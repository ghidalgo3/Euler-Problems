open System.Collections.Generic
open System.Numerics

// One rule: no use of mut!
let problem1 limit =
    [ 1 .. limit - 1 ]
    |> List.filter(fun n -> n % 3 = 0 || n % 5 = 0)
    |> List.sum

let memoize f =
    let dict = Dictionary<_, _>()
    fun x ->
        // out parameters become tuple members!
        let exist, value = dict.TryGetValue x
        match exist with
        | true -> value
        | false ->
            let y = f x
            dict.Add(x, y)
            y

let rec fib = memoize (fun (n: int) ->
    match n with
    | 0 | 1 -> bigint 1
    | _ -> fib (n - 1) + fib (n - 2))

/// Evaluate a sequence until one value productes a false predicate
let rec takeWhile fn test i =
    seq {
        let y = fn i
        match test y with
        | true ->
            yield y
            yield! takeWhile fn test (i + 1)
        | false ->
            ()
    }

// we can approximate with an order or magnitude check? if n = v * 10^P we can go up to 10^(P/2 + 1), + 1 to over count.
// >> is a function composition operator!
// >>> is the right bit shift operator!
// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/symbol-and-operator-reference/#function-symbols-and-operators
let approximateSqrt (n : bigint) : bigint = n >>> (int(n.GetBitLength()) / 2 - 1)

// Does not include 1
let rec primeFactors (n : bigint) =
    let hi = approximateSqrt n
    let rec p (i : bigint) =
        match n % i with
        | zero when zero = 0 -> i :: primeFactors (n / i)
        | remainder when i <= hi -> p (i + bigint 1)
        | _ -> [n]
    if n = 1 then [] else p 2

let freq ns =
    List.fold (fun (acc: Map<bigint, int>) n ->
            if acc.ContainsKey n then
                acc.Change (n, fun n -> Some(n.Value + 1))
            else
                acc.Add (n, 1)
        ) Map.empty ns

let isPrime n = (primeFactors n).Length = 1

let fibs =
    takeWhile fib (fun n -> n < 4_000_000) 0
    |> Seq.filter (fun n -> n % (bigint 2) = (bigint 0))
    |> Seq.sum

// This is an example of an "active pattern"
// The pattern is that when a parameter is implicitly supplied, it should go last
let (|Even|Odd|) input = if input % 2 then Even else Odd 

let isPalindrome n = 
    let rec isStringPalindrome (s : string) = 
        match s.Length with
        | 1 -> true
        | 2 -> s.[0] = s.[1]
        | _ -> s.[0] = s.[s.Length - 1] && isStringPalindrome (s.Substring(1, s.Length - 2))
    isStringPalindrome (n.ToString())
    // even
    // odd

let allPairs xs =
    seq {
        for x in xs do
            for y in xs do
                yield (x, y)
    }

let lcm a b = 
    let primesA = (primeFactors >> freq) a
    let primesB = (primeFactors >> freq) b
    // primesA is my initial value
    // primesB is my map i'm actually folding over
    // inside of fold, acc is primesA 
    // prime and freq are entries of primesB
    (primesA, primesB) ||> Map.fold (fun acc prime freq ->
        if (acc.ContainsKey prime) then
            acc.Change (prime, fun n -> Some(max (n.Value) freq))
        else
            acc.Add (prime, freq)
        )

/// Convert a prime factorization to a number
let toNumber (factors : Map<bigint, int>) : bigint =
    // inside, acc is 1 (initially)
    // prime and power are the entries of factors
    (bigint 1, factors) ||> Map.fold (fun acc (prime:bigint) power ->
        acc * bigint.Pow(prime, power))

// is it the LCM? Yes!
let lcmAll xs =
    xs |> List.fold (fun acc n ->
        lcm acc n |> toNumber) 1

// if you're going to init and map a numeric range, list expressions are a nice way to avoid a List.map 
[ for (x, y) in allPairs [1 .. 999] -> x * y ]
|> List.filter isPalindrome 
|> List.max
printfn "%A" fibs


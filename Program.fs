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
        | remainder when i < hi -> p (i + bigint 1)
        | _ -> [n]
    p 2

let fibs =
    takeWhile fib (fun n -> n < 4_000_000) 0
    |> Seq.filter (fun n -> n % (bigint 2) = (bigint 0))
    |> Seq.sum

printfn "%A" fibs

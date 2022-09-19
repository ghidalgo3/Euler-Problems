open Numbers

// One rule: no use of mut!
let problem1 limit =
    [ 1 .. limit - 1 ]
    |> List.filter(fun n -> n % 3 = 0 || n % 5 = 0)
    |> List.sum

let problem6 (n : int) =
    let sum = arithmeticSum n
    let squareOfSum  = sum * sum
    let sumOfSquares = List.sum <| [ for i in 1 .. n -> i * i ]
    squareOfSum - sumOfSquares
    // find the difference between the sum of squares and the square of the sum
    // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

// if you're going to init and map a numeric range, list expressions are a nice way to avoid a List.map 
[ for (x, y) in allPairs [1 .. 999] -> x * y ]
|> List.filter isPalindrome 
|> List.max

printfn "%A" fibs
printfn "Problem_6(10):  %A" (problem6 10)
printfn "Problem 6(100): %A" (problem6 100)


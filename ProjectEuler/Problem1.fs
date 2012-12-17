module Problem1
open System

//sum of all multiples of 3 or 5 below 1000
let solve () = [1..999] |> List.filter (fun n -> n % 3 = 0 || n % 5 = 0) |> List.sum 
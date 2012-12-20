namespace ProjectEuler
open System

type public Problem3() = 
 let n = 10I //600851475143I
 
 let IsPrime (x : int) : bool = 
  match x with
  | a when a < 2 -> false
  | _ -> [2 .. int (Math.Round (Math.Sqrt (float x)))] |> Seq.filter (fun e -> x % e = 0) |> Seq.isEmpty 
 
 let rec NextPrime (x : int) : int = 
  match IsPrime x with
  | true -> x
  | false -> NextPrime (x + 1)
 
 let rec FactorPrimes (x : bigint) (y : int) : (list<int>) = 
   match x, y with
   | z, _ when z = 1I -> []
   | _, 0 -> []
   | a, b -> if a % (bigint b) = 0I then b :: FactorPrimes (a / (bigint b)) 2
             else FactorPrimes a (NextPrime b + 1)
 
 [<ProbSolutionMethodAttr()>]
 member this.Solve() = FactorPrimes n 2
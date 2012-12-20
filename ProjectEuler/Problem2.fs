namespace ProjectEuler

type public Problem2() = 
 
 let SeqFib = Seq.unfold(fun (e1, e2) -> Some( e1, (e2, e1 + e2))) (1, 2)
  
 [<ProbSolutionMethodAttr()>]
 member this.Solve() = SeqFib |> Seq.takeWhile (fun x -> x < 4000000) |> Seq.filter (fun y -> y % 2 = 1) |>  Seq.sum 
 
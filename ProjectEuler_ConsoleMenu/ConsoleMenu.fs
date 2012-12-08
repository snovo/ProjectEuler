namespace ProjectEuler

open System
open System.Linq 
 
type public ConsoleMenu (iIdxGoBack : int, iNumProblems : int, iNumProbsByRange) =
 let selectOption = "Selecione o prolema pretendido para verificar a soluçao: "
 let invalidOption = "Invalid Option!"

 member this.enterChoice (iGoBack : int) (rangeOptions : list<int>) : int = 
    Console.Write (selectOption)
    let mutable answer : int = -1
    while answer = -1 && rangeOptions.Contains(answer) = false && answer <> iGoBack do
     try
      answer <- Convert.ToInt32 (Console.ReadLine())
     with 
     | e -> Console.Write (invalidOption + e.Message + " " + selectOption)
    answer

 member this.selectRangeOfProblems : int = 
    let l = [0 .. iNumProbsByRange .. iNumProblems]
    let mutable i : int = 1
    for range in l do
     printfn "%d - Problem %d to %d" i (range + 1) (range + iNumProbsByRange)
     i <- i + 1
    printfn ""
    printfn "0 - Exit"
    printfn ""
    this.enterChoice 0 [1.. (iNumProblems / iNumProbsByRange)]

 member this.selectProblem (iRange : int) (iNProbByRange : int) : int = 
    let l = [((iRange - 1) * iNProbByRange) + 1 .. iNProbByRange * iRange]
    for problem in l do printfn "%d - Problem %d" problem problem
    printfn ""
    printfn "0 - Go back"
    printfn ""
    this.enterChoice 0 [1..iNProbByRange]
module Main

open System
open System.Linq 
open ProjectEuler

[<EntryPoint>]
let main args = 
    let iNProbByRange = 30
    let iNProblems = 400
    let iNumRanges = iNProblems / iNProbByRange
    let iIdxGoBack = 0
    let consoleMenu = new ProjectEuler.ConsoleMenu(iIdxGoBack, iNProblems, iNProbByRange )
    let mutable choiceRange = consoleMenu.selectRangeOfProblems 
    let mutable choiceProblem = 0
    while choiceRange > 0 do
     match choiceRange with
     | a when a > 0 && a < iNumRanges -> choiceProblem <- consoleMenu.selectProblem choiceRange iNProbByRange
                                         match choiceProblem with
                                         | 0 -> choiceRange <- consoleMenu.selectRangeOfProblems 
                                         | _ -> let result = (CheckSolution.SolveProblem choiceProblem)
                                                Console.Write ("Solution of problem {0} is: ",  choiceProblem)
                                                match result with
                                                | null -> printfn "UNKNOWN"
                                                | x -> Console.WriteLine (x)
     | _ -> choiceRange <- consoleMenu.enterChoice 0 [1.. (iNProblems / iNProbByRange)]
    Console.Read()
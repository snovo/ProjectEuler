namespace ProjectEuler
open System
open System.Reflection 

type public CheckSolution (iProblem : int) =
 let bindingFlags = BindingFlags.Public ||| BindingFlags.NonPublic |||
                     BindingFlags.Instance ||| BindingFlags.Static ||| 
                     BindingFlags.DeclaredOnly
 

 member this.SolveProblem() =
  let iProblemToCheck = iProblem
  let tyName = "ProjectEuler.Problem" + iProblem.ToString()
  let mutable tyObj = null
  let ass = System.Reflection.Assembly.GetExecutingAssembly()
  try
   let obj = System.Activator.CreateInstance (null, tyName)
   tyObj <- Type.GetType(tyName)
   for m in tyObj.GetMethods (bindingFlags) |> Array.filter (fun m -> Array.length(m.GetCustomAttributes(Type.GetType("ProjectEuler.ProbSolutionMethodAttr"), false)) > 0) do
     let r = m.Invoke(obj,null)
     Console.WriteLine(r)
  with
  | e -> Console.Clear () 
         printfn "Erro: %s " e.Message
  
  
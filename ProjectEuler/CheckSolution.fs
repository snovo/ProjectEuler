namespace ProjectEuler
open System
open System.Reflection 

type public CheckSolution (iProblem : int) =
 let bindingFlags = BindingFlags.Public ||| BindingFlags.NonPublic |||
                     BindingFlags.Instance ||| BindingFlags.Static ||| 
                     BindingFlags.DeclaredOnly
 let methods (ty : Type) = 
  ty.GetMethods (bindingFlags)


 member this.SolveProblem() =
  let iProblemToCheck = iProblem
  let tyName = "Problem" + iProblem.ToString()
  let mutable obj = null
  let mutable tyObj = null
  try
   Console.WriteLine( System.Reflection.Assembly.GetExecutingAssembly().GetName())
   obj <- System.Activator.CreateInstance (System.Reflection.Assembly.GetExecutingAssembly().FullName, tyName)
   tyObj <- obj.GetType()
   methods tyObj |> Array.fold (fun desc meth -> desc + sprintf " %s " meth.Name) "" |> printf " %s "
  with
  | e -> printf " %s " e.Message
  
  
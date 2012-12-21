namespace ProjectEuler
open System
open System.Reflection 
module CheckSolution =


 let bindingFlags = BindingFlags.Public ||| BindingFlags.NonPublic |||
                     BindingFlags.Instance ||| BindingFlags.Static ||| 
                     BindingFlags.DeclaredOnly
 
 let SolveProblem(iProblem : int) : obj =
  let tyName = "ProjectEuler.Problem" + iProblem.ToString()
  let mutable result = null
  let ass = System.Reflection.Assembly.GetExecutingAssembly()
  
  try
   let wrappedProblemClass : System.Runtime.Remoting.ObjectHandle = System.Activator.CreateInstance (null, tyName)
   result <- ((Type.GetType(tyName).GetMethods (bindingFlags) |> Array.filter (fun m -> Array.length(m.GetCustomAttributes(Type.GetType("ProjectEuler.ProbSolutionMethodAttr"), false)) > 0) |> Array.map (fun m -> m.Invoke(wrappedProblemClass.Unwrap(), null))).[0])
  with
  | t as TypeLoadException -> result <- "Error: problem not found! Maybe isn't solved yet!\n" + t.Message
  //| _ -> result <- "Unknown Error!\n"
  
  result
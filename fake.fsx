#light (*
    exec fsharpi --exec $0 --quiet
*)

let command (cmd:string) (arguments:string) =
  let psi = new System.Diagnostics.ProcessStartInfo(cmd)
  psi.Arguments <- arguments
  psi.UseShellExecute <- false;
  let p = System.Diagnostics.Process.Start(psi)
  p.WaitForExit();
  p.ExitCode

let installPackageIfMissing (package:string) (present:bool) =
  if not present then
    printfn "installing %s" package
    let commandText = "nuget"
    let commandArguments = sprintf "Install %s -OutputDirectory packages -ExcludeVersion" package
    let installCommand = command commandText commandArguments
    if installCommand = 0 then
      printfn "Successfully installed %s" package
    else
      printfn "Failed to install %s!" package





printfn "Building Project"

let fakeIsInstalled = System.IO.Directory.Exists "packages/FAKE"
installPackageIfMissing "FAKE" fakeIsInstalled

let nunitRunnerIsInstalled = System.IO.Directory.Exists "packages/NUnit.Runners"
installPackageIfMissing "NUnit.Runners" nunitRunnerIsInstalled

let nugetIsInstalled = System.IO.Directory.Exists "tools/Nuget"
if not nugetIsInstalled then
  System.IO.Directory.CreateDirectory "./tools/Nuget" |> ignore
  let installCommand = command "wget" "-O ./tools/Nuget/nuget.exe https://nuget.org/nuget.exe"
  if installCommand = 0 then
    printfn "Successfully downloaded nuget"
  else
    printfn "Failed to download nuget!"


command "mono" "packages/FAKE/tools/FAKE.exe build.fsx"

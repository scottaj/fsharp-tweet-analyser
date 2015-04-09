// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

RestorePackages()

let projectName = "tweet-analyser-enterprise-ready-edition"
let srcTarget = sprintf "./%s/**/*.fsproj" projectName
let buildDir = "./build"

Target "Clean" (fun _ ->
    CleanDirs [buildDir;]
)

Target "Build" (fun _ ->
  !! srcTarget
     |> MSBuildRelease buildDir "Build"
     |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    !! (sprintf "%s/%s.exe" buildDir projectName)
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = buildDir + "/TestResults.xml" })
)

Target "Default" (fun _ ->
    trace "Building project"
)

"Clean"
  ==> "Build"
  ==> "Test"
  ==> "Default"

// start build
RunTargetOrDefault "Default"

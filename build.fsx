// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"
open Fake

RestorePackages()

let projectName = "tweet-analyser-enterprise-ready-edition"
let srcTarget = sprintf "./%s/**/*.fsproj" projectName
let testTarget = sprintf "./%s-tests/**/*.fsproj" projectName
let buildDir = "./build"
let testDir = "./test"

Target "Clean" (fun _ ->
    CleanDirs [buildDir; testDir;]
)

Target "Build" (fun _ ->
  !! srcTarget
     |> MSBuildRelease buildDir "Build"
     |> Log "AppBuild-Output: "
)

Target "BuildTest" (fun _ ->
  !! testTarget
     |> MSBuildRelease testDir "Build"
     |> Log "AppBuild-Output: "
)

Target "Test" (fun _ ->
    !! (sprintf "%s/%s-tests.dll" testDir projectName)
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true;
             OutputFile = testDir + "/TestResults.xml" })
)

Target "Default" (fun _ ->
    trace "Building project"
)

"Clean"
  ==> "Build"
  ==> "BuildTest"
  ==> "Test"
  ==> "Default"

// start build
RunTargetOrDefault "Default"

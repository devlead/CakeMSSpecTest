#tool nuget:?package=Machine.Specifications.Runner.Console&version=0.9.3

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Task("Clean")
    .Does(() =>
{
    CleanDirectories($"./src/**/bin/{configuration}/*");
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    NuGetRestore("./src/CakeMSSpec.sln");
});


Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    // Use XBuild
      MSBuild("./src/CakeMSSpec.sln", settings =>
        settings.SetConfiguration(configuration));
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    MSpec($"./src/**/bin/{configuration}/*.Tests.dll");
});

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

RunTarget(target);
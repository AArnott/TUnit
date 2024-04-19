﻿using System.Diagnostics;

namespace TUnit.Engine.SourceGenerator.Tests;

public class Git
{
    private static readonly Lazy<DirectoryInfo> LazyRootDirectory = new(() =>
    {
        var processStartInfo = new ProcessStartInfo("git", "rev-parse --show-toplevel")
        {
            RedirectStandardOutput = true
        };
        var process = Process.Start(processStartInfo)!;
        process.WaitForExit();
        return new DirectoryInfo(process.StandardOutput.ReadToEnd().Trim());
    });
    
    public static DirectoryInfo RootDirectory => LazyRootDirectory.Value;
}
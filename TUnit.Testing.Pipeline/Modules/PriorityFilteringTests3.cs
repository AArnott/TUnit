﻿using FluentAssertions;
using ModularPipelines.Context;

namespace TUnit.Testing.Pipeline.Modules;

public class PriorityFilteringTests3 : TestModule
{
    protected override async Task<TestResult?> ExecuteAsync(IPipelineContext context, CancellationToken cancellationToken)
    {
        return await RunTestsWithFilter(context, 
            "/*/*/PriorityFilteringTests/*[Priority=*i*]",
            [
                result => result.Successful.Should().BeTrue(),
                result => result.Total.Should().Be(5),
                result => result.Passed.Should().Be(5),
                result => result.Failed.Should().Be(0),
                result => result.Skipped.Should().Be(0)
            ], cancellationToken);
    }
}
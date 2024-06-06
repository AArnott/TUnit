﻿using FluentAssertions;
using ModularPipelines.Context;

namespace TUnit.Testing.Pipeline.Modules;

public class CustomerFilteringTests2 : TestModule
{
    protected override async Task<TestResult?> ExecuteAsync(IPipelineContext context, CancellationToken cancellationToken)
    {
        return await RunTestsWithFilter(context, 
            "/*/*/CustomFilteringTests/*[one=no]",
            [
                result => result.Successful.Should().BeTrue(),
                result => result.Total.Should().Be(1),
                result => result.Passed.Should().Be(1),
                result => result.Failed.Should().Be(0),
                result => result.Skipped.Should().Be(0)
            ], cancellationToken);
    }
}
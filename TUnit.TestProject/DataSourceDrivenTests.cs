﻿using TUnit.Core;

namespace TUnit.TestProject;

public class DataSourceDrivenTests
{
    [DataSourceDrivenTest]
    [MethodData(nameof(SomeMethod))]
    public void DataSource_Method(int value)
    {
    }
    
    [DataSourceDrivenTest]
    [ClassData(typeof(SomeClass))]
    public void DataSource_Class(int value)
    {
    }

    public int SomeMethod() => 1;

    public class SomeClass
    {
        public int Value => 1;
    }
}
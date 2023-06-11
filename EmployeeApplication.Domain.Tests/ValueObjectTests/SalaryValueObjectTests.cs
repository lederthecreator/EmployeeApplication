using System.Runtime.InteropServices;
using Domain.AggregationModels.EmployeeAggregate;

namespace EmployeeApplication.Domain.Tests.ValueObjectTests;

public class SalaryValueObjectTests
{
    [Fact]
    public void CreateSalaryInstanceFromDecimalSuccess()
    {
        // Arrange
        const decimal salary = 130_000m;
        
        // Act
        var result = new Salary(salary);
        
        // Assert
        Assert.Equal(salary, result.Value);
    }
    
    [Fact]
    public void CreateSalaryInstanceFromStringSuccess()
    {
        // Arrange
        const string salary = "130000";
        const decimal correctSalary = 130_000m;
        
        // Act
        var result = new Salary(salary);
        
        // Assert
        Assert.Equal(correctSalary, result.Value);
    }

    [Theory]
    [InlineData(-10000)]
    [InlineData(0)]
    public void CreateSalaryInstanceFromDecimalFailure(decimal salary)
    {
        // Assert
        Assert.Throws<Exception>(() =>
        {
            _ = new Salary(salary);
        });
    }
    
    [Theory]
    [InlineData("-10000")]
    [InlineData("0")]
    [InlineData("")]
    public void CreateSalaryInstanceFromStringFailure(string salary)
    {
        // Assert
        Assert.Throws<Exception>(() =>
        {
            _ = new Salary(salary);
        });
    }

    [Theory]
    [InlineData(10000)]
    [InlineData(120301)]
    [InlineData(1200100)]
    public void SetSalaryToInstanceSuccess(decimal salary)
    {
        // Arrange
        var instance = new Salary(1);
        
        // Act
        instance.SetSalary(salary);
        
        // Assert
        Assert.Equal(salary, instance.Value);
    }

    [Theory]
    [InlineData(-10000)]
    [InlineData(-101201200)]
    [InlineData(0)]
    public void SetSalaryToInstanceFailure(decimal salary)
    {
        // Arrange
        var instance = new Salary(1);
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            instance.SetSalary(salary);
        });
    }
}
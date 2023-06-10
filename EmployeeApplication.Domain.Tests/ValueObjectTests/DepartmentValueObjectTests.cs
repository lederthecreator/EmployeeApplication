using Domain.AggregationModels.EmployeeAggregate;

namespace EmployeeApplication.Domain.Tests;

public class DepartmentValueObjectTests
{
    [Fact]
    public void CreateDepartmentInstanceSuccess()
    {
        // Arrange
        const string code = "123";
        const string fullName = "ООО ТЕСТОВОЕ";
        
        // Act
        var result = new Department(code, fullName);
        
        // Assert
        Assert.Equal(code, result.Code);
        Assert.Equal(fullName, result.FullName);
    }

    [Fact]
    public void CreateDepartmentInstanceFailure()
    {
        // Arrange
        const string code = "12";
        const string fullName = "ООО ТЕСТОВОЕ";
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            _ = new Department(code, fullName);
        });
    }

    [Fact]
    public void SetCodeToInstanceSuccess()
    {
        // Arrange
        var department = new Department("123", "ООО ТЕСТОВОЕ");
        const string newCode = "111";
        
        // Act
        department.SetCode(newCode);
        
        // Assert
        Assert.Equal(newCode, department.Code);
    }

    [Theory]
    [InlineData("123123")]
    [InlineData("")]
    public void SetCodeToInstanceFailure(string newCode)
    {
        // Arrange
        var department = new Department("123", "ООО ТЕСТОВОЕ");
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            department.SetCode(newCode);
        });
    }
    
    [Fact]
    public void SetFullNameToInstanceSuccess()
    {
        // Arrange
        var department = new Department("123", "ООО ТЕСТОВОЕ");
        const string fullName = "ОАО ТЕСТИРУЕМОЕ";
        
        // Act
        department.SetFullName(fullName);
        
        // Assert
        Assert.Equal(fullName, department.FullName);
    }

    [Theory]
    [InlineData("000 Т3СТ0В03")]
    [InlineData("")]
    public void SetFullNameToInstanceFailure(string newName)
    {
        // Arrange
        var department = new Department("123", "ООО ТЕСТОВОЕ");
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            department.SetFullName(newName);
        });
    }
}
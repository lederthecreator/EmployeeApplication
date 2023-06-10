using Domain.AggregationModels.EmployeeAggregate;

namespace EmployeeApplication.Domain.Tests.ValueObjectTests;

public class BirthDayValueObjectTests
{
    [Fact]
    public void CreateBirthDateFromDateOnlyInstanceSuccess()
    {
        // Arrange
        var date = new DateOnly(2023, 6, 9);
        
        // Act
        var result = new BirthDate(date);
        
        // Assert
        Assert.Equal(date, result.Value);
    }

    [Fact]
    public void CreateBirthDateFromStringInstanceSuccess()
    {
        // Arrange
        var date = "09.06.2023";
        var correctDate = new DateOnly(2023, 6, 9);
        
        // Act
        var result = new BirthDate(date);
        
        // Assert
        Assert.Equal(correctDate, result.Value);
    }

    [Fact]
    public void CreateBirthDateFromStringInstanceFailure()
    {
        // Arrange
        var date = "06.09.2023";
        var correctDate = new DateOnly(2023, 6, 9);
        
        // Act
        var result = new BirthDate(date);
        
        // Assert
        Assert.NotEqual(correctDate, result.Value);
    }
    
}
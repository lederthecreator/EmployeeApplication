using Domain.AggregationModels.EmployeeAggregate;

namespace EmployeeApplication.Domain.Tests;

public class FullNameValueObjectTests
{
    [Fact]
    public void CreateFullNameWithoutPatronymicInstanceSuccess()
    {
        // Arrange 
        const string surname = "Иванов";
        const string firstName = "Иван";

        // Act
        var result = new FullName(surname, firstName);

        // Assert
        Assert.Equal(surname, result.Surname);
        Assert.Equal(firstName, result.FirstName);
    }

    [Fact]
    public void CreateFullNameWithPatronymicInstanceSuccess()
    {
        // Arrange 
        const string surname = "Иванов";
        const string firstName = "Иван";
        const string patronymic = "Иванович";

        // Act
        var result = new FullName(surname, firstName, patronymic);

        // Assert
        Assert.Equal(surname, result.Surname);
        Assert.Equal(firstName, result.FirstName);
        Assert.Equal(patronymic, result.PatronymicName);
    }

    [Fact]
    public void CreateFullNameWithIncorrectParamsInstanceFailure()
    {
        // Arrange
        const string incorrectSurname = "123";
        const string incorrectFirstName = "Иванов";
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            _ = new FullName(incorrectSurname, incorrectFirstName);
        });
    }

    [Fact]
    public void SetPatronymicNameToInstanceSuccess()
    {
        // Arrange
        var fullName = new FullName("Иванов", "Иван");
        const string patronymicName = "Иванович";
        
        // Act 
        fullName.SetPatronymicName(patronymicName);
        
        // Assert
        Assert.Equal(patronymicName, fullName.PatronymicName);
    }

    [Theory]
    [InlineData("1")]
    [InlineData("")]
    [InlineData("Иванови4")]
    public void SetPatronymicNameToInstanceFailure(string patronymicName)
    {
        // Arrange
        var fullName = new FullName("Иванов", "Иван");
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            fullName.SetPatronymicName(patronymicName);
        });
    }

    [Fact]
    public void SetSurnameToInstanceSuccess()
    {
        // Arrange
        var fullName = new FullName("Петров", "Петр");
        const string surname = "Иванов";
        
        // Act
        fullName.SetSurname(surname);
        
        // Assert
        Assert.Equal(surname, fullName.Surname);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("")]
    [InlineData("Иван0в")]
    public void SetSurnameToInstanceFailure(string surname)
    {
        // Arrange
        var fullName = new FullName("Иванов", "Иван");
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            fullName.SetSurname(surname);
        });
    }
    
    [Fact]
    public void SetFirstNameToInstanceSuccess()
    {
        // Arrange
        var fullName = new FullName("Петров", "Петр");
        const string firstName = "Иван";
        
        // Act
        fullName.SetFirstName(firstName);
        
        // Assert
        Assert.Equal(firstName, fullName.FirstName);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("")]
    [InlineData("1ван")]
    public void SetFirstNameToInstanceFailure(string firstName)
    {
        // Arrange
        var fullName = new FullName("Иванов", "Иван");
        
        // Assert
        Assert.Throws<Exception>(() =>
        {
            fullName.SetFirstName(firstName);
        });
    }
}
namespace DivergentChange.Test;

public class EmailValidatorTest
{
    private CustomerServiceTest _customerServiceTest;
    private readonly EmailValidator emailValidator = new EmailValidator();

    public EmailValidatorTest(CustomerServiceTest customerServiceTest)
    {
        _customerServiceTest = customerServiceTest;
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenEmailIsNull()
    {
        Assert.IsFalse(_customerServiceTest.service.IsValidEmail(null));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenEmailIsEmpty()
    {
        Assert.IsFalse(_customerServiceTest.service.IsValidEmail(""));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingAtSymbol()
    {
        Assert.IsFalse(_customerServiceTest.service.IsValidEmail("invalid.email.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingLocalPart()
    {
        Assert.IsFalse(_customerServiceTest.service.IsValidEmail("@domain.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingDomain()
    {
        Assert.IsFalse(_customerServiceTest.service.IsValidEmail("user@"));
    }

    [Test]
    public void IsValidEmail_shouldReturnTrue_whenEmailIsValid()
    {
        Assert.IsTrue(_customerServiceTest.service.IsValidEmail("user.name+tag@example.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnTrue_whenSimpleValidEmail()
    {
        Assert.IsTrue(_customerServiceTest.service.IsValidEmail("user@example.com"));
    }
}
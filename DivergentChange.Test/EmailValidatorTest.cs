namespace DivergentChange.Test;

[TestFixture]
public class EmailValidatorTest
{
    private readonly EmailValidator emailValidator = new EmailValidator();

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenEmailIsNull()
    {
        Assert.IsFalse(emailValidator.IsValidEmail(null));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenEmailIsEmpty()
    {
        Assert.IsFalse(emailValidator.IsValidEmail(""));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingAtSymbol()
    {
        Assert.IsFalse(emailValidator.IsValidEmail("invalid.email.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingLocalPart()
    {
        Assert.IsFalse(emailValidator.IsValidEmail("@domain.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnFalse_whenMissingDomain()
    {
        Assert.IsFalse(emailValidator.IsValidEmail("user@"));
    }

    [Test]
    public void IsValidEmail_shouldReturnTrue_whenEmailIsValid()
    {
        Assert.IsTrue(emailValidator.IsValidEmail("user.name+tag@example.com"));
    }

    [Test]
    public void IsValidEmail_shouldReturnTrue_whenSimpleValidEmail()
    {
        Assert.IsTrue(emailValidator.IsValidEmail("user@example.com"));
    }
}
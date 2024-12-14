using Microsoft.Extensions.DependencyInjection;

namespace SanitizerSharp.Test;

public class DependencyInjectedRuleTest : TestFixture<DependencyInjectedRuleTest>
{
    [Fact]
    public void SimpleTest()
    {
        Student student = new()
        {
            Name = "John",
            Age = 60,
            IsGraduated = false,
            IsMale = true,
            Email = "",
            Address = new Address
            {
                City = "New York",
                State = null
            },
            Note = "<script>alert('XSS')</script>"
        };
        
        var studentSanitizer = Services.GetRequiredService<ISanitizer<Student>>();
        
        studentSanitizer.Sanitize(student);
        
        Assert.DoesNotContain("<script>", student.Note);
        // Assert.Throws<ArgumentNullException>(() => studentSanitizer.Sanitize(student));
    }
}
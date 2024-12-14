using SanitizerSharp.Extensions.Rules;
using SanitizerSharp.FluentRule;

namespace SanitizerSharp.Test;

public class StudentSanitizer : SanitizerBase<Student, StudentSanitizer>
{
    protected override void DefineRules(RuleFor<Student> rule)
    {
        rule
            .If(s => s.Age < 18)
            .If(s => !s.IsGraduated)
            .Then(_ => Console.WriteLine("Student is underage and not graduated"))
            .If(s => s.IsMale)
            .Then(_ => Console.WriteLine("Student is Male"))
            .If(s => s.Age < 18)
            .If(s => s.IsGraduated)
            .Then(_ => Console.WriteLine("Student is underage yet graduated"))
            .ForProperty(s => s.Email)
            .If(string.IsNullOrEmpty)
            .Then(_ => Console.WriteLine("Email is empty"))
            .If(email => email.StartsWith("test"))
            .Then(email => Console.WriteLine($"Email is test ({email})"))
            .Next()
            .If(s => s.Age >= 18)
            .Then(_ => Console.WriteLine("Student is adult"))
            .ForProperty(x => x.Address.City)
            .If(string.IsNullOrEmpty)
            .Then(_ => Console.WriteLine("City is empty"))
            .If(city => city == "New York")
            .Then(_ => Console.WriteLine("City is New York"))
            .Next()
            .Apply(x => x.Note = x.Note.Replace("<script>", ""));
        // .ForProperty(x => x.Address.State)
        //     .ThrowIfNull(new ArgumentNullException(nameof(Address.State)))
        //     .Next();
    }
}
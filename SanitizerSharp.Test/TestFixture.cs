using Microsoft.Extensions.DependencyInjection;
using SanitizerSharp.Extensions.DependencyInjection;

namespace SanitizerSharp.Test;

public class TestFixture<T>: IClassFixture<T> where T : class
{
    public IServiceProvider Services { get; private set; }
    
    public TestFixture()
    {
        var sp = new ServiceCollection();
        sp.AddSanitizer<Student, StudentSanitizer>();
        Services = sp.BuildServiceProvider();
    }
}
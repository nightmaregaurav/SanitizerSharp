using SanitizerSharp.FluentRule;

namespace SanitizerSharp.Extensions.Rules;

public static class RuleForThrow
{
    public static RuleFor<TParent> Throw<TException, TParent>(
        this RuleFor<TParent> rule,
        TException exception
    ) where TException : Exception
    {
        return rule.Then(_ => throw exception);
    }
    
    public static RuleFor<TParent, TProperty> Throw<TException, TParent, TProperty>(
        this RuleFor<TParent, TProperty> rule,
        TException exception
    ) where TException : Exception
    {
        return rule.Then(_ => throw exception);
    }
    
    public static RuleFor<TParent> Throws<TException, TParent>(
        this RuleFor<TParent> rule,
        Func<TParent, TException> exceptionFactory
    ) where TException : Exception
    {
        return rule.Then(x => throw exceptionFactory(x));
    }
    
    public static RuleFor<TParent, TProperty> Throws<TException, TParent, TProperty>(
        this RuleFor<TParent, TProperty> rule,
        Func<TProperty, TException> exceptionFactory
    ) where TException : Exception
    {
        return rule.Then(x => throw exceptionFactory(x));
    }
}
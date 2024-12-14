using SanitizerSharp.FluentRule;

namespace SanitizerSharp.Extensions.Rules;

public static class RuleForNull
{
    public static RuleFor<TParent> IfNull<TParent>(this RuleFor<TParent> rule)
    {
        return rule.If(x => x == null);
    }
    
    public static RuleFor<TParent, TProperty> IfNull<TParent, TProperty>(this RuleFor<TParent, TProperty> rule)
    {
        return rule.If(x => x == null);
    }
    
    public static RuleFor<TParent> ThrowIfNull<TException, TParent>(
        this RuleFor<TParent> rule,
        TException exception
    ) where TException : Exception
    {
        return rule.IfNull().Throw(exception);
    }
    
    public static RuleFor<TParent, TProperty> ThrowIfNull<TException, TParent, TProperty>(
        this RuleFor<TParent, TProperty> rule,
        TException exception
    ) where TException : Exception
    {
        return rule.IfNull().Throw(exception);
    }
}
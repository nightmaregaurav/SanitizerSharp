using SanitizerSharp.FluentRule;

namespace SanitizerSharp;

public abstract class SanitizerBase<TFor, TSanitizer> : ISanitizer<TFor> where TSanitizer : SanitizerBase<TFor, TSanitizer>, new()
{
    protected abstract  void DefineRules(RuleFor<TFor> rule);

    public void Sanitize(TFor target)
    {
        var rule = new RuleFor<TFor>(target);
        DefineRules(rule);
        rule.Enforce();
    }
}
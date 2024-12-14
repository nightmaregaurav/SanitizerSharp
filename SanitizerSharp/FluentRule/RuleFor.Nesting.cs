namespace SanitizerSharp.FluentRule;

public class RuleFor<TParent, TProperty>(TProperty target, RuleFor<TParent> parentRuleSet)
{
    private readonly List<Func<TProperty, bool>> _conditions = [];
    
    public RuleFor<TParent, TProperty> If(Func<TProperty, bool> condition)
    {
        ArgumentNullException.ThrowIfNull(condition);
        _conditions.Add(condition);
        return this;
    }

    public RuleFor<TParent, TProperty> Then(Action<TProperty> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var patchedConditions = _conditions.Select(c => new Func<TParent, bool>(_ => c(target))).ToList();
        var patchedAction = new Action<TParent>(_ => action(target));
        parentRuleSet.AddRule(patchedConditions, patchedAction);
        _conditions.Clear();
        return this;
    }
    
    public RuleFor<TParent> Next()
    {
        return parentRuleSet;
    }
}
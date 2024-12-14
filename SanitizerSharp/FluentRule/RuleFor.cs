namespace SanitizerSharp.FluentRule;

public class RuleFor<TFor>(TFor target)
{
    private readonly List<KeyValuePair<List<Func<TFor, bool>>, Action<TFor>>> _rules = [];
    private readonly List<Func<TFor, bool>> _conditions = [];

    public RuleFor<TFor> If(Func<TFor, bool> condition)
    {
        ArgumentNullException.ThrowIfNull(condition);
        _conditions.Add(condition);
        return this;
    }
    
    public RuleFor<TFor> Apply(Action<TFor> action) => Then(action);

    public RuleFor<TFor> Then(Action<TFor> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        _rules.Add(new KeyValuePair<List<Func<TFor, bool>>, Action<TFor>>(_conditions.ToList(), action));
        _conditions.Clear();
        return this;
    }
    
    public RuleFor<TFor, TProperty> ForProperty<TProperty>(Func<TFor, TProperty> property)
    {
        ArgumentNullException.ThrowIfNull(property);
        _conditions.Clear();
        var rule = new RuleFor<TFor, TProperty>(property(target), this);
        return rule;
    }
    
    protected internal void AddRule(List<Func<TFor, bool>> conditions, Action<TFor> action)
    {
        ArgumentNullException.ThrowIfNull(conditions);
        ArgumentNullException.ThrowIfNull(action);
        _rules.Add(new KeyValuePair<List<Func<TFor, bool>>, Action<TFor>>(conditions, action));
    }

    public void Enforce()
    {
        foreach (var (conditions, action) in _rules)
        {
            if (conditions.All(c => c(target)))
            {
                action(target);
            }
        }
    }
}

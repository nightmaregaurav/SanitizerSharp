namespace SanitizerSharp;

public interface ISanitizer<in TFor>
{
    void Sanitize(TFor target);
}
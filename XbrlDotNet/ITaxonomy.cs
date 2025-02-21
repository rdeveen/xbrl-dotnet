namespace XbrlDotNet;

public interface ITaxonomy
{
    IEnumerable<IContext> Contexts { get; }
    NamespacePrefix Domain { get; }
    NamespacePrefix Dimension { get; }

    public interface PeriodDuration : ITaxonomy, IPeriodDuration;
    public interface PeriodInstant : ITaxonomy, IPeriodInstant;
}
namespace XbrlDotNet.Converters;

internal class Taxonomy(Report report)
{
    public void Convert(ITaxonomy instance)
    {
        report.Period = instance switch
        {
            IPeriodDuration period => new Period(period.Start, period.End),
            IPeriodInstant instant => new Period(instant.Instant),
            _ => report.Period
        };

        report.SetDimensionNamespace(instance.Dimension.Prefix, instance.Dimension.Namespace.NamespaceName);
        report.SetTypedDomainNamespace(instance.Domain.Prefix, instance.Domain.Namespace.NamespaceName);
    } 
}
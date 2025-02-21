namespace XbrlDotNet.Tests.TestTaxonomy;

internal record Taxonomy(params IEnumerable<IContext> Contexts) : ITaxonomy
{
    NamespacePrefix ITaxonomy.Domain => new("frc-vt-dm", FrcVtDm);
    NamespacePrefix ITaxonomy.Dimension => new("frc-vt-dim", FrcVtDim);
}
using XbrlDotNet.Dimensions;
using Entity = XbrlDotNet.Tests.TestTaxonomy.Entity;

namespace XbrlDotNet.Tests;

public static class TypedMembersTests
{
    [Fact]
    public static void AddTypedMembers()
    {
        var report = XbrlConverter.Convert(new TestTaxonomy(new TestContext("OwnerName")));

        using var scope = new AssertionScope(report.ToString);
        var root = report
            .Element(Xbrli + "xbrl")!;
        root.Should().HaveElement(Xbrli + "context").Which
            .Should().HaveElement(Xbrli + "scenario").Which
            .Should().HaveElement(Xbrldi + "typedMember").Which
            .Should().HaveAttributeWithValue("dimension", "frc-vt-dim:OwnersAxis").And
            .HaveElement(FrcVtDm + "OwnersTypedMember").Which
            .Should().HaveValue("OwnerName");
    }

    private record TestContext(string OwnersTypedMember) : IContext
    {
        IEntity IContext.Entity => Entity.Dummy;
        TypedMember[] IContext.TypedMembers =>
        [
            new (FrcVtDm + "OwnersTypedMember", FrcVtDim + "OwnersAxis", OwnersTypedMember)
        ];
        ExplicitMember[] IContext.ExplicitMembers => [];
    }

    private record TestTaxonomy(TestContext TestContext) : ITaxonomy
    {
        IEnumerable<IContext> ITaxonomy.Contexts => [TestContext];
        NamespacePrefix ITaxonomy.Domain => new("frc-vt-dm", FrcVtDm);
        NamespacePrefix ITaxonomy.Dimension => new("frc-vt-dim", FrcVtDim);
    }
}
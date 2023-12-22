using VContainer;
using VContainer.Unity;

namespace Template.Runtime.Core
{
    public sealed class MetaScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder scope) =>
            scope.RegisterEntryPoint<MetaEntryPoint>();
    }
}
using VContainer;
using VContainer.Unity;

namespace Template.Runtime.Game
{
    public sealed class GameScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder scope) =>
            scope.RegisterEntryPoint<GameEntryPoint>();
    }
}
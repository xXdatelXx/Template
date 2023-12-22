using Template.Tools.Unity;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Template.Runtime.Bootstrap
{
    public sealed class BootstrapScope : LifetimeScope
    {
        [SerializeField] private UnityScene _entry;
        [SerializeField] private UnityScene _empty;

        protected override void Awake()
        {
            IsRoot = true;
            DontDestroyOnLoad(this);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder scope)
        {
            scope.RegisterInstance(new UnitySceneWithMemoryAllocate(_entry, _empty)).AsImplementedInterfaces();
            scope.RegisterEntryPoint<BootstrapEntryPoint>();
        }
    }
}
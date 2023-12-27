using Template.Engine.Exceptions;
using Template.Engine.Unity;
using Template.Runtime.Tools;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Template.Runtime.Core
{
    public sealed class BootstrapScope : LifetimeScope
    {
        [SerializeField] private ScenesSet _scenes;

        protected override void Awake()
        {
            IsRoot = true;
            DontDestroyOnLoad(this);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder scope)
        {
            IScene meta = new UnitySceneWithMemoryAllocate(_scenes.Meta, _scenes.Empty);

            IReport report = new UnityDiagnosticReport(new UserReportingScript());
            IReport limitReport = new LimitReport(report, limit: 10, time: 60);

            scope.RegisterInstance(meta);
            scope.RegisterEntryPoint<Bootstrap>();
            scope.RegisterEntryPointExceptionHandler(e => limitReport.Send(e));
        }
    }
}
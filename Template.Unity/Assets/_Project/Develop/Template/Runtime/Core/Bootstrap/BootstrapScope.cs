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
        [SerializeField] private UserReportingScript _userReport;

        protected override void Awake()
        {
            IsRoot = true;
            DontDestroyOnLoad(this);
            base.Awake();
        }

        protected override void Configure(IContainerBuilder scope)
        {
            IScene meta = new UnitySceneWithMemoryAllocate(_scenes.Meta, _scenes.Empty);

            IReport report = new UnityDiagnosticReport(_userReport);
            IReport limitReport = new LimitReport(report, limit: 10, time: 60);

            scope.RegisterInstance(meta);
            scope.RegisterEntryPoint<Bootstrap>();
            scope.RegisterInstance(limitReport);
#if !UNITY_EDITOR
            scope.RegisterEntryPointExceptionHandler(e => limitReport.Send(e));
#endif
        }
    }
}
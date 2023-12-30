using Balancy;
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

            var config = new Balancy.AppConfig
            {
                ApiGameId = "1fdcaaf2-a422-11ee-9aad-0260a0c170f4",
                PublicKey = "YTk5Mzc0MzAyYWNlMzVjMDM1ZTI3OG",
                Environment = Constants.Environment.Development,
            };
            Balancy.Main.Init(config);

            scope.RegisterInstance(meta);
            scope.RegisterInstance(limitReport);
            scope.RegisterEntryPoint<Bootstrap>();
#if !UNITY_EDITOR
            scope.RegisterEntryPointExceptionHandler(e => limitReport.Send(e));
#endif
        }
    }
}
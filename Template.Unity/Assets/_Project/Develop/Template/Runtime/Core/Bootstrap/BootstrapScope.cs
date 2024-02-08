using System;
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
         IReport limitReport = new LimitReport(report, 10, 60);
         IReport strictReport = new StrictReport(limitReport);

         AppConfig config = new()
         {
            ApiGameId = Environment.GetEnvironmentVariable("ONLINE_CONFIGS_ID"),
            PublicKey = Environment.GetEnvironmentVariable("ONLINE_CONFIGS_PUBLIC_KEY"),
            Environment = Constants.Environment.Development
         };

         scope.RegisterInstance(meta);
         scope.RegisterInstance(strictReport);
         scope.RegisterInstance(config);
         scope.RegisterEntryPoint<Bootstrap>();
#if !UNITY_EDITOR
            scope.RegisterEntryPointExceptionHandler(e => limitReport.Send(e));
#endif
      }
   }
}
using System.Collections.Generic;
using Template.Engine.Extensions;

namespace Template.Runtime.Core.Extensions
{
   public static class GameLoopScopeExtensions
   {
      public static void Add(this IGameLoopScope scope, IEnumerable<IGameLoopObject> range) =>
         range.Foreach(scope.Add);

      public static void Add(this IGameLoopScope scope, IEnumerable<IPhysicGameLoopObject> range) =>
         range.Foreach(scope.Add);

      public static void Add(this IGameLoopScope scope, IEnumerable<ILateGameLoopObject> range) =>
         range.Foreach(scope.Add);
   }
}
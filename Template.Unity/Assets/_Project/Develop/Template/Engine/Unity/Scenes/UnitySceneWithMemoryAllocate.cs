using System;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Template.Engine.Unity
{
   /// <summary>
   /// Decorator for 100% unloading of all resources of the previous scene in empty scene
   /// </summary>
   public sealed class UnitySceneWithMemoryAllocate : IScene
   {
      private readonly IScene _origin;
      private readonly IScene _empty;

      public UnitySceneWithMemoryAllocate(IScene origin, IScene empty)
      {
         _origin = origin;
         _empty = empty;
      }

      public void Open()
      {
         if (_origin is null || _empty is null)
            throw new NullReferenceException(nameof(Scene));
         if (Equals(_origin, _empty))
            throw new InvalidOperationException($"Scene {_origin} == {_empty}");

         Async().Forget();
         return;

         async UniTaskVoid Async()
         {
            _empty.Open();

            // Await for the next scene opening
            await UniTask.NextFrame();
            _origin.Open();
         }
      }
   }
}
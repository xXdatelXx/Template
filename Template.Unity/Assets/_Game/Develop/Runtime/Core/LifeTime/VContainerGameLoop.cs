using System;
using UnityEngine;
using VContainer.Unity;

namespace Template.Runtime.Core
{
   public sealed class VContainerGameLoop : IGameLoop, ILateTickable, IFixedTickable, ITickable
   {
      private readonly IGameLoopScope _scope;

      public VContainerGameLoop(IGameLoopScope scope) =>
         _scope = scope;

      public bool Playing { get; private set; }

      public void Play()
      {
         if (Playing)
            throw new InvalidOperationException("Loop is already playing");

         Playing = true;
      }

      public void Stop()
      {
         if (!Playing)
            throw new InvalidOperationException("Loop is already stopped");

         Playing = false;
      }

      public void Tick()
      {
         if (Playing)
            _scope.Tick(Time.deltaTime);
      }

      public void LateTick()
      {
         if (Playing)
            _scope.LateTick(Time.deltaTime);
      }

      public void FixedTick()
      {
         if (Playing)
            _scope.PhysicTick(Time.fixedDeltaTime);
      }
   }
}
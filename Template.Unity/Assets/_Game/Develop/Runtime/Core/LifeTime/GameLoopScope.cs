using System;
using System.Collections.Generic;

namespace Template.Runtime.Core
{
   public sealed class GameLoopScope : IGameLoopScope
   {
      public List<IGameLoopObject> Objects { get; init; }
      public List<IPhysicGameLoopObject> PhysicObjects { get; init; }
      public List<ILateGameLoopObject> LateObjects { get; init; }

      public void Add(IGameLoopObject o) =>
         Objects.Add(o ?? throw new ArgumentNullException(nameof(o)));

      public void Add(IPhysicGameLoopObject o) =>
         PhysicObjects.Add(o ?? throw new ArgumentNullException(nameof(o)));

      public void Add(ILateGameLoopObject o) =>
         LateObjects.Add(o ?? throw new ArgumentNullException(nameof(o)));

      public void Tick(float deltaTime) =>
         Objects.ForEach(o => o.Tick(deltaTime));

      public void PhysicTick(float deltaTime) =>
         PhysicObjects.ForEach(o => o.PhysicTick(deltaTime));

      public void LateTick(float deltaTime) =>
         LateObjects.ForEach(o => o.LateTick(deltaTime));
   }
}
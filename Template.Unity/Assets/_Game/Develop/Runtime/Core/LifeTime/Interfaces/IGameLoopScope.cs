namespace Template.Runtime.Core
{
   public interface IGameLoopScope : IReadOnlyGameLoopScope
   {
      void Tick(float deltaTime);
      void PhysicTick(float deltaTime);
      void LateTick(float deltaTime);
   }
}
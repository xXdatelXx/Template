namespace Template.Runtime.Core
{
   public interface IReadOnlyGameLoopScope
   {
      void Add(IGameLoopObject o);
      void Add(IPhysicGameLoopObject o);
      void Add(ILateGameLoopObject o);
   }
}
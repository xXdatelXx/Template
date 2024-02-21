namespace Template.Runtime.Core
{
   public interface ILateGameLoopObject
   {
      void LateTick(in float deltaTime);
   }
}
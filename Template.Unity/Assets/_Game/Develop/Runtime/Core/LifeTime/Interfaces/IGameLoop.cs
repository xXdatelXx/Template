namespace Template.Runtime.Core
{
   public interface IGameLoop
   {
      bool Playing { get; }
      void Play();
      void Stop();
   }
}
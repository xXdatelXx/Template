using Cysharp.Threading.Tasks;

namespace Template.Engine.Time
{
    public static class TimerExtension
    {
        public static bool Rest(this ITimer t) =>
            !t.Playing;
        
        public static async UniTask End(this ITimer t) =>
            await UniTask.WaitUntil(t.Rest);
    }
}
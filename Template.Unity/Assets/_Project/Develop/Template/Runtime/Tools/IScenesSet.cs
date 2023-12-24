using Template.Engine.Unity;

namespace Template.Runtime.Tools
{
    public interface IScenesSet
    {
        IScene Meta { get; }
        IScene Game { get; }
        IScene Empty { get; }
    }
}
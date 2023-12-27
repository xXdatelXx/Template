namespace Template.Engine.Time
{
    public interface ITimer
    {
        bool Playing { get; }
        void Play();
    }
}
using Template.Engine.Unity;
using VContainer.Unity;

namespace Template.Runtime.Core
{
    public sealed class Bootstrap : IStartable
    {
        private readonly IScene _entry;

        public Bootstrap(IScene entry) =>
            _entry = entry;

        public void Start()
        {
            //TODO: load configs

            _entry.Open();
        }
    }
}
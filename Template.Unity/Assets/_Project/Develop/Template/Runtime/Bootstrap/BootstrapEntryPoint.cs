using Template.Tools.Unity;
using VContainer.Unity;

namespace Template.Runtime.Bootstrap
{
    public sealed class BootstrapEntryPoint : IStartable
    {
        private readonly IScene _entry;

        public BootstrapEntryPoint(IScene entry) => 
            _entry = entry;

        public void Start()
        {
            //TODO: load configs

            _entry.Open();
        }
    }
}
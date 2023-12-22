using Template.Tools.Unity;
using UnityEngine;
using VContainer.Unity;

namespace Template.Runtime.Meta
{
    public sealed class MetaEntryPoint : IStartable
    {
        public MetaEntryPoint(IScene scene)
        {
            Debug.Log(scene.Name);
        }

        public void Start()
        {
            Debug.Log("start");
        }
    }
}
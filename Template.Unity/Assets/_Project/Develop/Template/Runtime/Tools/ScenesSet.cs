using Template.Engine.Unity;
using UnityEngine;

namespace Template.Runtime.Tools
{
    [CreateAssetMenu(menuName = "Template/Scenes/Set", fileName = nameof(ScenesSet))]
    public sealed class ScenesSet : ScriptableObject, IScenesSet
    {
        [SerializeField] private UnityScene _meta;
        [SerializeField] private UnityScene _game;
        [SerializeField] private UnityScene _empty;

        public IScene Meta => _meta;
        public IScene Game => _game;
        public IScene Empty => _empty;
    }
}
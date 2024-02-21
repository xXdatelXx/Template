#if UNITY_EDITOR
using System.Linq;
using Sirenix.OdinInspector;

namespace Template.Runtime.Core
{
   public sealed partial class WorldEntity
   {
      [Button]
      public void FindFactories() =>
         _factories = GetComponentsInChildren<IEntityModuleFactory>().ToList();

      [Button]
      public void SortFactories() =>
         this.SortFactories(_factories);
   }
}
#endif
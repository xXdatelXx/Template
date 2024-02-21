using System.Collections.Generic;

namespace Template.Runtime.Core
{
   public static class EntityExtension
   {
      public static bool NotExist<TModule>(this IReadOnlyEntity entity) =>
         !entity.Exist<TModule>();

      public static bool Exist<TModule>(this IReadOnlyEntity entity, out TModule module)
      {
         if (entity.Exist<TModule>())
         {
            module = entity.Get<TModule>();
            return true;
         }

         module = default;
         return false;
      }

      public static void SaveAdd<TModule>(this IEntity entity, TModule module)
      {
         if (!entity.Exist<TModule>())
            entity.Add(module);
      }

      public static void SortFactories(this IEntity entity, List<IEntityModuleFactory> factories)
      {
         factories.Sort((factoryA, factoryB) =>
         {
            if (factoryA.Construct(entity) != factoryB.Construct(entity))
               return factoryA.Construct(entity) ? 1 : -1;

            return 0;
         });
      }
   }
}
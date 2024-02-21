using System;
using System.Collections.Generic;
using System.Linq;

namespace Template.Engine.Extensions
{
   public static class CollectionExtensions
   {
      public static bool Has<T>(this IEnumerable<T> collection, T item) =>
         collection.Any(i => i.Equals(item));

      public static bool Empty<T>(this IEnumerable<T> collection) =>
         !collection.Any();

      public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
      {
         foreach (T i in collection)
            action.Invoke(i);
      }
   }
}
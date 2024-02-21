namespace Template.Runtime.Core
{
   /// <summary>
   /// Mutable root object for prefabs
   /// </summary>
   public interface IEntity : IReadOnlyEntity
   {
      void Add<TModule>(in TModule module);
   }
}
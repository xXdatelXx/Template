namespace Template.Runtime.Core
{
   /// <summary>
   /// Not mutable root object for prefabs
   /// </summary>
   public interface IReadOnlyEntity
   {
      TModule Get<TModule>();
      bool Exist<TModule>();
   }
}
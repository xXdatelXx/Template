namespace Template.Runtime.Core
{
   /// <summary>
   /// Service locator Entity module factory
   /// </summary>
   public interface IEntityModuleFactory
   {
      bool Construct(IEntity forEntity);
   }
}
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Template.Engine.Extensions;
using UnityEngine;

namespace Template.Runtime.Core
{
   /// <summary>
   /// Standard Entity in Unity scene
   /// </summary>
   [DisallowMultipleComponent]
   public sealed partial class WorldEntity : SerializedMonoBehaviour, IEntity
   {
      [SerializeField] private bool _autoConstruct;
      [SerializeField] private List<IEntityModuleFactory> _factories;
      private readonly Dictionary<Type, object> _modulesMap = new();

      private void Awake()
      {
         if (_autoConstruct)
            Construct(default);
      }

      public void Construct(IEnumerable<IEntityModuleFactory> factories)
      {
         _factories.AddRange(factories);
         _factories.Foreach(f => f.Construct(forEntity: this));
      }

      public bool Exist<TModule>() => _modulesMap.ContainsKey(typeof(TModule));

      public void Add<TModule>(in TModule module)
      {
         if (module is null)
            throw new ArgumentNullException(nameof(module));
         if (Exist<TModule>())
            throw new InvalidOperationException($"{_modulesMap} already have {typeof(TModule)} module");

         _modulesMap.Add(typeof(TModule), module);
      }

      public TModule Get<TModule>()
      {
         // Extension method
         if (this.Exist(out TModule module))
            return module;

         throw new InvalidOperationException($"{_modulesMap} don't have {typeof(TModule)} module");
      }
   }
}
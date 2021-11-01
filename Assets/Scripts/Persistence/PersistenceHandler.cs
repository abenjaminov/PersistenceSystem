using System;
using System.Collections.Generic;
using Persistence.Models;
using UnityEngine;

namespace Persistence 
{
    public class PersistenceHandler : MonoBehaviour
    {
        [SerializeField] private PersistenceChannel _persistenceChannel;
        [SerializeField] private List<ModuleToAccessorTuple> _tuples;

        private void Start()
        {
            LoadModules();
        }

        private void OnApplicationQuit()
        {
            SaveModules();
        }

        private void LoadModules()
        {
            foreach (var tuple in _tuples)
            {
                var accessor = tuple.Accessor;

                accessor.LoadModule();
                tuple.Module.OnModuleLoaded(accessor);
            }
           
            _persistenceChannel.OnPersistenceLoaded();
        }

        private void SaveModules()
        {
            foreach (var tuple in _tuples)
            {
                var accessor = tuple.Accessor;

                tuple.Module.OnModuleSaving(accessor);
                accessor.SaveModule();
            }
        }
    }
}

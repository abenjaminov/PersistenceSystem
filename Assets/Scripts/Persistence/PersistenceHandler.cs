using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PersistenceHandler : MonoBehaviour
{
    [SerializeField] private PersistenceChannel _persistenceChannel;
    [SerializeField] private List<ModuleToAccessorTuple> _modules;

    private void Start()
    {
        LoadModules();
        
        _persistenceChannel.OnPersistenceLoaded();
    }

    private void OnApplicationQuit()
    {
        SaveModules();
    }

    private void LoadModules()
    {
        foreach (var module in _modules)
        {
            var accessor = module.Accessor;

            accessor.LoadModule();
            module.Module.OnModuleLoaded(accessor);
        }
    }
        
    private void SaveModules()
    {
        foreach (var module in _modules)
        {
            var accessor = module.Accessor;

            module.Module.OnModuleSaving(accessor);
            accessor.SaveModule();
        }
    }
}
using Persistence;
using UnityEngine;

namespace Persistence.Modules
{
    public abstract class PersistenceModule : MonoBehaviour
    {
        public string Name;
        public ModuleType ModuleType;
        public abstract void OnModuleLoaded(ModuleAccessor accessor);
        public abstract void OnModuleSaving(ModuleAccessor accessor);
    }
}

using UnityEngine;

namespace Persistence
{
    public abstract class ModuleAccessor : ScriptableObject
    {
        public abstract T GetData<T>(string key);
        public abstract void PersistData<T>(string key, T data);
        
        public abstract void LoadModule();
        public abstract void SaveModule();
    }
}

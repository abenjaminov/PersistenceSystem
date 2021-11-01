using System;
using Persistence;

namespace DefaultNamespace
{
    [Serializable]
    public class ModuleToAccessorTuple
    {
        public ModuleAccessor Accessor;
        public PersistenceModule Module;
    }
}

using System;
using Persistence;

namespace DefaultNamespace
{
    [Serializable]
    public class ModuleToAccessorTuple
    {
        public BaseModuleAccessor Accessor;
        public PersistenceModule Module;
    }
}
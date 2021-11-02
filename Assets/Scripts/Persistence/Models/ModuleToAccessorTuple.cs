using System;
using Persistence;
using Persistence.ModuleAccessors;
using Persistence.Modules;

namespace Persistence.Models
{
    [Serializable]
    public class ModuleToAccessorTuple
    {
        public ModuleAccessor Accessor;
        public PersistenceModule Module;
    }
}

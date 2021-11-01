using System;
using Persistence;

namespace Persistence.Models
{
    [Serializable]
    public class ModuleToAccessorTuple
    {
        public ModuleAccessor Accessor;
        public PersistenceModule Module;
    }
}

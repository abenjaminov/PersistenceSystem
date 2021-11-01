using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Persistence Channel", menuName = "Channels/Persistence")]
    public class PersistenceChannel : ScriptableObject
    {
        public UnityAction PersistenceLoadedEvent;

        public void OnPersistenceLoaded()
        {
            PersistenceLoadedEvent?.Invoke();
        }
    }
}
using System;
using DefaultNamespace;
using UnityEngine;

namespace Persistence
{
    public class AnyGameComponent : MonoBehaviour
    {
        [SerializeField] private PersistenceChannel _persistenceChannel;

        private void Awake()
        {
            _persistenceChannel.PersistenceLoadedEvent += PersistenceLoadedEvent;
        }

        private void PersistenceLoadedEvent()
        {
            Debug.Log("I see the persistence has finished loading and i can start working now");
        }
    }
}
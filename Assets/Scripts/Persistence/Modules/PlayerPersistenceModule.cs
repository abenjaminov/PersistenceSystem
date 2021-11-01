using DefaultNamespace;
using Persistence;
using UnityEngine;

public class PlayerPersistenceModule : PersistenceModule
{
    [SerializeField] private Player _player;
        
    public override void OnModuleLoaded(ModuleAccessor accessor)
    {
        _player.Level = accessor.GetData<int>("PlayerLevel");
        _player.Hp = accessor.GetData<int>("PlayerHp");
        _player.transform.position = 
            accessor.GetData<SerializableVector3>("PlayerPosition").ToVector3();
    }

    public override void OnModuleSaving(ModuleAccessor accessor)
    {
        accessor.PersistData<int>("PlayerLevel", _player.Level);
        accessor.PersistData<int>("PlayerHp", _player.Hp);
        accessor.PersistData<SerializableVector3>("PlayerPosition", 
            SerializableVector3.GetSerializable(_player.transform.position));
    }
}

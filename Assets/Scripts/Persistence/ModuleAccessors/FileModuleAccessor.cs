using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

namespace Persistence.ModuleAccessors
{
    [CreateAssetMenu(fileName = "Binary File Accessor", menuName = "ModuleAccessors/Binary Files")]
    public class FileModuleAccessor : ModuleAccessor
    {
        private const string FilePrefix = ".dat";
        public string FileName;

        private Dictionary<string, object> _allData;

        public override T GetData<T>(string key)
        {
            if (_allData.TryGetValue(key, out var value))
            {
                return (T) value;
            }

            return default(T);
        }

        public override void PersistData<T>(string key, T data)
        {
            _allData ??= new Dictionary<string, object>();

            _allData[key] = data;
        }

        public override void LoadModule()
        {
            _allData = new Dictionary<string, object>();

            if (!DirectoryExists()) return;
            
            using var stream = File.Open(GetPath(), FileMode.OpenOrCreate);

            if (stream.Length == 0) return;
            
            BinaryFormatter bin = new BinaryFormatter();
            try
            {
                _allData = (Dictionary<string, object>)bin.Deserialize(stream);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        public override async void SaveModule()
        {
            _allData ??= new Dictionary<string, object>();

            if (!DirectoryExists())
            {
                Directory.CreateDirectory(GetDirectoryPath());
            }

            await Task.Delay(TimeSpan.FromSeconds(1));
            
            using var stream = File.Open(GetPath(), FileMode.OpenOrCreate);
            
            var bin = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            bin.Serialize(stream, _allData);
        }
        
        private string GetDirectoryPath()
        {
            return Application.persistentDataPath;
        }
        
        private bool DirectoryExists()
        {
            return Directory.Exists(GetDirectoryPath());
        }
        
        private string GetPath()
        {
            return GetDirectoryPath() + "\\" + FileName + FilePrefix;
        }
    }
}

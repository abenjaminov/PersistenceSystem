using System;
using UnityEngine;

namespace Persistence.Models
{
    [Serializable]
    public class SerializableVector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3 ToVector3()
        {
            return new Vector3(x,y,z);
        }

        public static SerializableVector3 GetSerializable(Vector3 vector)
        {
            return new SerializableVector3()
            {
                x = vector.x,
                y = vector.y,
                z = vector.z
            };
        }
    }
}

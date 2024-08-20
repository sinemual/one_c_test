using System;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine;

namespace _Project.Scripts.Data
{
    [Serializable]
    public class VfxByType : SerializableDictionaryBase<VfxType, ParticleSystem>
    {
    }
}
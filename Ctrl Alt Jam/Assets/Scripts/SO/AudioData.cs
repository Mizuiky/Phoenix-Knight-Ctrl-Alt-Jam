using System.Collections.Generic;
using UnityEngine;

namespace JAM.Audio
{
    [CreateAssetMenu(menuName = "Data/Audio")]
    public class AudioData : ScriptableObject
    {
        public List<AudioConfig> audioConfigList;
    }
}
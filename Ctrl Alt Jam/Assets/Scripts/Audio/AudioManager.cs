using System.Collections.Generic;
using UnityEngine;

namespace JAM.Audio
{
    public enum SoundType
    {
        Music,
        SFX
    }

    public class AudioManager
    {
        [SerializeField] private string musicName;
        [SerializeField] private SoundType musicType;

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;

        [SerializeField] private AudioData _musicData;
        [SerializeField] private AudioData _sfxData;

        [SerializeField] private List<AudioConfig> _musicConfigs;
        [SerializeField] private List<AudioConfig> _sfxConfigs;

        private AudioConfig _audioConfig;
        private AudioSource _currentAudioSource;

        public void Start()
        {
            Init();
        }

        public void Init()
        {
            _musicConfigs = new List<AudioConfig>();
            _musicConfigs = _musicData.audioConfigList;

            _sfxConfigs = new List<AudioConfig>();
            _sfxConfigs = _sfxData.audioConfigList;        
        }

        public void Reset()
        {
            _musicSource.Stop();
            _sfxSource.Stop();       
        }

        public void PlaySound(string name, SoundType type)
        {
            if(type == SoundType.Music)
                _audioConfig = GetAudioConfig(name, _musicConfigs, type);
            else
                _audioConfig = GetAudioConfig(name, _sfxConfigs, type);

            _currentAudioSource = type == SoundType.Music ? _musicSource : _sfxSource;

            SetSound();

            _currentAudioSource.Play();
        }

        private AudioConfig GetAudioConfig(string name, List<AudioConfig> audioList, SoundType type)
        {
            foreach (var audio in audioList)
            {
                if (audio.name == name)
                    return audio;
            }

            return null;
        }

        private void SetSound()
        {
            if (_audioConfig.clip == null) return;

            _currentAudioSource.clip = _audioConfig.clip;
            _currentAudioSource.volume = _audioConfig.volume;
            _currentAudioSource.pitch = _audioConfig.pitch;
            _currentAudioSource.loop = _audioConfig.isLoopSound;

            if(_audioConfig.has3DSound)
            {
                _currentAudioSource.minDistance = _audioConfig.minDistance;
                _currentAudioSource.maxDistance = _audioConfig.maxDistance;
            }         
        }
    }

    [System.Serializable]
    public class AudioConfig
    {
        public AudioClip clip;
        public string name;
        [Range(0.0f, 1)]
        public float volume;
        [Range(.1f, 3f)]
        public float pitch;
        public bool isLoopSound;
        public bool has3DSound;
        public float minDistance;
        public float maxDistance;
    }
}
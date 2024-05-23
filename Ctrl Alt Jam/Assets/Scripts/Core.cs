using JAM.Audio;
using JAM.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Core : Singleton<Core>
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private AudioHandler _audioHandler;

    private AudioSource _musicSource;
    private AudioSource _SFXSource;

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        SceneManager.sceneLoaded += OnLoadSceneAsync;
        _uiManager?.Init();
    }


    public void StartRoutine(IEnumerator coroutine)
    {
        Instance.StartCoroutine(coroutine);
    }

    public void StopRoutine(IEnumerator coroutine)
    {
        Instance.StopCoroutine(coroutine);
    }

    public void OnLoadSceneAsync(UnityEngine.SceneManagement.Scene scene, LoadSceneMode loadSceneMode)
    {
        UpdateAudioSource();
    }

    private void UpdateAudioSource()
    {
        Debug.Log("loaded");
        AudioSource[] audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.InstanceID);

        if(audioSources.Length > 0)
        {
            for(int i = 0; i < audioSources.Length; i++)
            {
                if (audioSources[i].gameObject.CompareTag("MusicSource"))
                    _musicSource = audioSources[i];
                else
                    _SFXSource = audioSources[i];
            }
        }

        _audioHandler.SetAudioSource(_musicSource, _SFXSource);
    }
}

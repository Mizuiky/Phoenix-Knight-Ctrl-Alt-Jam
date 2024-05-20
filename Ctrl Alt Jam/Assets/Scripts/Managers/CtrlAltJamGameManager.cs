using JAM.UI;
using UnityEngine;
using JAM.Dialog;
using JAM.Audio;
using UnityEngine.SceneManagement;

public class CtrlAltJamGameManager : Singleton<CtrlAltJamGameManager>
{
    public enum SceneType
    {
        AgathaDream,
        AgathaHome,
        DungeonFuria,
        BossFuria
    }

    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private TextAsset[] _localizationFiles;
    [SerializeField] private TextAsset _dialogFile;

    private InitializeDialogs _initializeDialogs;
    private LocalizationManager _localizationManager;
    private AudioManager _audioManager;

    public DialogManager DialogController { get { return _dialogManager; } }
    public InitializeDialogs InitializeDialogs { get { return _initializeDialogs; } }
    public LocalizationManager LocalizationManager { get { return _localizationManager; } }
    public UIManager UIController { get { return _uiManager; } }
    public AudioManager AudioManager { get { return _audioManager; } }

    public void Start()
    {
        Init();
        SceneManager.sceneLoaded += OnLoadScene;
    }

    private void Init()
    {
        _initializeDialogs = new InitializeDialogs();
        _initializeDialogs.Load(_dialogFile);

        _localizationManager = new LocalizationManager();
        _localizationManager?.Init(_localizationFiles);
        _uiManager?.Init();
        _dialogManager?.Init();     
    }

    public void OnLoadScene(UnityEngine.SceneManagement.Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("loaded");
        string name = scene.name.ToString();
        AudioManager.PlaySound(name, SoundType.Music);     
    }
}

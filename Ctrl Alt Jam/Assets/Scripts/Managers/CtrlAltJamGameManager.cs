using JAM.Pools;
using JAM.UI;
using UnityEngine;
using JAM.Dialog;
using JAM.Audio;

public class CtrlAltJamGameManager : Singleton<CtrlAltJamGameManager>
{
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private TextAsset[] _localizationFiles;
    [SerializeField] private TextAsset _dialogFile;

    [SerializeField] private PoolBase _projectilPool;
    [SerializeField] private PoolBase _mobPool;
    [SerializeField] private PoolBase _bossProjectilPool;

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
    }

    private void Init()
    {
        _initializeDialogs = new InitializeDialogs();
        _initializeDialogs.Load(_dialogFile);

        _localizationManager?.Init(_localizationFiles);
        _uiManager?.Init();
        _dialogManager?.Init();     
    }

    public void InitPools()
    {
        _projectilPool.Init();
        _bossProjectilPool.Init();
    }
}

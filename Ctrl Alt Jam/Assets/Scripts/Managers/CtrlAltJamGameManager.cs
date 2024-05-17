using JAM.Pools;
using JAM.UI;
using UnityEngine;

public class CtrlAltJamGameManager : Singleton<CtrlAltJamGameManager>
{
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private LocalizationManager _localizationManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private TextAsset _dialogFile;

    [SerializeField] private PoolBase _ProjectilPool;
    [SerializeField] private PoolBase _mobPool;

    private InitializeDialogs _initializeDialogs;

    public DialogManager DialogController { get { return _dialogManager; } }
    public InitializeDialogs InitializeDialogs { get { return _initializeDialogs; } }
    public LocalizationManager LocalizationManager { get { return _localizationManager; } }
    public UIManager UIController { get { return _uiManager; } }
    public PoolBase ProjectilPool { get { return _ProjectilPool; } }

    public void Start()
    {
        Init();
    }

    private void Init()
    {
        _initializeDialogs = new InitializeDialogs();
        _initializeDialogs.Load(_dialogFile);

        _localizationManager?.Init();

        _uiManager?.Init();

        _dialogManager?.Init();

        _ProjectilPool.Init();
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class CtrlAltJamGameManager : Singleton<CtrlAltJamGameManager>
{
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private LocalizationManager _localizationManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private TextAsset _dialogFile;

    private InitializeDialogs _initializeDialogs;

    public DialogManager DialogController { get { return _dialogManager; } }
    public InitializeDialogs InitializeDialogs { get { return _initializeDialogs; } }
    public LocalizationManager LocalizationManager { get { return _localizationManager; } }
    public UIManager UIController { get { return _uiManager; } }

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
    }
}

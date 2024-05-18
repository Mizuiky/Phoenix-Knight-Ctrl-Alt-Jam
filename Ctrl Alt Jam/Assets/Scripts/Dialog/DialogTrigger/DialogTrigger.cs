using UnityEngine;

namespace JAM.Dialog
{
    public class DialogTrigger : MonoBehaviour, IDialogTrigger
    {
        [SerializeField] private int _dialogRoot;

        private bool hasDialogFinished = true;
        public bool HasDialogFinished {  get { return hasDialogFinished; } }

        public void Start()
        {
            CtrlAltJamGameManager.Instance.DialogController.onEndDialog += OnEndDialog;
        }

        public virtual void OnStartDialog()
        {
            Debug.Log("OnStartDialog");

            if (_dialogRoot != -1)
            {
                Debug.Log("Dialog != -1");

                if (hasDialogFinished)
                {
                    Debug.Log("Started dialog");
                    hasDialogFinished = false;
                    CtrlAltJamGameManager.Instance.DialogController.StartDialog(_dialogRoot);                 
                }
            }
        }

        public void OnEndDialog()
        {
            hasDialogFinished = true;
        }
    }
}

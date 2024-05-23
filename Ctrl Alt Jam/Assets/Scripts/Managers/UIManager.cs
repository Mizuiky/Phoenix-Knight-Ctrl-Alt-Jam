using System.Collections.Generic;
using UnityEngine;
using JAM.Dialog;

namespace JAM.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private DialogWritter _dialogWritter;
        [SerializeField] private DialogBox _dialogBox;
        [SerializeField] private HUD _hud;

        public void Start()
        {
            DontDestroyOnLoad(this);
        }

        public void Init()
        {
            _dialogWritter.startDialogEvent.AddListener(OpenDialogBox);
            _dialogWritter.endDialogEvent.AddListener(CloseDialogBox);
            _dialogWritter.updateOptionsEvent.AddListener(SetDialogOptions);
            _dialogWritter.enableNextButtonEvent.AddListener(HideOptions);
            _dialogWritter.changePortraitEvent.AddListener(UpdatePortrait);

            DialogOption.onChooseOption += SelectOption;

            _dialogBox.Init();
        }

        public void Reset()
        {
            _dialogBox.ResetFields();
            _dialogBox.SetBoxVisibility(false);
            _dialogBox.EnableOptionsContainer(false);
            //_hud.Reset();
        }

        #region DialogBox

        private void OpenDialogBox()
        {
            _dialogBox.SetBoxVisibility(true);
            _dialogBox.EnableOptionsContainer(true);
        }

        private void CloseDialogBox()
        {
            _dialogBox.SetBoxVisibility(false);
        }

        private void SetDialogOptions(List<Option> options)
        {
            _dialogBox.SetOptions(options);
        }

        private void HideOptions()
        {
            _dialogBox.HideDialogOptions();
        }

        private void UpdatePortrait(Sprite newPortrait)
        {
            _dialogBox.ChangePortrait(newPortrait);
        }

        private void SelectOption(int option)
        {
            Debug.Log($"next dialog index: {option}");
            _dialogWritter.ChangeToNextDialog(option);
        }

        public void OnContinueDialog()
        {
            _dialogWritter.OnContinueDialog();
        }

        #endregion

        private void OnDisable()
        {
            _dialogWritter.startDialogEvent.RemoveListener(OpenDialogBox);
            _dialogWritter.endDialogEvent.RemoveListener(CloseDialogBox);
            _dialogWritter.updateOptionsEvent.RemoveListener(SetDialogOptions);
            _dialogWritter.enableNextButtonEvent.RemoveListener(HideOptions);
            _dialogWritter.changePortraitEvent.RemoveListener(UpdatePortrait);

            DialogOption.onChooseOption -= SelectOption;
        }
    }
}
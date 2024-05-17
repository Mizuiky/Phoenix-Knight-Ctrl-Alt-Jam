using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace JAM.UI
{
    public class SliderUpdater : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _fillDuration;
        [SerializeField] private float _resetDuration;

        private Ease resetFill = Ease.Linear;
        public Ease normalFill = Ease.OutBack;
     
        private float _maxValue;
        private Tween _currentTween;

        public void Init(float maxValue)
        {
            _maxValue = maxValue;
            Reset();
        }

        public void Reset()
        {
            _image.DOFillAmount(_maxValue, _resetDuration).SetEase(resetFill);
        }

        public void UpdateSlider(float currentValue)
        {
            if (_currentTween != null) _currentTween.Kill();

            _image.DOFillAmount(currentValue / _maxValue, _fillDuration).SetEase(normalFill);
        }
    }
}

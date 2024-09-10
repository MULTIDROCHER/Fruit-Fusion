using DG.Tweening;
using TMPro;
using UnityEngine.UI;

namespace FoodFusion
{
    public class BlenderStatusDisplay
    {
        private Image _progress;
        private TMP_Text _count;
        private string _readyText;
        private int _seconds = 60;

        public BlenderStatusDisplay(Image progress, TMP_Text count)
        {
            _progress = progress;
            _count = count;
            _readyText = _count.text;
        }

        public void UpdateCount(float timer)
        => _count.text = $"{(int)timer / _seconds} : {(int)timer % _seconds}";

        public void OnEnable() => _count.text = _readyText;

        public Tween Activate(float duration)
        {
            _count.gameObject.SetActive(false);

            return _progress.DOFillAmount(1, duration)
            .OnComplete(() => Reset());
        }

        public void Reset()
        {
            _progress.fillAmount = 0;
            _count.gameObject.SetActive(true);
        }
    }
}

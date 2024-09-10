using MoreMountains.Feedbacks;
using TMPro;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private ScoreCounter _counter;
        private MMFeedbackFloatingText _floatingText;

        [Inject]
        private void Construct(ScoreCounter counter, FeedbacksContainer feedbacks)
        {
            _counter = counter;
            _floatingText = feedbacks.FloatingText.Feedbacks[0] as MMFeedbackFloatingText;
        }

        private void Awake() => UpdateDisplay();

        private void Start() => _counter.ScoreChanged += ShowChanges;

        private void OnDestroy() => _counter.ScoreChanged -= ShowChanges;

        private void ShowChanges(int amount)
        {
            UpdateDisplay();

            if (_floatingText != null)
                ShowFloatingText(amount);
        }

        private void ShowFloatingText(int amount)
        {
            _floatingText.Value = amount.ToString();
            _floatingText.Play(_floatingText.transform.position);
        }

        private void UpdateDisplay() => _text.text = _counter.Score.ToString();
    }
}
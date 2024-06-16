using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private MMFeedbacks _feedbacks;

        private ScoreAdder _adder;
        private MMFeedbackFloatingText _floatingText;

        [Inject]
        private void Construct(ScoreAdder adder)
        {
            _adder = adder;
            _adder.ScoreChanged += OnScoreChanged;

            _floatingText =GetFeedback<MMFeedbackFloatingText>();
        }

        private void OnDestroy()
        {
            _adder.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int amount)
        {
            _count.text = _adder.Score.ToString();
            _floatingText.Value = amount.ToString();
            _feedbacks.Feedbacks[1]?.Play(Vector3.zero);
        }

        public T GetFeedback<T>() where T : MMFeedbackFloatingText
        {
            foreach (var feedback in _feedbacks.Feedbacks)
            {
                if (feedback is T typedFeedback)
                {
                    return typedFeedback;
                }
            }

            Debug.Log("Feedback not found");
            return null;
        }
    }
}

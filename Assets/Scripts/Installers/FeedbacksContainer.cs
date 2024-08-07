using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class FeedbacksContainer : MonoBehaviour
    {
        [field: SerializeField] public MMFeedbacks FloatingText;
        [field: SerializeField] public MMFeedbacks CameraShaker;
        [field: SerializeField] public MMFeedbacks Particles;
    }
}
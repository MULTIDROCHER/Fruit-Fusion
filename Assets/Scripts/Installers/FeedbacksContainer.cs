using MoreMountains.Feedbacks;
using UnityEngine;

namespace FoodFusion
{
    public class FeedbacksContainer : MonoBehaviour
    {
        [field: SerializeField] public MMFeedbacks FloatingText;
        [field: SerializeField] public MMFeedbacks CameraShaker;
        [field: SerializeField] public MMFeedbacks Particles;
    }
}
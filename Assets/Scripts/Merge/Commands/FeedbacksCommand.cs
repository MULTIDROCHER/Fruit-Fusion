using System.ComponentModel;
using MoreMountains.Feedbacks;

namespace FoodFusion
{
    public class FeedbacksCommand : MergeCommand
    {
        private MMFeedbacks[] _feedbacks;
        int _amount;

        public FeedbacksCommand(MergeInvoker invoker, FeedbacksContainer feedbacks)
        : base(invoker)
        {
            _feedbacks = new MMFeedbacks[]
            {
                feedbacks.CameraShaker,
                feedbacks.Particles
            };
        }

        protected override void Execute((FoodObject, FoodObject) mergePair)
        {
            foreach (var feedback in _feedbacks)
                feedback.PlayFeedbacks(mergePair.Item1.transform.position);
        }
    }
}

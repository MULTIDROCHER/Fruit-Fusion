using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class FeedbacksCommand : MatchCommand
    {
        private readonly MMFeedbacks _feedbacks;

        public FeedbacksCommand(MatchInvoker invoker, MMFeedbacks feedbacks)
        : base(invoker)
        {
            _feedbacks = feedbacks;
        }

        public override void Execute()
        {
            _feedbacks.Feedbacks[0].Play(Vector3.zero);
        }
    }
}
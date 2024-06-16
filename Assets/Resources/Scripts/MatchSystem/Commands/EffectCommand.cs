using System.Linq;
using MoreMountains.Feedbacks;
using UnityEngine;

namespace FoodFusion
{
    public class EffectCommand : MatchCommand
    {
        MMFeedbackParticles _particles;

        public EffectCommand(MatchInvoker invoker, MMFeedbacks feedbacks)
        : base(invoker)
        {
            _particles = feedbacks.Feedbacks.FirstOrDefault(x => x is MMFeedbackParticles) as MMFeedbackParticles;
        }

        public override void Execute()
        {
            /* _effect.transform.position = Match.Item1.transform.position;
            _effect.Play(); */
            _particles.Play(Match.Item1.transform.position);
        }
    }
}
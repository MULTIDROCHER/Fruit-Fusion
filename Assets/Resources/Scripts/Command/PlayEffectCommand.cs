using UnityEngine;

namespace FoodFusion
{
    public class PlayEffectCommand
    {
        private readonly ParticleSystem _effect;

        public PlayEffectCommand(ParticleSystem effect)
        {
            _effect = effect;
        }

        public void Execute(Vector3 position)
        {
            _effect.transform.position = position;
            _effect.Play();
        }
    }
}
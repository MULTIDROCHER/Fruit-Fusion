using DG.Tweening;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class BlenderCap : MonoBehaviour
    {
        private readonly float _duration = .3f;

        [SerializeField] private float _openedPosY;
        [SerializeField] private float _closedPosY;

        public Tween Open()
        {
            return transform.DOMoveY(_openedPosY, _duration);
        }

        public Tween Close()
        {
            return transform.DOMoveY(_closedPosY, _duration);
        }
    }
}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FoodFusion
{
    public class Blender : MonoBehaviour
    {
        [SerializeField] private BuoyancyEffector2D _water;
        [SerializeField] private Button _button;

        private float _duration = .3f;
        private float _magnitude = 500;

        public event Action Activated;
        public event Action Deactivated;

        //private float _timer;
        //private float _delay = 300;

        private void Start()
        {
            _button.onClick.AddListener(BlenderOn);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(BlenderOn);
        }

        private void BlenderOn()
        {
            Activated?.Invoke();
            StartCoroutine(Blend());
        }

        private void BlenderOff()
        {
            _water.flowMagnitude = 0;
            Deactivated?.Invoke();
        }

        private IEnumerator Blend()
        {
            var timer = _duration;

            _water.flowMagnitude = _magnitude;

            while (timer > 0)
            {
                timer -= Time.deltaTime;

                yield return new WaitForSeconds(.4f);
                _water.flowMagnitude = -_water.flowMagnitude;
            }

            BlenderOff();
        }
    }
}

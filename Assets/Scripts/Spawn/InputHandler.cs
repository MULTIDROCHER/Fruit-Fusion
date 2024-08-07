using System;
using UnityEngine;

namespace FoodFusion
{
    public class InputHandler : MonoBehaviour
    {
        private Camera _camera;

        public event Action OnMouseDown;
        public event Action OnMouseUp;

        public Vector3 MousePosition => _camera.ScreenToWorldPoint(Input.mousePosition);

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                OnMouseDown?.Invoke();

            if (Input.GetMouseButtonUp(0))
                OnMouseUp?.Invoke();
        }
    }
}

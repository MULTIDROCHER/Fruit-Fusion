using UnityEngine;

namespace FoodFusion
{
    public class InputHandler
    {
        private readonly Camera _camera;
        public Vector3 MousePosition { get; private set; }

        public InputHandler()
        {
            _camera = Camera.main;
        }

        public void Update()
        {
            MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
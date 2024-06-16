using UnityEngine;

namespace FoodFusion
{
    public class InputHandler
    {
        private readonly Camera _camera;

        public InputHandler() => _camera = Camera.main;

        public Vector3 MousePosition => _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
using System;
using UnityEngine;

namespace FoodFusion
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FoodPhysics : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private float _bounceForce = 2.5f;

        public event Action<FoodObject> OnCollisionEnter;
        public event Action<GameObject> OnCollisionExit;

        public bool IsActive => _rigidbody.bodyType == RigidbodyType2D.Dynamic && gameObject.activeSelf;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Initialize()
        {
            _rigidbody.bodyType = RigidbodyType2D.Kinematic;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (IsActive == false)
                return;

            if (other.gameObject.TryGetComponent(out FoodObject food))
                OnCollisionEnter?.Invoke(food);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            OnCollisionExit?.Invoke(other.gameObject);
        }

        public void Drop(Vector3 force)
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        public void Bounce()
        {
            _rigidbody.AddForce(Vector3.up * _bounceForce, ForceMode2D.Impulse);
        }
    }
}
using UnityEngine;

namespace FoodFusion
{
    public class FoodPhysics
    {
        private readonly float _shootForce = 5;
        private readonly float _bounceForce = 2;
        private readonly Rigidbody2D _rigidbody;

        private Vector3 Direction => _rigidbody.velocity.normalized;

        public bool IsFree => _rigidbody.bodyType == RigidbodyType2D.Dynamic;

        public FoodPhysics(Rigidbody2D rigidbody) => _rigidbody = rigidbody;

        public void Shoot(Vector3 direction)
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            AddForce(_shootForce * direction);
        }

        public void Bounce()
        => AddForce(_bounceForce * Direction);

        private void AddForce(Vector2 force)
        => _rigidbody.AddForce(force, ForceMode2D.Impulse);
    }
}
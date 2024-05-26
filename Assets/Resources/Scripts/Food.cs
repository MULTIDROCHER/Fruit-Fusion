using System;
using UnityEngine;

namespace FoodFusion
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Food : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _renderer;

        public event Action<Food, Food> Matched;

        public FoodData Data { get; private set; }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Food other))
                if (other.Data.Level == Data.Level)
                    Matched?.Invoke(this, other);
        }

        public void Initialize(FoodData data)
        {
            Data = data;

            if (Data != null)
            {
                var scaleFactor = Data.Level / 5;
                _renderer.sprite = Data.Sprite;
                transform.localScale = new(1 + scaleFactor, 1 + scaleFactor);
            }
        }

        public void SetAcceleration(Vector2 force)
        {
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
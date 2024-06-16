using System;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Food : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private Rigidbody2D _rigidbody;

        public event Action<Food, Food> Matched;

        public FoodPhysics Physics { get; private set; }
        public FoodData Data { get; private set; }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();

            Physics = new(_rigidbody);
        }

        private void OnEnable()
        {
            _rigidbody.bodyType = RigidbodyType2D.Static;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Food other))
            {
                if (other.Data.Level == Data.Level)
                    Matched?.Invoke(this, other);
            }
        }

        public void Initialize(FoodData data)
        {
            Data = data;
            gameObject.name = Data.Level.ToString();

            if (Data != null)
                _renderer.sprite = Data.Sprite;
        }
    }
}
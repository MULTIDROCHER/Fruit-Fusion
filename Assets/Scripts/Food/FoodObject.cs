using System;
using UnityEngine;

namespace FoodFusion
{
    [RequireComponent(typeof(FoodPhysics))]
    public class FoodObject : MonoBehaviour
    {
        private FoodPhysics _physics;
        private SpriteRenderer _renderer;

        public static event Action<FoodObject> OnCollision;

        public FoodData Data { get; private set; }
        public FoodObject PotentialPair { get; private set; }
        public bool CanBeMerged => _physics.IsActive;

        private void Awake()
        {
            _physics = GetComponent<FoodPhysics>();
            _renderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Start()
        {
            _physics.OnCollisionEnter += SetPair;
            _physics.OnCollisionExit += ClearPair;
        }

        private void OnDestroy()
        {
            _physics.OnCollisionEnter -= SetPair;
            _physics.OnCollisionExit -= ClearPair;
        }

        public void Initialize(FoodData data)
        {
            Data = data;
            _renderer.sprite = data.Sprite;
            gameObject.name = data.Level.ToString();
            _physics.Initialize();
        }

        private void SetPair(FoodObject food)
        {
            if (food.Data.Level == Data.Level)
            {
                PotentialPair = food;
                OnCollision?.Invoke(this);
            }
        }

        private void ClearPair(GameObject other)
        {
            if (PotentialPair == null)
                return;

            if (other == PotentialPair.gameObject)
                PotentialPair = null;
        }

        public void Drop(Vector3 force) => _physics.Drop(force);

        public void Bounce() => _physics.Bounce();
    }
}

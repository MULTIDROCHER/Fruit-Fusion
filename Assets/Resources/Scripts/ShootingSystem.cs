using System.Collections;
using FoodFusion;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] private ObjectPool _pool;
        [SerializeField] private float _shootForce;
        [SerializeField] private MatchInvoker _matchInvoker;

        private InputHandler _input;
        private MatchesHandler _matchesHandler;
        private MatchClient _matchClient;

        private Food _currentFood;
        private Vector3 _direction;

        [Inject]
        private void Construct(InputHandler input, ObjectsAssets assets)
        {
            _input = input;
            _matchClient = new (_matchInvoker);
            _matchesHandler = new (_matchClient, assets);
        }

        private void Awake()
        {
            SetFood();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                _input.Update();
                SetDirection();
            }

            if (Input.GetMouseButtonUp(0) && _currentFood != null)
                Shoot();
        }

        private void SetDirection()
        {
            _direction = _input.MousePosition - transform.position;
            Debug.DrawRay(transform.position, _direction, Color.red, 1f);
        }

        private void Shoot()
        {
            if (_currentFood == null)
                SetFood();
            else
            {
                _currentFood.SetAcceleration(_direction * _shootForce);
                _currentFood = null;
                StartCoroutine(SetNewFood());
            }
        }

        private void SetFood()
        {
            _currentFood = _pool.GetObject();
            _matchesHandler.OnSpawned(_currentFood);
            _currentFood.transform.position = transform.position;
        }

        private IEnumerator SetNewFood()
        {
            yield return new WaitForSeconds(.3f);

            if (_currentFood == null)
                SetFood();
        }
    }
}
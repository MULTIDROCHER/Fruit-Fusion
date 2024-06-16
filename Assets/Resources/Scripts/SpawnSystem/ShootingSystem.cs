using System.Collections;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class ShootingSystem : MonoBehaviour
    {
        private ObjectPool _pool;
        private InputHandler _input;
        private DataAssets _assets;
        private MatchInvoker _invoker;

        private Food _currentFood;
        private Vector3 _direction;

        [Inject]
        private void Construct(InputHandler input, DataAssets assets, ObjectPool pool, MatchInvoker invoker)
        {
            _input = input;
            _assets = assets;
            _pool = pool;
            _invoker = invoker;
        }

        private void Awake() => SetFood();

        private void Update()
        {
            if (Input.GetMouseButton(0))
                _direction = _input.MousePosition - transform.position;

            if (Input.GetMouseButtonUp(0) && _currentFood != null)
                Shoot();
        }

        private void Shoot()
        {
            if (_currentFood == null)
                SetFood();
            else
            {
                _currentFood.Physics.Shoot(_direction);
                _currentFood = null;
                StartCoroutine(SetNewFood());
            }
        }

        private void SetFood()
        {
            _currentFood = _pool.GetObject();
            _currentFood.transform.position = transform.position;
            _currentFood.Initialize(_assets.GetRandomData());
            _invoker.OnSpawned(_currentFood);
        }

        private IEnumerator SetNewFood()
        {
            yield return new WaitForSeconds(.3f);

            if (_currentFood == null)
                SetFood();
        }
    }
}
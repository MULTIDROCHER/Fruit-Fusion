using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FoodFusion
{
    public class NextFoodHolder : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private ObjectPool _pool;
        private FoodObject _nextFood;
        private FoodObject _currentFood;

        [Inject]
        private void Construct(ObjectPool pool) => _pool = pool;

        private void Start() => SetNext();

        public FoodObject GetObject()
        {
            if (_nextFood == null)
                SetNext();

            _currentFood = _nextFood;
            SetNext();

            return _currentFood;
        }

        private void SetNext()
        {
            _nextFood = _pool.GetObject();
            _image.sprite = _nextFood.Data.Sprite;
        }
    }
}
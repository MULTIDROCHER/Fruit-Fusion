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

        [Inject]
        private void Construct(ObjectPool pool)
        {
            _pool = pool;
        }

        private void Start() {
            SetNext();
        }

        private void SetNext()
        {
            _nextFood = _pool.GetObject();
            _image.sprite = _nextFood.Data.Sprite;
        }

        public FoodObject GetObject()
        {
            if (_nextFood == null)
                SetNext();

            var temp = _nextFood;
            SetNext();

            return temp;
        }
    }
}

using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FoodFusion
{
    [RequireComponent(typeof(Button))]
    public class BlenderButton : MonoBehaviour
    {
        [Header("----System----")]
        [SerializeField] private float _duration;
        [SerializeField] private float _delay;

        [Header("----Display----")]
        [SerializeField] private Image _progress;
        [SerializeField] private TMP_Text _count;

        private Button _button;
        private Blender _blender;
        private BlenderStatusDisplay _statusDisplay;
        private float _timer;

        [Inject]
        private void Construct(Blender blender) => _blender = blender;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(BlenderOn);
            _statusDisplay = new(_progress, _count);
        }

        private void Start()
        {
            _timer = _delay;
            _button.interactable = false;
            _statusDisplay.Reset();
        }

        private void OnDestroy() => _button.onClick.RemoveListener(BlenderOn);

        private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                _statusDisplay.UpdateCount(_timer);

                if (_timer <= 0)
                    EnableButton();
            }
        }

        private void EnableButton()
        {
            _button.interactable = true;
            _statusDisplay.OnEnable();
        }

        private void BlenderOn()
        {
            _blender.BlenderOn(_duration);
            _statusDisplay.Activate(_duration + 1)
            .OnComplete(() => BlenderOff());
        }

        private void BlenderOff()
        {
            _button.interactable = false;
            _timer = _delay;
            _statusDisplay.Reset();
            _blender.BlenderOff(_duration);
        }
    }
}

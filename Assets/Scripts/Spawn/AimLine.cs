using UnityEngine;
using YG;
using Zenject;

namespace FoodFusion
{
    [RequireComponent(typeof(LineRenderer))]
    public class AimLine : MonoBehaviour
    {
        private InputHandler _input;
        private LineRenderer _lineRenderer;

        [Inject]
        private void Construct(InputHandler input) => _input = input;

        private void Awake() => _lineRenderer = GetComponent<LineRenderer>();

        private void Start()
        {
            if (YandexGame.EnvironmentData.isMobile)
            {
                _input.OnMouseDown += EnableLine;
                _input.OnMouseUp += DisableLine;
            }
            else
            {
                EnableLine();
            }
        }

        private void Update()
        {
            if (_lineRenderer.enabled)
            {
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, _input.MousePosition);
            }
        }

        private void OnDestroy()
        {
            if (YandexGame.EnvironmentData.isMobile)
            {
                _input.OnMouseDown -= EnableLine;
                _input.OnMouseUp -= DisableLine;
            }
        }

        private void EnableLine() => _lineRenderer.enabled = true;

        private void DisableLine() => _lineRenderer.enabled = false;
    }
}
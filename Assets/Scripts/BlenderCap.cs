using DG.Tweening;
using UnityEngine;
using Zenject;

namespace FoodFusion
{
    public class BlenderCap : MonoBehaviour
    {
        private readonly float _duration = .5f;

        [SerializeField] private float _openedPosY;
        [SerializeField] private float _closedPosY;
        private Blender _blender;

        /* private Sequence _openTween;
        private Sequence _closeTween;

        private void Awake()
        {

            _openTween = DOTween.Sequence()
                .Join(transform.DOLocalMoveY(_openedPosY, _duration))
                .SetAutoKill(false);

            _closeTween = DOTween.Sequence()
                .Join(transform.DOLocalMoveY(_closedPosY, _duration))
                .SetAutoKill(false);
        } */
        [Inject]
        private void Construct(Blender blender)
        {
            _blender = blender;
        }

        private void Start()
        {
            _blender.Activated += Close;
            _blender.Deactivated += Open;
        }

        private void OnDestroy()
        {
            _blender.Activated -= Close;
            _blender.Deactivated -= Open;
        }

        private void Open()
        {
            //_openTween.Play().OnComplete(() => _openTween.Pause());

            transform.DOLocalMoveY(_openedPosY, _duration);
        }

        private void Close()
        {
            //_closeTween.Play().OnComplete(() => _closeTween.Pause());

            transform.DOLocalMoveY(_closedPosY, _duration);
        }
    }
}

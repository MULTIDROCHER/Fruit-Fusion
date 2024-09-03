using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;
using System.Linq;

namespace FoodFusion
{
    public class RadialFoodGroup : MonoBehaviour
    {
        [SerializeField] private Image _imageTemplate;
        [SerializeField] private Color _closedColor;

        private DataAssets _assets;
        private Image[] _foodGroup;
        private Color _openedColor = new Color(1, 1, 1, 1);

        [Inject]
        private void Construct(DataAssets assets)
        {
            _assets = assets;
            _assets.DataOpened += SetImageColor;
        }

        private void OnDestroy() => _assets.DataOpened -= SetImageColor;

        private void Start()
        {
            _foodGroup = new Image[_assets.Datas.Count];

            for (int i = 0; i < _foodGroup.Length; i++)
            {
                _foodGroup[i] = Instantiate(_imageTemplate, transform);
                _foodGroup[i].sprite = _assets.Datas.Keys.ElementAt(i).Sprite;
                _foodGroup[i].SetNativeSize();
                SetImageColor(i);
            }
        }

        private void SetImageColor(int index)
        {
            if (_assets.Datas.Values.ElementAt(index))
                _foodGroup[index].color = _openedColor;
            else
                _foodGroup[index].color = _closedColor;
        }
    }
}

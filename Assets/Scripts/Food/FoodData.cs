using UnityEngine;

namespace FoodFusion
{
    [CreateAssetMenu(fileName = "FoodData", menuName = "FoodData")]
    public class FoodData : ScriptableObject
    {
        [field: SerializeField] public int Level { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int BonusScore { get; private set; }
    }
}

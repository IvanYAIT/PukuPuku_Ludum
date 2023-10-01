using UnityEngine;

namespace Claustrophobia
{
    [CreateAssetMenu(fileName = "СlaustrophobiaSettings", menuName = "SO/NewСlaustrophobiaSettings")]
    public class ClaustrophobiaSettings : ScriptableObject
    {
        [SerializeField] private float maxValue;
        [SerializeField] private float valuePerItem;

        public float MaxValue => maxValue;
        public float ValuePerItem => valuePerItem;
    }
}
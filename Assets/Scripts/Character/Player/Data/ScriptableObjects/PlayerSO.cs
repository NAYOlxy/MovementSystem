using UnityEngine;

namespace GenshinImpacetMovementSystem
{
    [CreateAssetMenu(fileName ="Player",menuName ="Custom/Characters/Player")]
    public class PlayerSO : ScriptableObject
    {
        [field:SerializeField] public PlayerGroundedData GroundedData { get; private set; }
        [field: SerializeField] public PlayerAirborneData AirborneData { get; private set; }
    }
}

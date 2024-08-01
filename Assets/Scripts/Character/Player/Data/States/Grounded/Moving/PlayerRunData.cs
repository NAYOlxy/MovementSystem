using System;
using UnityEngine;

namespace GenshinImpacetMovementSystem
{
    [Serializable]
    public class PlayerRunData 
    {
        [field: SerializeField][field: Range(1f, 2f)] public float SpeedModifer { get; private set; } = 1f;
    }
}

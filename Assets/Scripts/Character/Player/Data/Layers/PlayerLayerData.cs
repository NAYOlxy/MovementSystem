using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpacetMovementSystem
{
    [Serializable]
    public class PlayerLayerData 
    {
        [field:SerializeField] public LayerMask GroundLayer {  get; private set; }

        // LayerMask实际上是一个32位的位掩码，假设我们第6层为环境层，那么对应的LayseMask 码就在第“7”位上置1，其余为0
        // 结果如下：（环境层Layer表示）
        // 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0 0
        // <<是位运算符，即向左位移
        // 1即使我们对应的层，将其想左移动对应的层数就得到了其位掩码
        public bool ContainsLayer(LayerMask layerMask,int layer)
        {
            return(1<<layer&layerMask) != 0;
        }

        public bool IsGroundLayer(int layer)
        {
            return ContainsLayer(GroundLayer,layer);
        }
    }
}

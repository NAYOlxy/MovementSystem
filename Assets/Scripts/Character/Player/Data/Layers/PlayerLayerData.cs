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

        // LayerMaskʵ������һ��32λ��λ���룬�������ǵ�6��Ϊ�����㣬��ô��Ӧ��LayseMask ����ڵڡ�7��λ����1������Ϊ0
        // ������£���������Layer��ʾ��
        // 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 0 0 0
        // <<��λ�������������λ��
        // 1��ʹ���Ƕ�Ӧ�Ĳ㣬���������ƶ���Ӧ�Ĳ����͵õ�����λ����
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

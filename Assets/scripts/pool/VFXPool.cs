using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    [CreateAssetMenu(fileName = "vfxPool", menuName = "Game/VFXPool", order = 1)]
    public class VFXPool : ScriptableObject
    {
        [SerializeField] private int _size = 5;
        [SerializeField] private GameObject _vfxPrefab;

        private List<VFXPoolItem> _poolItems;
        private Queue<VFXPoolItem> _poolQueue;

        public void Init()
        {
        }

        public void ResetPool()
        {
            
        }

        /*public VFXPoolItem GetItem()
        {

        }
        public VFXPoolItem ReturnItem()
        {

        }*/

    }
}

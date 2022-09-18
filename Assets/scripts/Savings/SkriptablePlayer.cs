using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    [CreateAssetMenu(fileName = "____PlayerData", menuName = "____Create PlayerData", order = 1)]
    public class SkriptablePlayer : First<PlayerData>
    {

        public bool canDecrenetn(int value)
        {
            return !(Model.Score <= value);
        } 

    }
}

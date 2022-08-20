using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class DestroyHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _particle;

        public void DestroyFX()
        {
            Instantiate(_particle);
        }
    }
}

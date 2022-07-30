using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class Saver : MonoBehaviour
    {
        [SerializeField] private Object[] elements; 
        // Start is called before the first frame update
        void Start()
        {
            foreach (var item in elements)
            {
                DontDestroyOnLoad(item);
            }
        }
    }
}

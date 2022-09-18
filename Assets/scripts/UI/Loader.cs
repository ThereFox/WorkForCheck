using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] protected List<ScriptableObject> _list;

        public List<ScriptableObject> ScriptableList => _list;

        private void Start()
        {
            foreach (var item in _list)
            {
                (item as IStorable)?.Load();
            }
        }
        private void OnDisable()
        {
            foreach (var item in _list)
            {
                (item as IStorable)?.Save();
            }
        }

    }
}

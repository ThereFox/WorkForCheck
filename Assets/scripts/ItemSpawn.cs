using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class ItemSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _count = 5;
        [SerializeField] private Vector3 rotation;
        [SerializeField] private float spead;
        [SerializeField] private Transform folder;
        private Transform transform;

        public void Start()
        {
            transform = GetComponent<Transform>();
            StartCoroutine(_spawnRandomElements().GetEnumerator());
        }
        private IEnumerable _spawnRandomElements()
        {
            for (int i = 0; i <= _count; i++)
            {
                var randomSpeed = Random.Range(spead - (0.1f * spead), spead + (0.1f * spead));
                var rabdomPrefab = Instantiate(_prefab, transform.position, Quaternion.identity);
                
                rabdomPrefab.name = "draggableItem";
                rabdomPrefab.transform.parent = folder;
                rabdomPrefab.GetComponent<Rigidbody>().AddForce(rotation * spead, ForceMode.Force);
                yield return new WaitForSeconds(0.75f);
            }
            yield break;
        }
    }
}

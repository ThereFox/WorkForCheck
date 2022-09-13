using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class ItemSpawn : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _prefabs;
        [SerializeField] private int _count = 5;
        [SerializeField] private Vector3 rotation;
        [SerializeField] private float spead;
        [SerializeField] private Transform folder;
        [SerializeField] private float maxDeltaPosition = 5.0f;
        private Transform transform;

        public void Start()
        {
            transform = GetComponent<Transform>();
            StartCoroutine(_spawnRandomElements());
        }
        private IEnumerator _spawnRandomElements()
        {
            for (int i = 0; i <= _count; i++)
            {
                var randomSpeed = Random.Range(spead - (0.1f * spead), spead + (0.1f * spead));
                
                var prefabIndex = Random.Range(0, _prefabs.Count);
                var _prefab = _prefabs[prefabIndex];

                var position = new Vector3(
                    Random.Range(transform.position.x - maxDeltaPosition, maxDeltaPosition + transform.position.x),
                    transform.position.y,
                    Random.Range(transform.position.z - maxDeltaPosition, maxDeltaPosition + transform.position.z));


                var rabdomPrefab = Instantiate(_prefab, position, Quaternion.identity);
                
                rabdomPrefab.name = "draggableItem";
                rabdomPrefab.transform.parent = folder;
                rabdomPrefab.GetComponent<Rigidbody>().AddForce(rotation * spead, ForceMode.Force);
                yield return new WaitForSeconds(0.75f);
            }
            yield break;
        }
    }
}

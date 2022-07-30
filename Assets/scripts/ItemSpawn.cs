using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class ItemSpawn : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();
        [SerializeField] private List<Material> _materials = new List<Material>();
        [SerializeField] private int _count = 5;
        [SerializeField] private float radius = 5;
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
                var randomPrefabIndex = Random.Range(0, _prefabs.Count);
                var randomPosition = new Vector3(Random.Range(transform.position.x - radius, transform.position.x + radius), Random.Range(0, radius), Random.Range(transform.position.z - radius, transform.position.z + radius));
                var rabdomPrefab = Instantiate(_prefabs[randomPrefabIndex], randomPosition, new Quaternion(0f,0f,0f,0f));
                var randomMaterialIndex = Random.Range(0, _materials.Count);
                rabdomPrefab.GetComponent<Renderer>().sharedMaterial = _materials[randomMaterialIndex];

                rabdomPrefab.GetComponent<Draggable>().color = (ItemColor)randomMaterialIndex;
                
                rabdomPrefab.name = "draggableItem";
                rabdomPrefab.transform.parent = folder;
                yield return new WaitForSeconds(0.1f);
            }
            yield break;
        }
    }
}

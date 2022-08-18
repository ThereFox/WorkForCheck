using UnityEngine;
using UnityEngine.EventSystems;

namespace ItemsSorting
{
    public class ClickVfxHandler : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private GameObject _circleVfxPrefab;

        public void OnPointerDown(PointerEventData eventData)
        {
            Instantiate(_circleVfxPrefab, transform.position, Quaternion.identity, null);
        }
    }
}

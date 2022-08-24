using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ItemsSorting
{
    public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        private Rigidbody _rigidbody;
        public ItemColor color;
        public bool isDragging;

        public void OnDrag(PointerEventData eventData)
        {
            if (isDragging == false)
                return;
            if(eventData.pointerCurrentRaycast.isValid == false)
            {
                _rigidbody.isKinematic = false;
                isDragging = false;
                return;
            }
            var position = eventData.pointerCurrentRaycast.worldPosition;
            var delta = position - transform.position;
            delta.y = 0;

            transform.position += delta;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isDragging = true;
            _rigidbody.isKinematic = true;
            this?.GetComponent<animation>()?.StartAnimate();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isDragging == false)
                return;
            _rigidbody.isKinematic = false;
            isDragging = false;
            _rigidbody.AddForce(Vector3.up * 150);
            this?.GetComponent<animation>()?.StopAnimate();
        }
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    }
}

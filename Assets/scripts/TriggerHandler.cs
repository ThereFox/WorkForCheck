using UnityEngine;
using UnityEngine.Events;

namespace ItemsSorting
{
    public class TriggerHandler : MonoBehaviour
    {
        [SerializeField] private ItemType color;
        private Material _material;
        private Color _default;
        private bool active;
        [Min(1)]
        private int targetCount = 1;
        private int inneringCount;

        public UnityEvent UrnFill;
        public UnityEvent<TriggerHandler, int> InnerValueChanged;


        public UnityEvent OnNeededItemUpperInnering;
        public UnityEvent OnAnoutherItemUpperInnering;

        public UnityEvent OnItemUpperOuting;

        public UnityEvent OnInneringNeededObject;

        public void SetCount(int value)
        {
            targetCount = value;

            if (inneringCount == targetCount)
            {
                _material.color = Color.gray;
                active = false;
            }
        }

        private void Start()
        {
            active = true;
            _material = GetComponent<MeshRenderer>().material;
            _default = _material.color;
        }
        private void OnTriggerStay(Collider other)
        {
            if (!active)
                return;
            Draggable draggable;
            if (other.attachedRigidbody.TryGetComponent<Draggable>(out draggable) && other != null)
            {

                if (draggable.isDragging && inneringCount < targetCount)
                {
                    if (draggable.color == color)
                    {
                        _material.color = Color.green;
                        OnNeededItemUpperInnering.Invoke();
                    }
                    else
                    {
                        OnAnoutherItemUpperInnering.Invoke();
                        _material.color = Color.yellow;
                    }
                }
                else if(draggable.color == color)
                {
                    if(inneringCount < targetCount)
                    {

                        other?.GetComponent<DestroyHandler>()?.DestroyFX();
                        other?.GetComponent<sizeAnimation>()?.StartAnimate(other.gameObject);
                        Destroy(draggable);
                        inneringCount++;
                        InnerValueChanged.Invoke(this, inneringCount);
                        OnInneringNeededObject.Invoke();
                    }
                    if (inneringCount == targetCount)
                    {
                        _material.color = Color.gray;
                        UrnFill.Invoke();
                        active = false;
                    }
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (!active)
                return;
            OnItemUpperOuting.Invoke();
            _material.color = _default;
        }
        private void OnDestroy()
        {
            UrnFill.RemoveAllListeners();
            InnerValueChanged.RemoveAllListeners();
        }
    }
}

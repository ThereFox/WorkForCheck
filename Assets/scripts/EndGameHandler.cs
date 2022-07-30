using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace ItemsSorting
{
    public class EndGameHandler : MonoBehaviour
    {
        public UnityEvent GameEnd;
        [SerializeField] private List<UrnParametrs> _urns;
        private int filledUrns;
        [SerializeField]private SceneChanger changer;

        private void Start()
        {
            filledUrns = 0;
            if (_urns == null)
            {
                Debug.LogError("urnEmpty");
            }
            foreach (var item in _urns)
            {
                item.urn.SetCount(item.TargerCount);
                item.urn.UrnFill.AddListener(OnUrnFill);
            }


        }
        private void OnUrnFill()
        {
            filledUrns++;
            if(filledUrns == _urns.Count)
            {
                Debug.Log("win");
                GameEnd.Invoke();
            }
        }
        private void OnUrnInnerValueChnged(TriggerHandler urn, int newValue)
        {
            var invocker = _urns.Where(el => el.urn == urn).First();
            invocker.Count = newValue;
        }
        private void OnDestroy()
        {
            GameEnd.RemoveAllListeners();
        }

    }
    [System.Serializable]
    public struct UrnParametrs
    {
        public TriggerHandler urn;
        public int TargerCount;
        [HideInInspector]public int Count;
    }
}

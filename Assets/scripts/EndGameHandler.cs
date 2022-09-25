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

        [SerializeField]private List<ScoreUI> scoreUIs;
        private void Start()
        {
            filledUrns = 0;
            if (_urns == null)
            {
                return;
            }
            foreach (var item in _urns)
            {
                item.urn.SetCount(item.TargerCount);
                item.urn.UrnFill.AddListener(OnUrnFill);
            }
            setMaxCounts();


        }
        private void setMaxCounts()
        {
            foreach (var item in scoreUIs)
            {
                var res = _urns.Where(element => element.Id == item.Id).First().TargerCount;
                item.setMaxCount(res);
            }
        }
        private void OnUrnFill()
        {
            filledUrns++;
            if(filledUrns == _urns.Count)
            {
                GameEnd.Invoke();
            }
        }
        public void OnUrnInnerValueChnged(TriggerHandler urn, int newValue)
        {
            var invocker = _urns.Where(el => el.urn == urn).First();
            invocker.Count = newValue;
        }
        private void OnDestroy()
        {
            GameEnd.RemoveAllListeners();
        }

       /* public IEnumerator showWin()
        {
        
        }*/

    }
    [System.Serializable]
    public struct UrnParametrs
    {
        public int Id;
        public TriggerHandler urn;
        public int TargerCount;
        [HideInInspector]public int Count;
    }
}

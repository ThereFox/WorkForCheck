using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;


namespace ItemsSorting
{
    public class Provider : MonoBehaviour
    {
        [SerializeField] protected SkriptablePlayer _skriptablePlayerData;

        public UnityEvent OnModelChange = new UnityEvent();

        public UnityEvent OnDoesnotDecrement = new UnityEvent();


        public SkriptablePlayer skriptablePlayerData => _skriptablePlayerData;

        protected void OnEnable()
        {
            _skriptablePlayerData.Model.OnValueChange.AddListener(OnModelChangeDelegate);
        }

        protected void OnDisable()
        {
            _skriptablePlayerData.Model.OnValueChange.RemoveListener(OnModelChangeDelegate);
        }

        protected void OnModelChangeDelegate()
        {
            OnModelChange.Invoke();
        }

        public void IncrementUserScore(int ScoreStep)
        {
            if(ScoreStep <= 0) return;
            _skriptablePlayerData.Model.Score += ScoreStep;
        }
        public void DecrementUserScore(int ScoreStep)
        {
            if (ScoreStep <= 0) return;
            if (_skriptablePlayerData.canDecrenetn(ScoreStep))
            {
                _skriptablePlayerData.Model.Score -= ScoreStep;
            }
            else
            {
                OnDoesnotDecrement.Invoke();
            }
        }

        public async Task<bool> Load()
        {
            _skriptablePlayerData.Model.OnValueChange.RemoveListener(OnModelChangeDelegate);
            return await skriptablePlayerData.Load();
            _skriptablePlayerData.Model.OnValueChange.AddListener(OnModelChangeDelegate);
        }
        public async Task<bool> Save()
        {
            return await skriptablePlayerData.Save();
        }
    }
}

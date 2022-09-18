using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Threading.Tasks;


namespace ItemsSorting
{
    public class Provider : MonoBehaviour
    {
        [SerializeField] protected SkriptablePlayer _skriptablePlayerData;

        public SkriptablePlayer skriptablePlayerData => _skriptablePlayerData;

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
                //Event           
            }
        }

        public async Task<bool> Load()
        {
            return await skriptablePlayerData.Load();
        }
        public async Task<bool> Save()
        {
            return await skriptablePlayerData.Save();
        }
    }
}

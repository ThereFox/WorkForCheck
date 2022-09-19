using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ItemsSorting
{
    public class ScorePresender : Provider
    {
        [SerializeField] protected TMP_Text _scoreText;

        public TMP_Text ScoreText => _scoreText;

        private void OnEnable()
        {
            base.OnEnable();
            _skriptablePlayerData.OnLoad.AddListener(UpdateScore);
        }
        private void OnDisable()
        {
            base.OnDisable();
            _skriptablePlayerData.OnLoad.RemoveListener(UpdateScore);
        }

        public void UpdateScore()
        {
            ScoreText.text = _skriptablePlayerData.Model.Score.ToString();
        }
      

    }
}

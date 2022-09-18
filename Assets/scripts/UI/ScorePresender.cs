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

        private void Start()
        {
            ScoreText.text = _skriptablePlayerData.Model.Score.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using TMPro;

namespace ItemsSorting
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text ScoreText;
        [SerializeField] private GameObject fullImage;
        [SerializeField] private int _id;
        public int Id { get { return _id; } }

        private int CurrentCount = 0;
        private int CurrentMaxCount = 0;
        private EndGameHandler handler;

        private void Start()
        {
            ScoreText.text = $"0/{CurrentMaxCount}";
        }

        public void ScoreUpdateHandler()
        {
            if (CurrentCount >= CurrentMaxCount)
            {
                ScoreText.enabled = false;
                fullImage.SetActive(true);
                return;
            }
            ScoreText.text = $"{++CurrentCount} / {CurrentMaxCount}";
            
        }
        public void setMaxCount(int newValue)
        {
            if(newValue >= 0)
            {
                CurrentMaxCount = newValue;
                ScoreText.text = $"{CurrentCount} / {CurrentMaxCount}";
            }
        }
    }
}

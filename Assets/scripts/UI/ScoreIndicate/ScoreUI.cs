using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ItemsSorting
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text ScoreText;
        [SerializeField] private Image fullImage;
        [SerializeField] private int _id;
        public int Id { get { return _id; } }

        private int CurrentCount = 0;
        private int CurrentMaxCount = 0;

        private void Start()
        {
            ScoreText.text = $"0/{CurrentMaxCount}";
        }

        public void ScoreUpdateHandler()
        {

            ScoreText.text = $"{++CurrentCount} / {CurrentMaxCount}";
            if (CurrentCount >= CurrentMaxCount)
            {
                ScoreText.gameObject.SetActive(false);
                fullImage.gameObject.SetActive(true);
                return;
            }
            
        }
        public void setMaxCount(int newValue)
        {
            if (newValue <= 0)
            {
                return;
            }
                CurrentMaxCount = newValue;
                ScoreText.text = $"{CurrentCount} / {CurrentMaxCount}";
        }
    }
}

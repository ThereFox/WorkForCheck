using UnityEngine;

namespace ItemsSorting
{
    public class Saver : MonoBehaviour
    {
        [SerializeField] private Object[] elements;
        // Start is called before the first frame update
        void Start()
        {
            if(PlayerPrefs.GetInt("isSaved",0) == 1)
            {
                Destroy(this);
                return;
            }
            PlayerPrefs.SetInt("isSaved", 1);
            DontDestroyOnLoad(this.gameObject);
            foreach (var item in elements)
            {
                DontDestroyOnLoad(item);
            }
        }
        private void OnDestroy()
        {
            PlayerPrefs.SetInt("isSaved", 0);
        }
    }
}

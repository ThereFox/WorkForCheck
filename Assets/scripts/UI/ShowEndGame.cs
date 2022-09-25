using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class ShowEndGame : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        public void ShowWinCanvas()
        {
            canvas.gameObject.SetActive(true);

        }
    }
}

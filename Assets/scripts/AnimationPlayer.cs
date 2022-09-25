using UnityEngine;

namespace ItemsSorting
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private void Start()
        {
            PlayWin();
        }

        public void PlayWin()
        {
            animator.SetTrigger("Win");
        }
        public void PlayLose()
        {
            animator.SetTrigger("Lose");
        }

    }
}

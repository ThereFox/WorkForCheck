using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace ItemsSorting
{
    public class Animate : MonoBehaviour
    {
        [SerializeField] private PostProcessVolume _volume;
        [SerializeField] private float _animationTime = 0.3f;

        private float _elapsedTime;
        private bool _isPlaying = false;

        public void StartAnimate()
        {
            if (_isPlaying)
                return;
            _isPlaying = true;
            _elapsedTime = 0f;
            StartCoroutine(runAnimation());
        }

        protected IEnumerator runAnimation()
        {
            while (true)
            {
                while (_elapsedTime < _animationTime)
                {
                    yield return new WaitForEndOfFrame();

                    _volume.weight = Mathf.Sin(Mathf.PI * _elapsedTime / _animationTime);


                    _elapsedTime += Time.deltaTime;

                }
                _isPlaying = false;
            }
        }
        private void OnDestroy()
        {
            StopCoroutine(runAnimation());
        }

    }
}

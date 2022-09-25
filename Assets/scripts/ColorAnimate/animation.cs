using System.Collections;
using UnityEngine;

namespace ItemsSorting
{
    public class animation : MonoBehaviour
    {
        [SerializeField] private Color _startColor = Color.black;
        [SerializeField] private Color _endColor = Color.blue;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _timeOfAnimation = 0.3f;
        
        private bool animationContue = false;
        private Material _material;
        private float _timeOfContueOfAnimation;

        private void Awake()
        {
            _material = _meshRenderer.material;
        }

        public void StartAnimate()
        {
            if (animationContue)
                return;
            _timeOfContueOfAnimation = 0;
            animationContue = true;
            StartCoroutine(runAnimation());
        }

        public void StopAnimate()
        {
            if (!animationContue)
                return;
            animationContue = false;
            StopCoroutine(runAnimation());
        }

        protected IEnumerator runAnimation()
        {
            while (true)
            {
                while (_timeOfContueOfAnimation < _timeOfAnimation)
                {
                    yield return new WaitForEndOfFrame();

                    _material.color = Color.Lerp(_startColor, _endColor, Mathf.PingPong(2 * _timeOfContueOfAnimation / _timeOfAnimation, 1));
                    _timeOfContueOfAnimation += Time.deltaTime;

                }
                animationContue = false;
                _timeOfContueOfAnimation = 0;
            }
        }
        private void OnDestroy()
        {
            StopCoroutine(runAnimation());
        }
    }
}

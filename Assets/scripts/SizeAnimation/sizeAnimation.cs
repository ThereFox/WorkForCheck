using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class sizeAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 _endSize = Vector3.zero;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _timeOfAnimation = 0.3f;
        
        private bool animationContue = false;
        private float _timeOfContueOfAnimation;
        private GameObject item;
        private Vector3 _startSize;

        private void Awake()
        {
            _startSize = this.gameObject.transform.localScale;
        }
        public void StartAnimate(GameObject gameObject)
        {
            if (animationContue)
                return;
            item = gameObject;
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
                while (_timeOfContueOfAnimation < _timeOfAnimation)
                {
                    yield return new WaitForEndOfFrame();

                    _transform.transform.localScale = Vector3.Lerp(_startSize, _endSize, Mathf.PingPong(2 * _timeOfContueOfAnimation / _timeOfAnimation, 1));
                    
                    _timeOfContueOfAnimation += Time.deltaTime;

                }
                animationContue = false;
                _timeOfContueOfAnimation = 0;
                Destroy(item.gameObject);
        }
        private void OnDestroy()
        {
            StopCoroutine(runAnimation());
        }
    }
}

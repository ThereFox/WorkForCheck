using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


namespace ItemsSorting
{
    public class UIIndicate : MonoBehaviour
    {
        [SerializeField] private Volume volume;

        [SerializeField] private float startValue;
        [SerializeField] private float endValue;

        [SerializeField] private Color trueColor;
        [SerializeField] private Color falseColor;

        private bool isRunning = false;
        private Vignette vignette;

        private bool isTrueUrn = false;

        private void Start()
        {
            if (volume.profile.TryGet<Vignette>(out vignette) == false)
            {
                return;
            }
        }

        public void StartAnimation(bool IsTrueUrn)
        {
            if (isRunning || volume == null)
            {
                return;
            }

            isTrueUrn = IsTrueUrn;
            isRunning = true;
            StartCoroutine(AnimationCooruntime());
        }
        public void StopAnimation()
        {
            if (isRunning == false)
            {
                return;
            }

            isRunning = false;
        }

        public IEnumerator AnimationCooruntime()
        {
            vignette.color.Override(isTrueUrn ? trueColor : falseColor);
            var iter = 0f;
            var lastValue = volume.weight;

            while (volume.weight > startValue)
            {
                yield return new WaitForEndOfFrame();
                volume.weight = Mathf.Lerp(lastValue, 0, Mathf.Sin(iter));
                iter += Time.deltaTime * 4f;
            }

            iter = 0f;
            lastValue = volume.weight;

            while (volume.weight < startValue - (startValue * 0.3) && isRunning)
            {
                yield return new WaitForEndOfFrame();
                volume.weight = Mathf.Lerp(0, startValue, Mathf.Sin(iter));
                iter += Time.deltaTime * 1.75f;

            }
            iter = 0f;
            lastValue = volume.weight;
            while (isRunning)
            {
                yield return new WaitForEndOfFrame();
                volume.weight = Mathf.Lerp(lastValue, endValue, Mathf.Sin(iter));
                iter += Time.deltaTime * 2.5f;
            }
            
            iter = 0f;
            lastValue = volume.weight;
            while (volume.weight > 0.1 && !isRunning)
            {
                yield return new WaitForEndOfFrame();
                volume.weight = Mathf.Lerp(lastValue, 0, Mathf.Sin(iter));
                iter += Time.deltaTime * 1.5f;
            }

            StopCoroutine(AnimationCooruntime());

        }
    }
}

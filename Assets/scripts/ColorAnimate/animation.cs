using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItemsSorting
{
    public class animation : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.black;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private float _timeOfAnimation = 0.3f;
        
        private bool animationContue = false;
        private Material _material;
        private Color _initialColor;
        private float _timeOfContueOfAnimation;

        private void Awake()
        {
            _material = _meshRenderer.material;
            _initialColor = _material.color;
        }
        public void Animate()
        {
            if (animationContue)
                return;
            
            animationContue = true;
        }

        protected IEnumerable animation()
        {
            while (true)
            {
                yield return new WaitForEndOfFrame();

                _material.color = Color.Lerp(_color, _initialColor, Mathf.);
                
            }
        }
    }
}

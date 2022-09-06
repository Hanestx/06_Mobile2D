using DG.Tweening;
using UnityEngine;

namespace Mobile2D.Tween
{
    internal class TweenComplexAnim : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _countLoops;
        [SerializeField] private float _positionX;
        [SerializeField] private float _endScale;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
                ComplexTween();
        }
        
        private void ComplexTween()
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOMoveY(_positionX, _duration).SetLoops(_countLoops).SetEase(Ease.InOutQuad));
            sequence.Insert(0, transform.DOScale(_endScale, _duration));
            sequence.Insert(1, transform.DOJump(Vector3.forward, 3, 3, _duration));
        }
        
    }
}
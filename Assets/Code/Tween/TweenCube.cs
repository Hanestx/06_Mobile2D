using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace Mobile2D.Tween
{
    internal class TweenCube : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _endValue;
        [SerializeField] private Color _color;
        [SerializeField] private PathType _pathType = PathType.CubicBezier;
        [SerializeField] private Transform[] _points;

        private List<Vector3> _pointPosition = new List<Vector3>();
        private Material _material;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        void Start()
        {
            foreach (var point in _points)
                _pointPosition.Add(point.position);

            transform.DOPath(_pointPosition.ToArray(), _duration, _pathType);
            _material.DOColor(_color, _duration);
        }
    }
}

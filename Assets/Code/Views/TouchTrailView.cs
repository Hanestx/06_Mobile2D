using UnityEngine;


namespace Mobile2D
{
    internal sealed class TouchTrailView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _trailPrefab = null;
        [SerializeField] private Camera _cameraTrail;
        [SerializeField] private float _clearSpeed = 100.0f;
        [SerializeField] private float _distanceFromCamera = 35.0f;

        public LineRenderer TrailPrefab => _trailPrefab;
        public Camera CameraTrail => _cameraTrail;
        public float ClearSpeed => _clearSpeed;
        public float DistanceFromCamera => _distanceFromCamera;
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Mobile2D
{
    public class TouchTrailController : BaseController
    {
        private readonly ResourcePath _viewPath = new ResourcePath{PathResource = "Prefabs/TrailMaker"};
        private readonly TouchTrailView _trailView;
        
        private List<Vector3> _points = new List<Vector3>();
        private LineRenderer _currentTrail;
        private LineRenderer _trailPrefab;
        private Camera _cameraTrail;
        private float _clearSpeed;
        private float _distanceFromCamera;
        
        public TouchTrailController()
        {
            _trailView = LoadView();
            _trailPrefab = _trailView.TrailPrefab;
            _cameraTrail = _trailView.CameraTrail;
            _clearSpeed = _trailView.ClearSpeed;
            _distanceFromCamera = _trailView.DistanceFromCamera;
        }

        private TouchTrailView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<TouchTrailView>();
        }
        
        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DestroyCurrentTrail();
                CreateCurrentTrail();
                AddPoint();
            }

            if (Input.GetMouseButton(0))
            {
                AddPoint();
            }

            UpdateTrailPoints();
            ClearTrailPoints();
        }

        private void DestroyCurrentTrail()
        {
            if (_currentTrail != null)
            {
                Object.Destroy(_currentTrail.gameObject);
                _currentTrail = null;
                _points.Clear();
            }
        }

        private void CreateCurrentTrail()
        {
            _currentTrail = Object.Instantiate(_trailPrefab);
            _currentTrail.transform.SetParent(_trailView.gameObject.transform, true);
        }

        private void AddPoint()
        {
            Vector3 mousePosition = Input.mousePosition;
            _points.Add(_cameraTrail.ViewportToWorldPoint(new Vector3(mousePosition.x / Screen.width,
                mousePosition.y / Screen.height,
                _distanceFromCamera)));
        }

        private void UpdateTrailPoints()
        {
            if (_currentTrail != null && _points.Count > 1)
            {
                _currentTrail.positionCount = _points.Count;
                _currentTrail.SetPositions(_points.ToArray());
            }
            else
            {
                DestroyCurrentTrail();
            }
        }

        private void ClearTrailPoints()
        {
            float clearDistance = Time.deltaTime * _clearSpeed;
            while (_points.Count > 1 && clearDistance > 0)
            {
                float distance = (_points[1] - _points[0]).magnitude;
                if (clearDistance > distance)
                {
                    _points.RemoveAt(0);
                }
                else
                {
                    _points[0] = Vector3.Lerp(_points[0], _points[1], clearDistance / distance);
                }

                clearDistance -= distance;
            }
        }

        void OnDisable()
        {
            DestroyCurrentTrail();
        }
    }
}
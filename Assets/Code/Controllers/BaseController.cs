using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Mobile2D
{
    internal abstract class BaseController : IDisposable
    {
        private List<BaseController> _baseControllers = new();
        private List<GameObject> _gameObjects = new();
        private bool _isDisposed;

        public void Dispose()
        {
            if (_isDisposed)
                return;

            _isDisposed = true;

            foreach (BaseController baseController in _baseControllers)
                baseController?.Dispose();

            _baseControllers.Clear();

            foreach (GameObject cachedGameObject in _gameObjects)
                Object.Destroy(cachedGameObject);

            _gameObjects.Clear();

            OnDispose();
        }

        protected void AddController(BaseController baseController)
        {
            _baseControllers.Add(baseController);
        }

        protected void AddGameObjects(GameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {
        }
    }
}
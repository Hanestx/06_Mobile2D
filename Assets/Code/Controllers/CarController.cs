using UnityEngine;


namespace Mobile2D
{
    internal class CarController : BaseController, IAbilityActivator
    {
        private readonly ResourcePath _viewPath = new ResourcePath {PathResource = "Prefabs/Car"};
        private readonly CarView _carView;

        public CarController()
        {
            _carView = LoadView();
        }

        private CarView LoadView()
        {
            var objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath));
            AddGameObjects(objView);
            return objView.GetComponent<CarView>();
        }

        private GameObject GetGameObject()
        {
            return _carView.gameObject;
        }

        public GameObject GetViewObject()
        {
            throw new System.NotImplementedException();
        }

        /*private void OnAbilityUseRequested(object sender, IItem e)
        {
            if (_abilityRepository.AbilityMapByItemId.TryGetValue(e.Id, out var ability))
                ability.Apply(_abilityActivator);
        }*/
    }
}
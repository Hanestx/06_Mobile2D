namespace Mobile2D
{
    internal class AbilityController : BaseController, IAbilityController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IRepository<int, IAbility> _abilityRepository;
        private readonly AbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        public AbilityController(
            IRepository<int, IAbility> abilityRepository,
            IInventoryModel inventoryModel,
            AbilityCollectionView abilityCollectionView)
        {
            _abilityRepository = abilityRepository;
            _inventoryModel = inventoryModel;
            _abilityCollectionView = abilityCollectionView;
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        }

        protected override void OnDispose()
        {
            CleanupView();
        }

        private void SubscribeView()
        {
            _abilityCollectionView.UseRequested += OnAbilityUseRequested;
        }

        private void CleanupView()
        {
            _abilityCollectionView.UseRequested -= OnAbilityUseRequested;
        }

        private void OnAbilityUseRequested(IItem item)
        {
            if (_abilityRepository.Collection.TryGetValue(item.ID, out var ability))
            {
                ability.Apply();
            }
        }

        public void ShowAbilities()
        {
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
            _abilityCollectionView.Show();
        }
    }
}
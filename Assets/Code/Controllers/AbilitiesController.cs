using System;

namespace Mobile2D
{
    internal class AbilitiesController : BaseController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IAbilityRepository _abilityRepository;
        private readonly IAbilityCollectionView _abilityCollectionView;
        private readonly IAbilityActivator _abilityActivator;

        public AbilitiesController(
            IAbilityActivator abilityActivator,
            IInventoryModel inventoryModel,
            IAbilityRepository abilityRepository,
            IAbilityCollectionView abilityCollectionView)
        {
            _abilityActivator = abilityActivator ?? throw new ArgumentNullException(nameof(abilityActivator));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _abilityRepository = abilityRepository ?? throw new ArgumentNullException(nameof(abilityRepository));
            _abilityCollectionView =
                abilityCollectionView ?? throw new ArgumentNullException(nameof(abilityCollectionView));
            _abilityCollectionView.Display(_inventoryModel.GetEquippedItems());
        }
    }
}
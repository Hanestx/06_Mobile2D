using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Mobile2D
{
    internal class ShedController : BaseController
    {
        private readonly Car _car;
        private readonly UpgradeHandlersRepositoryController _upgradeHandlersRepository;
        private readonly ItemsRepositoryController _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;

        private readonly InventoryController _inventoryController;
        //private readonly IInventoryView _inventoryView;

        public ShedController(List<UpgradeItemConfig> upgradeItemConfigs, Car car)
        {
            if (upgradeItemConfigs == null) throw new ArgumentNullException(nameof(upgradeItemConfigs));
            _car = car ?? throw new ArgumentNullException(nameof(car));
            _upgradeHandlersRepository = new UpgradeHandlersRepositoryController(upgradeItemConfigs);
            AddController(_upgradeHandlersRepository);

            _upgradeItemsRepository =
                new ItemsRepositoryController(upgradeItemConfigs.Select(value => value.Config).ToList());
            AddController(_upgradeItemsRepository);

            //_inventoryView = 

            _inventoryModel = new InventoryModel();
            //_inventoryController = new InventoryController(_inventoryModel, _upgradeItemsRepository, null); // Add InventoryView
            AddController(_inventoryController);
        }

        public void Enter()
        {
            _inventoryController.ShowInventory();
            Debug.Log($"Enter: car has speed : {_car.Speed}");
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(
                _car, _inventoryModel.GetEquippedItems(), _upgradeHandlersRepository.UpgradeItems);
            Debug.Log($"Exit: car has speed : {_car.Speed}");
        }

        private void UpgradeCarWithEquippedItems(
            IUpgradableCar upgradableCar,
            IReadOnlyList<IItem> equippedItems,
            IReadOnlyDictionary<int, IUpgradeCarHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.ID, out var handler))
                {
                    handler.Upgrade(upgradableCar);
                }
            }
        }
    }
}
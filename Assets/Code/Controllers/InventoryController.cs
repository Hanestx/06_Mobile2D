using System;
using System.Collections.Generic;

namespace Mobile2D
{
    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryWindowView;

        public InventoryController(List<ItemConfig> itemConfigs)
        {
            _inventoryModel = new InventoryModel();
            _itemsRepository = new ItemsRepositoryController(itemConfigs);
            _inventoryWindowView = new InventoryView();
        }

        public void ShowInventory()
        {
            foreach (var item in _itemsRepository.Items.Values)
                _inventoryModel.EquipItem(item);

            var equippedItems = _inventoryModel.GetEquippedItems();
            _inventoryWindowView.Display(equippedItems);

        }

        public void HideInventory()
        {
            foreach (var item in _itemsRepository.Items.Values)
            {
                _inventoryModel.UnequipItem(item);
            }
        }
    }
}
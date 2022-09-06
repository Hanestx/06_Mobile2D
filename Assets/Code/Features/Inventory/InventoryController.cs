using System;
using System.Collections.Generic;


namespace Mobile2D
{
    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IRepository<int, IItem> _itemsRepository;
        private readonly IInventoryView _inventoryWindowView;

        private Action _hideAction;

        public InventoryController(List<ItemConfig> itemConfigs)
        {
            _inventoryModel = new InventoryModel();
            _inventoryWindowView = new InventoryView();
            _itemsRepository = new ItemsRepositoryController(itemConfigs);

            SubscribeView();
        }

        protected override void OnDispose()
        {
            CleanupView();
        }

        public IReadOnlyList<IItem> GetEquippedItems()
        {
            return _inventoryModel.GetEquippedItems();
        }


        public void ShowInventory()
        {
            foreach (var item in _itemsRepository.Collection.Values)
                _inventoryModel.EquipItem(item);

            var equippedItems = _inventoryModel.GetEquippedItems();
            _inventoryWindowView.Display(equippedItems);
        }

        public void HideInventory()
        {
            _inventoryWindowView.Hide();
            _hideAction?.Invoke();

            foreach (var item in _itemsRepository.Collection.Values)
                _inventoryModel.UnequipItem(item);
        }

        private void SubscribeView()
        {
            _inventoryWindowView.Selected += OnItemSelected;
            _inventoryWindowView.Deselected += OnItemDeselected;
        }

        private void CleanupView()
        {
            _inventoryWindowView.Selected -= OnItemSelected;
            _inventoryWindowView.Deselected -= OnItemDeselected;
        }

        private void OnItemSelected(IItem item)
        {
            _inventoryModel.EquipItem(item);
        }

        private void OnItemDeselected(IItem item)
        {
            _inventoryModel.UnequipItem(item);
        }
    }
}
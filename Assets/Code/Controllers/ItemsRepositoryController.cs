using System.Collections.Generic;

namespace Mobile2D
{
    internal class ItemsRepositoryController : BaseController, IItemsRepository
    {
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        public ItemsRepositoryController(List<ItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _itemsMapById, upgradeItemConfigs);
        }
        
        protected override void OnDispose()
        {
            _itemsMapById.Clear();
        }

        private void PopulateItems(ref Dictionary<int, IItem> upgradeHandlersMapByType, List<ItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.ID)) 
                    continue;
                
                upgradeHandlersMapByType.Add(config.ID, CreateItem(config));
            }
        }
        private IItem CreateItem(ItemConfig config)
        {
            return new Item
            {
                ID = config.ID,
                Info = new ItemInfo {Title = config.Title}
            };
        }
    }
}
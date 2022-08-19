using System.Collections.Generic;

namespace Mobile2D
{
    internal class UpgradeHandlersRepositoryController : BaseController
    {
        public IReadOnlyDictionary<int, IUpgradeCarHandler> UpgradeItems => _upgradeItemsMapById;
        private Dictionary<int, IUpgradeCarHandler> _upgradeItemsMapById = new Dictionary<int, IUpgradeCarHandler>();
     
        public UpgradeHandlersRepositoryController(List<UpgradeItemConfig> upgradeItemConfigs)
        {
            PopulateItems(ref _upgradeItemsMapById, upgradeItemConfigs);
        }
        
        protected override void OnDispose()
        {
            _upgradeItemsMapById.Clear();
            _upgradeItemsMapById = null;
        }
        
        private void PopulateItems(
            ref Dictionary<int, IUpgradeCarHandler> upgradeHandlersMapByType,
            List<UpgradeItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (upgradeHandlersMapByType.ContainsKey(config.ID)) continue;
                upgradeHandlersMapByType.Add(config.ID, CreateHandlerByType(config));
            }
        }
        private IUpgradeCarHandler CreateHandlerByType(UpgradeItemConfig config)
        {
            switch (config.UpgadeType)
            {
                case UpgradeType.Speed:
                    return new SpeedUpgradeCarHandler(config.Value);
                default:
                    return StubUpgradeCarHandler.Default;
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;


namespace Mobile2D
{
    internal class AbilityRepositoryController : BaseController, IRepository<int, IAbility>
    {
        private readonly Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();
        public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;

        public AbilityRepositoryController(List<AbilityItemConfig> itemConfigs)
        {
            PopulateAbilities(itemConfigs);
        }

        private void PopulateAbilities(List<AbilityItemConfig> configs)
        {
            foreach (var config in configs)
            {
                if (_abilityMapById.ContainsKey(config.ID))
                    continue;

                _abilityMapById.Add(config.ID, CreateAbilityByType(config));
            }
        }

        private IAbility CreateAbilityByType(AbilityItemConfig config)
        {
            switch (config.Type)
            {
                case AbilityType.Gun:
                    return new BombAbility(config);

                default:
                    Debug.LogError($"Not type ability {config.Type}");
                    return null;
            }
        }
    }
}
using UnityEngine;

namespace Bomberman.Model.Definitions.Repositories.BonusItems
{
    [CreateAssetMenu(menuName = "Definitions/BonusItems", fileName = "BonusItemsRepostiory")]
    public class BonusItemsRepostiory : DefinitionRepository<BonusItemDefinition>
    {
#if UNITY_EDITOR
        public BonusItemDefinition[] ItemsForEditor => _collection;
#endif
    }
}
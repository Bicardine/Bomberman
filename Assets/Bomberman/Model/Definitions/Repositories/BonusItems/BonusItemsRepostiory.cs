using UnityEngine;

namespace Bomberman.Model.Definitions.Repositories.BonusItems
{
    [CreateAssetMenu(menuName = "Definitions/BonusItems", fileName = "BonusItems")]
    public class BonusItemsRepostiory : DefinitionRepository<BonusItemDefinition>
    {
#if UNITY_EDITOR
        public BonusItemDefinition[] ItemsForEditor => _collection;
#endif
    }
}
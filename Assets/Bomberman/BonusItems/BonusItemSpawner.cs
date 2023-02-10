using Bomberman.DestructiblesBricks;
using Bomberman.Model.Definitions;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.BonusItems
{
    public class BonusItemSpawner : MonoBehaviour
    {
        [SerializeField] private DestructableBrickSpawner _destructableBrickSpawner;
        [SerializeField] private BonusItem _prefab;
        [SerializeField] private Transform _parent;
        [SerializeField][Range(0, 1)] private float _chance;

        private void OnEnable() => _destructableBrickSpawner.Spawned += OnDestructableBrickSpawned;

        private void OnDisable() => _destructableBrickSpawner.Spawned -= OnDestructableBrickSpawned;

        private void OnDestructableBrickSpawned(DestructableBrick destructableBrick) => destructableBrick.Destructed += OnDestructableBrickDestructed;

        private void OnDestructableBrickDestructed(DestructableBrick destructableBrick)
        {
            destructableBrick.Destructed -= OnDestructableBrickDestructed;
            TrySpawn(destructableBrick.transform.position);
        }

        private void TrySpawn(Vector2 position)
        {
            if (_chance == 0 || Random.value > _chance) return;

            var bonusItems = DefinitionsFacade.Instance.BonusItemsRepostiory.Collection;
            var bonusItemIndexDefinition = Random.Range(0, bonusItems.Length);
            var bonusItemData = bonusItems[bonusItemIndexDefinition].Data;

            var bonusItem = Pool.Instance.Get(_prefab);
            bonusItem.Render(bonusItemData);
            bonusItem.transform.position = position;
            bonusItem.transform.parent = _parent;
        }
    }
}
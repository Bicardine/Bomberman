using Bomberman.Components;
using Bomberman.Explosions;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.DestructiblesBricks
{
    public class DestructableBrickSpawner : MonoBehaviour
    {
        [SerializeField] private DeleteTileComponent _deleteTailComponent;
        [SerializeField] private DestructableBrick _destructableBrick;
        [SerializeField] private Transform _parent;

        private void OnEnable() => _deleteTailComponent.OnDeleted.AddListener(Spawn);

        private void OnDisable() =>_deleteTailComponent.OnDeleted.RemoveListener(Spawn);

        private void Spawn(Vector2 position)
        {
            var instance = Pool.Instance.Get(_destructableBrick);
            instance.transform.position = position;
            instance.transform.parent = _parent;
        }
    }
}
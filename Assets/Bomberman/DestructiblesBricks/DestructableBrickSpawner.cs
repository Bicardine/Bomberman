using System;
using Bomberman.Components;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.DestructiblesBricks
{
    public class DestructableBrickSpawner : MonoBehaviour
    {
        [SerializeField] private DeleteTileComponent _deleteTailComponent;
        [SerializeField] private DestructableBrick _destructableBrick;
        [SerializeField] private Transform _parent;

        public event Action<DestructableBrick> Spawned;

        private void OnEnable() => _deleteTailComponent.OnDeleted.AddListener(Spawn);

        private void OnDisable() =>_deleteTailComponent.OnDeleted.RemoveListener(Spawn);

        private void Spawn(Vector2 position)
        {
            var destructableBrick = Pool.Instance.Get(_destructableBrick);
            destructableBrick.transform.position = position;
            destructableBrick.transform.parent = _parent;
            Spawned.Invoke(destructableBrick);
        }
    }
}
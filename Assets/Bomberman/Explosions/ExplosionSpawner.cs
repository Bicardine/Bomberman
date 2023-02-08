using Bomberman.Components;
using Bomberman.Components.ColliderBased;
using Bomberman.Utils;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.Explosions
{
    [RequireComponent(typeof(CheckOverlapBoxComponent))]
    [RequireComponent(typeof(DeleteTileComponent))]
    public class ExplosionSpawner : MonoBehaviour
    {
        [SerializeField] private Explosion _explosion;
        [SerializeField] private Transform _parent;
        [SerializeField] private Vector2[] _directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right};
        [SerializeField] private int _explosionLength = 2;

        private CheckOverlapBoxComponent _checkOverlapBoxComponent;
        private DeleteTileComponent _deleteTileComponent;

        private void OnValidate()
        {
            if (_explosionLength < 1)
                _explosionLength = 1;
        }

        private void Awake()
        {
            _checkOverlapBoxComponent = GetComponent<CheckOverlapBoxComponent>();
            _deleteTileComponent = GetComponent<DeleteTileComponent>();
        }

        public void Spawn(Vector2 position)
        {
            SpawnExplosion(position);
            SpawnWavesExplosion(position);
        }

        private Explosion SpawnExplosion(Vector2 position)
        {
            var instance = Pool.Instance.Get(_explosion);
            instance.transform.position = position.Round();
            instance.transform.parent = _parent;
            instance.SetExplosionType(ExplosionType.Start);

            return instance;
        }

        public void SpawnWavesExplosion(Vector2 position)
        {
            foreach (var direction in _directions)
                Explode(position, direction, _explosionLength);
        }

        private void Explode(Vector2 position, Vector2 direction, int length)
        {
            if (length <= 0) return;

            position += direction;
            if (_checkOverlapBoxComponent.Check(position))
            {
                _deleteTileComponent.Delete(position);
                return;
            }

            var instance = SpawnExplosion(position);
            instance.SetDirection(direction);
            var explosionType = length > 1 ? ExplosionType.Middle : ExplosionType.End;
            instance.SetExplosionType(explosionType);
            Explode(position, direction, length - 1);
        }
    }
}
using Bomberman.Bombs;
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
        [SerializeField] private BombSpawner _bombSpawner;
        [SerializeField] private Explosion _explosion;
        [SerializeField] private Transform _parent;
        [SerializeField] private Vector2[] _directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right};

        private CheckOverlapBoxComponent _checkOverlapBoxComponent;
        private DeleteTileComponent _deleteTileComponent;

        private void Awake()
        {
            _checkOverlapBoxComponent = GetComponent<CheckOverlapBoxComponent>();
            _deleteTileComponent = GetComponent<DeleteTileComponent>();
        }

        private void OnEnable() => _bombSpawner.Spawned += OnBombSpawned;

        private void OnDisable() => _bombSpawner.Spawned -= OnBombSpawned;

        private void OnBombSpawned(Bomb bomb) => bomb.Activated += OnBombActivated;

        private void OnBombActivated(Bomb bomb)
        {
            bomb.Activated -= OnBombActivated;
            Spawn(bomb.transform.position, bomb.BlustRadius);
        }

        private void Spawn(Vector2 position, int blustRadius)
        {
            position = position.Round();
            SpawnExplosion(position);
            SpawnWavesExplosion(position, blustRadius);
        }

        private Explosion SpawnExplosion(Vector2 position)
        {
            var explosion = Pool.Instance.Get(_explosion);
            explosion.transform.position = position.Round();
            explosion.transform.parent = _parent;
            explosion.SetExplosionType(ExplosionType.Start);

            return explosion;
        }

        public void SpawnWavesExplosion(Vector2 position, int blustRadius)
        {
            foreach (var direction in _directions)
                Explode(position, direction, blustRadius);
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

            var explosion = SpawnExplosion(position);
            explosion.SetDirection(direction);
            var explosionType = length > 1 ? ExplosionType.Middle : ExplosionType.End;
            explosion.SetExplosionType(explosionType);
            Explode(position, direction, length - 1);
        }
    }
}
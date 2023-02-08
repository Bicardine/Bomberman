using Bomberman.Creatures.Hero;
using Bomberman.Explosions;
using Bomberman.Utils.ObjectPool;
using BombermanComponents;
using UnityEngine;

namespace Bomberman.Bombs
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(TimerComponent))]
    public class Bomb : PoolItem
    {
        private Collider2D _collider;
        private TimerComponent _timerComponent;
        private ExplosionSpawner _explosionSpawner;

        private static readonly string ExplosionKey = "Explosion";

        private void Awake()
        {
            _timerComponent = GetComponent<TimerComponent>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnEnable()
        {
            _timerComponent.SetTimer(ExplosionKey);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Hero hero))
                _collider.isTrigger = false;
        }

        public void Init(ExplosionSpawner explosionSpawner) => _explosionSpawner = explosionSpawner;

        public void SpawnExplosion()
        {
            _explosionSpawner.Spawn(transform.position);
        }

        public override void Restart()
        {
            base.Restart();
            
            _collider.isTrigger = true;
        }
    }
}
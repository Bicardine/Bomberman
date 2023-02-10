using System;
using Bomberman.Creatures.Hero;
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
        private int _blustRadius = 1;

        public int BlustRadius => _blustRadius;

        private static readonly string ExplosionKey = "Explosion";

        public event Action<Bomb> Activated;

        private void Awake()
        {
            _timerComponent = GetComponent<TimerComponent>();
            _collider = GetComponent<Collider2D>();
        }

        private void OnEnable() => _timerComponent.SetTimer(ExplosionKey);

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Hero hero))
                _collider.isTrigger = false;
        }

        public void Init(int blustRadius) => _blustRadius = blustRadius;

        public void Activate()
        {
            Activated?.Invoke(this);
            Release();
        }

        public override void Restart()
        {
            base.Restart();

            _collider.isTrigger = true;
        }
    }
}
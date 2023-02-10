using Bomberman.Components;
using Bomberman.Utils.ObjectPool;
using BombermanComponents;
using UnityEngine;

namespace Bomberman.Explosions
{
    [RequireComponent(typeof(SpriteAnimationComponent))]
    [RequireComponent(typeof(SetDirectionComponent))]
    [RequireComponent(typeof(TimerComponent))]
    public class Explosion : PoolItem
    {
        private SpriteAnimationComponent _spriteAnimationComponent;
        private SetDirectionComponent _setDirectionComponent;
        private TimerComponent _timerComponent;

        private static readonly string ReleaseKey = "Release";

        private void Awake()
        {
            _spriteAnimationComponent = GetComponent<SpriteAnimationComponent>();
            _setDirectionComponent = GetComponent<SetDirectionComponent>();
            _timerComponent = GetComponent<TimerComponent>();
        }

        private void OnEnable() => _timerComponent.SetTimer(ReleaseKey);

        public void SetExplosionType(ExplosionType type) => _spriteAnimationComponent.SetClip(type.ToString());

        public void SetDirection(Vector2 direction) => _setDirectionComponent.SetDirection(direction);
    }
}
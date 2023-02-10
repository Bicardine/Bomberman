using System;
using Bomberman.Components;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.DestructiblesBricks
{
    [RequireComponent(typeof(SpriteAnimationComponent))]
    public class DestructableBrick : PoolItem
    {
        private SpriteAnimationComponent _spriteAnimationComponent;

        public event Action<DestructableBrick> Destructed;

        private void Awake() => _spriteAnimationComponent = GetComponent<SpriteAnimationComponent>();

        public void Destruct()
        {
            Destructed?.Invoke(this);
            Release();
        }

        public override void Restart()
        {
            base.Restart();

            _spriteAnimationComponent.StartAnimation();
        }
    }
}
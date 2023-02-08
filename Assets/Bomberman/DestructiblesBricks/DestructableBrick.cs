using Bomberman.Components;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.DestructiblesBricks
{
    [RequireComponent(typeof(SpriteAnimationComponent))]
    public class DestructableBrick : PoolItem
    {
        private SpriteAnimationComponent _spriteAnimationComponent;

        private void Awake() => _spriteAnimationComponent = GetComponent<SpriteAnimationComponent>();

        public override void Restart()
        {
            base.Restart();

            _spriteAnimationComponent.StartAnimation();
        }
    }
}
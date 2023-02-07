using Bomberman.Bombs;
using Bomberman.Components;
using UnityEngine;

namespace Bomberman.Creatures.Hero
{
    public class Hero : Creature
    {
        [SerializeField] private SpriteAnimationComponent _spriteAnimationComponent;
        [SerializeField] private BombSpawner _bombSpawner;

        private static readonly string UpMovementKey = "UpMovement";
        private static readonly string DownMovementKey = "DownMovement";
        private static readonly string LeftMovementKey = "LeftMovement";
        private static readonly string RightMovementKey = "RightMovement";

        private string _currentMovementKey = DownMovementKey;

        private Vector2 _previousDirection;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            UpdateSpriteDirection(Direction);
        }

        private void UpdateSpriteDirection(Vector2 direction)
        {
            if (_previousDirection == direction) return;

            _previousDirection = direction;

            if (direction.y > 0)
                _currentMovementKey = UpMovementKey;
            else if (direction.y < 0)
                _currentMovementKey = DownMovementKey;
            else if (direction.x > 0)
                _currentMovementKey = RightMovementKey;
            else if (direction.x < 0)
                _currentMovementKey = LeftMovementKey;

            if (direction == Vector2.zero)
            {
                Debug.Log("Vector2 zero...");
                _spriteAnimationComponent.StopAnimation();
                return;
            }

            _spriteAnimationComponent.SetClip(_currentMovementKey);
        }

        public void SpawnBomb()
        {
            _bombSpawner.Spawn(transform.position);
        }
    }
}
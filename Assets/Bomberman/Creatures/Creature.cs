using UnityEngine;

namespace Bomberman.Creatures
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Creature : MonoBehaviour
    {
        [SerializeField] private float Speed;
        
        protected Rigidbody2D Rigidbody;
        protected Vector3 Direction;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var velocity = CalculateVelocity();
            Rigidbody.velocity = velocity;
        }

        public void SetDirection(Vector2 direction) => Direction = direction;

        private Vector2 CalculateVelocity() => new Vector2(Direction.x * Speed, Direction.y * Speed);
    }
}
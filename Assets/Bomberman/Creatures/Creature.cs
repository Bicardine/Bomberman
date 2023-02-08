using UnityEngine;

namespace Bomberman.Creatures
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Creature : MonoBehaviour
    {
        [SerializeField] private float Speed;

        protected Rigidbody2D Rigidbody;
        protected Vector2 Direction;

        private void OnValidate()
        {
            if (Speed < 0)
                Speed = 0;
        }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        protected virtual void FixedUpdate()
        {
            var velocity = CalculateVelocity();
            Rigidbody.velocity = velocity;
        }

        public void SetDirection(Vector2 direction) => Direction = direction;

        private Vector2 CalculateVelocity() => Direction * Speed;
    }
}
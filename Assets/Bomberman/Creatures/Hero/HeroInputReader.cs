using UnityEngine;
using UnityEngine.InputSystem;

namespace Bomberman.Creatures.Hero
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnSpawnBomb(InputAction.CallbackContext context)
        {
            if (context.started)
                _hero.TrySpawnBomb();
        }
    }
}
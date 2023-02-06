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
            Debug.Log(direction);
            _hero.SetDirection(direction);
        }
    }
}
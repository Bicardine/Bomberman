using UnityEngine;

namespace Bomberman.Components
{
    public class SetDirectionComponent : MonoBehaviour
    {
        public void SetDirection(Vector2 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x);
            transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
        }
    }
}
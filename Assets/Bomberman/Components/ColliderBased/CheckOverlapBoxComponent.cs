using UnityEngine;

namespace Bomberman.Components.ColliderBased
{
    public class CheckOverlapBoxComponent : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private Vector2 _size = Vector2.one / 4f;

        public bool Check(Vector2 position) => Physics2D.OverlapBox(position, _size, 0f, _mask);
    }
}
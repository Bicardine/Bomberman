using Bomberman.Creatures.Hero;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.Bombs
{
    [RequireComponent(typeof(Collider2D))]
    public class Bomb : PoolItem
    {
        private Collider2D _collider;

        private void Start() => _collider = GetComponent<Collider2D>();

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Hero hero))
                _collider.isTrigger = false;
        }
    }
}
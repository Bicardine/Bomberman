using Bomberman.Explosions;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.Bombs
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Bomb _bomb;
        [SerializeField] private Transform _parent;
        [SerializeField] private ExplosionSpawner _explosionSpawner;

        public void Spawn(Vector2 position)
        {
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            var instance = Pool.Instance.Get(_bomb);
            instance.transform.position = position;
            instance.transform.parent =_parent;
            instance.Init(_explosionSpawner);
        }
    }
}
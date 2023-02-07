using Bomberman.Utils.ObjectPool;
using BombermanComponents;
using UnityEngine;

namespace Bomberman.Bombs
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Bomb _bomb;
        [SerializeField] private Transform _parent;

        private static readonly string ExplosionKey = "Explosion";

        public void Spawn(Vector2 position)
        {
            position.x = Mathf.Round(position.x);
            position.y = Mathf.Round(position.y);

            var instance = Pool.Instance.Get(_bomb);
            instance.transform.position = position;
            instance.transform.parent =_parent;

            if (instance.TryGetComponent(out TimerComponent timerComponent))
                timerComponent.SetTimer(ExplosionKey);
        }
    }
}
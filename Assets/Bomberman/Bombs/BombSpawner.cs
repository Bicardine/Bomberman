using System;
using Bomberman.Utils;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.Bombs
{
    public class BombSpawner : MonoBehaviour
    {
        [SerializeField] private Bomb _bomb;
        [SerializeField] private Transform _parent;

        public event Action<Bomb> Spawned;
        
        public void Spawn(Vector2 position)
        {
            var bomb = Pool.Instance.Get(_bomb);
            bomb.transform.position = position.Round();
            bomb.transform.parent =_parent;
            Spawned?.Invoke(bomb);
        }
    }
}
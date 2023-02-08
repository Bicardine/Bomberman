using UnityEngine;
using UnityEngine.Events;

namespace Bomberman.Utils.ObjectPool
{
    public class PoolItem : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onRestart;
        
        private int _id;
        private Pool _pool;

        public void Retain(int id, Pool pool)
        {
            _id = id;
            _pool = pool;
        }

        public virtual void Restart() => _onRestart?.Invoke();

        public void Release() => _pool.Release(_id, this);
    }
}
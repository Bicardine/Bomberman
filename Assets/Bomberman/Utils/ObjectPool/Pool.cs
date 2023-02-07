using System.Collections.Generic;
using UnityEngine;

namespace Bomberman.Utils.ObjectPool
{
    public class Pool : MonoBehaviour
    {
        private Dictionary<int, Queue<PoolItem>> _items = new Dictionary<int, Queue<PoolItem>>();

        private const string _defaultPoolName = "POOL";

        private static Pool _instance;

        public static Pool Instance
        {
            get
            {
                if (_instance == null)
                {
                    var instance = new GameObject(_defaultPoolName);
                    _instance = instance.AddComponent<Pool>();
                }

                return _instance;
            }
        }

        public PoolItem Get(PoolItem poolItem)
        {
            var id = poolItem.GetInstanceID();
            var queue = RequireQueue(id);

            if (queue.Count > 0)
            {
                var polledItem = queue.Dequeue();
                polledItem.gameObject.SetActive(true);
                polledItem.Restart();
                return polledItem;
            }

            var instance = Instantiate(poolItem);
            instance.Retain(id, this);
            return instance;
        }

        private Queue<PoolItem> RequireQueue(int id)
        {
            if (!_items.TryGetValue(id, out var queue))
            {
                queue = new Queue<PoolItem>();
                _items.Add(id, queue);
            }

            return queue;
        }

        public void Release(int id, PoolItem poolItem)
        {
            var queue = RequireQueue(id);
            queue.Enqueue(poolItem);
            poolItem.gameObject.SetActive(false);
        }
    }
}
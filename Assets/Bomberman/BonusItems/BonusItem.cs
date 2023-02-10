using Bomberman.Creatures.Hero;
using Bomberman.Model.Data;
using Bomberman.Utils.ObjectPool;
using UnityEngine;

namespace Bomberman.BonusItems
{
    public class BonusItem : PoolItem, IItemRenderer<BonusItemData>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private IUsable _usableBehaviour;

        public void Render(BonusItemData data)
        {
            _usableBehaviour = data.UsableBehaviour;
            _spriteRenderer.sprite = data.Sprite;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter...");
            if (other.TryGetComponent(out Hero hero))
                Use(hero);
            Release();
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("OnCollisionEnter");    
        }

        public void Use(Hero hero) => _usableBehaviour.Use(hero);
    }
}
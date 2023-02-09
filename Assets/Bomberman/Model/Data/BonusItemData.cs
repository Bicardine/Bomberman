using System;
using Bomberman.BonusItems;
using Bomberman.BonusItems.Behaviours;
using UnityEngine;

namespace Bomberman.Model.Data
{
    [Serializable]
    public class BonusItemData
    {
        [SerializeField] private Sprite _sprite;
        [SerializeField] private UsableBehaviour _usableBehaviour;
        
        public IUsable UsableBehaviour => _usableBehaviour;
        public Sprite Sprite => _sprite;

        public BonusItemData(UsableBehaviour usableBehaviour, Sprite sprite)
        {
            _usableBehaviour = usableBehaviour;
            _sprite = sprite;
        }
    }
}
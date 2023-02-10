using System;
using Bomberman.Creatures.Hero;
using Bomberman.Model.Data;
using UnityEngine;

namespace Bomberman.BonusItems.Behaviours
{
    [CreateAssetMenu(menuName = "Behaviours/IncreaseBombAmount", fileName = "IncreaseBombAmountBehaviour")]
    [Serializable]
    public class IncreaseBombAmountBehaviour : UsableBehaviour
    {
        [SerializeField] private PositiveIntData _intData;

        public override void Use(Hero hero) => hero.IncreaseBombAmount(_intData.Value);
    }
}
using System;
using Bomberman.Creatures.Hero;
using Bomberman.Model.Data;
using UnityEngine;

namespace Bomberman.BonusItems.Behaviours
{
    [CreateAssetMenu(menuName = "Behaviours/SpeedIncrease", fileName = "SpeedIncreaseBehaviour")]
    [Serializable]
    public class SpeedIncreaseBehaviour : UsableBehaviour
    {
        [SerializeField] private PositiveIntData _intData;

        public override void Use(Hero hero) => hero.IncreaseSpeed(_intData.Value);
    }
}
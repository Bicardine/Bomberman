using System;
using Bomberman.Creatures.Hero;
using Bomberman.Model.Data;
using UnityEngine;

namespace Bomberman.BonusItems.Behaviours
{
    [CreateAssetMenu(menuName = "Behaviours/IncreaseBlastRadius", fileName = "IncreaseBlastRadiusBehaviour")]
    [Serializable]
    public class IncreaseBlastRadiusBehaviour : UsableBehaviour
    {
        [SerializeField] private PositiveIntData _intData;

        public override void Use(Hero hero) => hero.IncreaseBlustRadius(_intData.Value);
    }
}
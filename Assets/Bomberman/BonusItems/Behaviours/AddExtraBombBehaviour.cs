using System;
using Bomberman.Creatures.Hero;
using UnityEngine;

namespace Bomberman.BonusItems.Behaviours
{
    [CreateAssetMenu(menuName = "Behaviours/AddExtraBomb", fileName = "AddExtraBombBehaviour")]
    [Serializable]
    public class AddExtraBombBehaviour : UsableBehaviour
    {
        public override void Use(Hero hero) => hero.AddExtraBomb();
    }
}
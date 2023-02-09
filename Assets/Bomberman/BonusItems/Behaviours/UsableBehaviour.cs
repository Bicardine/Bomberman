using System;
using Bomberman.Creatures.Hero;
using UnityEngine;

namespace Bomberman.BonusItems.Behaviours
{
    [Serializable]
    public abstract class UsableBehaviour : ScriptableObject, IUsable
    {
        public abstract void Use(Hero hero);
    }
}
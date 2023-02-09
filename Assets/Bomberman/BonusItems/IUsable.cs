using System;
using Bomberman.Creatures.Hero;

namespace Bomberman.BonusItems
{
    public interface IUsable
    {
        void Use(Hero hero);
    }
}
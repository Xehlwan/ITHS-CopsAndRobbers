﻿using System;

namespace CopsAndRobbers.Game
{
    public class Thief : Person
    {
        public override char Symbol => 'T';

        public override ConsoleColor SymbolColor => ConsoleColor.Red;

        public override (string, ConsoleColor) TakeItem(Person victim)
        {
            if (victim is Citizen)
            {
                if (victim.Inventory.Count == 0) return ("Thief tried to steal, but citizen had nothing!", SymbolColor);

                var index = Rng.Next(0, victim.Inventory.Count);
                var item = victim.Inventory[index];
                Inventory.Add(item);
                victim.Inventory.RemoveAt(index);

                return ($"Thief stole: {item.Name}.", SymbolColor);
            }

            return (null, SymbolColor);
        }
    }
}

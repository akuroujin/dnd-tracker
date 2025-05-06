using Godot;
using System;
using System.Collections.Generic;

public class Monster : Unit
{
    public Monster(string name, int maxHealth, int currentHealth, int maxUbi, int currentUbi, int walkSpeed, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int armorClass, int initiative, List<DamageType> resistances, List<Attack> attacks, List<Spell> spells) : base(name, maxHealth, currentHealth, maxUbi, currentUbi, walkSpeed, strength, dexterity, constitution, intelligence, wisdom, charisma, armorClass, initiative, resistances, attacks, spells)
    {
    }
}

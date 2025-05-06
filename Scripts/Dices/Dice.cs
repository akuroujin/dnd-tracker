using System;
public class Dice
{
    public static int Roll(DiceType diceType)
    {
        Random random = new Random();
        return random.Next(1, (int)diceType + 1);
    }
    public static int Roll(DiceType diceType, int amount)
    {
        int total = 0;
        for (int i = 0; i < amount; i++)
        {
            total += Roll(diceType);
        }
        return total;
    }
    public static int RollDisadvantage(DiceType diceType)
    {
        int roll1 = Roll(diceType);
        int roll2 = Roll(diceType);
        return Math.Min(roll1, roll2);
    }
    public static int RollAdvantage(DiceType diceType)
    {
        int roll1 = Roll(diceType);
        int roll2 = Roll(diceType);
        return Math.Max(roll1, roll2);
    }
}
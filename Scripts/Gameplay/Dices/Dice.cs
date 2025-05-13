using System;
public class Dice
{
    private static int Roll(DiceTypes diceType)
    {
        Random random = new Random();
        return random.Next(1, (int)diceType + 1);
    }

    private static int RollDisadvantage(DiceTypes diceType)
    {
        int roll1 = Roll(diceType);
        int roll2 = Roll(diceType);
        return Math.Min(roll1, roll2);
    }
    private static int RollAdvantage(DiceTypes diceType)
    {
        int roll1 = Roll(diceType);
        int roll2 = Roll(diceType);
        return Math.Max(roll1, roll2);
    }

    public static int Roll(DiceTypes diceType, RollType rollType = RollType.Flat)
    {
        switch (rollType)
        {
            case RollType.Disadvantage:
                return RollDisadvantage(diceType);
            case RollType.Advantage:
                return RollAdvantage(diceType);
            default:
                return Roll(diceType);
        }
    }
    public static int Roll(DiceTypes diceType, int amount)
    {
        int total = 0;
        for (int i = 0; i < amount; i++)
        {
            total += Roll(diceType);
        }
        return total;
    }
}

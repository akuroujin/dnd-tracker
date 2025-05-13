using System.Collections.Generic;
public static class Level
{
    public static List<int> Levels { get; private set; } = [
        0,
        300,
        900,
        2700,
        6500,
        14000,
        23000,
        34000,
        48000,
        64000,
        85000,
        100000,
        120000,
        140000,
        165000,
        195000,
        225000,
        265000,
        305000,
        355000
    ];
    public static int GetLevel(int exp)
    {
        for (int i = 0; i < Levels.Count; i++)
        {
            if (exp <= Levels[i])
                return i;
        }
        return Levels.Count;
    }
    public static void ChangeLevels(List<int> levels)
    {
        Levels = levels;
        Levels.Sort();
    }
}

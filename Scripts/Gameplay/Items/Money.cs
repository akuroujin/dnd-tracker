public class Money
{
    public int total = 0;
    public int copper => total % 10;
    public int silver => copper / 10 % 5;
    public int electrum => silver / 5 % 2;
    public int gold => electrum / 2 % 10;
    public int platinum => gold / 10;
    public int TotalCopper => total;
    public int TotalSilver => total / 10;
    public int TotalElectrum => total / 5;
    public int TotalGold => total / 2;
    public int TotalPlatinum => total / 10;

    public Money(int copper = 0, int silver = 0, int electrum = 0, int gold = 0, int platinum = 0)
    {
        int total = copper + silver * 10 + electrum * 50 + gold * 100 + platinum * 1000;
        this.total = total;
    }
}
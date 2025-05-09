public class Item
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Money Price { get; set; }
    public int Weight { get; set; }
    public int Amount { get; set; }
    public int TotalWeight => Weight * Amount;
}
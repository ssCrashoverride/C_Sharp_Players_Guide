Console.WriteLine("What arrow do you want?");
Console.WriteLine("1 - Elite Arrow");
Console.WriteLine("2 - Beginner Arrow");
Console.WriteLine("3 - Marksman Arrow");
Console.WriteLine("4 - Custom Arrow");

string choise = Console.ReadLine();

Arrow arrow = choise switch
{
    "1" => Arrow.CreateEliteArrow(),
    "2" => Arrow.CreateBeginnerArrow(),
    "3" => Arrow.CreateMarksmanArrow(),
    _ => CreateCustomArrow(),
};

Console.WriteLine($"That arrow cost {arrow.Cost} gold.");

Arrow CreateCustomArrow()
{
    Arrowhead arrowhead = GetArrowheadType();
    Fletching fletching = GetFletchingType();
    float lenght = GetLenght();
    return new Arrow(arrowhead, fletching, lenght);
}
Arrowhead GetArrowheadType()
{
    Console.Write("Arrowhead type (steel, wood, obsidian): ");
    string input = Console.ReadLine();
    return input switch
    {
        "steel" => Arrowhead.steel,
        "wood" => Arrowhead.wood,
        "obsidian" => Arrowhead.obsidian
    };
}
Fletching GetFletchingType()
{
    Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
    string input = Console.ReadLine();
    return input switch
    {
        "plastic" => Fletching.plastic,
        "turkey feather" => Fletching.turkeyFeathers,
        "goose feather" => Fletching.gooseFeathers
    };
}
float GetLenght()
{
    float lenght = 0;
    while (lenght < 60 || lenght > 100)
    {
        Console.Write("Arrow lenght (between 60 and 100): ");
        lenght = float.Parse(Console.ReadLine());
    }
    return lenght;
}
public class Arrow
{
    public Arrowhead Arrowhead { get; }
    private Fletching Fletching { get; }
    private float Lenght { get; }
    public static Arrow CreateEliteArrow()
    {
        return new Arrow(Arrowhead.steel, Fletching.plastic, 95);
    }
    public static Arrow CreateBeginnerArrow()
    {
        return new Arrow(Arrowhead.wood, Fletching.gooseFeathers, 75);
    }
    public static Arrow CreateMarksmanArrow()
    {
        return new Arrow(Arrowhead.steel, Fletching.gooseFeathers, 65);
    }
    public Arrow(Arrowhead arrowhead, Fletching fletching, float lenght)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Lenght = lenght;
    }
    public float Cost
    {
        get
        {
            float arrowheadCost = Arrowhead switch
            {
                Arrowhead.steel => 10,
                Arrowhead.wood => 3,
                Arrowhead.obsidian => 5
            };
            float fletchingCost = Fletching switch
            {
                Fletching.plastic => 10,
                Fletching.turkeyFeathers => 5,
                Fletching.gooseFeathers => 3
            };
            float shaftCost = 0.05f * Lenght;
            return arrowheadCost + fletchingCost + shaftCost;
        }
    }

}
public enum Arrowhead { steel, wood, obsidian }
public enum Fletching { plastic, turkeyFeathers, gooseFeathers }
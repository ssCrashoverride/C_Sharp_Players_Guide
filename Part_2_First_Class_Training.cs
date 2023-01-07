Arrow arrow = GetArrow();
Console.WriteLine($"That arrow cost {arrow.GetCost()} gold.");

Arrow GetArrow()
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
class Arrow
{
    public Arrowhead _arrowhead;
    public Fletching _fletching;
    public float _lenght;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float lenght)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _lenght = lenght;
    }
    public float GetCost()
    {
        float arrowheadCost = _arrowhead switch
        {
            Arrowhead.steel => 10,
            Arrowhead.wood => 3,
            Arrowhead.obsidian => 5
        };
        float fletchingCost = _fletching switch
        {
            Fletching.plastic => 10,
            Fletching.turkeyFeathers => 5,
            Fletching.gooseFeathers => 3
        };
        float shaftCost = 0.05f * _lenght;
        return arrowheadCost + fletchingCost + shaftCost;
    }

}
enum Arrowhead { steel, wood, obsidian }
enum Fletching { plastic, turkeyFeathers, gooseFeathers }
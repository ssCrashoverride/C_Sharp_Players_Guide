(SoupType type, MainIngredient ingredient, Seasoning seasoning) soup = GetSoup();
Console.WriteLine($"{soup.seasoning} {soup.ingredient} {soup.type}");

(SoupType, MainIngredient, Seasoning) GetSoup ()
{
    SoupType type = GetSoupType();
    MainIngredient ingredient = GetMainIngradient();
    Seasoning seasoning = GetSeasoning();
    return (type, ingredient, seasoning);
}
SoupType GetSoupType()
{
    Console.WriteLine("Soup type (soup, stew, gumbo): ");
    string input = Console.ReadLine();
    return input switch
    {
        "soup" => SoupType.soup,
        "stew" => SoupType.stew,
        "gumbo" => SoupType.gumbo
    };
}
MainIngredient GetMainIngradient()
{
    Console.WriteLine("Main ingradient (mushrooms, chicken, carrots, potatoes): ");
    string input = Console.ReadLine();
    return input switch
    {
        "mushrooms" => MainIngredient.mushrooms,
        "chicken" => MainIngredient.chicken,
        "carrots" => MainIngredient.carrots,
        "potatoes" => MainIngredient.potatoes
    };
}
Seasoning GetSeasoning()
{
    Console.WriteLine("Seasoning (spicy, salty, sweet): ");
    string input = Console.ReadLine();
    return input switch
    {
        "spicy" => Seasoning.spicy,
        "salty" => Seasoning.salty,
        "sweet" => Seasoning.sweet
    };
}

enum SoupType { soup, stew, gumbo };
enum MainIngredient { mushrooms, chicken, carrots, potatoes };
enum Seasoning { spicy, salty, sweet };
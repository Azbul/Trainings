namespace Inheritance.MapObjects
{
    static class Interaction
    {
        public static void Make(Player player, IMapObject mapObject)
        {
            mapObject.Make(player);
        }
    }
}

namespace Inheritance.MapObjects
{
    class ResourcePile : IMapObject, ITreasure
    {
        public Treasure Treasure { get; set; }

        public void Make(Player player)
        {
            player.Consume(Treasure);
        }
    }
}

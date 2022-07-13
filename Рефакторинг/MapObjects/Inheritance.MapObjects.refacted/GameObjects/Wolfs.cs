namespace Inheritance.MapObjects
{
    class Wolfs : IMapObject, IArmy
    {
        public Army Army { get; set; }

        public void Make(Player player)
        {
            if (!player.CanBeat(Army))
                player.Die();
        }
    }
}

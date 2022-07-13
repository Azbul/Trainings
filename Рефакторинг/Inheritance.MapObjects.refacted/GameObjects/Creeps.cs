namespace Inheritance.MapObjects
{
    class Creeps : IMapObject, IArmy, ITreasure
    {
        public Army Army { get; set; }
        public Treasure Treasure { get; set; }

        public void Make(Player player)
        {
            if (player.CanBeat(Army))
                player.Consume(Treasure);
            else
                player.Die();
        }
    }
}

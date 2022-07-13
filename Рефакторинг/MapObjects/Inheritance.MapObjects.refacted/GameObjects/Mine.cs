namespace Inheritance.MapObjects
{
    class Mine : IMapObject, IOwner, IArmy, ITreasure
    {
        public int Owner { get; set; }

        public Army Army { get; set; }

        public Treasure Treasure { get; set; }

        public void Make(Player player)
        {
            if (player.CanBeat(Army))
            {
                Owner = player.Id;
                player.Consume(Treasure);
            }
            else player.Die();
        }
    }
}

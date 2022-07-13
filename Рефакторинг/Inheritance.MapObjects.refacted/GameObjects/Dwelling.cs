namespace Inheritance.MapObjects
{
    class Dwelling : IMapObject, IOwner
    {
        public int Owner { get; set; }

        public void Make(Player player)
        {
            Owner = player.Id;
        }
    }
}

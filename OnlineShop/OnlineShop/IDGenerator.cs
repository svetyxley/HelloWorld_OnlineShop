namespace OnlineShop
{
    internal class IDGenerator
    {
        public int InputID<T>(List<T> items)
        {
            return items.Count() + 1;
        }
    }
}

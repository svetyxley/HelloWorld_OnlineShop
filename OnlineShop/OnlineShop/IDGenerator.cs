namespace OnlineShop
{
    public class IDGenerator
    {
        public Guid InputID<T>()
        {
            return Guid.NewGuid();
        }
    }
}

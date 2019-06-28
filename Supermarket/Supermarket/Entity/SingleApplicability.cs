namespace Supermarket.Entity
{
    public class SingleApplicability : IApplicability
    {
        public int GetApplicableSize()
        {
            return 1;
        }
    }
}
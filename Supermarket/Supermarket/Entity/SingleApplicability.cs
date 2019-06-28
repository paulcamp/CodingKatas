namespace Supermarket.Entity
{
    class SingleApplicability : IApplicability
    {
        public int GetApplicableSize()
        {
            return 1;
        }
    }
}
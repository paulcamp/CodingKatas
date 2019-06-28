namespace Supermarket.Entity
{
    class MultiApplicability : IApplicability
    {
        private readonly int _qualifier;

        public MultiApplicability(int qualifier)
        {
            _qualifier = qualifier;
        }
        public int GetApplicableSize()
        {
            return _qualifier;
        }
    }
}
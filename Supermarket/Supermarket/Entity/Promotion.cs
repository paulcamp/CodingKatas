namespace Supermarket.Entity
{
    public class Promotion
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IApplicability Applicability { get; set; }
        public IDiscount Discount { get; set; }

        public Promotion(string id, string description, IApplicability applicability, IDiscount discount)
        {
            Id = id;
            Description = description;
            Applicability = applicability;
            Discount = discount;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            
            var input = obj as Promotion;

            if (input == null)
                return false;

            return this.Id.Equals(input.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

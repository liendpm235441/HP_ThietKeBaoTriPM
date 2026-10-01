namespace SimplifyingConditionals_ConsolidateConditionalExpression
{
    public class Real
    {
        public bool IsEligibleForDiscount(decimal purchaseAmount, bool isMember, DateTime lastPurchaseDate)
        {
            bool largeOrder = purchaseAmount > 1000;
            bool isLoyalMember = isMember && (DateTime.Now - lastPurchaseDate).Days < 30;
            return largeOrder || isLoyalMember;
        }
    }
}


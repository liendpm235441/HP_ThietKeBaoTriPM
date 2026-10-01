namespace SimplifyingConditionalExpressions_RemoveControlFlag
{
    public class After
    {
        public double GetPayAmount()
        {
            if (isDead)
            {
                return DeadAmount();
            }
            if (isSeparated)
            {
                return SeparatedAmount();
            }
            if (isRetired)
            {
                return RetiredAmount();
            }
            return NormalPayAmount();
        }
    }
}

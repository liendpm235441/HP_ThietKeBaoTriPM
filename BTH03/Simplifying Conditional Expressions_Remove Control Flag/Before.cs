namespace SimplifyingConditionalExpressions_RemoveControlFlag
{
    public class Before
    {
        public double GetPayAmount()
        {
            double result;

            if (isDead)
            {
                result = DeadAmount();
            }
            else
            {
                if (isSeparated)
                {
                    result = SeparatedAmount();
                }
                else
                {
                    if (isRetired)
                    {
                        result = RetiredAmount();
                    }
                    else
                    {
                        result = NormalPayAmount();
                    }
                }
            }

            return result;
        }
    }
}

namespace SimplifyingConditionals_DecomposeConditional
{
    public class Real
    {
        public bool CanApplyForLoan(int creditScore, decimal monthlyIncome, int yearsEmployed)
        {
            bool hasGoodCredit = creditScore >= 650;
            bool hasSufficientIncome = monthlyIncome >= 3000;
            bool hasStableEmployment = yearsEmployed >= 2;

            bool meetsBasicRequirements = hasGoodCredit && hasSufficientIncome;
            bool isEligible = meetsBasicRequirements && hasStableEmployment;

            return isEligible;
        }
    }
}


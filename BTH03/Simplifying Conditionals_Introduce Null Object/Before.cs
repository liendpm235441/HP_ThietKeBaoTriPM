namespace SimplifyingConditionals_IntroduceNullObject
{
    public class Before
    {
        if (customer == null) 
{
  plan = BillingPlan.Basic();
}
else 
{
  plan = customer.GetPlan();
}
    }
}


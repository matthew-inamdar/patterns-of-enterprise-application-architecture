using System;

namespace patterns_of_enterprise_application_architecture.DomainModel
{
    public class RevenueRecognition
    {
        private int amount;
        private DateTime date;
        
        public RevenueRecognition(int amount, DateTime date)
        {
            this.amount = amount;
            this.date = date;
        }

        public int GetAmount()
        {
            return amount;
        }

        public bool IsRecognisableBy(DateTime asOf)
        {
            return asOf >= date;
        }
    }
}

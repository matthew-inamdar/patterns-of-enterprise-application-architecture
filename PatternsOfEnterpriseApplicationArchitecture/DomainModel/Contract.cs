using System;
using System.Collections.Generic;

namespace patterns_of_enterprise_application_architecture.DomainModel
{
    public class Contract
    {
        private readonly Product product;
        private readonly int revenue;
        private readonly DateTime whenSigned;
        private readonly List<RevenueRecognition> revenueRecognitions;

        public Contract(Product product, int revenue, DateTime whenSigned)
        {
            this.product = product;
            this.revenue = revenue;
            this.whenSigned = whenSigned;
            revenueRecognitions = new List<RevenueRecognition>();
        }

        public int GetRevenue()
        {
            return revenue;
        }

        public DateTime GetWhenSigned()
        {
            return whenSigned;
        }

        public void CalculateRecognitions()
        {
            product.CalculateRevenueRecognitions(this);
        }

        public void AddRevenueRecognition(RevenueRecognition revenueRecognition)
        {
            revenueRecognitions.Add(revenueRecognition);
        }

        public int RecognisedRevenue(DateTime asOf)
        {
            int result = 0;

            revenueRecognitions.ForEach((revenueRecognition) => {
                if (revenueRecognition.IsRecognisableBy(asOf))
                {
                    result += revenueRecognition.GetAmount();
                }
            });

            return result;
        }
    }
}

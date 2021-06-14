namespace patterns_of_enterprise_application_architecture.DomainModel
{
    public class ThreeWayRecognitionStrategy: RecognitionStrategy
    {
        private readonly int firstRecognitionOffset;
        private readonly int secondRecognitionOffset;

        public ThreeWayRecognitionStrategy(
            int firstRecognitionOffset,
            int secondRecognitionOffset
        ) {
            this.firstRecognitionOffset = firstRecognitionOffset;
            this.secondRecognitionOffset = secondRecognitionOffset;
        }

        public void CalculateRevenueRecognitions(Contract contract)
        {
            contract.AddRevenueRecognition(
                new RevenueRecognition(
                    StandardRevenueAmount(contract),
                    contract.GetWhenSigned()
                )
            );

            contract.AddRevenueRecognition(
                new RevenueRecognition(
                    StandardRevenueAmount(contract),
                    contract.GetWhenSigned().AddDays(firstRecognitionOffset)
                )
            );

            contract.AddRevenueRecognition(
                new RevenueRecognition(
                    FinalRevenueAmount(contract),
                    contract.GetWhenSigned().AddDays(secondRecognitionOffset)
                )
            );
        }

        private static int StandardRevenueAmount(Contract contract)
        {
            return contract.GetRevenue() / 3;
        }

        private static int FinalRevenueAmount(Contract contract)
        {
            return contract.GetRevenue() - (StandardRevenueAmount(contract) * 2);
        }
    }
}

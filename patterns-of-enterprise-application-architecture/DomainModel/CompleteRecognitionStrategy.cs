namespace patterns_of_enterprise_application_architecture.DomainModel
{
    public class CompleteRecognitionStrategy: RecognitionStrategy
    {
        public CompleteRecognitionStrategy()
        {
        }

        public void CalculateRevenueRecognitions(Contract contract)
        {
            contract.AddRevenueRecognition(
                new RevenueRecognition(
                    contract.GetRevenue(),
                    contract.GetWhenSigned()
                )
            );
        }
    }
}

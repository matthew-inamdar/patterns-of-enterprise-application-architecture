namespace patterns_of_enterprise_application_architecture.DomainModel
{
    public class Product
    {
        private string name;
        private RecognitionStrategy recognitionStrategy;

        private Product(string name, RecognitionStrategy recognitionStrategy)
        {
            this.name = name;
            this.recognitionStrategy = recognitionStrategy;
        }

        public static Product NewWordProcessor(string name)
        {
            return new Product(name, new CompleteRecognitionStrategy());
        }

        public static Product NewSpreadsheet(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(60, 90));
        }

        public static Product NewDatabase(string name)
        {
            return new Product(name, new ThreeWayRecognitionStrategy(30, 60));
        }

        public void CalculateRevenueRecognitions(Contract contract)
        {
            recognitionStrategy.CalculateRevenueRecognitions(contract);
        }
    }
}

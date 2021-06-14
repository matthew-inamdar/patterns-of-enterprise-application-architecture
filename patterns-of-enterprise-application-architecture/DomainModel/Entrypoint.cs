using System;

namespace patterns_of_enterprise_application_architecture.DomainModel
{
    public class Entrypoint
    {
        public static void Run()
        {
            Console.WriteLine("Domain Model entrypoint!");

            RunDomainModel();
        }

        private static void RunDomainModel()
        {
            Product wordProcessorProduct = Product.NewWordProcessor(
                "Thinking Word"
            );
            Contract wordProcessorContract = new Contract(
                wordProcessorProduct,
                350,
                new DateTime(2021, 7, 14)
            );
            wordProcessorContract.CalculateRecognitions();
            int wordProcessorRecognisedRevenue = wordProcessorContract.RecognisedRevenue(
                new DateTime(2021, 7, 14)
            );
            Console.WriteLine($"Word Processor revenue: {wordProcessorRecognisedRevenue}");
        }
    }
}

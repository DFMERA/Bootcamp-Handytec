using System;
using ConsoleAppML1ML.Model;
using Microsoft.ML;

namespace ConsoleAppML1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string opcion = "1";
            while (opcion != "0")
            {
                Console.Write("Texto: ");
                string texto = Console.ReadLine();
                Console.Write("Negativo?: ");
                string etiqueta = Console.ReadLine();

                ModelInput sampleData = CreateSingleDataSample(texto, Convert.ToBoolean(etiqueta));

                // Make a single prediction on the sample data and print results
                var result = ConsumeModel.Predict(sampleData);

                Console.WriteLine("Using model to make single prediction -- Comparing actual Sentiment with predicted Sentiment from sample data...\n\n");
                Console.WriteLine($"SentimentText: {sampleData.SentimentText}");
                Console.WriteLine($"\n\nActual Sentiment: {sampleData.Sentiment} \nPredicted Sentiment: {result.Prediction}\n\n");
                Console.WriteLine("=============== End of process, hit any key to finish ===============");
                opcion = Console.ReadLine();
            }
        }

        private static ModelInput CreateSingleDataSample(string text, bool label)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            ModelInput sampleForPrediction = new ModelInput()
            {
                SentimentText = text,
                Sentiment = label
            };

            return sampleForPrediction;
        }
    }
}

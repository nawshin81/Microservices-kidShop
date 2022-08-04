using Newtonsoft.Json;
using RatingService.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RatingService
{
    public class RatingRepository
    {
        HttpClientHandler clientHandler = new HttpClientHandler();

        public RatingRepository()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>{ return true; };
        }
        
        private List<Rating> LoadData()
        {
            var dataString = File.ReadAllText("F:\\3-2\\SWE 4601(Software Design and Architecture)\\assignment 3\\Microservices-kidShop\\RatingService\\Data\\rating.json");
            return JsonConvert.DeserializeObject<List<Rating>>(dataString);
        }

        private void SaveData(List<Rating> data)
        {
            var dataString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("F:\\3-2\\SWE 4601(Software Design and Architecture)\\assignment 3\\Microservices-kidShop\\RatingService\\Data\\rating.json", dataString);
        }

        internal IEnumerable<Rating> RetrieveAll()
        {
            return LoadData();
        }

        internal void CreateRating(Rating rate)
        {
            var allRates = LoadData();
            Console.WriteLine("New Rating");
            rate.Id = Guid.NewGuid();
            allRates.Add(rate);
            SaveData(allRates);
            UpdateProductRating();
        }
        internal void UpdateRate(Rating rate)
        {
            var allRates = LoadData();
            var findRate = allRates.Find(c => c.productId == rate.productId && c.raterId == rate.raterId);
            Console.WriteLine("Update Rating");
            findRate.rating = rate.rating;
            SaveData(allRates);
        }

        private async void UpdateProductRating()
        {
            var allRates = LoadData();
            var Datalength = allRates.Count;
            if (Datalength % 5 == 0)
            {
                Guid[] allProducts= new Guid[Datalength];
                for (int index=0;index< Datalength; index++)
                {
                    allProducts[index] = allRates[index].productId;
                }
                var uniqueProduct = allProducts.Distinct().ToArray();
                foreach (Guid id in uniqueProduct)
                {
                    var singleProductRate = allRates.FindAll(c => c.productId == id);
                    var totalSingleProductRate = singleProductRate.Count;
                    float totalRating = 0;
                    foreach (var x in singleProductRate)
                    {
                        totalRating = totalRating + x.rating;
                    }
                    float avgRating = totalRating / totalSingleProductRate;
                    var ratingUpdate = new { productId = id, averageRating = avgRating, numberOfRaters = totalSingleProductRate };
                    var result = JsonConvert.SerializeObject(ratingUpdate, Formatting.Indented);
                    using(var httpClient =new HttpClient(clientHandler, false))
                    {
                        StringContent content = new StringContent(result, Encoding.UTF8, "application/json");
                        using (var response = await httpClient.PutAsync("http://localhost:3005/product/updateRating", content))
                        {
                            String apiResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(apiResponse);
                        }
                    }

                }
            }
        }
    }
}

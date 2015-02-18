using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhoneBookClientConsoleV1
{
    class Program
    {
        static async Task RunPhonebook()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:19186/");

                    // Accept JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET ../phonebook/name/Jane Doe
                    HttpResponseMessage response = await client.GetAsync("phonebook/name/Jane Doe");
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            var entries = await response.Content.ReadAsAsync<IEnumerable<PhonebookRow>>();
                            foreach (var entry in entries)
                                {
                                    Console.WriteLine(entry.Name + " " + entry.Address + " " + entry.Number);
                                }
                        }
                            
                        else
                        {
                            Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);

                        }


                        response = await client.GetAsync("phonebook/number/0860889861");
                        if(response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsAsync<PhonebookRow>();
                            Console.WriteLine(result.Name + " " + result.Address + " " + result.Number);
                        }
                        else
                        {
                            Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);

                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception " + e.StackTrace);
            }
        }

        public static void Main()
        {
            RunPhonebook().Wait();
            Console.WriteLine("Press Any Key to Exit");
            Console.ReadKey();
        }
    }
}

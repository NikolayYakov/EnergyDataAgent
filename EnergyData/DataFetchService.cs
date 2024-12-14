using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using System.Text.Json;

namespace EnergyData
{
    public class DataFetchService : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public static  ConcurrentDictionary<string, EnergyInfo> DataDictionary = new();
        public static  ConcurrentDictionary<string, string> StateDictionary = new();
        public static  ConcurrentBag<string> Years = new();
        public static bool IsInitialized = false;


        public DataFetchService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await FetchAndCacheData();
                await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
            }
        }

        private async Task FetchAndCacheData()
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://api.eia.gov/v2/electricity/state-electricity-profiles/source-disposition/data/?frequency=annual&data[0]=combined-heat-and-pwr-comm&data[1]=combined-heat-and-pwr-elect&data[2]=combined-heat-and-pwr-indust&data[3]=direct-use&data[4]=elect-pwr-sector-gen-subtotal&data[5]=electric-utilities&data[6]=energy-only-providers&data[7]=estimated-losses&data[8]=facility-direct&data[9]=full-service-providers&data[10]=independent-power-producers&data[11]=indust-and-comm-gen-subtotal&data[12]=net-interstate-trade&data[13]=net-trade-index&data[14]=total-disposition&data[15]=total-elect-indust&data[16]=total-international-exports&data[17]=total-international-imports&data[18]=total-net-generation&data[19]=total-supply&data[20]=unaccounted&sort[0][column]=period&sort[0][direction]=desc&offset=0&api_key=";

            try
            {
                var response = await client.GetStringAsync(apiUrl);
                var energyDataResponse = JsonSerializer.Deserialize<ApiResponse>(response);
                if (energyDataResponse?.Response.Data != null)
                {
                    foreach (var energyData in energyDataResponse.Response.Data)
                    {
                        var cacheKey = $"{energyData.State}-{energyData.Period}";

                        DataDictionary[cacheKey] = energyData;
                    }
                    GetUniqueYears(energyDataResponse);
                    GetStateDictionary(energyDataResponse);
                    IsInitialized = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
        }

        public static void GetUniqueYears(ApiResponse apiResponse)
        {
            Years = new ConcurrentBag<string>(
     apiResponse.Response.Data.Select(d => d.Period).Distinct()
 );
        }

        public static void GetStateDictionary(ApiResponse apiResponse)
        {
            foreach (var item in apiResponse.Response.Data)
            {
                StateDictionary[item.State] = item.StateDescription;
            }
        }
    }

    public class EnergyDataResponse
    {
        public List<EnergyInfo> Data { get; set; }
    }
}

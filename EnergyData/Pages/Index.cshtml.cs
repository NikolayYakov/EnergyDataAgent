using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace EnergyData.Pages
{
    public class IndexModel : PageModel
    {
        public EnergyInfo EnergyInfo { get; set; }
        public Dictionary<string, string> States = new();
        public List<string> Years = new();

        [BindProperty(SupportsGet = true)]
        public string SelectedYear { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedState { get; set; }

        public IndexModel()
        {
        }

        public async Task OnGetAsync()
        {
            while (!DataFetchService.IsInitialized)
            {
                await Task.Delay(25);
            }

            Years = DataFetchService.Years.ToList();
            States = DataFetchService.StateDictionary.ToDictionary();

            if (!string.IsNullOrEmpty(SelectedState) && !string.IsNullOrEmpty(SelectedYear))
            {
                var key = $"{SelectedState}-{SelectedYear}";

                if (DataFetchService.DataDictionary.ContainsKey(key))
                {
                    EnergyInfo = DataFetchService.DataDictionary[key];
                }
            }
        }
    }
}

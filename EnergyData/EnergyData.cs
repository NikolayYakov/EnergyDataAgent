using System.Text.Json.Serialization;

namespace EnergyData
{
    public class EnergyInfo
    {
        [JsonPropertyName("period")]
        public string Period { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("stateDescription")]
        public string StateDescription { get; set; }

        [JsonPropertyName("combined-heat-and-pwr-comm")]
        public string CombinedHeatAndPwrComm { get; set; }

        [JsonPropertyName("combined-heat-and-pwr-elect")]
        public string CombinedHeatAndPwrElect { get; set; }

        [JsonPropertyName("combined-heat-and-pwr-indust")]
        public string CombinedHeatAndPwrIndust { get; set; }

        [JsonPropertyName("direct-use")]
        public string DirectUse { get; set; }

        [JsonPropertyName("elect-pwr-sector-gen-subtotal")]
        public string ElectPwrSectorGenSubtotal { get; set; }

        [JsonPropertyName("electric-utilities")]
        public string ElectricUtilities { get; set; }

        [JsonPropertyName("energy-only-providers")]
        public string EnergyOnlyProviders { get; set; }

        [JsonPropertyName("estimated-losses")]
        public string EstimatedLosses { get; set; }

        [JsonPropertyName("facility-direct")]
        public string FacilityDirect { get; set; }

        [JsonPropertyName("full-service-providers")]
        public string FullServiceProviders { get; set; }

        [JsonPropertyName("independent-power-producers")]
        public string IndependentPowerProducers { get; set; }

        [JsonPropertyName("indust-and-comm-gen-subtotal")]
        public string IndustAndCommGenSubtotal { get; set; }

        [JsonPropertyName("net-interstate-trade")]
        public string NetInterstateTrade { get; set; }

        [JsonPropertyName("net-trade-index")]
        public string NetTradeIndex { get; set; }

        [JsonPropertyName("total-disposition")]
        public string TotalDisposition { get; set; }

        [JsonPropertyName("total-elect-indust")]
        public string TotalElectIndust { get; set; }

        [JsonPropertyName("total-international-exports")]
        public string TotalInternationalExports { get; set; }

        [JsonPropertyName("total-international-imports")]
        public string TotalInternationalImports { get; set; }

        [JsonPropertyName("total-net-generation")]
        public string TotalNetGeneration { get; set; }

        [JsonPropertyName("total-supply")]
        public string TotalSupply { get; set; }

        [JsonPropertyName("unaccounted")]
        public string Unaccounted { get; set; }

        [JsonPropertyName("combined-heat-and-pwr-comm-units")]
        public string CombinedHeatAndPwrCommUnits { get; set; }

        [JsonPropertyName("combined-heat-and-pwr-elect-units")]
        public string CombinedHeatAndPwrElectUnits { get; set; }

        [JsonPropertyName("combined-heat-and-pwr-indust-units")]
        public string CombinedHeatAndPwrIndustUnits { get; set; }

        [JsonPropertyName("direct-use-units")]
        public string DirectUseUnits { get; set; }

        [JsonPropertyName("elect-pwr-sector-gen-subtotal-units")]
        public string ElectPwrSectorGenSubtotalUnits { get; set; }

        [JsonPropertyName("electric-utilities-units")]
        public string ElectricUtilitiesUnits { get; set; }

        [JsonPropertyName("energy-only-providers-units")]
        public string EnergyOnlyProvidersUnits { get; set; }

        [JsonPropertyName("estimated-losses-units")]
        public string EstimatedLossesUnits { get; set; }

        [JsonPropertyName("facility-direct-units")]
        public string FacilityDirectUnits { get; set; }

        [JsonPropertyName("full-service-providers-units")]
        public string FullServiceProvidersUnits { get; set; }

        [JsonPropertyName("independent-power-producers-units")]
        public string IndependentPowerProducersUnits { get; set; }

        [JsonPropertyName("indust-and-comm-gen-subtotal-units")]
        public string IndustAndCommGenSubtotalUnits { get; set; }

        [JsonPropertyName("net-interstate-trade-units")]
        public string NetInterstateTradeUnits { get; set; }

        [JsonPropertyName("net-trade-index-units")]
        public string NetTradeIndexUnits { get; set; }

        [JsonPropertyName("total-disposition-units")]
        public string TotalDispositionUnits { get; set; }

        [JsonPropertyName("total-elect-indust-units")]
        public string TotalElectIndustUnits { get; set; }

        [JsonPropertyName("total-international-exports-units")]
        public string TotalInternationalExportsUnits { get; set; }

        [JsonPropertyName("total-international-imports-units")]
        public string TotalInternationalImportsUnits { get; set; }

        [JsonPropertyName("total-net-generation-units")]
        public string TotalNetGenerationUnits { get; set; }

        [JsonPropertyName("total-supply-units")]
        public string TotalSupplyUnits { get; set; }

        [JsonPropertyName("unaccounted-units")]
        public string UnaccountedUnits { get; set; }

        // Mapping property names to human-readable names
        // Mapping property names to human-readable names
        public static Dictionary<string, string> PropertyDescriptions = new Dictionary<string, string>
    {
        { "Period", "Period" },
        { "State", "State" },
        { "StateDescription", "State Description" },
        { "CombinedHeatAndPwrComm", "Combined Heat and Power (Commercial)" },
        { "CombinedHeatAndPwrElect", "Combined Heat and Power (Electric)" },
        { "CombinedHeatAndPwrIndust", "Combined Heat and Power (Industrial)" },
        { "DirectUse", "Direct Use" },
        { "ElectPwrSectorGenSubtotal", "Electric Power Sector Generation Subtotal" },
        { "ElectricUtilities", "Electric Utilities" },
        { "EnergyOnlyProviders", "Energy Only Providers" },
        { "EstimatedLosses", "Estimated Losses" },
        { "FullServiceProviders", "Full Service Providers" },
        { "IndependentPowerProducers", "Independent Power Producers" },
        { "IndustAndCommGenSubtotal", "Industrial and Commercial Generation Subtotal" },
        { "NetInterstateTrade", "Net Interstate Trade" },
        { "NetTradeIndex", "Net Trade Index" },
        { "TotalDisposition", "Total Disposition" },
        { "TotalElectIndust", "Total Electric Industry" },
        { "TotalInternationalExports", "Total International Exports" },
        { "TotalInternationalImports", "Total International Imports" },
        { "TotalNetGeneration", "Total Net Generation" },
        { "TotalSupply", "Total Supply" },
        { "Unaccounted", "Unaccounted" }
    };
    }


    public class ApiResponse
    {
        [JsonPropertyName("response")]
        public ApiResponseData Response { get; set; }
    }

    public class ApiResponseData
    {
        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("dateFormat")]
        public string DateFormat { get; set; }

        [JsonPropertyName("frequency")]
        public string Frequency { get; set; }

        [JsonPropertyName("data")]
        public List<EnergyInfo> Data { get; set; }
    }
}

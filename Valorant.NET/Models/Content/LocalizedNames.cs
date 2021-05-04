using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Valorant.NET.Models.Content
{
    [ExcludeFromCodeCoverage]
    public class LocalizedNames
    {
        [JsonProperty("ar-AE")]
        public string ArAE { get; set; }

        [JsonProperty("de-DE")]
        public string DeDE { get; set; }

        [JsonProperty("en-GB")]
        public string EnGB { get; set; }

        [JsonProperty("en-US")]
        public string EnUS { get; set; }

        [JsonProperty("es-ES")]
        public string EsES { get; set; }

        [JsonProperty("es-MX")]
        public string EsMX { get; set; }

        [JsonProperty("fr-FR")]
        public string FrFR { get; set; }

        [JsonProperty("id-ID")]
        public string IdID { get; set; }

        [JsonProperty("it-IT")]
        public string ItIT { get; set; }

        [JsonProperty("ja-JP")]
        public string JaJP { get; set; }

        [JsonProperty("ko-KR")]
        public string KoKR { get; set; }

        [JsonProperty("pl-PL")]
        public string PlPL { get; set; }

        [JsonProperty("pt-BR")]
        public string PtBR { get; set; }

        [JsonProperty("ru-RU")]
        public string RuRU { get; set; }

        [JsonProperty("th-TH")]
        public string ThTH { get; set; }

        [JsonProperty("tr-TR")]
        public string TrTR { get; set; }

        [JsonProperty("vi-VN")]
        public string ViVN { get; set; }

        [JsonProperty("zh-CN")]
        public string ZhCN { get; set; }

        [JsonProperty("zh-TW")]
        public string ZhTW { get; set; }
    }
}

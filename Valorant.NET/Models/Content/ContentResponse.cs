using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Valorant.NET.Models.Content
{
    [ExcludeFromCodeCoverage]
    public class ContentResponse
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("characters")]
        public List<Character> Characters { get; set; }

        [JsonProperty("maps")]
        public List<Map> Maps { get; set; }

        [JsonProperty("chromas")]
        public List<Chroma> Chromas { get; set; }

        [JsonProperty("skins")]
        public List<Skin> Skins { get; set; }

        [JsonProperty("skinLevels")]
        public List<SkinLevel> SkinLevels { get; set; }

        [JsonProperty("equips")]
        public List<Equip> Equips { get; set; }

        [JsonProperty("gameModes")]
        public List<GameMode> GameModes { get; set; }

        [JsonProperty("sprays")]
        public List<Spray> Sprays { get; set; }

        [JsonProperty("sprayLevels")]
        public List<SprayLevel> SprayLevels { get; set; }

        [JsonProperty("charms")]
        public List<Charm> Charms { get; set; }

        [JsonProperty("charmLevels")]
        public List<CharmLevel> CharmLevels { get; set; }

        [JsonProperty("playerCards")]
        public List<PlayerCard> PlayerCards { get; set; }

        [JsonProperty("playerTitles")]
        public List<PlayerTitle> PlayerTitles { get; set; }

        [JsonProperty("acts")]
        public List<Act> Acts { get; set; }
    }
}

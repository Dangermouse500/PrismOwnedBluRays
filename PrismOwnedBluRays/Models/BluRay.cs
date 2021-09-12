using Newtonsoft.Json;
using SQLite;
using System;

namespace PrismOwnedBluRays.Models
{
    [Serializable]
    public class BluRay
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int BluRayId { get; set; }
        [JsonProperty("Title")]
        public string BluRayTitle { get; set; }
        [JsonProperty("Director")]
        public string BluRayDirector { get; set; }
        [JsonProperty("Actors")]
        public string BluRayActors { get; set; }
        [JsonProperty("Genre")]
        public string BluRayGenre { get; set; }
        [JsonProperty("Year")]
        public string BluRayYearOfRelease { get; set; }
        #endregion
    }
}

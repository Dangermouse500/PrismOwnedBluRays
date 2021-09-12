﻿using SQLite;

namespace PrismOwnedBluRays.AndroidProject.Models
{
    public class BluRay
    {
        #region Properties
        [PrimaryKey, AutoIncrement]
        public int BluRayId { get; set; }
        public string BluRayTitle { get; set; }
        public string BluRayDirector { get; set; }
        public string BluRayActors { get; set; }
        public string BluRayGenre { get; set; }
        public string BluRayYearOfRelease { get; set; }
        #endregion
    }
}
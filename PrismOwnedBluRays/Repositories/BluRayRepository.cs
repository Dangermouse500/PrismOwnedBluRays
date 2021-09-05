using PrismOwnedBluRays.Models;
using System.Collections.Generic;

namespace PrismOwnedBluRays.Repositories
{
    public class BluRayRepository : IBluRayRepository
    {
        public List<BluRay> GetOwnedBluRays()
        {
            var listOfOwnedBluRays = new List<BluRay>();

            listOfOwnedBluRays.Add(new BluRay
            {
                BluRayId = 1,
                BluRayTitle = "Batman", BluRayActors = "Michael Keaton, Jack Nicholson", BluRayDirector = "Tim Burton", BluRayGenre = "Action", BluRayYearOfRelease = "1989"
            });

            listOfOwnedBluRays.Add(new BluRay
            {
                BluRayId = 2,
                BluRayTitle = "Transformers",
                BluRayActors = "Megan Fox, Shia LeBouf",
                BluRayDirector = "Michael Bay",
                BluRayGenre = "Action",
                BluRayYearOfRelease = "2001"
            });

            return listOfOwnedBluRays;
        }
    }
}
using PrismOwnedBluRays.Models;
using System.Collections.Generic;

namespace PrismOwnedBluRays.Repositories
{
    public interface IBluRayRepository
    {
        List<BluRay> GetOwnedBluRays();
    }
}
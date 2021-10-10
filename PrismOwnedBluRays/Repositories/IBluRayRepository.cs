using PrismOwnedBluRays.Models;
using System.Collections.Generic;

namespace PrismOwnedBluRays.Repositories
{
    public interface IBluRayRepository
    {
        List<BluRay> GetOwnedBluRays();
        BluRay GetBluRayDetailsById(int bluRayId);
        void AddBluRay(BluRay bluRay);
        void DeleteBluRay(BluRay bluRay);
    }
}
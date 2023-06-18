using System.Collections.Generic;
using System.Threading.Tasks;
using KTHotel.Api.Models;

namespace KTHotel.Api.Data
{
    public interface IProfilesRepository
    {
        Task<IEnumerable<Profile>> GetAllAsync();

        Task<Profile> GetAsync(int profileId);

        Task AddAsync(Profile newProfile);

        void Update(Profile profile);

        void Remove(int profileId);
    }
}
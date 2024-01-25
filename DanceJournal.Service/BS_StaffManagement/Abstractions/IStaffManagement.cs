using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Services.BS_StaffManagement.Abstractions
{
    public interface IStaffManagement
    {
        Task<List<User>> GetAllStaffAsync(CancellationToken cancellationToken);
        Task<User> GetStaffByIdAsync(int userId, CancellationToken cancellationToken);
        Task<User> ChangeLevelUserAsync(int userId, int levelId, CancellationToken cancellationToken);
    }
}

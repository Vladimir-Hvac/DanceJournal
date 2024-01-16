using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Service.BS_StaffManagement.Abstractions
{
    public interface IStaffManagement
    {
        public Task<List<User>> GetAllStaffAsync();
        public Task<User> GetStaffByIdAsync(int userId);
        public Task<User> ChangeLevelUserAsync(int userId,int levelId);

    }
}

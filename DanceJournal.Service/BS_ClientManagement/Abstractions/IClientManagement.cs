using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceJournal.Services.BS_ClientManagement.Abstractions
{
    public interface IClientManagement
    {
        public Task<List<User>> GetAllClientsAsync();
        public Task<User> GetClientByIdAsync(int userId);
        // public Task<User> CreateClientAsync();
        // public Task<User> UpdateClientAsync();
        //public Task<bool> DeleteClientAsync();
    }
}

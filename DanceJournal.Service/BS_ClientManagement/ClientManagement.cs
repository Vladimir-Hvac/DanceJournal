//using DanceJournal.Domain.BS_ClientManagement.Abstractions;
//using Microsoft.EntityFrameworkCore;

//namespace DanceJournal.Domain.BS_ClientManagement
//{
//    public class ClientManagement : IClientManagement
//    {
//        private DanceJournalDbContext _dbContext;
//        private readonly int _roleClient;

//        public ClientManagement(DanceJournalDbContext dbContext)
//        {
//            _dbContext = dbContext;
//            _roleClient = 1;
//        }

//        public async Task<List<User>> GetAllClientsAsync()
//        {
//            var clients = await _dbContext.Users.Where(item => item.RoleId == 1).ToListAsync();
//            return clients;
//        }
//        public async Task<User> GetClientByIdAsync(int userId)
//        {
//            var client = await _dbContext.Users.Where(item => item.RoleId == _roleClient & item.Id == userId).FirstAsync();
//            if (client == null)
//            {
//                throw new Exception("По переданному id не найден пользователь");
//            }
//            return client;
//        }
//        //public async Task<List<User>> UpdateClientAsync()  {}
//        //public Task<List<User>> DeleteClientAsync();
//        //public async Task<User> CreateClientAsync(User user)
//        //{
//        //   var s = _dbContext.Add(user);
//        //   await _dbContext.SaveChangesAsync();
//        //  if (s != null)
//        // {
//        //    return s.;
//        //  }
//        // }
//    }
//}

//using Microsoft.EntityFrameworkCore;
//using ShopsRUs.Contracts;
//using ShopsRUs.Data;
//using ShopsRUs.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ShopsRUs.Repositories
//{
//    public class UserRepository : RepositoryBase<Users>, IUserRepository
//    {
//        public UserRepository(ApplicationContext context):base(context) {  }
//        public void CreateUser(Users user, string userType)
//        {
//            user.UserType = userType;
//            Create(user); 
//        }

//        public async Task<Users> GetUserById(int userId, bool trackChanges) =>
//            await FindByCondition(u => u.UserId.Equals(userId), trackChanges).SingleOrDefaultAsync();

//        public async Task<IEnumerable<Users>> GetAllCustomers(bool trackChanges) =>
//          await FindByCondition(u => u.UserType.Equals("Customer"), trackChanges).ToListAsync();

//        public async Task<Users> GetCustomerById(int customerId, bool trackChanges) =>
//            await FindByCondition(c => c.UserId.Equals(customerId) 
//            && c.UserType.Equals("Customer"), trackChanges).SingleOrDefaultAsync();


//        public async Task<Users> GetCustomersByName(string name, bool trackChanges) =>
//            await FindByCondition(c => c.LastName.Trim().ToLower().Contains(name) ||
//            c.MiddleName.Trim().ToLower().Contains(name) ||
//            c.FirstName.Trim().ToLower().Contains(name)
//            && c.UserType.Equals("Customer"), trackChanges).SingleOrDefaultAsync();


//    }
//}

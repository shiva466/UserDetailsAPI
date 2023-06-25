using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsDesktop.DbConnection;
using UserDetailsDesktop.Models;

namespace UserDetailsDesktop.Services
{
    public class UserService : IUserService
    {
        private MyDbContext _dbContext;

        public UserService(MyDbContext context)
        {
            _dbContext = context;
        }
        public List<User> GetAll()
        {
            var users =  _dbContext.User.ToList();
            return users.FindAll(x => x.IsActive == 1);
        }
        public User GetById(int id)
        {
            return _dbContext.User.Find(id);
        }
        public void Add(User user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }
        public void Update(User user)
        {
            _dbContext.User.Update(user);
            _dbContext.SaveChanges();
        }
    }
}

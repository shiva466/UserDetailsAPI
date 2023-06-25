using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDetailsDesktop.Models;

namespace UserDetailsDesktop.Services
{
    public interface IUserService
    {
        public List<User> GetAll();
        public User GetById(int id);
        public void Add(User user);
        public void Update(User user);
    }
}

using Model;
using Repository.Entitiy;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> Repository;

        public UserService(IRepositoryBase<User> repositoryBase)
        {
            Repository = repositoryBase;
        }

        public User Create(User user)
        {
            return Repository.Create(user);
        }

        public bool Delete(Guid id)
        {
            var user = Get(id);

            if (user != null)
            {
                var result = Repository.Delete(user);
                return true;
            }
            return false;
        }

        public User Get(Guid id)
        {
            var result = Repository.Get(x => x.Id == id);
            return result.FirstOrDefault();
        }

        public IList<User> GetAllUser()
        {
            return Repository.GetAll().ToList();
        }

        public User Update(Guid id, User updateUser)
        {
            var user = Get(id);

            if (user != null)
            {
                return Repository.Update(updateUser);
            }
            return null;
        }
    }
}

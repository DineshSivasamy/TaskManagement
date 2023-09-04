using Model;
using System;
using System.Collections.Generic;

namespace Services.Interface
{
    public interface IUserService
    {
        IList<User> GetAllUser();

        User Get(Guid id);

        User Create(User user);

        User Update(Guid id, User user);

        bool Delete(Guid id);
    }
}

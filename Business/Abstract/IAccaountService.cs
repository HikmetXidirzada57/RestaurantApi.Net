using Core.Entity.Models;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccaountService
    {
        void Register(RegisterDTO registerDTO);
        User Login(string email);
        List<User> GetAllUsers();
        User FindUserByEmail(string email);

    }
}

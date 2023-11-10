using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crudapp.Models;

namespace crudapp.Services
{
    public interface IJwtService
    {
         public string GenJwtToken(LoginModel user);
    }
}
using SynthFinManSystem.Model.Abstract;
using SynthFinManSystem.Model.Context;
using SynthFinManSystem.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthFinManSystem.Model.Business
{
    public class UserBusiness : IUserBusiness
    {

        private readonly AppDbContext _context;

        public UserBusiness(AppDbContext context)
        {
            _context = context;
        }

        public User FindUserByUserName(string username)
        {
            try
            {
                return _context.Users.Find(username);
            }
            catch (Exception exception)
            {
                throw;
            }
        }

    }
}

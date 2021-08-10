using SynthFinManSystem.Web.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynthFinManSystem.Model.Abstract;
using SynthFinManSystem.Model.Objects;
using SynthFinManSystem.Web.Objects;

namespace SynthFinManSystem.Web.Business
{
    public class AccountBusiness : IAccountBusiness
    {

        private readonly IUserBusiness _userBusiness;

        public AccountBusiness(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// Method to validate a user
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns>The validated user</returns>
        public User validateUser(string userName, string password)
        {
            try
            {
                User userVal = _userBusiness.FindUserByUserName(userName);
                if (userVal == null)
                {
                    userVal = new User {Valid = false};
                }
                else
                {
                    if (userVal.Password.Equals(password))
                    {
                        userVal.Valid = true;
                    }
                    else
                    {
                        userVal.Valid = false;
                    }
                }

                return userVal;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

    }
}

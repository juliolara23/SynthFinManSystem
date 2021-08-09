using SynthFinManSystem.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthFinManSystem.Model.Abstract
{
    public interface IUserBusiness
    {

        User FindUserByUserName(string username);

    }
}

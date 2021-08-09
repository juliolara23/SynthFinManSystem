using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SynthFinManSystem.Model.Objects;

namespace SynthFinManSystem.Web.Abstract
{
    public interface IAccountBusiness
    {

        User validateUser(string userName, string password);

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using SynthFinManSystem.Model.Abstract;
using SynthFinManSystem.Model.Objects;

namespace SynthFinManSystem.Web.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {

        private readonly ITransactionBusiness _transactionBusiness;

        public RegisterController(ITransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }

        [HttpPost]
        public virtual ActionResult SaveTransaction([FromBody] JObject data)
        {
            Transaction transaction = data["transaction"].ToObject<Transaction>();
            try
            {
                _transactionBusiness.SaveTransaction(transaction);
                return Ok(string.Empty);
            }
            catch (Exception exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

    }
}

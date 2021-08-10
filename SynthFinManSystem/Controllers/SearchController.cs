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
    public class SearchController : Controller
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public SearchController(ITransactionBusiness transactionBusiness)
        {
            _transactionBusiness = transactionBusiness;
        }

        /// <summary>
        /// Method to search a transaction marked as fraud
        /// </summary>
        /// <returns>Transactions list</returns>
        [HttpPost]
        public virtual ActionResult FindTransactionByUserIsFraud()
        {
            try
            {
                return Ok(_transactionBusiness.FindTransactionByUserIsFraud());
            }
            catch (Exception exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Method to search transactions by recipient name
        /// </summary>
        /// <param name="data">Recipient name</param>
        /// <returns>Transactions list</returns>
        [HttpPost]
        public virtual ActionResult FindTransactionByUserNameDest([FromBody] JObject data)
        {
            string nameDest = data["nameDest"].ToObject<string>();
            try
            {
                return Ok(_transactionBusiness.FindTransactionByUserNameDest(nameDest));
            }
            catch (Exception exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }


        /// <summary>
        /// Method to search transactions by date
        /// </summary>
        /// <param name="data">Transaction date</param>
        /// <returns>Transactions list</returns>
        [HttpPost]
        public virtual ActionResult FindTransactionByTransactionDate([FromBody] JObject data)
        {
            DateTimeOffset transactionDate = data["transactionDate"].ToObject<DateTimeOffset>();
            try
            {
                return Ok(_transactionBusiness.FindTransactionByTransactionDate(transactionDate));
            }
            catch (Exception exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Method to update a existing transaction
        /// </summary>
        /// <param name="data">Transaction</param>
        /// <returns>none</returns>
        [HttpPost]
        public virtual ActionResult UpdateTransaction([FromBody] JObject data)
        {
            Transaction transaction = data["transaction"].ToObject<Transaction>();
            try
            {
                _transactionBusiness.UpdateTransaction(transaction);
                return Ok(string.Empty);
            }
            catch (Exception exception)
            {
                return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
            }
        }
    }
}

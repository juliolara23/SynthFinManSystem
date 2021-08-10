using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SynthFinManSystem.Model.Objects;

namespace SynthFinManSystem.Model.Abstract
{
    public interface ITransactionBusiness
    {

        List<Transaction> FindTransactionByUserNameDest(string nameDest);

        List<Transaction> FindTransactionByUserIsFraud();

        List<Transaction> FindTransactionByTransactionDate(DateTimeOffset transactionDate);

        void SaveTransaction(Transaction transaction);

        void UpdateTransaction(Transaction transaction);

    }
}

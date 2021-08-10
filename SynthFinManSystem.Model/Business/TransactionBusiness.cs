using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SynthFinManSystem.Model.Abstract;
using SynthFinManSystem.Model.Context;
using SynthFinManSystem.Model.Objects;

namespace SynthFinManSystem.Model.Business
{
    public class TransactionBusiness : ITransactionBusiness
    {

        private readonly AppDbContext _context;

        public TransactionBusiness(AppDbContext context)
        {
            _context = context;
        }

        public List<Transaction> FindTransactionByUserNameDest(string nameDest)
        {
            try
            {
                return _context.Transactions.Where(x => x.NameDest.Trim().ToUpper().Contains(nameDest.Trim().ToUpper())).ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public List<Transaction> FindTransactionByUserIsFraud()
        {
            try
            {
                return _context.Transactions.Where(x => x.IsFraud).ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public List<Transaction> FindTransactionByTransactionDate(DateTimeOffset transactionDate)
        {
            try
            {
                return _context.Transactions.Where(x => x.TransactionDate.Date.Equals(transactionDate.Date)).ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void SaveTransaction(Transaction transaction)
        {
            try
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void UpdateTransaction(Transaction transaction)
        {
            try
            {
                _context.Set<Transaction>().Update(transaction);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

    }
}

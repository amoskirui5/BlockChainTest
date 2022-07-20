using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainTest
{
    public class Block
    {
        public int Id { get; set; }
        public List<Transaction>? Transactions { get; set; }

        public Block()
        {
            
        }

        public int getId()
        {
            return Id;
        }
        public List<Transaction> getTransactions()
        {
            return Transactions;
        }
        public int setId(int id)
        {
            return this.Id = id;
        }
        public bool validateTransaction(List<Transaction> transactions)
        {
            bool isValid = false;
            foreach (var item in transactions)
            {
                var transactionId=item.Id;
                var transactionType = item.Type;
                var transactionFrom = item.From;
                var transactionTo = item.To;
                var transactionAmount = item.Amount;
                var stringToBeHashed = string.Concat(transactionId,":", transactionType,":", transactionFrom,":",transactionTo,":",transactionAmount);

                var transactionSignature = CalculateHashMD5.CalculateMD5HashSignature(stringToBeHashed);
                if (item.Signature==transactionSignature)
                {
                    return isValid=true; ;
                }
                
            }
            return isValid;

        }
        public void addTransaction(List<Transaction>transactions)
        {
            if (validateTransaction(transactions) && transactions.Count<10)
            {
                foreach (var item in transactions)
                {
                    if (item.getId()==getId())
                    {
                        return;
                    }
                }
                this.Transactions=transactions;
            }
        }
    }
}

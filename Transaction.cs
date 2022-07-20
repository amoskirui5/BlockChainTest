using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainTest
{
    public class Transaction
    {
        const int money_emission = 0;
        const int money_transfer = 1;
        public int Id { get; set; }
        public int Type { get; set; }
        public string? From { get; set; }
        public string To { get; set; }
        public int Amount { get; set; }
        public string Signature { get; set; }
        public Transaction()
        {

        }
        public Transaction(int id,int type,string from,string to,int amount,string signature)
        {
            this.Id = id;
            this.Type = type;
            this.From = from;
            this.To=to;
            this.Amount = amount;
            this.Signature = signature;
        }
        public int getId() { 
            return Id;
        }
        public int getType() { 
        return Type;
        }
        public string getFrom()
        {
            return From;
        }
        public string getTo()
        {
            return To;
        }
        public int getAmount()
        {
            return Amount;
        }
        public string getSignature()
        {
            return Signature;
        }

        public int setId(int id) { 
            return this.Id = id;
        }
        public int setType(int type)
        {
            //Make sure type passed is valid
            if (type<0||type>1)
            {
                throw new Exception($"{type} is not a valid type");
            }
            if (type==money_emission)
            {
                this.From = null;
            }

            return this.Type = type;
        }
        public string setFrom(string sender)
        {
            if (Type==money_emission)
            {
                this.From = null;
            }
            if (sender == null|| sender.Length<2|| sender.Length>10)
            {
                throw new Exception("Sender length should be between 2 and 10");
            }
            return this.From = sender;
        } 
        public string setTo(string receiver)
        {
            if (receiver == From)
            {
                throw new Exception("Receiver cannot be the same as Sender");

            }
            if (receiver == null|| receiver.Length<2|| receiver.Length>10)
            {
                throw new Exception("Sender length should be between 2 and 10");
            }
            return this.To = receiver;
        }
        public int setAmount(int amount)
        {
            if (amount<0)
            {
                throw new Exception("Invalid amount!");

            }
            return this.Amount = amount;
        } 
        public string setSignature()
        {
            var stringToBeHashed = String.Concat(Id, ":", Type, ":", From, ":", To, ":", Amount);

            var hashedSignature = CalculateHashMD5.CalculateMD5HashSignature(stringToBeHashed);

            if (Signature.Length!=32)
            {
                throw new Exception("Invalid signature!,signature length should be 32 characters");

            }
            return this.Signature = hashedSignature;
        }

        


    }
}

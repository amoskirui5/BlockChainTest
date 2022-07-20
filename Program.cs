using System;

namespace BlockChainTest // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // create 100 coins and transfer them to Bob
            Transaction trx = new Transaction();
            List<Transaction> trx1 = new List<Transaction>();
            trx1.Add(new Transaction(trx.setId(1),
            trx.setType(0),
            trx.setFrom(null),
            trx.setTo("bob"),
            trx.setAmount(100),
            trx.setSignature()));
            Block block = new Block();
            block.setId(1);
            block.addTransaction(trx1);
            BlockChain blockChain = new BlockChain();
            blockChain.addBlock(null, block);

            // bob transfers 50 coins to alice
            Transaction trx2 = new Transaction();
            List<Transaction> trx3 = new List<Transaction>();
            trx3.Add(new Transaction(trx.setId(2),
            trx.setType(1),
            trx.setFrom("bob"),
            trx.setTo("alice"),
            trx.setAmount(50),
            trx.setSignature()));
            Block block1 = new Block();
            block1.setId(2);
            block.addTransaction(trx1);
            BlockChain blockChain1 = new BlockChain();
            blockChain.addBlock(null, block1);
            
            blockChain.addBlock(1, block);
            blockChain.getBalance("alice"); // should return 50
            blockChain.getBalance("bob"); // should return 50
        }
        
    }
}
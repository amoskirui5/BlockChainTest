using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainTest
{
    public class BlockChain
    {
        public List<Block> blocks { get; set; }

        public BlockChain( )
        {
            
        }

        public List<Block> getBlockChain()
        {
            List<Block> chains = new List<Block>();
            foreach (var item in blocks)
            {
                if (blocks == chains)
                {
                    blocks.Add(item);

                }
            }
            return this.blocks;
        }
        public  bool validateBlock(Block block)
        {
            if (block.getTransactions().Count<1)
            {
                return false;
            }
            foreach (var item in blocks)
            {
                if (item.getId()==block.getId())
                {
                    return false;
                }
            }
            return true;
        }

        public void  addBlock(int? parentBlockId , Block block)
        {
            if (validateBlock(block))
            {
                if (parentBlockId!=null && blocks.Count<1)
                {
                    List<Block> chains = new List<Block>();
                    foreach (var item in blocks)
                    {
                        if (item.getId() == parentBlockId)
                        {
                            blocks.Add(item);

                        }
                    }
                }
            }
        }
        public int getBalance(string account)
        {
            int balance = 0;
            if (account==null||account.Trim().Length<2||account.Trim().Length>100)
            {
                throw new Exception("Account is invalid,the length should be between 2 and 100 characters");
            }
            var blockchains = getBlockChain();

            foreach (var item in blockchains)
            {
                foreach (var b in item.getTransactions())
                {
                    if (b.getTo()==account)
                    {
                        balance += b.getAmount();
                    }
                    if (b.getFrom()==account)
                    {
                        balance -= b.getAmount();
                    }
                }
            }
            return balance;
        }
    }
}

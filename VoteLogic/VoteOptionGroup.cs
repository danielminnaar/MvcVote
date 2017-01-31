using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteLogic
{
    public class VoteOptionGroup : List<VoteOption>
    {
        public void Add(string name)
        {
            //base.Add(new VoteOption() { Name = name, Votes = 0 });
        }

    }
}

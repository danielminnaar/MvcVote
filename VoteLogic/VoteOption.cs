using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteLogic
{
    public class VoteOption
    {
        public string Name { get; set; }
        private int _votes { get; set; }
        public int Id { get; set; }
        public List<string> Voters = new List<string>();

        public int Votes
        {
            get { return _votes; }
        }

        public void AddVote(string voterId)
        {
            _votes++;
            Voters.Add(voterId.ToLower());
        }

        public void ResetVotes()
        { 
            _votes = 0;
            Voters = new List<string>();
        }

        public VoteOption()
        {

        }

        public VoteOption(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

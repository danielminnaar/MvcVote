using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteLogic
{
    public class Logic
    {
        public List<VoteOption> Votes
        {
            get { return _votes; }
        }

        private List<VoteOption> _votes { get; set; }

        public Logic()
        {
            _votes = new List<VoteOption>();

            _votes.Add(new VoteOption(1, "C#"));
            _votes.Add(new VoteOption(2, "Java"));
            _votes.Add(new VoteOption(3, "Python"));
            _votes.Add(new VoteOption(4, "Ruby"));
            _votes.Add(new VoteOption(5, "C++"));
            _votes.Add(new VoteOption(6, "C"));
        }

        public void AdvanceVotingStage(int bestOf)
        {
            if (Votes.Count == bestOf)
                _votes = Votes.OrderByDescending(x => x.Votes).Take(1).ToList(); // if we have a tie breaker, then choose whatever
            else
            {
                _votes = Votes.OrderByDescending(x => x.Votes).Take(bestOf).ToList();
                _votes.ForEach(vo =>
                {
                    vo.ResetVotes();
                });
            }
        }

        private bool UserAlreadyVoted(string userIP)
        {
            var retVal = false;
            _votes.ForEach(vo =>
            {
                if (vo.Voters.Contains(userIP.ToLower()))
                {
                    retVal = true;
                    return;
                }
            });
            return retVal;
        }

        public void UpVote(int voteId, string userIP)
        {
            if (!UserAlreadyVoted(userIP))
            {
                _votes.ForEach(vo =>
                {
                    if (vo.Id == voteId)
                        vo.AddVote(userIP);
                });
            }
        }

        public VoteOption GetHighestVotedOption()
        {
            VoteOption mostVotedOption = new VoteOption();
            _votes.ForEach(vo =>
            {
                if (vo.Votes > mostVotedOption.Votes)
                    mostVotedOption = vo;
            });

            return mostVotedOption;
        }
    }
}

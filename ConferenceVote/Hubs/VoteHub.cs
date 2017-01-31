using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace ConferenceVote.Hubs
{
    public class VoteHub : Hub
    {
        private static VoteLogic.Logic VoteLogic = new VoteLogic.Logic();

        // Increment the vote
        public void Vote(int id, string userid)
        {
            VoteLogic.UpVote(id, userid);
            Clients.All.updateVoteResults(VoteLogic.Votes);
        }

        public void Advance()
        {
            VoteLogic.AdvanceVotingStage(2); // re-seed the votes based on the 2 highest voted options
            Clients.All.updateVoteResults(VoteLogic.Votes);
        }

        public void Reset()
        {
            VoteLogic = new VoteLogic.Logic();
            Clients.All.updateVoteResults(VoteLogic.Votes);
        }

        // Give the new client an updated list of the current votes
        public override Task OnConnected()
        {
            Clients.Caller.joinVoting(VoteLogic.Votes);
            return base.OnConnected();
        }
    }
}
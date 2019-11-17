using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inov1010_001_RankUp_Final
{
    public class Match
    {
        List<User> players;
        bool result;
        public Match nextMatch;
        public Match prevMatch;
        bool finalMatch;

        public Match(List<User> players)
        {
            this.players = players;
        }
        public Match()
        {
        }

        public void PopulateMatch(User player)
        {
            this.players.Add(player);
        }
        public void PopulateMatch(List<User> players)
        {
            this.players = players;
        }
        public void ProgressPlayers()
        {
            if (result)
            {
                this.nextMatch.PopulateMatch(players[0]);
            }
            else
            {
                this.nextMatch.PopulateMatch(players[1]);
            }
            
        }

        public void ReportMatch()
        {
            if(this.nextMatch != null)
            {
                result = true;
            }
            else
            {
                finalMatch = true;
            }

            
        }
    }
}

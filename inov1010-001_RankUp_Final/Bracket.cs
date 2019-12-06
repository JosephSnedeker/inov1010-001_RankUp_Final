using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
namespace inov1010_001_RankUp_Final
{
    public class Bracket
    {
        string name;
        int playerNum;
        public List<User> users = new List<User>();
        User winner;
        public List<Match> matchList;




        public Bracket(string name, int playerNum, List<User> users)
        {
            this.name = name;
            this.playerNum = playerNum;
            this.users = users;
        }
        public void SeedTournament()
        {
            List<User> sortedUsers = users.OrderBy(users => users.rank).ToList();
            users = sortedUsers;

        }
        public void ConstructBracket()
        {
            
            while (!((playerNum &(playerNum - 1)) == 0))//adds BYE players if the bracket is not the right size
            {
                users.Add(new User("BYE", 999999));
                playerNum++;
            }
            matchList = new List<Match>();

            for (int i = 0; i < playerNum/2; i++)//creates round one
            {
                matchList.Add(new Match(new List<User> { users[i], users[playerNum - 1 - i]}));
            }

            for (int i = 0; i < matchList.Count; i++) //populates rest of bracket
            {
                if (i % 2 != 0)
                {
                    matchList[i-1].nextMatch = matchList[i].nextMatch = new Match();
                    matchList.Add(matchList[i].nextMatch);

                }
            }
        }
        public List<User> GetUsers()
        {
            return users;
        }
        
    }
}
*/
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inov1010_001_RankUp_Final
{
    public class Match
    {
        public int id { get; set; }
        public int teamid1 { get; set; }
        public int teamid2 { get; set; }
        public int roundnumber { get; set; }
        public int winner { get; set; }

        public Match(int id, int teamid1, int teamid2, int roundnumber, int winner)
        {
            this.id = id;
            this.teamid1 = teamid1;
            this.teamid2 = teamid2;
            this.roundnumber = roundnumber;
            this.winner = winner;
        }
    }

    public class Tournament
    {
        public SortedList<int, SortedList<int, Match>> TournamentRoundMatches { get; private set; }
        public Match ThirdPlaceMatch { get; private set; }

        public Tournament(int rounds)
        {
            this.TournamentRoundMatches = new SortedList<int, SortedList<int, Match>>();
            this.GenerateTournamentResults(rounds);
            
        }

        public void AddMatch(Match m)
        {
            if (this.TournamentRoundMatches.ContainsKey(m.roundnumber))
            {
                if (!this.TournamentRoundMatches[m.roundnumber].ContainsKey(m.id))
                {
                    this.TournamentRoundMatches[m.roundnumber].Add(m.id, m);
                }
            }
            else
            {
                this.TournamentRoundMatches.Add(m.roundnumber, new SortedList<int, Match>());
                this.TournamentRoundMatches[m.roundnumber].Add(m.id, m);
            }
        }

        private void GenerateTournamentResults(int rounds)
        {
            //Random WinnerRandomizer = new Random();

            for (int round = 1, match_id = 1; round <= rounds; round++)
            {
                int matches_in_round = 1 << (rounds - round);
                for (int round_match = 1; round_match <= matches_in_round; round_match++, match_id++)
                {
                    int team1_id;
                    int team2_id;
                    int winner;
                    if (round == 1)
                    {
                        team1_id = (match_id * 2) - 1;
                        team2_id = (match_id * 2);
                    }
                    else
                    {
                        int match1 = (match_id - (matches_in_round * 2) + (round_match - 1));
                        int match2 = match1 + 1;
                        team1_id = this.TournamentRoundMatches[round - 1][match1].winner;
                        team2_id = this.TournamentRoundMatches[round - 1][match2].winner;
                    }
                    //winner = (WinnerRandomizer.Next(1, 3) == 1) ? team1_id : team2_id;
                    this.AddMatch(new Match(match_id, team1_id, team2_id, round, winner));
                }
            }
        }

        
    }
}


/*
public class Match
{
    public List<User> players = new List<User>();
    public bool result;
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
        else if(!result)
        {
            return;
        }
        else
        {
            return;
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
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;


namespace inov1010_001_RankUp_Final.Pages
{
    public class TournamentModel : PageModel
    {
        public ActionResult OnGet()
        {
            Tournament tournament = new Tournament(5);
            int match_white_span;
            int match_span;
            int position_in_match_span;
            int column_stagger_offset;
            int effective_row;
            int col_match_num;
            int cumulative_matches;
            int effective_match_id;
            int rounds = tournament.TournamentRoundMatches.Count;
            int teams = 1 << rounds;
            int max_rows = teams << 1;
            StringBuilder HTMLTable = new StringBuilder();

            HTMLTable.AppendLine("<style type=\"text/css\">");
            HTMLTable.AppendLine("    .thd {background: rgb(220,220,220); font: bold 10pt Arial; text-align: center;}");
            HTMLTable.AppendLine("    .team {color: white; background: rgb(100,100,100); font: bold 10pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    .winner {color: white; background: rgb(60,60,60); font: bold 10pt Arial;}");
            HTMLTable.AppendLine("    .vs {font: bold 7pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    td, th {padding: 3px 15px; border-right: dotted 2px rgb(200,200,200); text-align: right;}");
            HTMLTable.AppendLine("    h1 {font: bold 14pt Arial; margin-top: 24pt;}");
            HTMLTable.AppendLine("</style>");

            HTMLTable.AppendLine("<h1>Tournament Results</h1>");
            HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
            for (int row = 0; row <= max_rows; row++)
            {
                cumulative_matches = 0;
                HTMLTable.AppendLine("    <tr>");
                for (int col = 1; col <= rounds + 1; col++)
                {
                    match_span = 1 << (col + 1);
                    match_white_span = (1 << col) - 1;
                    column_stagger_offset = match_white_span >> 1;
                    if (row == 0)
                    {
                        if (col <= rounds)
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Round " + col + "</th>");
                        }
                        else
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Winner</th>");
                        }
                    }
                    else if (row == 1)
                    {
                        HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                    }
                    else
                    {
                        effective_row = row + column_stagger_offset;
                        if (col <= rounds)
                        {
                            position_in_match_span = effective_row % match_span;
                            position_in_match_span = (position_in_match_span == 0) ? match_span : position_in_match_span;
                            col_match_num = (effective_row / match_span) + ((position_in_match_span < match_span) ? 1 : 0);
                            effective_match_id = cumulative_matches + col_match_num;
                            if ((position_in_match_span == 1) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + match_white_span + "\">&nbsp;</td>");
                            }
                            else if ((position_in_match_span == (match_span >> 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.TournamentRoundMatches[col][effective_match_id].teamid1 + "</td>");
                            }
                            else if ((position_in_match_span == ((match_span >> 1) + 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"vs\" rowspan=\"" + match_white_span + "\">VS</td>");
                            }
                            else if ((position_in_match_span == match_span) && (effective_row % match_span == 0))
                            {
                                HTMLTable.AppendLine("        <td class=\"team\">Team " + tournament.TournamentRoundMatches[col][effective_match_id].teamid2 + "</td>");
                            }
                        }
                        else
                        {
                            if (row == column_stagger_offset + 2)
                            {
                                HTMLTable.AppendLine("        <td class=\"winner\">Team " + tournament.TournamentRoundMatches[rounds][cumulative_matches].winner + "</td>");
                            }
                            else if (row == column_stagger_offset + 3)
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                            }
                        }
                    }
                    if (col <= rounds)
                    {
                        cumulative_matches += tournament.TournamentRoundMatches[col].Count;
                    }
                }
                HTMLTable.AppendLine("    </tr>");
            }
            

            return Content(HTMLTable.ToString(), "text/html");
        }
        


    }
}

















/*
namespace inov1010_001_RankUp_Final.Pages
{
    public class TournamentModel : PageModel
    {
        public string returnString;
        StringBuilder sb = new StringBuilder();

        static User user1 = new User("user1", 1);
        static User user2 = new User("user2", 1);
        static User user3 = new User("user3", 1);
        static User user4 = new User("user4", 1);
        static User user5 = new User("user5", 1);
        static User user6 = new User("user6", 1);
        static User user7 = new User("user7", 1);
        static User user8 = new User("user8", 1);
        static User user9 = new User("user9", 1);
        static User user10 = new User("user10", 1);
        static User user11 = new User("user11", 1);
        static User user12 = new User("user12", 1);
        static User user13 = new User("user13", 1);
        static User user14 = new User("user14", 1);
        static User user15 = new User("user15", 1);
        static User user16 = new User("user16", 1);
        static public List<User> users = new List<User>() { user1, user2, user3, user4, user5, user6, user7, user8, user9, user10, user11, user12, user13, user14, user15, user16 };




        public ActionResult OnGet()
        {
            Bracket tournamentOne = new Bracket("TEST BRACKET", 16, users);
            tournamentOne.ConstructBracket();
            int match_white_span;
            int match_span;
            int position_in_match_span;
            int column_stagger_offset;
            int effective_row;
            int col_match_num;
            int cumulative_matches;
            int effective_match_id;
            int i = 0;
            int rounds = (int)MathF.Sqrt(tournamentOne.users.Count);
            int debugCounter = 0;
            int teams = 1 << rounds;
            int max_rows = teams << 1;
            StringBuilder HTMLTable = new StringBuilder();

            HTMLTable.AppendLine("<style type=\"text/css\">");
            HTMLTable.AppendLine("    .thd {background: rgb(220,220,220); font: bold 10pt Arial; text-align: center;}");
            HTMLTable.AppendLine("    .team {color: white; background: rgb(100,100,100); font: bold 10pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    .winner {color: white; background: rgb(60,60,60); font: bold 10pt Arial;}");
            HTMLTable.AppendLine("    .vs {font: bold 7pt Arial; border-right: solid 2px black;}");
            HTMLTable.AppendLine("    td, th {padding: 3px 15px; border-right: dotted 2px rgb(200,200,200); text-align: right;}");
            HTMLTable.AppendLine("    h1 {font: bold 14pt Arial; margin-top: 24pt;}");
            HTMLTable.AppendLine("</style>");

            HTMLTable.AppendLine("<h1>Tournament Results</h1>");
            HTMLTable.AppendLine("<table border=\"0\" cellspacing=\"0\">");
            for (int row = 0; row <= max_rows; row++)
            {
                
                cumulative_matches = 0;
                HTMLTable.AppendLine("    <tr>");
                for (int col = 1; col <= rounds + 1; col++)
                {

                    match_span = 1 << (col + 1);
                    match_white_span = (1 << col) - 1;
                    column_stagger_offset = match_white_span >> 1;
                    if (row == 0)
                    {
                        if (col <= rounds)
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Round " + col + "</th>");
                        }
                        else
                        {
                            HTMLTable.AppendLine("        <th class=\"thd\">Winner</th>");
                        }
                    }
                    else if (row == 1)
                    {
                        HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                    }
                    else
                    {
                        effective_row = row + column_stagger_offset;
                        if (col <= rounds)
                        {
                            position_in_match_span = effective_row % match_span;
                            position_in_match_span = (position_in_match_span == 0) ? match_span : position_in_match_span;
                            col_match_num = (effective_row / match_span) + ((position_in_match_span < match_span) ? 1 : 0);
                            effective_match_id = cumulative_matches + col_match_num;
                            if ((position_in_match_span == 1) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + match_white_span + "\">&nbsp;</td>");
                            }
                            else if ((position_in_match_span == (match_span >> 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                

                                HTMLTable.AppendLine("        <td class=\"team\">Team " +  tournamentOne.matchList[i].players[0].name + "</td>");
                                

                            }
                            else if ((position_in_match_span == ((match_span >> 1) + 1)) && (effective_row % match_span == position_in_match_span))
                            {
                                HTMLTable.AppendLine("        <td class=\"vs\" rowspan=\"" + match_white_span + "\">VS</td>");
                            }
                            else if ((position_in_match_span == match_span) && (effective_row % match_span == 0))
                            {
                                
                                HTMLTable.AppendLine("        <td class=\"team\">Team " + tournamentOne.matchList[i].players[1].name + "</td>");
                                i++;
                                tournamentOne.matchList[i - 1].ReportMatch();
                                tournamentOne.matchList[i - 1].ProgressPlayers();

                            }
                        }
                        else
                        {
                            if (row == column_stagger_offset + 2)
                            {
                                //tournamentOne.matchList[col].result = true;
                                //tournamentOne.matchList[col].ProgressPlayers();
                                HTMLTable.AppendLine("        <td class=\"winner\">Team " + tournamentOne.matchList[i].players[1].name + "</td>");
                                
                            }
                            else if (row == column_stagger_offset + 3)
                            {
                                HTMLTable.AppendLine("        <td class=\"white_span\" rowspan=\"" + (match_white_span - column_stagger_offset) + "\">&nbsp;</td>");
                            }
                        }
                    }
                    if (col <= rounds)
                    {
                        cumulative_matches += tournamentOne.matchList.Count;
                    }
                    
                }
                HTMLTable.AppendLine("    </tr>");
                
                
                
                
            }

            return Content(HTMLTable.ToString(), "text/html");

        }
    }
}
*/

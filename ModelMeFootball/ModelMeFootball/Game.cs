using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMeFootball
{
    public class Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public Referee Referee { get; set; }
        public List<Referee> AssistantReferees { get; set; }
        public List<(int Minute, FootballPlayer Player)> Goals { get; set; }
        public Team Winner { get; set; }
        int team1, team2;
        bool isDraw;

        public Game(Team team1, Team team2, Referee referee, List<Referee> assistantReferees)
        {
            if (team1.Players.Count < 11 || team2.Players.Count < 11)
            {
                throw new Exception("Teams should have atleast 11 players to start the game.");
            }
            Team1 = team1;
            Team2 = team2;
            Referee = referee;
            AssistantReferees = assistantReferees;
            Goals = new List<(int Minute, FootballPlayer Player)>();
            Winner = null;
        }

        public void AddGoal(int minute, FootballPlayer player)
        {
            Goals.Add((minute, player));
            team1 += Convert.ToInt32(Team1.Players.Where(p => p.Number == player.Number).FirstOrDefault() != null);
            team2 += Convert.ToInt32(Team2.Players.Where(p => p.Number == player.Number).FirstOrDefault() != null);
            Winner = team1 > team2 ? Team1 : Team2;
            if (team1 == team2) isDraw = true;
            else isDraw = false;
        }

        public void PrintResult()
        {
            Console.WriteLine("Game Result:");
            Console.WriteLine();
            Console.WriteLine("Team 1: " + Team1.Coach.Name);
            Console.WriteLine("Players:");
            foreach (FootballPlayer player in Team1.Players)
            {
                Console.WriteLine(player.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Team 2: " + Team2.Coach.Name);
            Console.WriteLine("Players:");
            foreach (FootballPlayer player in Team2.Players)
            {
                Console.WriteLine(player.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Referee: " + Referee.Name);
            Console.WriteLine("\nAssistant Referees:");
            foreach (Referee assistantReferee in AssistantReferees)
            {
                Console.WriteLine(assistantReferee.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Goals:");
            foreach (var goal in Goals)
            {
                Console.WriteLine("Minute: " + goal.Minute + " \nPlayer: " + goal.Player.Name + "\n\n");
            }
            Console.WriteLine("\tWinner: " + (Winner != null ? isDraw ? "DRAW" : Winner.Coach.Name : "None"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMeFootball
{
    public class Team
    {
        public Coach Coach { get; set; }
        private List<FootballPlayer> players;
        public List<FootballPlayer> Players
        {
            get
            {
                List<FootballPlayer> temp = new List<FootballPlayer>();
                foreach (FootballPlayer player in players)
                {
                    temp.Add(player);
                }
                return temp;
            }
            private set
            {
                if (value.Count < 11 || value.Count > 22)
                {
                    throw new Exception("Players are not between 11 and 22!");
                }
                players = value;
            }
        }

        public Team(Coach coach, List<FootballPlayer> players)
        {
            Coach = coach;
            Players = players;
        }

        public void AddPlayer(FootballPlayer player)
        {
            if (players.Count() > 22)
            {
                throw new Exception("Can't add more than 22 players");
            }
            players.Add(player);
        }

        public void RemovePlayer(FootballPlayer player)
        {
            if (players.Count() == 0)
            {
                throw new Exception("Can't remove when you have 0 players");
            }
            players.Remove(player);
        }

        public double CalculateAverageAge()
        {
            int totalAge = 0;
            foreach (FootballPlayer player in Players)
            {
                totalAge += player.Age;
            }
            return (double)totalAge / Players.Count;
        }
    }
}

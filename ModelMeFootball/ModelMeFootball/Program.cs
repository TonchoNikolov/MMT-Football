namespace ModelMeFootball
{
    public class Program
    {
        public static void Main()
        {
            Goalkeeper player1 = new Goalkeeper("John Smith", 1, 25, 190);
            Defender player2 = new Defender("Michael Johnson", 2, 28, 180);
            Defender player3 = new Defender("Daniel Williams", 3, 29, 185);
            Defender player4 = new Defender("Christopher Brown", 4, 27, 182);
            Defender player5 = new Defender("Andrew Davis", 5, 26, 178);
            Midfielder player6 = new Midfielder("Matthew Wilson", 6, 24, 175);
            Midfielder player7 = new Midfielder("James Taylor", 7, 27, 176);
            Midfielder player8 = new Midfielder("Joseph Anderson", 8, 29, 177);
            Midfielder player9 = new Midfielder("David Robinson", 9, 30, 179);
            Striker player10 = new Striker("Robert Clark", 10, 23, 185);
            Striker player11 = new Striker("William Martinez", 11, 22, 183);

            Goalkeeper player12 = new Goalkeeper("Thomas Johnson", 13, 24, 188);
            Defender player13 = new Defender("Joshua Anderson", 14, 27, 182);
            Defender player14 = new Defender("Christopher Thompson", 15, 26, 180);
            Defender player15 = new Defender("Matthew Davis", 16, 25, 179);
            Defender player16 = new Defender("Joseph Wilson", 17, 28, 181);
            Midfielder player17 = new Midfielder("Daniel Clark", 18, 26, 176);
            Midfielder player18 = new Midfielder("David Garcia", 19, 29, 177);
            Midfielder player19 = new Midfielder("Andrew Rodriguez", 20, 28, 178);
            Midfielder player20 = new Midfielder("Joshua Young", 21, 25, 180);
            Striker player21 = new Striker("Michael Harris", 22, 27, 183);
            Striker player22 = new Striker("Matthew White", 23, 24, 185);

            List<FootballPlayer> playersTeamOne = new List<FootballPlayer> { player1, player2, player3, player4, player5, player6, player7, player8, player9, player10, player11 };
            List<FootballPlayer> playersTeamTwo = new List<FootballPlayer> { player12, player13, player14, player15, player16, player17, player18, player19, player20, player21, player22 };

            Coach coachOne = new Coach("Piter", 42);
            Coach coachTwo = new Coach("Joshwa", 34);

            Referee referee = new Referee("Ludwig", 48);

            List<Referee> assistantReferees = new List<Referee> {
                new Referee("Asmen", 30),
                new Referee("Tabani", 41)
            };

            Team teamOne = new Team(coachOne, playersTeamOne);
            Team teamTwo = new Team(coachTwo, playersTeamTwo);

            teamOne.Players.RemoveRange(0, 11); // the get returns a copy of the original list and does not allow for change of the original
            //teamOne.players = new List<FootballPlayer> { }; //can't access private properties

            double avgAge;
            avgAge = teamOne.CalculateAverageAge();
            Console.WriteLine("The average age of the first Team: " + Math.Round(avgAge, 2));
            avgAge = teamTwo.CalculateAverageAge();
            Console.WriteLine("The average age of the second Team: " + Math.Round(avgAge, 2));
            Console.WriteLine();


            Game game = new Game(teamOne, teamTwo, referee, assistantReferees);

            game.AddGoal(18, player2);
            game.AddGoal(21, player13);
            game.AddGoal(65, player20);
            game.AddGoal(66, player11);
            //game.AddGoal(67, player11); //DRAW
            //game.AddGoal(70, player11); //team1 win test (Piter)
            game.AddGoal(74, player21);

            game.PrintResult();
        }
    }
}
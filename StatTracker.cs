using System;
using System.Text.RegularExpressions;

public class StatTracker
{
    public static void Main(string[] args)
    {
        CustomQueue matchQueue = new CustomQueue();
        Analyzer analyzer = new Analyzer(matchQueue);
        GameplayInsights insights = new GameplayInsights(analyzer);

        int choice = 0;

        while (choice != 7)
        {
            Console.WriteLine("\nCall of Duty Stat Insights and Tracker");
            Console.WriteLine("1. Add a Recent Match");
            Console.WriteLine("2. Remove the Oldest Match");
            Console.WriteLine("3. View the Last Played Match");
            Console.WriteLine("4. Display all Queued Matches");
            Console.WriteLine("5. Show Two Match Insight Comparision");
            Console.WriteLine("6. Show Overall Match Statistics and Insights");
            Console.WriteLine("7. Exit Tracker");

            choice = MenuChoiceSelection(7);

            switch (choice)
            {
                case 1:
                    int kills;
                    while (true)
                    {
                        Console.WriteLine("Enter kill amount: ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out kills) || kills < 0)
                        {
                            Console.WriteLine("Please enter an integer value greater than or equal to 0.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    int deaths;
                    while (true)
                    {
                        Console.WriteLine("Enter death amount: ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out deaths) || deaths < 0)
                        {
                            Console.WriteLine("Please enter an integer value greater than or equal to 0.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    int assists;
                    while (true)
                    {
                        Console.WriteLine("Enter assist amount: ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out assists) || assists < 0)
                        {
                            Console.WriteLine("Please enter an integer value greater than or equal to 0.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    int damage;
                    while (true)
                    {
                        Console.WriteLine("Enter damage amount: ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out damage) || damage < 0)
                        {
                            Console.WriteLine("Please enter an integer value greater than or equal to 0.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    bool wins;
                    while (true)
                    {
                        Console.WriteLine("Did you win the match (yes or no): ");
                        string input = Console.ReadLine().ToLower();

                        if (input == "yes")
                        {
                            wins = true;
                            break;
                        }
                        else if (input == "no")
                        {
                            wins = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid, enter yes or no. Nothing else.");
                        }
                    }

                    int objectiveTime;
                    while (true)
                    {
                        Console.WriteLine("Enter objective time amount (0 to 250): ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out objectiveTime) || objectiveTime < 0 || objectiveTime > 250)
                        {
                            Console.WriteLine("Please enter an integer value greater than or equal to 0 amd less then 250.");
                        }
                        else
                        {
                            break;
                        }
                    }

                    Match newMatch = new Match(kills, deaths, assists, damage, wins, objectiveTime);
                    matchQueue.enqueue(newMatch);
                    Console.WriteLine("Match has been added to the queue.");
                    break;

                case 2:
                    Match oldMatch = matchQueue.dequeue();
                    if (oldMatch != null)
                    {
                        Console.WriteLine("Match has been removed!");
                    }
                    break;

                case 3:
                    Match lastPlayed = matchQueue.peek();
                    if (lastPlayed != null)
                    {
                        Console.WriteLine("Last played match: " + lastPlayed);
                    }
                    break;

                case 4:
                    matchQueue.displayQueue();
                    break;

                case 5:
                    if (matchQueue.getSize() < 2)
                    {
                        Console.WriteLine("Not enough matches to compare.");
                    }
                    else
                    {
                        int matchNumber = MenuChoiceSelection(matchQueue.getSize() - 1);
                        Console.WriteLine(analyzer.matchSpecificTrends(matchNumber));
                    }
                    break;

                case 6:
                    Console.WriteLine("Total Gameplay Kills: " + analyzer.totalKills());
                    Console.WriteLine("Total Gameplay Deaths: " + analyzer.totalDeaths());
                    Console.WriteLine("Overall KD: " + analyzer.overallKD());
                    Console.WriteLine("Average Assists a Match: " + analyzer.averageAssists());
                    Console.WriteLine("Average Engagements a Match: " + analyzer.averageEngagements());
                    Console.WriteLine("Average Objective Time a Match: " + analyzer.averageObj());
                    Console.WriteLine("Average Pace: " + analyzer.averagePace());
                    Console.WriteLine("Win Percentage: " + analyzer.winPercentage());
                    Console.WriteLine(insights.kdInsight());
                    Console.WriteLine(insights.paceInsight());
                    Console.WriteLine(insights.objectiveInsight());
                    Console.WriteLine(insights.projectedRoleInsight());
                    break;

                case 7:
                    Console.WriteLine("Exiting Program, have a good day!");
                    break;

                default:
                    Console.WriteLine("Invalid Input, try again!");
                    break;
            }
        }
    }

    public static int MenuChoiceSelection(int maxChoice)
    {
        int choice = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("Please enter your selection: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice) || choice < 1 || choice > maxChoice)
            {
                Console.WriteLine("Please enter an integer value from 1 to 7!");
            }
            else
            {
                validInput = true;
            }
        }
        return choice;
    }
}
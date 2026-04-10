/*
Name: Gavin Goodman
Class: CSCI - C311 Programming Langauges
Date: April 10, 2026
Program Name: GameplayInsights.cs

General Description:
This is the main driver force to allow the user to interact
with the program and provide the information needed to 
operate all areas and other files in the program. In this program
we have the Main method to execute the program and also have
a MenuChoiceSelection method to get the users input and allow
the program to operate as intended. This is how we enter the 
users match specific data, create nodes, and generate the insights/ 
*/

using System;                                                   // allows use of system namespace

public class StatTracker
/*
This is the class for the StatTracker, to not rehash the general description,
this is where the main method lies for program execution and allowing user
input for match data and getting sepcific insights for the player. We have 
a method in this class to read the users menu selection for input as well. 
Overall, this is the class to run every single aspect of the program. 
*/
{
    public static void Main(string[] args)
    /*
    This is the main method in the program, here we will use all of the constructors
    to instatiate objects and to hold memory for the variables used within these
    constructors to get them up and running. We also have a menu for the user to choose
    from that is explicit in its options, mainly including adding a match to the queue,
    removing the oldest match, viewing the first match in the queue all the way to 
    providing the overall insights the player needs to figure out role and actual impact
    in the matches they are playing. This is a switch case that will operate until the user
    selects choice 7 to close the program and stop its execution. 
    */
    {
        CustomQueue matchQueue = new CustomQueue();                         // initialization of queue, analyzer,
        Analyzer analyzer = new Analyzer(matchQueue);                       // and general insights objects for use
        GameplayInsights insights = new GameplayInsights(analyzer);

        int choice = 0;         

        while (choice != 7)                                                     // menu to print and continue to print 
        {                                                                       // with all of the options until the 
            Console.WriteLine("\nCall of Duty Stat Insights and Tracker");      // user selects choice 7 to close
            Console.WriteLine("1. Add a Recent Match");
            Console.WriteLine("2. Remove the Oldest Match");
            Console.WriteLine("3. View the First Played Match");
            Console.WriteLine("4. Display all Queued Matches");
            Console.WriteLine("5. Show Two Match Insight Comparision");
            Console.WriteLine("6. Show Overall Match Statistics and Insights");
            Console.WriteLine("7. Exit Tracker");

            choice = MenuChoiceSelection(7);                                    // reads user input for menu

            switch (choice)                                                     // begin the switch statement
            {                                                                   // based on the user choice. 
                case 1:
                /*
                Case one will check for proper input of varaibles to create
                a match object to store in the queue for manipulation later.
                The user enters kills, deaths, assists, damage, win, and
                objective time and use this information for engagements, KD,
                and the average pace of the player. 
                */                                                         
                    int kills;                              // kills variable input
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

                    int deaths;                             // death variable input
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

                    int assists;                            // assists variable input
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
                    while (true)                            // damage variable input
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

                    bool wins;                                 // if the match was a win or lose
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

                    int objectiveTime;                         // the input for objective time
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

                    Match newMatch = new Match(kills, deaths, assists, damage, wins, objectiveTime);    // creation of match object
                    matchQueue.enqueue(newMatch);                                                       // and enqueue process
                    Console.WriteLine("Match has been added to the queue.");
                    break;

                case 2:
                // dequeues the oldest match in the queue and provides that information to the user
                    Match oldMatch = matchQueue.dequeue();                              
                    if (oldMatch != null)
                    {
                        Console.WriteLine("Match has been removed!");
                    }
                    break;

                case 3:
                // retrieves information on the first played match without dequeuing
                    Match firstPlayed = matchQueue.peek();
                    if (firstPlayed != null)
                    {
                        Console.WriteLine("First played match: " + firstPlayed);
                    }
                    break;

                case 4:
                // displays the contents inside of the queue/
                    matchQueue.displayQueue();
                    break;

                case 5:
                // compares two matches that are next to each other in the queue
                    Console.WriteLine("Please enter the match you want to compare: ");
                    if (matchQueue.getSize() < 2)
                    {
                        Console.WriteLine("Not enough matches to compare.");
                    }
                    else
    {
        int matchNumber = 0;
        bool validMatchInput = false;

        while (!validMatchInput)
        {
            Console.WriteLine("Enter the first match number to compare matches (1 to " + (matchQueue.getSize() - 1) + "): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out matchNumber) || matchNumber < 1 || matchNumber >= matchQueue.getSize())
            {
                Console.WriteLine("Invalid match number. Please enter a value from 1 to " + (matchQueue.getSize() - 1) + ".");
            }
            else
            {
                validMatchInput = true;
            }
        }

        Console.WriteLine(analyzer.matchSpecificTrends(matchNumber));
    }
    break;

                case 6:
                // displays all of the insights to the player based on the queue match contents at the time of calling
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
                // exits and closes the program
                    Console.WriteLine("Exiting Program, have a good day!");
                    break;

                default:
                // is default based on if input is a bad input from the user. 
                    Console.WriteLine("Invalid Input, try again!");
                    break;
            }
        }
    }

    public static int MenuChoiceSelection(int maxChoice)
    /*
    This method is a simple method similar to some Java projects taught in older
    classes that will provide the user to interact with the menu of selection items. 
    In this method, we have int choice varable set to 0 and bool validInput to false
    In this case, we have the user input an integer from 1 to 7, if the input is not
    either of these, it will tell the user again to input an integer 1 to 7 and 
    keep validInput to false. Due to the while loop, this will run until the user
    inputs 1 to 7 as a choice, which will set the variable validInput to true
    and break out of the while loop.
    */
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
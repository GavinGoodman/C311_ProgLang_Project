/*
Name: Gavin Goodman
Class: CSCI - C311 Programming Languages
Date: April 9, 2026
Program Name: Analyzer.cs

General Description:
This is the class that will be used to analyze and add
the specific variables in the queue from each match together
to get a total. This will then be used to provide tailored and
custom insights and/or aid for the player to take and apply after
a few matches have been recorded. This class will use the custom
queue created along with storing the match data to present 
total kills and deaths and provide the averages of engagements
damage, KD, assists, pace, objective time, and the player's win
percentage. Then, when comparing the current match to the previous one, 
can provide insights to the player on trends seen match to match.
*/

using System;           // allows use of system namespace

public class Analyzer
/*
This is the class encapsulation for the analyzer class. It will allow the 
user to utilize the Match file and CustomQueue file to calculate multiple methods
pertaining towards totals and averages of the matches within the queue. In doing this,
it will better allow the program to give information and insights for improvement
or general gameplay sayings on how the game is being played by the user. Additionally, 
this class will allow the user to get match trends based on a certain match entered. This
will provide feedback on match to match variables and indicate them as increasing or
decreasing for the user. This analyzer is what is used to see multiple match information
at once and return it to the user to see possible fixes and changes needed in the game.
*/
{
    private CustomQueue matches;                // This is the one private variable 
                                                // to allow access to queue information
    public Analyzer(CustomQueue queuedMatches)
    /*
    This is our only constructor for the class, it will have the argument of CustomQueue
    in order to access the queue of matches and manipulate their data. This one constructor
    though will allow us to use the analyzer to access the queue and move through it when 
    needed to get each match information to provide a greater scope of change needed for
    the player. This is important and vital for the program to operate as intended.
    */
    {
        matches = queuedMatches;
    }

    public int totalKills()
    /*
    This is a public method to obtain the total kills of the player through all of the 
    matches inserted into the queue. It will start initially at 0 and move through the 
    queue using a for loop. During the crawl through the queue, we will search each node
    and obtain the number of kills from the player by utilizing the getKills getter 
    method from the Match class and utilize the getMatchAt method from the queue class
    to ensure we are getting this from the correct match in the queue. 
    */
    {
        int killTotal = 0;                                  //initializes variable at 0.

        for (int i = 0; i < matches.getSize(); ++i)         // iterates through the match queue
        {                                                   // to get the amount of kills 
            Match currentMatch = matches.getMatchAt(i);
            killTotal += currentMatch.getKills();
        }

        return killTotal;                                   // returns the total kills 
    }

    public int totalDeaths()
    /*
    This is a public method to obtain the total deaths of the player through all of the 
    matches inserted into the queue. It will start initially at 0 and move thorugh the 
    queue using a for loop. During the crawl through the queue, we will search each node
    and obtain the number of deaths from the player by utilizing the getDeaths getter 
    method from the Match class and utilize the getMatchAt method from the queue class
    to ensure we are getting this from the correct match in the queue. 
    */
    {
        int deathTotal = 0;                                 // initializes deathTotal to 0

        for (int i = 0; i < matches.getSize(); ++i)         // iterates through the entire queue 
        {                                                   // using getMatchAt i to find the total
            Match currentMatch = matches.getMatchAt(i);     // deaths per match and adds them to deathTotal
            deathTotal += currentMatch.getDeaths();
        }

        return deathTotal;                                  // It will return the calculated deathTotal
    }

    public double overallKD()
    /*
    This is a public method to obtain the full ratio of deaths and kills, utilizing the 
    now calculated totals. This is the first average we are calculating in this class as well.
    Specifically, we will first see if there are any matches. If not, we return 0.0. If there
    are, we will use two variables for totalKills and totalDeaths to return the ratio of the 
    two. This will also be a double due to being a ratio and average within the class. 
    */
    {
        if (matches.getSize() == 0)                         // First we see if there are matches in the
        {                                                   // queue. If not, we will return 0.0
            return 0.0;
        }

        int killsTotal = totalKills();                      // if there are matches, we will set variables
        int deathsTotal = totalDeaths();                    // killsTotal and deathsTotal to totalKills method
                                                            // and totalDeaths 
        if (deathsTotal == 0)                               // if there were no deaths (great if not) then the 
        {                                                   // ratio will be the killtotal, if not, it will 
            return killsTotal;                              // return the ratio by dividing killsTotal by 
        }                                                   // deathsTotal

        return (double)killsTotal / deathsTotal;            // type casting is done here for double
    }

    public double averageAssists()
    /*
    This is a double method to return the average assists obtained in the matches queue,
    essentially returning the average assists per game. This is done very similar to the
    overallKD method mixed with the totalKills and totalDeaths methods. We will, once
    again, be iterating through the queued matches to get the assists a match and divide
    those total assist numbers by the number of matches in the queue to get the average. 
    */
    {
        if (matches.getSize() == 0)                         // First we see if there are matches in the
        {                                                   // queue. If not, we will return 0.0
            return 0.0;
        }

        double assistTotal = 0.0;                           // starts the assist total as 0

        for (int i = 0; i < matches.getSize(); ++i)         // will iterate through the match queue nodes
        {                                                   // one by one and get the assists for that 
            assistTotal += matches.getMatchAt(i).getAssists();  // match to add to the assist total.
        }

        return assistTotal / matches.getSize();             // it then will return the assist total divided
    }                                                       // by the queue size to get the average 

    public double averageEngagements()
    /*
    This is a double method as well very similar to the averageAssist method. However, in
    this method, we will be finding the average number of engagements by the user. This is
    done in an identical fashion as to the average assists, we go through the queue, get the
    total number of engagements, and average that by dividing the total by the queue size. 
    */
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        double engagementTotal = 0.0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            engagementTotal += matches.getMatchAt(i).calculateEngagements();    // similar to the average assists but
        }                                                                       // pulls from the calculate engagements
                                                                                // method in the match class. 
        return engagementTotal / matches.getSize();
    }

    public double winPercentage()
    /*
    This is yet another double method but is implemented slightly differently due to being
    a boolean function in the Match class. Here we are calculating the win percentage of the 
    player with their queued matches. Here we will set an int variable titled winTotal. We will
    increment this by checking to see if the getWin method from each match is true. If it isn't
    true, it will not be incremented. Then we will cast a double to the winTotal and divide it
    by the Match queue size multiplied by 100 to get the win percentage of the player.
    */
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        int winTotal = 0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            if (matches.getMatchAt(i).getWin())
            {
                ++winTotal;                             // here we see the variable being incremented
            }                                           // if the win boolean is true in the queued match
        }

        return ((double)winTotal / matches.getSize()) * 100;
    }

    public double averageObj()
    /*
    Again, this is very similar method to the other average method from above but
    is dealing with the objective score or time from the player in the given 
    matches. WE do this again by iterating through the queue of matches and 
    use the getObjective getter method to obtain the objective score value.
    We then will increment that to the objTotal and divide that total by queue
    size to return the average objective score of the player. 
    */
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        double objTotal = 0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            objTotal += matches.getMatchAt(i).getObjective();
        }

        return objTotal / matches.getSize();
    }

    public double averagePace()
    /*
    This method, again, is similar to the other average methods in this
    class. This one specifically is referring to the pace of the player.
    Here, again, we initialize a variable (paceTotal) to double 0.0. WE
    will then move through the queues and obtain all of the objective 
    values from each match and add them all to the paceTotal. This
    is done with the calculatePace getter function in the match class.
    After this is completed, we will use the calculated paceTotal and
    divide that by the queue size to get the players average pace.
    */
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        double paceTotal = 0.0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            paceTotal += matches.getMatchAt(i).calculatePace();
        }

        return paceTotal / matches.getSize();
    }

    public string matchSpecificTrends(int matchNumber)
    /*
    This is why the bulk of this work is done, and will return the trends between two 
    matches next to each other in queue. Specifically, it will compare the matches based
    on a players KD, engagements, damage, and objective time. It will then give feedback
    based on increases in those fields, decreases in those fields, or if they remained the 
    same over the two matches.
    */
    {
        if (matches.getSize() < 2)                                                  // first it will check if the queue
        {                                                                           // has two matches to begin this process
            return "Not enough matches played to get a trend";
        }

        if (matchNumber < 1 || matchNumber >= matches.getSize())                    // it will ensure matchnumber given is in
        {                                                                           // the correct range needed for this to run
            return "Invalid entry, you have not played that many matches yet.";
        }

        Match first = matches.getMatchAt(matchNumber - 1);                          // creates two matches, next to each other
        Match second = matches.getMatchAt(matchNumber);                             // to compare to each other.

        string postMatchesStatment = "Comparing Match " + matchNumber + " to Match " + (matchNumber + 1) + ": ";    // begins the string to return for insights

        if (first.calculateKD() < second.calculateKD())                 // this section of code will return insights based
        {                                                               // on player KD comparisons in the two matches
            postMatchesStatment += "\nKD improved.";                    // to let players know improvements, decreases, or 
        }                                                               // same KDs.
        else if (first.calculateKD() > second.calculateKD())
        {
            postMatchesStatment += "\nKD decreased.";
        }
        else
        {
            postMatchesStatment += "\nKD remained the same.";
        }


        if (first.calculateEngagements() < second.calculateEngagements())       // this section of code will return insights based
        {                                                                       // on player engagements comparisons in the two 
            postMatchesStatment += "\nEngagements increased.";                  // matches to let players kbow improvements, decreases
        }                                                                       // or similarities in the match engagements
        else if (first.calculateEngagements() > second.calculateEngagements())
        {
            postMatchesStatment += "\nEngagements decreased.";
        }
        else
        {
            postMatchesStatment += "\nEngagements remained the same.";
        }


        if (first.getDamage() < second.getDamage())                             // this section of code will return insights based
        {                                                                       // on player damage comparisons in the two
            postMatchesStatment += "\nDamage increased.";                       // matches to let players kbow improvements, 
        }                                                                       // decreases or similarities in the match damage
        else if (first.getDamage() > second.getDamage())
        {
            postMatchesStatment += "\nDamage decreased.";
        }
        else
        {
            postMatchesStatment += "\nDamage remained the same.";
        }


        if (first.getObjective() < second.getObjective())                       // this section of code will return insights based
        {                                                                       // on player objective comparisons in the two
            postMatchesStatment += "\nObjective work increased.";               // matches to let players kbow improvements,
        }                                                                       // decreases or similarities in the match objective
        else if (first.getObjective() > second.getObjective())
        {
            postMatchesStatment += "\nObjective work decreased.";
        }
        else
        {
            postMatchesStatment += "\nObjective work remained the same.";
        }
                                                                                // It will add these results to the string and
        return postMatchesStatment;                                             // print this completed result for the player 
    }
}
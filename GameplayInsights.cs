/*
Name: Gavin Goodman
Class: CSCI - C311 Programming Langauges
Date: April 10, 2026
Program Name: GameplayInsights.cs

General Description:
This class is to take the overall totals and averages obtained by the analyzer. 
With these numbers from the analyzer, we can give some general analytics based
on the state of play of a specific player. In this file specifically, we have
a general KD insight, pace of the player insight, the objective insight for players,
and a role predictor based on the overall play of the player. The key for this class
is to give string and information feedback specifically to the player. 
*/

using System;                                   // allows use of system namespace

public class GameplayInsights
/*
This is the general class of the Gameplay Insights file. This will house the
methods in the gereral description (KD, objective, pace, and role insights). 
We also have a constructor to utilize the generalInsights object that will 
also utilize the analyzer. This is done by the private variable Analyzer 
analyzer that can allow the user of the program to utilize the program.
*/
{
    private Analyzer analyzer;                                  // private variable analyzer for the 
                                                                // analyzer class created for totals
    public GameplayInsights(Analyzer analyze)
    /*
    This is the constructor class for the gameplay Insights class. This will instatiate
    the object to be used without error and initialize the variables within the constructor
    to be used after creation when needed. In the constructor, we have a parameter
    pointing to the Analyzer class and will use the analyze field to set equal to 
    the analyzer private variable within the class. 
    */
    {
        analyzer = analyze;                     // assignment of variable to parameter argument
    }

    public string kdInsight()
    /*
    This is the general kdInsight that can be given to a player after multiple matches
    have been added to the queue and will provide the overall kd feedback the player 
    needs to hear. Specifically, it will state the insight type as the KD insight for
    the user, it will compare the overallKD method in the analyzer to multiple kd
    values (0.95, 1.15, higher) and give information based on this number. The general
    concept is three phases for this, with the insight stating below average, average, to
    above average and tips to improve or maintan this number for the player. 
    */
    {
        double kd = analyzer.overallKD();
        Console.WriteLine("This is a KD specific insight. Your KD is: " + kd);      // line provides the overallKD to get insights

        if (kd < 0.95)
        {
            return "\nYour overall KD is below average, try to get to power spots and play your life better to improve.";
        }
        else if (kd < 1.15)
        {
            return "\nYour overall KD is average to good, continue performance as is and look for more survivavbility oppertunities.";
        }
        else
        {
            return "\nYour overall KD is great, keep playing the same way survivability and positioning wise, look at overall insights for improvements.";
        }
    }

    public string paceInsight()
    /*
    This is another general insight method that will provide the insight for the players
    pace in matches. This is entirely calculated with the number of engagements but pace with
    KD is supposed to be used for role insights with other specific aids to the players 
    overall performacne. For this method, we will use the analyzer to get average engagements
    so the user can see them and provide the pace based on this. Again, pace is a number between
    1 and 4 in this case with q being the slowest pace and 4 being the fastest possible pace. This
    method as a whole will provide average engagements and average pace with the insight on certain
    possible playstyle based on pace. This is for the player to see if it matches their playstyle 
    they are attempting or is the opposite and to adjust based on this given feedback.  
    */
    {
        double pace = analyzer.averagePace();               
        double engagements = analyzer.averageEngagements();
        Console.WriteLine("This is a pace specific insight using engagements to further analyze."); 

        Console.WriteLine("\nYour engagements on average are: " + engagements);     // These lines provide the users with the
        Console.WriteLine("\nYour pace on average is: " + pace);                    // average engagements and pace. 
        if (pace < 1.5)
        {
            return "\nYour pace is slower then average, this could indicate a methodical or flank heavy playstyle.";
        }
        else if (pace < 2.5)
        {
            return "\nYour pace is average, this is a general playstyle with decent pace and engagements.";
        }
        else if (pace < 3.5)
        {
            return "\nYour pace is above average, this indicates a faster class and pushing out the map.";
        }
        else
        {
            return "\nYour pace is very fast, this indicates an entry player and someone attmepting to control the pace of the map.";
        }
    }

    public string objectiveInsight()
    /*
    This is the method that will provide the average objective insight for the player. This
    will again, use the analyzer to obtain the average objective score for the player. Similar
    to the other insights given previously, it will be tiered in below average, average and above 
    average with another just to heighten that above average a bit more. Again, this will use
    the average objective time for a player to provide insights on how to improve or if they
    should maintain the current objective play they are giving and if it is effective. 
    */
    {
        double obj = analyzer.averageObj();
        Console.WriteLine("This is the objective insight for hardpoint (king of the hill). Here is your average objective time: " + obj);

        if (obj < 40)
        {
            return "\nYour objective score is low, consider playing the objective more.";
        }
        else if (obj < 90)
        {
            return "\nYour objective score is average, could be a good mix of slayer and objective player.";
        }
        else if (obj < 120)
        {
            return "\nYour objective score is high, you are providing a good backbone for the team.";
        }
        else
        {
            return "\nYour objective score is great, you are providing a lot of freedome for the team with this average.";
        }
    }

    public string projectedRoleInsight()
    /*
    This is the bulk of the insight that will be provided for the player and will utilize all of the 
    previous insights in this class to allow for the role to be seen within the players state of play. 
    This can then be used by the player to see if this is the correct role they are intending to play at
    and make adjustments if that is not the case. The broader main four roles for this case are named 
    main, flex, support sub and entry sub and this is mainly determined by pace but objective also indicates
    these roles as well. I will add block comments to each section to better explain or inidicate what is 
    being compared for this case but the blocks of code are used to indicate these four roles. 
    */
    {
        double kd = analyzer.overallKD();
        double obj = analyzer.averageObj();
        double pace = analyzer.averagePace();

        Console.WriteLine("This is your projected role based on pace and KD and some based on objective.");

        if (pace < 1.5)
        /*
        This block is used to give feedback on the pace, which would indicate a Main player. Specifically,
        it will use this general pace and go into kd and objective insights. Based on these insights, it 
        will let you know if you are more objective based, more of a slayer, not producing much of anything
        in either of those categories and your pace is that of a main, or that you are evenly split between
        the two. The idea here is to see which Main role you want to play and if you are efficient, if so good.
        If you are not playing as a main and your pace indicates you are, you will need to adjust to play differently.
        */
        {
            if (kd < 0.95 && obj > 120)
            {
                return "\nYou play as an objective based Main player.";
            }
            else if (kd >= 1.10 && obj < 60)
            {
                return "\nYou play as a slayer based Main player.";
            }
            else if (kd < 0.95 && obj < 60)
            {
                return "\nYou play as a slow Main but currently are not producing. Improve objective time or KD.";
            }
            else
            {
                return "\nYou're a Main that plays evenly in the objective and KD role, this is the optimal way to play.";
            }
        }
        else if (pace < 2.5)
        /*
        This block is utilized to give role insights based on the Flex position. Again, it will use the pace
        value to enter this block of else-if statements and move through the selections based on the state
        of the players obj and kd. There are slight differences in the values based on how the role should
        play but remains very similar. Again, we go through these, and it will provide information based on 
        all of these values and indicate changes in the ways to play or keep going as is with the effiecient 
        gameplay being given. 
        */
        {
            if (kd < 0.95 && obj > 120)
            {
                return "\nYou play as an objective based Main player but pace indicates a Flex role, consider less hill time.";
            }
            else if (kd >= 1.10 && obj < 80)
            {
                return "\nYou play as a slayer based Flex player. This is optimal for the Flex position on the team.";
            }
            else if (kd < 0.95 && obj < 60)
            {
                return "\nYou play as a Flex but currently are not producing. Focus on improving KD with minor hill time increase.";
            }
            else
            {
                return "\nYou're a Flex that plays evenly in the objective and KD role, this is an even team optimal way to play.";
            }
        }
        else if (pace < 3.5)
        /*
        This block is utilized to give role insights based on the support sub position. Again, it utilizes
        the same parameters and fields for the other two role specific blocks to return insights to fix
        gameplay, maintain gameplay, or provide a role switch and switch in style if that is needed. 
        */
        {
            if (kd < 0.95 && obj > 120)
            {
                return "\nYou play as an objective based sub player. You need to stop the objective work and push out the map.";
            }
            else if (kd >= 1.10 && obj < 60)
            {
                return "\nYou play as a slayer based sub player. Typically the slower of the two in the team.";
            }
            else if (kd < 0.95 && obj < 60)
            {
                return "\nYou play as a low impact sub player. Either slow down and focus on KD or role switch to a Flex.";
            }
            else
            {
                return "\nYou are playing as a slow entry sub, so try to increase the pace while maintaining objective and KD.";
            }
        }
        else
        /*
        This block is utilized to give role insights based on the entry sub position. Again, it utilizes
        the same parameters and fields for the other two role specific blocks to return insights to fix
        gameplay, maintain gameplay, or provide a role switch and switch in style if that is needed. 
        */
        {
            if (kd < 0.95 && obj > 100)
            {
                return "\nYou play as an entry sub with too much objective, try pushing out the objective once secured.";
            }
            else if (kd >= 1.10 && obj < 60)
            {
                return "\nYou are a heavy producer as an entry sub, keep this up and the team should be great.";
            }
            else if (kd < 0.95 && obj < 60)
            {
                return "\nThis is the average agrressive sub player, this should be valuable to the team.";
            }
            else
            {
                return "\nYou are playing as a high impact entry sub, try to drop objective still and push out cuts.";
            }
        }
    }
}
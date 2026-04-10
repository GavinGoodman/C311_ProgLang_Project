using System;

public class GameplayInsights
{
    private Analyzer analyzer;

    public GameplayInsights(Analyzer analyze)
    {
        analyzer = analyze;
    }

    public string kdInsight()
    {
        double kd = analyzer.overallKD();
        Console.WriteLine("This is a KD specific insight.");

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
    {
        double pace = analyzer.averagePace();
        double engagements = analyzer.averageEngagements();
        Console.WriteLine("This is a pace specific insight using engagements to further analyze");

        Console.WriteLine("\nYour engagement on average are: " + engagements);
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
    {
        double obj = analyzer.averageObj();
        Console.WriteLine("This is the objective insight for hardpoint (king of the hill).");

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
    {
        double kd = analyzer.overallKD();
        double obj = analyzer.averageObj();
        double pace = analyzer.averagePace();

        Console.WriteLine("This is your projected role based on pace and KD and some based on objective.");

        if (pace < 1.5)
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
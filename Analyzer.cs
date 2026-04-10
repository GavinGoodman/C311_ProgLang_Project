using System;
using System.Text.RegularExpressions;

public class Analyzer
{
    private CustomQueue matches;

    public Analyzer(CustomQueue queuedMatches)
    {
        matches = queuedMatches;
    }

    public int totalKills()
    {
        int killTotal = 0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            Match currentMatch = matches.getMatchAt(i);
            killTotal += currentMatch.getKills();
        }

        return killTotal;
    }

    public int totalDeaths()
    {
        int deathTotal = 0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            Match currentMatch = matches.getMatchAt(i);
            deathTotal += currentMatch.getDeaths();
        }

        return deathTotal;
    }

    public double overallKD()
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        int killsTotal = totalKills();
        int deathsTotal = totalDeaths();

        if (totalDeaths == 0)
        {
            return totalKills;
        }

        return (double)totalKills / totalDeaths;
    }

    public double averageAssists()
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        double assistTotal = 0.0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            assistTotal += matches.getMatchAt(i).getAssists();
        }

        return assistTotal / matches.getSize();
    }

    public double averageEngagements()
    {
        if (matches.getSize() == 0)
        {
            return 0.0;
        }

        double engagementTotal = 0.0;

        for (int i = 0; i < matches.getSize(); ++i)
        {
            engagementTotal += matches.getMatchAt(i).calculateEngagements();
        }

        return engagementTotal / matches.getSize();
    }

    public double winPercentage()
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
                ++winTotal;
            }
        }

        return ((double)winTotal / matches.getSize()) * 100;
    }

    public double averageObj()
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
    {
        if (matches.getSize() < 2)
        {
            return "Not enough matches played to get a trend";
        }

        if (matchNumber < 1 || matchNumber >= matches.getSize())
        {
            return "Invalid entry, you have not played that many matches yet.";
        }

        Match first = matches.getMatchAt(matchNumber - 1);
        Match second = matches.getMatchAt(matchNumber);

        string postMatchesStatment = "Comparing Match " + matchNumber + " to Match " + (matchNumber + 1) + ": ";

        if (first.calculateKD() < second.calculateKD())
        {
            postMatchesStatment += "\nKD improved.";
        }
        else if (first.calculateKD() > second.calculateKD())
        {
            postMatchesStatment += "\nKD decreased.";
        }
        else
        {
            postMatchesStatment += "\nKD remained the same.";
        }


        if (first.calculateEngagements() < second.calculateEngagements())
        {
            postMatchesStatment += "\nEngagements increased.";
        }
        else if (first.calculateEngagements() > second.calculateEngagements())
        {
            postMatchesStatment += "\nEngagements decreased.";
        }
        else
        {
            postMatchesStatment += "\nEngagements remained the same.";
        }


        if (first.getDamage() < second.getDamage())
        {
            postMatchesStatment += "\nDamage increased.";
        }
        else if (first.getDamage() > second.getDamage())
        {
            postMatchesStatment += "\nDamage decreased.";
        }
        else
        {
            postMatchesStatment += "\nDamage remained the same.";
        }


        if (first.getObjective() < second.getObjective())
        {
            postMatchesStatment += "\nObjective work increased.";
        }
        else if (first.getObjective() > second.getObjective())
        {
            postMatchesStatment += "\nObjective work decreased.";
        }
        else
        {
            postMatchesStatment += "\nObjective work remained the same.";
        }

        return postMatchesStatment;
    }
}
using System;

public class Match
{

    private int kills;
    private int deaths;
    private int assists;
    private int damage;
    private bool win;
    private int objective;

    public Match()
    {
        kills = 0;
        deaths = 0;
        assists = 0;
        damage = 0;
        win = false;
        objective = 0;
    }

    public Match(int match_kills, int match_deaths, int match_assists, int match_damage, bool match_win, int match_obj)
    {
        kills = match_kills;
        deaths = match_deaths;
        assists = match_assists;
        damage = match_damage;
        win = match_win;
        objective = match_obj;
    }

    public int getKills()
    {
        return kills;
    }

    public int getDeaths()
    {
        return deaths;
    }

    public int getAssists()
    {
        return assists;
    }

    public int getDamage()
    {
        return damage;
    }

    public bool getWin()
    {
        return win;
    }

    public int getObjective()
    {
        return objective;
    }

    public void setKills(int match_kills)
    {
        kills = match_kills;
    }

    public void setDeaths(int match_deaths)
    {
        deaths = match_deaths;
    }

    public void setAssists(int match_assist)
    {
        assists = match_assist;
    }

    public void setDamage(int match_damage)
    {
        damage = match_damage;
    }

    public void setWin(bool match_win)
    {
        win = match_win;
    }

    public void setObjective(int match_obj)
    {
        objective = match_obj;
    }

    public double calculateKD()
    {
        if (deaths == 0)
            return (double)kills;
        return (double)kills / deaths;
    }

    public int calculateEngagements()
    {
        return kills + deaths;
    }

    public int calculatePace()
    {
        if (calculateEngagements() <= 35)
            return 1;
        else if (calculateEngagements() <= 45)
            return 2;
        else if (calculateEngagements() <= 55)
            return 3;
        else
            return 4;
    }

    public override string ToString()
    {
        return "Kills: " + getKills() +
               "Deaths: " + getDeaths() +
               "Assists: " + getAssists() +
               "KD: " + calculateKD() +
               "Damage: " + getDamage() +
               "Engagements: " + calculateEngagements() +
               "Pace: " + calculatePace();
    }
}
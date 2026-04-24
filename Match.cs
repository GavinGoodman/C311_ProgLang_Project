/*
Name: Gavin Goodman
Class: CSCI - C311 Programming Langauges
Date: April 9, 2026
Program Name: Match.cs

General Description:
This is the bases for tracking our individual matches for the tracker to keep
and analyze. Within this class, we have a class match that encapsulates the
entire file. We also have the private variables used to track general single 
match statistics. Additionally, we have the getter and setter methods for these
to be returned and manipulated outside of the class along with other methods
to get the specific match KD, the number of player engagements, the overall
pace of the player throughout the match, and the to string for returning match
information. This will be a large base for the project to access and manipulate.
*/
using System;                                   // allows us to use system namespace

public class Match  
/*
This is the class match that will help use define the matches we are using
throughout the project. In this class, we will have numerous variables, consisting
of kills, deaths, assists, damage, win, and objective for use in creating the 
Match object to use later on. These will allow the user to keep track of 
performance in a specific single match. Next, we have the constructor for the class,
one with a no argument and one with arguments pertaining to the class variables. 
Next we have a set of getter and setter methods for the class to either get
a value pertaining to variables or set a value for a specific variable. Lastly,
we have two methods to calculate other match statistics using variables such
as ratio between kills and deaths, the number of engagements a map, the
average pace of the player in the map, and a to string with information 
based on the single match. 
*/
{

    private int kills;                          // these are private variables
    private int deaths;                         // for player stats in the match.
    private int assists;                        // We have kills, deaths, assists,
    private int damage;                         // damage, if the player won the 
    private bool win;                           // match and their objective time.
    private int objective;

    public Match()
    /*
    This is the no argument constructor for this class. The constructor does
    not create the object to be used, it will initialize the objects state
    for use and alteration while ensuring the constructor works. In the no
    argument constructor, it will set all int values for the varaibles in
    the class to 0 and set win to false and this will initialize the object.
    */
    {
        kills = 0;
        deaths = 0;
        assists = 0;
        damage = 0;
        win = false;
        objective = 0;
    }

    public Match(int match_kills, int match_deaths, int match_assists, int match_damage, bool match_win, int match_obj)
    /*
    This is the second constructor for the Match object class, in this
    class, we will set the variables for all of the private variables
    in the class to a similar variable. This will allow for user input
    to create the Match class with specific values and better track what
    is needed for tailorized insights later one. Currently, this is just
    an Object to store match data for use in the future. 
    */
    {
        kills = match_kills;
        deaths = match_deaths;
        assists = match_assists;
        damage = match_damage;
        win = match_win;
        objective = match_obj;
    }

    public int getKills()
    /*
    These is not much to be said through a majority of these methods. 
    They are getters or setter which will return the value of the 
    specific variable called in the case of getters and allow
    for the value to be altered and changed in the case of setters. This
    getter returns the kills value input or created by the user. 
    */
    {
        return kills;
    }

    public int getDeaths()
    // This is a getter for the variable of deaths obtained in the match.
    {
        return deaths;
    }

    public int getAssists()
    // This is a getter for obtaining the assists variable in the program.
    {
        return assists;
    }

    public int getDamage()
    // This is a getter for obtaining the damage variable in the program.
    {
        return damage;
    }

    public bool getWin()
    // This is a getter for getting if the match was won or not in the program.
    {
        return win;
    }

    public int getObjective()
    // This is a getter for obtaining the objective score variable in the program.
    {
        return objective;
    }

    public void setKills(int match_kills)
    /*
    These are the setters within the program. In these setters, they will be able
    to modify the original value of the variable and change what value is returned
    by the getter functoins, this will be the setter for the variable kills. 
    */
    {
        kills = match_kills;
    }

    public void setDeaths(int match_deaths)
    // This is the setter for the death variable in the Match class
    {
        deaths = match_deaths;
    }

    public void setAssists(int match_assist)
    // This is the setter for the assists variable in the Match class
    {
        assists = match_assist;
    }

    public void setDamage(int match_damage)
    // This is the setter for the damage variable in the Match class
    {
        damage = match_damage;
    }

    public void setWin(bool match_win)
    // This is the setter for the win variable in the Match class
    {
        win = match_win;
    }

    public void setObjective(int match_obj)
    // This is the setter for the objective variable in the Match class
    {
        objective = match_obj;
    }

    public double calculateKD()
    /*
    This is our first standout method. In this method, we will be
    returning the ratio of kills to deaths in the match. The better
    the ratio returns, the better the performance typically is in game.
    */
    {
        if (deaths == 0)                        // checks to see if deaths is 0
            return (double)kills;               // if so, will just return kills
        return (double)kills / deaths;          // as ratio, if not it will perform
    }                                           // the ratio calculation

    public int calculateEngagements()
    /*
    In this method, we are adding the deaths and kills variables together
    in order to understand how many engagements the user got into during
    the match. This is used for pacing and some role calculations.
    */
    {
        return kills + deaths;                  // kills and deaths are added
    }

    public int calculatePace()
    /*
    This is the pace calculator, for this it will return either 1, 2, 3, or 4
    based on the engagements of the player, the general concept of this is 
    how many engagements the player gets into dictates the role of the player.
    The lower number in the pace calulation means the player is a slower on the map.
    */
    {
        if (calculateEngagements() <= 35)       // slowest possible pace alloed
            return 1;
        else if (calculateEngagements() <= 45)  // second slowest possible pace
            return 2;
        else if (calculateEngagements() <= 55)  // second fasted pace given
            return 3;
        else                                    // the fastest possible pace 
            return 4;   
    }

    public override string ToString()
    /*
    This is an override of the ToString method within C#, in this ToString,
    we will be returning the kills, deaths, assists, KD, damage, engagements, 
    and the pace of the player for that specific match. This will be printed. 
    */
    {
        return "Kills: " + getKills() +
               " Deaths: " + getDeaths() +
               " Assists: " + getAssists() +
               " KD: " + calculateKD().ToString("F2") +
               " Damage: " + getDamage() +
               " Engagements: " + calculateEngagements() +
               " Pace: " + calculatePace();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class Parliament
{
    public delegate void VotingHandler(string message);
    public event VotingHandler OnVoteStart;
    public event VotingHandler OnVoteEnd;
    
    private string title;

    // Add a dictionary to store the votes
    public Dictionary<int, int> Votes { get; private set; } = new Dictionary<int, int>();

    public void StartVoting(string title)
    {
        this.title = title;
        Console.WriteLine($"POCZATEK {this.title}");
        OnVoteStart?.Invoke("Voting has started.");
        // Clear the votes at the start of voting
        Votes.Clear();
    }

    public void EndVoting()
    {
        Console.WriteLine("KONIEC");
        OnVoteEnd?.Invoke($"Voting for has ended.");
        // Print the votes at the end of voting
        int votesFor = 0;
        int votesAgainst = 0;
        foreach (var vote in Votes.Keys.ToList())
        {
            if (Votes[vote] == 0)
            {
                votesAgainst++;
            }
            else if (Votes[vote] ==1)
            {
                votesFor++;
            }
            Votes[vote] = -1;
        }
        Console.WriteLine($"Votes for {this.title}: {votesFor}, against: {votesAgainst}");
    }
}

public class ParliamentMember
{
    private static Random rand = new Random();
    public int Name { get; private set; }
    private bool canVote;

    public ParliamentMember(int name, Parliament parliament)
    {
        Name = name;
        parliament.OnVoteStart += (message) => 
        {
            //Console.WriteLine($"{Name} heard: {message}");
            canVote = true;
        };
        parliament.OnVoteEnd += (message) => 
        {
            //Console.WriteLine($"{Name} heard: {message}");
            canVote = false;
        };
    }

    public void Vote(Parliament parliament)
    {
        if (!canVote)
        {
            Console.WriteLine($"{Name} cannot vote now.");
            return;
        }

        int vote = rand.Next(2);  // Randomly generates 0 or 1
        Console.WriteLine($"GŁOS {Name}: {vote}");
        
        // Store the vote in the Parliament's Votes dictionary
        parliament.Votes[Name] = vote;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Parliament parliament = new Parliament();
        //list was for testing purposes
        List<ParliamentMember> members = new List<ParliamentMember>
        {
            new ParliamentMember(1, parliament),
            new ParliamentMember(2, parliament),
            new ParliamentMember(3, parliament),
            new ParliamentMember(4, parliament),
            new ParliamentMember(5, parliament)
            // Add more members as needed
        };
        //dictionary of parialment members
        Dictionary<int, ParliamentMember> membersDict = new Dictionary<int, ParliamentMember>();
        foreach (var member in members)
        {
            membersDict.Add(member.Name, member);
        }
        
        string input = "";
        int result = -1;
        while (input!="EXIT")
        {
            Console.WriteLine("START title - Start voting");
            Console.WriteLine("END - End voting");
            Console.WriteLine("EXIT - Exit");
            Console.WriteLine("Enter a member number to vote");
            
            input = Console.ReadLine();
            Console.Clear();
            
            if ( input.Length >5 && input.Substring(0, 5) == "START")
            {
                parliament.StartVoting(input.Substring(6));
            }
            else if (input == "END")
            {
                parliament.EndVoting();
            }
            else if (int.TryParse(input, out result) && membersDict.ContainsKey(result))
            {
                membersDict[result].Vote(parliament);
            }
        }
        
        
       // foreach loops for automatic voting testing
       
         // foreach (var member in members)
         // {
         //     member.Vote(parliament);
         // }
         //
         // parliament.StartVoting("Witty Title");
         //
         // foreach (var member in members)
         // {
         //     member.Vote(parliament);
         // }
         // parliament.EndVoting();
         // foreach (var member in members)
         // {
         //     member.Vote(parliament);
         // }
    }
}
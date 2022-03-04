using System;
using System.Collections.Generic;

namespace IoBTMessage.Models;

/// <summary>
/// RandomName class, used to generate a random name.
/// </summary>
public class RandomName
{
    class NameList
    {
        public string[] first { get; set; }
        public string[] last { get; set; }

        public NameList()
        {
            first = new string[] {
                    "Thomas", "Casen", "Eric","Steve","Greg", "Sherman","Jason","Nathan","Matt","Mark","JB"
                };
            last = new string[] {
                    "North", "South", "East","West","Earth","Wind","Fire","Water"
                };
        }
    }

    Random rand;
    readonly List<string> First;
    readonly List<string> Last;

    public RandomName()
    {
        this.rand = new Random();
        var list = new NameList();

        First = new List<string>(list.first);
        Last = new List<string>(list.last);
    }

    public string GenerateName()
    {
        string first = First[rand.Next(First.Count)];
        string last = Last[rand.Next(Last.Count)];

        return $"{first}_{last}";
    }
}

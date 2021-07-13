using System;
using System.Collections.Generic;

namespace SiftMock
{
    class Program
    {
        static void Main()
        {
            List<SiftMember> sift = new List<SiftMember>();
            SiftMember me = new SiftMember("Riley Shirk", "Associate Program Manager",
                                                "rileyshirk@quickenloans.com", 11, 18, 2019);
            me.AddSkill("Programming");
            me.AddSkill("Writing Assessments");
            sift.Add(me);
            while (true)
            {
                Console.Write("Welcome to Sift, what would you like to do?\n");
                Console.Write("1. Add a team member\n2. Search for a team member\n3. Print all members\n4. Quit\n");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter the team member's name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter their job title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter their email: ");
                        string email = Console.ReadLine();
                        Console.Write("Enter their anniversary (MM dd yyyy): ");
                        string date = Console.ReadLine();
                        string[] d = date.Split(" ");
                        int month = int.Parse(d[0]);
                        int day = int.Parse(d[1]);
                        int year = int.Parse(d[2]);
                        
                        sift.Add(new SiftMember(name, title, email, month, day, year));
                        break;
                    case 2:
                        Console.Write("Enter the full name of the person you'd like to search for: ");
                        string nameToSearch = Console.ReadLine();
                        
                        int index = Search(sift, nameToSearch);
                        if (index > -1)
                        {
                            while (true)
                            {
                                Console.Write("Enter a skill, enter 'q' to stop adding skills: ");
                                string skill = Console.ReadLine();
                                if (skill == "q")
                                {
                                    break;
                                }
                                else if (sift[index].AddSkill(skill))
                                {
                                    Console.WriteLine($"Added {skill} to {sift[index].Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"{skill} is already a skill for {sift[index].Name}");
                                }
                            }
                        }
                        break;
                    case 3:
                        PrintSift(sift);
                        break;
                    case 4:
                        return;
                }
            }
        }
        public static int Search(List<SiftMember> l, string nameToSearch)
        {
            for(int i = 0; i < l.Count; i++)
            {
                if (l[i].Name == nameToSearch)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void PrintSift(List<SiftMember> l)
        {
            foreach (SiftMember s in l)
            {
                Console.WriteLine(s);
            }
        }
    }

}
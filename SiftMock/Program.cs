using System;
using System.Collections.Generic;

namespace SiftMock
{
    class Program
    {
        static void Main()
        {
            List<SiftMember> siftMembers = new List<SiftMember>();
            SiftMember tm = new SiftMember("Jane",new DateTime(2016,02,19), "Program Manager", "jane@rocket.com");
            tm.AddSkill("Programming");
            tm.AddSkill("Writing Assessments");
            siftMembers.Add(tm);
            
            
            
            while (true)
            {
                Console.Write("[1]Add a team member [2]Search for a team member [3]Print all members [4]Quit: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the team member's name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter their job title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter their email: ");
                        string email = Console.ReadLine();
                        
                        Console.Write("Anniversary Month: ");
                        int anniversaryMonth = int.Parse(Console.ReadLine());
                        
                        Console.Write("Anniversary Day: ");
                        int anniversaryDay = int.Parse(Console.ReadLine());

                        Console.Write("Anniversary Year: ");
                        int anniversaryYear = int.Parse(Console.ReadLine());

                        siftMembers.Add(new SiftMember(name, new DateTime(anniversaryYear,anniversaryMonth,anniversaryDay),title,email));
                        break;
                    
                    case "2":
                        Console.Write("Enter the full name of the person you'd like to search for: ");
                        string nameToSearch = Console.ReadLine();

                        SiftMember returnedTM = Search(siftMembers, nameToSearch);

                        if ( returnedTM != null)
                        {
                            while (true)
                            {
                                Console.Write("Enter a skill, enter 'q' to stop adding skills: ");
                                string skill = Console.ReadLine();
                                if (skill == "q")
                                {
                                    break;
                                }

                                if (returnedTM.AddSkill(skill))
                                {
                                    Console.WriteLine($"Added {skill} to {returnedTM.Name}");
                                }
                                else
                                {
                                    Console.WriteLine($"{skill} is already a skill for {returnedTM.Name}");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Team member was not found.");
                        }

                        break;
                    case "3":
                        foreach (var teamMember in siftMembers)
                        {
                            Console.WriteLine(teamMember.ToString());
                        }
                        break;
                    case "4":
                        return;
                }
            }
        }
        public static SiftMember Search(List<SiftMember> listOfSiftMembers, string nameToSearch)
        {
            foreach (var member in listOfSiftMembers)
            {
                if (member.Name.ToLower() == nameToSearch.ToLower())
                {
                    return member;
                }
            }
            return null;
        }
        
    }

}
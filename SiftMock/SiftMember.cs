using System;
using System.Collections.Generic;
using System.Text;

namespace SiftMock
{
    class SiftMember
    {
        private string name;
        private DateTime anniversary;
        private string jobTitle;
        private string email;
        private List<string> skills;

        public SiftMember(string n, string j, string e, int month, int day, int year)
        {
            name = n;
            jobTitle = j;
            email = e;
            anniversary = new DateTime(year, month, day);
            skills = new List<string>();
        }

        public string Name { get => name; }

        public bool AddSkill(string skill)
        {
            if (!skills.Contains(skill))
            {
                skills.Add(skill);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string output = $"Name: {name}\nJob Title: {jobTitle}\nAnniversary: {anniversary.ToString("MM/dd/yyyy")}\nEmail: {email}\nSkills: ";
            foreach (string s in skills)
            {
                output += $"{s}\t";
            }
            output += "\n\n";
            return output;
        }
    }
}
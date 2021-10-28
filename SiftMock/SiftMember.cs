using System;
using System.Collections.Generic;
using System.Text;

namespace SiftMock
{
    class SiftMember
    {
        public string Name { get; set; }
        public DateTime Anniversary { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public List<string> Skills { get; set; }

        public SiftMember(string name, DateTime anniversary, string jobTitle, string email)
        {
            Name = name;
            Anniversary = anniversary;
            JobTitle = jobTitle;
            Email = email;
            Skills = new List<string>();
        }
    
        
        public bool AddSkill(string skill)
        {
            if (!Skills.Contains(skill))
            {
                Skills.Add(skill);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            string output = $"Name: {Name}\nJob Title: {JobTitle}\nAnniversary: {Anniversary.ToString("MM/dd/yyyy")}\nEmail: {Email}\nSkills: ";
            foreach (string skill in Skills)
            {
                output += $"{skill}\t";
            }
            output += "\n\n";
            return output;
        }
    }
}
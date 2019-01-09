using System;
using System.Collections.Generic;
using System.Text;

namespace InnoLib
{
    public class Project
    {
        private int _id;
        private string _projectName;
        private string _category;
        private int _points;

        public Project()
        {
            
        }

        public Project(int id, string projectName, string category, int points)
        {
            _id = id;
            ProjectName = projectName;
            _category = category;
            Points = points;
        }

        public int Id { get => _id; set => _id = value; }

        public string ProjectName
        {
            get { return _projectName; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentException("Projektnavn skal være mindst 4 karakterer langt");
                }
                _projectName = value;
            } 
        }
        public string Category { get => _category; set => _category = value; }

        public int Points
        {
            get { return _points; }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Points kan ikke være lavere end 0 eller højere end 100");
                }
                _points = value;
            }
        }

        public bool MyPoints(int points)
        {
            if (points > -1 && points < 101)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"ID: {Id}, ProjectName: {ProjectName}, ProjectCategory: {Category}, Points: {Points}";
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnoLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private static List<Project> _projects = new List<Project>()
        { new Project(1, "RengøringsRobot", "Hjem", 60),
          new Project(2, "GræsslåningsRobot", "Have", 50),
          new Project(3, "Havevanding9001", "Have", 97) };

        private static List<Project> _sortedList = new List<Project>();
        private static List<string> _categories = new List<string>();
    

        // GET: api/Projects
        [HttpGet]
        public List<Project> GetProjects()
        {
            _sortedList = _projects.OrderByDescending(p => p.Points).ToList();
            return _sortedList;
        }


        // GET: api/Projects/5
        [HttpGet("{id}")]
        public Project GetProjectById(int id)
        {
            foreach (Project project in _projects)
            {
                if (project.Id == id)
                {
                    return project;
                }
            }
            return null;
        }

        // POST: api/Projects
        [HttpPost]
        public void Post([FromBody] Project project)
        {
            _projects.Add(project);
        }

        
    }
}

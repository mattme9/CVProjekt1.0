using CVProjekt1._0.Models;

namespace CVProjekt1._0.TestData
{
    public static class TestDataGenerator
    {
        public static List<User> GetUsers()
        {
            return new List<User>
            {
                new User { UserId = "1", UserName = "ExampleUser1", ProfilePicturePath = "/images/birde.jpg" },
                new User { UserId = "2", UserName = "ExampleUser2", ProfilePicturePath = "/images/strangeBirde.jpg" },
                
            };
        }

        public static List<Education> GetEducations()
        {
            return new List<Education>
            {
                new Education { EducationId = 1, ResumeId = 1, EducationType = "Bachelor's in Computer Science" },
                new Education { EducationId = 2, ResumeId = 2, EducationType = "Master's in Business Administration" }
            };
        }

        public static List<Experience> GetExperiences()
        {
            return new List<Experience>
            {
                new Experience { ExperienceId = 1, ResumeId = 1, ExperienceDescription = "Software Engineer" },
                new Experience { ExperienceId = 2, ResumeId = 2, ExperienceDescription = "Project Manager" }
            };
        }

        public static List<Skill> GetSkills()
        {
            return new List<Skill>
            {
                new Skill { SkillId = 1, ResumeId = 1, SkillName = "C#", SkillDescription = "C# blablabla" },
                new Skill { SkillId = 2, ResumeId = 2, SkillName = "Project Management", SkillDescription = "ProjectManagement blablabla" }
            };
        }

        public static List<Project> GetProjects()
        {
            return new List<Project>
            {
                new Project { ProjectId = 1, Title = "InnovateHub: Empowering Collaboration for Innovative Solutions", 
                    Description = "InnovateHub is a dynamic platform that brings together creative minds from diverse backgrounds to collaborate on cutting-edge projects. Whether you're a developer, designer, or business strategist, join us in shaping the future. Explore exciting challenges, share your expertise, and contribute to building solutions that make a positive impact. Together, let's redefine innovation!", 
                    CreatorId = "1" },
                new Project { ProjectId = 2, Title = "GreenScape: Sustainable Living App", 
                    Description = "GreenScape is an innovative mobile application aimed at promoting sustainable living practices. This project invites users to adopt eco-friendly habits, track their environmental impact, and connect with like-minded individuals. From carbon footprint tracking to sharing eco-tips, GreenScape empowers users to make positive contributions towards a greener planet. Join us on this journey towards a sustainable future!", 
                    CreatorId = "2" }
            };
        }

        public static List<Resume> GetResumes()
        {
            var resumes = new List<Resume>
            {
                new Resume { ResumeId = 1, UserId = "1", Description = "Passionate software developer with expertise in web application development. Proficient in technologies such as ASP.NET Core, JavaScript, and React. Experienced in full-stack development and dedicated to delivering high-quality, scalable solutions." },
                new Resume { ResumeId = 2, UserId = "2", Description = "Results-driven marketing professional with a proven track record in digital marketing and social media management. Skilled in creating engaging content, analyzing marketing data, and implementing successful campaigns. A creative thinker with a strong focus on achieving business objectives." }
            };

            foreach(var resume in resumes)
            {
                resume.Skills = GetSkills().Where(skill => skill.ResumeId == resume.ResumeId).ToList();
            }

            return resumes;
        }

        public static List<ProjectUser> GetProjectUsers()
        {
            return new List<ProjectUser>
            {
                new ProjectUser { ProjectId = 1, UserId = "1" },
                new ProjectUser { ProjectId = 2, UserId = "2" }
            };
        }
    }

}

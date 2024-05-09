using AdvancedTaskPart2SpecFlowProject.DataModel;
using Newtonsoft.Json;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.Utilities
{
    public class JSONReader
    {
        public string jsonFilePath;
        public JSONReader()
        {
            jsonFilePath = string.Empty;
        }

        public List<ChangePasswordDM> ReadPJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<ChangePasswordDM> changePasswordList = JsonConvert.DeserializeObject<List<ChangePasswordDM>>(json)!;
            return changePasswordList;
        }
        public List<EducationDM> ReadEJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<EducationDM> educationList = JsonConvert.DeserializeObject<List<EducationDM>>(json)!;
            return educationList;
        }
        public List<ShareSkillDM> ReadShareSkillJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<ShareSkillDM> shareSkillsList = JsonConvert.DeserializeObject<List<ShareSkillDM>>(json)!;
            return shareSkillsList;
        }

        public List<CertificationDM> ReadCertificationJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<CertificationDM> certificationList = JsonConvert.DeserializeObject<List<CertificationDM>>(json)!;
            return certificationList;
        }
        public List<LoginDM> ReadLoginJsonData()
        {
            using StreamReader reader = new(jsonFilePath);
            var json = reader.ReadToEnd();

            List<LoginDM> loginInfo = JsonConvert.DeserializeObject<List<LoginDM>>(json)!;
            return loginInfo;
        }
        public void SetDataPath(string testDataPath)
        {
            string path = Assembly.GetCallingAssembly().Location;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            jsonFilePath = projectPath + testDataPath;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskPart2SpecFlowProject.DataModel
{
    public class ChangePasswordDM
    {
        public string currentPassword { get; set; } = string.Empty;
        public string newPassword { get; set; } = string.Empty;
        public string confirmPassword { get; set; } = string.Empty;



    }
}

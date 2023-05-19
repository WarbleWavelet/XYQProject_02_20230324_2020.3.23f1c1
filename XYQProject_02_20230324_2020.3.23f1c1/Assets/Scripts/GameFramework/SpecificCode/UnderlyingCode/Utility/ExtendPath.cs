using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class ExtendPath
    {
        public static string GetSkillPath(ActObj actObj)
        {
            return "Skills/" + actObj.skillInfo.sectName + "/" + actObj.skillInfo.pathName;

        }
    }

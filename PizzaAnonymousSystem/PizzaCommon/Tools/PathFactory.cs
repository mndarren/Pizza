using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCommon.Tools
{
    public static class PathFactory
    {
        public static string SolutionPath()
        {
            var solutionPath = "";
            var currentDirectory = System.Environment.CurrentDirectory;

            var dirSplit = currentDirectory.Split(new string[] { "PizzaAnonymousSystem" }, StringSplitOptions.None);
            solutionPath = dirSplit[0] + "PizzaAnonymousSystem";

            return solutionPath;
        }

        public static string DatabasePath()
        {
            return System.IO.Path.Combine(PathFactory.SolutionPath(), "PizzaRepository\\App_Data");
        }
    }
}

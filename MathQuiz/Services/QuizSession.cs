using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuiz.Services
{
    public static class QuizSession
    {
        public static int TargetScore { get; set; } = 5;
        public static string userName { get; set; } = "nameOfStudent";

        public static Dictionary<string, int> ModuleScores { get; set; } = new Dictionary<string, int>();

        public static int GetTotalScores()
        {
            return ModuleScores.Values.Sum();
        }

        public static void AddPoint(string moduleName)
        {
            if (ModuleScores.ContainsKey(moduleName))
            {
                ModuleScores[moduleName]++;
            }
            else
            {
                ModuleScores[moduleName] = 1;
            }
        }

        public static void SubPoint(string moudleName)
        {
            if (ModuleScores.ContainsKey(moudleName))
            {
                ModuleScores[moudleName]--;
            }
            else
            {
                ModuleScores[moudleName] = -1;
            }
        }
        public static void ResetSession()
        {
            ModuleScores.Clear();
        }
    }
}

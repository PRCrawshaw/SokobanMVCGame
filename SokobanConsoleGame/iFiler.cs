using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanConsoleGame
{
    public interface iFiler
    {
        void Save(string filename, iFileable callMeBackforDetails);
        string Load(string filename);
    }
}

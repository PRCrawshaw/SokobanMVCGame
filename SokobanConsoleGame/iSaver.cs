using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public interface iSaver
    {
        string Save(string filename, string text);
    }
}

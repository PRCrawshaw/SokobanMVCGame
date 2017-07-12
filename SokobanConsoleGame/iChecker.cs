using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SokobanGame
{
    public interface iChecker
    {
        bool PreExpandingCheck(string input);
        bool PreCompressingCheck(string input);
    }
}

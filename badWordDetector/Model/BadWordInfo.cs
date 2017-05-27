using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace badWordDetector.Model
{
    public class BadWordInfo
    {
        public int StartIndex { get; set; }
        public int Length { get; set; }

        public BadWordInfo(int startIndex, int length)
        {
            StartIndex = startIndex;
            Length = length;
        }
    }
}

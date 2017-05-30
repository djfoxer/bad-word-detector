using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace badWordDetector.Model
{
    public class RegexInfo
    {
        public bool IsActive { get; set; }

        public List<Regex> Regex { get; set; }
    }
}

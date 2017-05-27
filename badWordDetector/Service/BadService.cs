using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace badWordDetector.Service
{
    public class BadService
    {
        private BadService()
        {
            LoadBadList();
        }

        private void LoadBadList()
        {
            TextReader tr = File.OpenText("./Data/bad.en.txt");
            BadList = tr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public List<Tuple<int, int>> BadWordsDetails(string input)
        {
            if (input != null && OnlyAlphaRegex.IsMatch(input))
            {
                List<Tuple<int, int>> indexList = new List<Tuple<int, int>>();
                BadList.ForEach(bad =>
                {
                    var badMatch = Regex.Match(input, @"\b" + bad + @"\b", RegexOptions.IgnoreCase);
                    while (badMatch.Success)
                    {
                        indexList.Add(new Tuple<int, int>(badMatch.Index, bad.Length));
                        badMatch = badMatch.NextMatch();
                    }

                });
                return indexList.Any() ? indexList : null;
            }
            return null;
        }

        private Regex OnlyAlphaRegex = new Regex(@"[a-zA-Z]", RegexOptions.Compiled);

        private List<string> BadList { get; set; }

        private static BadService _service { get; set; }

        public static BadService Instance
        {
            get
            {
                if (_service == null)
                {
                    _service = new BadService();
                }
                return _service;
            }
        }
    }
}

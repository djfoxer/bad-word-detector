using badWordDetector.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace badWordDetector.Service
{
    public class BadService
    {
        private void InitBadService()
        {
            BadListRegex = new List<Regex>();
            if (EnableEnglishBadList)
                LoadBadList("en");
            if (EnablePolishBadList)
                LoadBadList("pl");
        }

        private void LoadBadList(string languageCode)
        {

            TextReader tr = File.OpenText("./Data/bad." + languageCode + ".txt");
            var badList = tr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            BadListRegex.AddRange(badList.Select(bad => new Regex(@"\b" + bad + @"\b", RegexOptions.IgnoreCase | RegexOptions.Compiled)));
        }

        public List<BadWordInfo> BadWordsDetails(string input)
        {
            if (BadListRegex == null)
            {
                InitBadService();
            }

            if (input != null && OnlyAlphaRegex.IsMatch(input))
            {
                List<BadWordInfo> indexList = new List<BadWordInfo>();
                BadListRegex.ForEach(badRegex =>
                {
                    var badMatch = badRegex.Match(input);
                    while (badMatch.Success)
                    {
                        indexList.Add(new BadWordInfo(badMatch.Index, badMatch.Length));
                        badMatch = badMatch.NextMatch();
                    }

                });
                return indexList.Any() ? indexList : null;
            }
            return null;
        }

        private Regex OnlyAlphaRegex = new Regex(@"[a-zA-Z]", RegexOptions.Compiled);

        private List<Regex> BadListRegex { get; set; }

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

        public bool EnablePolishBadList { get; set; }

        public bool EnableEnglishBadList { get; set; }
    }
}

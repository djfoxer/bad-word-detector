using badWordDetector.Helper;
using badWordDetector.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace badWordDetector.Service
{
    public class BadService
    {
        private BadService()
        {
            BadRegexData = new Dictionary<LanguageEnum, RegexInfo>();
            foreach (var lang in Enum.GetValues(typeof(LanguageEnum)).Cast<LanguageEnum>())
            {
                LoadBadList(lang);
            }
        }

        private void LoadBadList(LanguageEnum language)
        {
            if (!BadRegexData.ContainsKey(language))
            {
                TextReader tr = File.OpenText(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data", $"bad.{(int)language}.txt"));
                var badList = tr.ReadToEnd().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
                BadRegexData.Add(language, new RegexInfo() { IsActive = false, Regex = badList.Select(bad => new Regex(@"\b" + bad + @"\b", RegexOptions.IgnoreCase | RegexOptions.Compiled)).ToList() });
            }
        }

        public List<BadWordInfo> BadWordsDetails(string input)
        {
            if (input != null && OnlyAlphaRegex.IsMatch(input))
            {
                List<BadWordInfo> indexList = new List<BadWordInfo>();
                foreach (var lang in Enum.GetValues(typeof(LanguageEnum)).Cast<LanguageEnum>())
                {
                    if (BadRegexData.ContainsKey(lang))
                    {
                        var regexInfo = BadRegexData[lang];
                        if (regexInfo.IsActive)
                        {
                            regexInfo.Regex.ForEach(badRegex =>
                            {
                                var badMatch = badRegex.Match(input);
                                while (badMatch.Success)
                                {
                                    indexList.Add(new BadWordInfo(badMatch.Index, badMatch.Length));
                                    badMatch = badMatch.NextMatch();
                                }

                            });
                        }
                    }
                }
                return indexList.Any() ? indexList : null;
            }
            return null;
        }

        private Regex OnlyAlphaRegex = new Regex(@"[a-zA-Z]", RegexOptions.Compiled);

        private Dictionary<LanguageEnum, RegexInfo> BadRegexData { get; set; }

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

        public void SetLanguageCheckActive(LanguageEnum language, bool isActive)
        {
            BadRegexData[language].IsActive = isActive;
        }
    }
}

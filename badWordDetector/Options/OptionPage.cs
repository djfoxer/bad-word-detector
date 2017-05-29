using badWordDetector.Helper;
using badWordDetector.Service;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace badWordDetector.Options
{
    public class OptionPage : DialogPage
    {
        public OptionPage()
        {
            EnablePolishBadList = false;
            EnableEnglishBadList = true;
        }

        private bool _EnablePolishBadList { get; set; }
        [Category(Consts.BasicOptions)]
        [DisplayName(Consts.OptionsPlEnableText)]
        [Description(Consts.OptionsPlEnableDescription)]
        public bool EnablePolishBadList
        {
            get { return _EnablePolishBadList; }
            set
            {
                _EnablePolishBadList = value;
                BadService.Instance.EnablePolishBadList = value;
            }
        }

        private bool _EnableEnglishBadList { get; set; }
        [Category(Consts.BasicOptions)]
        [DisplayName(Consts.OptionsEnEnableText)]
        [Description(Consts.OptionsEnEnableDescription)]
        public bool EnableEnglishBadList
        {
            get { return _EnableEnglishBadList; }
            set
            {
                _EnableEnglishBadList = value;
                BadService.Instance.EnableEnglishBadList = value;
            }
        }
    }
}

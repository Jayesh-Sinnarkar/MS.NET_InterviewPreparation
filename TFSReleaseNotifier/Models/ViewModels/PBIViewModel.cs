using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFSReleaseNotifier.Models.ViewModels
{
    public class PBIViewModel
    {
        public int WorkItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
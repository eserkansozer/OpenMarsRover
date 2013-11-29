using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarsRoverUI.Models
{
    
    public class ViewModel
    {
        private string input;
        public string Input
        {
            get { return input; }
            set { input = value; }
        }
        
        private string output;
        public string Output
        {
            get { return output; }
            set { output = value; }
        }

        private string track;
        public string Track
        {
            get { return track; }
            set { track = value; }
        }

        private string longest;
        public string Longest
        {
            get { return longest; }
            set { longest = value; }
        }

    }
}
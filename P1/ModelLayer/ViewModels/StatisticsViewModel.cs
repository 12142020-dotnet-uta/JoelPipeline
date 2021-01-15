using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class StatisticsViewModel
    {   [Display(Name ="Guitars")]
        public int GuitarP  { get; set; }
        [Display(Name = "Guitar Cases")]
        public int CaseP { get; set; }
        [Display(Name = "Amplifiers")]
        public int AmplifierP { get; set; }
        [Display(Name = "Guitar Strings")]
        public int StringsP { get; set; }


        public StatisticsViewModel()
        {

        }
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OOPR.Services.Enums
{
    public enum GradeEnum
    {
        [Display(Name = "Pet")]
        Five = 5,

        [Display(Name = "Sest")]
        Six = 6,

        [Display(Name = "Sedam")]
        Seven = 7,

        [Display(Name = "Osam")]
        Eight = 8,

        [Display(Name = "Devet")]
        Nine = 9,

        [Display(Name = "Deset")]
        Ten = 10
    }
}

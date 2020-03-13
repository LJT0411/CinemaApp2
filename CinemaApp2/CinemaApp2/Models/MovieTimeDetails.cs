using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp2.Models
{
    public class MovieTimeDetails
    {
        public int MovieTimeID { get; set; }

        public DateTime MovieTimeStart { get; set; }

        public int MovieHallID { get; set; }

        public int MovieID { get; set; }
    }
}

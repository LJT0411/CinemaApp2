using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp2.Models
{
    public class MovieSeatDetails
    {
        public int SeatID { get; set; }

        public string SeatNo { get; set; }

        public SAvail SeatAvail { get; set; }

        public int MovieTimeID { get; set; }
    }
    public enum SAvail
    {
        E, T
    }
}

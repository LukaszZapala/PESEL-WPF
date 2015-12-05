using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESEL.ViewModel
{
    class Decoding
    {
        public int Year(string _string)
        {
            string year = null, month = null;

            for (int i = 0; i < 4; i++)
            {
                if (i < 2) year += _string[i];
                else month += _string[i];
            }

            if (int.Parse(month) > 0 && int.Parse(month) < 13) return 1900 + int.Parse(year);
            if (int.Parse(month) > 20 && int.Parse(month) < 33) return 2000 + int.Parse(year);

            return 1889;
        }

        public int Month(string _string)
        {
            string month = null;

            for (int i = 2; i < 4; i++)
            {
                month += _string[i];
            }

            if (int.Parse(month) > 0 && int.Parse(month) < 13) return int.Parse(month);
            if (int.Parse(month) > 20 && int.Parse(month) < 33) return int.Parse(month) - 20;

            return 13;
        }

        public int Day(string _string)
        {
            string day = null;

            for (int i = 4; i < 6; i++)
            {
                day += _string[i];
            }

            return int.Parse(day);
        }

        public string Sex(string _string)
        {
            return int.Parse(_string[9].ToString()) % 2 != 0 ? "Mężczyzna" : "Kobieta";
        }

        public int ControlNumber(string _string)
        {
            return int.Parse(_string[10].ToString());
        }

    }
}

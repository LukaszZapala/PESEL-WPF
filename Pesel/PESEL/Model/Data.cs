using PESEL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESEL.Model
{
    class Data
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Sex { get; set; }
        public int ControlNumber { get; set; }

        public void UpdateProperties(string _string)
        {
            if (_string.Length == 11)
            {
                Decoding dekoder = new Decoding();

                this.Year = dekoder.Year(_string);
                this.Month = dekoder.Month(_string);
                this.Day = dekoder.Day(_string);
                this.Sex = dekoder.Sex(_string);
                this.ControlNumber = dekoder.ControlNumber(_string);
            }
        }

        // Czy rok jest prawidłowy ?
        public bool WhetherYearIsCorrect()
        {
            return Year < 1900 ? false : true;
        }

        // Czy liczba kontrolna się zgadza ?
        public bool WhetherControlNumerIsCorrect(string _string)
        {
            if (_string.Length == 11)
            {
                int sum = 0, controlNumber = 0;

                for (int i = 0; i < _string.Length - 1; i++)
                {
                    if (i == 0 || i == 4 || i == 8) sum += int.Parse(_string[i].ToString()) * 1;
                    if (i == 1 || i == 5 || i == 9) sum += int.Parse(_string[i].ToString()) * 3;
                    if (i == 2 || i == 6) sum += int.Parse(_string[i].ToString()) * 7;
                    if (i == 3 || i == 7) sum += int.Parse(_string[i].ToString()) * 9;
                }

                controlNumber = 10 - (sum % 10);

                return this.ControlNumber == controlNumber ? true : false;
            }
            return false;
        }

        // Czy miesiąc jest prawidłowy ?
        public bool WhetherMonthIsCorrect()
        {
            return Month > 0 && Month < 13 ? true : false;
        }

        // Czy dzień jest prawidłowy ?
        public bool WhetherDayIsCorrect()
        {
            switch (Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    if (Day > 0 && Day < 31) return true;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    if (Day > 0 && Day < 30) return true;
                    break;
                case 2:
                    if (Day > 0 && Day < 29) return true;
                    break;
            }

            return false;
        }

        public bool WhetherDataIsCorrect(string _string)
        {
            UpdateProperties(_string);
            return WhetherYearIsCorrect() && WhetherControlNumerIsCorrect(_string) && WhetherMonthIsCorrect() && WhetherDayIsCorrect();
        }
    }
}

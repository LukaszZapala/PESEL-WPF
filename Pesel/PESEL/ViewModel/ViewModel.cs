using PESEL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PESEL.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public Data data = new Data();

        public int Year
        {
            get
            {
                return data.Year;
            }
        }
        public string Month
        {
            get
            {
                switch (data.Month)
                {
                    case 1:
                        return "Styczeń";
                    case 2:
                        return "Luty";
                    case 3:
                        return "Marzec";
                    case 4:
                        return "Kwiecień";
                    case 5:
                        return "Maj";
                    case 6:
                        return "Czerwiec";
                    case 7:
                        return "Lipiec";
                    case 8:
                        return "Sierpień";
                    case 9:
                        return "Wrzesień";
                    case 10:
                        return "Październik";
                    case 11:
                        return "Listopad";
                    case 12:
                        return "Grudzień";
                    default:
                        return null;
                }
            }
        }
        public int Day
        {
            get
            {
                return data.Day;
            }
        }
        public string Sex
        {
            get
            {
                return data.Sex;
            }
        }
        public int ControlNumber
        {
            get
            {
                return data.ControlNumber;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool WhetherStringIsCorrect(string _string)
        {
            if (string.IsNullOrWhiteSpace(_string)) return false;
            if (_string.Length != 11) return false;
            decimal liczba;
            if (!decimal.TryParse(_string, out liczba)) return false;
            else return data.WhetherDataIsCorrect(_string);
        }

        private ICommand changeCommand;

        public void Change(object argument)
        {
            string _string = argument.ToString();
            if (WhetherStringIsCorrect(_string))
            {
                data.UpdateProperties(_string);

                OnPropertyChanged("Year");
                OnPropertyChanged("Month");
                OnPropertyChanged("Day");
                OnPropertyChanged("Sex");
                OnPropertyChanged("ControlNumber");
            }
        }

        public ICommand ChangeCommand
        {
            get
            {
                if (changeCommand == null)
                {
                    changeCommand = new RelayCommand(
                        (object argument) =>
                        {
                            try
                            {
                                Change(argument);

                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message, "PESEL", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        },
                        (object argument) =>
                        {
                            return WhetherStringIsCorrect((string)argument);
                        }
                        );
                }
                return changeCommand;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UserClnd
{
    //readonly треба ініціалізувати в конструкторі. тоді не виходить  змінити поля персон в цьому класі  => з рідонлі не вийде. Повертаємось до варіанту "??"
    class UserApplicationView : INotifyPropertyChanged
    {

      
        
            public event PropertyChangedEventHandler PropertyChanged;

            private Person _user = new Person();
            
            public String Name
            {
            get
            {
                return _user.Name;
            }

            set
            {

                _user.Name = value;
              
            }

             }

        public string Mail
        {
            get
            {

                return _user.Mail;

            }
            set
            {

                _user.Mail = value;

                
            }
        }
        public string Surname
        {
            get
            {

                return _user.Surname;

            }
            set
            {

                _user.Surname = value;

               
            }
        }

        public DateTime Birthdate
            {
                get {
                   
                    return _user.Birthdate;
                   
                }
                set
                {
                   
                    _user.Birthdate = value;
                    
                    
                }
            }
         
            public bool? IsAdult
        {
            get
            {
                return _user.IsAdult;

            }
         
        }

        public bool? IsBirthday
        {
            get
            {
               
                return _user.IsBirthday;

            }
           
        }
            public String WesternZodiac
            {
                get
                {
                    return _user.SunSign;

                }
               
            }
            public String ChineseZodiac
            {
                get
                {
                return _user.ChineseSign;
                     
                }
                
            }


            private String[] WestAstrology = {
            "Aries",
            "Taurus" ,
            "Gemini" ,
            "Cancer" ,
            "Leo"  ,
            "Virgo" ,
            "Libro",
            "Scorpion" ,
            "Sagittarius" ,
            "Capricorn" ,
            "Aquarius" ,
            "Pisces"
        };

          
            

            private string[] ChineAstrology = {
            "Rat",
            "Ox" ,
            "Tiger" ,
            "Rabbit" ,
            "Dragon"  ,
            "Snake" ,
            "Horse",
            "Sheep" ,
            "Monkey" ,
            "Rooster" ,
            "Dog" ,
            "Pig"
        };

            private RelayCommand _calculateCommand;
            public RelayCommand CalculateCommand
            {
                get
                {



                  
                    
                    return _calculateCommand ??
                        (_calculateCommand = new RelayCommand(_ => calculateAll(_user.Birthdate), CanExecute));

                  
                }
            }

            private void calculateAll(DateTime dateTime)
            {

                
                OnPropertyChanged("Birthdate");
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("ChineseZodiac");
                OnPropertyChanged("WesternZodiac");
                OnPropertyChanged("Mail");
                OnPropertyChanged("Name");
                OnPropertyChanged("Surname");
            
        }

          

            

            private bool CanExecute(object obj)
            {
                return Birthdate != DateTime.MinValue && Mail != "" && Name != "" && Surname != "" ;
            }

            
                



            
            public void OnPropertyChanged([CallerMemberName] string prop = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



    
}

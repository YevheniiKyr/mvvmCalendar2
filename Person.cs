using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserClnd
{
    class Person
    {
        private string _name;
        private string _surname;
        private DateTime _birthdate;
        private string _mail;
        private bool? _isAdult;
        private string _chineseSign;
        private bool? _isBirthday;
        private string _sunSign;

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

        public string Name
        {
            get
            {


                return _name;
            }
            set
            {
                _name = value;
            }

        }


        public string Surname
        {
            get
            {


                return _surname;
            }
            set
            {
                _surname = value;
            }

        }

        public string Mail
        {
            get
            {

                return _mail;
            }
            set
            {
                _mail = value;
            }

        }

        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                _isAdult = null;
                _chineseSign = null;
                _sunSign = null;
                _isBirthday = null; 
            }
        }

        public bool IsAdult
        {
            get
            {
                
             
                return (bool)(_isAdult ?? (_isAdult = Task.Run(() => isAdult()).Result));
                
            }

        }


        public string ChineseSign
        {
            get
            {
                //  return _chineseSign;
                return _chineseSign ?? (_chineseSign = Task.Run(() => chineseSign(_birthdate)).Result);
            }

        }

        public bool IsBirthday
        {
            get
            {
                return (bool)(_isBirthday ?? (_isBirthday = Task.Run(() => isBirthday()).Result));
            }
            // return DateTime.Now == _birthday;


        }
        public string SunSign
        {


            get
            {
                return _sunSign ?? (_sunSign = Task.Run(() => sunSign(_birthdate)).Result);

            }

        }


        public Person()
        {

        }
        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _mail = email;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _birthdate = birthday;
        }

        public Person(string name, string surname, string email, DateTime birthday)
        {
            _name = name;
            _surname = surname;
            _mail = email;
            _birthdate = birthday;
            // _isAdult = isAdult();
            // _isBirthday = isBirthday();
            // _chineseSign = chineseSign(_birthdate);
        }

        
        private Boolean isAdult()
        {
            if (DateTime.Now.Year > _birthdate.Year + 18) return true;
            if (DateTime.Now.Year == _birthdate.Year + 18)
            {
                if (DateTime.Now.Month > _birthdate.Month)
                {
                    return true;
                }
                if (DateTime.Now.Month == _birthdate.Month)
                {
                    return (DateTime.Now.Day) >= _birthdate.Day;
                }

            }
            return false;
        }

        private string chineseSign(DateTime dateTime)
        {
            int countYear = Math.Abs(dateTime.Year - 4) % 12;

            return ChineAstrology[countYear];

        }

        public bool isBirthday()
        {

            return DateTime.Now == _birthdate;

        }

        private async Task<string> sunSignAsync(DateTime date)
        {

            var sunsign = await Task.Run(() => sunSign(date));
         
            return sunsign;


        }

        private  string sunSign(DateTime date)
        {

            int day = date.Month * 100 + date.Day;
            string sunsign = "";
            switch (day)
            {
                case < 22:
                    return WestAstrology[8];


                case < 121:
                    sunsign = WestAstrology[9];
                    break;
                case < 221:
                    sunsign = WestAstrology[10];
                    break;
                case < 321:
                    sunsign = WestAstrology[11];
                    break;
                case < 421:
                    sunsign = WestAstrology[0];
                    break;
                case < 522:
                    sunsign = WestAstrology[1];
                    break;
                case < 622:
                    sunsign = WestAstrology[2];
                    break;
                case < 723:
                    sunsign = WestAstrology[3];
                    break;
                case < 824:
                    sunsign = WestAstrology[4];
                    break;
                case < 923:
                    sunsign = WestAstrology[5];
                    break;
                case < 1024:
                    sunsign = WestAstrology[6];
                    break;
                case < 1123:
                    sunsign = WestAstrology[7];
                    break;

            }

            return sunsign;


        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Course
    {
        private TypeOfWin WinType {  get; set; }
        public bool IsWin { get; set; }
        public float _CourseValue {  get; set; }
        public float PlayerBet {  get; set; }
        public Course(TypeOfWin winType)
        {
            WinType=winType;
            IsWin = false;
            _CourseValue = 1.33f;
            PlayerBet = 50.0f;
        }
    }
}

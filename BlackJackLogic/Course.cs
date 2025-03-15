using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackLogic
{
    public class Course
    {
        public bool IsWin { get; set; }
        public float _CourseValue {  get; set; }
        public float PlayerBet {  get; set; }
        public Course()
        {
            IsWin = false;
            _CourseValue = 1.33f;
            PlayerBet = 0f;
        }
    }
}

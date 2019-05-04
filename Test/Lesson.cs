using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class Lesson
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string LessonText { get; set; }
        public IEnumerable<Tuple<string, string>> Teachers { get; set; }
        public IEnumerable<Tuple<string, string>> Rooms { get; set; }
        public IEnumerable<Tuple<string, string>> Subjects { get; set; }
        public string CellState { get; set; }
        public string StudentGroup { get; set; }
    }
}

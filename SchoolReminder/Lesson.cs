using System;
using System.Collections;
using System.Collections.Generic;

namespace SchoolReminder
{
    public class Lesson
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string LessonText { get; set; }
        public LessonDetail[] Teachers { get; set; }
        public LessonDetail[] Rooms { get; set; }
        public LessonDetail[] Subjects { get; set; }
        public string CellState { get; set; }
        public string StudentGroup { get; set; }
    }
}

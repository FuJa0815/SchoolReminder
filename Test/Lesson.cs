﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Test
{
    public class Lesson
    {
        public int ID { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string LessonText { get; set; }
        public IEnumerable<LessonDetail> Teachers { get; set; }
        public IEnumerable<LessonDetail> Rooms { get; set; }
        public IEnumerable<LessonDetail> Subjects { get; set; }
        public string CellState { get; set; }
        public string StudentGroup { get; set; }
    }
}

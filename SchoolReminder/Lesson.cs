using System;

namespace SchoolReminder
{
    public struct Lesson
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

        public override string ToString() => $"{ID} {StudentGroup} {Start.ToString("yyyy.MM.dd hh:mm")}-{End.ToString("hh:mm")} {string.Join(' ',Subjects)} {string.Join(' ', Rooms)} {string.Join(' ', Teachers)} {CellState} {LessonText}";
    }
}

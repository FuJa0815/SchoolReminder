using System;

namespace SchoolReminder
{
    public struct Lesson
    {
        public int            Id           { get; set; }
        public DateTime       Start        { get; set; }
        public DateTime       End          { get; set; }
        public string         LessonText   { get; set; }
        public LessonDetail[] Teachers     { get; set; }
        public LessonDetail[] Rooms        { get; set; }
        public LessonDetail[] Subjects     { get; set; }
        public string         CellState    { get; set; }
        public string         StudentGroup { get; set; }

        public override bool Equals(object obj) =>
            obj is Lesson lesson &&
            Id == lesson.Id;

        public override int GetHashCode() => 2108858624 + Id.GetHashCode();

        public override string ToString() =>
            $"{Id} {StudentGroup} {Start:yyyy.MM.dd hh:mm}-{End:hh:mm} {string.Join(' ', Subjects)} {string.Join(' ', Rooms)} {string.Join(' ', Teachers)} {CellState} {LessonText}";
    }
}
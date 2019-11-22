using System;

namespace SchoolReminder {
    public struct LessonDetail {
        public LessonDetail(string original, string substitution = "") {
            Original = original;
            Substitution = substitution;
        }

        public string Original { get; set; }
        public string Substitution { get; set; }

        public override bool Equals(LessonDetail obj) => Original == obj.Original &&
                                                   Substitution == obj.Substitution;

        public override int GetHashCode() => HashCode.Combine(Original, Substitution);
        public override string ToString() => $"{Original} {Substitution}".TrimEnd();
    }
}
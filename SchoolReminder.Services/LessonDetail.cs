using System;

namespace SchoolReminder.Services
{
    public struct LessonDetail
    {
        public LessonDetail(string original, string substitution = "")
        {
            Original     = original;
            Substitution = substitution;
        }

        public string Original     { get; }
        public string Substitution { get; }

        public override bool Equals(object obj) => obj is LessonDetail detail && Original == detail.Original &&
                                                   Substitution                           == detail.Substitution;

        public override int GetHashCode() => HashCode.Combine(Original, Substitution);

        public override string ToString() => $"{Original} {Substitution}".TrimEnd();
    }
}
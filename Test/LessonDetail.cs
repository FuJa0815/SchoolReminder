﻿using System;

namespace Test
{
    public struct LessonDetail
    {
        public LessonDetail(string original, string substitution = "")
        {
            Original = original;
            Substitution = substitution;
        }

        public string Original { get; set; }
        public string Substitution { get; set; }

        public override bool Equals(object obj) => obj is LessonDetail detail && Original == detail.Original && Substitution == detail.Substitution;
        public override int GetHashCode() => HashCode.Combine(Original, Substitution);
    }
}
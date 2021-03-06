using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolReminder.Extractor;

namespace SchoolReminderTest
{
    [TestClass]
    public class LessonTests
    {
        [TestMethod]
        public void TestToString()
        {
            Assert.AreEqual("1 GrA 2019.01.01 12:00-12:50 D eg01 TEACH ABC",
                            new Lesson
                            {
                                Id           = 1,
                                StudentGroup = "GrA",
                                Start        = new DateTime(2019, 1, 1, 12, 0,  0),
                                End          = new DateTime(2019, 1, 1, 12, 50, 0),
                                LessonText   = "ABC",
                                Rooms        = new[] {new LessonDetail("eg01")},
                                Subjects     = new[] {new LessonDetail("D")},
                                Teachers     = new[] {new LessonDetail("TEACH")}
                            }.ToString());
        }
    }
}
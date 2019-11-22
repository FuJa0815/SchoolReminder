using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolReminder;

namespace SchoolReminderTest
{
    [TestClass]
    public class LessonDetailTest
    {
        [TestMethod]
        public void TestToString1()
        {
            Assert.AreEqual("AM", new LessonDetail("AM").ToString());
        }

        [TestMethod]
        public void TestToString2()
        {
            Assert.AreEqual("AM D", new LessonDetail("AM", "D").ToString());
        }

        [TestMethod]
        public void TestToString3()
        {
            Assert.AreEqual("AM D", new LessonDetail( "AM", "D").ToString());
        }

        [TestMethod]
        public void TestToString4()
        {
            Assert.AreEqual("AM", new LessonDetail ( "AM").ToString());
        }

        [TestMethod]
        public void TestEquals1()
        {
            Assert.IsFalse(new LessonDetail().Equals(new LessonDetail("AM")));
        }

        [TestMethod]
        public void TestEquals2()
        {
            Assert.IsFalse(new LessonDetail("AM").Equals(new LessonDetail("AM2")));
        }

        [TestMethod]
        public void TestEquals3()
        {
            Assert.IsFalse(new LessonDetail("AM", "D").Equals(new LessonDetail("AM")));
        }

        [TestMethod]
        public void TestHashCode1()
        {
            Assert.AreEqual(new LessonDetail().GetHashCode(), new LessonDetail().GetHashCode());
        }

        [TestMethod]
        public void TestHashCode2()
        {
            Assert.AreEqual(new LessonDetail("AM").GetHashCode(), new LessonDetail("AM").GetHashCode());
        }

        [TestMethod]
        public void TestHashCode3()
        {
            Assert.AreEqual(new LessonDetail("AM", "D").GetHashCode(), new LessonDetail("AM", "D").GetHashCode());
        }

        [TestMethod]
        public void TestHashCode4()
        {
            Assert.AreNotEqual(new LessonDetail().GetHashCode(), new LessonDetail("AM").GetHashCode());
        }

        [TestMethod]
        public void TestHashCode5()
        {
            Assert.AreNotEqual(new LessonDetail("AM").GetHashCode(), new LessonDetail("AM2").GetHashCode());
        }

        [TestMethod]
        public void TestHashCode6()
        {
            Assert.AreNotEqual(new LessonDetail("AM", "D").GetHashCode(), new LessonDetail("AM").GetHashCode());
        }
    }
}
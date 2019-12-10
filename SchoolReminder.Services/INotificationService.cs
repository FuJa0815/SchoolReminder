using System;

namespace SchoolReminder.Services
{
    public interface INotificationService
    {
        /// <summary>
        /// Sends a notification about a lesson.
        /// </summary>
        /// <param name="lesson"></param>
        void SendLessonNotification(Lesson lesson);
        bool SendLessonNotificationIfDayHasNoSpecialInformation { get; set; }
        bool SendLessonNotificationOnWeekends { get; set; }
        bool SendRoomSubstituted { get; set; }
        bool SendTeacherSubstituted { get; set; }
        bool SendSubjectSubstituted { get; set; }
        int[] SendTestNotificationDaysBefore { get; set; }
        bool SendRemovedLessons { get; set; }
        bool SendAddedLessons { get; set; }
    }
}

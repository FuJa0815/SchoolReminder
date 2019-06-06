using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SchoolReminder
{
    public static class WebUntisExtractor
    {
        public static async IAsyncEnumerable<Lesson> GetLessons(int classID = 158)
        {
            var json = GetFromServer(classID, DateTime.Now);

            foreach(var p in json["data"]["result"]["data"]["elementPeriods"][classID.ToString()].ToList().AsParallel())
            {
                var id = Task.Run(() => Int32.Parse(p["id"].ToString()));
                var cellState = Task.Run(() => p["cellState"].ToString());
                var start = Task.Run(() => new DateTime(Int32.Parse(p["date"].ToString().Substring(0, 4)), Int32.Parse(p["date"].ToString().Substring(4, 2)), Int32.Parse(p["date"].ToString().Substring(6, 2)), Int32.Parse(p["startTime"].ToString().PadLeft(4, '0').Substring(0, 2)), Int32.Parse(p["startTime"].ToString().PadLeft(4, '0').Substring(2, 2)), 0));
                var end = Task.Run(() => new DateTime(Int32.Parse(p["date"].ToString().Substring(0, 4)), Int32.Parse(p["date"].ToString().Substring(4, 2)), Int32.Parse(p["date"].ToString().Substring(6, 2)), Int32.Parse(p["endTime"].ToString().PadLeft(4, '0').Substring(0, 2)), Int32.Parse(p["endTime"].ToString().PadLeft(4, '0').Substring(2, 2)), 0));
                var lessonText = Task.Run(() => p["lessonText"].ToString());
                var teachers = Task.Run(() => Lookup(p, json, "2").ToArray());
                var subjects = Task.Run(() => Lookup(p, json, "3").ToArray());
                var rooms = Task.Run(() => Lookup(p, json, "4").ToArray());
                var studentGroup = Task.Run(() => p["studentGroup"]?.ToString() ?? "");

                yield return new Lesson()
                {
                    ID = await id,
                    CellState = await cellState,
                    Start = await start,
                    End = await end,
                    LessonText = await lessonText,
                    Teachers = await teachers,
                    Subjects = await subjects,
                    Rooms = await rooms,
                    StudentGroup = await studentGroup,
                };
            }
        }

        private static IEnumerable<LessonDetail> Lookup(JToken p, JObject json, string type)
        {
            foreach (var s in p["elements"].Where(s => s["type"].ToString() == type))
            {
                yield return new LessonDetail(json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == type && u["id"].ToString() == s["id"].ToString())["name"].ToString(), s["orgId"].ToString() == "0" ? "" : json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == type && u["id"].ToString() == s["orgId"].ToString())["name"].ToString());
            }
        }

        private static JObject GetFromServer(int elementId, DateTime date)
        {
            var baseAddress = new Uri($"https://arche.webuntis.com/WebUntis/api/public/timetable/weekly/data?elementType=1&elementId={elementId}&date={date.ToString("yyyy-MM-dd")}");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                cookieContainer.Add(baseAddress, new Cookie("schoolname", "_aHRibGEtZ3JpZXNraXJjaGVu"));
                return JObject.Parse(client.GetStringAsync(baseAddress).Result);
            }
        }
    }
}

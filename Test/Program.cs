using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var classID = 158;

            var json = GetFromServer(classID, DateTime.Now);

            var elements = new List<Lesson>(json["data"]["result"]["data"]["elementPeriods"][classID.ToString()].Select(p => new Lesson()
            {
                ID = Int32.Parse(p["id"].ToString()),
                CellState = p["cellState"].ToString(),
                Start = new DateTime(Int32.Parse(p["date"].ToString().Substring(0, 4)), Int32.Parse(p["date"].ToString().Substring(4, 2)), Int32.Parse(p["date"].ToString().Substring(6, 2)), Int32.Parse(p["startTime"].ToString().PadLeft(4, '0').Substring(0, 2)), Int32.Parse(p["startTime"].ToString().PadLeft(4, '0').Substring(2, 2)), 0),
                End = new DateTime(Int32.Parse(p["date"].ToString().Substring(0, 4)), Int32.Parse(p["date"].ToString().Substring(4, 2)), Int32.Parse(p["date"].ToString().Substring(6, 2)), Int32.Parse(p["endTime"].ToString().PadLeft(4, '0').Substring(0, 2)), Int32.Parse(p["endTime"].ToString().PadLeft(4, '0').Substring(2, 2)), 0),
                LessonText = p["lessonText"].ToString(),
                Teachers = p["elements"].Where(s => s["type"].ToString() == "2").ToList().ConvertAll(s => new Tuple<string, string>(json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == "2" && u["id"].ToString() == s["id"].ToString())["name"].ToString(), s["orgId"].ToString() == "0" ? "" : json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == "2" && u["id"].ToString() == s["orgId"].ToString())["name"].ToString())),
                Subjects = p["elements"].Where(s => s["type"].ToString() == "3").ToList().ConvertAll(s => new Tuple<string, string>(json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == "3" && u["id"].ToString() == s["id"].ToString())["name"].ToString(), s["orgId"].ToString() == "0" ? "" : json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == "3" && u["id"].ToString() == s["orgId"].ToString())["name"].ToString())),
                Rooms = p["elements"].Where(s => s["type"].ToString() == "4").ToList().ConvertAll(s => new Tuple<string, string>(json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == "4" && u["id"].ToString() == s["id"].ToString())["name"].ToString(), s["orgId"].ToString() == "0" ? "" : json["data"]["result"]["data"]["elements"].First(u => u["type"].ToString() == "4" && u["id"].ToString() == s["orgId"].ToString())["name"].ToString())),
                StudentGroup = p["studentGroup"]?.ToString() ?? "",
            }));
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

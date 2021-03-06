﻿using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotWashy.Controllers
{
    public static class dateFormat
    {
        public static string getFormatedDateNow()
        {
            return formatDate(DateTime.Now);
        }

        public static string getFormatedDateTomorrow()
        {
            return formatDate(DateTime.Now.AddDays(1));
        }

        public static string formatDate(DateTime date)
        {
            string output = "";
            output += date.Month + "+";
            output += date.Day + "+";
            output += date.Year + "+";
            output += date.Hour + ":";
            output += date.Minute + ":";
            output += date.Second;

            return output;
        }

        public static string formatDateDot(DateTime date)
        {
            string output = "";
            output += date.Month + ".";
            output += date.Day + ".";
            output += date.Year + ".";
            output += date.Hour + ":";
            output += date.Minute;

            return output;
        }

        public static string[] getStartDateFromJSON(string input)
        {
            dynamic json = JsonConvert.DeserializeObject(input);
            string[] start = new string[json.Count];
            for (int i = 0; i < json.Count; i++ )
            {
                start[i] = json[i].start;
            }
            return start;
        }

        public static string getStateFromJSON(string input)
        {
            dynamic json = JsonConvert.DeserializeObject(input);
            string rcvState = json.state;
            return rcvState;
        }

        public static string getDateFromJSON(string input)
        {
            dynamic json = JsonConvert.DeserializeObject(input);
            string rcvDate = json.date;
            return rcvDate;
        }


        public static string[] getEndDateFromJSON(string input)
        {
            dynamic json = JsonConvert.DeserializeObject(input);
            string[] end = new string[json.Count];
            for (int i = 0; i < json.Count; i++)
            {
                end[i] = json[i].end;
            }
            return end;
        }

        public static string[] getTimeslotsPlainText(string json)
        {
            string[] starts = getStartDateFromJSON(json);
            string[] ends = getEndDateFromJSON(json);

            int sLength = starts.Length;
            int eLength = starts.Length;
            string[] output = new string [sLength];
            if (sLength == eLength)
            {
                for (int i = 0; i< sLength; i++)
                {
                    output[i] += $"A timeslot from {starts[i]} to {ends[i]} is available. " + Environment.NewLine;
                }
               // output[sLength] += "Which Timeslot do you prefer?";
            }
            return output;
        }

        internal static object getRoomFromJSON(string input)
        {
            dynamic json = JsonConvert.DeserializeObject(input);
            string rcvDate = json.room;
            return rcvDate;
        }
    }
}
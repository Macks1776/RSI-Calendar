﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSI_Calendar.Models
{
    public class CalendarEvent
    {
        //This class is only for the calendar plugin. You do NOT create anything here, it is ONLY for passing data in a specific way to the calendar


        public int id;
        public string title;
        public DateTime start;

        public CalendarEvent(int num, string name, DateTime date)
        {
            id = num;
            title = name;
            start = date;
        }
    }
}
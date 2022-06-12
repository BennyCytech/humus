using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace humus.Models
{
    public class log
    {
        public log()
        {
        }
        public log(DataRow row)
        {
            id = row.Field<int>("id");
            UserID = row.Field<int>("UserID");
            UserName = row.Field<string>("UserName") == null ? "" : row.Field<string>("UserName");
            datetime = row.Field<DateTime>("datetime");
            category = row.Field<string>("category") == null ? "" : row.Field<string>("category");
            action = row.Field<string>("action") == null ? "" : row.Field<string>("action");
        }
        [Display(Name = "")] public int id { get; set; }
        [Display(Name = "משתמש")] public int UserID { get; set; }
        [Display(Name = "משתמש")] public string UserName { get; set; }
        [Display(Name = "תאריך שעה")] public DateTime datetime { get; set; }
        [Display(Name = "קטגוריה")] public string category { get; set; }
        [Display(Name = "תיאור")] public string action { get; set; }

    }
}
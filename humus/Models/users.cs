using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace humus.Models
{
    public class users
    {
        public users()
        {
            IsActive = true;
        }
        public users(DataRow row)
        {
            _DAL dal = new _DAL();

            ID = row.Field<int>("id");
            sID = dal.Encrypt( ID.ToString(),"excel");
            name = row.Field<string>("name") == null ? "" : row.Field<string>("name");
            email = row.Field<string>("email") == null ? "" : row.Field<string>("email");
            fkRole = row.IsNull("fkRole") ? 0 : row.Field<int>("fkRole");
            fkRoleDesc = row.Field<string>("fkRoleDesc") == null ? "" : row.Field<string>("fkRoleDesc");
            IsActive = row.Field<bool>("IsActive");
            password = row.Field<string>("password") == null ? "" : row.Field<string>("password");
        }
        public int ID { get; set; }
        public string sID { get; set; }

        //[Display(Name = "שם פרטי ומשפחה")]
        [Display(Name = "Name")]
        public string name { get; set; }
        //[Display(Name = "כתובת מייל")]
        [Display(Name = "Email address")]
        public string email { get; set; }
        //[Display(Name = "סיסמה")]
        [Display(Name = "Password")]
        public string password { get; set; }
        //[Display(Name = "תפקיד")]
        [Display(Name = "Role")]
        public int fkRole { get; set; }
        [Display(Name = "Role")]
        //[Display(Name = "תפקיד")]
        public string fkRoleDesc { get; set; }
        //[Display(Name = "פעיל")]
        [Display(Name = "Is active")]
        public bool IsActive { get; set; }

    }
}
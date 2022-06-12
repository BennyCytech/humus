using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace humus.Models
{
    public class _DAL
    {
        _SQL sql = new _SQL();

        public IEnumerable<SelectListItem> getlutTableListItems(string table, bool LimitByCompany = false, bool ShowAllKeyWord = true, bool ShowBlankOption = true)
        {
            var selectList = new List<SelectListItem>();
            if (table == "") { }

            if (ShowAllKeyWord)
            {
                selectList.Add(new SelectListItem
                {
                    Value = "0",
                    Text = "הכל"
                });
            }
            else
            {
                if (ShowBlankOption)
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = "0",
                        Text = ""
                    });
                }
            }
            var db = new DBContext();
            string SQL = "select * from " + table;

            var ds = db.SqlExecute(string.Format(SQL));
            if (ds != null)
                if (ds.Tables != null && ds.Tables.Count > 0)
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = dr[0].ToString(),
                            Text = dr.Field<string>("desc")
                        });
                    }
            //selectList = selectList.OrderBy(x => x.Text).ToList();
            return selectList;
        }
        #region log
        public List<log> Getlog()
        {
            List<log> list = new List<log>();
                var db = new DBContext("DefaultConnection");
                var ds = db.SqlExecute(sql.Getlog);

                if (ds != null)
                    if (ds.Tables != null && ds.Tables.Count > 0)
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            list.Add(new log(dr));
            return list;
        }
        public int NewUpdatelog(log model, string action)
        {
            var db = new DBContext();
            string s = "";
            int retVal = 0;

            db.SqlParameters.Add(new SqlParameter("@id", string.IsNullOrWhiteSpace(model.id.ToString()) ? "" : model.id.ToString()));
            db.SqlParameters.Add(new SqlParameter("@UserID", string.IsNullOrWhiteSpace(model.UserID.ToString()) ? "" : model.UserID.ToString()));
            db.SqlParameters.Add(new SqlParameter("@UserName", string.IsNullOrWhiteSpace(model.UserName) ? "" : model.UserName.ToString()));
            db.SqlParameters.Add(new SqlParameter("@category", string.IsNullOrWhiteSpace(model.category) ? "" : model.category.ToString()));
            db.SqlParameters.Add(new SqlParameter("@action", string.IsNullOrWhiteSpace(model.action) ? "" : model.action.ToString()));

            if (action == "new")
            {
                s = sql.Newlog;
                var ds = db.SqlExecute(s + ";SELECT CAST(scope_identity() AS int)");
                if (ds != null)
                    if (ds.Tables != null && ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            retVal = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
                            model.id = retVal;
                        }
            }
            else
            {
                s = sql.Updatelog;
                var ds = db.SqlExecute(s + ";SELECT CAST(scope_identity() AS int)");
            }

            return retVal;
        }
        public void WriteLog(string category, string action)
        {
            if (category != "Controller")
            {
                log model = new log();

                var userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                var ip = System.Web.HttpContext.Current.Request.UserHostAddress;

                model.category = category;
                model.action = userName + '-' + ip + '-' + action;
                NewUpdatelog(model, "new");
            }
        }

        #endregion

        #region order
        public List<order> Getorder()
        {
            List<order> list = new List<order>();
            var db = new DBContext("DefaultConnection");

            var ds = db.SqlExecute(sql.Getorder);

            if (ds != null)
                if (ds.Tables != null && ds.Tables.Count > 0)
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        list.Add(new order(dr));

            return list;
        }
        public int NewUpdateorder(order model, string action)
        {
            int retVal = 0;

            var db = new DBContext();
            string s = "";

            db.SqlParameters.Add(new SqlParameter("@id", string.IsNullOrWhiteSpace(model.id.ToString()) ? "" : model.id.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name", string.IsNullOrWhiteSpace(model.name) ? "" : model.name.ToString()));
            db.SqlParameters.Add(new SqlParameter("@phone", string.IsNullOrWhiteSpace(model.phone) ? "" : model.phone.ToString()));
            db.SqlParameters.Add(new SqlParameter("@address", string.IsNullOrWhiteSpace(model.address) ? "" : model.address.ToString()));
            db.SqlParameters.Add(new SqlParameter("@email", string.IsNullOrWhiteSpace(model.email) ? "" : model.email.ToString()));
            db.SqlParameters.Add(new SqlParameter("@fkPaymentMethod", string.IsNullOrWhiteSpace(model.fkPaymentMethod.ToString()) ? "" : model.fkPaymentMethod.ToString()));
            db.SqlParameters.Add(new SqlParameter("@remarks", string.IsNullOrWhiteSpace(model.remarks) ? "" : model.remarks.ToString()));
            db.SqlParameters.Add(new SqlParameter("@humusKilo", string.IsNullOrWhiteSpace(model.humusKilo) ? "" : model.humusKilo.ToString()));
            db.SqlParameters.Add(new SqlParameter("@fullKilo", string.IsNullOrWhiteSpace(model.fullKilo) ? "" : model.fullKilo.ToString()));
            db.SqlParameters.Add(new SqlParameter("@check110", model.check110));
            db.SqlParameters.Add(new SqlParameter("@check19", model.check19));
            db.SqlParameters.Add(new SqlParameter("@check18", model.check18));
            db.SqlParameters.Add(new SqlParameter("@check17", model.check17));
            db.SqlParameters.Add(new SqlParameter("@check16", model.check16));
            db.SqlParameters.Add(new SqlParameter("@check15", model.check15));
            db.SqlParameters.Add(new SqlParameter("@check14", model.check14));
            db.SqlParameters.Add(new SqlParameter("@check13", model.check13));
            db.SqlParameters.Add(new SqlParameter("@check12", model.check12));
            db.SqlParameters.Add(new SqlParameter("@check11", model.check11));
            db.SqlParameters.Add(new SqlParameter("@check210", model.check210));
            db.SqlParameters.Add(new SqlParameter("@check29", model.check29));
            db.SqlParameters.Add(new SqlParameter("@check28", model.check28));
            db.SqlParameters.Add(new SqlParameter("@check27", model.check27));
            db.SqlParameters.Add(new SqlParameter("@check26", model.check26));
            db.SqlParameters.Add(new SqlParameter("@check25", model.check25));
            db.SqlParameters.Add(new SqlParameter("@check24", model.check24));
            db.SqlParameters.Add(new SqlParameter("@check23", model.check23));
            db.SqlParameters.Add(new SqlParameter("@check22", model.check22));
            db.SqlParameters.Add(new SqlParameter("@check21", model.check21));
            db.SqlParameters.Add(new SqlParameter("@check310", model.check310));
            db.SqlParameters.Add(new SqlParameter("@check39", model.check39));
            db.SqlParameters.Add(new SqlParameter("@check38", model.check38));
            db.SqlParameters.Add(new SqlParameter("@check37", model.check37));
            db.SqlParameters.Add(new SqlParameter("@check36", model.check36));
            db.SqlParameters.Add(new SqlParameter("@check35", model.check35));
            db.SqlParameters.Add(new SqlParameter("@check34", model.check34));
            db.SqlParameters.Add(new SqlParameter("@check33", model.check33));
            db.SqlParameters.Add(new SqlParameter("@check32", model.check32));
            db.SqlParameters.Add(new SqlParameter("@check31", model.check31));
            db.SqlParameters.Add(new SqlParameter("@check410", model.check410));
            db.SqlParameters.Add(new SqlParameter("@check49", model.check49));
            db.SqlParameters.Add(new SqlParameter("@check48", model.check48));
            db.SqlParameters.Add(new SqlParameter("@check47", model.check47));
            db.SqlParameters.Add(new SqlParameter("@check46", model.check46));
            db.SqlParameters.Add(new SqlParameter("@check45", model.check45));
            db.SqlParameters.Add(new SqlParameter("@check44", model.check44));
            db.SqlParameters.Add(new SqlParameter("@check43", model.check43));
            db.SqlParameters.Add(new SqlParameter("@check42", model.check42));
            db.SqlParameters.Add(new SqlParameter("@check41", model.check41));
            db.SqlParameters.Add(new SqlParameter("@check510", model.check510));
            db.SqlParameters.Add(new SqlParameter("@check59", model.check59));
            db.SqlParameters.Add(new SqlParameter("@check58", model.check58));
            db.SqlParameters.Add(new SqlParameter("@check57", model.check57));
            db.SqlParameters.Add(new SqlParameter("@check56", model.check56));
            db.SqlParameters.Add(new SqlParameter("@check55", model.check55));
            db.SqlParameters.Add(new SqlParameter("@check54", model.check54));
            db.SqlParameters.Add(new SqlParameter("@check53", model.check53));
            db.SqlParameters.Add(new SqlParameter("@check52", model.check52));
            db.SqlParameters.Add(new SqlParameter("@check51", model.check51));
            db.SqlParameters.Add(new SqlParameter("@check610", model.check610));
            db.SqlParameters.Add(new SqlParameter("@check69", model.check69));
            db.SqlParameters.Add(new SqlParameter("@check68", model.check68));
            db.SqlParameters.Add(new SqlParameter("@check67", model.check67));
            db.SqlParameters.Add(new SqlParameter("@check66", model.check66));
            db.SqlParameters.Add(new SqlParameter("@check65", model.check65));
            db.SqlParameters.Add(new SqlParameter("@check64", model.check64));
            db.SqlParameters.Add(new SqlParameter("@check63", model.check63));
            db.SqlParameters.Add(new SqlParameter("@check62", model.check62));
            db.SqlParameters.Add(new SqlParameter("@check61", model.check61));
            db.SqlParameters.Add(new SqlParameter("@name6", string.IsNullOrWhiteSpace(model.name6) ? "" : model.name6.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name5", string.IsNullOrWhiteSpace(model.name5) ? "" : model.name5.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name4", string.IsNullOrWhiteSpace(model.name4) ? "" : model.name4.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name3", string.IsNullOrWhiteSpace(model.name3) ? "" : model.name3.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name2", string.IsNullOrWhiteSpace(model.name2) ? "" : model.name2.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name1", string.IsNullOrWhiteSpace(model.name1) ? "" : model.name1.ToString()));
            db.SqlParameters.Add(new SqlParameter("@KiloSum15", model.KiloSum15 == null ? 0 : model.KiloSum15));
            db.SqlParameters.Add(new SqlParameter("@KiloSum14", model.KiloSum14 == null ? 0 : model.KiloSum14));
            db.SqlParameters.Add(new SqlParameter("@KiloSum13", model.KiloSum13 == null ? 0 : model.KiloSum13));
            db.SqlParameters.Add(new SqlParameter("@KiloSum12", model.KiloSum12 == null ? 0 : model.KiloSum12));
            db.SqlParameters.Add(new SqlParameter("@KiloSum11", model.KiloSum11 == null ? 0 : model.KiloSum11));
            db.SqlParameters.Add(new SqlParameter("@KiloSum10", model.KiloSum10 == null ? 0 : model.KiloSum10));
            db.SqlParameters.Add(new SqlParameter("@KiloSum9", model.KiloSum9 == null ? 0 : model.KiloSum9));
            db.SqlParameters.Add(new SqlParameter("@KiloSum8", model.KiloSum8 == null ? 0 : model.KiloSum8));
            db.SqlParameters.Add(new SqlParameter("@KiloSum7", model.KiloSum7 == null ? 0 : model.KiloSum7));
            db.SqlParameters.Add(new SqlParameter("@KiloSum6", model.KiloSum6 == null ? 0 : model.KiloSum6));
            db.SqlParameters.Add(new SqlParameter("@KiloSum5", model.KiloSum5 == null ? 0 : model.KiloSum5));
            db.SqlParameters.Add(new SqlParameter("@KiloSum4", model.KiloSum4 == null ? 0 : model.KiloSum4));
            db.SqlParameters.Add(new SqlParameter("@KiloSum3", model.KiloSum3 == null ? 0 : model.KiloSum3));
            db.SqlParameters.Add(new SqlParameter("@KiloSum2", model.KiloSum2 == null ? 0 : model.KiloSum2));
            db.SqlParameters.Add(new SqlParameter("@KiloSum1", model.KiloSum1 == null ? 0 : model.KiloSum1));
            db.SqlParameters.Add(new SqlParameter("@sum1", model.sum1 == null ? 0 : model.sum1));
            db.SqlParameters.Add(new SqlParameter("@sum2", model.sum2 == null ? 0 : model.sum2));
            db.SqlParameters.Add(new SqlParameter("@sum3", model.sum3 == null ? 0 : model.sum3));
            db.SqlParameters.Add(new SqlParameter("@sum4", model.sum4 == null ? 0 : model.sum4));
            db.SqlParameters.Add(new SqlParameter("@sum5", model.sum5 == null ? 0 : model.sum5));
            db.SqlParameters.Add(new SqlParameter("@sum6", model.sum6 == null ? 0 : model.sum6));
            db.SqlParameters.Add(new SqlParameter("@sum7", model.sum7 == null ? 0 : model.sum7));
            db.SqlParameters.Add(new SqlParameter("@sum8", model.sum8 == null ? 0 : model.sum8));
            db.SqlParameters.Add(new SqlParameter("@sum9", model.sum9 == null ? 0 : model.sum9));
            db.SqlParameters.Add(new SqlParameter("@sum10", model.sum10 == null ? 0 : model.sum10));
            db.SqlParameters.Add(new SqlParameter("@OrderCount", model.OrderCount == null ? 0 : model.OrderCount));
            db.SqlParameters.Add(new SqlParameter("@OrderSum", model.OrderSum == null ? 0 : model.OrderSum));
            db.SqlParameters.Add(new SqlParameter("@KiloCount", model.KiloCount == null ? 0 : model.KiloCount));
            db.SqlParameters.Add(new SqlParameter("@kilo1", model.kilo1 == null ? 0 : model.kilo1));
            db.SqlParameters.Add(new SqlParameter("@kilo2", model.kilo2 == null ? 0 : model.kilo2));
            db.SqlParameters.Add(new SqlParameter("@kilo3", model.kilo3 == null ? 0 : model.kilo3));
            db.SqlParameters.Add(new SqlParameter("@kilo4", model.kilo4 == null ? 0 : model.kilo4));
            db.SqlParameters.Add(new SqlParameter("@kilo5", model.kilo5 == null ? 0 : model.kilo5));
            db.SqlParameters.Add(new SqlParameter("@kilo6", model.kilo6 == null ? 0 : model.kilo6));
            db.SqlParameters.Add(new SqlParameter("@kilo7", model.kilo7 == null ? 0 : model.kilo7));
            db.SqlParameters.Add(new SqlParameter("@kilo8", model.kilo8 == null ? 0 : model.kilo8));
            db.SqlParameters.Add(new SqlParameter("@kilo9", model.kilo9 == null ? 0 : model.kilo9));
            db.SqlParameters.Add(new SqlParameter("@kilo10", model.kilo10 == null ? 0 : model.kilo10));
            db.SqlParameters.Add(new SqlParameter("@kilo11", model.kilo11 == null ? 0 : model.kilo11));
            db.SqlParameters.Add(new SqlParameter("@kilo12", model.kilo12 == null ? 0 : model.kilo12));
            db.SqlParameters.Add(new SqlParameter("@kilo13", model.kilo13 == null ? 0 : model.kilo13));
            db.SqlParameters.Add(new SqlParameter("@kilo14", model.kilo14 == null ? 0 : model.kilo14));
            db.SqlParameters.Add(new SqlParameter("@kilo15", model.kilo15 == null ? 0 : model.kilo15));
            db.SqlParameters.Add(new SqlParameter("@KiloSum16", model.KiloSum16 == null ? 0 : model.KiloSum16));
            db.SqlParameters.Add(new SqlParameter("@KiloSum17", model.KiloSum17 == null ? 0 : model.KiloSum17));
            db.SqlParameters.Add(new SqlParameter("@KiloSum18", model.KiloSum18 == null ? 0 : model.KiloSum18));
            db.SqlParameters.Add(new SqlParameter("@KiloSum19", model.KiloSum19 == null ? 0 : model.KiloSum19));
            db.SqlParameters.Add(new SqlParameter("@KiloSum20", model.KiloSum20 == null ? 0 : model.KiloSum20));
            db.SqlParameters.Add(new SqlParameter("@KiloSum21", model.KiloSum21 == null ? 0 : model.KiloSum21));
            db.SqlParameters.Add(new SqlParameter("@kilo16", model.kilo16 == null ? 0 : model.kilo16));
            db.SqlParameters.Add(new SqlParameter("@kilo17", model.kilo17 == null ? 0 : model.kilo17));
            db.SqlParameters.Add(new SqlParameter("@kilo18", model.kilo18 == null ? 0 : model.kilo18));
            db.SqlParameters.Add(new SqlParameter("@kilo19", model.kilo19 == null ? 0 : model.kilo19));
            db.SqlParameters.Add(new SqlParameter("@kilo20", model.kilo20 == null ? 0 : model.kilo20));
            db.SqlParameters.Add(new SqlParameter("@kilo21", model.kilo21 == null ? 0 : model.kilo21));


            if (action == "new")
            {
                s = sql.Neworder;
                var ds = db.SqlExecute(s + ";SELECT CAST(scope_identity() AS int)");
                if (ds != null)
                    if (ds.Tables != null && ds.Tables.Count > 0)
                        if (ds.Tables[0].Rows.Count == 1)
                            retVal = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());

            }
            else
            {
                s = sql.Updateorder;
                var ds = db.SqlExecute(s + ";SELECT CAST(scope_identity() AS int)");
            }
            return retVal;



        }
        #endregion

        #region users
   
        public int login(users user)
        {
            int retval = 0;

            foreach (var x in GetUsers())
            {
                if (x.email == user.email && x.password == user.password && x.IsActive == true)
                {
                    retval = x.fkRole;// x.ID;
                }
            }

            return retval;
        }

        public string ServiceLogin(string email, string password)
        {
            string ret = "";

            foreach (var x in GetUsers())
            {
                if (x.email == email && x.password == password && x.IsActive == true)
                {
                    ret = x.fkRole.ToString();
                }
            }

            return ret;
        }

  
        public List<users> GetUsers()
        {
            List<users> list = new List<users>();
            var db = new DBContext("DefaultConnection");
            var ds = db.SqlExecute(sql.GetUsers);

            if (ds != null)
                if (ds.Tables != null && ds.Tables.Count > 0)
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        list.Add(new users(dr));

            return list;
        }
     
        public users GetUsersByID(int UserID)
        {
            return GetUsers().Where(x => x.ID == UserID).FirstOrDefault();
        }
        public int NewUser(users user)
        {
            var db = new DBContext();
            int retVal = 0;

            db.SqlParameters.Add(new SqlParameter("@email", string.IsNullOrWhiteSpace(user.email) ? "" : user.email.ToString()));
            db.SqlParameters.Add(new SqlParameter("@fkRole", string.IsNullOrWhiteSpace(user.fkRole.ToString()) ? "" : user.fkRole.ToString()));
            db.SqlParameters.Add(new SqlParameter("@IsActive", string.IsNullOrWhiteSpace(user.IsActive.ToString()) ? "" : user.IsActive.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name", string.IsNullOrWhiteSpace(user.name) ? "" : user.name.ToString()));
            db.SqlParameters.Add(new SqlParameter("@password", string.IsNullOrWhiteSpace(user.password) ? "" : user.password.ToString()));
            db.SqlParameters.Add(new SqlParameter("@UserName", string.IsNullOrWhiteSpace(user.email) ? "" : user.email.ToString()));

            var ds = db.SqlExecute(sql.NewUser + ";SELECT CAST(scope_identity() AS int)");
            if (ds != null)
                if (ds.Tables != null && ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count == 1)
                        retVal = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());

            return retVal;
        }
        public void UpdateUser(users user)
        {
            var db = new DBContext();

            db.SqlParameters.Add(new SqlParameter("@email", string.IsNullOrWhiteSpace(user.email) ? "" : user.email.ToString()));
            db.SqlParameters.Add(new SqlParameter("@fkRole", string.IsNullOrWhiteSpace(user.fkRole.ToString()) ? "" : user.fkRole.ToString()));
            db.SqlParameters.Add(new SqlParameter("@IsActive", string.IsNullOrWhiteSpace(user.IsActive.ToString()) ? "" : user.IsActive.ToString()));
            db.SqlParameters.Add(new SqlParameter("@name", string.IsNullOrWhiteSpace(user.name) ? "" : user.name.ToString()));
            db.SqlParameters.Add(new SqlParameter("@password", string.IsNullOrWhiteSpace(user.password) ? "" : user.password.ToString()));
            db.SqlParameters.Add(new SqlParameter("@UserName", string.IsNullOrWhiteSpace(user.email) ? "" : user.email.ToString()));
            db.SqlParameters.Add(new SqlParameter("@id", user.ID.ToString()));

            var ds = db.SqlExecuteNonQuery(sql.UpdateUser);
        }
        #endregion

        public string Encrypt(string plainText, string password)
        {
            if (plainText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }

            var bytesToBeEncrypted = Encoding.UTF8.GetBytes(plainText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesEncrypted = Encrypt(bytesToBeEncrypted, passwordBytes);

            string retVal = Convert.ToBase64String(bytesEncrypted);
            int mm = retVal.Replace(" ", "").Length % 4;
            if (mm > 0)
            {
                retVal += new string('=', 4 - mm);
            }
            return retVal;
        }

        public string Decrypt(string encryptedText, string password)
        {
            if (encryptedText == null)
            {
                return null;
            }

            if (password == null)
            {
                password = String.Empty;
            }
            encryptedText = encryptedText.Replace(" ", "+");
            // Get the bytes of the string
            var bytesToBeDecrypted = Convert.FromBase64String(encryptedText);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            var bytesDecrypted = Decrypt(bytesToBeDecrypted, passwordBytes);

            return Encoding.UTF8.GetString(bytesDecrypted);
        }
        private byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        private byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            var saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);

                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }

                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

    }
}
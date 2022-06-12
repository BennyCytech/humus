using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace humus.Models
{
    public class order: IValidatableObject
    {
        public order()
        {
        }
        public order(DataRow row)
        {
            id = row.Field<int>("id");
            name = row.Field<string>("name") == null ? "" : row.Field<string>("name");
            phone = row.Field<string>("phone") == null ? "" : row.Field<string>("phone");
            email = row.Field<string>("email") == null ? "" : row.Field<string>("email");
            address = row.Field<string>("address") == null ? "" : row.Field<string>("address");
            fkPaymentMethod = row.IsNull("fkPaymentMethod") ? 0 : row.Field<int>("fkPaymentMethod");
            remarks = row.Field<string>("remarks") == null ? "" : row.Field<string>("remarks");
            humusKilo = row.Field<string>("humusKilo") == null ? "" : row.Field<string>("humusKilo");
            fullKilo = row.Field<string>("fullKilo") == null ? "" : row.Field<string>("fullKilo");
            sum10 = row.IsNull("sum10") ? 0 : row.Field<int>("sum10");
            sum9 = row.IsNull("sum9") ? 0 : row.Field<int>("sum9");
            sum8 = row.IsNull("sum8") ? 0 : row.Field<int>("sum8");
            sum7 = row.IsNull("sum7") ? 0 : row.Field<int>("sum7");
            sum6 = row.IsNull("sum6") ? 0 : row.Field<int>("sum6");
            sum5 = row.IsNull("sum5") ? 0 : row.Field<int>("sum5");
            sum4 = row.IsNull("sum4") ? 0 : row.Field<int>("sum4");
            sum3 = row.IsNull("sum3") ? 0 : row.Field<int>("sum3");
            sum2 = row.IsNull("sum2") ? 0 : row.Field<int>("sum2");
            sum1 = row.IsNull("sum1") ? 0 : row.Field<int>("sum1");
            OrderCount = row.IsNull("OrderCount") ? 0 : row.Field<int>("OrderCount");
            OrderSum = row.IsNull("OrderSum") ? 0 : row.Field<double>("OrderSum");
            kilo15 = row.IsNull("kilo15") ? 0 : row.Field<int>("kilo15");
            kilo14 = row.IsNull("kilo14") ? 0 : row.Field<int>("kilo14");
            kilo13 = row.IsNull("kilo13") ? 0 : row.Field<int>("kilo13");
            kilo12 = row.IsNull("kilo12") ? 0 : row.Field<int>("kilo12");
            kilo11 = row.IsNull("kilo11") ? 0 : row.Field<int>("kilo11");
            kilo10 = row.IsNull("kilo10") ? 0 : row.Field<int>("kilo10");
            kilo9 = row.IsNull("kilo9") ? 0 : row.Field<int>("kilo9");
            kilo8 = row.IsNull("kilo8") ? 0 : row.Field<int>("kilo8");
            kilo7 = row.IsNull("kilo7") ? 0 : row.Field<int>("kilo7");
            kilo6 = row.IsNull("kilo6") ? 0 : row.Field<int>("kilo6");
            kilo5 = row.IsNull("kilo5") ? 0 : row.Field<int>("kilo5");
            kilo4 = row.IsNull("kilo4") ? 0 : row.Field<int>("kilo4");
            kilo3 = row.IsNull("kilo3") ? 0 : row.Field<int>("kilo3");
            kilo2 = row.IsNull("kilo2") ? 0 : row.Field<int>("kilo2");
            kilo1 = row.IsNull("kilo1") ? 0 : row.Field<int>("kilo1");
            KiloCount = row.IsNull("KiloCount") ? 0 : row.Field<int>("KiloCount");
            check110 = row.IsNull("check110") ? false : row.Field<bool>("check110");
            check19 = row.IsNull("check19") ? false : row.Field<bool>("check19");
            check18 = row.IsNull("check18") ? false : row.Field<bool>("check18");
            check17 = row.IsNull("check17") ? false : row.Field<bool>("check17");
            check16 = row.IsNull("check16") ? false : row.Field<bool>("check16");
            check15 = row.IsNull("check15") ? false : row.Field<bool>("check15");
            check14 = row.IsNull("check14") ? false : row.Field<bool>("check14");
            check13 = row.IsNull("check13") ? false : row.Field<bool>("check13");
            check12 = row.IsNull("check12") ? false : row.Field<bool>("check12");
            check11 = row.IsNull("check11") ? false : row.Field<bool>("check11");
            check210 = row.IsNull("check210") ? false : row.Field<bool>("check210");
            check29 = row.IsNull("check29") ? false : row.Field<bool>("check29");
            check28 = row.IsNull("check28") ? false : row.Field<bool>("check28");
            check27 = row.IsNull("check27") ? false : row.Field<bool>("check27");
            check26 = row.IsNull("check26") ? false : row.Field<bool>("check26");
            check25 = row.IsNull("check25") ? false : row.Field<bool>("check25");
            check24 = row.IsNull("check24") ? false : row.Field<bool>("check24");
            check23 = row.IsNull("check23") ? false : row.Field<bool>("check23");
            check22 = row.IsNull("check22") ? false : row.Field<bool>("check22");
            check21 = row.IsNull("check21") ? false : row.Field<bool>("check21");
            check310 = row.IsNull("check310") ? false : row.Field<bool>("check310");
            check39 = row.IsNull("check39") ? false : row.Field<bool>("check39");
            check38 = row.IsNull("check38") ? false : row.Field<bool>("check38");
            check37 = row.IsNull("check37") ? false : row.Field<bool>("check37");
            check36 = row.IsNull("check36") ? false : row.Field<bool>("check36");
            check35 = row.IsNull("check35") ? false : row.Field<bool>("check35");
            check34 = row.IsNull("check34") ? false : row.Field<bool>("check34");
            check33 = row.IsNull("check33") ? false : row.Field<bool>("check33");
            check32 = row.IsNull("check32") ? false : row.Field<bool>("check32");
            check31 = row.IsNull("check31") ? false : row.Field<bool>("check31");
            check410 = row.IsNull("check410") ? false : row.Field<bool>("check410");
            check49 = row.IsNull("check49") ? false : row.Field<bool>("check49");
            check48 = row.IsNull("check48") ? false : row.Field<bool>("check48");
            check47 = row.IsNull("check47") ? false : row.Field<bool>("check47");
            check46 = row.IsNull("check46") ? false : row.Field<bool>("check46");
            check45 = row.IsNull("check45") ? false : row.Field<bool>("check45");
            check44 = row.IsNull("check44") ? false : row.Field<bool>("check44");
            check43 = row.IsNull("check43") ? false : row.Field<bool>("check43");
            check42 = row.IsNull("check42") ? false : row.Field<bool>("check42");
            check41 = row.IsNull("check41") ? false : row.Field<bool>("check41");
            check510 = row.IsNull("check510") ? false : row.Field<bool>("check510");
            check59 = row.IsNull("check59") ? false : row.Field<bool>("check59");
            check58 = row.IsNull("check58") ? false : row.Field<bool>("check58");
            check57 = row.IsNull("check57") ? false : row.Field<bool>("check57");
            check56 = row.IsNull("check56") ? false : row.Field<bool>("check56");
            check55 = row.IsNull("check55") ? false : row.Field<bool>("check55");
            check54 = row.IsNull("check54") ? false : row.Field<bool>("check54");
            check53 = row.IsNull("check53") ? false : row.Field<bool>("check53");
            check52 = row.IsNull("check52") ? false : row.Field<bool>("check52");
            check51 = row.IsNull("check51") ? false : row.Field<bool>("check51");
            check610 = row.IsNull("check610") ? false : row.Field<bool>("check610");
            check69 = row.IsNull("check69") ? false : row.Field<bool>("check69");
            check68 = row.IsNull("check68") ? false : row.Field<bool>("check68");
            check67 = row.IsNull("check67") ? false : row.Field<bool>("check67");
            check66 = row.IsNull("check66") ? false : row.Field<bool>("check66");
            check65 = row.IsNull("check65") ? false : row.Field<bool>("check65");
            check64 = row.IsNull("check64") ? false : row.Field<bool>("check64");
            check63 = row.IsNull("check63") ? false : row.Field<bool>("check63");
            check62 = row.IsNull("check62") ? false : row.Field<bool>("check62");
            check61 = row.IsNull("check61") ? false : row.Field<bool>("check61");
            name6 = row.Field<string>("name6") == null ? "" : row.Field<string>("name6");
            name5 = row.Field<string>("name5") == null ? "" : row.Field<string>("name5");
            name4 = row.Field<string>("name4") == null ? "" : row.Field<string>("name4");
            name3 = row.Field<string>("name3") == null ? "" : row.Field<string>("name3");
            name2 = row.Field<string>("name2") == null ? "" : row.Field<string>("name2");
            name1 = row.Field<string>("name1") == null ? "" : row.Field<string>("name1");
            KiloSum15 = row.IsNull("KiloSum15") ? 0 : row.Field<int>("KiloSum15");
            KiloSum14 = row.IsNull("KiloSum14") ? 0 : row.Field<int>("KiloSum14");
            KiloSum13 = row.IsNull("KiloSum13") ? 0 : row.Field<int>("KiloSum13");
            KiloSum12 = row.IsNull("KiloSum12") ? 0 : row.Field<int>("KiloSum12");
            KiloSum11 = row.IsNull("KiloSum11") ? 0 : row.Field<int>("KiloSum11");
            KiloSum10 = row.IsNull("KiloSum10") ? 0 : row.Field<int>("KiloSum10");
            KiloSum9 = row.IsNull("KiloSum9") ? 0 : row.Field<int>("KiloSum9");
            KiloSum8 = row.IsNull("KiloSum8") ? 0 : row.Field<int>("KiloSum8");
            KiloSum7 = row.IsNull("KiloSum7") ? 0 : row.Field<int>("KiloSum7");
            KiloSum6 = row.IsNull("KiloSum6") ? 0 : row.Field<int>("KiloSum6");
            KiloSum5 = row.IsNull("KiloSum5") ? 0 : row.Field<int>("KiloSum5");
            KiloSum4 = row.IsNull("KiloSum4") ? 0 : row.Field<int>("KiloSum4");
            KiloSum3 = row.IsNull("KiloSum3") ? 0 : row.Field<int>("KiloSum3");
            KiloSum2 = row.IsNull("KiloSum2") ? 0 : row.Field<int>("KiloSum2");
            KiloSum1 = row.IsNull("KiloSum1") ? 0 : row.Field<int>("KiloSum1");
            KiloSum16 = row.IsNull("KiloSum16") ? 0 : row.Field<int>("KiloSum16");
            KiloSum17 = row.IsNull("KiloSum17") ? 0 : row.Field<int>("KiloSum17");
            KiloSum18 = row.IsNull("KiloSum18") ? 0 : row.Field<int>("KiloSum18");
            KiloSum19 = row.IsNull("KiloSum19") ? 0 : row.Field<double>("KiloSum19");
            KiloSum20 = row.IsNull("KiloSum20") ? 0 : row.Field<double>("KiloSum20");
            KiloSum21 = row.IsNull("KiloSum21") ? 0 : row.Field<double>("KiloSum21");
            kilo16 = row.IsNull("kilo16") ? 0 : row.Field<int>("kilo16");
            kilo17 = row.IsNull("kilo17") ? 0 : row.Field<int>("kilo17");
            kilo18 = row.IsNull("kilo18") ? 0 : row.Field<int>("kilo18");
            kilo19 = row.IsNull("kilo19") ? 0 : row.Field<double>("kilo19");
            kilo20 = row.IsNull("kilo20") ? 0 : row.Field<double>("kilo20");
            kilo21 = row.IsNull("kilo21") ? 0 : row.Field<double>("kilo21");
            //check510 = row.IsNull("check610") ? false : row.Field<bool>("check510");
            //check59 = row.IsNull("check69") ? false : row.Field<bool>("check59");
            //check58 = row.IsNull("check68") ? false : row.Field<bool>("check58");
            //check57 = row.IsNull("check67") ? false : row.Field<bool>("check57");
            //check56 = row.IsNull("check66") ? false : row.Field<bool>("check56");
            //check55 = row.IsNull("check65") ? false : row.Field<bool>("check55");
            //check54 = row.IsNull("check64") ? false : row.Field<bool>("check54");
            //check53 = row.IsNull("check63") ? false : row.Field<bool>("check53");
            //check52 = row.IsNull("check62") ? false : row.Field<bool>("check52");
            //check51 = row.IsNull("check61") ? false : row.Field<bool>("check51");
        }
        public int id { get; set; }
        [Display(Name = "שם")] public string name { get; set; }
        [Display(Name = "טלפון")] public string phone { get; set; }
        [Display(Name = "כתובת")] public string address { get; set; }

        [Display(Name = "כתובת מייל")]
        [EmailAddress(ErrorMessage = "כתובת מייל שגויה")]
        public string email { get; set; }
        [Display(Name = "צורת תשלום")] public int? fkPaymentMethod { get; set; }
        [Display(Name = "הערות להזמנה")] public string remarks { get; set; }
        [Display(Name = "כמות")] public string humusKilo { get; set; }
        [Display(Name = "כמות")] public string fullKilo { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum10 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum9 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum8 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum7 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum6 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum5 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum4 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum3 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum2 { get; set; }
        [Display(Name = "סה''כ מחיר")] public int? sum1 { get; set; }
        [Display(Name = "סה''כ מנות")] public int? OrderCount { get; set; }
        [Display(Name = "סה''כ מחיר")] public double? OrderSum { get; set; }
        public int? kilo15 { get; set; }
        public int? kilo14 { get; set; }
        public int? kilo13 { get; set; }
        public int? kilo12 { get; set; }
        public int? kilo11 { get; set; }
        public int? kilo10 { get; set; }
        public int? kilo9 { get; set; }
        public int? kilo8 { get; set; }
        public int? kilo7 { get; set; }
        public int? kilo6 { get; set; }
        public int? kilo5 { get; set; }
        public int? kilo4 { get; set; }
        public int? kilo3 { get; set; }
        public int? kilo2 { get; set; }
        public int? kilo1 { get; set; }
        public int? KiloCount { get; set; }
        public bool check110 { get; set; }
        public bool check19 { get; set; }
        public bool check18 { get; set; }
        public bool check17 { get; set; }
        public bool check16 { get; set; }
        public bool check15 { get; set; }
        public bool check14 { get; set; }
        public bool check13 { get; set; }
        public bool check12 { get; set; }
        public bool check11 { get; set; }
        public bool check210 { get; set; }
        public bool check29 { get; set; }
        public bool check28 { get; set; }
        public bool check27 { get; set; }
        public bool check26 { get; set; }
        public bool check25 { get; set; }
        public bool check24 { get; set; }
        public bool check23 { get; set; }
        public bool check22 { get; set; }
        public bool check21 { get; set; }
        public bool check310 { get; set; }
        public bool check39 { get; set; }
        public bool check38 { get; set; }
        public bool check37 { get; set; }
        public bool check36 { get; set; }
        public bool check35 { get; set; }
        public bool check34 { get; set; }
        public bool check33 { get; set; }
        public bool check32 { get; set; }
        public bool check31 { get; set; }
        public bool check410 { get; set; }
        public bool check49 { get; set; }
        public bool check48 { get; set; }
        public bool check47 { get; set; }
        public bool check46 { get; set; }
        public bool check45 { get; set; }
        public bool check44 { get; set; }
        public bool check43 { get; set; }
        public bool check42 { get; set; }
        public bool check41 { get; set; }
        public bool check510 { get; set; }
        public bool check59 { get; set; }
        public bool check58 { get; set; }
        public bool check57 { get; set; }
        public bool check56 { get; set; }
        public bool check55 { get; set; }
        public bool check54 { get; set; }
        public bool check53 { get; set; }
        public bool check52 { get; set; }
        public bool check51 { get; set; }
        public string name5 { get; set; }
        public string name4 { get; set; }
        public string name3 { get; set; }
        public string name2 { get; set; }
        public string name1 { get; set; }
        public int? KiloSum15 { get; set; }
        public int? KiloSum14 { get; set; }
        public int? KiloSum13 { get; set; }
        public int? KiloSum12 { get; set; }
        public int? KiloSum11 { get; set; }
        public int? KiloSum10 { get; set; }
        public int? KiloSum9 { get; set; }
        public int? KiloSum8 { get; set; }
        public int? KiloSum7 { get; set; }
        public int? KiloSum6 { get; set; }
        public int? KiloSum5 { get; set; }
        public int? KiloSum4 { get; set; }
        public int? KiloSum3 { get; set; }
        public int? KiloSum2 { get; set; }
        public int? KiloSum1 { get; set; }
        public double? AllSum1 { get; set; }
        public double? AllSum2 { get; set; }

        public int? KiloSum16 { get; set; }
        public int? KiloSum17 { get; set; }
        public int? KiloSum18 { get; set; }
        public double? KiloSum19 { get; set; }
        public double? KiloSum20 { get; set; }
        public double? KiloSum21 { get; set; }
        public int? kilo16 { get; set; }
        public int? kilo17 { get; set; }
        public int? kilo18 { get; set; }
        public double? kilo19 { get; set; }
        public double? kilo20 { get; set; }
        public double? kilo21 { get; set; }

        public int? HidOrderCount { get; set; }
        public int? HidKiloCount { get; set; }
        public double? HidOrderSum { get; set; }

        public int? HidKiloSum16 { get; set; }
        public int? HidKiloSum17 { get; set; }
        public int? HidKiloSum18 { get; set; }
        public float? HidKiloSum19 { get; set; }
        public float? HidKiloSum20 { get; set; }
        public float? HidKiloSum21 { get; set; }
        public int? HidKiloSum15 { get; set; }
        public int? HidKiloSum14 { get; set; }
        public int? HidKiloSum13 { get; set; }
        public int? HidKiloSum12 { get; set; }
        public int? HidKiloSum11 { get; set; }
        public int? HidKiloSum10 { get; set; }
        public int? HidKiloSum9 { get; set; }
        public int? HidKiloSum8 { get; set; }
        public int? HidKiloSum7 { get; set; }
        public int? HidKiloSum6 { get; set; }
        public int? HidKiloSum5 { get; set; }
        public int? HidKiloSum4 { get; set; }
        public int? HidKiloSum3 { get; set; }
        public int? HidKiloSum2 { get; set; }
        public int? HidKiloSum1 { get; set; }
        public int? Hidsum10 { get; set; }
        public int? Hidsum9 { get; set; }
        public int? Hidsum8 { get; set; }
        public int? Hidsum7 { get; set; }
        public int? Hidsum6 { get; set; }
        public int? Hidsum5 { get; set; }
        public int? Hidsum4 { get; set; }
        public int? Hidsum3 { get; set; }
        public int? Hidsum2 { get; set; }
        public int? Hidsum1 { get; set; }

        public bool check610 { get; set; }
        public bool check69 { get; set; }
        public bool check68 { get; set; }
        public bool check67 { get; set; }
        public bool check66 { get; set; }
        public bool check65 { get; set; }
        public bool check64 { get; set; }
        public bool check63 { get; set; }
        public bool check62 { get; set; }
        public bool check61 { get; set; }
        public string name6 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (string.IsNullOrEmpty(name))
                results.Add(new ValidationResult("שם - שדה חובה"));

            if (string.IsNullOrEmpty(phone))
                results.Add(new ValidationResult("טלפון - שדה חובה"));

            if (string.IsNullOrEmpty(email))
                results.Add(new ValidationResult("כתובת מייל - שדה חובה"));

            if (string.IsNullOrEmpty(address))
                results.Add(new ValidationResult("כתובת - שדה חובה"));

            if (fkPaymentMethod == 0)
                results.Add(new ValidationResult("צורת תשלום - שדה חובה"));


            return results;
        }

    }
}
namespace CincinnatiApplication.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Employee
    {
        [JsonProperty("age_range")]
        public string AgeRange { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sex")]
        public Sex Sex { get; set; }

        [JsonProperty("race")]
        public Race Race { get; set; }

        [JsonProperty("business_title")]
        public string BusinessTitle { get; set; }

        [JsonProperty("std_hours")]
        [JsonConverter(typeof(ParseStringConverter))]
        public double StdHours { get; set; }


        [JsonProperty("jobtitle")]
        public string Jobtitle { get; set; }

        [JsonProperty("hire_date")]
        public DateTimeOffset HireDate { get; set; }
    }


    public enum JobFamily { D0Mgm, D1Afs, D2Fir, D2Pol, D4Pt, D5Adm, D6Msc, D7Law, D8Smg, D9Leg };

    public enum Paygroup { Ccl, Fir, Gen, Mgm, Pol };

    public enum Race { AmericanIndianAlaskanNative, AsianPacificIslander, Black, Hispanic, Unknown, White, Chinese };

    public enum SalAdminPlan { D0, D0C, D1, D4, D4M, D5, D6, D8, D9, F40, F48, Law, Pol };

    public enum Sex { F, M };

    public partial class Employee
    {
        public static Employee[] FromJson(string json) => JsonConvert.DeserializeObject<Employee[]>(json, CincinnatiApplication.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Employee[] self) => JsonConvert.SerializeObject(self, CincinnatiApplication.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                JobFamilyConverter.Singleton,
                PaygroupConverter.Singleton,
                RaceConverter.Singleton,
                SalAdminPlanConverter.Singleton,
                SexConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(double) || t == typeof(double?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            double l;
            if (double.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class JobFamilyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(JobFamily) || t == typeof(JobFamily?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "D0MGM":
                    return JobFamily.D0Mgm;
                case "D1AFS":
                    return JobFamily.D1Afs;
                case "D2FIR":
                    return JobFamily.D2Fir;
                case "D2POL":
                    return JobFamily.D2Pol;
                case "D4PT":
                    return JobFamily.D4Pt;
                case "D5ADM":
                    return JobFamily.D5Adm;
                case "D6MSC":
                    return JobFamily.D6Msc;
                case "D7LAW":
                    return JobFamily.D7Law;
                case "D8SMG":
                    return JobFamily.D8Smg;
                case "D9LEG":
                    return JobFamily.D9Leg;
            }
            throw new Exception("Cannot unmarshal type JobFamily");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (JobFamily)untypedValue;
            switch (value)
            {
                case JobFamily.D0Mgm:
                    serializer.Serialize(writer, "D0MGM");
                    return;
                case JobFamily.D1Afs:
                    serializer.Serialize(writer, "D1AFS");
                    return;
                case JobFamily.D2Fir:
                    serializer.Serialize(writer, "D2FIR");
                    return;
                case JobFamily.D2Pol:
                    serializer.Serialize(writer, "D2POL");
                    return;
                case JobFamily.D4Pt:
                    serializer.Serialize(writer, "D4PT");
                    return;
                case JobFamily.D5Adm:
                    serializer.Serialize(writer, "D5ADM");
                    return;
                case JobFamily.D6Msc:
                    serializer.Serialize(writer, "D6MSC");
                    return;
                case JobFamily.D7Law:
                    serializer.Serialize(writer, "D7LAW");
                    return;
                case JobFamily.D8Smg:
                    serializer.Serialize(writer, "D8SMG");
                    return;
                case JobFamily.D9Leg:
                    serializer.Serialize(writer, "D9LEG");
                    return;
            }
            throw new Exception("Cannot marshal type JobFamily");
        }

        public static readonly JobFamilyConverter Singleton = new JobFamilyConverter();
    }

    internal class PaygroupConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Paygroup) || t == typeof(Paygroup?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CCL":
                    return Paygroup.Ccl;
                case "FIR":
                    return Paygroup.Fir;
                case "GEN":
                    return Paygroup.Gen;
                case "MGM":
                    return Paygroup.Mgm;
                case "POL":
                    return Paygroup.Pol;
            }
            throw new Exception("Cannot unmarshal type Paygroup");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Paygroup)untypedValue;
            switch (value)
            {
                case Paygroup.Ccl:
                    serializer.Serialize(writer, "CCL");
                    return;
                case Paygroup.Fir:
                    serializer.Serialize(writer, "FIR");
                    return;
                case Paygroup.Gen:
                    serializer.Serialize(writer, "GEN");
                    return;
                case Paygroup.Mgm:
                    serializer.Serialize(writer, "MGM");
                    return;
                case Paygroup.Pol:
                    serializer.Serialize(writer, "POL");
                    return;
            }
            throw new Exception("Cannot marshal type Paygroup");
        }

        public static readonly PaygroupConverter Singleton = new PaygroupConverter();
    }

    internal class RaceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Race) || t == typeof(Race?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AMERICAN INDIAN/ALASKAN NATIVE":
                    return Race.AmericanIndianAlaskanNative;
                case "ASIAN/PACIFIC ISLANDER":
                    return Race.AsianPacificIslander;
                case "BLACK":
                    return Race.Black;
                case "HISPANIC":
                    return Race.Hispanic;
                case "UNKNOWN":
                    return Race.Unknown;
                case "WHITE":
                    return Race.White;
                case "CHINESE":
                    return Race.Chinese;
            }
            throw new Exception("Cannot unmarshal type Race");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Race)untypedValue;
            switch (value)
            {
                case Race.AmericanIndianAlaskanNative:
                    serializer.Serialize(writer, "AMERICAN INDIAN/ALASKAN NATIVE");
                    return;
                case Race.AsianPacificIslander:
                    serializer.Serialize(writer, "ASIAN/PACIFIC ISLANDER");
                    return;
                case Race.Black:
                    serializer.Serialize(writer, "BLACK");
                    return;
                case Race.Hispanic:
                    serializer.Serialize(writer, "HISPANIC");
                    return;
                case Race.Unknown:
                    serializer.Serialize(writer, "UNKNOWN");
                    return;
                case Race.White:
                    serializer.Serialize(writer, "WHITE");
                    return;
                case Race.Chinese:
                    serializer.Serialize(writer, "CHINESE");
                    return;
            }
            throw new Exception("Cannot marshal type Race");
        }

        public static readonly RaceConverter Singleton = new RaceConverter();
    }

    internal class SalAdminPlanConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SalAdminPlan) || t == typeof(SalAdminPlan?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "D0":
                    return SalAdminPlan.D0;
                case "D0C":
                    return SalAdminPlan.D0C;
                case "D1":
                    return SalAdminPlan.D1;
                case "D4":
                    return SalAdminPlan.D4;
                case "D4M":
                    return SalAdminPlan.D4M;
                case "D5":
                    return SalAdminPlan.D5;
                case "D6":
                    return SalAdminPlan.D6;
                case "D8":
                    return SalAdminPlan.D8;
                case "D9":
                    return SalAdminPlan.D9;
                case "F40":
                    return SalAdminPlan.F40;
                case "F48":
                    return SalAdminPlan.F48;
                case "LAW":
                    return SalAdminPlan.Law;
                case "POL":
                    return SalAdminPlan.Pol;
            }
            throw new Exception("Cannot unmarshal type SalAdminPlan");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SalAdminPlan)untypedValue;
            switch (value)
            {
                case SalAdminPlan.D0:
                    serializer.Serialize(writer, "D0");
                    return;
                case SalAdminPlan.D0C:
                    serializer.Serialize(writer, "D0C");
                    return;
                case SalAdminPlan.D1:
                    serializer.Serialize(writer, "D1");
                    return;
                case SalAdminPlan.D4:
                    serializer.Serialize(writer, "D4");
                    return;
                case SalAdminPlan.D4M:
                    serializer.Serialize(writer, "D4M");
                    return;
                case SalAdminPlan.D5:
                    serializer.Serialize(writer, "D5");
                    return;
                case SalAdminPlan.D6:
                    serializer.Serialize(writer, "D6");
                    return;
                case SalAdminPlan.D8:
                    serializer.Serialize(writer, "D8");
                    return;
                case SalAdminPlan.D9:
                    serializer.Serialize(writer, "D9");
                    return;
                case SalAdminPlan.F40:
                    serializer.Serialize(writer, "F40");
                    return;
                case SalAdminPlan.F48:
                    serializer.Serialize(writer, "F48");
                    return;
                case SalAdminPlan.Law:
                    serializer.Serialize(writer, "LAW");
                    return;
                case SalAdminPlan.Pol:
                    serializer.Serialize(writer, "POL");
                    return;
            }
            throw new Exception("Cannot marshal type SalAdminPlan");
        }

        public static readonly SalAdminPlanConverter Singleton = new SalAdminPlanConverter();
    }

    internal class SexConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Sex) || t == typeof(Sex?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "F":
                    return Sex.F;
                case "M":
                    return Sex.M;
            }
            throw new Exception("Cannot unmarshal type Sex");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Sex)untypedValue;
            switch (value)
            {
                case Sex.F:
                    serializer.Serialize(writer, "F");
                    return;
                case Sex.M:
                    serializer.Serialize(writer, "M");
                    return;
            }
            throw new Exception("Cannot marshal type Sex");
        }

        public static readonly SexConverter Singleton = new SexConverter();
    }
}


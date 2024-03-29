﻿//namespace CincinnatiApplication.Models
//{
//    public class Economy
//    {
//    }
//}
namespace CincinnatiApplication.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Economy
    {
        

        [JsonProperty("project_no")]
        public string ProjectNo { get; set; }

        [JsonProperty("organization_legal_name", NullValueHandling = NullValueHandling.Ignore)]
        public string OrganizationLegalName { get; set; }

        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [JsonProperty("approved_by_city_council", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ApprovedByCityCouncil { get; set; }

        [JsonProperty("total_project_cost_est", NullValueHandling = NullValueHandling.Ignore)]
        public string TotalProjectCostEst { get; set; }

        [JsonProperty("total_funding_all_sources_est", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverters))]
        public long? TotalFundingAllSourcesEst { get; set; }

        [JsonProperty("est_program_total_value")]
        [JsonConverter(typeof(ParseStringConverters))]
        public long EstProgramTotalValue { get; set; }

        [JsonProperty("site_street_address", NullValueHandling = NullValueHandling.Ignore)]
        public string SiteStreetAddress { get; set; }

    }

    public enum ProgramType { BelowMarketRateSale, CapitalGrant, CdbgGrant, Cra, DistrictTif, Focus52, Grant, GrossLease, GrowCincinnatiLoanFund, Home, Jctc, LandSale, Lease, LeedCra, Loan, Multiple, OtherCityGrant, OtherCityLoan, Pir, ProjectTif, Tif, TifGrant, TripleNetLease };

    public enum ProjectCategory { CommercialTaxAbatement, Grant, LeaseOfCityProperty, Loan, SaleOfCityProperty, TaxIncentive, TaxIncrementFinancing };

    public enum ProjectType { Commercial, Hotel, Industrial, Infrastructure, MixedUse, Office, Other, ProjectTypeIndustrial, ProjectTypeMixedUse, ProjectTypeOffice, ProjectTypeResidential, PublicInfrastructure, Residential, Retail, Undetermined };

    public partial class Economy
    {
        public static Economy[] FromJson(string json) => JsonConvert.DeserializeObject<Economy[]>(json, CincinnatiApplication.Models.Converter.Settings);
    }

    public static class Serializes
    {
        public static string ToJson(this Economy[] self) => JsonConvert.SerializeObject(self, CincinnatiApplication.Models.Converter.Settings);
    }

    internal static class Converters
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ProgramTypeConverter.Singleton,
                ProjectCategoryConverter.Singleton,
                ProjectTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverters: JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
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

        public static readonly ParseStringConverters Singleton = new ParseStringConverters();
    }

    internal class ProgramTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProgramType) || t == typeof(ProgramType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BELOW MARKET RATE SALE":
                    return ProgramType.BelowMarketRateSale;
                case "CAPITAL GRANT":
                    return ProgramType.CapitalGrant;
                case "CDBG GRANT":
                    return ProgramType.CdbgGrant;
                case "CRA":
                    return ProgramType.Cra;
                case "DISTRICT TIF":
                    return ProgramType.DistrictTif;
                case "FOCUS 52":
                    return ProgramType.Focus52;
                case "GROSS LEASE":
                    return ProgramType.GrossLease;
                case "GROW CINCINNATI LOAN FUND":
                    return ProgramType.GrowCincinnatiLoanFund;
                case "Grant":
                    return ProgramType.Grant;
                case "HOME":
                    return ProgramType.Home;
                case "JCTC":
                    return ProgramType.Jctc;
                case "LEED CRA":
                    return ProgramType.LeedCra;
                case "Land Sale":
                    return ProgramType.LandSale;
                case "Lease":
                    return ProgramType.Lease;
                case "Loan":
                    return ProgramType.Loan;
                case "Multiple":
                    return ProgramType.Multiple;
                case "OTHER CITY GRANT":
                    return ProgramType.OtherCityGrant;
                case "OTHER CITY LOAN":
                    return ProgramType.OtherCityLoan;
                case "PIR":
                    return ProgramType.Pir;
                case "PROJECT TIF":
                    return ProgramType.ProjectTif;
                case "TIF":
                    return ProgramType.Tif;
                case "TIF GRANT":
                    return ProgramType.TifGrant;
                case "TRIPLE NET LEASE":
                    return ProgramType.TripleNetLease;
            }
            throw new Exception("Cannot unmarshal type ProgramType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ProgramType)untypedValue;
            switch (value)
            {
                case ProgramType.BelowMarketRateSale:
                    serializer.Serialize(writer, "BELOW MARKET RATE SALE");
                    return;
                case ProgramType.CapitalGrant:
                    serializer.Serialize(writer, "CAPITAL GRANT");
                    return;
                case ProgramType.CdbgGrant:
                    serializer.Serialize(writer, "CDBG GRANT");
                    return;
                case ProgramType.Cra:
                    serializer.Serialize(writer, "CRA");
                    return;
                case ProgramType.DistrictTif:
                    serializer.Serialize(writer, "DISTRICT TIF");
                    return;
                case ProgramType.Focus52:
                    serializer.Serialize(writer, "FOCUS 52");
                    return;
                case ProgramType.GrossLease:
                    serializer.Serialize(writer, "GROSS LEASE");
                    return;
                case ProgramType.GrowCincinnatiLoanFund:
                    serializer.Serialize(writer, "GROW CINCINNATI LOAN FUND");
                    return;
                case ProgramType.Grant:
                    serializer.Serialize(writer, "Grant");
                    return;
                case ProgramType.Home:
                    serializer.Serialize(writer, "HOME");
                    return;
                case ProgramType.Jctc:
                    serializer.Serialize(writer, "JCTC");
                    return;
                case ProgramType.LeedCra:
                    serializer.Serialize(writer, "LEED CRA");
                    return;
                case ProgramType.LandSale:
                    serializer.Serialize(writer, "Land Sale");
                    return;
                case ProgramType.Lease:
                    serializer.Serialize(writer, "Lease");
                    return;
                case ProgramType.Loan:
                    serializer.Serialize(writer, "Loan");
                    return;
                case ProgramType.Multiple:
                    serializer.Serialize(writer, "Multiple");
                    return;
                case ProgramType.OtherCityGrant:
                    serializer.Serialize(writer, "OTHER CITY GRANT");
                    return;
                case ProgramType.OtherCityLoan:
                    serializer.Serialize(writer, "OTHER CITY LOAN");
                    return;
                case ProgramType.Pir:
                    serializer.Serialize(writer, "PIR");
                    return;
                case ProgramType.ProjectTif:
                    serializer.Serialize(writer, "PROJECT TIF");
                    return;
                case ProgramType.Tif:
                    serializer.Serialize(writer, "TIF");
                    return;
                case ProgramType.TifGrant:
                    serializer.Serialize(writer, "TIF GRANT");
                    return;
                case ProgramType.TripleNetLease:
                    serializer.Serialize(writer, "TRIPLE NET LEASE");
                    return;
            }
            throw new Exception("Cannot marshal type ProgramType");
        }

        public static readonly ProgramTypeConverter Singleton = new ProgramTypeConverter();
    }

    internal class ProjectCategoryConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProjectCategory) || t == typeof(ProjectCategory?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "COMMERCIAL TAX ABATEMENT":
                    return ProjectCategory.CommercialTaxAbatement;
                case "GRANT":
                    return ProjectCategory.Grant;
                case "LEASE OF CITY PROPERTY":
                    return ProjectCategory.LeaseOfCityProperty;
                case "LOAN":
                    return ProjectCategory.Loan;
                case "SALE OF CITY PROPERTY":
                    return ProjectCategory.SaleOfCityProperty;
                case "TAX INCENTIVE":
                    return ProjectCategory.TaxIncentive;
                case "TAX INCREMENT FINANCING":
                    return ProjectCategory.TaxIncrementFinancing;
            }
            throw new Exception("Cannot unmarshal type ProjectCategory");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ProjectCategory)untypedValue;
            switch (value)
            {
                case ProjectCategory.CommercialTaxAbatement:
                    serializer.Serialize(writer, "COMMERCIAL TAX ABATEMENT");
                    return;
                case ProjectCategory.Grant:
                    serializer.Serialize(writer, "GRANT");
                    return;
                case ProjectCategory.LeaseOfCityProperty:
                    serializer.Serialize(writer, "LEASE OF CITY PROPERTY");
                    return;
                case ProjectCategory.Loan:
                    serializer.Serialize(writer, "LOAN");
                    return;
                case ProjectCategory.SaleOfCityProperty:
                    serializer.Serialize(writer, "SALE OF CITY PROPERTY");
                    return;
                case ProjectCategory.TaxIncentive:
                    serializer.Serialize(writer, "TAX INCENTIVE");
                    return;
                case ProjectCategory.TaxIncrementFinancing:
                    serializer.Serialize(writer, "TAX INCREMENT FINANCING");
                    return;
            }
            throw new Exception("Cannot marshal type ProjectCategory");
        }

        public static readonly ProjectCategoryConverter Singleton = new ProjectCategoryConverter();
    }

    internal class ProjectTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ProjectType) || t == typeof(ProjectType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Commercial":
                    return ProjectType.Commercial;
                case "HOTEL":
                    return ProjectType.Hotel;
                case "INDUSTRIAL":
                    return ProjectType.Industrial;
                case "Industrial":
                    return ProjectType.ProjectTypeIndustrial;
                case "Infrastructure":
                    return ProjectType.Infrastructure;
                case "MIXED USE":
                    return ProjectType.MixedUse;
                case "Mixed Use":
                    return ProjectType.ProjectTypeMixedUse;
                case "OFFICE":
                    return ProjectType.Office;
                case "Office":
                    return ProjectType.ProjectTypeOffice;
                case "Other":
                    return ProjectType.Other;
                case "PUBLIC INFRASTRUCTURE":
                    return ProjectType.PublicInfrastructure;
                case "RESIDENTIAL":
                    return ProjectType.Residential;
                case "RETAIL":
                    return ProjectType.Retail;
                case "Residential":
                    return ProjectType.ProjectTypeResidential;
                case "UNDETERMINED":
                    return ProjectType.Undetermined;
            }
            throw new Exception("Cannot unmarshal type ProjectType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ProjectType)untypedValue;
            switch (value)
            {
                case ProjectType.Commercial:
                    serializer.Serialize(writer, "Commercial");
                    return;
                case ProjectType.Hotel:
                    serializer.Serialize(writer, "HOTEL");
                    return;
                case ProjectType.Industrial:
                    serializer.Serialize(writer, "INDUSTRIAL");
                    return;
                case ProjectType.ProjectTypeIndustrial:
                    serializer.Serialize(writer, "Industrial");
                    return;
                case ProjectType.Infrastructure:
                    serializer.Serialize(writer, "Infrastructure");
                    return;
                case ProjectType.MixedUse:
                    serializer.Serialize(writer, "MIXED USE");
                    return;
                case ProjectType.ProjectTypeMixedUse:
                    serializer.Serialize(writer, "Mixed Use");
                    return;
                case ProjectType.Office:
                    serializer.Serialize(writer, "OFFICE");
                    return;
                case ProjectType.ProjectTypeOffice:
                    serializer.Serialize(writer, "Office");
                    return;
                case ProjectType.Other:
                    serializer.Serialize(writer, "Other");
                    return;
                case ProjectType.PublicInfrastructure:
                    serializer.Serialize(writer, "PUBLIC INFRASTRUCTURE");
                    return;
                case ProjectType.Residential:
                    serializer.Serialize(writer, "RESIDENTIAL");
                    return;
                case ProjectType.Retail:
                    serializer.Serialize(writer, "RETAIL");
                    return;
                case ProjectType.ProjectTypeResidential:
                    serializer.Serialize(writer, "Residential");
                    return;
                case ProjectType.Undetermined:
                    serializer.Serialize(writer, "UNDETERMINED");
                    return;
            }
            throw new Exception("Cannot marshal type ProjectType");
        }

        public static readonly ProjectTypeConverter Singleton = new ProjectTypeConverter();
    }
}

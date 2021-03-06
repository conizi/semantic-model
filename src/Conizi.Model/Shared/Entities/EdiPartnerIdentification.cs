﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Conizi.Model.Shared.Attributes;
using Conizi.Model.Shared.Interfaces;
using Newtonsoft.Json;

namespace Conizi.Model.Shared.Entities
{
    /// <summary>
    /// Fields to identify the partner or/and further data routing information
    /// </summary>
    [DisplayName("Fields to identify the partner")]
    
    [ConiziAdditionalProperties(false)]
    [ConiziAllowXProperties]
    public class EdiPartnerIdentification : EdiMessageRouting, IAddress
    {
        /// <summary>
        /// Name of the address
        /// </summary>
        [DisplayName("Name of the address")]
        public string Name { get; set; }

        /// <summary>
        /// Name2 of the address
        /// </summary>
        [DisplayName("Name2 of the address")]
        public string Name2 { get; set; }

        /// <summary>
        /// Street of the address
        /// </summary>
        [DisplayName("Street of the address")]
        public string Street { get; set; }

        /// <summary>
        /// House number of the address
        /// </summary>
        [DisplayName("House number of the address")]
        public string HouseNumber { get; set; }

        /// <summary>
        /// Zip code of the Address
        /// </summary>
        [DisplayName("Zip code of the Address")]
        public string ZipCode { get; set; }

        /// <summary>
        /// City of the address
        /// </summary>
        [DisplayName("City of the address")]
        public string City { get; set; }

        /// <summary>
        /// Town area address"
        /// </summary>
        [DisplayName("Town area address")]
        public string TownArea { get; set; }

        /// <summary>
        /// Country code of the address Use ISO 3166-1 Alpha-2 codes. See also <seealso href="https://en.wikipedia.org/wiki/ISO_3166-1"></seealso>
        /// </summary>
        [DisplayName("Country code of the address Use ISO 3166-1 Alpha-2 codes.")]
        public string CountryCode { get; set; }

        /// <summary>
        /// Email of the address
        /// </summary>
        [DisplayName("Email of the address")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Phone number of the address
        /// </summary>
        [Phone]
        [DisplayName("Phone number of the address")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Additional address lines of the address
        /// </summary>
        [DisplayName("Additional address lines of the address")]
        public List<string> AdditionalAddressLines { get; set; }

        /// <summary>
        /// Reference for an address
        /// </summary>
        [DisplayName("Reference for an address")]
        public string Reference { get; set; }

        /// <summary>
        /// The contact person
        /// </summary>
        [DisplayName("The contact person")]
        public string ContactPerson { get; set; }

        /// <summary>
        /// The Fax number
        /// </summary>
        [Phone]
        [DisplayName("The Fax number")]
        public string FaxNumber { get; set; }

        /// <summary>
        /// The geo position
        /// </summary>
        [JsonProperty("geoPosition", Order = -9, Required = Required.DisallowNull)]
        public EdiGeoPosition GeoPosition { get; set; }
    }

    /// <summary>
    /// Routing information to identify the parties involved in the data transfer (e.g. PartnerId, ConiziId...)
    /// </summary>
    
    [DisplayName("Routing information of the message")]
    [Description("Routing information to identify the parties involved in the data transfer")]
    [ConiziAdditionalProperties(false)]
    [ConiziAllowXProperties]
    public class EdiMessageRouting : EdiPatternPropertiesBase
    {
        /// <summary>
        /// Partner Id is used to identify the real sender or receiver (e.g. 1234)
        /// </summary>
        [DisplayName("The PartnerId")]
        [Description(
            "The partner which is sending the message to the receiving partner for further actions (e.g. 1234)")]
        [MaxLength(50)]
        public string PartnerId { get; set; }

        /// <summary>
        /// Edi Id is used to identify the technical sender or receiver (e.g. CONIZVK)
        /// </summary>
        [DisplayName("The Edi Id")]
        [Description("The Edi Id is the technical sender or receiver (e.g. CONIZVK)")]
        [StringLength(50)]
        public string EdiId { get; set; }

        /// <summary>
        /// Conizi Id is used to identify the sending or receiving Tenant/Site/App on the conizi platform 
        /// </summary>
        [DisplayName("The Conizi Id")]
        [Description("The conizi id for internal routing purposes")]
        [MaxLength(50)]
        public string ConiziId { get; set; }

        //[JsonProperty("network", Required = Required.DisallowNull)]
        //public EdiNetwork Network { get; set; }
    }
}
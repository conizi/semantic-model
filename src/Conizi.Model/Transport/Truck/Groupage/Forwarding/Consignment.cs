﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Conizi.Model.Shared.Attributes;
using Conizi.Model.Shared.Entities;
using Newtonsoft.Json;

namespace Conizi.Model.Transport.Truck.Groupage.Forwarding
{
    [ConiziSchema("http://conizi.io/model/transport/truck/groupage/forwarding/consignment.json", "consignment.json")]
    [DisplayName("Consignment")]
    [Description("A single consignment which is transferred between two partners. Usually used within the context a manifest")]
    public class Consignment : EdiDocument
    {

        [DisplayName("Unique central consignment number")]
        public string ConsignmentObjectId { get; set; }
        [DisplayName("Consignment number of the shipping partner")]
        public string ConsignmentNoShippingPartner { get; set; }
        [DisplayName("Consignment number of the receiving partner")]
        public string ConsignmentNoReceivingPartner { get; set; }

        [DisplayName("Shipping date")]
        [JsonProperty(Required = Required.Always)]
        public DateTime ShippingDate { get; set; }

        [DisplayName("Manifest id of the shipping partner")]
        public string ManifestId { get; set; }

        [DisplayName("Is a pre advice")]
        public bool IsPreAdvice { get; set; }

        [JsonProperty("additionPartners")]
        public EdiPartnerIdentification AdditionalPartners { get; set; }




    }
}

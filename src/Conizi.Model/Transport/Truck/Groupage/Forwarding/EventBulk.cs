﻿using System.Collections.Generic;
using System.ComponentModel;
using Conizi.Model.Shared.Attributes;
using Conizi.Model.Shared.Entities;
using Newtonsoft.Json;

namespace Conizi.Model.Transport.Truck.Groupage.Forwarding
{

    /// <summary>
    /// A single consignment which is transferred between two partners. Usually used within the context a manifest
    /// </summary>
    [ConiziSchema("https://model.conizi.io/v1/transport/truck/groupage/forwarding/event-bulk.json", "event-bulk.json")]
    [DisplayName("Bulk Event")]
    [Description("Events for different consignments, pickup orders or packages, that can be send in bulk, which occured during the processing")]
    [ConiziAdditionalProperties(false)]
    [ConiziAllowXProperties]
    public class EventBulk : EdiModel
    {
        /// <summary>
        /// List of consignment events <see cref="ConsignmentEvent"/>
        /// </summary>
        [JsonProperty("consignment-events")]
        public List<ConsignmentEvent> ConsignmentEvents { get; set; }

        /// <summary>
        /// List of pickup order events <see cref="PickupOrderEvent"/>
        /// </summary>
        [JsonProperty("pickuporder-events")]
        public List<PickupOrderEvent> PickupOrderEvents { get; set; }

        /// <summary>
        /// List of package events <see cref="PackageEvent"/>
        /// </summary>
        [JsonProperty("package-events")]
        public List<PackageEvent> PackageEvents { get; set; }

        /// <summary>
        /// List of tour events <see cref="TourEvent"/>
        /// </summary>
        [JsonProperty("tour-events")]
        public List<TourEvent> TourEvents { get; set; }
    }
}
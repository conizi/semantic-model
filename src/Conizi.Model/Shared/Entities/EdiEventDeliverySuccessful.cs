﻿using System.ComponentModel;
using Conizi.Model.Shared.Attributes;
using Conizi.Model.Shared.Interfaces;

namespace Conizi.Model.Shared.Entities
{
    /// <summary>
    ///Events indicating successful delivery
    /// </summary>
    [DisplayName("Delivery successful")]
    [Description("Events indicating successful delivery")]
    [ConiziAdditionalProperties(false)]
    [ConiziAllowXProperties]
    public class EdiEventDeliverySuccessful : EdiEventBase
    {
        /// <summary>
        /// Detailed information about the exceptions that occurred when consignment was successfully delivered
        /// </summary>
        public EdiDeliverySuccessfulExceptions Exceptions { get; set; }

        /// <summary>
        /// Name of the person which accepted the consignment
        /// </summary>
        [DisplayName("Signee")]
        [Description("Name of the person which accepted the consignment")]
        public string Signee { get; set; }

        /// <summary>
        /// Time spent waiting during delivery
        /// </summary>
        [DisplayName("Wait time")]
        [Description("Time spent waiting during delivery")]
        public string WaitTime { get; set; }
    }
}
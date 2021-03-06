﻿using System;
using System.ComponentModel;
using Conizi.Model.Shared.Attributes;
using Newtonsoft.Json;

namespace Conizi.Model.Shared.Entities
{
    /// <summary>
    /// Event to notify about vehicle specific incidents
    /// </summary>
    [DisplayName("Vehicle specific Event")]
    [Description("Event to notify about vehicle specific incidents")]
    [ConiziAdditionalProperties(false)]
    [ConiziAllowXProperties]
    
    public class EdiVehicleSpecificEvent : EdiTourEventBase
    {
        /// <summary>
        /// Weight of the vehicle
        /// </summary>
        [DisplayName("Weight of vehicle")]
        [Description("Weight of the vehicle in kg")]
        public decimal? Weight { get; set; }

        /// <summary>
        /// Available loading meter
        /// </summary>
        [DisplayName("loading meter")]
        [Description("Available loading meter")]
        public decimal? LoadingMeter { get; set; }

        /// <summary>
        /// Name of the driver
        /// </summary>
        [DisplayName("Driver Name")]
        [Description("Name of the driver")]
        public string DriverName { get; set; }

        /// <summary>
        /// Name of the co-driver
        /// </summary>
        [DisplayName("Co-driver Name")]
        [Description("Name of the co-driver")]
        public string CoDriverName { get; set; }

        /// <summary>
        /// Mileage of the vehicle at tour start
        /// </summary>
        [DisplayName("Mileage Start")]
        [Description("Mileage of the vehicle at tour start")]
        public decimal? MileageStart { get; set; }

        /// <summary>
        /// Mileage of the vehicle at the end of the tour
        /// </summary>
        [DisplayName("Mileage Finish")]
        [Description("Mileage of the vehicle at the end of the tour")]
        public decimal? MileageFinish { get; set; }

        /// <summary>
        /// Current temperature in degrees Celsius
        /// </summary>
        [DisplayName("Temperature")]
        [Description("Current temperature in degrees Celsius")]
        public decimal? Temperature { get; set; }

        /// <summary>
        /// Registration number of the truck
        /// </summary>
        /// <remarks>Should be similar to <see cref="EdiVehicle.Registration"/> of the <see cref="EdiDriver"/> entity</remarks>
        [DisplayName("Truck Registration Number")]
        [Description("The registration number of the truck")]
        public string TruckRegistrationNumber { get; set; }

        /// <summary>
        /// Registration number of the trailer
        /// </summary>
        /// <remarks> Should be similar to <see cref="EdiVehicle.Registration"/> of the <see cref="EdiDriver"/> entity, when a trailer is set</remarks>
        [DisplayName("Trailer Registration Number")]
        [Description("Registration number of the trailer")]
        public string TrailerRegistrationNumber { get; set; }


    }
}
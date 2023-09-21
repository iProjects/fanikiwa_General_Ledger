//====================================================================================================
// Code generated with Inertia: BE Gen (Build 2.5.4750.27569)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by fmuraya at SOFTBOOKSSERVER on 08/24/2013 16:50:55 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace fanikiwaGL.Entities
{
    /// <summary>
    /// Represents a row of Setting data.
    /// </summary>
    [DataContract]
    public partial class Setting
    {

        /// <summary>
        /// Gets or sets a string value for the SSKey column.
        /// </summary>
        [DataMember] 
        public string SSKey { get; set; }

        /// <summary>
        /// Gets or sets a string value for the SSValue column.
        /// </summary>
        [DataMember]
        public string SSValue { get; set; }

        /// <summary>
        /// Gets or sets a string value for the SSValueType column.
        /// </summary>
        [DataMember]
        public string SSValueType { get; set; }

        /// <summary>
        /// Gets or sets a string value for the Description column.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a int value for the SGroup column.
        /// </summary>
        [DataMember]
        public int SGroup { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the SSSystem column.
        /// </summary>
        [DataMember]
        public bool SSSystem { get; set; }
    }
}

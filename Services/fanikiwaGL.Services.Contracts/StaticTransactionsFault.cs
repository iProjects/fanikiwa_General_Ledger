//====================================================================================================
// Code generated with Velocity: SL Gen (Build 2.4.4750.27570)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by fmuraya at SOFTBOOKSSERVER on 10/21/2013 17:39:09 
//====================================================================================================

using System.Runtime.Serialization;

namespace fanikiwaGL.Services.Contracts
{
    /// <summary>
    /// Fault contract class.
    /// </summary>
    [DataContract]
    public class StaticTransactionsFault
    {
        [DataMember]
        public string Message { get; set; }

        public StaticTransactionsFault(string message)
        {
            this.Message = message;
        }
    }
}

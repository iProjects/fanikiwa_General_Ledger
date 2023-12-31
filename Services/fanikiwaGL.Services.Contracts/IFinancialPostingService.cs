//====================================================================================================
// Code generated with Velocity: SL Gen (Build 2.4.4750.27570)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by fmuraya at SOFTBOOKSSERVER on 10/21/2013 13:27:40 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel;
using fanikiwaGL.Entities;
using fanikiwaGL.Framework;

namespace fanikiwaGL.Services.Contracts
{
    /// <summary>
    /// Service contract for FinancialPostingService.
    /// </summary>
    [ServiceContract]
    public interface IFinancialPostingService
    {

        [OperationContract]
        bool BatchPost(List<Transaction> Trans);

        [OperationContract]
        void PostSingle(Transaction transaction);

        [OperationContract]
        SimulatePostStatus SimulatePostSingle(Transaction transaction);

        [OperationContract]
        BatchSimulateStatus SimulatePostBatch(List<Transaction> transactions);
    }
}

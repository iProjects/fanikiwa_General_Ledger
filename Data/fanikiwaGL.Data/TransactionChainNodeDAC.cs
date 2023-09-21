//====================================================================================================
// Code generated with Momentum: DAC Gen (Build 2.5.4750.27570)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by francis.muraya at KPC7070W on 08/21/2013 08:11:10 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using fanikiwaGL.Entities;

namespace fanikiwaGL.Data
{
    /// <summary>
    /// TransactionChainNode data access component. Manages CRUD operations for the TransactionChainNode table.
    /// </summary>
    public partial class TransactionChainNodeDAC : DataAccessComponent
    {

        /// <summary>
        /// Inserts a new row in the TransactionChainNode table.
        /// </summary>
        /// <param name="transactionChainNode">A TransactionChainNode object.</param>
        /// <returns>An updated TransactionChainNode object.</returns>
        public TransactionChainNode Create(TransactionChainNode transactionChainNode)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.TransactionChainNode ([ParentId], [Descripion], [TransactionType]) " +
                "VALUES(@ParentId, @Descripion, @TransactionType); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@ParentId", DbType.Int32, transactionChainNode.ParentId);
                db.AddInParameter(cmd, "@Descripion", DbType.StringFixedLength, transactionChainNode.Descripion);
                db.AddInParameter(cmd, "@TransactionType", DbType.Int32, transactionChainNode.TransactionType);

                // Get the primary key value.
                transactionChainNode.NodeId = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return transactionChainNode;
        }

        /// <summary>
        /// Updates an existing row in the TransactionChainNode table.
        /// </summary>
        /// <param name="transactionChainNode">A TransactionChainNode entity object.</param>
        public void UpdateById(TransactionChainNode transactionChainNode)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.TransactionChainNode " +
                "SET " +
                    "[ParentId]=@ParentId, " +
                    "[Descripion]=@Descripion, " +
                    "[TransactionType]=@TransactionType " +
                "WHERE [NodeId]=@NodeId ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@ParentId", DbType.Int32, transactionChainNode.ParentId);
                db.AddInParameter(cmd, "@Descripion", DbType.StringFixedLength, transactionChainNode.Descripion);
                db.AddInParameter(cmd, "@TransactionType", DbType.Int32, transactionChainNode.TransactionType);
                db.AddInParameter(cmd, "@NodeId", DbType.Int32, transactionChainNode.NodeId);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the TransactionChainNode table.
        /// </summary>
        /// <param name="nodeId">A nodeId value.</param>
        public void DeleteById(int nodeId)
        {
            const string SQL_STATEMENT = "DELETE dbo.TransactionChainNode " +
                                         "WHERE [NodeId]=@NodeId ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.

                db.AddInParameter(cmd, "@NodeId", DbType.Int32, nodeId);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the TransactionChainNode table.
        /// </summary>
        /// <param name="nodeId">A NodeId value.</param>
        /// <returns>A TransactionChainNode object with data populated from the database.</returns>
        public TransactionChainNode SelectById(int nodeId)
        {
            const string SQL_STATEMENT =
                "SELECT [NodeId], [ParentId], [Descripion], [TransactionType] " +
                "FROM dbo.TransactionChainNode  " +
                "WHERE [NodeId]=@NodeId ";

            TransactionChainNode transactionChainNode = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@NodeId", DbType.Int32, nodeId);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new TransactionChainNode
                        transactionChainNode = new TransactionChainNode();

                        // Read values.
                        transactionChainNode.NodeId = base.GetDataValue<int>(dr, "NodeId");
                        transactionChainNode.ParentId = base.GetDataValue<int>(dr, "ParentId");
                        transactionChainNode.Descripion = base.GetDataValue<string>(dr, "Descripion");
                        transactionChainNode.TransactionType = base.GetDataValue<int>(dr, "TransactionType");
                    }
                }
            }

            return transactionChainNode;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the TransactionChainNode table.
        /// </summary>
        /// <returns>A collection of TransactionChainNode objects.</returns>		
        public List<TransactionChainNode> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [NodeId], [ParentId], [Descripion], [TransactionType] " +
                "FROM dbo.TransactionChainNode ";

            List<TransactionChainNode> result = new List<TransactionChainNode>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new TransactionChainNode
                        TransactionChainNode transactionChainNode = new TransactionChainNode();

                        // Read values.
                        transactionChainNode.NodeId = base.GetDataValue<int>(dr, "NodeId");
                        transactionChainNode.ParentId = base.GetDataValue<int>(dr, "ParentId");
                        transactionChainNode.Descripion = base.GetDataValue<string>(dr, "Descripion");
                        transactionChainNode.TransactionType = base.GetDataValue<int>(dr, "TransactionType");

                        // Add to List.
                        result.Add(transactionChainNode);
                    }
                }
            }

            return result;
        }
    }
}

//====================================================================================================
// Code generated with Momentum: DAC Gen (Build 2.5.4750.27570)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by fmuraya at SOFTBOOKSSERVER on 08/24/2013 16:52:15 
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
    /// Transactions data access component. Manages CRUD operations for the Transactions table.
    /// </summary>
    public partial class TransactionDAC : DataAccessComponent
    {

        /// <summary>
        /// Inserts a new row in the Transactions table.
        /// </summary>
        /// <param name="transaction">A Transaction object.</param>
        /// <returns>An updated Transaction object.</returns>
        public Transaction Create(Transaction transaction)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.Transactions ([TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate], [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID], [ForcePostFlag], [Reference], [ContraReference]) " +
                "VALUES(@TransactionTypeId, @AccountID, @Amount, @PostDate, @RecordDate, @ValueDate, @Narrative, @StatementFlag, @Authorizer, @UserID, @ForcePostFlag, @Reference, @ContraReference); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@TransactionTypeId", DbType.Int32, transaction.TransactionTypeId);
                db.AddInParameter(cmd, "@AccountID", DbType.Int32, transaction.AccountID);
                db.AddInParameter(cmd, "@Amount", DbType.Currency, transaction.Amount);
                db.AddInParameter(cmd, "@PostDate", DbType.DateTime2, transaction.PostDate);
                db.AddInParameter(cmd, "@RecordDate", DbType.DateTime2, transaction.RecordDate);
                db.AddInParameter(cmd, "@ValueDate", DbType.DateTime2, transaction.ValueDate);
                db.AddInParameter(cmd, "@Narrative", DbType.String, transaction.Narrative);
                db.AddInParameter(cmd, "@StatementFlag", DbType.String, transaction.StatementFlag);
                db.AddInParameter(cmd, "@Authorizer", DbType.String, transaction.Authorizer);
                db.AddInParameter(cmd, "@UserID", DbType.String, transaction.UserID);
                db.AddInParameter(cmd, "@ForcePostFlag", DbType.Boolean, transaction.ForcePostFlag);
                db.AddInParameter(cmd, "@Reference", DbType.AnsiString, transaction.Reference);
                db.AddInParameter(cmd, "@ContraReference", DbType.AnsiString, transaction.ContraReference);

                // Get the primary key value.
                transaction.TransactionID = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return transaction;
        }

        /// <summary>
        /// Updates an existing row in the Transactions table.
        /// </summary>
        /// <param name="transaction">A Transaction entity object.</param>
        public void UpdateById(Transaction transaction)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.Transactions " +
                "SET " +
                    "[TransactionTypeId]=@TransactionTypeId, " +
                    "[AccountID]=@AccountID, " +
                    "[Amount]=@Amount, " +
                    "[PostDate]=@PostDate, " +
                    "[RecordDate]=@RecordDate, " +
                    "[ValueDate]=@ValueDate, " +
                    "[Narrative]=@Narrative, " +
                    "[StatementFlag]=@StatementFlag, " +
                    "[Authorizer]=@Authorizer, " +
                    "[UserID]=@UserID, " +
                    "[ForcePostFlag]=@ForcePostFlag, " +
                    "[Reference]=@Reference, " +
                    "[ContraReference]=@ContraReference " +
                "WHERE [TransactionID]=@TransactionID ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@TransactionTypeId", DbType.Int32, transaction.TransactionTypeId);
                db.AddInParameter(cmd, "@AccountID", DbType.Int32, transaction.AccountID);
                db.AddInParameter(cmd, "@Amount", DbType.Currency, transaction.Amount);
                db.AddInParameter(cmd, "@PostDate", DbType.DateTime2, transaction.PostDate);
                db.AddInParameter(cmd, "@RecordDate", DbType.DateTime2, transaction.RecordDate);
                db.AddInParameter(cmd, "@ValueDate", DbType.DateTime2, transaction.ValueDate);
                db.AddInParameter(cmd, "@Narrative", DbType.String, transaction.Narrative);
                db.AddInParameter(cmd, "@StatementFlag", DbType.String, transaction.StatementFlag);
                db.AddInParameter(cmd, "@Authorizer", DbType.String, transaction.Authorizer);
                db.AddInParameter(cmd, "@UserID", DbType.String, transaction.UserID);
                db.AddInParameter(cmd, "@ForcePostFlag", DbType.Boolean, transaction.ForcePostFlag);
                db.AddInParameter(cmd, "@Reference", DbType.AnsiString, transaction.Reference);
                db.AddInParameter(cmd, "@ContraReference", DbType.AnsiString, transaction.ContraReference);
                db.AddInParameter(cmd, "@TransactionID", DbType.Int32, transaction.TransactionID);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the Transactions table.
        /// </summary>
        /// <param name="transactionID">A transactionID value.</param>
        public void DeleteById(int transactionID)
        {
            const string SQL_STATEMENT = "DELETE dbo.Transactions " +
                                         "WHERE [TransactionID]=@TransactionID ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.

                db.AddInParameter(cmd, "@TransactionID", DbType.Int32, transactionID);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the Transactions table.
        /// </summary>
        /// <param name="transactionID">A TransactionID value.</param>
        /// <returns>A Transaction object with data populated from the database.</returns>
        public Transaction SelectById(int transactionID)
        {
            const string SQL_STATEMENT =
                "SELECT [TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate]" +
                        ", [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID], [ForcePostFlag]" +
                        ", [Reference], [ContraReference] " +
                "FROM dbo.Transactions  " +
                "WHERE [TransactionID]=@TransactionID ";

            Transaction transaction = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@TransactionID", DbType.Int32, transactionID);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new Transaction
                        transaction = new Transaction();

                        // Read values.
                        transaction.TransactionID = base.GetDataValue<int>(dr, "TransactionID");
                        transaction.TransactionTypeId = base.GetDataValue<int>(dr, "TransactionTypeId");
                        transaction.AccountID = base.GetDataValue<int>(dr, "AccountID");
                        transaction.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        transaction.PostDate = base.GetDataValue<DateTime>(dr, "PostDate");
                        transaction.RecordDate = base.GetDataValue<DateTime>(dr, "RecordDate");
                        transaction.ValueDate = base.GetDataValue<DateTime>(dr, "ValueDate");
                        transaction.Narrative = base.GetDataValue<string>(dr, "Narrative");
                        transaction.StatementFlag = base.GetDataValue<string>(dr, "StatementFlag");
                        transaction.Authorizer = base.GetDataValue<string>(dr, "Authorizer");
                        transaction.UserID = base.GetDataValue<string>(dr, "UserID");
                        transaction.ForcePostFlag = base.GetDataValue<bool>(dr, "ForcePostFlag");
                        transaction.Reference = base.GetDataValue<string>(dr, "Reference");
                        transaction.ContraReference = base.GetDataValue<string>(dr, "ContraReference");
                    }
                }
            }

            return transaction;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the Transactions table.
        /// </summary>
        /// <returns>A collection of Transaction objects.</returns>		
        public List<Transaction> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [TransactionID], [TransactionTypeId], [AccountID], [Amount], [PostDate], [RecordDate]" +
                        ", [ValueDate], [Narrative], [StatementFlag], [Authorizer], [UserID], [ForcePostFlag]" +
                        ", [Reference], [ContraReference] " +
                "FROM dbo.Transactions ";

            List<Transaction> result = new List<Transaction>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new Transaction
                        Transaction transaction = new Transaction();

                        // Read values.
                        transaction.TransactionID = base.GetDataValue<int>(dr, "TransactionID");
                        transaction.TransactionTypeId = base.GetDataValue<int>(dr, "TransactionTypeId");
                        transaction.AccountID = base.GetDataValue<int>(dr, "AccountID");
                        transaction.Amount = base.GetDataValue<decimal>(dr, "Amount");
                        transaction.PostDate = base.GetDataValue<DateTime>(dr, "PostDate");
                        transaction.RecordDate = base.GetDataValue<DateTime>(dr, "RecordDate");
                        transaction.ValueDate = base.GetDataValue<DateTime>(dr, "ValueDate");
                        transaction.Narrative = base.GetDataValue<string>(dr, "Narrative");
                        transaction.StatementFlag = base.GetDataValue<string>(dr, "StatementFlag");
                        transaction.Authorizer = base.GetDataValue<string>(dr, "Authorizer");
                        transaction.UserID = base.GetDataValue<string>(dr, "UserID");
                        transaction.ForcePostFlag = base.GetDataValue<bool>(dr, "ForcePostFlag");
                        transaction.Reference = base.GetDataValue<string>(dr, "Reference");
                        transaction.ContraReference = base.GetDataValue<string>(dr, "ContraReference");

                        // Add to List.
                        result.Add(transaction);
                    }
                }
            }

            return result;
        }
    }
}

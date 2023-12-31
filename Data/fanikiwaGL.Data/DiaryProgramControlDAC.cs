//====================================================================================================
// Base code generated with Momentum: DAC Gen (Build 2.5.5049.15162)
// Layered Architecture Solution Guidance (http://layerguidance.codeplex.com)
//
// Generated by Administrator at SAPSERVER on 01/07/2015 18:33:41 
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
    /// DiaryProgramControl data access component. Manages CRUD operations for the DiaryProgramControl table.
    /// </summary>
    public partial class DiaryProgramControlDAC : DataAccessComponent
    {
        /// <summary>
        /// Inserts a new row in the DiaryProgramControl table.
        /// </summary>
        /// <param name="diaryProgramControl">A DiaryProgramControl object.</param>
        /// <returns>An updated DiaryProgramControl object.</returns>
        public DiaryProgramControl Create(DiaryProgramControl diaryProgramControl)
        {
            const string SQL_STATEMENT =
                "INSERT INTO dbo.DiaryProgramControl ([LastRun], [NextRun]) " +
                "VALUES(@LastRun, @NextRun); SELECT SCOPE_IDENTITY();";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@LastRun", DbType.DateTime2, diaryProgramControl.LastRun);
                db.AddInParameter(cmd, "@NextRun", DbType.DateTime2, diaryProgramControl.NextRun);

                // Get the primary key value.
                diaryProgramControl.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return diaryProgramControl;
        }

        /// <summary>
        /// Updates an existing row in the DiaryProgramControl table.
        /// </summary>
        /// <param name="diaryProgramControl">A DiaryProgramControl entity object.</param>
        public void UpdateById(DiaryProgramControl diaryProgramControl)
        {
            const string SQL_STATEMENT =
                "UPDATE dbo.DiaryProgramControl " +
                "SET " +
                    "[LastRun]=@LastRun, " +
                    "[NextRun]=@NextRun " +
                "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@LastRun", DbType.DateTime2, diaryProgramControl.LastRun);
                db.AddInParameter(cmd, "@NextRun", DbType.DateTime2, diaryProgramControl.NextRun);
                db.AddInParameter(cmd, "@Id", DbType.Int32, diaryProgramControl.Id);

                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Conditionally deletes one or more rows in the DiaryProgramControl table.
        /// </summary>
        /// <param name="id">A id value.</param>
        public void DeleteById(int id)
        {
            const string SQL_STATEMENT = "DELETE dbo.DiaryProgramControl " +
                                         "WHERE [Id]=@Id ";

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                // Set parameter values.
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);


                db.ExecuteNonQuery(cmd);
            }
        }

        /// <summary>
        /// Returns a row from the DiaryProgramControl table.
        /// </summary>
        /// <param name="id">A Id value.</param>
        /// <returns>A DiaryProgramControl object with data populated from the database.</returns>
        public DiaryProgramControl SelectById(int id)
        {
            const string SQL_STATEMENT =
                "SELECT [Id], [LastRun], [NextRun] " +
                "FROM dbo.DiaryProgramControl  " +
                "WHERE [Id]=@Id ";

            DiaryProgramControl diaryProgramControl = null;

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);

                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read())
                    {
                        // Create a new DiaryProgramControl
                        diaryProgramControl = new DiaryProgramControl();

                        // Read values.
                        diaryProgramControl.Id = base.GetDataValue<int>(dr, "Id");
                        diaryProgramControl.LastRun = base.GetDataValue<DateTime>(dr, "LastRun");
                        diaryProgramControl.NextRun = base.GetDataValue<DateTime>(dr, "NextRun");
                    }
                }
            }

            return diaryProgramControl;
        }

        /// <summary>
        /// Conditionally retrieves one or more rows from the DiaryProgramControl table.
        /// </summary>
        /// <returns>A collection of DiaryProgramControl objects.</returns>		
        public List<DiaryProgramControl> Select()
        {
            // WARNING! The following SQL query does not contain a WHERE condition.
            // You are advised to include a WHERE condition to prevent any performance
            // issues when querying large resultsets.
            const string SQL_STATEMENT =
                "SELECT [Id], [LastRun], [NextRun] " +
                "FROM dbo.DiaryProgramControl ";

            List<DiaryProgramControl> result = new List<DiaryProgramControl>();

            // Connect to database.
            Database db = DatabaseFactory.CreateDatabase(CONNECTION_NAME);
            using (DbCommand cmd = db.GetSqlStringCommand(SQL_STATEMENT))
            {
                using (IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        // Create a new DiaryProgramControl
                        DiaryProgramControl diaryProgramControl = new DiaryProgramControl();

                        // Read values.
                        diaryProgramControl.Id = base.GetDataValue<int>(dr, "Id");
                        diaryProgramControl.LastRun = base.GetDataValue<DateTime>(dr, "LastRun");
                        diaryProgramControl.NextRun = base.GetDataValue<DateTime>(dr, "NextRun");

                        // Add to List.
                        result.Add(diaryProgramControl);
                    }
                }
            }

            return result;
        }
    }
}


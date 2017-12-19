using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
namespace MyAirport.Pim.Models
{
    /// <summary>
    /// Class Sql corresponding to the SQL version of AbstractDefinition
    /// </summary>
    public class Sql : AbstractDefinition
    {
        /// <summary>
        /// String to connect to the database
        /// </summary>
        private string strCnx = ConfigurationManager.ConnectionStrings["MyAiport.Pim.Settings.DbConnect"].ConnectionString;

        /// <summary>
        /// String to select a bagage using its id
        /// </summary>
        private static string EXACT_ID = " WHERE [BAGAGE].[ID_BAGAGE] = @ID_BAGAGE";

        /// <summary>
        /// String to select a company using its iata code
        /// </summary>
        private static string COMPANGNY_EXACT_ID = " WHERE [COMPAGNIE].[CODE_IATA] = @CODE_IATA";

        /// <summary>
        /// String to select a list of bagage using a regex of their iata codes
        /// </summary>
        private static string LIKE_IATA = " WHERE [BAGAGE].[CODE_IATA] LIKE @CODE_IATA";

        /// <summary>
        /// String to query bagages
        /// </summary>
        private static string GET_BAGAGE = "SELECT [BAGAGE].ID_BAGAGE, [BAGAGE].CODE_IATA, co.NOM AS 'COMPAGNIE', [BAGAGE].LIGNE, [BAGAGE].DATE_CREATION ,[BAGAGE].PRIORITAIRE, [BAGAGE].DESTINATION, [BAGAGE].EN_CONTINUATION, cast(iif(bp.PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " FROM BAGAGE "
            + " LEFT JOIN BAGAGE_A_POUR_PARTICULARITE bap ON bap.ID_BAGAGE=[BAGAGE].ID_BAGAGE"
            + " LEFT JOIN BAGAGE_PARTICULARITE bp ON bp.ID_PART=bap.ID_PARTICULARITE"
            + " LEFT JOIN COMPAGNIE co ON co.CODE_IATA=[BAGAGE].COMPAGNIE";

        /// <summary>
        /// String to query companies
        /// </summary>
        private static string GET_COMPANY = "SELECT [COMPAGNIE].[ID_COMPAGNIE] FROM COMPAGNIE";

        /// <summary>
        /// String to update bagages
        /// </summary>
        private static string UPDATE_BAGAGE = "UPDATE BAGAGE"
            + " SET [PRIORITAIRE] = @PRIORITAIRE, [DESTINATION] = @DESTINATION, [LIGNE] = @LIGNE, [EN_CONTINUATION] = @EN_CONTINUATION";

        /// <summary>
        /// String to insert a new bagage
        /// </summary>
        private static string INSERT_BAGAGE = "INSERT INTO BAGAGE ([CODE_IATA], [DATE_CREATION], [JOUR_EXPLOITATION], [ORIGINE_CREATION], [PRIORITAIRE], [DESTINATION], [COMPAGNIE], [LIGNE], [EN_CONTINUATION])"
            + " VALUES (@CODE_IATA, SYSDATETIME(), 2, 'D', @PRIORITAIRE, @DESTINATION, @COMPAGNIE, @LIGNE, @EN_CONTINUATION);";

        /// <summary>
        /// String to insert a new particularity to a bagage if it does not exist
        /// </summary>
        private static string INSERT_PARTICULARITE = "INSERT INTO BAGAGE_A_POUR_PARTICULARITE ([ID_BAGAGE], [ID_PARTICULARITE])"
            + " SELECT @ID_BAGAGE, 1"
            + " WHERE NOT EXISTS ( SELECT * FROM BAGAGE_A_POUR_PARTICULARITE WHERE [ID_BAGAGE] = @ID_BAGAGE);";

        /// <summary>
        /// String to delete all particularity of a bagage according to its id
        /// </summary>
        private static string DELETE_PARTICULARITE = "DELETE FROM BAGAGE_A_POUR_PARTICULARITE WHERE [ID_BAGAGE]=@ID_BAGAGE";

        /// <summary>
        /// String to query the inserted row id 
        /// </summary>
        private static string GET_INSERT = "SELECT SCOPE_IDENTITY()";

        /// <summary>
        /// Get bagage by iata code in BAGAGE table
        /// iata code is in format ____XXXXXX00
        /// </summary>
        /// <param name="codeIataBagage"></param>
        /// <returns></returns>
        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            List<BagageDefinition> bagList = new List<BagageDefinition>();
            String codeIata = "";
            if(codeIataBagage.Length == 12)
            {
                codeIata = codeIataBagage;
            } 
            else if (codeIataBagage.Length == 6)
            {
                codeIata = "____" + codeIataBagage + "00";
            }
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(GET_BAGAGE + LIKE_IATA, cnx);
                cmd.Parameters.AddWithValue("@CODE_IATA", codeIata);
                cnx.Open();
                bagList = executeQuery(cmd);
            }
            return bagList;
        }

        /// <summary>
        /// Get a bagage using its id from BAGAGE table
        /// </summary>
        /// <param name="idBagage"></param>
        /// <returns>the corresponding bagage</returns>
        public override BagageDefinition GetBagage(int idBagage)
        {
            BagageDefinition bag = null;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(GET_BAGAGE + EXACT_ID, cnx);
                cmd.Parameters.AddWithValue("@ID_BAGAGE", idBagage);
                cnx.Open();
                List<BagageDefinition> bagList = executeQuery(cmd);
                if(bagList.Count > 0)
                {
                    bag = bagList[0];
                }
            }
            return bag;
        }

        /// <summary>
        /// Insert a bagage in BAGAGE table
        /// </summary>
        /// <param name="bagage"></param>
        /// <returns>the new bagage id</returns>
        public override int InsertBagage(BagageDefinition bagage)
        {
            int id = 0;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                if(CheckCompanyExist(bagage.Compagnie))
                {
                    // if the company iata code exist, insert in the database
                    SqlCommand cmd = new SqlCommand(INSERT_BAGAGE + GET_INSERT, cnx);
                    cmd.Parameters.AddWithValue("@CODE_IATA", bagage.CodeIata);
                    cmd.Parameters.AddWithValue("@EN_CONTINUATION", bagage.EnContinuation);
                    cmd.Parameters.AddWithValue("@COMPAGNIE", bagage.Compagnie);
                    cmd.Parameters.AddWithValue("@LIGNE", bagage.Ligne);
                    cmd.Parameters.AddWithValue("@DESTINATION", bagage.Itineraire);
                    cmd.Parameters.AddWithValue("@PRIORITAIRE", bagage.Prioritaire);
                    cnx.Open();
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    if (bagage.Rush == true)
                    {
                        // if the bagage is rush insert in the table BAGAGE_A_POUR_PARTICULARITE
                        SqlCommand cmd2 = new SqlCommand(INSERT_PARTICULARITE, cnx);
                        cmd2.Parameters.AddWithValue("@ID_BAGAGE", id);
                        cmd2.ExecuteScalar();
                    }
                }
            }
            return id;
        }

        /// <summary>
        /// Check whether the company exist using its iata code
        /// </summary>
        /// <param name="codeIata"></param>
        /// <returns>whether it exist</returns>
        private bool CheckCompanyExist(String codeIata)
        {
            bool exist = false;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(GET_COMPANY + COMPANGNY_EXACT_ID, cnx);
                cmd.Parameters.AddWithValue("@CODE_IATA", codeIata);
                cnx.Open();
                using (SqlDataReader dataReader = cmd.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        exist = true;
                    }
                }
            }
            return exist;
        }
        
        /// <summary>
        /// Update a bagage in bagage table
        /// </summary>
        /// <param name="bagage"></param>
        /// <returns>the bagage updated</returns>
        public override BagageDefinition UpdateBagage(BagageDefinition bagage)
        {
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                // update the bagage in BAGAGE table
                SqlCommand cmd = new SqlCommand(UPDATE_BAGAGE + EXACT_ID, cnx);
                cmd.Parameters.AddWithValue("@ID_BAGAGE", bagage.IdBagage);
                cmd.Parameters.AddWithValue("@EN_CONTINUATION", bagage.EnContinuation);
                cmd.Parameters.AddWithValue("@LIGNE", bagage.Ligne);
                cmd.Parameters.AddWithValue("@DESTINATION", bagage.Itineraire);
                cmd.Parameters.AddWithValue("@PRIORITAIRE", bagage.Prioritaire);
                cnx.Open();
                List<BagageDefinition> bagList = executeQuery(cmd);
                if (bagage.Rush == true)
                {
                    // if the bagage is rush, insert a line BAGAGE_A_POUR_PARTICULARITE  corresponding to bagage id if there is none
                    SqlCommand cmd2 = new SqlCommand(INSERT_PARTICULARITE, cnx);
                    cmd2.Parameters.AddWithValue("@ID_BAGAGE", bagage.IdBagage);
                    cmd2.ExecuteScalar();
                }
                else
                {
                    // if the bagage is not rush, remove all line in BAGAGE_A_POUR_PARTICULARITE corresponding to bagage id
                    SqlCommand cmd2 = new SqlCommand(DELETE_PARTICULARITE, cnx);
                    cmd2.Parameters.AddWithValue("@ID_BAGAGE", bagage.IdBagage);
                    cmd2.ExecuteScalar();
                }
            }
            // return the bagage updated
            return GetBagage(bagage.IdBagage);
        }

        /// <summary>
        /// Delete a bagage using its id
        /// </summary>
        /// <param name="idBagage"></param>
        public override void DeleteBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Execute a select query and convert the result into a list of BagageDefinition
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>a list of BagageDefinition</returns>
        private List<BagageDefinition> executeQuery(SqlCommand cmd)
        {
            List<BagageDefinition> bagList = new List<BagageDefinition>();
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        BagageDefinition bag = new BagageDefinition();
                        bag.IdBagage = dataReader.GetInt32(dataReader.GetOrdinal("ID_BAGAGE"));
                        bag.CodeIata = dataReader.GetString(dataReader.GetOrdinal("CODE_IATA"));
                        bag.Compagnie = dataReader.GetString(dataReader.GetOrdinal("COMPAGNIE"));
                        bag.Ligne = dataReader.GetString(dataReader.GetOrdinal("LIGNE"));
                        bag.DateVol = dataReader.GetDateTime(dataReader.GetOrdinal("DATE_CREATION"));
                        bag.Itineraire = dataReader.GetString(dataReader.GetOrdinal("DESTINATION"));
                        bag.Prioritaire = dataReader.GetBoolean(dataReader.GetOrdinal("PRIORITAIRE"));
                        bag.EnContinuation = dataReader.GetBoolean(dataReader.GetOrdinal("EN_CONTINUATION"));
                        bag.Rush = dataReader.GetBoolean(dataReader.GetOrdinal("RUSH"));
                        bagList.Add(bag);
                    }
                }
            }
            return bagList;
        }
    }
}

using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
namespace MyAirport.Pim.Models
{
    public class Sql : AbstractDefinition
    {
        string strCnx = ConfigurationManager.ConnectionStrings["MyAiport.Pim.Settings.DbConnect"].ConnectionString;

        static string LIKE_IATA = " WHERE b.CODE_IATA LIKE @code_iata";

        static string EXACT_ID = " WHERE b.ID_BAGAGE=@id_bagage";

        static string EXACT_IATA = " WHERE b.CODE_IATA = @code_iata";

        static string GET_BAGAGE = "SELECT b.ID_BAGAGE, b.CODE_IATA, co.NOM AS 'COMPAGNIE', b.LIGNE, b.DATE_CREATION ,b.PRIORITAIRE, b.DESTINATION, b.EN_CONTINUATION, cast(iif(bp.PARTICULARITE is null, 0, 1) as bit) as 'RUSH'"
            + " FROM BAGAGE b"
            + " LEFT JOIN BAGAGE_A_POUR_PARTICULARITE bap ON bap.ID_BAGAGE=b.ID_BAGAGE"
            + " LEFT JOIN BAGAGE_PARTICULARITE bp ON bp.ID_PART=bap.ID_PARTICULARITE"
            + " LEFT JOIN COMPAGNIE co ON co.CODE_IATA=b.COMPAGNIE";

        static string GET_COMPANY = "SELECT b.ID_COMPAGNIE FROM COMPAGNIE b";

        static string UPDATE_BAGAGE = "UPDATE BAGAGE b "
            + " SET b.ID_VOL = @ID_VOL, b.CODE_IATA = @CODE_IATA, b.ORIGINE_CREATION = @ORIGINE_CREATION, b.DATE_CREATION = @DATE_CREATION, b.CLASSE = @CLASSE, b.PRIORITAIRE = @PRIORITAIRE, b.STA = '', b.LOCAL_TRANFERT = @LOCAL_TRANFERT, b.NSUR = @NSUR, b.SSUR = @SSUR, b.ISUR = @ISUR, b.TSUR = @TSUR, b.GSUR = @GSUR, b.CSUR = @CSUR, b.DESTINATION = @DESTINATION, b.ESCALE = @ESCALE, b.EMB = @EMB, b.RECOLE = @RECOLE, b.COMPAGNIE = @COMPAGNIE, b.LIGNE = @LIGNE, b.JOUR_EXPLOITATION = @JOUR_EXPLOITATION, b.CONTINUATION = @CONTINUATION, b.STATUT_EJECTION = @STATUT_EJECTION, b.STATUT_TEMPOREL = @STATUT_TEMPOREL, b.DCS_EMETTEUR = @DCS_EMETTEUR, b.ORIGINE_SAFIR = @ORIGINE_SAFIR, b.EN_CONTINUATION = @EN_CONTINUATION, b.EN_TRANSFERT = @EN_TRANSFERT";

        static string INSERT_BAGAGE = "INSERT INTO BAGAGE ([CODE_IATA], [DATE_CREATION], [JOUR_EXPLOITATION], [ORIGINE_CREATION], [PRIORITAIRE], [DESTINATION], [COMPAGNIE], [LIGNE], [EN_CONTINUATION])"
            + " VALUES (@CODE_IATA, SYSDATETIME(), 2, 'D', @PRIORITAIRE, @DESTINATION, @COMPAGNIE, @LIGNE, @EN_CONTINUATION);";

        static string INSERT_PARTICULARITE = "INSERT INTO BAGAGE_A_POUR_PARTICULARITE ([ID_BAGAGE], [ID_PARTICULARITE])"
            + " VALUES (@ID_BAGAGE, 1)";

        static string GET_INSERT = "SELECT SCOPE_IDENTITY()";

        public override List<BagageDefinition> GetBagage(string codeIataBagage)
        {
            List<BagageDefinition> bagList = new List<BagageDefinition>();
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(GET_BAGAGE + LIKE_IATA, cnx);
                cmd.Parameters.AddWithValue("@code_iata", "____" + codeIataBagage + "00");
                cnx.Open();
                bagList = executeQuery(cmd);
            }
            return bagList;
        }

        public override BagageDefinition GetBagage(int idBagage)
        {
            BagageDefinition bag = null;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(GET_BAGAGE + EXACT_ID, cnx);
                cmd.Parameters.AddWithValue("@id_bagage", idBagage);
                cnx.Open();
                List<BagageDefinition> bagList = executeQuery(cmd);
                if(bagList.Count > 0)
                {
                    bag = bagList[0];
                }
            }
            return bag;
        }

        public override int InsertBagage(BagageDefinition bagage)
        {
            int id = 0;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                if(checkCompanyExist(bagage.Compagnie))
                {
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
                        SqlCommand cmd2 = new SqlCommand(INSERT_PARTICULARITE, cnx);
                        cmd2.Parameters.AddWithValue("@ID_BAGAGE", id);
                        cmd2.ExecuteScalar();
                    }
                }
            }
            return id;
        }

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

        public override BagageDefinition UpdateBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public override void DeleteBagage(int idBagage)
        {
            throw new NotImplementedException();
        }

        public bool checkCompanyExist(String codeIata)
        {
            bool exist = false;
            using (SqlConnection cnx = new SqlConnection(strCnx))
            {
                SqlCommand cmd = new SqlCommand(GET_COMPANY + EXACT_IATA, cnx);
                cmd.Parameters.AddWithValue("@code_iata", codeIata);
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
    }
}

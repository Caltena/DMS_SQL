using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Controls;

namespace TSQLtoCS
{
    public class cConnectDB
    {
        private string _sDatabbase = "Test";
        public string sDatabase
        {
            get { return _sDatabbase; }
            set { _sDatabbase = value; }
        }

        private string _sServer = "NB-036\\development";

        public string sServer
        {
            get { return _sServer; }
            set { _sServer = value; }
        }

        private string _connectionString = @"Data Source=NB-036\development;Initial Catalog=Test;Integrated Security=True";
        public string connectionString
        {
            get
            {
                return @"Data Source=" + sServer + ";" +
                              "Initial Catalog=" + sDatabase + ";" +
                              "Integrated Security=True";
            }
            set { _connectionString = value; }
        }



        private SqlConnection conn;
        public LinkedList<cField> lcFields = new LinkedList<cField>();



        public void SetFields()
        {
            lcFields.AddFirst(new cField("binary", "SqlBinary", "Byte[]", "binary"));
            lcFields.AddFirst(new cField("bit", "SqlBoolean", "Boolean", "bit"));
            lcFields.AddFirst(new cField("date", "SqlDateTime", "DateTime", "date"));
            lcFields.AddFirst(new cField("datetime", "SqlDateTime", "DateTime", "datetime"));
            lcFields.AddFirst(new cField("decimal", "SqlDecimal", "Decimal", "decimal({0},{1})"));
            lcFields.AddFirst(new cField("float", "SqlDouble", "Double", "float"));
            lcFields.AddFirst(new cField("int", "SqlInt32", "Int32", "int"));
            lcFields.AddFirst(new cField("money", "SqlMoney", "Decimal", "money"));
            lcFields.AddFirst(new cField("nchar", "SqlString", "String", "nchar({0})"));
            lcFields.AddFirst(new cField("nvarchar", "SqlString", "String", "nvarchar({0})"));
            lcFields.AddFirst(new cField("numeric", "SqlDecimal", "Decimal", "numeric"));
            lcFields.AddFirst(new cField("smallint", "SqlInt16", "Int16", "smallint"));
            lcFields.AddFirst(new cField("smallmoney", "SqlMoney", "Decimal", "smallmoney"));
            lcFields.AddFirst(new cField("tinyint", "SqlByte", "Byte", "tinyint"));
            lcFields.AddFirst(new cField("uniqueidentifier", "SqlGuid", "Guid", "uniqueidentifier"));
            lcFields.AddFirst(new cField("varbinary", "SqlBytes", "Byte", "varbinary({0})"));
            lcFields.AddFirst(new cField("varchar", "SqlString", "String", "varchar({0})"));
            lcFields.AddFirst(new cField("xml", "SqlXml", "String", "xml"));

        }

        public cConnectDB()
        {
            conn = new SqlConnection(connectionString);
        }

        private SqlDataReader DBQueryReader(string strSQL, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(strSQL, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return (reader);
        }

        private Boolean DisConnection()
        {
            try
            {
                conn.Close();
                return (true);
            }
            catch (Exception e)
            {


                return (false);
            }
        }

        public void BindComboBoxTable(ComboBox comboBoxName)
        {

            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = " SELECT t.name COLLATE SQL_Latin1_General_CP1_CI_AI AS 'ID'  ," +
                                "      t.name COLLATE SQL_Latin1_General_CP1_CI_AI AS 'Table'" +
                                "   FROM [" + sDatabase + "].sys.schemas AS s  " +
                                "   INNER JOIN [" + sDatabase + "].sys.tables AS t  " +
                                "   ON s.[schema_id] = t.[schema_id]  " +
                                "   ORDER BY  t.name  ";
            SqlDataAdapter sqlDa = new SqlDataAdapter();
            sqlDa.SelectCommand = cmd;
            DataSet ds = new DataSet();
            try
            {
                sqlDa.Fill(ds, "SYS");
                DataRow nRow = ds.Tables["SYS"].NewRow();
                nRow["Table"] = "List All";
                nRow["ID"] = "0";
                ds.Tables["SYS"].Rows.InsertAt(nRow, 0);

                comboBoxName.DataContext = ds.Tables["SYS"].DefaultView;

                comboBoxName.DisplayMemberPath =
                    ds.Tables["SYS"].Columns["Table"].ToString();

                comboBoxName.SelectedValuePath =
                    ds.Tables["SYS"].Columns["ID"].ToString();

            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show("An error occurred while loading categories." + ex.Message.ToString());
            }
            finally
            {
                sqlDa.Dispose();
                cmd.Dispose();
                sqlCon.Dispose();
            }
        }

        public List<cFields> ReadTable(string sTable)
        {
            List<cFields> lTable = new List<cFields>();
            SetFields();
            connectionString = @"Data Source=NB-036\development;Initial Catalog=Test;Integrated Security=True";

            string sSQL = "      SELECT  c.Table_catalog, " +
                           "             c.TABLE_Schema, " +
                           "             c.TABLE_NAME, " +
                           "             c.Column_Name, " +
                           "             c.ORDINAL_POSITION," +
                           "             c.DATA_TYPE, " +
                           "             ISNULL(c.CHARACTER_MAXIMUM_LENGTH , 0)   AS CHARACTER_MAXIMUM_LENGTH," +
                           "             ISNULL(c.NUMERIC_PRECISION , 0 )         AS NUMERIC_PRECISION, " +
                           "             ISNULL(c.NUMERIC_SCALE , 0 )             AS NUMERIC_SCALE," +
                           "             IIF(d.name IS NOT null , '*','' )        AS constraint_name" +
                           "       FROM " + sDatabase + ".information_schema.columns as c" +
                           "  LEFT JOIN " + sDatabase + ".sys.indexes A  ON OBJECT_ID(c.table_name) = A.Object_ID " +
                           "  LEFT Join " + sDatabase + ".sys.index_columns B On A.object_id = B.object_id And A.index_id = B.index_id  " +
                           "  LEFT Join " + sDatabase + ".sys.columns D On D.object_id = B.object_id  And D.column_id  = B.column_id  AND  d.name  = c.Column_Name " +
                           "      WHERE c.TABLE_NAME = '" + sTable + "' " +
                           "   GROUP BY c.Table_catalog, c.TABLE_Schema, c.TABLE_NAME, c.Column_Name, " +
                           "            c.ORDINAL_POSITION, c.DATA_TYPE, ISNULL(c.CHARACTER_MAXIMUM_LENGTH, 0) ," +
                           "            ISNULL(c.NUMERIC_PRECISION, 0) ,ISNULL(c.NUMERIC_SCALE, 0) , d.name " +
                           "   ORDER BY c.ORDINAL_POSITION";
            try
            {
                conn.Open();
                SqlDataReader reader = DBQueryReader(sSQL, conn);
                while (reader.Read())
                {
                    cFields ct = new cFields();
                    ct.Table_catalog = reader["Table_catalog"].ToString();
                    ct.TABLE_Schema = reader["TABLE_Schema"].ToString();
                    ct.TABLE_NAME = reader["TABLE_NAME"].ToString();
                    ct.Column_Name = reader["Column_Name"].ToString();
                    ct.ORDINAL_POSITION = Convert.ToInt32(reader["ORDINAL_POSITION"]);
                    ct.DATA_TYPE = reader["DATA_TYPE"].ToString();
                    ct.CHARACTER_MAXIMUM_LENGTH = Convert.ToInt32(reader["CHARACTER_MAXIMUM_LENGTH"]);
                    ct.NUMERIC_PRECISION = Convert.ToInt32(reader["NUMERIC_PRECISION"]);
                    ct.NUMERIC_SCALE = Convert.ToInt32(reader["NUMERIC_SCALE"]);
                    ct.constraint_name = reader["constraint_name"].ToString();
                    cField a = lcFields.Where(p => p.sSQL == ct.DATA_TYPE).FirstOrDefault();
                    if (a != null)
                    {
                        ct.sSQL = a.sSQL;
                        ct.sCS = a.sCS;
                        ct.cC = a.cC;
                        ct.cSP = string.Format(a.sSP, ct.CHARACTER_MAXIMUM_LENGTH, ct.NUMERIC_PRECISION);
                    }
                    ct.SetC();
                    lTable.Add(ct);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                lTable = null;
            }
            return lTable;
        }
    }

    public class cField
    {
        public string sSQL { get; set; }
        public string sCS { get; set; }
        public string cC { get; set; }
        public string sSP { get; set; }

        public cField(string _sSQL, string _sCS, string _cC, string _csSP)
        {
            sSQL = _sSQL;
            sCS = _sCS;
            cC = _cC;
            sSP = _csSP;
        }
    }

    public class cFields
    {
        public string sSQL { get; set; }
        public string sCS { get; set; }
        public string cC { get; set; }
        public string cSP { get; set; }
        public string Table_catalog { get; set; }
        public string TABLE_Schema { get; set; }
        public string TABLE_NAME { get; set; }
        public string Column_Name { get; set; }
        public int ORDINAL_POSITION { get; set; }
        public string DATA_TYPE { get; set; }
        public int CHARACTER_MAXIMUM_LENGTH { get; set; }
        public int NUMERIC_PRECISION { get; set; }
        public int NUMERIC_SCALE { get; set; }
        public string constraint_name { get; set; }
        public string sDIM_C { get; set; }

        public void SetC()
        {
            switch (DATA_TYPE.ToUpper())
            {
                case "MONEY":
                    sDIM_C = string.Format("money ({0},{1})", CHARACTER_MAXIMUM_LENGTH.ToString(), NUMERIC_SCALE.ToString());
                    break;
                case "DECIMAL":
                    sDIM_C = string.Format("decimal ({0},{1})", CHARACTER_MAXIMUM_LENGTH.ToString(), NUMERIC_SCALE.ToString());
                    break;
                case "VARCHAR":
                    if (CHARACTER_MAXIMUM_LENGTH > 0)
                        sDIM_C = string.Format("varchar ({0})", CHARACTER_MAXIMUM_LENGTH.ToString());
                    else
                        sDIM_C = string.Format("varchar ({0})", "max");
                    break;
                case "NVARCHAR":
                    if (CHARACTER_MAXIMUM_LENGTH > 0)
                        sDIM_C = string.Format("nvarchar ({0})", CHARACTER_MAXIMUM_LENGTH.ToString());
                    else
                        sDIM_C = string.Format("nvarchar ({0})", "max");
                    break;
                default:
                    sDIM_C = DATA_TYPE;
                    break;
            }
        }



    }
}



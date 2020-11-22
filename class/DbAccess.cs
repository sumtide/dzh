using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace dzh
{
    class DbAccess
    {
        #region 字段
        /// <summary>
        /// 链接字符串
        /// </summary>
        public static string connectionString = "Server=.;database=access;uid=sa;pwd=dongzhihui66";
        /// <summary>
        /// 数据库链接定义
        /// </summary>
        private SqlConnection dbConnection;
        /// <summary>
        /// SQL命令定义
        /// </summary>
        private SqlCommand dbCommand;
        /// <summary>
        /// 数据读取定义
        /// </summary>
        private SqlDataReader dataReader;

        #endregion

        #region 属性
        public DbAccess()
        {
                //构造数据库链接
                dbConnection = new SqlConnection(connectionString);
            //根据状态打开数据库
            switch (dbConnection.State)
            {
                 case ConnectionState.Broken:
                    dbConnection.Close();
                    dbConnection.Open();
                    break;
                 case ConnectionState.Closed:
                    dbConnection.Open();
                    break;
                case ConnectionState.Connecting:
                    break;
                case ConnectionState.Executing:
                    break;
                case ConnectionState.Fetching:
                    break;
                case ConnectionState.Open:
                    break;
                default:
                    break;
                
            }
               
        }
        #endregion

        #region  方法
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteQuery(string queryString)
        {
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = queryString;
            dataReader = dbCommand.ExecuteReader();
            return dataReader;
        }
        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void CloseConnect()
        {
            if (dbCommand != null)
            {
                dbCommand.Cancel();
            }
            dbCommand = null;
            if (dataReader != null)
            {
                dataReader.Close();
            }
            dataReader = null;
            if (dbConnection != null)
            {
                dbConnection.Close();            
            }
            dbConnection = null;
        }
        #endregion


    }
}

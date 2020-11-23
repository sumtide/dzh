using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dzh
{
    class Car
    {
        #region 字段
        public string location { get; set; }
        public string number { get; set; }
        public string mid { get; set; }
        public string com { get; set; }
        public string rate { get; set; }
        public event ShowMessage ShowMessageEvent;
        public delegate void ShowMessage(object sender,MessageEventArgs e);

        #endregion

        #region 属性

        #endregion

        #region 方法
        /// <summary>
        /// 读取数据库获取车位
        /// </summary>
        /// <returns></returns>
        private  int[] GetLocation()
        {
            List<int> index = new List<int>();
            DbAccess dbAccess = new DbAccess();
            SqlDataReader dataReader = dbAccess.ExecuteQuery("select location from Car");
            while (dataReader.Read())
            {
                int temp = dataReader.GetInt32(dataReader.GetOrdinal("location"));
                if (index.Contains(temp))
                {
                    continue;
                }
                else
                {
                    index.Add(temp);
                }

            }
            dbAccess.CloseConnect();
            return index.ToArray();
        }
        /// <summary>
        /// 读取数据库车位下的车号
        /// </summary>
        /// <returns></returns>
        private int[] GetNumber(int location)
        {
            List<int> index = new List<int>();
            DbAccess dbAccess = new DbAccess();
            SqlDataReader dataReader = dbAccess.ExecuteQuery("select number from Car where location="+location.ToString());
            while (dataReader.Read())
            {
                int temp = dataReader.GetInt32(dataReader.GetOrdinal("number"));
                index.Add(temp);
            }
            dbAccess.CloseConnect();
            return index.ToArray();
        }
        /// <summary>
        /// 读取数据库根据id获取子编号
        /// </summary>
        /// <param name="location"></param>
        /// <param name="number"></param>
        /// <returns></returns>
       private string GetSequence(int id)
        {
            StringBuilder sb = new StringBuilder(20);
            DbAccess dbAccess = new DbAccess();
            SqlDataReader dataReader = dbAccess.ExecuteQuery(" SELECT meterId FROM MeterIDInfo WHERE id="+id.ToString());
            while (dataReader.Read())
            {
               sb.Append(dataReader.GetString(dataReader.GetOrdinal("meterId")));
            }
            dbAccess.CloseConnect();
            return sb.ToString();
        }
        /// <summary>
        /// 异步调用读取数据库车位
        /// </summary>
        /// <returns></returns>
        public Task<int[]> GetFItem()
        {
            return Task.Run(() =>
            {
                return GetLocation();
            });
        }
        /// <summary>
        /// 异步调用读取数据库车位下的车号
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Task<int[]> GetCItem(int location)
        {
            return Task.Run(() =>
            {
                return GetNumber(location);
            });
        }
        /// <summary>
        /// 异步调用读取数据库对应车的编号
        /// </summary>
        /// <returns></returns>
        public Task<string> GetID(int id)
        {
            return Task.Run(() =>
            {
                return GetSequence(id);
            });
        }
        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="msg"></param>
        public void SendEvent(string msg)
        {
            ShowMessageEvent?.Invoke(this, new MessageEventArgs(msg));
        }
        #endregion
    }

}

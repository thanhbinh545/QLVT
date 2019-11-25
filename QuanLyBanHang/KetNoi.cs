using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QuanLyBanHang
{
    class KetNoi
    {

        private string str = @"Data Source=ADMIN;Initial Catalog=QuanLyBanHang;User ID=sa;Password=b1nh";
        private SqlConnection connect;
        private SqlDataAdapter da_Table;
        private DataTable dt_Table;
        private SqlCommand cmd;
        private SqlDataReader d_reader;
        //
        public KetNoi()
        {
            try
            {
                if (connect == null)
                {
                    connect = new SqlConnection(str);
                }
                da_Table = new SqlDataAdapter();
                dt_Table = new DataTable();
                cmd = new SqlCommand();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + "Can not connect DB from connection. Pls check internet.");
            }
            
        }

        //hàm tạo kết nối
        public void MoKetNoi()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                    cmd.Connection = connect;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " from MoKetNoi");
            }
            
        }


        //Hàm ngắt kết nối
        public void DongKetNoi()
        {
            connect.Close();
            cmd.Dispose();
        }


        //Hàm lấy dữ liệu từ sql
        public DataTable NhanDuLieu(string query)
        {
            try
            {
                da_Table = new SqlDataAdapter(query, connect);
                //dt_Table.Clear(); xoá tất cả các DataTable tồn tại.
                dt_Table = new DataTable();
                da_Table.Fill(dt_Table);
                DongKetNoi();
                return dt_Table;
            }
            catch (Exception ex)
            {               
                MessageBox.Show("Can not connect to DB. Pls check internet connection!");
                return null;
            }
            
        }

        public void ExCute_NonQuery(string sql)
        {
            MoKetNoi();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DongKetNoi();
        }

        public string ExCute_Scalar(string sql)
        {
            MoKetNoi();
            cmd.CommandText = System.String.Concat(sql);
            string str = Convert.ToString(cmd.ExecuteScalar());
            return str;
        }

        public SqlDataReader Excute_Reader(string query)
        {
            MoKetNoi();
            cmd.CommandText = System.String.Concat(query);
            d_reader = cmd.ExecuteReader();
            //CloseConnect(); de ham closeConnect se khong duyet dc
            return d_reader;
        }

        public void ButtonLuu(ucbutton tam)
        {
            tam.btLuu.Enabled = false;
            tam.btThem.Enabled = true;
            tam.btXoa.Enabled = true;
            tam.btSua.Enabled = true;
        }

        public void ButtonLoad(ucbutton tam)
        {
            tam.btLuu.Enabled = false;
            tam.btThem.Enabled = true;
            tam.btXoa.Enabled = true;
            tam.btSua.Enabled = true;
        }

        public void ButtonThem(ucbutton tam)
        {
            tam.btLuu.Enabled = true;
            tam.btThem.Enabled = false;
            tam.btXoa.Enabled = false;
            tam.btSua.Enabled = false;
        }

        public void ButtonSua(ucbutton tam)
        {
            tam.btLuu.Enabled = true;
            tam.btThem.Enabled = false;
            tam.btXoa.Enabled = false;
            tam.btSua.Enabled = false;
        }

        public void LoadLookupedit(LookUpEdit lue, string query, string display, string value)
        {
            KetNoi kn = new KetNoi();
            DataTable tb = kn.NhanDuLieu(query);
            lue.Properties.DataSource = tb;
            lue.Properties.DisplayMember = display;
            lue.Properties.ValueMember = value;
        }

    }
}

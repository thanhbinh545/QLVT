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
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn = new KetNoi();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string query = "select MaNV, TenNV from NhanVien where MaNV = '" + txtTaiKhoan.Text + "' and MatKhau = '" + txtMatKhau.Text + "'";
            DataTable tbNV = kn.NhanDuLieu(query);
                       
            if (tbNV.Rows.Count != 0)
            {
                string manv = tbNV.Rows[0]["MaNV"].ToString();
                string tennv = tbNV.Rows[0]["TenNV"].ToString();
                LopTinh.NhanMaNV = manv;
                LopTinh.NhanTenNV = tennv;
                //this.Hide();
                //var frm = new frmMenu();
                //frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Pls check ID and Pass again !");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Focus();
        }
    }
}
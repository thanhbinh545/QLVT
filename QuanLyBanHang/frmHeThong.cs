using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;


namespace QuanLyBanHang
{
    public partial class frmHeThong : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn = new KetNoi();
        int ttbutton = 0;
        public frmHeThong()
        {
            InitializeComponent();
            //khai bao button DSQuen
            ucDSQuyen.btThem.Click += new System.EventHandler(this.btThemDSQ_Click);
            ucDSQuyen.btLuu.Click += new System.EventHandler(this.btLuuDSQ_Click);
            ucDSQuyen.btXoa.Click += new System.EventHandler(this.btXoaDSQ_Click);
            ucDSQuyen.btSua.Click += new System.EventHandler(this.btSuaDSQ_Click);

            //khai bao button Thuong Hieu
            ucThuongHieu.btThem.Click += new System.EventHandler(this.btThemTH_Click);
            ucThuongHieu.btLuu.Click += new System.EventHandler(this.btLuuTH_Click);
            ucThuongHieu.btXoa.Click += new System.EventHandler(this.btXoaTH_Click);
            ucThuongHieu.btSua.Click += new System.EventHandler(this.btSuaTH_Click);

            //khai bao button Chuc Nang He Thong
            ucChucNang.btThem.Click += new System.EventHandler(this.btThemCN_Click);
            ucChucNang.btLuu.Click += new System.EventHandler(this.btLuuCN_Click);
            ucChucNang.btXoa.Click += new System.EventHandler(this.btXoaCN_Click);
            ucChucNang.btSua.Click += new System.EventHandler(this.btSuaCN_Click);

            //khai bao button CTHT
            ucCTCN.btThem.Click += new System.EventHandler(this.btThemCTCN_Click);
            ucCTCN.btLuu.Click += new System.EventHandler(this.btLuuCTCN_Click);
            ucCTCN.btXoa.Click += new System.EventHandler(this.btXoaCTCN_Click);
            ucCTCN.btSua.Click += new System.EventHandler(this.btSuaCTCN_Click);

        }

        private void frmHeThong_Load(object sender, EventArgs e)
        {
            HeThong_Load();
        }

        private void HeThong_Load()
        {
            //load danh sach quyen len grid contrl
            string query = "select * from DSQuyen";
            DataTable tbDSQuyen = kn.NhanDuLieu(query);
            gcDSQuyen.DataSource = tbDSQuyen;
            kn.ButtonLoad(ucDSQuyen);

            //load thuong hieu
            string queryth = "select * from ThuongHieu";
            DataTable tbThuongHieu = kn.NhanDuLieu(queryth);
            gcThuongHieu.DataSource = tbThuongHieu;
            kn.ButtonLoad(ucThuongHieu);

            //load Chuc nang HT
            string queryCN = "select * from HeThong";
            DataTable tbHeThong = kn.NhanDuLieu(queryCN);
            gcChucNang.DataSource = tbHeThong;
            kn.ButtonLoad(ucChucNang);

            //load CTCN HT

        }


        private void btLuuDSQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttbutton == 1)// them quyen
                {
                    DataRow row = gvDSQuyen.GetFocusedDataRow();
                    string query = "insert into DSQuyen values('" + row["MaQuyen"].ToString() + "',N'" + row["TenQuyen"].ToString() + "',N'" 
                                                                  + row["GhiChuQuyen"].ToString() + "',N'" + LopTinh.NhanTenNV.ToString() + "','"
                                                                  + DateTime.Now + "')";
                    kn.ExCute_NonQuery(query);
                    HeThong_Load();
                    gvDSQuyen.OptionsBehavior.ReadOnly = true;
                }
                else if (ttbutton == 2)//sua quyen
                {
                    DataRow row = gvDSQuyen.GetFocusedDataRow();
                    string query = "update DSQuyen set TenQuyen = N'" + row["TenQuyen"].ToString() + "', GhiChuQuyen =N'"
                                                                      + row["GhiChuQuyen"].ToString() + "', NguoiDKQuyen =N'"
                                                                      + LopTinh.NhanTenNV + "', NgayDKQuyen='"
                                                                      + DateTime.Now.ToString() + "' where MaQuyen ='"
                                                                      + row["MaQuyen"].ToString() + "'";
                    kn.ExCute_NonQuery(query);
                    HeThong_Load();
                    gvDSQuyen.Columns[0].OptionsColumn.ReadOnly = false;
                    gvDSQuyen.OptionsBehavior.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btThemDSQ_Click(object sender, EventArgs e)
        {
            try
            {
                kn.ButtonThem(ucDSQuyen);
                ttbutton = 1;
                gvDSQuyen.OptionsBehavior.ReadOnly = false;
                gvDSQuyen.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }           
        }

        private void btXoaDSQ_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow row = gvDSQuyen.GetFocusedDataRow();
                string query = "delete from DSQuyen where MaQuyen='" + row["MaQuyen"].ToString() + "'";
                kn.ExCute_NonQuery(query);
                HeThong_Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }            
        }

        private void btSuaDSQ_Click(object sender, EventArgs e)
        {
            try
            {
                ttbutton = 2;
                gvDSQuyen.OptionsBehavior.ReadOnly = false;
                gvDSQuyen.Columns[0].OptionsColumn.ReadOnly = true;
                kn.ButtonSua(ucDSQuyen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }           
        }

        private void btLuuTH_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttbutton == 1)// them THUONG HIEU
                {
                    DataRow row = gvThuongHieu.GetFocusedDataRow();
                    string query = "insert into ThuongHieu values('" + row["MaTH"].ToString() + "',N'" + row["TenTH"].ToString() + "',N'"
                                                                  + row["GhiChuTH"].ToString() + "',N'" + LopTinh.NhanTenNV.ToString() + "','"
                                                                  + DateTime.Now + "')";
                    kn.ExCute_NonQuery(query);
                    HeThong_Load();
                    gvThuongHieu.OptionsBehavior.ReadOnly = true;
                }
                else if (ttbutton == 2)//sua Thuong Hieu
                {
                    DataRow row = gvThuongHieu.GetFocusedDataRow();
                    string query = "update ThuongHieu set TenTH = N'" + row["TenTH"].ToString() + "', GhiChuTH =N'"
                                                                      + row["GhiChuTH"].ToString() + "', NguoiDKTH =N'"
                                                                      + LopTinh.NhanTenNV + "', NgayDKTH='"
                                                                      + DateTime.Now.ToString() + "' where MaTH ='"
                                                                      + row["MaTH"].ToString() + "'";
                    kn.ExCute_NonQuery(query);
                    HeThong_Load();
                    gvThuongHieu.Columns[0].OptionsColumn.ReadOnly = false;
                    gvThuongHieu.OptionsBehavior.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btThemTH_Click(object sender, EventArgs e)
        {
            try
            {
                kn.ButtonThem(ucThuongHieu);
                ttbutton = 1;
                gvThuongHieu.OptionsBehavior.ReadOnly = false;
                gvThuongHieu.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btXoaTH_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow row = gvThuongHieu.GetFocusedDataRow();
                string query = "delete from ThuongHieu where MaTH='" + row["MaTH"].ToString() + "'";
                kn.ExCute_NonQuery(query);
                HeThong_Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btSuaTH_Click(object sender, EventArgs e)
        {
            try
            {
                ttbutton = 2;
                gvThuongHieu.OptionsBehavior.ReadOnly = false;
                gvThuongHieu.Columns[0].OptionsColumn.ReadOnly = true;
                kn.ButtonSua(ucThuongHieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btLuuCN_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttbutton == 1)// them chuc nang
                {
                    DataRow row = gvChucNang.GetFocusedDataRow();
                    string query = "insert into HeThong values(N'" + row["TenCN"].ToString() + "',N'"
                                                                  + row["GhiChuCN"].ToString() + "',N'" + LopTinh.NhanTenNV.ToString() + "','"
                                                                  + DateTime.Now + "')";
                    kn.ExCute_NonQuery(query);
                    HeThong_Load();
                    gvChucNang.OptionsBehavior.ReadOnly = true;
                }
                else if (ttbutton == 2)//sua chuc nang
                {
                    DataRow row = gvChucNang.GetFocusedDataRow();
                    string query = "update HeThong set TenCN = N'" + row["TenCN"].ToString() + "', GhiChuCN =N'"
                                                                      + row["GhiChuCN"].ToString() + "', NguoiDKCN =N'"
                                                                      + LopTinh.NhanTenNV + "', NgayDKCN='"
                                                                      + DateTime.Now.ToString() + "' where MaHT ='"
                                                                      + row["MaHT"].ToString() + "'";
                    kn.ExCute_NonQuery(query);
                    HeThong_Load();
                    gvChucNang.Columns[0].OptionsColumn.ReadOnly = false;
                    gvChucNang.OptionsBehavior.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btThemCN_Click(object sender, EventArgs e)
        {
            try
            {
                kn.ButtonThem(ucChucNang);
                ttbutton = 1;
                gvChucNang.OptionsBehavior.ReadOnly = false;
                gvChucNang.AddNewRow();
                gvChucNang.SetRowCellValue(gvChucNang.FocusedRowHandle, "MaHT",1000);
                gvChucNang.Columns[0].OptionsColumn.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btXoaCN_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow row = gvChucNang.GetFocusedDataRow();
                string query = "delete from HeThong where MaHT='" + row["MaHT"].ToString() + "'";
                kn.ExCute_NonQuery(query);
                HeThong_Load();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btSuaCN_Click(object sender, EventArgs e)
        {
            try
            {
                ttbutton = 2;
                gvChucNang.OptionsBehavior.ReadOnly = false;
                gvChucNang.Columns[0].OptionsColumn.ReadOnly = true;
                kn.ButtonSua(ucChucNang);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btLuuCTCN_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttbutton == 1)// them CTCN
                {
                    DataRow rowCN = gvChucNang.GetFocusedDataRow();
                    DataRow rowCTCN = gvCTCN.GetFocusedDataRow();

                    if (rowCTCN != null)
                    {
                        string queryCTCN = "insert into CTCN values('"+ rowCN["MaHT"].ToString() + "',N'"
                                                                  + rowCTCN["MoTaCN1"].ToString() + "',N'"
                                                                  + rowCTCN["MoTaCN2"].ToString() + "',N'"
                                                                  + rowCTCN["MoTaCN3"].ToString() + "',N'"
                                                                  + rowCTCN["GhiChuCTCN"].ToString() + "',N'"
                                                                  + LopTinh.NhanTenNV.ToString() + "','"
                                                                  + DateTime.Now + "')";
                        kn.ExCute_NonQuery(queryCTCN);
                        ChucNang_FocusedRowChanged();
                        kn.ButtonLuu(ucCTCN);
                        gvCTCN.OptionsBehavior.ReadOnly = true;
                    }
                    else
                        MessageBox.Show("Vui lòng chọn dòng dữ liệu thêm mới!");
                    
                }
                else if (ttbutton == 2)//sua CTCN
                {
                    DataRow row = gvCTCN.GetFocusedDataRow();
                    string query = "update CTCN set MoTaCN1 = N'" + row["MoTaCN1"].ToString() + "', MoTaCN2 =N'"
                                                                      + row["MoTaCN2"].ToString() + "', MoTaCN3 =N'"
                                                                      + row["MoTaCN3"].ToString() + "', GhiChuCTCN =N'"
                                                                      + row["GhiChuCTCN"].ToString() + "', NguoiDKCTCN =N'"
                                                                      + LopTinh.NhanTenNV + "', NgayDKCTCN='"
                                                                      + DateTime.Now.ToString() + "' where MaCTCN ='"
                                                                      + row["MaCTCN"].ToString() + "'";
                    kn.ExCute_NonQuery(query);
                    ChucNang_FocusedRowChanged();
                    kn.ButtonLuu(ucCTCN);
                    gvCTCN.Columns[0].OptionsColumn.ReadOnly = false;
                    gvCTCN.OptionsBehavior.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btThemCTCN_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow rowCN = gvChucNang.GetFocusedDataRow();
                if (rowCN != null)
                {
                    kn.ButtonThem(ucCTCN);
                    ttbutton = 1;
                    gvCTCN.OptionsBehavior.ReadOnly = false;
                    gvCTCN.AddNewRow();
                    gvCTCN.SetRowCellValue(gvCTCN.FocusedRowHandle, "MaCTCN", 1000);
                    gvCTCN.Columns[0].OptionsColumn.ReadOnly = true;
                }
                else
                    MessageBox.Show("Vui long chọn chức năng!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btXoaCTCN_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow row = gvCTCN.GetFocusedDataRow();
                string query = "delete from CTCN where MaCTCN='" + row["MaCTCN"].ToString() + "'";
                kn.ExCute_NonQuery(query);
                ChucNang_FocusedRowChanged();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btSuaCTCN_Click(object sender, EventArgs e)
        {
            try
            {
                ttbutton = 2;
                gvCTCN.OptionsBehavior.ReadOnly = false;
                gvCTCN.Columns[0].OptionsColumn.ReadOnly = true;
                kn.ButtonSua(ucCTCN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gvChucNang_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ChucNang_FocusedRowChanged();
        }

        private void ChucNang_FocusedRowChanged()
        {
            //load CTCN
            DataRow rowCN = gvChucNang.GetFocusedDataRow();
            if (rowCN != null)
            {
                string queryCTCN = "select * from CTCN where MaHT='" + rowCN["MaHT"].ToString() + "'";
                DataTable tbCTCN = kn.NhanDuLieu(queryCTCN);
                gcCTCN.DataSource = tbCTCN;
            }
            else
                gcCTCN.DataSource = null;
        }
    }
}
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

namespace QuanLyBanHang
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn = new KetNoi();
        int ttbutton;
        public frmNhanVien()
        {
            InitializeComponent();
            //khai bao button DSQuen
            ucNhanVien.btThem.Click += new System.EventHandler(this.btThemNV_Click);
            ucNhanVien.btLuu.Click += new System.EventHandler(this.btLuuNV_Click);
            ucNhanVien.btXoa.Click += new System.EventHandler(this.btXoaNV_Click);
            ucNhanVien.btSua.Click += new System.EventHandler(this.btSuaNV_Click);

            ucPQ.btThem.Click += new System.EventHandler(this.btThemPQ_Click);
            ucPQ.btLuu.Click += new System.EventHandler(this.btLuuPQ_Click);
            ucPQ.btXoa.Click += new System.EventHandler(this.btXoaPQ_Click);
            ucPQ.btSua.Click += new System.EventHandler(this.btSuaPQ_Click);
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            NhanVienLoad();
        }

        private void NhanVienLoad()
        {
            // load gridcontrol Nhan vien
            lcgNhanVien.Enabled = false;
            kn.ButtonLoad(ucNhanVien);
            string query = "select * from NhanVien";
            DataTable tbNhanVien = kn.NhanDuLieu(query);
            gcNhanVien.DataSource = tbNhanVien;

            kn.ButtonLoad(ucPQ);
            lueTenCTQ.Enabled = false;
            txtGhiChuCTQ.Enabled = false;
        }

        private void btLuuNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttbutton==1)//them nhan vien
                {
                    string querytnv = "insert into NhanVien values('" + txtMatKhau.Text + "',N'"
                                                                      + txtTenNV.Text + "',N'"
                                                                      + lueGioiTinhNV.Text + "',N'"
                                                                      + txtDiaChiNV.Text + "',N'"
                                                                      + txtDienThoaiNV.Text + "','"
                                                                      + txtCMNDNV.Text + "',N'"
                                                                      + LopTinh.NhanTenNV.ToString() + "','"
                                                                      + DateTime.Now + "')";
                    kn.ExCute_NonQuery(querytnv);
                    NhanVienLoad();
                    lueGioiTinhNV.EditValue = null;
                }
                else if (ttbutton==2)// sua nhan vien
                {
                    DataRow rowsnv = gvNhanVien.GetFocusedDataRow();
                    string querysnv = "update NhanVien set MatKhau='" + txtMatKhau.Text + "',TenNV =N'"
                                                                      + txtTenNV.Text + "',GioiTinhNV=N'"
                                                                      + lueGioiTinhNV.Text + "',DiaChiNV=N'"
                                                                      + txtDiaChiNV.Text + "',DienThoaiNV=N'"
                                                                      + txtDienThoaiNV.Text + "',CMNDNV='"
                                                                      + txtCMNDNV.Text + "',NguoiDKNV=N'"
                                                                      + LopTinh.NhanTenNV.ToString() + "',NgayDKNV='"
                                                                      + DateTime.Now + "' where MaNV ='"
                                                                      + rowsnv["MaNV"].ToString() + "'";
                    kn.ExCute_NonQuery(querysnv);
                    NhanVienLoad();
                    lueGioiTinhNV.EditValue = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btThemNV_Click(object sender, EventArgs e)
        {
            ttbutton = 1;
            lcgNhanVien.Enabled = true;
            kn.ButtonThem(ucNhanVien);
            txtMaNV.Enabled = false;
            txtMatKhau.Enabled = true;
            txtTenNV.Enabled = true;
            txtDiaChiNV.Enabled = true;
            txtCMNDNV.Enabled = true;
            txtNgayDKNV.Enabled = false;
            txtNguoiDKNV.Enabled = false;
            lueGioiTinhNV.Enabled = true;
            lueGioiTinhNV.EditValue = null;

            //reset text
            ResetlcgNhanVien();

            //load lookupedit Gioi Tinh
            string querygt = "select * from CTCN where MaHT = 1001";
            kn.LoadLookupedit(lueGioiTinhNV,querygt, "MoTaCN1", "MaCTCN");


        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            DataRow rownv = gvNhanVien.GetFocusedDataRow();
            if (rownv != null)
            {
                string queryxnv = "delete from NhanVien where MaNV ='" + rownv["MaNV"].ToString() + "'";
                kn.ExCute_NonQuery(queryxnv);
                NhanVienLoad();
            }
            else
                MessageBox.Show("Vui lòng chọn nhân viên cần xoá!");
        }

        private void btSuaNV_Click(object sender, EventArgs e)
        {
            DataRow rowfrc = gvNhanVien.GetFocusedDataRow();
            if (rowfrc != null)
            {
                ttbutton = 2;
                lcgNhanVien.Enabled = true;
                kn.ButtonSua(ucNhanVien);
                txtMaNV.Enabled = false;
                txtMatKhau.Enabled = true;
                txtTenNV.Enabled = true;
                txtDiaChiNV.Enabled = true;
                txtCMNDNV.Enabled = true;
                txtNgayDKNV.Enabled = false;
                txtNguoiDKNV.Enabled = false;
                lueGioiTinhNV.Enabled = true;
                txtMaNV.Text = rowfrc["MaNV"].ToString();
                txtMatKhau.Text = rowfrc["MatKhau"].ToString();
                txtTenNV.Text = rowfrc["TenNV"].ToString();
                //load lookupedit Gioi Tinh
                string querygt = "select * from CTCN where MaHT = 1001";
                kn.LoadLookupedit(lueGioiTinhNV, querygt, "MoTaCN1", "MaCTCN");
                lueGioiTinhNV.Properties.NullText = rowfrc["GioiTinhNV"].ToString();

                txtDiaChiNV.Text = rowfrc["DiaChiNV"].ToString();
                txtDienThoaiNV.Text = rowfrc["DienThoaiNV"].ToString();
                txtCMNDNV.Text = rowfrc["CMNDNV"].ToString();
                txtNguoiDKNV.Text = rowfrc["NguoiDKNV"].ToString();
                txtNgayDKNV.Text = rowfrc["NgayDKNV"].ToString();
            }
            else
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
        }

        private void btLuuPQ_Click(object sender, EventArgs e)
        {
            try
            {
                if (ttbutton == 1)//them CTQ
                {
                    DataRowView rowview = (DataRowView)lueTenCTQ.GetSelectedDataRow();
                    DataRow row = gvNhanVien.GetFocusedDataRow();
                    if (rowview !=null && row!=null)
                    {
                        string queryctq = "insert into CTQuyen values('" + row["MaNV"].ToString() + "','"
                                                                      + rowview["MaQuyen"].ToString() + "',N'"
                                                                      + lueTenCTQ.Text + "',N'"
                                                                      + txtGhiChuCTQ.Text + "',N'"
                                                                      + LopTinh.NhanTenNV.ToString() + "','"
                                                                      + DateTime.Now + "')";
                        kn.ExCute_NonQuery(queryctq);
                        lueTenCTQ.EditValue = null;
                        kn.ButtonLuu(ucPQ);
                        lueTenCTQ.Enabled = false;
                        txtGhiChuCTQ.Enabled = false;
                        NhanVien_FocusedRowChanged();
                        CTQuyen_FocusedRowChanged();
                    }
                    else
                        MessageBox.Show("Vui lòng chọn nhân viên hoặc quyền cần thêm!");
                }
                else if (ttbutton == 2)// sua CTQ
                {
                    DataRowView rowview = (DataRowView)lueTenCTQ.GetSelectedDataRow();
                    DataRow rowctq = gvCTQuyen.GetFocusedDataRow();
                    string queryspq = "update CTQuyen set MaQuyen ='" + rowview["MaQuyen"].ToString() + "',TenCTQ =N'"
                                                                      + rowview["TenQuyen"].ToString() + "',GhiChuCTQ=N'"
                                                                      + txtGhiChuCTQ.Text + "',NguoiDKCT=N'"
                                                                      + LopTinh.NhanTenNV.ToString() + "',NgayDKCTQ='"
                                                                      + DateTime.Now + "' where MaCTQ ='"
                                                                      + rowctq["MaCTQ"].ToString() + "'";
                    kn.ExCute_NonQuery(queryspq);
                    kn.ButtonLuu(ucPQ);
                    lueTenCTQ.EditValue = null;
                    lueTenCTQ.Enabled = false;
                    txtGhiChuCTQ.Enabled = false;
                    NhanVien_FocusedRowChanged();
                    CTQuyen_FocusedRowChanged();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + "from btLuuPQ");
            }
        }

        private void btThemPQ_Click(object sender, EventArgs e)
        {
            try
            {
                ttbutton = 1;
                kn.ButtonThem(ucPQ);
                lueTenCTQ.Enabled = true;
                txtGhiChuCTQ.Enabled = true;
                lueTenCTQ.Properties.NullText = null;
                txtGhiChuCTQ.ResetText();
                //load lookupedit TenCTQ
                string querytctq = "select * from DSQuyen";
                kn.LoadLookupedit(lueTenCTQ, querytctq, "TenQuyen", "MaQuyen");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " from btThemPQ");
            }            
        }

        private void btXoaPQ_Click(object sender, EventArgs e)
        {
            DataRow rowxpq = gvCTQuyen.GetFocusedDataRow();
            DataRow rownv = gvNhanVien.GetFocusedDataRow();
            if (rowxpq != null && rownv!= null)
            {
                string queryxpq = "delete from CTQuyen where MaCTQ ='" + rowxpq["MaCTQ"].ToString() + "'";
                kn.ExCute_NonQuery(queryxpq);
                NhanVien_FocusedRowChanged();
            }
            else
                MessageBox.Show("Vui lòng chọn nhân viên và quyền cần xoá!");
        }

        private void btSuaPQ_Click(object sender, EventArgs e)
        {
            try
            {
                ttbutton = 2;
                DataRow row = gvCTQuyen.GetFocusedDataRow();
                if (row != null)
                {
                    kn.ButtonSua(ucPQ);
                    lueTenCTQ.Enabled = true;
                    txtGhiChuCTQ.Enabled = true;
                    //load lueTenCTQ
                    string query = "select * from DSQuyen";
                    kn.LoadLookupedit(lueTenCTQ, query, "TenQuyen", "MaQuyen");
                }
                else
                    MessageBox.Show("Vui lòng chọn quyền cần sửa!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + "from btSuaPQ");
            }

        }

        private void gvNhanVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            NhanVien_FocusedRowChanged();
            CTQuyen_FocusedRowChanged();
        }

        private void NhanVien_FocusedRowChanged()
        {
            DataRow rowfrc = gvNhanVien.GetFocusedDataRow();
            if (rowfrc != null)
            {
                txtMaNV.Text = rowfrc["MaNV"].ToString();
                txtMatKhau.Text = rowfrc["MatKhau"].ToString();
                txtTenNV.Text = rowfrc["TenNV"].ToString();
                lueGioiTinhNV.Properties.NullText = rowfrc["GioiTinhNV"].ToString();
                txtDiaChiNV.Text = rowfrc["DiaChiNV"].ToString();
                txtDienThoaiNV.Text = rowfrc["DienThoaiNV"].ToString();
                txtCMNDNV.Text = rowfrc["CMNDNV"].ToString();
                txtNguoiDKNV.Text = rowfrc["NguoiDKNV"].ToString();
                txtNgayDKNV.Text = rowfrc["NgayDKNV"].ToString();

                //load grid conntrol Quyen nhan vien
                string querypq = "select * from CTQuyen where MaNV ='" + rowfrc["MaNV"].ToString() + "'";
                DataTable tbPhanQuyen = kn.NhanDuLieu(querypq);
                gcCTQuyen.DataSource = tbPhanQuyen;
            }
            else
            {
                ResetlcgNhanVien();
                gcCTQuyen.DataSource = null;
            }
        }

        private void ResetlcgNhanVien()
        {
            txtMaNV.ResetText();
            txtMatKhau.ResetText();
            txtTenNV.ResetText();
            lueGioiTinhNV.EditValue = null;
            lueGioiTinhNV.Properties.NullText = null;
            txtDiaChiNV.ResetText();
            txtDienThoaiNV.ResetText();
            txtCMNDNV.ResetText();
            txtNgayDKNV.ResetText();
            txtNguoiDKNV.ResetText();
        }

        private void gvCTQuyen_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            CTQuyen_FocusedRowChanged();
        }

        private void CTQuyen_FocusedRowChanged()
        {
            DataRow rowctq = gvCTQuyen.GetFocusedDataRow();
            if (rowctq != null)
            {
                lueTenCTQ.Properties.NullText = rowctq["TenCTQ"].ToString();
                txtGhiChuCTQ.Text = rowctq["GhiChuCTQ"].ToString();
            }
            else
            {
                lueTenCTQ.Properties.NullText = null;
                txtGhiChuCTQ.ResetText();
            }
        }
    }
}
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
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        KetNoi kn = new KetNoi();
        int btstatus;
        public frmSanPham()
        {
            InitializeComponent();

            //btSanPham
            ucSanPham.btThem.Click += new System.EventHandler(this.btThemSP_Click);
            ucSanPham.btLuu.Click += new System.EventHandler(this.btLuuSP_Click);
            ucSanPham.btXoa.Click += new System.EventHandler(this.btXoaSP_Click);
            ucSanPham.btSua.Click += new System.EventHandler(this.btSuaSP_Click);

            //btSPSize
            ucSPSize.btThem.Click += new System.EventHandler(this.btThemSPSize_Click);
            ucSPSize.btLuu.Click += new System.EventHandler(this.btLuuSPSize_Click);
            ucSPSize.btXoa.Click += new System.EventHandler(this.btXoaSPSize_Click);
            ucSPSize.btSua.Click += new System.EventHandler(this.btSuaSPSize_Click);
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {          
            SanPham_Load();
        }

        private void Autokey()
        {
            DataRowView temp = (DataRowView)lueThuongHieu.GetSelectedDataRow();
            if (temp != null)
            {
                string queryak = "Select * from SanPham where MaTH ='" + temp["MaTH"].ToString() + "'";
                DataTable dtTable = kn.NhanDuLieu(queryak);
                int n = dtTable.Rows.Count;
                DataRow drn;
                try
                {
                    if (n == 0)
                    {
                        this.txtMaSP.Text = temp["MaTH"].ToString() + "0001";
                    }
                    else
                    {
                        drn = dtTable.Rows[n - 1];

                        char[] cat = drn["MaSP"].ToString().ToCharArray();
                        int x = int.Parse(cat[6].ToString()) + 1 + int.Parse((cat[5]).ToString()) * 10;
                        if (x <= 9)
                        {

                            this.txtMaSP.Text = temp["MaTH"].ToString() + "000" + x;
                        }
                        else
                        {
                            if (x <= 99)
                            {
                                this.txtMaSP.Text = temp["MaTH"].ToString() + "00" + x;
                            }
                            else
                            {
                                if (x <= 999)
                                {
                                    this.txtMaSP.Text = temp["MaTH"].ToString() + "0" + x;
                                }
                                else
                                {
                                    this.txtMaSP.Text = temp["MaTH"].ToString() + x;
                                }
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi tạo Item code");
                }
            }
        }

        private void lcgSanPhamResetText()
        {
            txtMaSP.ResetText();
            txtMaTH.ResetText();
            txtTenSP.ResetText();
            txtTenTH.ResetText();
            ceSPPrice.ResetText();
            lueSPCurrency.Properties.NullText=null;
            lueSPUnit.Properties.NullText=null;
            txtRegistryDate.ResetText();
            txtSPRegistryName.ResetText();
            txtSPRemark.ResetText();
        }

        //form load san pham
        private void SanPham_Load()
        {
            //string query1 = "select * from CTQuyen where (MaNV ='" + LopTinh.NhanMaNV + "' and MaQuyen = '1001') or (MaNV ='" 
            //                                                       + LopTinh.NhanMaNV + "' and MaQuyen = '9999')";
            //DataTable dt_checkquyen = kn.NhanDuLieu(query1);

            //if(dt_checkquyen.Rows.Count>0)
            //{
            //    ucSanPham.Enabled = true;
            //}
            //else
            //{
            //    ucSanPham.Enabled = false;
            //}
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            string query = "select * from ThuongHieu";
            kn.LoadLookupedit(lueThuongHieu,query, "TenTH", "MaTH");
            lcgSP.Enabled = false;
            lueSPSize.Enabled = false;
            txtSPColor.Enabled = false;
            
        }

        //su kien texchaged thuong hieu
        private void lueThuongHieu_TextChanged(object sender, EventArgs e)
        {
            ThuongHieu_TextChanged();
        }

        private void ThuongHieu_TextChanged()
        {
            DataRowView rowv = (DataRowView)lueThuongHieu.GetSelectedDataRow();
            //load gc san pham
            string query = "select * from SanPham where MaTH='" + rowv["MaTH"].ToString() + "'";           
            DataTable tbSP = kn.NhanDuLieu(query);
            gcSanPham.DataSource = tbSP;
            SanPham_FocusedRowChanged();
        }

        private void btThemSP_Click(object sender, EventArgs e)
        {
            try
            {
                btstatus = 1;
                DataRowView rowv = (DataRowView)lueThuongHieu.GetSelectedDataRow();
                if (rowv != null)
                {
                    lcgSanPhamResetText();
                    ceSPPrice.Text = "0";
                    Autokey();
                    lcgSP.Enabled = true;
                    txtMaSP.Enabled = false;
                    txtMaTH.Enabled = false;
                    txtTenTH.Enabled = false;
                    txtTenSP.Enabled = true;
                    kn.ButtonThem(ucSanPham);
                    txtSPRegistryName.Enabled = false;
                    txtRegistryDate.Enabled = false;
                    string query1 = "select * from CTCN where MaHT ='1007'";
                    kn.LoadLookupedit(lueSPCurrency,query1,"MoTaCN1","MaCTCN");

                    string query2 = "select * from CTCN where MaHT ='1008'";
                    kn.LoadLookupedit(lueSPUnit, query2, "MoTaCN1", "MaCTCN");
                    txtMaTH.Text = rowv["MaTH"].ToString();
                    txtTenTH.Text = rowv["TenTH"].ToString();
                }
                else
                    MessageBox.Show("Please select Brand!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " from Registry Products");
            }
        }

        private void btXoaSP_Click(object sender, EventArgs e)
        {
            DataRow row = gvSanPham.GetFocusedDataRow();
            if (row !=null)
            {
                string query = "delete from SanPham where MaSP='" +row["MaSP"].ToString()+"'";
                kn.ExCute_NonQuery(query);
                ThuongHieu_TextChanged();
            }
            else
                MessageBox.Show("Please select Product to delete!");
        }

        private void btSuaSP_Click(object sender, EventArgs e)
        {
            try
            {
                btstatus = 2;
                DataRow row = gvSanPham.GetFocusedDataRow();
                if (row != null)
                {
                    kn.ButtonSua(ucSanPham);
                    lcgSP.Enabled = true;
                    txtMaSP.Enabled = false;
                    txtMaTH.Enabled = false;
                    txtTenTH.Enabled = false;
                    txtTenSP.Enabled = false;
                    txtRegistryDate.Enabled = false;
                    txtSPRegistryName.Enabled = false;

                    string query1 = "select * from CTCN where MaHT ='1007'";
                    kn.LoadLookupedit(lueSPCurrency, query1, "MoTaCN1", "MaCTCN");

                    string query2 = "select * from CTCN where MaHT ='1008'";
                    kn.LoadLookupedit(lueSPUnit, query2, "MoTaCN1", "MaCTCN");
                }
                else
                    MessageBox.Show("Please select Product to edit!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString() + " from Edit product!");
            }            
        }
        private void btLuuSP_Click(object sender, EventArgs e)
        {
            try
            {
                if (btstatus == 1)
                {
                    if (txtTenSP.Text != "" && lueSPCurrency.Text != "" && lueSPUnit.Text != "")
                    {
                        string query = "insert into SanPham values ('" + txtMaSP.Text + "','" + txtMaTH.Text + "',N'"
                                                                       + txtTenTH.Text + "',N'" + txtTenSP.Text + "','"
                                                                       + ceSPPrice.Text + "','" + lueSPCurrency.Text + "',N'"
                                                                       + lueSPUnit.Text + "',N'" + LopTinh.NhanTenNV.ToString() + "','"
                                                                       + DateTime.Now + "',N'" + txtSPRemark.Text + "')";
                        kn.ExCute_NonQuery(query);
                        ThuongHieu_TextChanged();
                        lueSPCurrency.EditValue = null;
                        lueSPUnit.EditValue = null;
                        kn.ButtonLuu(ucSanPham);
                        lcgSP.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Some info is null!");
                    }
                }
                else if(btstatus==2)
                {
                    DataRow row = gvSanPham.GetFocusedDataRow();
                    if (row != null)
                    {
                        string query = "update SanPham set GiaSP ='" + ceSPPrice.Text + "', TTSP ='" + lueSPCurrency.Text + "', DVTSP =N'"
                                                                + lueSPUnit.Text + "', NguoiDKSP=N'" + LopTinh.NhanTenNV.ToString() + "', NgayDKSP ='"
                                                                + DateTime.Now + "', GhiChuSP=N'" + txtSPRemark.Text + "',TenSP=N'" + txtTenSP.Text+"' where MaSP ='"
                                                                + row["MaSP"].ToString() + "'";
                        kn.ExCute_NonQuery(query);
                        kn.ButtonLuu(ucSanPham);
                        lcgSP.Enabled = false;
                        //ceSPPrice.Properties.ReadOnly=true;
                        lueSPCurrency.EditValue = null;
                        lueSPUnit.EditValue = null;
                        ThuongHieu_TextChanged();
                    }
                    else
                        MessageBox.Show("Please select Product!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "from Save Product"); ;
            }
            
        }

        private void gvSanPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SanPham_FocusedRowChanged();
        }
        private void SanPham_FocusedRowChanged()
        {
            try
            {
                DataRow row = gvSanPham.GetFocusedDataRow();
                if (row != null)
                {
                    txtMaSP.Text= row["MaSP"].ToString();
                    txtMaTH.Text=row["MaTH"].ToString();
                    txtTenSP.Text=row["TenSP"].ToString();
                    txtTenTH.Text=row["TenTH"].ToString();
                    ceSPPrice.Text=row["GiaSP"].ToString();
                    lueSPCurrency.Properties.NullText=row["TTSP"].ToString();
                    lueSPUnit.Properties.NullText=row["DVTSP"].ToString();
                    txtRegistryDate.Text=row["NgayDKSP"].ToString();
                    txtSPRegistryName.Text=row["NguoiDKSP"].ToString();
                    txtSPRemark.Text = row["GhiChuSP"].ToString();
                }
                else
                {
                    lcgSanPhamResetText();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "from SanPham_FocusedRowChanged");
            }
        }

        private void btLuuSPSize_Click(object sender, EventArgs e)
        {
            try
            {
                if (lueSPSize.EditValue == null) {MessageBox.Show("Vui lòng chọn màu!"); return;}
                
                if (btstatus == 1)
                {
                    DataRow row = gvSanPham.GetFocusedDataRow();
                    string query = "insert into MauNL values ('" + row[0].ToString() + "','" + lueSPSize.EditValue.ToString()
                                                                       + "',N'" + LopTinh.NhanTenNV.ToString() + "','"
                                                                       + DateTime.Now + "')";
                        kn.ExCute_NonQuery(query);
                }
                else if (btstatus == 2)
                {
                    DataRow row = gvSanPham.GetFocusedDataRow();
                    if (row != null)
                    {
                        string query = "update SanPham set GiaSP ='" + ceSPPrice.Text + "', TTSP ='" + lueSPCurrency.Text + "', DVTSP =N'"
                                                                + lueSPUnit.Text + "', NguoiDKSP=N'" + LopTinh.NhanTenNV.ToString() + "', NgayDKSP ='"
                                                                + DateTime.Now + "', GhiChuSP=N'" + txtSPRemark.Text + "',TenSP=N'" + txtTenSP.Text + "' where MaSP ='"
                                                                + row["MaSP"].ToString() + "'";
                        kn.ExCute_NonQuery(query);
                        kn.ButtonLuu(ucSanPham);
                        lcgSP.Enabled = false;
                        //ceSPPrice.Properties.ReadOnly=true;
                        lueSPCurrency.EditValue = null;
                        lueSPUnit.EditValue = null;
                        ThuongHieu_TextChanged();
                    }
                    else
                        MessageBox.Show("Please select Product!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "from Save Product"); ;
            }
        }

        private void btThemSPSize_Click(object sender, EventArgs e)
        {
            try
            {
                btstatus = 1;
                DataRow row = gvSanPham.GetFocusedDataRow();
                DataRowView rowv = (DataRowView)lueSPSize.GetSelectedDataRow();
                if (row != null)
                {
                    kn.ButtonThem(ucSPSize);
                    lueSPSize.Enabled = true;
                    string query = "select * from CTCN where MaHT ='1011'";
                    kn.LoadLookupedit(lueSPSize, query, "MoTaCN1", "MaCTCN");
                }
                else
                MessageBox.Show("Please select Product!");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message.ToString() + " from Add Size!");
            }
        }

        private void btXoaSPSize_Click(object sender, EventArgs e)
        {

        }

        private void btSuaSPSize_Click(object sender, EventArgs e)
        {
        }
    }
}
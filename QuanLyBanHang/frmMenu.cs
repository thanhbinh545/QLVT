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
    public partial class frmMenu : DevExpress.XtraEditors.XtraForm
    {

        KetNoi kn = new KetNoi();
        public frmMenu()
        {
            InitializeComponent();
        }

        private bool ExistForm(XtraForm form)
        {
            foreach (var child in MdiChildren)
            {
                if (child.Name == form.Name)
                {
                    child.Activate();
                    return true;
                }
            }
            return false;
        }

        private void barHeaderItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barStaticItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            MenuLoad();
        }

        private void MenuLoad()
        {
            var frmDN = new frmDangNhap();
            frmDN.Focus();
            frmDN.ShowDialog();

            bhiStaff.Caption = LopTinh.NhanTenNV;
            //var frmTG = new frmTroGiup();
            //if (ExistForm(frmTG)) return;
            //frmTG.MdiParent = this;
            //frmTG.Show();
        }

        private void btTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = "select MaCTQ from CTQuyen where (MaQuyen = '1001' and MaNV= '" + LopTinh.NhanMaNV + "')";
            DataTable tbq = kn.NhanDuLieu(query);
            int dem = tbq.Rows.Count;

            if (LopTinh.NhanMaNV == "10000" || dem > 0)
            {
                var frmDKSP = new frmSanPham();
                if (ExistForm(frmDKSP)) return;
                frmDKSP.MdiParent = this;
                frmDKSP.Show();
            }
            else
            {
                var frmDKSP = new frmSanPham();
                if (ExistForm(frmDKSP)) return;
                frmDKSP.MdiParent = this;
                frmDKSP.Show();
                frmDKSP.ucSanPham.Enabled = false;
                frmDKSP.ucSPColor.Enabled = false;
                frmDKSP.ucSPSize.Enabled = false;
            }
        }

        private void btProductInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmPIP = new frmProductInput();
            if (ExistForm(frmPIP)) return;
            frmPIP.MdiParent = this;
            frmPIP.Show();
        }

        private void btHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = "select MaCTQ from CTQuyen where (MaQuyen = '5001' and MaNV= '" + LopTinh.NhanMaNV + "')";
            DataTable tbq = kn.NhanDuLieu(query);
            int dem = tbq.Rows.Count;

            if (LopTinh.NhanMaNV == "10000" || dem > 0)
            {
                var frmHT = new frmHeThong();
                if (ExistForm(frmHT)) return;
                frmHT.MdiParent = this;
                frmHT.Show();
            }
            else
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
        }

        private void btTroGiup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmTG = new frmTroGiup();
            if (ExistForm(frmTG)) return;
            frmTG.MdiParent = this;
            frmTG.Show();
        }

        private void btNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = "select MaCTQ from CTQuyen where (MaQuyen = '4001' and MaNV= '" + LopTinh.NhanMaNV + "')";
            DataTable tbq = kn.NhanDuLieu(query);
            int dem = tbq.Rows.Count;

            if (LopTinh.NhanMaNV == "10000" || dem > 0)
            {
                var frmNV = new frmNhanVien();
                if (ExistForm(frmNV)) return;
                frmNV.MdiParent = this;
                frmNV.Show();
            }
            else
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!");
        }

        private void NewLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (var child in MdiChildren)
            child.Close();
            MenuLoad();
        }

        private void btExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btTotalInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmTPI = new frmTotalInput();
            if (ExistForm(frmTPI)) return;
            frmTPI.MdiParent = this;
            frmTPI.Show();
        }

        private void btTotalOutput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmTPO = new frmTotalOutput();
            if (ExistForm(frmTPO)) return;
            frmTPO.MdiParent = this;
            frmTPO.Show();
        }

        private void btTotalStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmTPS = new frmTotalStock();
            if (ExistForm(frmTPS)) return;
            frmTPS.MdiParent = this;
            frmTPS.Show();
        }

        private void btPaymentStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmPS = new frmPaymentStatus();
            if (ExistForm(frmPS)) return;
            frmPS.MdiParent = this;
            frmPS.Show();
        }

        private void btHome1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmH = new frmHome();
            if (ExistForm(frmH)) return;
            frmH.MdiParent = this;
            frmH.Show();
        }

        private void btProductsOutput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frmPOP = new frmProductoutput();
            if (ExistForm(frmPOP)) return;
            frmPOP.MdiParent = this;
            frmPOP.Show();
        }
    }
}
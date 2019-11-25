using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang
{
    [Serializable]
    public class Ob_Material
    {
        ////////
        private string m_Ma;
        public string Ma { get { return m_Ma; } set { m_Ma = value; } }

        private string m_MaTH;
        public string MaTH { get { return m_MaTH; } set { m_MaTH = value; } }

        private string m_TenTH;
        public string TenTH { get { return m_TenTH; } set { m_TenTH = value; } }

        private string m_TenSP;
        public string TenSP { get { return m_TenSP; } set { m_TenSP = value; } }

        private double m_GiaSP;
        public double GiaSP { get { return m_GiaSP; } set { m_GiaSP = value; } }

        private string m_TTSP;
        public string TTSP { get { return m_TTSP; } set { m_TTSP = value; } }

        private string m_DVTSP;
        public string DVTSP { get { return m_DVTSP; } set { m_DVTSP = value; } }

        private string m_GhiChu;
        public string GhiChu { get { return m_GhiChu; } set { m_GhiChu = value; } }

        private string m_NguoiDK;
        public string NguoiDK { get { return m_NguoiDK; } set { m_NguoiDK = value; } }

        private DateTime m_NgayDK;
        public DateTime NgayDK { get { return m_NgayDK; } set { m_NgayDK = value; } }

        private Cls_TT_Material m_TTChung;
        public Cls_TT_Material TTChung { get { return m_TTChung; } set { m_TTChung = value; } }

        public Ob_Material()
        {
            this.m_MaTH = "";
            this.m_TenTH = "";
            this.m_TenSP = "";
            this.m_GiaSP = 0;
            this.m_TTSP = "";
            this.m_DVTSP = "";
            this.m_NguoiDK = "";
            this.m_NgayDK = LopTinh.NgayMD;
            this.m_GhiChu = "";
        }

        public Ob_Material(Ob_Material ob)
        {
            this.m_MaTH = ob.MaTH;
            this.m_TenTH = ob.TenTH;
            this.m_TenSP = ob.TenSP;
            this.m_GiaSP = ob.GiaSP;
            this.m_TTSP = ob.TTSP;
            this.m_DVTSP = ob.DVTSP;
            this.m_NguoiDK = ob.NguoiDK;
            this.m_NgayDK = ob.NgayDK;
            this.m_GhiChu = ob.GhiChu;
        }
    }

    [Serializable]
    public class Cls_TT_Material
    {
        public Cls_TT_Material()
        {
        }

        public Cls_TT_Material(Cls_TT_Material ob)
        {
        }
    }

    [Serializable]
    public class DBaOb_Material
    {
        public static List<Ob_Material> GetListOb()
        {
            //Ma, Ten, QuanHe, CMND, NgaySinh, DiaChi, DienThoai, NgheNgiep, GhiChu, PhuThuoc, NguoiDK, NgayDK, TTChung
            List<Ob_Material> listOb = new List<Ob_Material>();
            SqlDataReader data;
            data = DBStaticHRM.SqlExcuteQuery("SELECT * FROM HRM_NhanThan");
            if (null == data) { return null; }
            while (data.Read())
            {
                Ob_Material ob = new Ob_Material();
                if (!data.IsDBNull(0)) ob.Ma = data.GetInt32(0);
                if (!data.IsDBNull(1)) ob.Ten = data.GetString(1);
                if (!data.IsDBNull(2)) ob.MaNV = data.GetInt32(2);
                if (!data.IsDBNull(3)) ob.QuanHe = data.GetString(3);
                if (!data.IsDBNull(4)) ob.CMND = data.GetString(4);

                if (!data.IsDBNull(5)) ob.NgaySinh = data.GetDateTime(5);
                if (!data.IsDBNull(6)) ob.DiaChi = data.GetString(6);
                if (!data.IsDBNull(7)) ob.DienThoai = data.GetString(7);
                if (!data.IsDBNull(8)) ob.NgheNgiep = data.GetString(8);

                if (!data.IsDBNull(9)) ob.GhiChu = data.GetString(9);
                if (!data.IsDBNull(10)) ob.PhuThuoc = data.GetBoolean(10);
                if (!data.IsDBNull(11)) ob.NguoiDK = data.GetString(11);
                if (!data.IsDBNull(12)) ob.NgayDK = data.GetString(12); ;

                if (!data.IsDBNull(13))
                {
                    byte[] blob = (byte[])data.GetValue(13);
                    if (blob.Length > 1)
                    {
                        try
                        {
                            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            MemoryStream stream = new MemoryStream(blob);
                            ob.TTChung = (Cls_TTHRM_NhanThan)bf.Deserialize(stream);
                        }
                        catch { }
                    }
                }

                listOb.Add(ob);
            }
            data.Close();
            return listOb;
        }

        public static List<Ob_Material> GetListOb(int manv)
        {
            //Ma, Ten, QuanHe, CMND, NgaySinh, DiaChi, DienThoai, NgheNgiep, GhiChu, PhuThuoc, NguoiDK, NgayDK, TTChung
            List<Ob_Material> listOb = new List<Ob_Material>();

            SqlCommand comm = new SqlCommand();

            comm.CommandText = "SELECT * FROM HRM_NhanThan WHERE MaNV = @MaNV";
            SqlParameter sqlPar;
            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "MaNV";
            sqlPar.SqlDbType = System.Data.SqlDbType.Int;
            sqlPar.Size = 0;
            sqlPar.Value = manv;
            comm.Parameters.Add(sqlPar);

            SqlDataReader data;
            data = DBStaticHRM.SqlExcuteQuery(comm);
            if (null == data) { return null; }
            while (data.Read())
            {
                Ob_Material ob = new Ob_Material();
                if (!data.IsDBNull(0)) ob.Ma = data.GetInt32(0);
                if (!data.IsDBNull(1)) ob.Ten = data.GetString(1);
                if (!data.IsDBNull(2)) ob.MaNV = data.GetInt32(2);
                if (!data.IsDBNull(3)) ob.QuanHe = data.GetString(3);
                if (!data.IsDBNull(4)) ob.CMND = data.GetString(4);

                if (!data.IsDBNull(5)) ob.NgaySinh = data.GetDateTime(5);
                if (!data.IsDBNull(6)) ob.DiaChi = data.GetString(6);
                if (!data.IsDBNull(7)) ob.DienThoai = data.GetString(7);
                if (!data.IsDBNull(8)) ob.NgheNgiep = data.GetString(8);

                if (!data.IsDBNull(9)) ob.GhiChu = data.GetString(9);
                if (!data.IsDBNull(10)) ob.PhuThuoc = data.GetBoolean(10);
                if (!data.IsDBNull(11)) ob.NguoiDK = data.GetString(11);
                if (!data.IsDBNull(12)) ob.NgayDK = data.GetString(12); ;

                if (!data.IsDBNull(13))
                {
                    byte[] blob = (byte[])data.GetValue(13);
                    if (blob.Length > 1)
                    {
                        try
                        {
                            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                            MemoryStream stream = new MemoryStream(blob);
                            ob.TTChung = (Cls_TTHRM_NhanThan)bf.Deserialize(stream);
                        }
                        catch { }
                    }
                }

                listOb.Add(ob);
            }
            data.Close();
            return listOb;
        }

        public static int Insert(Ob_Material ob, SqlCommand comm)
        {
            //Ma, Ten, QuanHe, CMND, NgaySinh, DiaChi, DienThoai, NgheNgiep, GhiChu, PhuThuoc, NguoiDK, NgayDK, TTChung
            SqlParameter sqlPar;
            comm = new SqlCommand();
            comm.CommandText = " INSERT INTO HRM_NhanThan (Ma, Ten, MaNV, QuanHe, CMND, NgaySinh, DiaChi, DienThoai, NgheNgiep, GhiChu, PhuThuoc, NguoiDK, NgayDK, TTChung) VALUES(@Ma, @Ten, @MaNV, @QuanHe, @CMND, @NgaySinh, @DiaChi, @DienThoai, @NgheNgiep, @GhiChu, @PhuThuoc, @NguoiDK, @NgayDK, @TTChung)";

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "Ma";
            sqlPar.SqlDbType = System.Data.SqlDbType.Int;
            sqlPar.Size = 0;
            sqlPar.Value = ob.Ma;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "Ten";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.Ten;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "MaNV";
            sqlPar.SqlDbType = System.Data.SqlDbType.Int;
            sqlPar.Size = 0;
            sqlPar.Value = ob.MaNV;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "QuanHe";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.QuanHe;
            comm.Parameters.Add(sqlPar);

            //Ma, Ten, QuanHe, CMND, NgaySinh, DiaChi, DienThoai, NgheNgiep, GhiChu, PhuThuoc, NguoiDK, NgayDK, TTChung
            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "CMND";
            sqlPar.SqlDbType = System.Data.SqlDbType.VarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.CMND;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NgaySinh";
            sqlPar.SqlDbType = System.Data.SqlDbType.DateTime;
            sqlPar.Size = 0;
            sqlPar.Value = ob.NgaySinh;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "DiaChi";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 100;
            sqlPar.Value = ob.DiaChi;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "DienThoai";
            sqlPar.SqlDbType = System.Data.SqlDbType.VarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.DienThoai;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NgheNgiep";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 100;
            sqlPar.Value = ob.NgheNgiep;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "GhiChu";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 200;
            sqlPar.Value = ob.GhiChu;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "PhuThuoc";
            sqlPar.SqlDbType = System.Data.SqlDbType.Bit;
            sqlPar.Size = 0;
            sqlPar.Value = ob.PhuThuoc;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NguoiDK";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.NguoiDK;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NgayDK";
            sqlPar.SqlDbType = System.Data.SqlDbType.VarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.NgayDK;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "TTChung";
            sqlPar.SqlDbType = System.Data.SqlDbType.Image;
            sqlPar.Size = 0;
            int st1 = -1;
            if (null != ob.TTChung)
            {
                try
                {
                    //trueyn Kieu Image cho SqlParameter
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    MemoryStream stream = new MemoryStream();
                    bf.Serialize(stream, ob.TTChung);
                    sqlPar.Size = (int)stream.Length;
                    sqlPar.Value = stream.ToArray(); st1 = 0;
                }
                catch { st1 = -1; }
            }
            if (st1 == -1)
            {
                sqlPar.Size = 1;
                sqlPar.Value = new byte[] { 1 };
            }
            comm.Parameters.Add(sqlPar);

            return DBStaticHRM.SqlExcuteNonQuery(comm);
        }

        public static int Update(Ob_Material ob, SqlCommand comm)
        {

            SqlParameter sqlPar;
            comm.Parameters.Clear();
            //SqlCommand comm = new SqlCommand();
            comm.CommandText = " UPDATE HRM_NhanThan SET  Ten =@Ten, MaNV = @MaNV, QuanHe =@QuanHe, CMND =@CMND, NgaySinh =@NgaySinh, DiaChi =@DiaChi, DienThoai =@DienThoai, NgheNgiep =@NgheNgiep, GhiChu =@GhiChu, PhuThuoc =@PhuThuoc, NguoiDK =@NguoiDK, NgayDK =@NgayDK, TTChung = @TTChung WHERE ( Ma = @K_Ma)";

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "Ten";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.Ten;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "MaNV";
            sqlPar.SqlDbType = System.Data.SqlDbType.Int;
            sqlPar.Size = 0;
            sqlPar.Value = ob.MaNV;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "QuanHe";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.QuanHe;
            comm.Parameters.Add(sqlPar);

            //Ma, Ten, QuanHe, CMND, NgaySinh, DiaChi, DienThoai, NgheNgiep, GhiChu, PhuThuoc, NguoiDK, NgayDK, TTChung
            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "CMND";
            sqlPar.SqlDbType = System.Data.SqlDbType.VarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.CMND;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NgaySinh";
            sqlPar.SqlDbType = System.Data.SqlDbType.DateTime;
            sqlPar.Size = 0;
            sqlPar.Value = ob.NgaySinh;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "DiaChi";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 100;
            sqlPar.Value = ob.DiaChi;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "DienThoai";
            sqlPar.SqlDbType = System.Data.SqlDbType.VarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.DienThoai;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NgheNgiep";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 100;
            sqlPar.Value = ob.NgheNgiep;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "GhiChu";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 200;
            sqlPar.Value = ob.GhiChu;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "PhuThuoc";
            sqlPar.SqlDbType = System.Data.SqlDbType.Bit;
            sqlPar.Size = 0;
            sqlPar.Value = ob.PhuThuoc;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NguoiDK";
            sqlPar.SqlDbType = System.Data.SqlDbType.NVarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.NguoiDK;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "NgayDK";
            sqlPar.SqlDbType = System.Data.SqlDbType.VarChar;
            sqlPar.Size = 50;
            sqlPar.Value = ob.NgayDK;
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "TTChung";
            sqlPar.SqlDbType = System.Data.SqlDbType.Image;
            sqlPar.Size = 0;
            int st1 = -1;
            if (null != ob.TTChung)
            {
                try
                {
                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    MemoryStream stream = new MemoryStream();
                    bf.Serialize(stream, ob.TTChung);
                    sqlPar.Size = (int)stream.Length;
                    sqlPar.Value = stream.ToArray(); st1 = 0;
                }
                catch
                {
                    try
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        MemoryStream stream = new MemoryStream();
                        bf.Serialize(stream, ob.TTChung);
                        sqlPar.Size = (int)stream.Length;
                        sqlPar.Value = stream.ToArray(); st1 = 0;
                    }
                    catch
                    {
                        st1 = -1;
                    }
                }
            }
            if (st1 == -1)
            {
                sqlPar.Size = 1;
                sqlPar.Value = new byte[] { 1 };
            }
            comm.Parameters.Add(sqlPar);

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "K_Ma";
            sqlPar.SqlDbType = System.Data.SqlDbType.Float;
            sqlPar.Value = ob.Ma;
            comm.Parameters.Add(sqlPar);

            return DBStaticHRM.SqlExcuteNonQuery(comm);
        }

        public static int Delete(Ob_Material ob)
        {
            SqlParameter sqlPar;
            SqlCommand comm = new SqlCommand();
            comm.CommandText = "DELETE FROM HRM_NhanThan WHERE(Ma = @K_Ma)";

            sqlPar = new SqlParameter();
            sqlPar.ParameterName = "K_Ma";
            sqlPar.SqlDbType = System.Data.SqlDbType.Float;
            sqlPar.Size = 0;
            sqlPar.Value = ob.Ma;
            comm.Parameters.Add(sqlPar);

            return DBStaticHRM.SqlExcuteNonQuery(comm);
        }

    }
}

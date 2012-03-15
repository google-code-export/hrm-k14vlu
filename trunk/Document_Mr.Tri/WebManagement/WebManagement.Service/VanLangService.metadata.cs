
namespace WebManagement.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies Vlu_CamNhanMetadata as the class
    // that carries additional metadata for the Vlu_CamNhan class.
    [MetadataTypeAttribute(typeof(Vlu_CamNhan.Vlu_CamNhanMetadata))]
    public partial class Vlu_CamNhan
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_CamNhan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_CamNhanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_CamNhanMetadata()
            {
            }

            public bool Duyet { get; set; }

            public string Email { get; set; }

            public bool HienThi { get; set; }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public Nullable<DateTime> NgayDuyet { get; set; }

            public DateTime NgayGui { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiDuyet { get; set; }

            public string NguoiGui { get; set; }

            public int NhomID { get; set; }

            public string NoiDung { get; set; }

            public int PortalID { get; set; }

            public string TieuDe { get; set; }

            public string TuServer { get; set; }

            public Vlu_CamNhanNhom Vlu_CamNhanNhom { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_CamNhanNhomMetadata as the class
    // that carries additional metadata for the Vlu_CamNhanNhom class.
    [MetadataTypeAttribute(typeof(Vlu_CamNhanNhom.Vlu_CamNhanNhomMetadata))]
    public partial class Vlu_CamNhanNhom
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_CamNhanNhom class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_CamNhanNhomMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_CamNhanNhomMetadata()
            {
            }

            public bool Duyet { get; set; }

            public bool HienThi { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public Nullable<DateTime> NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int NhomID { get; set; }

            public string NoiDung { get; set; }

            public Nullable<int> ParentID { get; set; }

            public int SapXep { get; set; }

            public string TenNhom { get; set; }

            public EntityCollection<Vlu_CamNhan> Vlu_CamNhan { get; set; }

            public EntityCollection<Vlu_CamNhanNhom> Vlu_CamNhanNhomChilds { get; set; }

            public Vlu_CamNhanNhom Vlu_CamNhanNhomParent { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuongTrinhDTMetadata as the class
    // that carries additional metadata for the Vlu_ChuongTrinhDT class.
    [MetadataTypeAttribute(typeof(Vlu_ChuongTrinhDT.Vlu_ChuongTrinhDTMetadata))]
    public partial class Vlu_ChuongTrinhDT
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuongTrinhDT class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuongTrinhDTMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuongTrinhDTMetadata()
            {
            }

            public int HocKy { get; set; }

            public int ID { get; set; }

            public int KhoaID { get; set; }

            public int LopID { get; set; }

            public int MonHocID { get; set; }

            public int NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Vlu_Khoa Vlu_Khoa { get; set; }

            public Vlu_LopHoc Vlu_LopHoc { get; set; }

            public Vlu_MonHoc Vlu_MonHoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuyenMucMetadata as the class
    // that carries additional metadata for the Vlu_ChuyenMuc class.
    [MetadataTypeAttribute(typeof(Vlu_ChuyenMuc.Vlu_ChuyenMucMetadata))]
    public partial class Vlu_ChuyenMuc
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuyenMuc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuyenMucMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuyenMucMetadata()
            {
            }

            public int ChuyenMucID { get; set; }

            public bool DaXoa { get; set; }

            public string Duongdan { get; set; }

            public bool HienThi { get; set; }

            public string Hinh { get; set; }

            public bool Internet { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Nullable<int> ParentID { get; set; }

            public int SapXep { get; set; }

            public string TenChuyenMuc { get; set; }

            public EntityCollection<Vlu_ChuyenMuc> Vlu_ChuyenMucChilds { get; set; }

            public Vlu_ChuyenMuc Vlu_ChuyenMucParent { get; set; }

            public EntityCollection<Vlu_ChuyenMucPhanQuyen> Vlu_ChuyenMucPhanQuyen { get; set; }

            public EntityCollection<Vlu_ChuyenMucTrongNoiDung> Vlu_ChuyenMucTrongNoiDung { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuyenMucNoiDungMetadata as the class
    // that carries additional metadata for the Vlu_ChuyenMucNoiDung class.
    [MetadataTypeAttribute(typeof(Vlu_ChuyenMucNoiDung.Vlu_ChuyenMucNoiDungMetadata))]
    public partial class Vlu_ChuyenMucNoiDung
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuyenMucNoiDung class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuyenMucNoiDungMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuyenMucNoiDungMetadata()
            {
            }

            public bool DaXoa { get; set; }

            public bool Duyet { get; set; }

            public string GhiChu { get; set; }

            public bool HienThi { get; set; }

            public bool Internet { get; set; }

            public int Loai { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiGiu { get; set; }

            public string NguoiNhan { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public int NoiDungID { get; set; }

            public int SapXep { get; set; }

            public string TieuDe { get; set; }

            public string TomTat { get; set; }

            public EntityCollection<Vlu_ChuyenMucPhienBan> Vlu_ChuyenMucPhienBan { get; set; }

            public EntityCollection<Vlu_ChuyenMucTinLienQuan> Vlu_ChuyenMucTinLienQuan { get; set; }

            public EntityCollection<Vlu_ChuyenMucTrongNoiDung> Vlu_ChuyenMucTrongNoiDung { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuyenMucPhanQuyenMetadata as the class
    // that carries additional metadata for the Vlu_ChuyenMucPhanQuyen class.
    [MetadataTypeAttribute(typeof(Vlu_ChuyenMucPhanQuyen.Vlu_ChuyenMucPhanQuyenMetadata))]
    public partial class Vlu_ChuyenMucPhanQuyen
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuyenMucPhanQuyen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuyenMucPhanQuyenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuyenMucPhanQuyenMetadata()
            {
            }

            public int ChuyenMucID { get; set; }

            public string NguoiBaoCao { get; set; }

            public string NguoiNhan { get; set; }

            public int PhanQuyenID { get; set; }

            public Vlu_ChuyenMuc Vlu_ChuyenMuc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuyenMucPhienBanMetadata as the class
    // that carries additional metadata for the Vlu_ChuyenMucPhienBan class.
    [MetadataTypeAttribute(typeof(Vlu_ChuyenMucPhienBan.Vlu_ChuyenMucPhienBanMetadata))]
    public partial class Vlu_ChuyenMucPhienBan
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuyenMucPhienBan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuyenMucPhienBanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuyenMucPhienBanMetadata()
            {
            }

            public string GhiChu { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public int NoiDungID { get; set; }

            public int PhienBan { get; set; }

            public int PhienBanID { get; set; }

            public string TieuDe { get; set; }

            public string TomTat { get; set; }

            public Vlu_ChuyenMucNoiDung Vlu_ChuyenMucNoiDung { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuyenMucTinLienQuanMetadata as the class
    // that carries additional metadata for the Vlu_ChuyenMucTinLienQuan class.
    [MetadataTypeAttribute(typeof(Vlu_ChuyenMucTinLienQuan.Vlu_ChuyenMucTinLienQuanMetadata))]
    public partial class Vlu_ChuyenMucTinLienQuan
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuyenMucTinLienQuan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuyenMucTinLienQuanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuyenMucTinLienQuanMetadata()
            {
            }

            public string DuongDan { get; set; }

            public int ID { get; set; }

            public string IDKhac { get; set; }

            public int Loai { get; set; }

            public int NoiDungID { get; set; }

            public int TabId { get; set; }

            public string TieuDe { get; set; }

            public Vlu_ChuyenMucNoiDung Vlu_ChuyenMucNoiDung { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ChuyenMucTrongNoiDungMetadata as the class
    // that carries additional metadata for the Vlu_ChuyenMucTrongNoiDung class.
    [MetadataTypeAttribute(typeof(Vlu_ChuyenMucTrongNoiDung.Vlu_ChuyenMucTrongNoiDungMetadata))]
    public partial class Vlu_ChuyenMucTrongNoiDung
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ChuyenMucTrongNoiDung class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ChuyenMucTrongNoiDungMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ChuyenMucTrongNoiDungMetadata()
            {
            }

            public int ChuyenMucID { get; set; }

            public int ID { get; set; }

            public int NoiDungID { get; set; }

            public Vlu_ChuyenMuc Vlu_ChuyenMuc { get; set; }

            public Vlu_ChuyenMucNoiDung Vlu_ChuyenMucNoiDung { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_DeCuongMH_TaiLieuMetadata as the class
    // that carries additional metadata for the Vlu_DeCuongMH_TaiLieu class.
    [MetadataTypeAttribute(typeof(Vlu_DeCuongMH_TaiLieu.Vlu_DeCuongMH_TaiLieuMetadata))]
    public partial class Vlu_DeCuongMH_TaiLieu
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_DeCuongMH_TaiLieu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_DeCuongMH_TaiLieuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_DeCuongMH_TaiLieuMetadata()
            {
            }

            public int DeCuongID { get; set; }

            public int ID { get; set; }

            public int TaiLieuID { get; set; }

            public Vlu_DeCuongMonHoc Vlu_DeCuongMonHoc { get; set; }

            public Vlu_TaiLieuMH Vlu_TaiLieuMH { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_DeCuongMonHocMetadata as the class
    // that carries additional metadata for the Vlu_DeCuongMonHoc class.
    [MetadataTypeAttribute(typeof(Vlu_DeCuongMonHoc.Vlu_DeCuongMonHocMetadata))]
    public partial class Vlu_DeCuongMonHoc
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_DeCuongMonHoc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_DeCuongMonHocMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_DeCuongMonHocMetadata()
            {
            }

            public bool Duyet { get; set; }

            public int HocKy { get; set; }

            public int ID { get; set; }

            public int MonHocID { get; set; }

            public int NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public EntityCollection<Vlu_DeCuongMH_TaiLieu> Vlu_DeCuongMH_TaiLieu { get; set; }

            public EntityCollection<Vlu_DeCuongMonHoc_ChiTiet> Vlu_DeCuongMonHoc_ChiTiet { get; set; }

            public Vlu_MonHoc Vlu_MonHoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_DeCuongMonHoc_ChiTietMetadata as the class
    // that carries additional metadata for the Vlu_DeCuongMonHoc_ChiTiet class.
    [MetadataTypeAttribute(typeof(Vlu_DeCuongMonHoc_ChiTiet.Vlu_DeCuongMonHoc_ChiTietMetadata))]
    public partial class Vlu_DeCuongMonHoc_ChiTiet
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_DeCuongMonHoc_ChiTiet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_DeCuongMonHoc_ChiTietMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_DeCuongMonHoc_ChiTietMetadata()
            {
            }

            public int Chuong { get; set; }

            public int DeCuongID { get; set; }

            public string GhiChu { get; set; }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public string TieuDe { get; set; }

            public Vlu_DeCuongMonHoc Vlu_DeCuongMonHoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_DemMetadata as the class
    // that carries additional metadata for the Vlu_Dem class.
    [MetadataTypeAttribute(typeof(Vlu_Dem.Vlu_DemMetadata))]
    public partial class Vlu_Dem
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_Dem class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_DemMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_DemMetadata()
            {
            }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public Nullable<DateTime> NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int ParentID { get; set; }

            public string TenGoi { get; set; }

            public EntityCollection<Vlu_DemChiTiet> Vlu_DemChiTiet { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_DemChiTietMetadata as the class
    // that carries additional metadata for the Vlu_DemChiTiet class.
    [MetadataTypeAttribute(typeof(Vlu_DemChiTiet.Vlu_DemChiTietMetadata))]
    public partial class Vlu_DemChiTiet
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_DemChiTiet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_DemChiTietMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_DemChiTietMetadata()
            {
            }

            public int Dem { get; set; }

            public int DemID { get; set; }

            public int ID { get; set; }

            public DateTime Ngay { get; set; }

            public Vlu_Dem Vlu_Dem { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_DiemMetadata as the class
    // that carries additional metadata for the Vlu_Diem class.
    [MetadataTypeAttribute(typeof(Vlu_Diem.Vlu_DiemMetadata))]
    public partial class Vlu_Diem
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_Diem class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_DiemMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_DiemMetadata()
            {
            }

            public string Diem { get; set; }

            public string Diem1 { get; set; }

            public string Diem2 { get; set; }

            public string DiemBT { get; set; }

            public string DiemTL { get; set; }

            public string DVHT { get; set; }

            public int HocKy { get; set; }

            public int ID { get; set; }

            public int LopID { get; set; }

            public int MonHocID { get; set; }

            public int NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public int SinhVienID { get; set; }

            public Vlu_LopHoc Vlu_LopHoc { get; set; }

            public Vlu_MonHoc Vlu_MonHoc { get; set; }

            public Vlu_SinhVien Vlu_SinhVien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_GiangVienMetadata as the class
    // that carries additional metadata for the Vlu_GiangVien class.
    [MetadataTypeAttribute(typeof(Vlu_GiangVien.Vlu_GiangVienMetadata))]
    public partial class Vlu_GiangVien
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_GiangVien class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_GiangVienMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_GiangVienMetadata()
            {
            }

            public string ChucDanh { get; set; }

            public string Ho { get; set; }

            public Nullable<int> KhoaID { get; set; }

            public string MaNhanVien { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int TaiKhoanID { get; set; }

            public string Ten { get; set; }

            public Vlu_Khoa Vlu_Khoa { get; set; }

            public EntityCollection<Vlu_LichTrinh> Vlu_LichTrinh { get; set; }

            public Vlu_TaiKhoan Vlu_TaiKhoan { get; set; }

            public EntityCollection<Vlu_TaiLieuMH> Vlu_TaiLieuMH { get; set; }

            public EntityCollection<Vlu_ThoiKhoaBieu_ChiTiet> Vlu_ThoiKhoaBieu_ChiTiet { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_GioiThieuMetadata as the class
    // that carries additional metadata for the Vlu_GioiThieu class.
    [MetadataTypeAttribute(typeof(Vlu_GioiThieu.Vlu_GioiThieuMetadata))]
    public partial class Vlu_GioiThieu
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_GioiThieu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_GioiThieuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_GioiThieuMetadata()
            {
            }

            public bool Duyet { get; set; }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public Nullable<DateTime> NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public int SapXep { get; set; }

            public int TabID { get; set; }

            public string TieuDe { get; set; }

            public Vlu_GioiThieu_Tabs Vlu_GioiThieu_Tabs { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_GioiThieu_TabsMetadata as the class
    // that carries additional metadata for the Vlu_GioiThieu_Tabs class.
    [MetadataTypeAttribute(typeof(Vlu_GioiThieu_Tabs.Vlu_GioiThieu_TabsMetadata))]
    public partial class Vlu_GioiThieu_Tabs
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_GioiThieu_Tabs class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_GioiThieu_TabsMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_GioiThieu_TabsMetadata()
            {
            }

            public int PortalID { get; set; }

            public int TabID { get; set; }

            public string TabName { get; set; }

            public EntityCollection<Vlu_GioiThieu> Vlu_GioiThieu { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_KhoaMetadata as the class
    // that carries additional metadata for the Vlu_Khoa class.
    [MetadataTypeAttribute(typeof(Vlu_Khoa.Vlu_KhoaMetadata))]
    public partial class Vlu_Khoa
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_Khoa class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_KhoaMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_KhoaMetadata()
            {
            }

            public int KhoaID { get; set; }

            public int Loai { get; set; }

            public string MaKhoa { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Nullable<int> ParentID { get; set; }

            public int SapXep { get; set; }

            public string TenKhoa { get; set; }

            public EntityCollection<Vlu_ChuongTrinhDT> Vlu_ChuongTrinhDT { get; set; }

            public EntityCollection<Vlu_GiangVien> Vlu_GiangVien { get; set; }

            public EntityCollection<Vlu_Khoa_ChiTiet> Vlu_Khoa_ChiTiet { get; set; }

            public EntityCollection<Vlu_Khoa> Vlu_KhoaChilds { get; set; }

            public Vlu_Khoa Vlu_KhoaParent { get; set; }

            public EntityCollection<Vlu_LopHoc> Vlu_LopHoc { get; set; }

            public EntityCollection<Vlu_SinhVien> Vlu_SinhVien { get; set; }

            public EntityCollection<Vlu_ThoiKhoaBieu> Vlu_ThoiKhoaBieu { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_Khoa_ChiTietMetadata as the class
    // that carries additional metadata for the Vlu_Khoa_ChiTiet class.
    [MetadataTypeAttribute(typeof(Vlu_Khoa_ChiTiet.Vlu_Khoa_ChiTietMetadata))]
    public partial class Vlu_Khoa_ChiTiet
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_Khoa_ChiTiet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_Khoa_ChiTietMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_Khoa_ChiTietMetadata()
            {
            }

            public bool Duyet { get; set; }

            public int ID { get; set; }

            public int KhoaID { get; set; }

            public int LoaiNoiDung { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public int SapXep { get; set; }

            public Vlu_Khoa Vlu_Khoa { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_LichTrinhMetadata as the class
    // that carries additional metadata for the Vlu_LichTrinh class.
    [MetadataTypeAttribute(typeof(Vlu_LichTrinh.Vlu_LichTrinhMetadata))]
    public partial class Vlu_LichTrinh
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_LichTrinh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_LichTrinhMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_LichTrinhMetadata()
            {
            }

            public bool Duyet { get; set; }

            public Nullable<int> GiangVienID { get; set; }

            public int HocKy { get; set; }

            public int ID { get; set; }

            public int MonHocID { get; set; }

            public int NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Vlu_GiangVien Vlu_GiangVien { get; set; }

            public EntityCollection<Vlu_LichTrinh_ChiTiet> Vlu_LichTrinh_ChiTiet { get; set; }

            public Vlu_MonHoc Vlu_MonHoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_LichTrinh_ChiTietMetadata as the class
    // that carries additional metadata for the Vlu_LichTrinh_ChiTiet class.
    [MetadataTypeAttribute(typeof(Vlu_LichTrinh_ChiTiet.Vlu_LichTrinh_ChiTietMetadata))]
    public partial class Vlu_LichTrinh_ChiTiet
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_LichTrinh_ChiTiet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_LichTrinh_ChiTietMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_LichTrinh_ChiTietMetadata()
            {
            }

            public Nullable<DateTime> DenNgay { get; set; }

            public int ID { get; set; }

            public int LichTrinhID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NoiDung { get; set; }

            public Nullable<int> SoTiet { get; set; }

            public int Tuan { get; set; }

            public Nullable<DateTime> TuNgay { get; set; }

            public Vlu_LichTrinh Vlu_LichTrinh { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_LinkNhanhMetadata as the class
    // that carries additional metadata for the Vlu_LinkNhanh class.
    [MetadataTypeAttribute(typeof(Vlu_LinkNhanh.Vlu_LinkNhanhMetadata))]
    public partial class Vlu_LinkNhanh
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_LinkNhanh class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_LinkNhanhMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_LinkNhanhMetadata()
            {
            }

            public string DuongDan { get; set; }

            public int LinkNhanhID { get; set; }

            public int LoaiLink { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int SapXep { get; set; }

            public int Server { get; set; }

            public string TieuDe { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_LoaiTaiLieuMHMetadata as the class
    // that carries additional metadata for the Vlu_LoaiTaiLieuMH class.
    [MetadataTypeAttribute(typeof(Vlu_LoaiTaiLieuMH.Vlu_LoaiTaiLieuMHMetadata))]
    public partial class Vlu_LoaiTaiLieuMH
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_LoaiTaiLieuMH class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_LoaiTaiLieuMHMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_LoaiTaiLieuMHMetadata()
            {
            }

            public string DuongDan { get; set; }

            public bool Duyet { get; set; }

            public int LoaiID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int SapXep { get; set; }

            public string TenLoai { get; set; }

            public EntityCollection<Vlu_TaiLieuMH> Vlu_TaiLieuMH { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_LopHocMetadata as the class
    // that carries additional metadata for the Vlu_LopHoc class.
    [MetadataTypeAttribute(typeof(Vlu_LopHoc.Vlu_LopHocMetadata))]
    public partial class Vlu_LopHoc
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_LopHoc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_LopHocMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_LopHocMetadata()
            {
            }

            public bool HienThi { get; set; }

            public Nullable<int> KhoaID { get; set; }

            public int LopID { get; set; }

            public string MaLop { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Nullable<int> ParentID { get; set; }

            public string TenLop { get; set; }

            public EntityCollection<Vlu_ChuongTrinhDT> Vlu_ChuongTrinhDT { get; set; }

            public EntityCollection<Vlu_Diem> Vlu_Diem { get; set; }

            public Vlu_Khoa Vlu_Khoa { get; set; }

            public EntityCollection<Vlu_LopHoc> Vlu_LopHocChilds { get; set; }

            public Vlu_LopHoc Vlu_LopHocParent { get; set; }

            public EntityCollection<Vlu_ThoiKhoaBieu> Vlu_ThoiKhoaBieu { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_MenuTraiMetadata as the class
    // that carries additional metadata for the Vlu_MenuTrai class.
    [MetadataTypeAttribute(typeof(Vlu_MenuTrai.Vlu_MenuTraiMetadata))]
    public partial class Vlu_MenuTrai
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_MenuTrai class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_MenuTraiMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_MenuTraiMetadata()
            {
            }

            public string DuongDan { get; set; }

            public bool Duyet { get; set; }

            public string Hinh { get; set; }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NhomAdmin { get; set; }

            public int ParentID { get; set; }

            public int PortalID { get; set; }

            public int SapXep { get; set; }

            public string Ten { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_MonHocMetadata as the class
    // that carries additional metadata for the Vlu_MonHoc class.
    [MetadataTypeAttribute(typeof(Vlu_MonHoc.Vlu_MonHocMetadata))]
    public partial class Vlu_MonHoc
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_MonHoc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_MonHocMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_MonHocMetadata()
            {
            }

            public string BT { get; set; }

            public string BTL { get; set; }

            public string DA { get; set; }

            public bool Duyet { get; set; }

            public string DVHT { get; set; }

            public string LA { get; set; }

            public string LT { get; set; }

            public string MaMonHoc { get; set; }

            public int MonHocID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public string TenMonHoc { get; set; }

            public string TH { get; set; }

            public int ThuocNhom { get; set; }

            public int TinhTrang { get; set; }

            public string TS { get; set; }

            public EntityCollection<Vlu_ChuongTrinhDT> Vlu_ChuongTrinhDT { get; set; }

            public EntityCollection<Vlu_DeCuongMonHoc> Vlu_DeCuongMonHoc { get; set; }

            public EntityCollection<Vlu_Diem> Vlu_Diem { get; set; }

            public EntityCollection<Vlu_LichTrinh> Vlu_LichTrinh { get; set; }

            public EntityCollection<Vlu_TaiLieuMH> Vlu_TaiLieuMH { get; set; }

            public EntityCollection<Vlu_ThoiKhoaBieu_ChiTiet> Vlu_ThoiKhoaBieu_ChiTiet { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_PhongHocMetadata as the class
    // that carries additional metadata for the Vlu_PhongHoc class.
    [MetadataTypeAttribute(typeof(Vlu_PhongHoc.Vlu_PhongHocMetadata))]
    public partial class Vlu_PhongHoc
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_PhongHoc class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_PhongHocMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_PhongHocMetadata()
            {
            }

            public int CoSo { get; set; }

            public string MaPhong { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int PhongID { get; set; }

            public string TenPhong { get; set; }

            public EntityCollection<Vlu_ThoiKhoaBieu_ChiTiet> Vlu_ThoiKhoaBieu_ChiTiet { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_PopupMetadata as the class
    // that carries additional metadata for the Vlu_Popup class.
    [MetadataTypeAttribute(typeof(Vlu_Popup.Vlu_PopupMetadata))]
    public partial class Vlu_Popup
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_Popup class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_PopupMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_PopupMetadata()
            {
            }

            public DateTime DenNgay { get; set; }

            public bool Duyet { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public int PopupID { get; set; }

            public int PortalID { get; set; }

            public string TieuDe { get; set; }

            public DateTime TuNgay { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_SinhVienMetadata as the class
    // that carries additional metadata for the Vlu_SinhVien class.
    [MetadataTypeAttribute(typeof(Vlu_SinhVien.Vlu_SinhVienMetadata))]
    public partial class Vlu_SinhVien
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_SinhVien class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_SinhVienMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_SinhVienMetadata()
            {
            }

            public string Ho { get; set; }

            public Nullable<int> KhoaID { get; set; }

            public int LopID { get; set; }

            public string MaSinhVien { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int TaiKhoanID { get; set; }

            public string Ten { get; set; }

            public EntityCollection<Vlu_Diem> Vlu_Diem { get; set; }

            public Vlu_Khoa Vlu_Khoa { get; set; }

            public Vlu_TaiKhoan Vlu_TaiKhoan { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_SlideShowMetadata as the class
    // that carries additional metadata for the Vlu_SlideShow class.
    [MetadataTypeAttribute(typeof(Vlu_SlideShow.Vlu_SlideShowMetadata))]
    public partial class Vlu_SlideShow
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_SlideShow class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_SlideShowMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_SlideShowMetadata()
            {
            }

            public string DuongDan { get; set; }

            public bool Duyet { get; set; }

            public string Hinh { get; set; }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayNhap { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiNhap { get; set; }

            public int PortalID { get; set; }

            public int SapXep { get; set; }

            public string TieuDe { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_SuKienMetadata as the class
    // that carries additional metadata for the Vlu_SuKien class.
    [MetadataTypeAttribute(typeof(Vlu_SuKien.Vlu_SuKienMetadata))]
    public partial class Vlu_SuKien
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_SuKien class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_SuKienMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_SuKienMetadata()
            {
            }

            public bool DaXoa { get; set; }

            public DateTime DenNgay { get; set; }

            public string DuongDan { get; set; }

            public bool Duyet { get; set; }

            public bool HienThi { get; set; }

            public int ID { get; set; }

            public bool Internet { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiGiu { get; set; }

            public string NguoiNhan { get; set; }

            public string NguoiTao { get; set; }

            public string NoiDung { get; set; }

            public int PortalID { get; set; }

            public int SapXep { get; set; }

            public DateTime ThoiGian { get; set; }

            public DateTime TuNgay { get; set; }

            public EntityCollection<Vlu_SuKien_PhienBan> Vlu_SuKien_PhienBan { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_SuKien_PhanQuyenMetadata as the class
    // that carries additional metadata for the Vlu_SuKien_PhanQuyen class.
    [MetadataTypeAttribute(typeof(Vlu_SuKien_PhanQuyen.Vlu_SuKien_PhanQuyenMetadata))]
    public partial class Vlu_SuKien_PhanQuyen
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_SuKien_PhanQuyen class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_SuKien_PhanQuyenMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_SuKien_PhanQuyenMetadata()
            {
            }

            public int ID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiBaoCao { get; set; }

            public string NguoiTao { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_SuKien_PhienBanMetadata as the class
    // that carries additional metadata for the Vlu_SuKien_PhienBan class.
    [MetadataTypeAttribute(typeof(Vlu_SuKien_PhienBan.Vlu_SuKien_PhienBanMetadata))]
    public partial class Vlu_SuKien_PhienBan
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_SuKien_PhienBan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_SuKien_PhienBanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_SuKien_PhienBanMetadata()
            {
            }

            public DateTime DenNgay { get; set; }

            public int ID { get; set; }

            public string NguoiTao { get; set; }

            public string Noidung { get; set; }

            public int PhienBan { get; set; }

            public int SuKienID { get; set; }

            public DateTime ThoiGian { get; set; }

            public DateTime TuNgay { get; set; }

            public Vlu_SuKien Vlu_SuKien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_TaiKhoanMetadata as the class
    // that carries additional metadata for the Vlu_TaiKhoan class.
    [MetadataTypeAttribute(typeof(Vlu_TaiKhoan.Vlu_TaiKhoanMetadata))]
    public partial class Vlu_TaiKhoan
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_TaiKhoan class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_TaiKhoanMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_TaiKhoanMetadata()
            {
            }

            public string Email { get; set; }

            public string Ho { get; set; }

            public int LoaiTaiKhoan { get; set; }

            public string MatKhau { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public string NgaySinh { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int TaiKhoanID { get; set; }

            public string Ten { get; set; }

            public string TenDangNhap { get; set; }

            public Vlu_GiangVien Vlu_GiangVien { get; set; }

            public Vlu_SinhVien Vlu_SinhVien { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_TaiLieuMHMetadata as the class
    // that carries additional metadata for the Vlu_TaiLieuMH class.
    [MetadataTypeAttribute(typeof(Vlu_TaiLieuMH.Vlu_TaiLieuMHMetadata))]
    public partial class Vlu_TaiLieuMH
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_TaiLieuMH class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_TaiLieuMHMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_TaiLieuMHMetadata()
            {
            }

            public string DuongDan1 { get; set; }

            public string DuongDan2 { get; set; }

            public bool Duyet { get; set; }

            public string GhiChu { get; set; }

            public Nullable<int> GiangVienID { get; set; }

            public int HocKy { get; set; }

            public int LoaiDuongDan { get; set; }

            public int LoaiID { get; set; }

            public int MonHocID { get; set; }

            public int NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public int SapXep { get; set; }

            public int TaiLieuID { get; set; }

            public string TenLop { get; set; }

            public string TenTaiLieu { get; set; }

            public EntityCollection<Vlu_DeCuongMH_TaiLieu> Vlu_DeCuongMH_TaiLieu { get; set; }

            public Vlu_GiangVien Vlu_GiangVien { get; set; }

            public Vlu_LoaiTaiLieuMH Vlu_LoaiTaiLieuMH { get; set; }

            public Vlu_MonHoc Vlu_MonHoc { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_TaiLieuMH_TempMetadata as the class
    // that carries additional metadata for the Vlu_TaiLieuMH_Temp class.
    [MetadataTypeAttribute(typeof(Vlu_TaiLieuMH_Temp.Vlu_TaiLieuMH_TempMetadata))]
    public partial class Vlu_TaiLieuMH_Temp
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_TaiLieuMH_Temp class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_TaiLieuMH_TempMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_TaiLieuMH_TempMetadata()
            {
            }

            public string DuongDan1 { get; set; }

            public string DuongDan2 { get; set; }

            public Nullable<bool> Duyet { get; set; }

            public string GhiChu { get; set; }

            public string GiangVien { get; set; }

            public Nullable<int> HocKy { get; set; }

            public string KhoaHoc { get; set; }

            public Nullable<int> Loai { get; set; }

            public Nullable<int> MaLoaiTL { get; set; }

            public string MaMH { get; set; }

            public string NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public Nullable<DateTime> NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Nullable<int> SapXep { get; set; }

            public int TaiLieuID { get; set; }

            public string TenTaiLieu { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ThoiKhoaBieuMetadata as the class
    // that carries additional metadata for the Vlu_ThoiKhoaBieu class.
    [MetadataTypeAttribute(typeof(Vlu_ThoiKhoaBieu.Vlu_ThoiKhoaBieuMetadata))]
    public partial class Vlu_ThoiKhoaBieu
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ThoiKhoaBieu class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ThoiKhoaBieuMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ThoiKhoaBieuMetadata()
            {
            }

            public bool Duyet { get; set; }

            public string GhiChu { get; set; }

            public int HocKy { get; set; }

            public int ID { get; set; }

            public int KhoaID { get; set; }

            public int Loai { get; set; }

            public int LopID { get; set; }

            public int NamHoc { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Vlu_Khoa Vlu_Khoa { get; set; }

            public Vlu_LopHoc Vlu_LopHoc { get; set; }

            public EntityCollection<Vlu_ThoiKhoaBieu_ChiTiet> Vlu_ThoiKhoaBieu_ChiTiet { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ThoiKhoaBieu_ChiTietMetadata as the class
    // that carries additional metadata for the Vlu_ThoiKhoaBieu_ChiTiet class.
    [MetadataTypeAttribute(typeof(Vlu_ThoiKhoaBieu_ChiTiet.Vlu_ThoiKhoaBieu_ChiTietMetadata))]
    public partial class Vlu_ThoiKhoaBieu_ChiTiet
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ThoiKhoaBieu_ChiTiet class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ThoiKhoaBieu_ChiTietMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ThoiKhoaBieu_ChiTietMetadata()
            {
            }

            public Nullable<DateTime> DenThoiGian { get; set; }

            public Nullable<int> DenTiet { get; set; }

            public string GhiChu { get; set; }

            public Nullable<int> GiangVienID { get; set; }

            public int ID { get; set; }

            public int MonHocID { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public DateTime NgayTao { get; set; }

            public string NguoiCapNhat { get; set; }

            public string NguoiTao { get; set; }

            public Nullable<int> PhongID { get; set; }

            public string TenLop { get; set; }

            public int ThoiKhoaBieuID { get; set; }

            public Nullable<int> Thu { get; set; }

            public Nullable<DateTime> TuThoiGian { get; set; }

            public Nullable<int> TuTiet { get; set; }

            public Vlu_GiangVien Vlu_GiangVien { get; set; }

            public Vlu_MonHoc Vlu_MonHoc { get; set; }

            public Vlu_PhongHoc Vlu_PhongHoc { get; set; }

            public Vlu_ThoiKhoaBieu Vlu_ThoiKhoaBieu { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies Vlu_ThongTinDTMetadata as the class
    // that carries additional metadata for the Vlu_ThongTinDT class.
    [MetadataTypeAttribute(typeof(Vlu_ThongTinDT.Vlu_ThongTinDTMetadata))]
    public partial class Vlu_ThongTinDT
    {

        // This class allows you to attach custom attributes to properties
        // of the Vlu_ThongTinDT class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class Vlu_ThongTinDTMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private Vlu_ThongTinDTMetadata()
            {
            }

            public string DuongDan { get; set; }

            public bool Duyet { get; set; }

            public int ID { get; set; }

            public bool Internet { get; set; }

            public int Loai { get; set; }

            public Nullable<DateTime> NgayCapNhat { get; set; }

            public string NguoiCapNhat { get; set; }

            public int SapXep { get; set; }

            public string ThuMuc { get; set; }

            public string TieuDe { get; set; }
        }
    }
}


namespace WebManagement.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the Portal_VanLangEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class VanLangService : LinqToEntitiesDomainService<Portal_VanLangEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_CamNhan' query.
        public IQueryable<Vlu_CamNhan> GetVlu_CamNhan()
        {
            return this.ObjectContext.Vlu_CamNhan;
        }

        public void InsertVlu_CamNhan(Vlu_CamNhan vlu_CamNhan)
        {
            if ((vlu_CamNhan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_CamNhan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_CamNhan.AddObject(vlu_CamNhan);
            }
        }

        public void UpdateVlu_CamNhan(Vlu_CamNhan currentVlu_CamNhan)
        {
            this.ObjectContext.Vlu_CamNhan.AttachAsModified(currentVlu_CamNhan, this.ChangeSet.GetOriginal(currentVlu_CamNhan));
        }

        public void DeleteVlu_CamNhan(Vlu_CamNhan vlu_CamNhan)
        {
            if ((vlu_CamNhan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_CamNhan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_CamNhan.Attach(vlu_CamNhan);
                this.ObjectContext.Vlu_CamNhan.DeleteObject(vlu_CamNhan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_CamNhanNhom' query.
        public IQueryable<Vlu_CamNhanNhom> GetVlu_CamNhanNhom()
        {
            return this.ObjectContext.Vlu_CamNhanNhom;
        }

        public void InsertVlu_CamNhanNhom(Vlu_CamNhanNhom vlu_CamNhanNhom)
        {
            if ((vlu_CamNhanNhom.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_CamNhanNhom, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_CamNhanNhom.AddObject(vlu_CamNhanNhom);
            }
        }

        public void UpdateVlu_CamNhanNhom(Vlu_CamNhanNhom currentVlu_CamNhanNhom)
        {
            this.ObjectContext.Vlu_CamNhanNhom.AttachAsModified(currentVlu_CamNhanNhom, this.ChangeSet.GetOriginal(currentVlu_CamNhanNhom));
        }

        public void DeleteVlu_CamNhanNhom(Vlu_CamNhanNhom vlu_CamNhanNhom)
        {
            if ((vlu_CamNhanNhom.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_CamNhanNhom, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_CamNhanNhom.Attach(vlu_CamNhanNhom);
                this.ObjectContext.Vlu_CamNhanNhom.DeleteObject(vlu_CamNhanNhom);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuongTrinhDT' query.
        public IQueryable<Vlu_ChuongTrinhDT> GetVlu_ChuongTrinhDT()
        {
            return this.ObjectContext.Vlu_ChuongTrinhDT;
        }

        public void InsertVlu_ChuongTrinhDT(Vlu_ChuongTrinhDT vlu_ChuongTrinhDT)
        {
            if ((vlu_ChuongTrinhDT.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuongTrinhDT, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuongTrinhDT.AddObject(vlu_ChuongTrinhDT);
            }
        }

        public void UpdateVlu_ChuongTrinhDT(Vlu_ChuongTrinhDT currentVlu_ChuongTrinhDT)
        {
            this.ObjectContext.Vlu_ChuongTrinhDT.AttachAsModified(currentVlu_ChuongTrinhDT, this.ChangeSet.GetOriginal(currentVlu_ChuongTrinhDT));
        }

        public void DeleteVlu_ChuongTrinhDT(Vlu_ChuongTrinhDT vlu_ChuongTrinhDT)
        {
            if ((vlu_ChuongTrinhDT.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuongTrinhDT, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuongTrinhDT.Attach(vlu_ChuongTrinhDT);
                this.ObjectContext.Vlu_ChuongTrinhDT.DeleteObject(vlu_ChuongTrinhDT);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuyenMuc' query.
        public IQueryable<Vlu_ChuyenMuc> GetVlu_ChuyenMuc()
        {
            return this.ObjectContext.Vlu_ChuyenMuc;
        }

        public void InsertVlu_ChuyenMuc(Vlu_ChuyenMuc vlu_ChuyenMuc)
        {
            if ((vlu_ChuyenMuc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMuc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMuc.AddObject(vlu_ChuyenMuc);
            }
        }

        public void UpdateVlu_ChuyenMuc(Vlu_ChuyenMuc currentVlu_ChuyenMuc)
        {
            this.ObjectContext.Vlu_ChuyenMuc.AttachAsModified(currentVlu_ChuyenMuc, this.ChangeSet.GetOriginal(currentVlu_ChuyenMuc));
        }

        public void DeleteVlu_ChuyenMuc(Vlu_ChuyenMuc vlu_ChuyenMuc)
        {
            if ((vlu_ChuyenMuc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMuc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMuc.Attach(vlu_ChuyenMuc);
                this.ObjectContext.Vlu_ChuyenMuc.DeleteObject(vlu_ChuyenMuc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuyenMucNoiDung' query.
        public IQueryable<Vlu_ChuyenMucNoiDung> GetVlu_ChuyenMucNoiDung()
        {
            return this.ObjectContext.Vlu_ChuyenMucNoiDung;
        }

        public void InsertVlu_ChuyenMucNoiDung(Vlu_ChuyenMucNoiDung vlu_ChuyenMucNoiDung)
        {
            if ((vlu_ChuyenMucNoiDung.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucNoiDung, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucNoiDung.AddObject(vlu_ChuyenMucNoiDung);
            }
        }

        public void UpdateVlu_ChuyenMucNoiDung(Vlu_ChuyenMucNoiDung currentVlu_ChuyenMucNoiDung)
        {
            this.ObjectContext.Vlu_ChuyenMucNoiDung.AttachAsModified(currentVlu_ChuyenMucNoiDung, this.ChangeSet.GetOriginal(currentVlu_ChuyenMucNoiDung));
        }

        public void DeleteVlu_ChuyenMucNoiDung(Vlu_ChuyenMucNoiDung vlu_ChuyenMucNoiDung)
        {
            if ((vlu_ChuyenMucNoiDung.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucNoiDung, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucNoiDung.Attach(vlu_ChuyenMucNoiDung);
                this.ObjectContext.Vlu_ChuyenMucNoiDung.DeleteObject(vlu_ChuyenMucNoiDung);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuyenMucPhanQuyen' query.
        public IQueryable<Vlu_ChuyenMucPhanQuyen> GetVlu_ChuyenMucPhanQuyen()
        {
            return this.ObjectContext.Vlu_ChuyenMucPhanQuyen;
        }

        public void InsertVlu_ChuyenMucPhanQuyen(Vlu_ChuyenMucPhanQuyen vlu_ChuyenMucPhanQuyen)
        {
            if ((vlu_ChuyenMucPhanQuyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucPhanQuyen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucPhanQuyen.AddObject(vlu_ChuyenMucPhanQuyen);
            }
        }

        public void UpdateVlu_ChuyenMucPhanQuyen(Vlu_ChuyenMucPhanQuyen currentVlu_ChuyenMucPhanQuyen)
        {
            this.ObjectContext.Vlu_ChuyenMucPhanQuyen.AttachAsModified(currentVlu_ChuyenMucPhanQuyen, this.ChangeSet.GetOriginal(currentVlu_ChuyenMucPhanQuyen));
        }

        public void DeleteVlu_ChuyenMucPhanQuyen(Vlu_ChuyenMucPhanQuyen vlu_ChuyenMucPhanQuyen)
        {
            if ((vlu_ChuyenMucPhanQuyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucPhanQuyen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucPhanQuyen.Attach(vlu_ChuyenMucPhanQuyen);
                this.ObjectContext.Vlu_ChuyenMucPhanQuyen.DeleteObject(vlu_ChuyenMucPhanQuyen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuyenMucPhienBan' query.
        public IQueryable<Vlu_ChuyenMucPhienBan> GetVlu_ChuyenMucPhienBan()
        {
            return this.ObjectContext.Vlu_ChuyenMucPhienBan;
        }

        public void InsertVlu_ChuyenMucPhienBan(Vlu_ChuyenMucPhienBan vlu_ChuyenMucPhienBan)
        {
            if ((vlu_ChuyenMucPhienBan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucPhienBan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucPhienBan.AddObject(vlu_ChuyenMucPhienBan);
            }
        }

        public void UpdateVlu_ChuyenMucPhienBan(Vlu_ChuyenMucPhienBan currentVlu_ChuyenMucPhienBan)
        {
            this.ObjectContext.Vlu_ChuyenMucPhienBan.AttachAsModified(currentVlu_ChuyenMucPhienBan, this.ChangeSet.GetOriginal(currentVlu_ChuyenMucPhienBan));
        }

        public void DeleteVlu_ChuyenMucPhienBan(Vlu_ChuyenMucPhienBan vlu_ChuyenMucPhienBan)
        {
            if ((vlu_ChuyenMucPhienBan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucPhienBan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucPhienBan.Attach(vlu_ChuyenMucPhienBan);
                this.ObjectContext.Vlu_ChuyenMucPhienBan.DeleteObject(vlu_ChuyenMucPhienBan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuyenMucTinLienQuan' query.
        public IQueryable<Vlu_ChuyenMucTinLienQuan> GetVlu_ChuyenMucTinLienQuan()
        {
            return this.ObjectContext.Vlu_ChuyenMucTinLienQuan;
        }

        public void InsertVlu_ChuyenMucTinLienQuan(Vlu_ChuyenMucTinLienQuan vlu_ChuyenMucTinLienQuan)
        {
            if ((vlu_ChuyenMucTinLienQuan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucTinLienQuan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucTinLienQuan.AddObject(vlu_ChuyenMucTinLienQuan);
            }
        }

        public void UpdateVlu_ChuyenMucTinLienQuan(Vlu_ChuyenMucTinLienQuan currentVlu_ChuyenMucTinLienQuan)
        {
            this.ObjectContext.Vlu_ChuyenMucTinLienQuan.AttachAsModified(currentVlu_ChuyenMucTinLienQuan, this.ChangeSet.GetOriginal(currentVlu_ChuyenMucTinLienQuan));
        }

        public void DeleteVlu_ChuyenMucTinLienQuan(Vlu_ChuyenMucTinLienQuan vlu_ChuyenMucTinLienQuan)
        {
            if ((vlu_ChuyenMucTinLienQuan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucTinLienQuan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucTinLienQuan.Attach(vlu_ChuyenMucTinLienQuan);
                this.ObjectContext.Vlu_ChuyenMucTinLienQuan.DeleteObject(vlu_ChuyenMucTinLienQuan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ChuyenMucTrongNoiDung' query.
        public IQueryable<Vlu_ChuyenMucTrongNoiDung> GetVlu_ChuyenMucTrongNoiDung()
        {
            return this.ObjectContext.Vlu_ChuyenMucTrongNoiDung;
        }

        public void InsertVlu_ChuyenMucTrongNoiDung(Vlu_ChuyenMucTrongNoiDung vlu_ChuyenMucTrongNoiDung)
        {
            if ((vlu_ChuyenMucTrongNoiDung.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucTrongNoiDung, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucTrongNoiDung.AddObject(vlu_ChuyenMucTrongNoiDung);
            }
        }

        public void UpdateVlu_ChuyenMucTrongNoiDung(Vlu_ChuyenMucTrongNoiDung currentVlu_ChuyenMucTrongNoiDung)
        {
            this.ObjectContext.Vlu_ChuyenMucTrongNoiDung.AttachAsModified(currentVlu_ChuyenMucTrongNoiDung, this.ChangeSet.GetOriginal(currentVlu_ChuyenMucTrongNoiDung));
        }

        public void DeleteVlu_ChuyenMucTrongNoiDung(Vlu_ChuyenMucTrongNoiDung vlu_ChuyenMucTrongNoiDung)
        {
            if ((vlu_ChuyenMucTrongNoiDung.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ChuyenMucTrongNoiDung, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ChuyenMucTrongNoiDung.Attach(vlu_ChuyenMucTrongNoiDung);
                this.ObjectContext.Vlu_ChuyenMucTrongNoiDung.DeleteObject(vlu_ChuyenMucTrongNoiDung);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_DeCuongMH_TaiLieu' query.
        public IQueryable<Vlu_DeCuongMH_TaiLieu> GetVlu_DeCuongMH_TaiLieu()
        {
            return this.ObjectContext.Vlu_DeCuongMH_TaiLieu;
        }

        public void InsertVlu_DeCuongMH_TaiLieu(Vlu_DeCuongMH_TaiLieu vlu_DeCuongMH_TaiLieu)
        {
            if ((vlu_DeCuongMH_TaiLieu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DeCuongMH_TaiLieu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_DeCuongMH_TaiLieu.AddObject(vlu_DeCuongMH_TaiLieu);
            }
        }

        public void UpdateVlu_DeCuongMH_TaiLieu(Vlu_DeCuongMH_TaiLieu currentVlu_DeCuongMH_TaiLieu)
        {
            this.ObjectContext.Vlu_DeCuongMH_TaiLieu.AttachAsModified(currentVlu_DeCuongMH_TaiLieu, this.ChangeSet.GetOriginal(currentVlu_DeCuongMH_TaiLieu));
        }

        public void DeleteVlu_DeCuongMH_TaiLieu(Vlu_DeCuongMH_TaiLieu vlu_DeCuongMH_TaiLieu)
        {
            if ((vlu_DeCuongMH_TaiLieu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DeCuongMH_TaiLieu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_DeCuongMH_TaiLieu.Attach(vlu_DeCuongMH_TaiLieu);
                this.ObjectContext.Vlu_DeCuongMH_TaiLieu.DeleteObject(vlu_DeCuongMH_TaiLieu);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_DeCuongMonHoc' query.
        public IQueryable<Vlu_DeCuongMonHoc> GetVlu_DeCuongMonHoc()
        {
            return this.ObjectContext.Vlu_DeCuongMonHoc;
        }

        public void InsertVlu_DeCuongMonHoc(Vlu_DeCuongMonHoc vlu_DeCuongMonHoc)
        {
            if ((vlu_DeCuongMonHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DeCuongMonHoc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_DeCuongMonHoc.AddObject(vlu_DeCuongMonHoc);
            }
        }

        public void UpdateVlu_DeCuongMonHoc(Vlu_DeCuongMonHoc currentVlu_DeCuongMonHoc)
        {
            this.ObjectContext.Vlu_DeCuongMonHoc.AttachAsModified(currentVlu_DeCuongMonHoc, this.ChangeSet.GetOriginal(currentVlu_DeCuongMonHoc));
        }

        public void DeleteVlu_DeCuongMonHoc(Vlu_DeCuongMonHoc vlu_DeCuongMonHoc)
        {
            if ((vlu_DeCuongMonHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DeCuongMonHoc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_DeCuongMonHoc.Attach(vlu_DeCuongMonHoc);
                this.ObjectContext.Vlu_DeCuongMonHoc.DeleteObject(vlu_DeCuongMonHoc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_DeCuongMonHoc_ChiTiet' query.
        public IQueryable<Vlu_DeCuongMonHoc_ChiTiet> GetVlu_DeCuongMonHoc_ChiTiet()
        {
            return this.ObjectContext.Vlu_DeCuongMonHoc_ChiTiet;
        }

        public void InsertVlu_DeCuongMonHoc_ChiTiet(Vlu_DeCuongMonHoc_ChiTiet vlu_DeCuongMonHoc_ChiTiet)
        {
            if ((vlu_DeCuongMonHoc_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DeCuongMonHoc_ChiTiet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_DeCuongMonHoc_ChiTiet.AddObject(vlu_DeCuongMonHoc_ChiTiet);
            }
        }

        public void UpdateVlu_DeCuongMonHoc_ChiTiet(Vlu_DeCuongMonHoc_ChiTiet currentVlu_DeCuongMonHoc_ChiTiet)
        {
            this.ObjectContext.Vlu_DeCuongMonHoc_ChiTiet.AttachAsModified(currentVlu_DeCuongMonHoc_ChiTiet, this.ChangeSet.GetOriginal(currentVlu_DeCuongMonHoc_ChiTiet));
        }

        public void DeleteVlu_DeCuongMonHoc_ChiTiet(Vlu_DeCuongMonHoc_ChiTiet vlu_DeCuongMonHoc_ChiTiet)
        {
            if ((vlu_DeCuongMonHoc_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DeCuongMonHoc_ChiTiet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_DeCuongMonHoc_ChiTiet.Attach(vlu_DeCuongMonHoc_ChiTiet);
                this.ObjectContext.Vlu_DeCuongMonHoc_ChiTiet.DeleteObject(vlu_DeCuongMonHoc_ChiTiet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_Dem' query.
        public IQueryable<Vlu_Dem> GetVlu_Dem()
        {
            return this.ObjectContext.Vlu_Dem;
        }

        public void InsertVlu_Dem(Vlu_Dem vlu_Dem)
        {
            if ((vlu_Dem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Dem, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_Dem.AddObject(vlu_Dem);
            }
        }

        public void UpdateVlu_Dem(Vlu_Dem currentVlu_Dem)
        {
            this.ObjectContext.Vlu_Dem.AttachAsModified(currentVlu_Dem, this.ChangeSet.GetOriginal(currentVlu_Dem));
        }

        public void DeleteVlu_Dem(Vlu_Dem vlu_Dem)
        {
            if ((vlu_Dem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Dem, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_Dem.Attach(vlu_Dem);
                this.ObjectContext.Vlu_Dem.DeleteObject(vlu_Dem);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_DemChiTiet' query.
        public IQueryable<Vlu_DemChiTiet> GetVlu_DemChiTiet()
        {
            return this.ObjectContext.Vlu_DemChiTiet;
        }

        public void InsertVlu_DemChiTiet(Vlu_DemChiTiet vlu_DemChiTiet)
        {
            if ((vlu_DemChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DemChiTiet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_DemChiTiet.AddObject(vlu_DemChiTiet);
            }
        }

        public void UpdateVlu_DemChiTiet(Vlu_DemChiTiet currentVlu_DemChiTiet)
        {
            this.ObjectContext.Vlu_DemChiTiet.AttachAsModified(currentVlu_DemChiTiet, this.ChangeSet.GetOriginal(currentVlu_DemChiTiet));
        }

        public void DeleteVlu_DemChiTiet(Vlu_DemChiTiet vlu_DemChiTiet)
        {
            if ((vlu_DemChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_DemChiTiet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_DemChiTiet.Attach(vlu_DemChiTiet);
                this.ObjectContext.Vlu_DemChiTiet.DeleteObject(vlu_DemChiTiet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_Diem' query.
        public IQueryable<Vlu_Diem> GetVlu_Diem()
        {
            return this.ObjectContext.Vlu_Diem;
        }

        public void InsertVlu_Diem(Vlu_Diem vlu_Diem)
        {
            if ((vlu_Diem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Diem, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_Diem.AddObject(vlu_Diem);
            }
        }

        public void UpdateVlu_Diem(Vlu_Diem currentVlu_Diem)
        {
            this.ObjectContext.Vlu_Diem.AttachAsModified(currentVlu_Diem, this.ChangeSet.GetOriginal(currentVlu_Diem));
        }

        public void DeleteVlu_Diem(Vlu_Diem vlu_Diem)
        {
            if ((vlu_Diem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Diem, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_Diem.Attach(vlu_Diem);
                this.ObjectContext.Vlu_Diem.DeleteObject(vlu_Diem);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_GiangVien' query.
        public IQueryable<Vlu_GiangVien> GetVlu_GiangVien()
        {
            return this.ObjectContext.Vlu_GiangVien;
        }

        public void InsertVlu_GiangVien(Vlu_GiangVien vlu_GiangVien)
        {
            if ((vlu_GiangVien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_GiangVien, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_GiangVien.AddObject(vlu_GiangVien);
            }
        }

        public void UpdateVlu_GiangVien(Vlu_GiangVien currentVlu_GiangVien)
        {
            this.ObjectContext.Vlu_GiangVien.AttachAsModified(currentVlu_GiangVien, this.ChangeSet.GetOriginal(currentVlu_GiangVien));
        }

        public void DeleteVlu_GiangVien(Vlu_GiangVien vlu_GiangVien)
        {
            if ((vlu_GiangVien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_GiangVien, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_GiangVien.Attach(vlu_GiangVien);
                this.ObjectContext.Vlu_GiangVien.DeleteObject(vlu_GiangVien);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_GioiThieu' query.
        public IQueryable<Vlu_GioiThieu> GetVlu_GioiThieu()
        {
            return this.ObjectContext.Vlu_GioiThieu;
        }

        public void InsertVlu_GioiThieu(Vlu_GioiThieu vlu_GioiThieu)
        {
            if ((vlu_GioiThieu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_GioiThieu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_GioiThieu.AddObject(vlu_GioiThieu);
            }
        }

        public void UpdateVlu_GioiThieu(Vlu_GioiThieu currentVlu_GioiThieu)
        {
            this.ObjectContext.Vlu_GioiThieu.AttachAsModified(currentVlu_GioiThieu, this.ChangeSet.GetOriginal(currentVlu_GioiThieu));
        }

        public void DeleteVlu_GioiThieu(Vlu_GioiThieu vlu_GioiThieu)
        {
            if ((vlu_GioiThieu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_GioiThieu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_GioiThieu.Attach(vlu_GioiThieu);
                this.ObjectContext.Vlu_GioiThieu.DeleteObject(vlu_GioiThieu);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_GioiThieu_Tabs' query.
        public IQueryable<Vlu_GioiThieu_Tabs> GetVlu_GioiThieu_Tabs()
        {
            return this.ObjectContext.Vlu_GioiThieu_Tabs;
        }

        public void InsertVlu_GioiThieu_Tabs(Vlu_GioiThieu_Tabs vlu_GioiThieu_Tabs)
        {
            if ((vlu_GioiThieu_Tabs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_GioiThieu_Tabs, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_GioiThieu_Tabs.AddObject(vlu_GioiThieu_Tabs);
            }
        }

        public void UpdateVlu_GioiThieu_Tabs(Vlu_GioiThieu_Tabs currentVlu_GioiThieu_Tabs)
        {
            this.ObjectContext.Vlu_GioiThieu_Tabs.AttachAsModified(currentVlu_GioiThieu_Tabs, this.ChangeSet.GetOriginal(currentVlu_GioiThieu_Tabs));
        }

        public void DeleteVlu_GioiThieu_Tabs(Vlu_GioiThieu_Tabs vlu_GioiThieu_Tabs)
        {
            if ((vlu_GioiThieu_Tabs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_GioiThieu_Tabs, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_GioiThieu_Tabs.Attach(vlu_GioiThieu_Tabs);
                this.ObjectContext.Vlu_GioiThieu_Tabs.DeleteObject(vlu_GioiThieu_Tabs);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_Khoa' query.
        public IQueryable<Vlu_Khoa> GetVlu_Khoa()
        {
            return this.ObjectContext.Vlu_Khoa;
        }

        public void InsertVlu_Khoa(Vlu_Khoa vlu_Khoa)
        {
            if ((vlu_Khoa.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Khoa, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_Khoa.AddObject(vlu_Khoa);
            }
        }

        public void UpdateVlu_Khoa(Vlu_Khoa currentVlu_Khoa)
        {
            this.ObjectContext.Vlu_Khoa.AttachAsModified(currentVlu_Khoa, this.ChangeSet.GetOriginal(currentVlu_Khoa));
        }

        public void DeleteVlu_Khoa(Vlu_Khoa vlu_Khoa)
        {
            if ((vlu_Khoa.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Khoa, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_Khoa.Attach(vlu_Khoa);
                this.ObjectContext.Vlu_Khoa.DeleteObject(vlu_Khoa);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_Khoa_ChiTiet' query.
        public IQueryable<Vlu_Khoa_ChiTiet> GetVlu_Khoa_ChiTiet()
        {
            return this.ObjectContext.Vlu_Khoa_ChiTiet;
        }

        public void InsertVlu_Khoa_ChiTiet(Vlu_Khoa_ChiTiet vlu_Khoa_ChiTiet)
        {
            if ((vlu_Khoa_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Khoa_ChiTiet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_Khoa_ChiTiet.AddObject(vlu_Khoa_ChiTiet);
            }
        }

        public void UpdateVlu_Khoa_ChiTiet(Vlu_Khoa_ChiTiet currentVlu_Khoa_ChiTiet)
        {
            this.ObjectContext.Vlu_Khoa_ChiTiet.AttachAsModified(currentVlu_Khoa_ChiTiet, this.ChangeSet.GetOriginal(currentVlu_Khoa_ChiTiet));
        }

        public void DeleteVlu_Khoa_ChiTiet(Vlu_Khoa_ChiTiet vlu_Khoa_ChiTiet)
        {
            if ((vlu_Khoa_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Khoa_ChiTiet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_Khoa_ChiTiet.Attach(vlu_Khoa_ChiTiet);
                this.ObjectContext.Vlu_Khoa_ChiTiet.DeleteObject(vlu_Khoa_ChiTiet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_LichTrinh' query.
        public IQueryable<Vlu_LichTrinh> GetVlu_LichTrinh()
        {
            return this.ObjectContext.Vlu_LichTrinh;
        }

        public void InsertVlu_LichTrinh(Vlu_LichTrinh vlu_LichTrinh)
        {
            if ((vlu_LichTrinh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LichTrinh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_LichTrinh.AddObject(vlu_LichTrinh);
            }
        }

        public void UpdateVlu_LichTrinh(Vlu_LichTrinh currentVlu_LichTrinh)
        {
            this.ObjectContext.Vlu_LichTrinh.AttachAsModified(currentVlu_LichTrinh, this.ChangeSet.GetOriginal(currentVlu_LichTrinh));
        }

        public void DeleteVlu_LichTrinh(Vlu_LichTrinh vlu_LichTrinh)
        {
            if ((vlu_LichTrinh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LichTrinh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_LichTrinh.Attach(vlu_LichTrinh);
                this.ObjectContext.Vlu_LichTrinh.DeleteObject(vlu_LichTrinh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_LichTrinh_ChiTiet' query.
        public IQueryable<Vlu_LichTrinh_ChiTiet> GetVlu_LichTrinh_ChiTiet()
        {
            return this.ObjectContext.Vlu_LichTrinh_ChiTiet;
        }

        public void InsertVlu_LichTrinh_ChiTiet(Vlu_LichTrinh_ChiTiet vlu_LichTrinh_ChiTiet)
        {
            if ((vlu_LichTrinh_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LichTrinh_ChiTiet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_LichTrinh_ChiTiet.AddObject(vlu_LichTrinh_ChiTiet);
            }
        }

        public void UpdateVlu_LichTrinh_ChiTiet(Vlu_LichTrinh_ChiTiet currentVlu_LichTrinh_ChiTiet)
        {
            this.ObjectContext.Vlu_LichTrinh_ChiTiet.AttachAsModified(currentVlu_LichTrinh_ChiTiet, this.ChangeSet.GetOriginal(currentVlu_LichTrinh_ChiTiet));
        }

        public void DeleteVlu_LichTrinh_ChiTiet(Vlu_LichTrinh_ChiTiet vlu_LichTrinh_ChiTiet)
        {
            if ((vlu_LichTrinh_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LichTrinh_ChiTiet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_LichTrinh_ChiTiet.Attach(vlu_LichTrinh_ChiTiet);
                this.ObjectContext.Vlu_LichTrinh_ChiTiet.DeleteObject(vlu_LichTrinh_ChiTiet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_LinkNhanh' query.
        public IQueryable<Vlu_LinkNhanh> GetVlu_LinkNhanh()
        {
            return this.ObjectContext.Vlu_LinkNhanh;
        }

        public void InsertVlu_LinkNhanh(Vlu_LinkNhanh vlu_LinkNhanh)
        {
            if ((vlu_LinkNhanh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LinkNhanh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_LinkNhanh.AddObject(vlu_LinkNhanh);
            }
        }

        public void UpdateVlu_LinkNhanh(Vlu_LinkNhanh currentVlu_LinkNhanh)
        {
            this.ObjectContext.Vlu_LinkNhanh.AttachAsModified(currentVlu_LinkNhanh, this.ChangeSet.GetOriginal(currentVlu_LinkNhanh));
        }

        public void DeleteVlu_LinkNhanh(Vlu_LinkNhanh vlu_LinkNhanh)
        {
            if ((vlu_LinkNhanh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LinkNhanh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_LinkNhanh.Attach(vlu_LinkNhanh);
                this.ObjectContext.Vlu_LinkNhanh.DeleteObject(vlu_LinkNhanh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_LoaiTaiLieuMH' query.
        public IQueryable<Vlu_LoaiTaiLieuMH> GetVlu_LoaiTaiLieuMH()
        {
            return this.ObjectContext.Vlu_LoaiTaiLieuMH;
        }

        public void InsertVlu_LoaiTaiLieuMH(Vlu_LoaiTaiLieuMH vlu_LoaiTaiLieuMH)
        {
            if ((vlu_LoaiTaiLieuMH.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LoaiTaiLieuMH, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_LoaiTaiLieuMH.AddObject(vlu_LoaiTaiLieuMH);
            }
        }

        public void UpdateVlu_LoaiTaiLieuMH(Vlu_LoaiTaiLieuMH currentVlu_LoaiTaiLieuMH)
        {
            this.ObjectContext.Vlu_LoaiTaiLieuMH.AttachAsModified(currentVlu_LoaiTaiLieuMH, this.ChangeSet.GetOriginal(currentVlu_LoaiTaiLieuMH));
        }

        public void DeleteVlu_LoaiTaiLieuMH(Vlu_LoaiTaiLieuMH vlu_LoaiTaiLieuMH)
        {
            if ((vlu_LoaiTaiLieuMH.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LoaiTaiLieuMH, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_LoaiTaiLieuMH.Attach(vlu_LoaiTaiLieuMH);
                this.ObjectContext.Vlu_LoaiTaiLieuMH.DeleteObject(vlu_LoaiTaiLieuMH);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_LopHoc' query.
        public IQueryable<Vlu_LopHoc> GetVlu_LopHoc()
        {
            return this.ObjectContext.Vlu_LopHoc;
        }

        public void InsertVlu_LopHoc(Vlu_LopHoc vlu_LopHoc)
        {
            if ((vlu_LopHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LopHoc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_LopHoc.AddObject(vlu_LopHoc);
            }
        }

        public void UpdateVlu_LopHoc(Vlu_LopHoc currentVlu_LopHoc)
        {
            this.ObjectContext.Vlu_LopHoc.AttachAsModified(currentVlu_LopHoc, this.ChangeSet.GetOriginal(currentVlu_LopHoc));
        }

        public void DeleteVlu_LopHoc(Vlu_LopHoc vlu_LopHoc)
        {
            if ((vlu_LopHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_LopHoc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_LopHoc.Attach(vlu_LopHoc);
                this.ObjectContext.Vlu_LopHoc.DeleteObject(vlu_LopHoc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_MenuTrai' query.
        public IQueryable<Vlu_MenuTrai> GetVlu_MenuTrai()
        {
            return this.ObjectContext.Vlu_MenuTrai;
        }

        public void InsertVlu_MenuTrai(Vlu_MenuTrai vlu_MenuTrai)
        {
            if ((vlu_MenuTrai.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_MenuTrai, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_MenuTrai.AddObject(vlu_MenuTrai);
            }
        }

        public void UpdateVlu_MenuTrai(Vlu_MenuTrai currentVlu_MenuTrai)
        {
            this.ObjectContext.Vlu_MenuTrai.AttachAsModified(currentVlu_MenuTrai, this.ChangeSet.GetOriginal(currentVlu_MenuTrai));
        }

        public void DeleteVlu_MenuTrai(Vlu_MenuTrai vlu_MenuTrai)
        {
            if ((vlu_MenuTrai.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_MenuTrai, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_MenuTrai.Attach(vlu_MenuTrai);
                this.ObjectContext.Vlu_MenuTrai.DeleteObject(vlu_MenuTrai);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_MonHoc' query.
        public IQueryable<Vlu_MonHoc> GetVlu_MonHoc()
        {
            return this.ObjectContext.Vlu_MonHoc;
        }

        public void InsertVlu_MonHoc(Vlu_MonHoc vlu_MonHoc)
        {
            if ((vlu_MonHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_MonHoc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_MonHoc.AddObject(vlu_MonHoc);
            }
        }

        public void UpdateVlu_MonHoc(Vlu_MonHoc currentVlu_MonHoc)
        {
            this.ObjectContext.Vlu_MonHoc.AttachAsModified(currentVlu_MonHoc, this.ChangeSet.GetOriginal(currentVlu_MonHoc));
        }

        public void DeleteVlu_MonHoc(Vlu_MonHoc vlu_MonHoc)
        {
            if ((vlu_MonHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_MonHoc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_MonHoc.Attach(vlu_MonHoc);
                this.ObjectContext.Vlu_MonHoc.DeleteObject(vlu_MonHoc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_PhongHoc' query.
        public IQueryable<Vlu_PhongHoc> GetVlu_PhongHoc()
        {
            return this.ObjectContext.Vlu_PhongHoc;
        }

        public void InsertVlu_PhongHoc(Vlu_PhongHoc vlu_PhongHoc)
        {
            if ((vlu_PhongHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_PhongHoc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_PhongHoc.AddObject(vlu_PhongHoc);
            }
        }

        public void UpdateVlu_PhongHoc(Vlu_PhongHoc currentVlu_PhongHoc)
        {
            this.ObjectContext.Vlu_PhongHoc.AttachAsModified(currentVlu_PhongHoc, this.ChangeSet.GetOriginal(currentVlu_PhongHoc));
        }

        public void DeleteVlu_PhongHoc(Vlu_PhongHoc vlu_PhongHoc)
        {
            if ((vlu_PhongHoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_PhongHoc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_PhongHoc.Attach(vlu_PhongHoc);
                this.ObjectContext.Vlu_PhongHoc.DeleteObject(vlu_PhongHoc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_Popup' query.
        public IQueryable<Vlu_Popup> GetVlu_Popup()
        {
            return this.ObjectContext.Vlu_Popup;
        }

        public void InsertVlu_Popup(Vlu_Popup vlu_Popup)
        {
            if ((vlu_Popup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Popup, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_Popup.AddObject(vlu_Popup);
            }
        }

        public void UpdateVlu_Popup(Vlu_Popup currentVlu_Popup)
        {
            this.ObjectContext.Vlu_Popup.AttachAsModified(currentVlu_Popup, this.ChangeSet.GetOriginal(currentVlu_Popup));
        }

        public void DeleteVlu_Popup(Vlu_Popup vlu_Popup)
        {
            if ((vlu_Popup.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_Popup, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_Popup.Attach(vlu_Popup);
                this.ObjectContext.Vlu_Popup.DeleteObject(vlu_Popup);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_SinhVien' query.
        public IQueryable<Vlu_SinhVien> GetVlu_SinhVien()
        {
            return this.ObjectContext.Vlu_SinhVien;
        }

        public void InsertVlu_SinhVien(Vlu_SinhVien vlu_SinhVien)
        {
            if ((vlu_SinhVien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SinhVien, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_SinhVien.AddObject(vlu_SinhVien);
            }
        }

        public void UpdateVlu_SinhVien(Vlu_SinhVien currentVlu_SinhVien)
        {
            this.ObjectContext.Vlu_SinhVien.AttachAsModified(currentVlu_SinhVien, this.ChangeSet.GetOriginal(currentVlu_SinhVien));
        }

        public void DeleteVlu_SinhVien(Vlu_SinhVien vlu_SinhVien)
        {
            if ((vlu_SinhVien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SinhVien, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_SinhVien.Attach(vlu_SinhVien);
                this.ObjectContext.Vlu_SinhVien.DeleteObject(vlu_SinhVien);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_SlideShow' query.
        public IQueryable<Vlu_SlideShow> GetVlu_SlideShow()
        {
            return this.ObjectContext.Vlu_SlideShow;
        }

        public void InsertVlu_SlideShow(Vlu_SlideShow vlu_SlideShow)
        {
            if ((vlu_SlideShow.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SlideShow, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_SlideShow.AddObject(vlu_SlideShow);
            }
        }

        public void UpdateVlu_SlideShow(Vlu_SlideShow currentVlu_SlideShow)
        {
            this.ObjectContext.Vlu_SlideShow.AttachAsModified(currentVlu_SlideShow, this.ChangeSet.GetOriginal(currentVlu_SlideShow));
        }

        public void DeleteVlu_SlideShow(Vlu_SlideShow vlu_SlideShow)
        {
            if ((vlu_SlideShow.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SlideShow, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_SlideShow.Attach(vlu_SlideShow);
                this.ObjectContext.Vlu_SlideShow.DeleteObject(vlu_SlideShow);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_SuKien' query.
        public IQueryable<Vlu_SuKien> GetVlu_SuKien()
        {
            return this.ObjectContext.Vlu_SuKien;
        }

        public void InsertVlu_SuKien(Vlu_SuKien vlu_SuKien)
        {
            if ((vlu_SuKien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SuKien, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_SuKien.AddObject(vlu_SuKien);
            }
        }

        public void UpdateVlu_SuKien(Vlu_SuKien currentVlu_SuKien)
        {
            this.ObjectContext.Vlu_SuKien.AttachAsModified(currentVlu_SuKien, this.ChangeSet.GetOriginal(currentVlu_SuKien));
        }

        public void DeleteVlu_SuKien(Vlu_SuKien vlu_SuKien)
        {
            if ((vlu_SuKien.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SuKien, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_SuKien.Attach(vlu_SuKien);
                this.ObjectContext.Vlu_SuKien.DeleteObject(vlu_SuKien);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_SuKien_PhanQuyen' query.
        public IQueryable<Vlu_SuKien_PhanQuyen> GetVlu_SuKien_PhanQuyen()
        {
            return this.ObjectContext.Vlu_SuKien_PhanQuyen;
        }

        public void InsertVlu_SuKien_PhanQuyen(Vlu_SuKien_PhanQuyen vlu_SuKien_PhanQuyen)
        {
            if ((vlu_SuKien_PhanQuyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SuKien_PhanQuyen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_SuKien_PhanQuyen.AddObject(vlu_SuKien_PhanQuyen);
            }
        }

        public void UpdateVlu_SuKien_PhanQuyen(Vlu_SuKien_PhanQuyen currentVlu_SuKien_PhanQuyen)
        {
            this.ObjectContext.Vlu_SuKien_PhanQuyen.AttachAsModified(currentVlu_SuKien_PhanQuyen, this.ChangeSet.GetOriginal(currentVlu_SuKien_PhanQuyen));
        }

        public void DeleteVlu_SuKien_PhanQuyen(Vlu_SuKien_PhanQuyen vlu_SuKien_PhanQuyen)
        {
            if ((vlu_SuKien_PhanQuyen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SuKien_PhanQuyen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_SuKien_PhanQuyen.Attach(vlu_SuKien_PhanQuyen);
                this.ObjectContext.Vlu_SuKien_PhanQuyen.DeleteObject(vlu_SuKien_PhanQuyen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_SuKien_PhienBan' query.
        public IQueryable<Vlu_SuKien_PhienBan> GetVlu_SuKien_PhienBan()
        {
            return this.ObjectContext.Vlu_SuKien_PhienBan;
        }

        public void InsertVlu_SuKien_PhienBan(Vlu_SuKien_PhienBan vlu_SuKien_PhienBan)
        {
            if ((vlu_SuKien_PhienBan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SuKien_PhienBan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_SuKien_PhienBan.AddObject(vlu_SuKien_PhienBan);
            }
        }

        public void UpdateVlu_SuKien_PhienBan(Vlu_SuKien_PhienBan currentVlu_SuKien_PhienBan)
        {
            this.ObjectContext.Vlu_SuKien_PhienBan.AttachAsModified(currentVlu_SuKien_PhienBan, this.ChangeSet.GetOriginal(currentVlu_SuKien_PhienBan));
        }

        public void DeleteVlu_SuKien_PhienBan(Vlu_SuKien_PhienBan vlu_SuKien_PhienBan)
        {
            if ((vlu_SuKien_PhienBan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_SuKien_PhienBan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_SuKien_PhienBan.Attach(vlu_SuKien_PhienBan);
                this.ObjectContext.Vlu_SuKien_PhienBan.DeleteObject(vlu_SuKien_PhienBan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_TaiKhoan' query.
        public IQueryable<Vlu_TaiKhoan> GetVlu_TaiKhoan()
        {
            return this.ObjectContext.Vlu_TaiKhoan;
        }

        public void InsertVlu_TaiKhoan(Vlu_TaiKhoan vlu_TaiKhoan)
        {
            if ((vlu_TaiKhoan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_TaiKhoan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_TaiKhoan.AddObject(vlu_TaiKhoan);
            }
        }

        public void UpdateVlu_TaiKhoan(Vlu_TaiKhoan currentVlu_TaiKhoan)
        {
            this.ObjectContext.Vlu_TaiKhoan.AttachAsModified(currentVlu_TaiKhoan, this.ChangeSet.GetOriginal(currentVlu_TaiKhoan));
        }

        public void DeleteVlu_TaiKhoan(Vlu_TaiKhoan vlu_TaiKhoan)
        {
            if ((vlu_TaiKhoan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_TaiKhoan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_TaiKhoan.Attach(vlu_TaiKhoan);
                this.ObjectContext.Vlu_TaiKhoan.DeleteObject(vlu_TaiKhoan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_TaiLieuMH' query.
        public IQueryable<Vlu_TaiLieuMH> GetVlu_TaiLieuMH()
        {
            return this.ObjectContext.Vlu_TaiLieuMH;
        }

        public void InsertVlu_TaiLieuMH(Vlu_TaiLieuMH vlu_TaiLieuMH)
        {
            if ((vlu_TaiLieuMH.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_TaiLieuMH, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_TaiLieuMH.AddObject(vlu_TaiLieuMH);
            }
        }

        public void UpdateVlu_TaiLieuMH(Vlu_TaiLieuMH currentVlu_TaiLieuMH)
        {
            this.ObjectContext.Vlu_TaiLieuMH.AttachAsModified(currentVlu_TaiLieuMH, this.ChangeSet.GetOriginal(currentVlu_TaiLieuMH));
        }

        public void DeleteVlu_TaiLieuMH(Vlu_TaiLieuMH vlu_TaiLieuMH)
        {
            if ((vlu_TaiLieuMH.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_TaiLieuMH, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_TaiLieuMH.Attach(vlu_TaiLieuMH);
                this.ObjectContext.Vlu_TaiLieuMH.DeleteObject(vlu_TaiLieuMH);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_TaiLieuMH_Temp' query.
        public IQueryable<Vlu_TaiLieuMH_Temp> GetVlu_TaiLieuMH_Temp()
        {
            return this.ObjectContext.Vlu_TaiLieuMH_Temp;
        }

        public void InsertVlu_TaiLieuMH_Temp(Vlu_TaiLieuMH_Temp vlu_TaiLieuMH_Temp)
        {
            if ((vlu_TaiLieuMH_Temp.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_TaiLieuMH_Temp, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_TaiLieuMH_Temp.AddObject(vlu_TaiLieuMH_Temp);
            }
        }

        public void UpdateVlu_TaiLieuMH_Temp(Vlu_TaiLieuMH_Temp currentVlu_TaiLieuMH_Temp)
        {
            this.ObjectContext.Vlu_TaiLieuMH_Temp.AttachAsModified(currentVlu_TaiLieuMH_Temp, this.ChangeSet.GetOriginal(currentVlu_TaiLieuMH_Temp));
        }

        public void DeleteVlu_TaiLieuMH_Temp(Vlu_TaiLieuMH_Temp vlu_TaiLieuMH_Temp)
        {
            if ((vlu_TaiLieuMH_Temp.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_TaiLieuMH_Temp, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_TaiLieuMH_Temp.Attach(vlu_TaiLieuMH_Temp);
                this.ObjectContext.Vlu_TaiLieuMH_Temp.DeleteObject(vlu_TaiLieuMH_Temp);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ThoiKhoaBieu' query.
        public IQueryable<Vlu_ThoiKhoaBieu> GetVlu_ThoiKhoaBieu()
        {
            return this.ObjectContext.Vlu_ThoiKhoaBieu;
        }

        public void InsertVlu_ThoiKhoaBieu(Vlu_ThoiKhoaBieu vlu_ThoiKhoaBieu)
        {
            if ((vlu_ThoiKhoaBieu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ThoiKhoaBieu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ThoiKhoaBieu.AddObject(vlu_ThoiKhoaBieu);
            }
        }

        public void UpdateVlu_ThoiKhoaBieu(Vlu_ThoiKhoaBieu currentVlu_ThoiKhoaBieu)
        {
            this.ObjectContext.Vlu_ThoiKhoaBieu.AttachAsModified(currentVlu_ThoiKhoaBieu, this.ChangeSet.GetOriginal(currentVlu_ThoiKhoaBieu));
        }

        public void DeleteVlu_ThoiKhoaBieu(Vlu_ThoiKhoaBieu vlu_ThoiKhoaBieu)
        {
            if ((vlu_ThoiKhoaBieu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ThoiKhoaBieu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ThoiKhoaBieu.Attach(vlu_ThoiKhoaBieu);
                this.ObjectContext.Vlu_ThoiKhoaBieu.DeleteObject(vlu_ThoiKhoaBieu);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ThoiKhoaBieu_ChiTiet' query.
        public IQueryable<Vlu_ThoiKhoaBieu_ChiTiet> GetVlu_ThoiKhoaBieu_ChiTiet()
        {
            return this.ObjectContext.Vlu_ThoiKhoaBieu_ChiTiet;
        }

        public void InsertVlu_ThoiKhoaBieu_ChiTiet(Vlu_ThoiKhoaBieu_ChiTiet vlu_ThoiKhoaBieu_ChiTiet)
        {
            if ((vlu_ThoiKhoaBieu_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ThoiKhoaBieu_ChiTiet, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ThoiKhoaBieu_ChiTiet.AddObject(vlu_ThoiKhoaBieu_ChiTiet);
            }
        }

        public void UpdateVlu_ThoiKhoaBieu_ChiTiet(Vlu_ThoiKhoaBieu_ChiTiet currentVlu_ThoiKhoaBieu_ChiTiet)
        {
            this.ObjectContext.Vlu_ThoiKhoaBieu_ChiTiet.AttachAsModified(currentVlu_ThoiKhoaBieu_ChiTiet, this.ChangeSet.GetOriginal(currentVlu_ThoiKhoaBieu_ChiTiet));
        }

        public void DeleteVlu_ThoiKhoaBieu_ChiTiet(Vlu_ThoiKhoaBieu_ChiTiet vlu_ThoiKhoaBieu_ChiTiet)
        {
            if ((vlu_ThoiKhoaBieu_ChiTiet.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ThoiKhoaBieu_ChiTiet, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ThoiKhoaBieu_ChiTiet.Attach(vlu_ThoiKhoaBieu_ChiTiet);
                this.ObjectContext.Vlu_ThoiKhoaBieu_ChiTiet.DeleteObject(vlu_ThoiKhoaBieu_ChiTiet);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_ThongTinDT' query.
        public IQueryable<Vlu_ThongTinDT> GetVlu_ThongTinDT()
        {
            return this.ObjectContext.Vlu_ThongTinDT;
        }

        public void InsertVlu_ThongTinDT(Vlu_ThongTinDT vlu_ThongTinDT)
        {
            if ((vlu_ThongTinDT.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ThongTinDT, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_ThongTinDT.AddObject(vlu_ThongTinDT);
            }
        }

        public void UpdateVlu_ThongTinDT(Vlu_ThongTinDT currentVlu_ThongTinDT)
        {
            this.ObjectContext.Vlu_ThongTinDT.AttachAsModified(currentVlu_ThongTinDT, this.ChangeSet.GetOriginal(currentVlu_ThongTinDT));
        }

        public void DeleteVlu_ThongTinDT(Vlu_ThongTinDT vlu_ThongTinDT)
        {
            if ((vlu_ThongTinDT.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_ThongTinDT, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_ThongTinDT.Attach(vlu_ThongTinDT);
                this.ObjectContext.Vlu_ThongTinDT.DeleteObject(vlu_ThongTinDT);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Vlu_UserSettings' query.
        public IQueryable<Vlu_UserSettings> GetVlu_UserSettings()
        {
            return this.ObjectContext.Vlu_UserSettings;
        }

        public void InsertVlu_UserSettings(Vlu_UserSettings vlu_UserSettings)
        {
            if ((vlu_UserSettings.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_UserSettings, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Vlu_UserSettings.AddObject(vlu_UserSettings);
            }
        }

        public void UpdateVlu_UserSettings(Vlu_UserSettings currentVlu_UserSettings)
        {
            this.ObjectContext.Vlu_UserSettings.AttachAsModified(currentVlu_UserSettings, this.ChangeSet.GetOriginal(currentVlu_UserSettings));
        }

        public void DeleteVlu_UserSettings(Vlu_UserSettings vlu_UserSettings)
        {
            if ((vlu_UserSettings.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vlu_UserSettings, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Vlu_UserSettings.Attach(vlu_UserSettings);
                this.ObjectContext.Vlu_UserSettings.DeleteObject(vlu_UserSettings);
            }
        }
    }
}



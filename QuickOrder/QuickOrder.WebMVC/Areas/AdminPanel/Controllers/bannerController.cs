using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;
using QuickOrder.Entities.Entities.EntityFramework;
using System.Linq;
using QuickOrder.WebMVC.App_Classes;
using System.Data.Entity.Migrations;
using QuickOrder.UnitOfWork.Abstract;

namespace QuickOrder.WebMVC.Areas.AdminPanel.Controllers
{
    /*
     AÇIKLAMA

    Her bir html sayfasının bir controller'ı olur. Controller= verilerin kontrol, kumanda edildiği classlara denir. 
    Bu alanda datalar çekilir ve istenilen şekilde html sayfasına yani viewlere gönderilir ve orada kullanıcıya gösterilir.
     */

    //Bu kod; bu controller'a sadece Moderator yetkisi olan kullanıcılar erişebilir demektir.
    [Authorize(Roles = "Moderator")]
    public class bannerController : Controller
    {
        //IUnitOfWork veritabanındaki tüm tabloların classlara dönüştürülüp, daha sonra iş kurallarının yazılıp, bu iş kurallarına göre veritabanında verilerin çekilip
        // kullanıma hazır hale getirilen bannerBll, productBll gibi classların bir arada tutularak tek satır kod ile çağrılması için kullanılan bir tekniktir.
        // Kısacası bir sepet görevi görür. Elma ve Armutlar bir sepete atılır, tek tek her birinin çağrılması yerine, sepet getirilir ve sepet içinden isteyen elma ya da
        //armut'u alır.
        IUnitOfWork ctx;
        public bannerController(IUnitOfWork _ctx)
        {
            ctx = _ctx;
        }
       
        //Veritabanından banner'ların tamamının çekilip view de gösterildiği fonksiyondur
        public ActionResult Index()
        {
            //Burada görüldüğü gibi ctx; yani meyve sepeti getirilmiş ve içinden bannerBll alınmış. İstense productBll de alınabilirdi
            List<banners> banners = ctx.bannerBll.getAll();
            if (banners!=null)
            {
                //Getirilen veritabanı verileri ilgili view'e liste halinde return ediliyor, yani gönderiliyor
                return View(banners);
            }
            return View();
        }
        //Admin panel üzerinden banner ekleme işlemi sırasında çalışan fonksiyondur. HTTPOST demek; bu servisin sadece post işlemi yaparken çalıştığını gösterir
        // Yani DB'ye ekleme, silme ya da güncelleme için kullanır demektir.
        [HttpPost]
        public ActionResult bannerAdd(string text, HttpPostedFileBase companyPicturePath)
        {
            //try case metodu demek; işlem sırasında bir hata olursa projeyi durdurma sadece beni uyar demek için kullanılır
            try
            {
                //ModelState.IsValid demek, Kayıt etmek için girilen veriler benim istediğim gibi mi gelmiş onun kontrolünü yapar.
                // Eğer geçersiz veri gelmişse kayıt etmez ve hata mesajı döndürür
                if (ModelState.IsValid &&!string.IsNullOrEmpty(text)&& companyPicturePath!=null)
                {
                    //Burada eklenmek istenilen resimler yeniden boyutlandırılarak, proje dizininden istenilen yere resmin kayıt edilmesi sağlanır
                    //
                    int picWidth = settings.bannerPicture.Width;
                    int pichHeight = settings.bannerPicture.Height;
                    string newName = Path.GetFileNameWithoutExtension(companyPicturePath.FileName) + "-" + Guid.NewGuid() + Path.GetExtension(companyPicturePath.FileName);
                    Image orjResim = Image.FromStream(companyPicturePath.InputStream);
                    Bitmap pictureDraw = new Bitmap(orjResim, picWidth, pichHeight);
                    if (Directory.Exists(Server.MapPath("/content/img/bannerPicture")))
                    {
                        pictureDraw.Save(Server.MapPath("/content/img/bannerPicture/" + newName));
                    }

                    banners bnr = new banners();
                    bnr.text = text;
                    bnr.bannerPath = "/content/img/bannerPicture/" + newName;
                    //resmin alt'ı olarak kullanacağım filename'i
                    bnr.altName = companyPicturePath.FileName;
                    bool result=ctx.bannerBll.add(bnr);
                     
                    Session["bannerAlert"] = "";
                    if (result)
                    {
                        Session["bannerAlert"] = "Banner başarıyla eklendi";
                        return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                    }
                    else
                    {
                        Session["bannerAlert"] = "Banner eklenirken bir hata meydana geldi !";

                        return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                    }
                }
               
                else
                {
                    Session["bannerAlert"] = "Lütfen ilgili tüm alanları doldurun";
                    return RedirectToAction("Index", "banner", new { area = "AdminPanel" });
                }
            }
            catch (Exception e)
            {
                Session["bannerAlert"] = e.Message;
                return RedirectToAction("Index", "banner", new {area = "AdminPanel"});
            }



            
        }
        //Banner silme servisi
        [HttpPost]
        public ActionResult bannerDelete(int id)
        {
            try
            {
                banners bnr=ctx.bannerBll.getOne( id);

                if (bnr!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(bnr.bannerPath)))
                    {
                        System.IO.File.Delete(Server.MapPath(bnr.bannerPath));

                    }

                    bool resultDeleteBanner = ctx.bannerBll.deleteById(bnr.id);
              
                    if (resultDeleteBanner)
                    {
                        return Json(new { id = 1, message = "Banner silindi." });
                    }
                    else
                    {
                        return Json(new { id = 0, message = "Banner silinirken bir hata meydana geldi !" });
                    }

                }
                else
                {
                    return Json(new { id = 0, message = "Silinmek istenen Banner bulunamadı" });
                }
               
                
            }
            catch (Exception e)
            {
                return Json(new { id = 0, message =e.Message });
            }
        }
    }
}
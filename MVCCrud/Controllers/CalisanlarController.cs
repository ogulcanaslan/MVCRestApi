using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;

namespace MVCCrud.Controllers
{
    public class CalisanlarController : Controller
    {
        // GET: Calisanlar
        public ActionResult Index()
        {
            IEnumerable<MvcCalisanlarModel> calList;
            HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Calisanlars").Result;
            calList = response.Content.ReadAsAsync<IEnumerable<MvcCalisanlarModel>>().Result;


            return View(calList);

        }
        public ActionResult Ekle(int id = 0)
        {
            if (id == 0)
            {
                return View(new MvcCalisanlarModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.GetAsync("Calisanlars/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcCalisanlarModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult Ekle(MvcCalisanlarModel calisan)
        {
            if (calisan.CalisanID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PostAsJsonAsync("Calisanlars", calisan).Result;
                TempData["SuccessMessage"] = "Başarılı Bir Şekilde Kaydedildi";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WepApiClient.PutAsJsonAsync("Calisanlars/" + calisan.CalisanID, calisan).Result;
                TempData["SuccessMessage"] = "Güncelleme Başarılı";

            }
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            HttpResponseMessage response = GlobalVariables.WepApiClient.DeleteAsync("Calisanlars/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Silme işlemi Başarılı";

            return RedirectToAction("Index");
        }




    }
}
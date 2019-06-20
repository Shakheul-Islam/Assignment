using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.ViewModels;
using Domain.Repositories;
using Core.Services;
using System.IO;

namespace Assignment.Controllers
{
    public class AgentController : Controller
    {
        private UnitOfWork unitOfWork;
        private AgentServices AgentServices ;

        public AgentController()
        {
            unitOfWork = new UnitOfWork();
            AgentServices = new AgentServices(unitOfWork);
        }
        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult Create(BusinessEntitiesViewModel businessEntitiesViewModel)
        {
            if (businessEntitiesViewModel.BusinessId > 0)
            {
              var file = businessEntitiesViewModel.ImageFile;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    string filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                    if (string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))

                    {

                        //file.SaveAs(Server.MapPath("/AppFile/Images/" + file.FileName));
                        businessEntitiesViewModel.LogoImagePath = "~/AppFiles/Images/" + fileName;
                        file.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                        var data = AgentServices.Update(businessEntitiesViewModel);
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {

                        return Json(new { success = "Image Extension is Worng" });

                    }
                

                }
                else
                {

                    var data = AgentServices.Update(businessEntitiesViewModel);
                    return Json(data, JsonRequestBehavior.AllowGet);

                }

              

            }
            else
            {

                var file = businessEntitiesViewModel.ImageFile;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    string filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                    if (string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase)
                    || string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase))

                    {

                        //file.SaveAs(Server.MapPath("/AppFile/Images/" + file.FileName));
                        businessEntitiesViewModel.LogoImagePath = "~/AppFiles/Images/" + fileName;
                        file.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                        var data = AgentServices.Create(businessEntitiesViewModel);
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {

                        return Json(new { success = "Image Extension is Worng" });

                    }


                }
                else
                {

                    return Json(new { success = "Image Not Fount" });

                }
            }




 }

        public JsonResult LoadAgentList()
        {
            var data = AgentServices.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
 public JsonResult GetAgentList(int BusinessId)
        {
            var data = AgentServices.GetById(BusinessId);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(int BusinessId)
        {
           var data = AgentServices.Delete(BusinessId);
            return Json(new { success = "Successfully Deleted" });
        }


        
       public JsonResult SearchAgentList(string code, string name, int? markupplanid)
        {
            

            var data  = AgentServices.SearchAgentList(code, name, markupplanid);
            //var data = AgentServices.SearchAgentList(businessEntitiesViewModel);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
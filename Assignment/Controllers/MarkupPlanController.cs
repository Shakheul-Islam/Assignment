using Domain.Repositories;
using Domain.ViewModels;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Controllers
{
    public class MarkupPlanController : Controller
    {

        private UnitOfWork unitOfWork;
        private MarkupPlanService MarkupPlanService;

        public MarkupPlanController()
        {
            unitOfWork = new UnitOfWork();
            MarkupPlanService = new MarkupPlanService(unitOfWork);
        }

        // GET: MarkupPlan
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult Create(MarkupPlanViewModel markupPlanViewModel)
        {
            if (markupPlanViewModel.Id != 0)
            {

                var data = MarkupPlanService.Update(markupPlanViewModel);
                return Json(data, JsonRequestBehavior.AllowGet);

            }
            else {
                var data = MarkupPlanService.Create(markupPlanViewModel);
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            
        }


        public JsonResult LoadPlan()
        {
            var data = MarkupPlanService.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int Id)
        {
            var data = MarkupPlanService.GetById(Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int Id)
        {
            MarkupPlanService.Delete(Id);
            return Json(new { success="Successfully Deleted"});
        }

    }
}
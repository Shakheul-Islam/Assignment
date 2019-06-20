using Domain.Models;
using Domain.Repositories;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
 public class MarkupPlanService
    {
        private UnitOfWork unitOfWork;

        public MarkupPlanService(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public string Create(MarkupPlanViewModel markupPlanViewModel)
        {
            int count = (from x in unitOfWork.MarkupPlanRepository.Get() where x.Name == markupPlanViewModel.Name select x.Name).Count();
            if (count>0) {
                return "Already Exist!!";
            }
            else {
                var markupPlan = new MarkupPlan
                {

                    Name = markupPlanViewModel.Name
                };

                unitOfWork.MarkupPlanRepository.Insert(markupPlan);

                if (unitOfWork.Save() == 1)
                {

                    return "Successfully Saved";
                }
                else
                {
                    return "Saved Failed!!";
                }

            }
           
        }


        public string Update(MarkupPlanViewModel markupPlanViewModel)
        {
            int count = (from x in unitOfWork.MarkupPlanRepository.Get() where x.Name == markupPlanViewModel.Name select x.Name).Count();
            if (count > 0)
            {
                return "Already Exist!!";
            }
            else
            {
                var markupPlan = new MarkupPlan
                {
                    Id = markupPlanViewModel.Id,
                    Name = markupPlanViewModel.Name
                };
                unitOfWork.MarkupPlanRepository.Update(markupPlan);
                if (unitOfWork.Save() == 1)
                {

                    return "Successfully Updated";
                }
                else
                {
                    return "Update Failed";
                }

            }
         
        }

        public MarkupPlanViewModel GetById(int id)
        {
            var data = (from s in unitOfWork.MarkupPlanRepository.Get()
                        where s.Id == id
                        select new MarkupPlanViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).SingleOrDefault();
            return data;
        }
        public IEnumerable<MarkupPlanViewModel> GetAll()
        {
            var data = (from s in unitOfWork.MarkupPlanRepository.Get()
                        select new MarkupPlanViewModel
                        {

                            Id = s.Id,
                            Name = s.Name

                        }).AsEnumerable();
            return data;
        }

        public string Delete(int id)
        {
            int count = (from x in unitOfWork.MarkupPlanRepository.Get() where x.Id == id select x.Name).Count();
            if (count > 0) {
                          var markupPlan = new MarkupPlan
                          {
                            Id = id
                          };
                unitOfWork.MarkupPlanRepository.Delete(markupPlan);
                if (unitOfWork.Save() == 1)
                {

                    return "Successfully Deleted";
                }
                else
                {
                    return "Delete Failed";
                }
            }
            else {
                return "Id is Not Fount";

            }
        

           

        }



        public IEnumerable<MarkupPlanViewModel> GetDropDown()
        {
            var data = (from s in unitOfWork.MarkupPlanRepository.Get()
                        select new MarkupPlanViewModel
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).AsEnumerable();

            return data;
        }



    }
}

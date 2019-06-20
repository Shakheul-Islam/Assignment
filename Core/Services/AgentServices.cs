using Domain.Repositories;
using Domain.Models;
using Domain.ViewModels;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
  public class AgentServices
    {
        private UnitOfWork unitOfWork;

        public AgentServices(UnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public string Create(BusinessEntitiesViewModel businessEntitiesViewModel)
        {
          
                var BusinessEntities = new BusinessEntities
                {
                    Code = businessEntitiesViewModel.Code,
                    Name = businessEntitiesViewModel.Name,
                    MarkupPlanId = businessEntitiesViewModel.MarkupPlanId,
                    Email = businessEntitiesViewModel.Email,
                    Mobile=businessEntitiesViewModel.Mobile,
                    Phone=businessEntitiesViewModel.Phone,
                    Address=businessEntitiesViewModel.Address,
                    City=businessEntitiesViewModel.City,
                    State=businessEntitiesViewModel.State,
                    Country=businessEntitiesViewModel.Country,
                    Zip=businessEntitiesViewModel.Zip,
                    ContactPerson=businessEntitiesViewModel.ContactPerson,
                    ReferredBy=businessEntitiesViewModel.ReferredBy,
                    CurrentBalance=businessEntitiesViewModel.Balance,
                    Status= businessEntitiesViewModel.Status,
                    RegentAPI=businessEntitiesViewModel.RegentAPI,
                    NovoAPI=businessEntitiesViewModel.NovoAPI,
                    GalileoAPI=businessEntitiesViewModel.GalileoAPI,
                    USBSAPI=businessEntitiesViewModel.USBSAPI,
                    IndigoAPI=businessEntitiesViewModel.IndigoAPI,
                    AgentType=businessEntitiesViewModel.AgentType,
                    Logo=businessEntitiesViewModel.LogoImagePath,
                    SMTPServer=businessEntitiesViewModel.SMTPServer,
                    SMTPPort=businessEntitiesViewModel.SMTPPort,
                    SMTPUsername=businessEntitiesViewModel.SMTPUsername,
                    SMTPPassword=businessEntitiesViewModel.SMTPPassword,
                    CreatedOnUtc=DateTime.Now
      };


                unitOfWork.BusinessEntitiesRepository.Insert(BusinessEntities);

                if (unitOfWork.Save() == 1)
                {

                    return "Successfully Saved";
                }
                else
                {
                    return "Saved Failed!!";
                }


        }


        public string Update(BusinessEntitiesViewModel businessEntitiesViewModel)
        {
            var BusinessEntities = new BusinessEntities
            {
                BusinessId = businessEntitiesViewModel.BusinessId,
                Code = businessEntitiesViewModel.Code,
                Name = businessEntitiesViewModel.Name,
                MarkupPlanId = businessEntitiesViewModel.MarkupPlanId,
                Email = businessEntitiesViewModel.Email,
                Mobile = businessEntitiesViewModel.Mobile,
                Phone = businessEntitiesViewModel.Phone,
                Address = businessEntitiesViewModel.Address,
                City = businessEntitiesViewModel.City,
                State = businessEntitiesViewModel.State,
                Country = businessEntitiesViewModel.Country,
                Zip = businessEntitiesViewModel.Zip,
                ContactPerson = businessEntitiesViewModel.ContactPerson,
                ReferredBy = businessEntitiesViewModel.ReferredBy,
                CurrentBalance = businessEntitiesViewModel.Balance,
                Status = businessEntitiesViewModel.Status,
                RegentAPI = businessEntitiesViewModel.RegentAPI,
                NovoAPI = businessEntitiesViewModel.NovoAPI,
                GalileoAPI = businessEntitiesViewModel.GalileoAPI,
                USBSAPI = businessEntitiesViewModel.USBSAPI,
                IndigoAPI = businessEntitiesViewModel.IndigoAPI,
                AgentType = businessEntitiesViewModel.AgentType,
                Logo = businessEntitiesViewModel.LogoImagePath,
                SMTPServer = businessEntitiesViewModel.SMTPServer,
                SMTPPort = businessEntitiesViewModel.SMTPPort,
                SMTPUsername = businessEntitiesViewModel.SMTPUsername,
                SMTPPassword = businessEntitiesViewModel.SMTPPassword,
                CreatedOnUtc = DateTime.Now
            };
            unitOfWork.BusinessEntitiesRepository.Update(BusinessEntities);
            if (unitOfWork.Save() == 1)
            {

                return "Successfully Updated";
            }
            else
            {
                return "Update Failed";
            }

        }

        public BusinessEntitiesViewModel GetById(int id)
        {
            var data = (from s in unitOfWork.BusinessEntitiesRepository.Get()
                        join m in unitOfWork.MarkupPlanRepository.Get() on s.MarkupPlanId equals m.Id
                        where s.BusinessId == id
                        select new BusinessEntitiesViewModel
                        {
                            BusinessId = s.BusinessId,
                            Code = s.Code,
                            Name = s.Name,
                            MarkupPlanId = s.MarkupPlanId,
                            MarkupPlanName=m.Name,
                            Email = s.Email,
                            Mobile = s.Mobile,
                            Phone = s.Phone,
                            Address = s.Address,
                            City = s.City,
                            State = s.State,
                            Country = s.Country,
                            Zip = s.Zip,
                            ContactPerson = s.ContactPerson,
                            ReferredBy = s.ReferredBy,
                            CurrentBalance = s.CurrentBalance,
                            Status = s.Status,
                            RegentAPI = s.RegentAPI,
                            NovoAPI = s.NovoAPI,
                            GalileoAPI = s.GalileoAPI,
                            USBSAPI = s.USBSAPI,
                            IndigoAPI = s.IndigoAPI,
                            AgentType = s.AgentType,
                            LogoImagePath=s.Logo,
                            SMTPServer = s.SMTPServer,
                            SMTPPort = s.SMTPPort,
                            SMTPUsername = s.SMTPUsername,
                            SMTPPassword = s.SMTPPassword,
                            CreatedOnUtc =s.CreatedOnUtc
                        }).SingleOrDefault();
            return data;
        }
        public IEnumerable<BusinessEntitiesViewModel> GetAll()
        {
            var data = (from s in unitOfWork.BusinessEntitiesRepository.Get()
                        join m in unitOfWork.MarkupPlanRepository.Get() on s.MarkupPlanId equals m.Id
                        select new BusinessEntitiesViewModel
                        {
                            BusinessId = s.BusinessId,
                            Code = s.Code,
                            Name = s.Name,
                            MarkupPlanId = s.MarkupPlanId,
                            MarkupPlanName= m.Name,
                            Email = s.Email,
                            Mobile = s.Mobile,
                            Phone = s.Phone,
                            Address = s.Address,
                            City = s.City,
                            State = s.State,
                            Country = s.Country,
                            Zip = s.Zip,
                            ContactPerson = s.ContactPerson,
                            ReferredBy = s.ReferredBy,
                            CurrentBalance = s.CurrentBalance,
                            Status = s.Status,
                            RegentAPI = s.RegentAPI,
                            NovoAPI = s.NovoAPI,
                            GalileoAPI = s.GalileoAPI,
                            USBSAPI = s.USBSAPI,
                            IndigoAPI = s.IndigoAPI,
                            AgentType = s.AgentType,
                            LogoImagePath = s.Logo,
                            SMTPServer = s.SMTPServer,
                            SMTPPort = s.SMTPPort,
                            SMTPUsername = s.SMTPUsername,
                            SMTPPassword = s.SMTPPassword,
                            CreatedOnUtc = s.CreatedOnUtc

                        }).AsEnumerable();
            return data;
        }

        public string Delete(int id)
        {
            int count = (from x in unitOfWork.BusinessEntitiesRepository.Get() where x.BusinessId == id select x.Name).Count();
            if (count > 0)
            {
                var BusinessEntities = new BusinessEntities
                {
                    BusinessId = id
                };
                unitOfWork.BusinessEntitiesRepository.Delete(BusinessEntities);
                if (unitOfWork.Save() == 1)
                {

                    return "Successfully Deleted";
                }
                else
                {
                    return "Delete Failed";
                }
            }
            else
            {
                return "Id is Not Fount";

            }




        }



        public List<BusinessEntitiesViewModel> SearchAgentList(string code, string name, int? markupplanid)
        {
            var r = (from s in unitOfWork.BusinessEntitiesRepository.Get()
                        join m in unitOfWork.MarkupPlanRepository.Get() on s.MarkupPlanId equals m.Id
                     
                        select new BusinessEntitiesViewModel
                        {
                            BusinessId = s.BusinessId,
                            Code = s.Code,
                            Name = s.Name,
                            MarkupPlanId = s.MarkupPlanId,
                            MarkupPlanName = m.Name,
                            Email = s.Email,
                            Mobile = s.Mobile,
                            Phone = s.Phone,
                            Address = s.Address,
                            City = s.City,
                            State = s.State,
                            Country = s.Country,
                            Zip = s.Zip,
                            ContactPerson = s.ContactPerson,
                            ReferredBy = s.ReferredBy,
                            CurrentBalance = s.CurrentBalance,
                            Status = s.Status,
                            RegentAPI = s.RegentAPI,
                            NovoAPI = s.NovoAPI,
                            GalileoAPI = s.GalileoAPI,
                            USBSAPI = s.USBSAPI,
                            IndigoAPI = s.IndigoAPI,
                            AgentType = s.AgentType,
                            LogoImagePath = s.Logo,
                            SMTPServer = s.SMTPServer,
                            SMTPPort = s.SMTPPort,
                            SMTPUsername = s.SMTPUsername,
                            SMTPPassword = s.SMTPPassword,
                            CreatedOnUtc = s.CreatedOnUtc
                        });

            if (code != null)
                r = r.Where(p => p.Code.Contains(code));

            if (name != null)
                r = r.Where(p => p.Name.Contains(name));

            if (markupplanid > 0)
                r = r.Where(p => p.MarkupPlanId == markupplanid);

            var data = r.ToList();

            return data;
        }



    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static Domain.Models.BusinessEntities;

namespace Domain.ViewModels
{
   public class BusinessEntitiesViewModel
    {
        public int BusinessId { get; set; }
        public string Code { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public string Name { get; set; }


        public string Street { get; set; }

        [MaxLength(150)]
        public string City { get; set; }

        [MaxLength(150)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Zip { get; set; }
        public string Address { get; set; }
        [MaxLength(150)]
        public string Country { get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }


        public string ContactPerson { get; set; }

        [MaxLength(50)]
        public string ReferredBy { get; set; }


        public string LogoImagePath { get; set; }
        

       
        public decimal Balance { get; set; }


        [MaxLength(50)]
        public string SecurityCode { get; set; }
        [MaxLength(50)]
        public string SMTPServer { get; set; }

        public int SMTPPort { get; set; }

        [MaxLength(50)]
        public string SMTPUsername { get; set; }

        [MaxLength(50)]
        public string SMTPPassword { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal CurrentBalance { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public int MarkupPlanId { get; set; }
        public string MarkupPlanName { get; set; }
        public string Status { get; set; }
        public string RegentAPI { get; set; }
        public string NovoAPI { get; set; }
        public string GalileoAPI { get; set; }
        public string USBSAPI { get; set; }
        public string IndigoAPI { get; set; }
        public string AgentType { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
        public List<BusinessEntitiesViewModel> businessEntitiesViewModelList { get; set; }
    }

   
}


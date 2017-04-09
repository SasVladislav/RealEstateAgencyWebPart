using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgencyWebPart.DAL.Models;
using RealEstateAgencyWebPart.DAL.RepositoryService;
using RealEstateAgencyWebPart.BLL.GenericService;
using System.Linq.Expressions;
using RealEstateAgencyWebPart.BLL.Interfaces;
using AutoMapper;
using RealEstateAgencyWebPart.BLL.Models;
using RealEstateAgencyWebPart.BLL.Models.ViewModels;

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class JournalService: IJournalService
    {
        GenericServiceEntity<Orders> service = new GenericServiceEntity<Orders>();

        public IEnumerable<JournalDTO> GetAllRecordsJournalByExpression(Expression<Func<JournalDTO, bool>> whereDTO = null)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Journal, JournalDTO>());
            //Expression<Func<Journal, bool>> where = Mapper.Map<Expression<Func<Journal, bool>>>(whereDTO);

            //Mapper.Initialize(cfg => cfg.CreateMap<Journal, JournalDTO>());
            //List<JournalDTO> journals = Mapper.Map<List<Journal>, List<JournalDTO>>(service.FindAll(where).ToList());

            //List<JournalDTO> returnList = new List<JournalDTO>();
            //JournalDTO journalObj;

            //foreach (var item in journals)
            //{
            //    journalObj = item;
            //       UserDTO user = new UserService().GetUserById(item.PersonId);
            //    //EmployeeRealEstateView realEstate = new EmployeeRealEstateService()
            //        //.FilterEmployeeRealEstatesViewObject(new EmployeeRealEstateDTO {Id=item.EmployeeRealEstateId });
            //    journalObj.UserDto = user;
            //   // journalObj.RealEstateDto = realEstate.RealEstates.FirstOrDefault();
            //    returnList.Add(journalObj);

            //}


            //return returnList;
            return null;
        }

        public IEnumerable<JournalDTO> GetAllJournal()
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Journal, JournalDTO>());
            //List<JournalDTO> journals = Mapper.Map<List<Journal>, List<JournalDTO>>(service.FindAll().ToList());

            //List<JournalDTO> returnList = new List<JournalDTO>();
            //JournalDTO journalObj;

            //foreach (var item in journals)
            //{
            //    journalObj = item;
            //    UserDTO user = new UserService().GetUserById(item.PersonId);
            //    EmployeeRealEstateView realEstate = new EmployeeRealEstateService()
            //        .FilterEmployeeRealEstatesViewObject(new EmployeeRealEstateDTO { Id = item.EmployeeRealEstateId });
            //    journalObj.UserDto = user;
            //    journalObj.RealEstateDto = realEstate.RealEstates.FirstOrDefault();
            //    returnList.Add(journalObj);

            //}


            //return returnList;
            return null;
        }
        public JournalDTO GetJournalByExpression(Expression<Func<JournalDTO, bool>> whereDTO = null)
        {
            //UserDTO user = new UserDTO();
            //EmployeeRealEstateView realEstate = new EmployeeRealEstateView();
            //Mapper.Initialize(cfg => cfg.CreateMap<Journal, JournalDTO>());
            //Expression<Func<Journal, bool>> where = Mapper.Map<Expression<Func<Journal, bool>>>(whereDTO);

            //Mapper.Initialize(cfg => cfg.CreateMap<Journal, JournalDTO>());
            //JournalDTO journal = Mapper.Map<Journal, JournalDTO>(service.FindOne(where));

            //JournalDTO journalObj=null;
            //if (journal!=null)
            //{
            //    journalObj = journal;
            //    user = new UserService().GetUserById(journal.PersonId);
            //    realEstate = new EmployeeRealEstateService()
            //        .FilterEmployeeRealEstatesViewObject(new EmployeeRealEstateDTO { Id = journal.EmployeeRealEstateId });
            //    journalObj.UserDto = user;
            //    journalObj.RealEstateDto = realEstate.RealEstates.FirstOrDefault();
            //}
            //return journalObj;
            return null;
        }
        public JournalDTO GetJournalById(int idJournal)
        {
            //Mapper.Initialize(cfg => cfg.CreateMap<Journal, JournalDTO>());
            //JournalDTO journalObjectDto = Mapper.Map<Journal, JournalDTO>(service.FindById(idJournal));

            //JournalDTO journalObj;

            //journalObj = journalObjectDto;
            //UserDTO user = new UserService().GetUserById(journalObjectDto.PersonId);
            //EmployeeRealEstateView realEstate = new EmployeeRealEstateService()
            //    .FilterEmployeeRealEstatesViewObject(new EmployeeRealEstateDTO { Id = journalObjectDto.EmployeeRealEstateId });
            //journalObj.UserDto = user;
            //journalObj.RealEstateDto = realEstate.RealEstates.FirstOrDefault();

            //return journalObj;
            return null;
        }

        public List<JournalDTO> FilterJournals(JournalDTO journal)
        {
            //List<JournalDTO> list = Mapper.Map<List<Journal>, List<JournalDTO>>(service.FindAll().ToList());
            //if (journal.Id != 0) list = list.Where(x => x.Id == journal.Id).ToList();
            //if (journal.PersonId != 0) list = list.Where(x => x.PersonId == journal.PersonId).ToList();
            //if (journal.EmployeeRealEstateId != 0) list = list.Where(x => x.EmployeeRealEstateId == journal.EmployeeRealEstateId).ToList();
            //if (journal.DateRecord != null) list = list.Where(x => x.DateRecord == journal.DateRecord).ToList();
            //if (journal.DateViewRealEstate != null) list = list.Where(x => x.DateViewRealEstate == journal.DateViewRealEstate).ToList();
            //if (journal.JournalStateOrderId != 0) list = list.Where(x => x.JournalStateOrderId == journal.JournalStateOrderId).ToList();
            //return list;
            return null;
        }

        public int CreateJournal(JournalDTO journalDto)
        {
            //int EmployeeRealEstId = new EmployeeRealEstateService().GetEmployeesRealEstateByExpression(x => x.RealEstateId == journalDto.RealEstateId).Id;
            //journalDto.EmployeeRealEstateId = EmployeeRealEstId;
            //Mapper.Initialize(cfg => cfg.CreateMap<JournalDTO, Journal>());
            //Journal journal = Mapper.Map<JournalDTO, Journal>(journalDto);

            //return service.CreateItem(journal, x => x.PersonId == journal.PersonId && x.DateViewRealEstate == journal.DateViewRealEstate &&
            //x.EmployeeRealEstateId == journal.EmployeeRealEstateId).Id;
            return 0;
        }
        public bool UpdateJournal(JournalDTO journalDto)
        {
            //if (journalDto.RealEstateId != null)
            //{
            //    int EmployeeRealEstId = new EmployeeRealEstateService().GetEmployeesRealEstateByExpression(x => x.RealEstateId == journalDto.RealEstateId).Id;
            //    journalDto.EmployeeRealEstateId = EmployeeRealEstId;
            //}
            //Mapper.Initialize(cfg => cfg.CreateMap<JournalDTO, Journal>());
            //Journal journal = Mapper.Map<JournalDTO, Journal>(journalDto);

            //return service.UpdateItem(journal);
            return false;
        }

        public bool DeleteJournal(int idJournal)
        {
            return service.DeleteItem(idJournal);
        }
    }
}

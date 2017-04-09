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

namespace RealEstateAgencyWebPart.BLL.Services
{
    public class JournalStateOrderService: IJournalStateOrderService
    {
        GenericServiceEntity<OrderState> service = new GenericServiceEntity<OrderState>();

        public IEnumerable<JournalStateOrderDTO> GetAllRecordsJournalStateOrderByExpression(Expression<Func<JournalStateOrderDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderState, JournalStateOrderDTO>());
            Expression<Func<OrderState, bool>> where = Mapper.Map<Expression<Func<OrderState, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<OrderState, JournalStateOrderDTO>());
            List<JournalStateOrderDTO> JournalStateOrders = Mapper.Map<List<OrderState>, List<JournalStateOrderDTO>>(service.FindAll(where).ToList());

            return JournalStateOrders;
        }

        public IEnumerable<JournalStateOrderDTO> GetAllJournalStateOrders()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderState, JournalStateOrderDTO>());
            List<JournalStateOrderDTO> list = Mapper.Map<List<OrderState>, List<JournalStateOrderDTO>>(service.FindAll().ToList());

            return list;
        }
        public JournalStateOrderDTO GetJournalStateOrderByExpression(Expression<Func<JournalStateOrderDTO, bool>> whereDTO = null)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderState, JournalStateOrderDTO>());
            Expression<Func<OrderState, bool>> where = Mapper.Map<Expression<Func<OrderState, bool>>>(whereDTO);

            Mapper.Initialize(cfg => cfg.CreateMap<OrderState, JournalStateOrderDTO>());
            JournalStateOrderDTO JournalStateOrder = Mapper.Map<OrderState,JournalStateOrderDTO>(service.FindOne(where));

            return JournalStateOrder;
        }
        public JournalStateOrderDTO GetJournalStateOrderById(int idJournalStateOrder)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<OrderState, JournalStateOrderDTO>());
            JournalStateOrderDTO journalStateOrderDto = Mapper.Map<OrderState, JournalStateOrderDTO>(service.FindById(idJournalStateOrder));

            return journalStateOrderDto;
        }

        public List<JournalStateOrderDTO> FilterJournalStateOrders(JournalStateOrderDTO journalStateOrder)
        {
            List<JournalStateOrderDTO> list = Mapper.Map<List<OrderState>, List<JournalStateOrderDTO>>(service.FindAll().ToList());
            if (journalStateOrder.Id != 0) list = list.Where(x => x.Id == journalStateOrder.Id).ToList();
            if (journalStateOrder.JournalStateOrderName != null) list = list.Where(x => x.JournalStateOrderName == journalStateOrder.JournalStateOrderName).ToList();
            return list;
        }

        public int CreateJournalStateOrder(JournalStateOrderDTO journalStateOrderDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<JournalStateOrderDTO, OrderState>());
            OrderState journalStateOrder = Mapper.Map<JournalStateOrderDTO, OrderState>(journalStateOrderDto);

            return service.CreateItem(journalStateOrder, x => x.JournalStateOrderName == journalStateOrder.JournalStateOrderName).Id;
        }
        public bool UpdateJournalStateOrder(JournalStateOrderDTO journalStateOrderDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<JournalStateOrderDTO, OrderState>());
            OrderState journalStateOrder = Mapper.Map<JournalStateOrderDTO, OrderState>(journalStateOrderDto);

            return service.UpdateItem(journalStateOrder);
        }
        public bool DeleteJournalStateOrder(int idJournalStateOrder)
        {
            return service.DeleteItem(idJournalStateOrder);
        }
    }
}

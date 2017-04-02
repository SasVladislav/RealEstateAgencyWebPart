using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IJournalStateOrderService
    {
        IEnumerable<JournalStateOrderDTO> GetAllJournalStateOrders();
        JournalStateOrderDTO GetJournalStateOrderById(int idJournalStateOrder);
        IEnumerable<JournalStateOrderDTO> GetAllRecordsJournalStateOrderByExpression(Expression<Func<JournalStateOrderDTO, bool>> whereDTO = null);
        JournalStateOrderDTO GetJournalStateOrderByExpression(Expression<Func<JournalStateOrderDTO, bool>> whereDTO = null);
        List<JournalStateOrderDTO> FilterJournalStateOrders(JournalStateOrderDTO journalStateOrder);
        int CreateJournalStateOrder(JournalStateOrderDTO journalStateOrderDto);
        bool UpdateJournalStateOrder(JournalStateOrderDTO journalStateOrderDto);
        bool DeleteJournalStateOrder(int idJournalStateOrder);
    }
}

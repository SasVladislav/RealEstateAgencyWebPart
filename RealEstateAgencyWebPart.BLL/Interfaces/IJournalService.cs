using RealEstateAgencyWebPart.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgencyWebPart.BLL.Interfaces
{
    public interface IJournalService
    {
        IEnumerable<JournalDTO> GetAllJournal();
        IEnumerable<JournalDTO> GetAllRecordsJournalByExpression(Expression<Func<JournalDTO, bool>> whereDTO = null);
        JournalDTO GetJournalById(int idJournal);
        JournalDTO GetJournalByExpression(Expression<Func<JournalDTO, bool>> whereDTO = null);
        List<JournalDTO> FilterJournals(JournalDTO journal);
        int CreateJournal(JournalDTO journalDto);
        bool UpdateJournal(JournalDTO JournalDto);
        bool DeleteJournal(int idJournal);
    }
}

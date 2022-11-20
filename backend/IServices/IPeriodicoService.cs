using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.IServices
{
    public interface IPeriodicoService
    {
        Periodicos Add(Periodicos oPeriodicos);
        
        List<Periodicos> Gets();

        Periodicos Get(int PeriodicoId);

        string Delete(int PeriodicoId);

        Periodicos Update(Periodicos oPeriodicos);
    }
}
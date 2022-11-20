using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.IServices
{
    public interface IRevistaService
    {
        Revistas Add(Revistas oRevistas);
        
        List<Revistas> Gets();

        Revistas Get(int RevistaId);

        string Delete(int RevistaId);

        Revistas Update(Revistas RevistaId);
    }
}

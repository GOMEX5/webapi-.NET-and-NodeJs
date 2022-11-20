using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.IServices
{
    public interface IHistorialService
    {
        Historials Add(Historials oHistorials);
        
        List<Historials> Gets();

        Historials Get(int HistorialId);

        string Delete(int HistorialId);

        Historials Update(Historials oHistorials);
    }
}

using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BackEnd.IServices
{
    public interface IAudioLibroService
    {
        AudioLibros Add(AudioLibros oAudioLibros);
        
        List<AudioLibros> Gets();

        AudioLibros Get(int IdAudioLibros);

        string Delete(int IdAudioLibros);

        AudioLibros Update(AudioLibros oAudioLibros);
    }
}

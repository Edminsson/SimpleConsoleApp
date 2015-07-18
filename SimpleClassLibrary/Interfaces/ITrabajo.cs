using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleClassLibrary.Interfaces
{
    public interface ITrabajo
    {
        void Trabaja(IProgress<int> progress, FileStream stream);
        void WriteToLog(string message, int level);
        List<int> GetFavoriteNumbers(int id, string name);
        List<string> ListaDeTrabajos { get; set; }
    }
}

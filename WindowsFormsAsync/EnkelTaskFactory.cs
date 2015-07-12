using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAsync
{
    public class EnkelTaskFactory
    {
        public EnkelTaskFactory()
        {
        }

        public async Task<List<string>> Starta()
        {
            List<string> lista = new List<string> { "uno","dos","tres"};
            await Task.Delay(3000).ConfigureAwait(false);
            return lista;
        }

    }
}

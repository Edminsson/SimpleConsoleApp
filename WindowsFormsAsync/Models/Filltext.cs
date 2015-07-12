using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAsync.Models
{
    public class Nombre
    {
        public string f { get; set; }
    }
    public class Filltext
    {
        public static async Task<List<string>> GetNames(int count)
        {
            HttpClient client = new HttpClient();
            var uri = "http://www.filltext.com/?rows=2&f={firstName}";
            //var uri = string.Format("http://www.filltext.com/?rows={0}&f={firstName}",count);
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode(); //kastar undantag om det finns fel;
            var jsonString = await response.Content.ReadAsStringAsync();
            var namnlista = JsonConvert.DeserializeObject<List<Nombre>>(jsonString);
            var tradinfo = string.Format(" [{0}]{1:HH:mm:ss.fff} ",Thread.CurrentThread.ManagedThreadId, DateTime.Now);

            return namnlista.Select(x => x.f+tradinfo).ToList();
        }

    }
}

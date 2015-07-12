using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAsync.Models
{
    public class WebCallLoop
    {
        public async Task<string[]> Starta()
        {
            List<string> resultatLista = new List<string>();
            resultatLista.Add(string.Format("Startar: {0:HH:mm:ss.fff}", DateTime.Now));

            List<string> adresses = getAdresses();

            foreach(var adress in adresses)
            {
                resultatLista.Add(await GetWebSiteStart(adress));
            }

            resultatLista.Add(string.Format("Slutar: {0:HH:mm:ss.fff}", DateTime.Now));
            return resultatLista.ToArray();
        }

        public async Task<string[]> StartaMedWhenAll()
        {
            List<string> resultatLista = new List<string>();
            resultatLista.Add(string.Format("Startar: {0:HH:mm:ss.fff}", DateTime.Now));

            List<string> adresses = getAdresses();
            var tasks = adresses.Select(s => GetWebSiteStart(s));
            var resultat = await Task.WhenAll(tasks);
            resultatLista.AddRange(resultat);

            resultatLista.Add(string.Format("Slutar: {0:HH:mm:ss.fff}", DateTime.Now));
            return resultatLista.ToArray();
        }

        private async Task<string> GetWebSiteStart(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string tradinfo = string.Format("Tråd: {0}. Tid: {1:HH:mm:ss.fff}", Thread.CurrentThread.ManagedThreadId, DateTime.Now);
            var uri = string.Format("http://{0}",url);
            var str = await client.DownloadStringTaskAsync(uri);
            var titleStart = str.IndexOf("<title>");
            var titleEnd = str.IndexOf("</title>");
            var titleLength = titleEnd - (titleStart + 7) ;
            var displayString = str.Substring(0, 50);
            if (titleStart > 0 && titleEnd > titleStart)
                displayString = str.Substring(titleStart + 7, titleLength).Trim().ToString(CultureInfo.CurrentCulture);
            displayString += " - " + tradinfo;

            return displayString;
        }

        private List<string> getAdresses()
        {
            return new List<string> 
            { 
                "www.riksarkivet.se", 
                "www.lu.se", 
                "www.dn.se",
                "www.aftonbladet.se", 
                "www.expressen.se", 
                "google.com"
            };
        }

    }
}

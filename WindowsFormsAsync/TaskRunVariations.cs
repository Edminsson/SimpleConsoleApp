using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsAsync
{
    public class TaskRunVariations
    {
        Random random = new Random();
        public async Task<string> GetStrAsync()
        {
            for (int i = 0; i < 3; i++)
            {
                await Task.Delay(1000);
            }
            var randomNo = random.Next(1, 1000);
            return string.Format("GetStrAsync.{0}", randomNo);
        }

        public Task<string> AltGetStrAsync()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                }
                var randomNo = random.Next(1, 1000);
                return string.Format("AltGetStrAsync.{0}", randomNo);
            });
        }

        public async Task<string> Alt2GetStrAsync()
        {
            var res = await Task.Run(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                }
                var randomNo = random.Next(1, 1000);
                return string.Format("Alt2GetStrAsync.{0}", randomNo);
            });

            return res;
        }

        public string GetStr()
        {
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
            }
            var randomNo = random.Next(1, 1000);
            return string.Format("GetStr.{0}", randomNo);
        }

    }
}

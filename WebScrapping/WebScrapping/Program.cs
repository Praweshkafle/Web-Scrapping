using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapping
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectAndParseHtml();
        }


        static void ConnectAndParseHtml()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://yts.mx/");

            var Datalist = new List<string>();

            foreach (var data in doc.DocumentNode.SelectNodes("//a[@class='browse-movie-title']"))
            {
                Datalist.Add(data.InnerText);
            }
            Datalist.ForEach(a => Console.WriteLine(a));
            WriteDataToTextFile(Datalist);
        }


        static void WriteDataToTextFile(List<string> DataList)
        {
            var stringBuilder = new StringBuilder();

            foreach (var item in DataList)
            {
               stringBuilder.AppendLine(item);
            }

            File.WriteAllText("C://Users/PraweshRajKhapangi/Desktop/example.csv", stringBuilder.ToString());
        } 
    }
}

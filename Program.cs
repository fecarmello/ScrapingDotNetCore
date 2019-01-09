using HtmlAgilityPack;
using System;

namespace Scraping
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var html = "https://support.apple.com/kb/SP776?locale=pt_BR&viewlocale=pt_BR";

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var nome = htmlDoc.DocumentNode
                                .SelectSingleNode("//*[@id='main-title']")
                                .InnerText;
            Console.WriteLine($"Produto: {nome}");
            Console.WriteLine("");

            //Cor
            Console.WriteLine("## COR ##");
            var corArray = htmlDoc.DocumentNode
                                    .SelectSingleNode("//*[@id='articlecontent']/div/ul[2]")
                                    .InnerText
                                    .Replace("\t", "")
                                    .Replace("\n", ";")
                                    .Split(";");
            for (int i = 0; i < corArray.Length; i++)
            {
                if (!corArray[i].Equals(""))
                    Console.WriteLine(corArray[i]);
            }
            Console.WriteLine("");

            //Processador
            Console.WriteLine("## PROCESSADOR ##");
            var processadorArray = htmlDoc.DocumentNode
                                            .SelectSingleNode("//*[@id='articlecontent']/div/ul[4]")
                                            .InnerText
                                            .Replace("\t", "")
                                            .Replace("\n", ";")
                                            .Split(";");
            for (int i = 0; i < processadorArray.Length; i++)
            {
                if (!processadorArray[i].Equals(""))
                    Console.WriteLine(processadorArray[i]);
            }

            Console.ReadKey();
        }
    }
}
﻿using Microsoft.Recognizers.Text;
using System.Text;
using TR.Engine.Contract;
using TR.Engine.Utilities;

namespace TR.Engine.Services
{
    public class PdfParserService : IPdfParserService
    {
        public Dictionary<string, IEnumerable<ModelResult>> Execute(List<string> output, int randomAmount, string culture)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var rnd = new Random();
            var narrowed = output.OrderBy(x => rnd.Next()).Take(randomAmount).ToList();

            var dic = new Dictionary<string, IEnumerable<ModelResult>>();
            foreach (var item in narrowed)
            {
                var results = PdfParserUtility.ParseAll(item, culture);
                dic.Add(item, results);
            }

            return dic;
        }
    }
}

﻿using Microsoft.Recognizers.Text;
using System.Text;
using TR.Engine.Contract;
using TR.Engine.Utilities;

namespace TR.Engine.Services
{
    public class PdfParserService : IPdfParserService
    {
        public Dictionary<string, IEnumerable<ModelResult>> Execute(List<string> input, int randomAmount, string culture, string strategyName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var narrowed = LanguageDetectionStrategy.ResolveStrategy(strategyName, input, randomAmount);

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

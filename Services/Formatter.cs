using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrFormatter.Services
{
    public class Formatter
    {


        public async Task Format(string path)
        {
            string fileName = Path.GetFileName(path);
            string newPath = path.Substring(0, path.Length - fileName.Length) + "copy" + fileName;

            string id = fileName.Substring(0, 5);


            Console.WriteLine(newPath);


            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var scrEncoding = Encoding.GetEncoding("windows-1251");

            string? text;
            List<string> lines = new();

            using (var reader = new StreamReader(path, encoding: scrEncoding))
            {
                try
                {
                    while ((text = await reader.ReadLineAsync()) != null)
                    {
                        if (text.StartsWith("="))
                        {
                            lines.Add(text);
                            break;
                        }
                        int countChar = 0;
                        int countPoint = 0;
                        foreach (var t in text)
                        {
                            countPoint++;
                            if (t == ';')
                            {
                                countChar++;
                                if (countChar == 5)
                                {
                                    text = text.Insert(countPoint, id);
                                    break;
                                }
                            }
                        }
                        lines.Add(text);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            using (var writer = new StreamWriter(newPath, false))
            {
                foreach (var line in lines)
                {
                    await writer.WriteLineAsync(line);
                }
            }
        }
    }
}

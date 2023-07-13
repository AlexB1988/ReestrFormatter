using ReestrFormatter.Interfaces;
using System.Text;

namespace ReestrFormatter.Services
{
    public class TnsFormatter : IFormatter
    {
        public int Format(string path, string id)
        {
            if (id == "532_1302")
            {
                id = "30483";
            }
            string fileName = Path.GetFileName(path);
            string newPath = path.Substring(0, path.Length - fileName.Length) + "copy" + fileName;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var scrEncoding = Encoding.GetEncoding("windows-1251");

            string? text;
            List<string> lines = new();

            using (var reader = new StreamReader(path, encoding: scrEncoding))
            {
                try
                {
                    while ((text = reader.ReadLine()) != null)
                    {
                        int countChar = 0;
                        int countPoint = 0;

                        foreach (var t in text)
                        {
                            countPoint++;
                            if (t == ';')
                            {
                                countChar++;
                                if (countChar == 2)
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
                    writer.WriteLine(line);
                }

                return 1;
            }
        }
    }
}

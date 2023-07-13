using ReestrFormatter.Interfaces;
using System.Text;

namespace ReestrFormatter.Services
{
    public class PochtaFormatter : IFormatter
    {
        public int Format(string path, string id)
        {
            if (id == "1984_" || id == "1985_")
            {
                id = "30483";
            }
            else if (id == "1856_" || id == "1857_")
            {
                id = "30473";
            }
            else if (id == "1986_")
            {
                id = "30541";
            }
            else if (id == "1987_")
            {
                id = "30542";
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
                        if (text.StartsWith("="))
                        {
                            lines.Add(text);
                            break;
                        }
                        int countChar = 0;
                        int countPoint = 0;
                        if (text.StartsWith("1"))
                        {
                            foreach (var t in text)
                            {
                                countPoint++;
                                if (t == ';')
                                {
                                    countChar++;
                                    if (countChar == 1)
                                    {
                                        text = text.Insert(countPoint, id);
                                    }
                                }
                            }
                        }
                        if (text.StartsWith("2"))
                        {
                            foreach (var t in text)
                            {
                                countPoint++;
                                if (t == ';')
                                {
                                    countChar++;
                                    if (countChar == 1)
                                    {
                                        text = text.Insert(countPoint, id);
                                        break;
                                    }
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
            }
            return 1;
        }
    }
}

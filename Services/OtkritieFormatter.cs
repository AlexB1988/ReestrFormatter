using ReestrFormatter.Interfaces;
using System.Text;

namespace ReestrFormatter.Services
{
    public class OtkritieFormatter : IFormatter
    {
        public int Format(string path, string id)
        {           
            if (id == "krylo")
            {
                id = "30483";
            }
            else if (id == "novop")
            {
                id = "30541";
            }
            else if (id == "okt07")
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
                        text = id + text;
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

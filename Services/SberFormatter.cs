using ReestrFormatter.Interfaces;
using System.Text;

namespace ReestrFormatter.Services
{
    public class SberFormatter : IFormatter
    {
        //public string PathName { get; set; }
        //public SberFormatter( string path)
        //{
        //    PathName = path;
        //}
        public int Format(string path,string id)
        {
            string fileName = Path.GetFileName(path);
            string newPath = path.Substring(0, path.Length - fileName.Length) + "copy" + fileName;

            //string id = fileName.Substring(0, 5);
            //Замена сберовского идентификатора
            if (id == "30538")
            {
                id = "30473";
            }

            Console.WriteLine(newPath);


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
                    writer.WriteLine(line);
                }

                return 1;
            }

    }   }
}

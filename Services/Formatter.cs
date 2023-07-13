using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReestrFormatter.Services
{
    public class Formatter
    {
        
        public int  Format(string path)
        {
            string fileName = Path.GetFileName(path);
            string newPath = path.Substring(0, path.Length - fileName.Length) + "copy" + fileName;

            string id = fileName.Substring(0, 5);
            string bank = "sber";
            //Замена сберовского идентификатора
            if (id == "30538")
            {
                id = "30473";
            }
            //Замена Кубань-Кредита (не хватает ещё 2-ух) 
            else if (id == "22456")
            {
                id = "30483";
                bank = "kuban";
            }
            else if (id == "65824")
            {
                id = "30473";
                bank = "kuban";
            }

            //Замена для Почта-банка
            else if (id == "1856_" ||id=="1857_")
            {
                id = "30473";
                bank = "pochta";
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
                        if (bank == "pochta" && text.StartsWith("1"))
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
                        if (bank == "pochta" && text.StartsWith("2"))
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
                        else
                        {
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

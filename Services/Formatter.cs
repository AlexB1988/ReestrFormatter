using System.Text;

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
            else if (id == "1984_" || id == "1985_")
            {
                id = "30483";
                bank = "pochta";
            }
            else if (id == "1856_" ||id=="1857_")
            {
                id = "30473";
                bank = "pochta";
            }
            else if (id == "1986_")
            {
                id = "30541";
                bank = "pochta";
            }
            else if (id == "1987_")
            {
                id = "30542";
                bank = "pochta";
            }

            //Замена для РНКБ
            else if (id == "Krl_0")
            {
                id = "30483";
                bank = "rnkb";
            }
            else if (id == "Len_7")
            {
                id = "30473";
                bank = "rnkb";
            }
            else if(id== "Novop")
            {
                id = "30541";
                bank = "rnkb";
            }
            else if (id == "Okt_0")
            {
                id = "30542";
                bank = "rnkb";
            }

            //Замена для банка Открытие

            else if (id == "krylov")
            {
                id = "30483";
                bank = "otkr";
            }
            else if (id == "novopl")
            {
                id = "30541";
                bank = "otkr";
            }
            else if (id == "okt07_")
            {
                id = "30542";
                bank = "otkr";
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
                        if (bank == "rnkb" ||bank=="otkr")
                        {
                            text = id + text;
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

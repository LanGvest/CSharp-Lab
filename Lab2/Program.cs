using System.Text.RegularExpressions;
string value = "У меня 10 долларов, 13 яблок, 255 апельсинов.";
Console.WriteLine("Исходный текст: {0}", value);
Console.WriteLine("Преобразованный текст: {0}", Regex.Replace(
    value, @"\d+",
    match => Convert.ToString(int.Parse(match.Value), 16).ToUpper())
);
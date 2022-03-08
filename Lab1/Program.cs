string value = "У меня 10 долларов, 13 яблок, 255 апельсинов.";
string[] words = value.Split(' ');
for (int i = 0; i < words.Length; i++)
    if (int.TryParse(words[i], out int num))
        words[i] = Convert.ToString(num, 16).ToUpper();
Console.WriteLine("Исходный текст: {0}", value);
Console.WriteLine("Преобразованный текст: {0}", string.Join(' ', words));
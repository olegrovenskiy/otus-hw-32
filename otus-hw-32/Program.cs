using System.IO;
using System.Text;
using System.Xml.Linq;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// 1.  Создать директории c:\Otus\TestDir1 и c:\Otus\TestDir2 с помощью класса DirectoryInfo


var dir1 = new DirectoryInfo("c:\\Otus\\TestDir1");
var dir2 = new DirectoryInfo("c:\\Otus\\TestDir2");

dir1.Create();
dir2.Create();


// 2. В каждой директории создать несколько файлов File1...File10 с помощью класса File.




    for (int i = 1; i < 11; i++)
    {
        File.Create("c:\\Otus\\TestDir1\\file" + i).Close();
        File.Create("c:\\Otus\\TestDir2\\file" + i).Close();
    }



// 3. В каждый файл записать его имя в кодировке UTF8. Учесть, что файл может быть удален, либо отсутствовать права на запись.
// Учесть, что файл может быть удален , либо отсутствовать права на запись - для этого переоткрываем и даём права на запись



for (int i = 1; i < 11; i++)

{

    File.Open($"c:\\Otus\\TestDir1\\file{i}", FileMode.OpenOrCreate, FileAccess.Write).Close();
    File.Open($"c:\\Otus\\TestDir2\\file{i}", FileMode.OpenOrCreate, FileAccess.Write).Close();

    File.WriteAllText($"c:\\Otus\\TestDir1\\file{i}", $"file{i}", Encoding.UTF8);
    File.WriteAllText($"c:\\Otus\\TestDir2\\file{i}", $"file{i}", Encoding.UTF8);

    //4. Каждый файл дополнить текущей датой (значение DateTime.Now) любыми способами: синхронно и\или асинхронно.

    File.AppendAllText($"c:\\Otus\\TestDir1\\file{i}", ("   Date Time  " + DateTime.Now.ToString()));
    File.AppendAllText($"c:\\Otus\\TestDir2\\file{i}", ("   Date Time  " + DateTime.Now.ToString()));

}

//5. Прочитать все файлы и вывести на консоль: имя_файла: текст + дополнение.

for (int i = 1; i < 11; i++)

{

    Console.WriteLine(File.ReadAllText("c:\\Otus\\TestDir1\\file" + i));
    Console.WriteLine(File.ReadAllText("c:\\Otus\\TestDir2\\file" + i));
}

Console.ReadKey();
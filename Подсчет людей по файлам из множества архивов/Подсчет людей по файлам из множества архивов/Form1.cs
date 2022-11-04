using Aspose.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Подсчет_людей_по_файлам_из_множества_архивов
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTN_Open_and_Count_Click(object sender, EventArgs e)//Метод включает в себя извлечение данных из необходимых архивов.
        {
            string[] ArchiveFilesPath;
            string ArchiveFileName;
            string fileDirectory;
            int All_counter=0;

            //Установка свойств объекта openFileDialog для выбора нескольких архивов в папке с датами
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Archive files (*.rar)|*.rar|Archive files (*.zip)|*.zip";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Multiselect = true;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {             
                ArchiveFilesPath = openFileDialog.FileNames;//Список всех выбранных архивов
                FileInfo fileInfo = new FileInfo(ArchiveFilesPath[0]);
                fileDirectory = fileInfo.DirectoryName;//Путь к выбранным архивам
                fileInfo = new FileInfo(fileDirectory);
                string Data = fileInfo.Name;
                Result_rtb.Text="Количество людей за " + Data + ":\n";

                for (int i=0; i < ArchiveFilesPath.Length; i++)//Цикл обработки каждого архива
                {
                    ArchiveFileName = openFileDialog.SafeFileNames[i].Remove(openFileDialog.SafeFileNames[i].Length - 4);//Имя архива для определения принадлежности количества к архиву
                    string SpisokName = fileDirectory + "\\Spisok_" + ArchiveFileName + "_.txt";//Имя для создаваемого промежуточного обрабатываемого файла
                    using (Archive archive = new Archive(ArchiveFilesPath[i]))//Использование сторонней библиотеки Aspose.Zip, позволяющей извлекать данные файлов из архивов
                    {
                        // Создайте файл с помощью метода Create().
                        using (var destination = File.Create(SpisokName))//Создается промежуточный файл. Способ взят из официальных примеров использования библиотеки, в сущности, можно было бы обрабатывать сразу поток байт.
                        {
                            // Откройте запись из архива RAR. Файл выбирается в зависимости от порядка записи на архив (???).
                            using (var source = archive.Entries[40].Open())
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                // Запись извлеченных данных в файл.
                                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                                 destination.Write(buffer, 0, bytesRead);
                            }
                        }
                    }
                    All_counter+=Spisok_Handler(SpisokName, ArchiveFileName);//Подсчет общего числа людей
                    File.Delete(SpisokName);//Удаление промежуточных файлов
                }
                Result_rtb.AppendText("\nОбщее число людей: " + All_counter);
            }
        }

        private int Spisok_Handler(string SpisokName, string ArchiveFileName)//Обрабатывает файл с входящим именем для подсчета людей-строк
        {
            int counter=0;
            foreach (string line in System.IO.File.ReadLines(SpisokName))//Для каждой строки в промежуточном файле счетчик увеличивается на 1
            {
                counter++;
            }
            Result_rtb.AppendText(ArchiveFileName + ": " + counter + "\n");
            return counter;
        }
    }
}

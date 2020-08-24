using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    class Program
    {
        static void Main(string[] args)
        {


            string[] fullName = new string[0];
            string[] position = new string[0];
            int serialNumber = 0;

            bool isOpen = true;
            while (isOpen)
            {

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Ввыберите команду: \n 1) добавить досье." +
                    $"\n 2) вывести всё досье\n " +
                    $"3) удалить досье\n " +
                    $"4) поиск по фамилии\n " +
                    $"5) выход.");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddDossier(ref fullName, ref position);
                        break;
                    case 2:
                        if (fullName.Length > 0 || position.Length > 0)
                        {
                            DrawDossier(fullName, position, ref serialNumber);
                        }
                        else
                        {
                            Console.WriteLine("Досье не заполнено!");
                        }
                        PressKey();
                        break;
                    case 3:
                        Console.Write("Введите номер досье которое хотите удалить: ");
                        int serialNumberDossier = Convert.ToInt32(Console.ReadLine()) - 1;
                        RemoveDossier(ref fullName, ref serialNumberDossier);
                        RemoveDossier(ref position, ref serialNumberDossier);
                        break;
                    case 4:
                        SearchByName(fullName);
                        break;
                    case 5:
                        Exit(ref isOpen);
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullName, ref string[] position)
        {
            Console.WriteLine("Введите Вашу Фамилию, имя, отчество: ");
            FillDossier(ref fullName);
            Console.WriteLine("Введите Вашу должность: ");
            FillDossier(ref position);
            PressKey();
        }

        static void DrawDossier(string[] fullName, string[] position, ref int serialNumber)
        {
            serialNumber = 0;
            for (int i = 0; i < fullName.Length; i++)
            {
                if (serialNumber < fullName.Length)
                {
                    ++serialNumber;
                }
                Console.WriteLine($"{serialNumber}.{fullName[i]} - {position[i]} ");
            }
        }

        static void RemoveDossier(ref string[] DossierData, ref int serialNumberDossier)
        {
            string[] newFullNameOrPosition = new string[DossierData.Length - 1];

            for (int i = 0; i < serialNumberDossier; i++)
            {
                newFullNameOrPosition[i] = DossierData[i];
            }
            for (int i = serialNumberDossier + 1; i < DossierData.Length; i++)
            {
                newFullNameOrPosition[i - 1] = DossierData[i];
            }
            DossierData = newFullNameOrPosition;
            PressKey();
        }

        static void SearchByName(string[] fullName)
        {
            bool surnameIsFind = false;
            Console.WriteLine("Введите фамилию, которую хотите найти: ");
            string userInput = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {

                string fullNameWorker = fullName[i];
                string[] splited = fullNameWorker.Split(' ');
                string surname = splited[0];
                if (userInput.ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"Фамилия: {surname} - есть в досье!");
                    surnameIsFind = true;
                }
            }
            if (!surnameIsFind)
            {
                Console.WriteLine("Такой фамилии в досье нет!");
            }

            PressKey();
        }

        static void Exit(ref bool isOpen)
        {
            isOpen = false;
            Console.WriteLine("До скорых встреч!");
            PressKey();
        }

        static void FillDossier(ref string[] dossierData)
        {
            string[] fullNameWorkerOrPosition = new string[dossierData.Length + 1];
            
            for (int i = 0; i < dossierData.Length; i++)
            {
                fullNameWorkerOrPosition[i] = dossierData[i];
            }
            fullNameWorkerOrPosition[fullNameWorkerOrPosition.Length - 1] = Console.ReadLine();
            dossierData = fullNameWorkerOrPosition;
        }


        static void PressKey()
        {
            Console.WriteLine("Для продолжения нажмите любую клавишу!");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

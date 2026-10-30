using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Program
    {
        private static List<Department> allDepartments = new List<Department>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2 — МЕНЮ");
                Console.WriteLine("==============================");
                Console.WriteLine("1. 1.2 — Рост и имя");
                Console.WriteLine("2. 1.3 — ФИО");
                Console.WriteLine("3. 2.4 — Создать отделы и сотрудников");
                Console.WriteLine("4. 3.4 — Выбор отдела, коллеги и начальник");
                Console.WriteLine("5. 4.5 — ФИО");
                Console.WriteLine("6. 5.1 — Пистолет");
                Console.WriteLine("0. Выход из программы");
                Console.WriteLine("==============================");
                Console.Write("Выберите номер задачи (0-6): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "0")
                {
                    Console.WriteLine("Выход из программы. До свидания!");
                    break;
                }

                switch (choice)
                {
                    case "1":
                        RunHumanTask();
                        break;
                    case "2":
                        RunFioTask();
                        break;
                    case "3":
                        RunCreateDepartmentsTask(); 
                        break;
                    case "4":
                        RunDepartmentManagementTask(); 
                        break;
                    case "5":
                        RunFioTask45();
                        break;
                    case "6":
                        RunPistoletTask();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор! Пожалуйста, выберите от 0 до 6.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню...");
                Console.ReadKey();
            }
        }

        static void RunHumanTask()
        {
            Console.WriteLine("--- Задание 1.2 ---");
            
            Console.Write("Введите имя человека: ");
            string name = Console.ReadLine();

            Console.Write("Введите рост (см): ");
            int height = 0;

            bool isCorrect = 
                int.TryParse(Console.ReadLine(), out height) && 
                height >= 120 && 
                height <= 300;

            while (!isCorrect)
            {
                Console.Write(
                    "Ошибка! Введите рост " +
                    "от 120 до 300: "
                );
                
                isCorrect = 
                    int.TryParse(Console.ReadLine(), out height) && 
                    height >= 120 && 
                    height <= 300;
            }

            Human human = new Human(name, height);
            Console.WriteLine("\nСозданный объект:");
            Console.WriteLine(human);
        }

        static void RunFioTask()
        {
            Console.WriteLine("--- Задание 1.3 ---");
            
            Console.Write("Введите фамилию (или оставьте пустой): ");
            string lastName = Console.ReadLine();

            Console.Write("Введите личное имя (или оставьте пустым): ");
            string firstName = Console.ReadLine();

            Console.Write("Введите отчество (или оставьте пустым): ");
            string middleName = Console.ReadLine();

            FullName fio;

            if (string.IsNullOrWhiteSpace(lastName) &&
            string.IsNullOrWhiteSpace(firstName) &&
            string.IsNullOrWhiteSpace(middleName))
            {
                fio = new FullName();
            }
            else if (string.IsNullOrWhiteSpace(lastName) && 
            string.IsNullOrWhiteSpace(middleName))
            {
                fio = new FullName(firstName);
            }
            else if (string.IsNullOrWhiteSpace(middleName))
            {
                fio = new FullName(lastName, firstName);
            }
            else
            {
                fio = new FullName(lastName, firstName, middleName);
            }

            Console.WriteLine("\nРезультат форматирования ФИО:");
            Console.WriteLine(fio);
        }

        static void RunCreateDepartmentsTask()
        {
            Console.WriteLine("--- Задание 2.4: Создание отделов и сотрудников ---");

            while (true)
            {
                Console.Write("\nВведите название нового отдела " + 
                "(или Enter для выхода в меню): ");
                string deptName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(deptName))
                {
                    break;
                }

                Department department = new Department(deptName);
                List<Employee> departmentEmployees = new List<Employee>();
                
                Console.WriteLine($"Вводите сотрудников для отдела '{deptName}'. " +
                                "Для завершения оставьте строку пустой.");

                while (true)
                {
                    Console.Write("  Имя сотрудника: ");
                    string empName = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(empName))
                    {
                        break;
                    }

                    Employee emp = new Employee(empName, department);
                    department.AddEmployee(emp);
                    departmentEmployees.Add(emp);
                }

                if (departmentEmployees.Count > 0)
                {
                    Console.Write($"\nХотите назначить начальника " +
                    $"для отдела '{deptName}'? (y/n): ");
                    string choice = Console.ReadLine()?.Trim().ToLower();

                    if (choice == "y")
                    {
                        Console.WriteLine("Список сотрудников отдела:");
                        for (int i = 0; i < departmentEmployees.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {departmentEmployees[i].Name}");
                        }

                        Console.Write("Введите номер сотрудника для назначения начальником: ");
                        if (int.TryParse(Console.ReadLine(), out int index) && 
                            index >= 1 && index <= departmentEmployees.Count)
                        {
                            departmentEmployees[index - 1].MakeManager();
                            Console.WriteLine($"Успешно! {departmentEmployees[index - 1].Name}" +
                            $"назначен начальником отдела '{deptName}'.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер." + 
                            "Никто не назначен начальником по умолчанию.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("В отдел не было добавлено ни одного сотрудника.");
                }

                allDepartments.Add(department);
                Console.WriteLine($"Отдел '{deptName}' успешно сохранен в систему!");
            }

            Console.WriteLine($"\nВсего создано отделов в системе: {allDepartments.Count}");
        }

        static void RunDepartmentManagementTask()
        {
            Console.WriteLine("--- Задание 3.4: Выбор сотрудника и проверка коллег ---");

            if (allDepartments.Count == 0)
            {
                Console.WriteLine("Сначала выполните пункт 3 (2.4) " +
                "и создайте хотя бы один отдел с сотрудниками!");
                return;
            }

            List<Employee> allEmployees = new List<Employee>();
            foreach (var dept in allDepartments)
            {
                allEmployees.AddRange(dept.Employees);
            }

            if (allEmployees.Count == 0)
            {
                Console.WriteLine("В созданных отделах пока нет ни одного сотрудника.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\nОбщий список всех сотрудников:");
                for (int i = 0; i < allEmployees.Count; i++)
                {
                    var emp = allEmployees[i];
                    Console.WriteLine($"{i + 1}. {emp.Name} ({emp.Position})");
                }

                Console.WriteLine("\n0. Вернуться в главное меню");
                Console.Write("Введите номер сотрудника для просмотра его коллег: ");

                string input = Console.ReadLine();
                if (input == "0")
                {
                    break;
                }

                if (int.TryParse(input, out int empIndex) && empIndex >= 1 && 
                empIndex <= allEmployees.Count)
                {
                    Employee selectedEmp = allEmployees[empIndex - 1];
                    
                    List<Employee> colleagues = selectedEmp.GetDepartmentEmployees();

                    Console.WriteLine($"\nВыбран сотрудник: {selectedEmp.Name} " +
                    $"(отдел '{selectedEmp.Department.Name}')");
                    Console.WriteLine("Его коллеги по отделу:");
                    
                    foreach (var colleague in colleagues)
                    {
                        Console.WriteLine($"- {colleague.Name} ({colleague.Position})");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный номер сотрудника, попробуйте снова.");
                }
            }
        }

        static void RunFioTask45()
        {
            Console.WriteLine("--- Задача 4.5 ---");
            Console.Write("Введите ФИО (необязательно полное): ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Ничего не введено.");
                return;
            }

            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            FullName fio;

            if (parts.Length == 1)
            {
                fio = new FullName(parts[0]);
            }
            else if (parts.Length == 2)
            {
                fio = new FullName(parts[1], parts[0]);
            }
            else
            {
                fio = new FullName(parts[2], parts[0], parts[1]);
            }

            Console.WriteLine("\nСформированное имя:");
            Console.WriteLine(fio);
        }

        static void RunPistoletTask()
        {
            Console.WriteLine("--- Задача 5.1 ---");
            Console.Write("Введите количество патронов (Enter для дефолта): ");
            string input = Console.ReadLine();

            Pistolet pistol;

            if (string.IsNullOrWhiteSpace(input))
            {
                pistol = new Pistolet();
                Console.WriteLine("Пистолет создан с дефолтными патронами (5).");
            }
            else if (int.TryParse(input, out int ammo))
            {
                pistol = new Pistolet(ammo);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Создан пистолет с 5 патронами.");
                pistol = new Pistolet();
            }

            Console.WriteLine($"\nПатронов в магазине: {pistol.Ammocount}");
            Console.Write("Сколько выстрелов сделать? Введите число: ");
            
            if (int.TryParse(Console.ReadLine(), out int shots) && shots > 0)
            {
                Console.WriteLine("\nСтрельба:");
                for (int i = 0; i < shots; i++)
                {
                    pistol.Shoot();
                }
            }
            else
            {
                Console.WriteLine("Неверное количество выстрелов.");
            }

            Console.WriteLine($"Осталось патронов: {pistol.Ammocount}");
        }
    }
}

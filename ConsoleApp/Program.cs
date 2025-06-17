using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

bool isWhile = true;
bool salaryConfirm = true;
int choice = 0;
double salaryPerHour = 0;
while(salaryConfirm){
        try
        {
                Console.Write("▁ ▂ ▃ ▄ ▅ ▆ ▇ █ ▉ █ ▇ ▆ ▅ ▄ ▃ ▂ ▁\nВітаємо в калькуляторі заробітньо плати!\nВведіть зарплату працівника за годину: ");
                salaryPerHour = Convert.ToDouble(Console.ReadLine());
                salaryConfirm = false;
        }
        catch
        {
                Console.WriteLine("✇Введіть доречний формат числа!");
        }
}

List<int> workTimeHistory = new List<int>();
while (isWhile)
{
        try
        {
                Console.Write("⊱Що ви бажаєте зробити?\n1 - добавити нові робочі ставки;\n2 - Вивести історію робочих днів і зарплати до них;\n3 - Очистити список;\n4 - Вивести графік роботи;\n0 - Закінчити роботу з програмою.\nВаш вибір: ");
                choice = Convert.ToInt16(Console.ReadLine());
        }
        catch
        {
                Console.WriteLine("✇ Введіть доречний формат!");
        }
        if (choice == 1)
        {
                Console.Clear();
                bool addNewWhile = true;
                Console.WriteLine("▁ ▂ ▃ ▄ ▅ ▆ ▇ █ ▉ █ ▇ ▆ ▅ ▄ ▃ ▂ ▁");
                while (addNewWhile)
                {
                        try
                        {
                                Console.Write("⊱ Введіть нову ставку робітника(25 щоб вийти): ");
                                int workTime = Convert.ToInt16(Console.ReadLine());
                                if (workTime == 25)
                                {
                                        Console.Clear();
                                        addNewWhile = false;
                                        break;
                                }
                                else if (workTime > 24)
                                {
                                        Console.WriteLine("✇ Людина не може працювати більше годин, ніж в добі!");
                                }
                                else
                                {
                                        workTimeHistory.Add(workTime);
                                }
                        }
                        catch
                        {
                                Console.WriteLine("✇ Введіть доречний формат числа!");
                        }

                }
        }
        else if (choice == 2)
        {
                int salary = 0;
                int salaryTotal = 0;
                Console.Clear();
                Console.WriteLine("─⊹⊱✙⊰⊹─");
                foreach (int workTime in workTimeHistory)
                {
                        salary = (int)(workTime * salaryPerHour);
                        Console.WriteLine($"⊰ {workTime} годин:Зарплата {salary}");
                        salaryTotal += salary;
                }
                Console.WriteLine($"Загалом: {salaryTotal}");
                Console.WriteLine("─────────");
        }
        else if (choice == 3)
        {
                Console.Clear();
                Console.Write("Ви підтверджуєте свій вибір?\n0 - Так, я хочу видалити історію;\n 1 - Ні, я хочу вернутись назад.\n");
                string input = Console.ReadLine();
                if (input == "0")
                {
                        workTimeHistory.Clear();
                        Console.WriteLine("Історію очищено.");
                }
                else
                {
                        Console.WriteLine("Скасовано.");
                }
        }
        else if (choice == 4)
        {

                int max = 0;
                foreach (int workTime in workTimeHistory)
                {
                        if (workTime > max)
                        {
                                max = workTime;
                        }
                }
                Console.Clear();
                for (int y = max; y >= 1; y--)
                {
                        for (int x = 0; x < workTimeHistory.Count; x++)
                        {
                                if (workTimeHistory[x] >= y)
                                {
                                        Console.Write(" █ ");
                                }
                                else
                                {
                                        Console.Write("   ");
                                }
                        }
                        Console.WriteLine();
                }

                for (int i = 0; i < workTimeHistory.Count; i++)
                {
                        Console.Write($" {i} ");
                }

                Console.WriteLine();
        }

        else if (choice == 0)
        {
                Console.WriteLine("До зустрічі!\n(*￣3￣)╭");
                isWhile = false;
                break;
        }
        else
        {
                Console.WriteLine("✇ Введіть доречний формат числа!");
        }

}
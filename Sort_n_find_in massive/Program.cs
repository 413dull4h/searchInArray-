using Sort_n_find_in_massive;
using System.Diagnostics;
while (true) //Начало программы
{
    double[] array = { };
    int menu_action = -1;
    while (true) //Выбор ввода массива
    {
        o.cls();
        o.print("Выберите способ ввода массива \n\n  1. вручную\n  2. случайные числа\n  3. указать путь к файлу\n  4. выход\n");
        try
        {
            menu_action = int.Parse(o.input());
            if (menu_action < 1 || menu_action > 4) throw new Exception();
        }
        catch
        {
            o.error();
            continue;
        }
        break;
    }
    switch (menu_action)
    {
        case 1: //Ручной ввод массива
        {
            int lenght = 0;
            while (true)
            {
                o.cls();
                o.print("Введите размер массива: ");
                try
                {
                    lenght = int.Parse(o.input());
                    if (lenght < 1) throw new Exception();
                }
                catch
                {
                    o.error();
                    continue;
                }
                break;
            }
            Array.Resize(ref array, lenght);
            for (int i = 0; i < lenght; i++)
                array[i] = double.MaxValue;
            while (true)
            {
                int i = 0;
                o.cls();
                Console.WriteLine("Введите элементы массива({0}):", lenght);
                while (true)
                    if (array[i] != Double.MaxValue)
                    {
                        Console.WriteLine("{0}. {1}", i + 1, array[i]);
                        i++;
                    }
                    else break;
                while (i < lenght)
                {
                    double a = 0;
                    Console.Write("{0}. ", i + 1);
                    try
                    {
                        a = Double.Parse(o.input());
                    }
                    catch
                    {
                        o.error();
                        break;
                    }
                    array[i] = a;
                    i++;
                }
                if (i != lenght) continue;
                break;
            }
            break;
        }
        case 2: //Ввод массива с случайными числами
        {
            int lenght = 0;
            Random random = new Random();
            while (true)
            {
                o.cls();
                o.print("Введите размер массива: ");
                try
                {
                    lenght = int.Parse(o.input());
                    if (lenght < 1) throw new Exception();
                }
                catch
                {
                    o.error();
                    continue;
                }
                break;
            }
            Array.Resize(ref array, lenght);
            for (int i = 0; i < lenght; i++)
                array[i] = random.Next(-1024, 1024);
            break;
        }
        case 3: //Чтение массива с файла
            {
                bool action_a = false;
                string adress;
                while (true)
                {
                    o.cls();
                    o.print("Введите путь к файлу (Введите 'назад', чтобы вернуться):");
                    try
                    {
                        adress = o.input();
                        if (adress == "назад")
                        {
                            action_a = true;
                            break;
                        }
                        else
                        {
                            List<double> temporary_list = new List<double>();
                            string s;
                            StreamReader f = new StreamReader(adress);
                            while ((s = f.ReadLine()) != null)
                            {
                                temporary_list.Add(Convert.ToDouble(s));
                            }
                            f.Close();
                            array = temporary_list.ToArray();
                            if (array.Length == 0) throw new Exception();
                        }
                    }
                    catch
                    {
                        o.error();
                        continue;
                    }
                    break;
                }
                if (action_a) continue;
                break;
            }
        case 4: //Выход из программы
        {
            Environment.Exit(0);
            break;
        }
    }
    int show_array_status = 0;
    while (true) //Меню взаимодействия с массивом
    {
        int action_a = 0;
        o.cls();
        Console.WriteLine("Длина текущего массива: " + array.Length);
        if (show_array_status == 0)
        {
            o.print("\nВыберите действие: \n\n  1. показать массив в строку\n  2. показать массив построчно");
        }
        else if (show_array_status == 1)
        {
            o.show_array(array, 0, 0);
            o.print("\nВыберите действие: \n\n  1. показать массив построчно\n  2. скрыть массив");
        }
        else if (show_array_status == 2)
        {
            o.show_array(array, 1, 0);
            o.print("\nВыберите действие: \n\n  1. показать массив в строку\n  2. скрыть массив");
        }
        o.print("  3. вернуться в меню ввода массива\n  4. сохранить данный массив в файл");
        o.print("  5. сортировка массива\n  6. поиск в массиве");
        try
        {
            action_a = int.Parse(o.input());
            if (action_a < 1 || action_a > 6) throw new Exception();
        }
        catch
        {
            o.error();
            continue;
        }
        if (action_a == 1 && (show_array_status == 0 || show_array_status == 2)) //Вывод/скрытие массива
        {
            show_array_status = 1;
            continue;
        }
        else if (action_a == 1 && show_array_status == 1)
        {
            show_array_status = 2;
            continue;
        }
        else if (action_a == 2 && (show_array_status == 1 || show_array_status == 2))
        {
            show_array_status = 0;
            continue;
        }
        else if (action_a == 2 && show_array_status == 0)
        {
            show_array_status = 2;
            continue;
        }
        if (action_a == 3) //Возврат в начало программы
            break;
        else if (action_a == 4) //Сохранение массива в файл
        {
            while (true)
            {
                o.cls();
                o.print("Введите путь сохранения текстового файла (Введите 'назад', чтобы вернуться):");
                string adress = o.input();
                string text_to_save = "";
                if (text_to_save == "назад")
                    break;
                for (int i = 0; i < array.Length; i++)
                    text_to_save += Convert.ToString(array[i]) + "\n";
                try
                {
                    System.IO.File.WriteAllText(@adress, text_to_save);
                }
                catch
                {
                    o.error();
                    continue;
                }
                break;
            }
        }
        else if (action_a == 5) //Сортировки
        {
            int action_d = 0;
            while (true)
            {
                o.cls();
                o.print("Способ сортировки:");
                o.print(" 1. сортировка вставками\n 2. сортировка Шелла\n 3. пузырьковый метод\n 4. сортировка выбором\n 5. быстрая сортировка\n 6. назад");
                try
                {
                    action_d = int.Parse(o.input());
                    if (action_d < 1 || action_d > 6) throw new Exception();
                }
                catch
                {
                    o.error();
                    continue;
                }
                break;
            }
            if (action_d == 1) //Сортировка вставками
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                double[] result = array_sort.insertion(array);
                timer.Stop();
                double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                while (true)
                {
                    o.cls();
                    Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                    o.print("Показать отсортированный массив?\n  1. показать в строку\n  2. показать построчно\n  3. нет");
                    string action_b = o.input();
                    if (!(action_b == "1" || action_b == "2" || action_b == "3"))
                    {
                        o.error();
                        continue;
                    }
                    while (true)
                    {
                        o.cls();
                        if (action_b == "1")
                            o.show_array(result, 0, 1);
                        else if (action_b == "2")
                            o.show_array(result, 1, 1);
                        o.print("Сделать отсортированный массив текущим?(да/нет)");
                        string action_c = o.input();
                        if (action_c == "да" || action_c == "Да" || action_c == "ДА")
                        {
                            array = result;
                            break;
                        }
                        else if (action_c == "нет" || action_c == "Нет" || action_c == "НЕТ")
                            break;
                        else
                        {
                            o.error();
                            continue;
                        }
                    }
                    break;
                }
            }
            else if (action_d == 2) //Сортировка Шелла
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                double[] result = array_sort.Shell(array);
                timer.Stop();
                double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                while (true)
                {
                    o.cls();
                    Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                    o.print("Показать отсортированный массив?\n  1. показать в строку\n  2. показать построчно\n  3. нет");
                    string action_b = o.input();
                    if (!(action_b == "1" || action_b == "2" || action_b == "3"))
                    {
                        o.error();
                        continue;
                    }
                    while (true)
                    {
                        o.cls();
                        if (action_b == "1")
                            o.show_array(result, 0, 1);
                        else if (action_b == "2")
                            o.show_array(result, 1, 1);
                        o.print("Сделать отсортированный массив текущим?(да/нет)");
                        string action_c = o.input();
                        if (action_c == "да" || action_c == "Да" || action_c == "ДА")
                        {
                            array = result;
                            break;
                        }
                        else if (action_c == "нет" || action_c == "Нет" || action_c == "НЕТ")
                            break;
                        else
                        {
                            o.error();
                            continue;
                        }
                    }
                    break;
                }
            }
            else if (action_d == 3) //Сортировка Пузырьковая
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                double[] result = array_sort.Bubble(array);
                timer.Stop();
                double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                while (true)
                {
                    o.cls();
                    Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                    o.print("Показать отсортированный массив?\n  1. показать в строку\n  2. показать построчно\n  3. нет");
                    string action_b = o.input();
                    if (!(action_b == "1" || action_b == "2" || action_b == "3"))
                    {
                        o.error();
                        continue;
                    }
                    while (true)
                    {
                        o.cls();
                        if (action_b == "1")
                            o.show_array(result, 0, 1);
                        else if (action_b == "2")
                            o.show_array(result, 1, 1);
                        o.print("Сделать отсортированный массив текущим?(да/нет)");
                        string action_c = o.input();
                        if (action_c == "да" || action_c == "Да" || action_c == "ДА")
                        {
                            array = result;
                            break;
                        }
                        else if (action_c == "нет" || action_c == "Нет" || action_c == "НЕТ")
                            break;
                        else
                        {
                            o.error();
                            continue;
                        }
                    }
                    break;
                }
            }
            else if (action_d == 4) //Сортировка выбором
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                double[] result = array_sort.Choose(array);
                timer.Stop();
                double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                while (true)
                {
                    o.cls();
                    Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                    o.print("Показать отсортированный массив?\n  1. показать в строку\n  2. показать построчно\n  3. нет");
                    string action_b = o.input();
                    if (!(action_b == "1" || action_b == "2" || action_b == "3"))
                    {
                        o.error();
                        continue;
                    }
                    while (true)
                    {
                        o.cls();
                        if (action_b == "1")
                            o.show_array(result, 0, 1);
                        else if (action_b == "2")
                            o.show_array(result, 1, 1);
                        o.print("Сделать отсортированный массив текущим?(да/нет)");
                        string action_c = o.input();
                        if (action_c == "да" || action_c == "Да" || action_c == "ДА")
                        {
                            array = result;
                            break;
                        }
                        else if (action_c == "нет" || action_c == "Нет" || action_c == "НЕТ")
                            break;
                        else
                        {
                            o.error();
                            continue;
                        }
                    }
                    break;
                }
            }
            else if (action_d == 5) //Сортировка быстро
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                double[] result = array_sort.Quick(array);
                timer.Stop();
                double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                while (true)
                {
                    o.cls();
                    Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                    o.print("Показать отсортированный массив?\n  1. показать в строку\n  2. показать построчно\n  3. нет");
                    string action_b = o.input();
                    if (!(action_b == "1" || action_b == "2" || action_b == "3"))
                    {
                        o.error();
                        continue;
                    }
                    while (true)
                    {
                        o.cls();
                        if (action_b == "1")
                            o.show_array(result, 0, 1);
                        else if (action_b == "2")
                            o.show_array(result, 1, 1);
                        o.print("Сделать отсортированный массив текущим?(да/нет)");
                        string action_c = o.input();
                        if (action_c == "да" || action_c == "Да" || action_c == "ДА")
                        {
                            array = result;
                            break;
                        }
                        else if (action_c == "нет" || action_c == "Нет" || action_c == "НЕТ")
                            break;
                        else
                        {
                            o.error();
                            continue;
                        }
                    }
                    break;
                }
            }
        }
        else if (action_a == 6) //Поиск в массиве
        {
            int action_d = 0;
            while (true)
            {
                o.cls();
                o.print("Способ поиска:");
                o.print(" 1. последовательный поиск\n 2. двоичный поиск\n 3. назад");
                try
                {
                    action_d = int.Parse(o.input());
                    if (action_d < 1 || action_d > 3) throw new Exception();
                }
                catch
                {
                    o.error();
                    continue;
                }
                break;
            }
            if (action_d == 1) //Поиск последовательный
            {
                double key;
                while (true)
                {
                    o.cls();
                    o.print("Введите ключ:");
                    try
                    {
                        key = Double.Parse(o.input());
                    }
                    catch
                    {
                        o.error();
                        continue;
                    }
                    break;
                }
                Stopwatch timer = new Stopwatch();
                timer.Start();
                List<int> indexes = new List<int>();
                for (int i = 0; i < array.Length; i++)
                    if (array[i] == key)
                        indexes.Add(i);
                timer.Stop();
                double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                o.cls();
                Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                if (indexes.Count > 0)
                {
                    Console.Write("Ключ совпал с элементом номер: ");
                    for (int i = 0; i < indexes.Count; i++)
                        Console.Write(indexes[i] + 1 + "; ");
                }
                else
                    Console.WriteLine("Ключ не совпал ни с одним элементом массива");
                o.wait();
            }
            else if (action_d==2) //Поиск двоичный
            {
                bool check = true;
                for (int i = 1; i < array.Length; i++)
                    if (array[i] < array[i - 1]) check = false;
                if (!check)
                {
                    o.cls();
                    o.print("Массив не отсортирован!");
                    o.wait();
                }
                else
                {
                    double key;
                    while (true)
                    {
                        o.cls();
                        o.print("Введите ключ:");
                        try
                        {
                            key = Double.Parse(o.input());
                        }
                        catch
                        {
                            o.error();
                            continue;
                        }
                        break;
                    }
                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    int lev = 0;
                    int prav = array.Length - 1;
                    bool found = false;
                    int sred = 0;
                    while (lev <= prav)
                    {
                        sred = lev + (prav - lev) / 2;
                        if (array[sred] == key)
                        {
                            found = true;
                            break;
                        }
                        else if (array[sred] < key)
                        {
                            lev = sred + 1;
                        }
                        else
                        {
                            prav = sred - 1;
                        }
                    }
                    if (found)
                    {
                        List<int> poisk = new List<int>();
                        for (int i = sred - 1; i >= 0; i--)
                        {
                            if (array[i] == array[sred]) poisk.Add(i);
                            else break;
                        }
                        poisk.Reverse();
                        poisk.Add(sred);
                        for (int i = sred + 1; i >= 0; i++)
                        {
                            if (array[i] == array[sred]) poisk.Add(i);
                            else break;
                        }
                        timer.Stop();
                        double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                        Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                        Console.Write("Ключ найден в массиве в позиции: ");
                        foreach (int i in poisk)
                        {
                            Console.Write("{0}; ", i + 1);
                        }
                        o.wait();
                    }
                    else
                    {
                        o.cls();
                        timer.Stop();
                        double time = Convert.ToDouble(timer.ElapsedMilliseconds) / 1000;
                        Console.WriteLine("Время выполнения операции: {0} сек.\n", time);
                        Console.WriteLine("Ключ не совпал ни с одним элементом массива");
                        o.wait();
                    }
                }
            }
        }
    }
}
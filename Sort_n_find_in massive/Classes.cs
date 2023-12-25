using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_n_find_in_massive
{
    internal class Classes
    {
    }
    public class o //Класс базовых действий
    {
        static public void cls() //отчистка экрана
        {
            Console.Clear();
        }
        static public string input() //ввод
        {
            return Console.ReadLine(); ;
        }
        static public void print(string a) //вывод строки
        {
            Console.WriteLine(a);
        }
        static public void printf(string a) //вывод
        {
            Console.Write(a);
        }
        static public void wait() //чтение клавиши
        {
            Console.ReadKey();
        }
        static public void error() //ошибка
        {
            Console.WriteLine("Ошибка!");
            Console.ReadKey();
        }
        static public void show_array(double[] a, int status, int status_2) //вывод массива
        {
            if (status == 0)
            {
                if (status_2 == 0)
                    Console.Write("Элементы текущего массива:");
                else
                    Console.Write("Элементы отсортированного массива:");
                for (int i = 0; i < a.Length; i++)
                    Console.Write(" {0}){1}", i + 1, a[i]);
                Console.WriteLine();
            }
            else
            {
                if (status_2 == 0)
                    Console.WriteLine("Элементы текущего массива:");
                else
                    Console.WriteLine("Элементы отсортированного массива:");
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine(" {0}) {1}", i + 1, a[i]);
                }
            }
        }
    }
    public class array_sort //класс сортировки
    {
        static public double[] insertion(double[] a) //сортировка вставками
        {
            double[] local = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                local[i] = a[i];
            for (int j = 0; j < local.Length; j++)
            {
                if (j != 0)
                {
                    double o = local[j];
                    for (int k = 0; k < j; k++)
                    {
                        if (o <= local[k])
                        {
                            for (int l = j; l > k; l--)
                            {
                                local[l] = local[l - 1];
                            }
                            local[k] = o;
                            break;
                        }
                    }
                }
            }
            return local;
        }
        static public double[] Shell(double[] a) //сортировка Шелла
        {
            double[] local = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                local[i] = a[i];
            int d = local.Length;
            while (d != 1)
            {
                d /= 2;
                for (int i = 0; i < d; i++)
                {
                    int m = local.Length / d;
                    m++;
                    if (d * m >= local.Length)
                        m--;
                    double[] mini_array = new double[m];
                    for (int j = 0; j < m; j++)
                        mini_array[j] = local[i + d * j];
                    mini_array = insertion(mini_array);
                    for (int j = 0; j < m; j++)
                        local[i + d * j] = mini_array[j];
                }
            }
            return local;
        }
        static public double[] Bubble(double[] a) //сортировка пузырьковая
        {
            double[] local = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                local[i] = a[i];
            for (int i = 0; i < local.Length - 1; i++)
                for (int j = 0; j < local.Length - 1; j++)
                    if (local[j] > local[j + 1])
                    {
                        double k = local[j];
                        local[j] = local[j + 1];
                        local[j + 1] = k;
                    }
            return local;
        }
        static public double[] Choose(double[] a) //сортировка выбором
        {
            double[] local = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                local[i] = a[i];
            for (int i = 0; i < local.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < local.Length; j++)
                {
                    if (local[j] < local[min])
                    {
                        min = j;
                    }
                }
                double k = local[min];
                local[min] = local[i];
                local[i] = k;
            }
            return local;
        }
        static public double[] Quick(double[] a) //быстрая сортировка
        {
            double[] local = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
                local[i] = a[i];
            double[] sort_func(double[] b, int left, int right)
            {
                int i = left;
                int j = right;
                double p = b[left];
                while (i <= j)
                {
                    while (b[i] < p) i++;
                    while (b[j] > p) j--;
                    if (i <= j)
                    {
                        double k = b[i];
                        b[i] = b[j];
                        b[j] = k;
                        i++;
                        j--;
                    }
                }
                if (left < j)
                    sort_func(b, left, j);
                if (i < right)
                    sort_func(b, i, right);
                return b;
            }
            sort_func(local, 0, local.Length - 1);
            return local;
        }
    }
}
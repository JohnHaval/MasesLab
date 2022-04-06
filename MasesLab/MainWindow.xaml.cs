using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AllXFiller;
using DataGridFiller;
using TryEqualing;

namespace MasesLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] _masA, _masB;//Массивы данных

        private void TryEqual_Click(object sender, RoutedEventArgs e)
        {
            if (_masA == null || _masB == null)
            {
                MessageBox.Show("Необходимо заполнить массивы перед началом сравнения", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                NVal.Focus();
            }
            else
            {
                bool result = TryEqualingMasses.TryEqualMasses(_masA, _masB);
                if (result && TryEqualingMasses.IsEqualSequance) Result.Text = "Массивы идентичны";
                else if (result) Result.Text = "Массивы равны, но их последовательность не идентична";
                else if (!result) Result.Text = "Массивы не идентичны";
            }
        }

        private void ClearTable_Click(object sender, RoutedEventArgs e)
        {
            Table.ItemsSource = VisualArray.Clear().DefaultView;
            _masA = null;
            _masB = null;
            Result.Clear();
        }

        private void Table_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)//----------------CellEditTable
        {
            int iColumn = e.Column.DisplayIndex;
            int iRow = e.Row.GetIndex();
            if (e.EditAction == DataGridEditAction.Commit)
            {
                if (iColumn == 0)
                {
                    _masA[iRow] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
                }
                else
                {
                    _masB[iRow] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
                }
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа имеет следующие особенности:\n" +
                "1) Конечная точка диапазона является размером массивов\n" +
                "2) Заполнение первого массива происходит последовательно заданному диапазону значений," +
                " для второго используется заполнение случайными значениями", "Справка",
                MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void AboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Задание.11. Даны натуральное число N и два одномерных массива A1, A2, …, AN и B1, B2, …, BN целых " +
                "чисел.Определить верно ли, что эти массивы отличаются только порядком следования элементов.\n" +
                "Разработчик: Лопаткин Сергей ИСП-31(GitHub.Name = \"Hapro Bishop\")", "О программе",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void FillMases_Click(object sender, RoutedEventArgs e)//----------------------------------ОШИБКА ПРОВЕРКИ КОНЕЧНОЙ ТОЧКИ ИНТЕРВАЛА
        {
            int n;
            try
            {
                n = Convert.ToInt32(NVal.Text);
            }
            catch
            {
                MessageBox.Show("Некорректно указано значение ограничения диапазона",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                NVal.Focus();
                return;
            }            
            _masA = XFiller.XFill(1, n);
            _masB = XFiller.XFillRnd(n);                        
            Table.ItemsSource = VisualArray.ToDataTable(_masA, _masB).DefaultView;
        }
    }
}

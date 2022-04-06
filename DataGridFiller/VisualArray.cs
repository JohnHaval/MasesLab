using System.Data;

namespace DataGridFiller
{
    /// <summary>
    /// Класс для связывания DataGrid с массивом данных
    /// </summary>
    public static class VisualArray
    {
        static DataTable _res = new DataTable();
        /// <summary>
        /// Выполняет заполнение массива данных в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xMas"></param>
        /// <param name="isA"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(T[] masA, T[] masB)
        {
            _res = new DataTable();            
            DataRow row;            
            _res.Columns.Add("A", typeof(T));                        
            _res.Columns.Add("B", typeof(T));
            for (int i = 0; i < masA.Length; i++)
            {
                row = _res.NewRow();
                row[0] = masA[i];                
                _res.Rows.Add(row);
            }
            for (int i = 0; i < masB.Length; i++)
            {
                row = _res.Rows[i];
                row[1] = masB[i];
            }
            return _res;
        }/// <summary>
        /// Очищает таблицу и возвращает пустоту в DataGrid
        /// </summary>
        /// <returns></returns>
        public static DataTable Clear()
        {
            return _res = new DataTable();
        }
    }
}
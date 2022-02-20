using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csvConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CsvToDataTable obj = new CsvToDataTable();
            DataTable dtData = obj.ConvertCsvToDataTable(@"C:\Users\TashirVallabh\Downloads\Enversoft\Data.csv");
            obj.ShowData(dtData);
        }


        class CsvToDataTable
        {

            public DataTable ConvertCsvToDataTable(string filePath)
            {
                //reading all the lines(rows) from the file.
                string[] rows = File.ReadAllLines(filePath);

                DataTable dtData = new DataTable();
                string[] rowValues = null;
                DataRow dr = dtData.NewRow();

                //Creating columns
                if (rows.Length > 0)
                {
                    foreach (string columnName in rows[0].Split(','))
                        dtData.Columns.Add(columnName);
                }

                //Creating row for each line.(except the first line, which contain column names)
                for (int row = 1; row < rows.Length; row++)
                {
                    rowValues = rows[row].Split(',');
                    dr = dtData.NewRow();
                    dr.ItemArray = rowValues;
                    dtData.Rows.Add(dr);
                }

                return dtData;

            }

            public void ShowData(DataTable dtData)
            {
                if (dtData != null && dtData.Rows.Count > 0)
                {
                    foreach (DataColumn dc in dtData.Columns)
                    {
                        Console.Write(dc.ColumnName + " ");
                    }
                    Console.WriteLine("\n-----------------------------------------------");

                    foreach (DataRow dr in dtData.Rows)
                    {
                        int x = 0;
                        foreach (var item in dr.ItemArray)
                        {
                            Console.Write(item.ToString() + "      ");
                            x++;
                        }
                        Console.Write("\n");

                        Write(dtData, @"C:\Users\TashirVallabh\Downloads\Enversoft\supplier.txt");
                        WriteDataToFile(dtData, @"C:\Users\TashirVallabh\Downloads\Enversoft\supplierAddress.txt");
                    }


 


                    Console.ReadKey();
                }
            }
            //convert csv to two text files
            public static void Write(DataTable dt, string filePath)
            {
                
                int i = 0;
                StreamWriter sw = null;
                sw = new StreamWriter(filePath, false);
                for (i = 0; i < dt.Columns.Count - 1; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName + " ");
                }
                sw.Write(dt.Columns[i].ColumnName);
                sw.WriteLine();
                foreach (DataRow row in dt.Rows)
                {
                    var query = dt.AsEnumerable()
                    .GroupBy(r => new { Name = r.Field<string>("FirstName"), SurName = r.Field<string>("LastName") })
                    .Select(grp => new
                    {
                        Name = grp.Key.Name,

                        Count = grp.Count()

                    });


                    foreach (var item in query)
                    {
                        Console.WriteLine( item.Name, item.Count);
                    }
                    object[] array = row.ItemArray;
                    for (i = 0; i < array.Length - 1; i++)
                    {
                        sw.Write(array[i] + " ");
                    }
                    sw.Write(array[i].ToString());
                    sw.WriteLine();
                }
                sw.Close();
            }

            // Convert Address to textfile 
            public static void WriteDataToFile(DataTable submittedDataTable, string submittedFilePath)
            {
                submittedFilePath = @"C:\Users\TashirVallabh\Downloads\Enversoft\supplierAddress.txt";
                int i = 2;
                StreamWriter sw = null;

                sw = new StreamWriter(submittedFilePath, false);
            
                sw.Write(submittedDataTable.Columns[2].ColumnName);
                sw.WriteLine();


                
                foreach (DataRow row in submittedDataTable.Rows)
                {
                    
                    object[] array = row.ItemArray;
    

                    string address = array[2].ToString();

                    
                    string address2 = Regex.Replace(address, "[0-9]", "");
                    


             


                    sw.Write(address2) ;
                    
                   
                         sw.WriteLine();

                }

                sw.Close();
            }
          



        }
    }
}

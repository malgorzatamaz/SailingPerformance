﻿using System;
using System.Collections.Generic;
using System.Data;
using ClientService.Model;
using Spire.Xls;

namespace ClientService.Services
{
    public class ReadExcelService
    {
        public List<DataGps> LoadData(string path)
        {
            Workbook workbook = new Workbook();
            List<DataGps> DataGpsList=new List<DataGps>();
            workbook.LoadFromFile(@"C:\Work\Anna_st\Programowanie\SailingPerfomanceS\SailingPerformance\Gui\DataExcel\DataGps.xlsx", ExcelVersion.Version2013);
            Worksheet sheet = workbook.Worksheets[0];

            DataTable dataTable = sheet.ExportDataTable();
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dataGps=new DataGps();
                dataGps.BoatSpeed=Convert.ToDouble(dataTable.Rows[i]["predkosc"]) ;
                dataGps.WindDirection = Convert.ToDouble(dataTable.Rows[i]["kurs"]);
                DataGpsList.Add(dataGps);
            }
            return DataGpsList;
        }
    }
}

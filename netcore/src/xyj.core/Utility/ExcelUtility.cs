using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using FastExcel;

namespace xyj.core.Utility
{
    public class ExcelUtility
    {
        private IEnumerable<Row> dataRows;
        private readonly FileInfo outputFile;
        private readonly FileInfo templateFile;

        public ExcelUtility(List<List<string>> dataToWrite, string templateFileDir, string outputFileDir)
        {
            templateFile = new FileInfo(templateFileDir);
            outputFile = new FileInfo(outputFileDir);
            dataRows = ToRow(dataToWrite);
            if (outputFile.Exists)
            {
                outputFile.Delete();
                outputFile = new FileInfo(outputFileDir);
            }
        }

        private IEnumerable<Row> ToRow(List<List<string>> dataToWrite)
        {
            //分配空间
            dataRows = new List<Row>();
            //转换格式
            var rows = new List<Row>();
            for (var i = 0; i < dataToWrite.Count(); i++)
            {
                var cells = new List<Cell>();
                for (var j = 0; j < dataToWrite[i].Count; j++)
                {
                    cells.Add(new Cell(j + 1, dataToWrite[i][j]));
                }
                rows.Add(new Row(i + 1, cells));
            }
            return rows;
        }

        public FileInfo ToExcel()
        {
            var stopwatch = new Stopwatch();
            using (var fastExcel = new FastExcel.FastExcel(templateFile, outputFile))
            {
                var worksheet = new Worksheet {Rows = dataRows};
                stopwatch.Start();
                fastExcel.Write(worksheet, "sheet1");
            }
            outputFile.Refresh();
            return outputFile;
        }
    }
}
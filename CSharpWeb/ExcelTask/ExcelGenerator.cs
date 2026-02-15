using ClosedXML.Excel;

namespace ExcelTask
{
    class ExcelGenerator
    {
        public void GenerateStudentsTable(List<Person> students)
        {
            using (var workbook = new XLWorkbook())
            {
                var headerNames = new List<string> { "Имя", "Фамилия", "Возраст", "Телефон" };

                var worksheet = workbook.Worksheets.Add("Студенты");

                var i = 1;

                foreach (var name in headerNames)
                {
                    var cell = worksheet.Cell(1, i);
                    cell.Value = name;

                    var cellStyle = cell.Style;
                    cellStyle.Fill.BackgroundColor = XLColor.Azure;
                    cellStyle.Font.Bold = true;
                    cellStyle.Border.OutsideBorder = XLBorderStyleValues.Medium;
                    cellStyle.Border.OutsideBorderColor = XLColor.AirForceBlue;

                    i++;
                }

                worksheet.Cell(2, 1).InsertData(students);
                worksheet.Columns().AdjustToContents();

                var tableData = worksheet.Range($"A2:D{students.Count + 1}");

                tableData.Style.Fill.BackgroundColor = XLColor.AliceBlue;
                tableData.Style.Border.OutsideBorderColor = XLColor.AirForceBlue;

                workbook.SaveAs("StudentsData.xlsx");
            }
        }
    }
}

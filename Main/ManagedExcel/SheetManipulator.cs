using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagedExcel
{
    public class SheetManipulator
    {
        public static string GetSheetCellAddress(Worksheet sheet, int row, int column)
        {
            var address = @"$A$1";
            using (var cells = sheet.Cells)
            {
                using (var cell = cells[row, column])
                {
                    address = cell.get_Address();
                }
            }
            return address;
        }

        public static void SetSheetCellWidth(Worksheet sheet, int row, int column, object width)
        {
            using (Range cells = sheet.Cells)
            {
                using (Range cell = cells[row, column])
                {
                    cell.ColumnWidth = width;
                }
            }
        }

        public static void SetSheetCellValue(Worksheet sheet, int row, int column, object value)
        {
            using (Range cells = sheet.Cells)
            {
                using (Range cell = cells[row, column])
                {
                    cell.Value = value;
                }
            }
        }

        public static void SetSheetCellFormula(Worksheet sheet, int row, int column, string value)
        {
            using (Range cells = sheet.Cells)
            {
                using (Range cell = cells[row, column])
                {
                    cell.Formula = value;
                }
            }
        }

        public static void SetSheetCellNumberFormat(Worksheet sheet, int row, int column, object value)
        {
            using (Range cells = sheet.Cells)
            {
                using (Range cell = cells[row, column])
                {
                    cell.NumberFormat = value;
                }
            }
        }

        public static void SetSheetCellBackgroundColor(Worksheet sheet, int row, int column, System.Drawing.Color color)
        {
            using (Range cells = sheet.Cells)
            {
                using (Range cell = cells[row, column])
                {
                    using (var interior = cell.Interior)
                    {
                        interior.Color = System.Drawing.ColorTranslator.ToOle(color);
                    }
                }
            }
        }

        public static void SetSheetCellFontStyles(Worksheet sheet, int row, int column, Color color, bool bold,
                                                  bool italic)
        {
            using (Range cells = sheet.Cells)
            {
                using (Range cell = cells[row, column])
                {
                    using (var font = cell.Font)
                    {
                        font.Color = ColorTranslator.ToOle(color);
                        font.Bold = bold;
                        font.Italic = italic;
                    }
                }
            }
        }

        public static void SetSheetCellTextHorizontalAlignment(Worksheet sheet, int row, int column, XlHAlign align)
        {
            using (var cells = sheet.Cells)
            {
                using (var cell = cells[row, column])
                {
                    cell.HorizontalAlignment = align;
                }
            }
        }

        public static void SetSheetCellBorder(Worksheet sheet, int rowStart, int columnStart,
                                              XlLineStyle lineStyle = XlLineStyle.xlContinuous,
                                              XlBorderWeight weight = XlBorderWeight.xlThin)
        {
            using (var cells = sheet.Cells)
            {
                using (var cell = cells[rowStart, columnStart])
                {
                    cell.BorderAround(lineStyle, weight);
                }
            }
        }

        public static void SetSheetRangeBorder(Worksheet sheet, int rowStart, int columnStart, int rowEnd, int columnEnd,
                                               XlLineStyle lineStyle = XlLineStyle.xlContinuous,
                                               XlBorderWeight weight = XlBorderWeight.xlThin)
        {
            using (var cells = sheet.Cells)
            {
                using (var cellStart = cells[rowStart, columnStart])
                {
                    using (var cellEnd = cells[rowEnd, columnEnd])
                    {
                        using (var cellRange = cells.get_Range(cellStart, cellEnd))
                        {
                            cellRange.BorderAround(lineStyle, weight);
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections;

namespace ManagedExcel
{
    /// <summary>
    /// Common properties that has appreared in almost all objects
    /// </summary>
    public interface Common : IDisposable {
        Application Application { get; }
        object Parent { get; }
    }
    public interface Collection : Common, IEnumerable {
        int Count { get; }
        void Remove(int index);
    }

/////////////////////////////////////////////////////////////////////////////
// You can add additional required classes and methods.
// To view full list of available classes and methods 
// view metadata of Microsoft.Office.Interop.Excel assembly 
// in Object Browser

    [ComProgId("Excel.Application")]
	public interface Application : Common {
        bool Visible { get; set; }
        String Version { get; }
        String Caption { get; set; }
        int SheetsInNewWorkbook { set; get; }

		Workbook ActiveWorkbook();
		Workbooks Workbooks{ get; }

        Worksheet ActiveSheet { get; }

	
		void Quit();
	}

	public interface Workbooks : Collection {
		Workbook this[ int index ] { get; }
		Workbook Add(object Template);
        Workbook Open(String Filename, Object UpdateLinks, Object ReadOnly
            , Object Format, Object Password
            , Object WriteResPassword, Object IgnoreReadOnlyRecommended
            , Object Origin, Object Delimiter, Object Editable
            , Object Notify, Object Converter, Object AddToMru
            , Object Local, Object CorruptLoad);
        Workbook OpenXML(String Filename, Object Stylesheets, Object LoadOptions);
        Workbook Open(String Filename);
        void Close();
    }

	public interface Workbook : Common {
        Worksheets Sheets { get; }
        String Title { get; set; }
        String Name { get; }
        bool Saved { get; set; }

        void Save();
        void SaveAs(String Filename, Object FileFormat, Object Password
            , Object WriteResPassword, Object ReadOnlyRecommended
            , Object CreateBackup, XlSaveAsAccessMode AccessMode
            , Object ConflictResolution, Object AddToMru
            , Object TextCodepage, Object TextVisualLayout);
        void SaveAs(String Filename);

        void Close();
    }

	public interface Worksheets : Collection {
		Worksheet this[int index] { get; }
        Worksheet Add(object param1);
	}

	public interface Worksheet : Common {
        void Close();
        void Delete();
        void Activate();
        void Select();

        Range Cells { get; }
        Range Columns { get; }
        Range Rows { get; }
        Range UsedRange { get; }
		
        string Name { get; set; }
        int Index { get; }
	}


	public interface Range : Common {
        object BorderAround(object LineStyle, XlBorderWeight Weight = XlBorderWeight.xlThin);
	    Range get_Range(object Cell1, object Cell2/* = System.Type.Missing*/);
	    String get_Address();

        Range this[Object rowIndex, Object columnIndex] { get; set; }
        int Row { get; }
        int Column { get; }
        Range Columns { get; }
        Range Rows { get; }
        String Text { get; }
        Font Font { get; }
        object ColumnWidth { get; set; }
        object NumberFormat { get; set; }
        Interior Interior { get; }
        Borders Borders { get; }
        object HorizontalAlignment { set; get; }
        object Formula { set; get; }

        object Value { get; set;  }
        object Value2 { get; set; }
	}

    public interface Font : Common
    {
        object Color { get; set; }
        object Bold { get; set; }
        object Italic { set; get; }
        object Background { get; set; }
        object ColorIndex { set; get; }
    }

    public interface Interior : Common
    {
        object Color { get; set; }
    }

    public interface Border : Common
    {
        object Color { set; get; }
        object LineStyle { set; get; }
        object Weight { set; get; }
    }

    public interface Borders : Common
    {
        Border this[XlBordersIndex borderIndex] { get; }
        int Count { get; }
        object Value { get; set; }
    }

    public enum XlSaveAsAccessMode
    {
        //default (don't change the access mode)
        xlNoChange = 1,
        //(share list)
        xlShared = 2,
        //(exclusive mode)
        xlExclusive = 3
    }

    public enum XlBordersIndex
    {
        xlDiagonalDown = 5,	    // Border running from the upper left-hand corner to the lower right of each cell in the range.
        xlDiagonalUp = 6,	    // Border running from the lower left-hand corner to the upper right of each cell in the range.
        xlEdgeBottom = 9,	    // Border at the bottom of the range.
        xlEdgeLeft = 7,	    // Border at the left-hand edge of the range.
        xlEdgeRight = 10,       //	Border at the right-hand edge of the range.
        xlEdgeTop = 8,	    // Border at the top of the range.
        xlInsideHorizontal = 12,       //	Horizontal borders for all cells in the range except borders on the outside of the range.
        xlInsideVertical = 11	    // Vertical borders for all the cells in the range except borders on the outside of the range.
    }

    public enum XlLineStyle
    {
        xlContinuous	= 1,        //	Continuous line.
        xlDash	        = -4115,    //	Dashed line.
        xlDashDot	    = 4,        //	Alternating dashes and dots.
        xlDashDotDot	= 5,        //	Dash followed by two dots.
        xlDot	        = -4118,    //	Dotted line.
        xlDouble	    = -4119,    //	Double line.
        xlLineStyleNone	= -4142,    //	No line.
        xlSlantDashDot  = 13        //	Slanted dashes.
    }

    public enum XlBorderWeight
    {
        xlHairline  = 1,        //	Hairline (thinnest border).
        xlMedium    = -4138,    //	Medium.
        xlThick     = 4,        //	Thick (widest border).
        xlThin      = 2         //	Thin.
    }

    public enum XlHAlign
    {
        xlHAlignCenter                  = -4108,    //	Center.
        xlHAlignCenterAcrossSelection   = 7,        //	Center across selection.
        xlHAlignDistributed             = -4117,    //	Distribute.
        xlHAlignFill                    = 5,        //	Fill.
        xlHAlignGeneral                 = 1,        //	Align according to data type.
        xlHAlignJustify                 = -4130,    //	Justify.
        xlHAlignLeft                    = -4131,    //	Left.
        xlHAlignRight                   = -4152     //	Right.
    }
}

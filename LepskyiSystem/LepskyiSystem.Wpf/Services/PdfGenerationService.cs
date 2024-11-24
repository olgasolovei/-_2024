using GrapeCity.Documents.Pdf;
using LepskyiSystem.Dto.AnalyzeCraneDto;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using GrapeCity.Documents.Drawing;
using GrapeCity.Documents.Text;
using GrapeCity.Documents.Layout;

namespace LepskyiSystem.Wpf.Services
{
    public class PdfGenerationService
    {
        public PdfGenerationService()
        {

        }

        public void GenerateFile(IEnumerable<AnalyzedCraneDataDto> dataList)
        {
            // Initialize GcPdfDocument
            var doc = new GcPdfDocument();

            //Set page width and height
            float pageW = 1250;
            float pageH = 74 * dataList.Count();

            // Add a page to the PDF document
            var page = doc.Pages.Add(new SizeF(pageW, pageH));

            // Initialize GcPdfGraphics
            var g = page.Graphics;

            var host = new LayoutHost();

            // Create LayoutView
            var view = host.CreateView(pageW, pageH);

            // Create LayoutRect. Add anchor points
            var rt = view.CreateRect();
            rt.AnchorTopLeft(null, 36, 36);

            var ta = new TableRenderer(g,
                rt, FixedTableSides.TopLeft,
                rowCount: dataList.Count() + 1, columnCount: 7,
                gridLineColor: Color.FromArgb(112, 112, 112),
                gridLineWidth: 1);

            // Set height and width of the the rows and columns
            ta.RowRects[0].SetHeight(74);
            ta.ColumnRects[0].SetWidth(1250 / 7);

            var cs = new CellStyle
            {
                TextAlignment = TextAlignment.Center,
                ParagraphAlignment = ParagraphAlignment.Center,

                // Set text format
                TextFormat = new TextFormat
                {
                    FontName = "Roboto",
                    FontSize = 16,
                    FontSizeInGraphicUnits = true,
                }
            };

            // Cell Style to set back color for even rows
            var evenRowStyle = new CellStyle(ta.DefaultCellStyle)
            {
                FillColor = Color.FromArgb(250, 250, 250)
            };

            ta.AddCell(cs, 0, 0, "Message ID");
            ta.AddCell(cs, 0, 1, "Sensor ID");
            ta.AddCell(cs, 0, 2, "Timestamp");
            ta.AddCell(cs, 0, 3, "Position (X,Y,Z)");
            ta.AddCell(cs, 0, 4, "Velocity");
            ta.AddCell(cs, 0, 5, "Vibration");
            ta.AddCell(cs, 0, 6, "Load Level");

            int counter = 0;
            foreach (var data in dataList)
            {
                counter++;

                ta.AddCell(cs, counter, 0, data.MessageId);
                ta.AddCell(cs, counter, 1, data.SensorId);
                ta.AddCell(cs, counter, 2, data.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"));
                ta.AddCell(cs, counter, 3, $"{data.Position.PositionX}, {data.Position.PositionY}, {data.Position.PositionZ}");
                ta.AddCell(cs, counter, 4, data.Velocity.Velocity);
                ta.AddCell(cs, counter, 5, data.Vibration.VibrationLevel);
                ta.AddCell(cs, counter, 6, data.LoadLevel.LoadLevel);
            }

            ta.Render();

            DateTime now = DateTime.Now;
            Directory.CreateDirectory("reports");
            doc.Save($"reports\\Report-{now.ToString("yyyy-MM-dd HH:mm:ss")}.pdf");
        }
    }
}

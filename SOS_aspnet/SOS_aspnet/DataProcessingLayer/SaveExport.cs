using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using GemBox.Spreadsheet;
using SOS.BusinessEntities;
using Type = System.Type;

namespace SOS.DataProcessingLayer
{
    public class SaveExport
    {
        private readonly string _path;
        public SaveExport(string path)
        {
            _path = path;
        }

        #region Save/Print

        #region Consults

        public void PrintPfsConsult(int consultId, PfsConsult consult)
        {
            // Set license key to use GemBox.Spreadsheet in a Free mode.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = ExcelFile.Load(_path + @"/Templates/PFSConsult.xlsx");
            var export = workbook.Worksheets[0];
            export.Cells[1, 6].Value = consult.Id;
            export.Cells[4, 2].Value = consult.Specialist;
            export.Cells[5, 2].Value = consult.Date;
            export.Cells[7, 2].Value = consult.Client;
            export.Cells[8, 2].Value = consult.Age;
            export.Cells[11, 2].Value = consult.StcGivingInformation ? "✓" : "";
            export.Cells[11, 7].Value = consult.StcConsultation ? "✓" : "";
            export.Cells[12, 2].Value = consult.StcPsychodiagnost ? "✓" : "";
            export.Cells[12, 7].Value = consult.StcTerrapevtSession ? "✓" : "";
            export.Cells[13, 2].Value = consult.StcAnother != "" ? "✓" : consult.StcAnother;
            export.Cells[13, 5].Value = consult.StcAnother;
            export.Cells[16, 2].Value = consult.StpScheduled ? "✓" : "";
            export.Cells[16, 7].Value = consult.StpScheduled ? "" : "✓";
            export.Cells[17, 2].Value = consult.StpAnother != "" ? "✓" : consult.StpAnother;
            export.Cells[17, 5].Value = consult.StpAnother;
            export.Cells[20, 1].Value = consult.Form;
            export.Cells[20, 7].Value = consult.Content;

            export.Cells[23, 0].Value = consult.ProblemDiscription;
            export.Cells[23, 0].Style.ShrinkToFit = true;
            export.Cells[26, 0].Value = consult.ConversDiscription;
            export.Cells[26, 0].Style.ShrinkToFit = true;
            export.Cells[29, 0].Value = consult.ConversResults;
            export.Cells[29, 0].Style.ShrinkToFit = true;
            SavePrint(workbook, @"ИндивКонсультВзр" + consult.Client.Replace(" ", string.Empty) + "КЦ");
        }

        public void PrintCfsConsult(int consultId, CfsConsult consult)
        {
            // Set license key to use GemBox.Spreadsheet in a Free mode.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = ExcelFile.Load(_path + @"/Templates/CFSConsult.xlsx");
            var export = workbook.Worksheets[0];
            export.Cells[1, 6].Value = consult.Id;
            export.Cells[4, 2].Value = consult.Specialist;
            export.Cells[5, 2].Value = consult.Date;
            export.Cells[7, 2].Value = consult.Client;
            export.Cells[8, 2].Value = consult.Age;
            export.Cells[10, 2].Value = consult.Form;
            export.Cells[10, 7].Value = consult.Content;

            export.Cells[13, 0].Value = consult.ProblemDiscription;
            export.Cells[13, 0].Style.ShrinkToFit = true;
            export.Cells[16, 0].Value = consult.ConversDiscription;
            export.Cells[16, 0].Style.ShrinkToFit = true;
            export.Cells[19, 0].Value = consult.ConversResults;
            export.Cells[19, 0].Style.ShrinkToFit = true;
            SavePrint(workbook, @"ИндивКонсульт" + consult.Client.Replace(" ", string.Empty) + "КЦ");
        }

        #endregion

        private void SetValueIntoCell(ExcelCell cell, string value)
        {
            cell.Value = value;
            cell.Style.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
            cell.Style.ShrinkToFit = true;
        }

        private void SetValueIntoCell(ExcelCell cell, string value, Type type)
        {
            cell.Value = Convert.ChangeType(value, type);
            cell.Style.Borders.SetBorders(MultipleBorders.Outside, Color.Black, LineStyle.Thin);
            cell.Style.VerticalAlignment = VerticalAlignmentStyle.Top;
            cell.Style.WrapText = true;
        }

        public void SavePrintPfsJournal(int periodId, string period, List<PfsJournal> consults)
        {
            // Set license key to use GemBox.Spreadsheet in a Free mode.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var line = 9;
            var workbook = ExcelFile.Load(_path + @"/Templates/PfsJournal.xlsx");
            workbook.Worksheets[0].Cells[3, 9].Value = DateTime.Now.Date.ToShortDateString();
            workbook.Worksheets[0].Cells[3, 1].Value = period;
            foreach (PfsJournal pfsJournal in consults)
            {
                var cell = 2;
                SetValueIntoCell(workbook.Worksheets[0].Cells[line, 0], Convert.ToString(line - 8), typeof (int));
                SetValueIntoCell(workbook.Worksheets[0].Cells[line, 1], pfsJournal.Client);
                foreach (var i in pfsJournal.Counts)
                {
                    SetValueIntoCell(workbook.Worksheets[0].Cells[line, cell], i.ToString(CultureInfo.InvariantCulture), typeof(int));
                    cell++;
                }
                line++;
            }
            try
            {
                SavePrint(workbook, @"ОтчетИндивКонсультВзр_" + period.Replace("/", "_"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SavePrintCfsJournal(int periodId, string period, List<CfsJournal> consults)
        {
            // Set license key to use GemBox.Spreadsheet in a Free mode.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var line = 7;
            var workbook = ExcelFile.Load(_path + @"/Templates/CfsJournal.xlsx");
            workbook.Worksheets[0].Cells[2, 7].Value = DateTime.Now.Date.ToShortDateString();
            workbook.Worksheets[0].Cells[2, 1].Value = period;
            foreach (CfsJournal cfsJournal in consults)
            {
                var cell = 2;
                SetValueIntoCell(workbook.Worksheets[0].Cells[line, 0], Convert.ToString(line - 6), typeof(int));
                SetValueIntoCell(workbook.Worksheets[0].Cells[line, 1], cfsJournal.Client);
                foreach (var i in cfsJournal.Counts)
                {
                    SetValueIntoCell(workbook.Worksheets[0].Cells[line, cell], i.ToString(CultureInfo.InvariantCulture), typeof(int));
                    cell++;
                }
                line++;
            }
            try
            {
                SavePrint(workbook, @"ОтчетИндивКонсультДети_" + period.Replace("/", "_"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void SavePrintSpecJournal(int periodId, string period, List<SpecJournal> consults)
        {
            // Set license key to use GemBox.Spreadsheet in a Free mode.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            var line = 8;
            var workbook = ExcelFile.Load(_path + @"/Templates/SJournal.xlsx");

            workbook.Worksheets[0].Cells[2, 13].Value = DateTime.Now.Date.ToShortDateString();
            workbook.Worksheets[0].Cells[2, 1].Value = period;

            foreach (SpecJournal specJournal in consults)
            {
                var cell = 1;
                workbook.Worksheets[0].Cells[line, 0].Value = specJournal.Specialist;
                workbook.Worksheets[0].Cells[line, 0].Style.ShrinkToFit = true;
                foreach (var i in specJournal.Counts)
                {
                    workbook.Worksheets[0].Cells[line, cell].Value = i;
                    cell++;
                }
                line++;
            }
            try
            {
                SavePrint(workbook, @"ОтчетИндивКонсультСпец_");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void SavePrint(ExcelFile file, string filename)
        {
            //var fileDialog = new SaveFileDialog { FileName = filename, DefaultExt = @".xlsx", Filter = @"Excel Worksheets|*.xlsx" };
            //var result = fileDialog.ShowDialog();
            if (true) //result == DialogResult.OK)
            {
                try
                {
                    var options1 = new PrintOptions
                    {
                        SelectionType = SelectionType.EntireFile
                    };
                    file.Print(null, options1);
                    file.Save("d:\\" + filename + ".xlsx");
                    Process.Start("d:\\" + filename + ".xlsx");

                    //// Save to XLSX file.
                    //file.Save(fileDialog.FileName);
                    //if (MessageBox.Show(@"Вы хотите распечатать документ?", @"Печать", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //{
                    //    var options = new PrintOptions
                    //    {
                    //        SelectionType = SelectionType.EntireFile
                    //    };
                    //    file.Print(null, options);
                    //    MessageBox.Show(@"Документ отправлен на печать", @"Печать", MessageBoxButtons.OK);

                    //}
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion
    }
}
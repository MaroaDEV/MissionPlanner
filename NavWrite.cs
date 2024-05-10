using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Community.CsharpSqlite.Sqlite3;
using Excel = Microsoft.Office.Interop.Excel;

namespace MissionPlanner
{
    internal class NavWrite
    {
        private bool IsEmpty(object cellValue)
        {
            return cellValue == null || string.IsNullOrWhiteSpace(cellValue.ToString());
        }
        public void Write()
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Vérifier si Excel est ouvert
                excelApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

                int i = (int)MainV2.comPort.MAV.cs.wpno - 1;

                // Vérifier si une seule feuille est ouverte
                if (excelApp.Workbooks.Count != 1)
                {
                    Console.WriteLine("Il doit y avoir exactement une feuille Excel ouverte.");
                    return;
                }

                // Obtenir la première feuille
                workbook = excelApp.ActiveWorkbook;
                worksheet = (Excel.Worksheet)workbook.Sheets[1];

                System.DateTime dateTime = MainV2.comPort.MAV.cs.datetime;
                string heure = dateTime.ToString("HH:mm:ss");

                // Vérifier si les cellules sont vides avant d'écrire
                if (IsEmpty(worksheet.Cells[5 + i, "M"].Value) && IsEmpty(worksheet.Cells[5 + i, "Q"].Value) && IsEmpty(worksheet.Cells[5 + i, "U"].Value))
                {
                    // Écrire dans les cellules spécifiées
                    worksheet.Cells[5 + i, "M"].Value = heure;
                    worksheet.Cells[5 + i, "Q"].Value = MainV2.comPort.MAV.cs.battery_usedmah;
                    worksheet.Cells[5 + i, "U"].Value = MainV2.comPort.MAV.cs.battery_voltage;
                }
                else
                {
                    // Afficher le contenu des cellules dans la console pour déboguer
                    Console.WriteLine("Contenu de la cellule M: " + worksheet.Cells[5 + i, "M"].Value);
                    Console.WriteLine("Contenu de la cellule Q: " + worksheet.Cells[5 + i, "Q"].Value);
                    Console.WriteLine("Contenu de la cellule U: " + worksheet.Cells[5 + i, "U"].Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur s'est produite : " + ex.Message);
            }
            finally
            {
                // Libérer les ressources COM
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                if (workbook != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                if (excelApp != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}

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
            if (cellValue == null)
                return true;

            // Vérifie si c'est un objet COM
            if (cellValue.GetType().IsCOMObject)
            {
                try
                {
                    // Si possible, essaye de récupérer la valeur sous-jacente de l'objet COM
                    dynamic comObject = cellValue;
                    var comValue = comObject.Value; // Cela dépend de la structure de l'objet COM
                    return comValue == null || string.IsNullOrWhiteSpace(comValue.ToString());
                }
                catch
                {
                    // Si cela échoue, retourne 'false' ou 'true' selon ce que tu veux par défaut
                    return true;  // On considère l'objet COM comme vide si la lecture échoue
                }
            }

            // Vérifie si c'est une chaîne vide ou composée d'espaces blancs
            return string.IsNullOrWhiteSpace(cellValue.ToString());
        }

        public void Write(int curr_wp)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // Vérifier si Excel est ouvert
                excelApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");

                int i = curr_wp;

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
                if (IsEmpty(worksheet.Cells[5 + i, "M"]) && IsEmpty(worksheet.Cells[5 + i, "Q"]) && IsEmpty(worksheet.Cells[5 + i, "U"]))
                {
                    // Écrire dans les cellules spécifiées
                    worksheet.Cells[5 + i, "M"] = heure;
                    worksheet.Cells[5 + i, "Q"] = MainV2.comPort.MAV.cs.battery_usedmah;
                    worksheet.Cells[5 + i, "U"] = MainV2.comPort.MAV.cs.battery_voltage;
                }
                else
                {
                    // Afficher le contenu des cellules dans la console pour déboguer
                    Console.WriteLine("Contenu de la cellule M: " + worksheet.Cells[5 + i, "M"]);
                    Console.WriteLine("Contenu de la cellule Q: " + worksheet.Cells[5 + i, "Q"]);
                    Console.WriteLine("Contenu de la cellule U: " + worksheet.Cells[5 + i, "U"]);
                }
                if (i == 1)
                {
                    worksheet.Cells[15, "D"] = heure;
                    worksheet.Cells[14, "D"]= MainV2.comPort.MAV.cs.battery_usedmah;
                    worksheet.Cells[5 + i, "U"] = MainV2.comPort.MAV.cs.battery_voltage;
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
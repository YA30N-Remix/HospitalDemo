using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.Class
{
    public static class ClsTools
    {

        public static string ShamsiDate()
        {
            PersianCalendar p = new PersianCalendar();
            var Emruz = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
            return Emruz;
        }

        public static DateTime ShamsiDateToGregorianDate(string shamsidate)
        {
            PersianCalendar p = new PersianCalendar();
            DateTime dt = new DateTime(Convert.ToInt32(shamsidate.Substring(0, 4)), Convert.ToInt32(shamsidate.Substring(5, 2)), Convert.ToInt32(shamsidate.Substring(8, 2)), p);

            return dt;
        }


        public static string GregorianDateToShamsiDate(DateTime Gregoriandate)
        {                       
            PersianCalendar p = new PersianCalendar();
            var Emruz = p.GetYear(Gregoriandate).ToString() + "/" + p.GetMonth(Gregoriandate).ToString("0#") + "/" + p.GetDayOfMonth(Gregoriandate).ToString("0#");
            return Emruz;
        }

        public static string AyamHafte()
        {
            var Ayam = "";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    Ayam = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    Ayam = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    Ayam = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    Ayam = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    Ayam = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    Ayam = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    Ayam = "چهارشنبه";
                    break;

            }

            return Ayam;
        }

        public static string Time()
        {
            var Saat = "";

            Saat = DateTime.Now.Hour.ToString("0#");
            Saat += ":";
            Saat += DateTime.Now.Minute.ToString("0#");
            Saat += ":";
            Saat += DateTime.Now.Second.ToString("0#");

            return Saat;
        }

        public static void InsertLog(int LogTypeID, int UserID, string LogContent, string TableName, decimal TableKeyID)
        {
            try
            {
                CarpetCleaningEntities db = new CarpetCleaningEntities();
                tblLog tblLog = new tblLog();

                decimal MaxID = (from a in db.tblLogs
                                 select a.LogID).DefaultIfEmpty().Max() + 1;

                tblLog.LogID = MaxID;
                tblLog.LogTypeID = LogTypeID;
                tblLog.UserID = UserID;
                tblLog.LogContent = LogContent;
                tblLog.TableName = TableName;
                tblLog.TableKeyID = 1;
                tblLog.LogDate = ShamsiDate();
                tblLog.LogTime = Time();

                db.tblLogs.Add(tblLog);
                db.SaveChanges();

            }
            catch (Exception)
            {

            }
        }

        public static void ClearContent(Control Content)
        {
            foreach (var item in Content.Controls)
            {
                if (item is TextBox)
                    (item as TextBox).Clear();

                if (item is MaskedTextBox)
                    (item as MaskedTextBox).Clear();

                if (item is PictureBox)
                    (item as PictureBox).Image = null;

                if (item is RadioButton)
                    (item as RadioButton).Checked = false;

                if (item is NumericUpDown)
                    (item as NumericUpDown).ResetText();

                if (item is ComboBox)
                    (item as ComboBox).ResetText();

            }
        }

        public static bool CheckValidation(Control Content)
        {
            foreach (var item in Content.Controls)
            {

                if (item is TextBox)
                {
                    if ((item as TextBox).Name.ToString().LastIndexOf("_") > 0)
                    {
                        if ((item as TextBox).Text.Trim().Length == 0)
                        {
                            return false;
                        }
                    }

                }

                if (item is ComboBox)
                {
                    if ((item as ComboBox).Name.ToString().LastIndexOf("_") > 0)
                    {
                        if ((item as ComboBox).Text.Trim().Length == 0)
                        {
                            return false;
                        }
                    }
                }

                if (item is MaskedTextBox)
                {
                    if ((item as MaskedTextBox).Name.ToString().LastIndexOf("_") > 0)
                    {
                        if ((item as MaskedTextBox).Text.Trim().Length == 0)
                        {
                            return false;
                        }
                    }
                }

                if (item is PictureBox)
                {
                    if ((item as PictureBox).Name.ToString().LastIndexOf("_") > 0)
                    {
                        if ((item as PictureBox).Image == null)
                        {
                            return false;
                        }
                    }
                }


                if (item is NumericUpDown)
                {
                    if ((item as NumericUpDown).Name.ToString().LastIndexOf("_") > 0)
                    {
                        if ((item as NumericUpDown).Text.Trim().Length == 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public static string EnCode(string input)
        {

            var byteValue = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(byteValue);

        }

        public static string DeCode(string input)
        {

            byte[] data = Convert.FromBase64String(input);
            string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
            return base64Decoded;

        }
    }

}


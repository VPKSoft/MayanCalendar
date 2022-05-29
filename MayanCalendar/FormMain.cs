#region License
/*
MIT License

Copyright(c) 2022 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.Drawing;
using System.Windows.Forms;
using VPKSoft.MayanCalendar;
using VPKSoft.MayanCalendar.Enumerations;
using VPKSoft.MayanCalendar.Helpers;

namespace MayanCalendar;

public partial class FormMain : Form
{
    MayanDate current = MayanDate.FromDateTime(DateTime.Now);
    double JDNCorrectionCurrent = (double)MayanCorrection.GMT;

    public FormMain()
    {
        InitializeComponent();
        tbDayMonthYear.Text = current.Day + "." + current.Month + "." + current.Year;

        // list the JDN (Julian Day Number) corrections
        MayanCorrectionContainer mchDefault = new MayanCorrectionContainer { Correction = MayanCorrection.GMT, CorrectionName = MayanCorrection.GMT.GetAttributeDescription() };
        foreach (MayanCorrectionContainer mch in MayanDate.JDNCorrectionList)
        {
            cmbJDNCorrection.Items.Add(mch);
            if (mch.Correction == MayanCorrection.GMT)
            {
                mchDefault = mch;
            }
        }

        cmbJDNCorrection.SelectedItem = mchDefault;

        // set the date part name texts
        lbAlautunNumberName.Text = MayanDate.AlautunName;
        lbKinchiltunNumberName.Text = MayanDate.KinchiltunName;
        lbKalabtunNumberName.Text = MayanDate.KalabtunName;
        lbPiktunNumberName.Text = MayanDate.PiktunName;
        lbBaktunNumberName.Text = MayanDate.BaktunName;
        lbKatunNumberName.Text = MayanDate.KatunName;
        lbTunNumberName.Text = MayanDate.TunName;
        lbWinalNumberName.Text = MayanDate.WinalName;
        lbKinNumberName.Text = MayanDate.KinName;

        // Set the Haab' and Tzolk'in names
        lbTzolkinName.Text = MayanDate.TzolkinName + " day";
        lbHaabName.Text = MayanDate.HaabName + " month";
    }

    // try to set the date by user given date string (Gregorian calendar)
    private void tbDayMonthYear_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int year, month, day;
            string dmy = tbDayMonthYear.Text;
            year = int.Parse(dmy.Split('.')[2]);
            month = int.Parse(dmy.Split('.')[1]);
            day = int.Parse(dmy.Split('.')[0]);
            current = MayanDate.FromYearMonthDay(year, month, day, JDNCorrectionCurrent);
            tbDayMonthYear.BackColor = SystemColors.Window;
        }
        catch
        {
            tbDayMonthYear.BackColor = Color.Red;
        }
        ShowMayanDate(false);
    }

    // Show mayan date and it's details
    private void ShowMayanDate(bool detailOnly)
    {
        if (!detailOnly)
        {
            tbMayanDate.TextChanged -= tbMayanDate_TextChanged;
        }

        try
        {
            if (!detailOnly)
            {
                tbMayanDate.Text = current.ToString();
            }
            lbAlautunNumber.Text = current.Alautun.ToString();
            lbKinchiltunNumber.Text = current.Kinchiltun.ToString();
            lbKalabtunNumber.Text = current.Kalabtun.ToString();
            lbPiktunNumber.Text = current.Piktun.ToString();
            lbBaktunNumber.Text = current.Baktun.ToString();
            lbKatunNumber.Text = current.Katun.ToString();
            lbTunNumber.Text = current.Tun.ToString();
            lbWinalNumber.Text = current.Winal.ToString();
            lbKinNumber.Text = current.Kin.ToString();
            lbTzolkinHaabLord.Text = current.TzolkinDayNumber + " " + current.TzolkinDayName + ", " + current.HaabDay + " " + current.HaabMonth + ", " + current.LordOfTheNight;
            lbTzolkin.Text = current.TzolkinDayNumber + " " + current.TzolkinDayName;
            lbHaab.Text = current.HaabDay + " " + current.HaabMonth;
            lbLordOfTheNight.Text = current.LordOfTheNight;
        }
        catch
        {

        }

        if (!detailOnly)
        {
            tbMayanDate.TextChanged += tbMayanDate_TextChanged;
        }
    }

    // Show a Gregorian calendar date of the selected date
    private void ShowDate()
    {
        tbDayMonthYear.TextChanged -= tbDayMonthYear_TextChanged;
        tbDayMonthYear.Text = current.Day + "." + current.Month + "." + current.Year;
        tbDayMonthYear.TextChanged += tbDayMonthYear_TextChanged;
    }

    // Try to set the by user given date string (Mayan calendar)
    private void tbMayanDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            current = new MayanDate(tbMayanDate.Text);
            ShowDate();
            ShowMayanDate(true);
            tbMayanDate.BackColor = SystemColors.Window;
        }
        catch
        {
            tbMayanDate.BackColor = Color.Red;
        }
    }

    // Set the JDN correction number to a value selected from the combo box
    private void cmbJDNCorrection_SelectedValueChanged(object sender, EventArgs e)
    {
        tbJDNCorrectionNumber.Text = ((uint)((MayanCorrectionContainer)cmbJDNCorrection.SelectedItem).Correction).ToString();
    }

    // Try to set the JDN correction number from a string value given by the user
    private void tbJDNCorrectionNumber_TextChanged(object sender, EventArgs e)
    {
        try
        {
            JDNCorrectionCurrent = (double)uint.Parse(tbJDNCorrectionNumber.Text);
            current.SetJDNCorrection(JDNCorrectionCurrent);
            tbDayMonthYear.TextChanged -= tbDayMonthYear_TextChanged;
            tbDayMonthYear.Text = current.Day + "." + current.Month + "." + current.Year;
            tbDayMonthYear.TextChanged += tbDayMonthYear_TextChanged;
            tbJDNCorrectionNumber.BackColor = SystemColors.Window;
        }
        catch
        {
            tbJDNCorrectionNumber.BackColor = Color.Red;
        }
    }

    // Increase the selected date by one
    private void btIncMayanDate_Click(object sender, EventArgs e)
    {
        current = current.AddDays(1);
        ShowMayanDate(false);
        ShowDate();
    }

    // Decrease the selected date by one
    private void btDecMayanDate_Click(object sender, EventArgs e)
    {
        current = current.AddDays(-1);
        ShowMayanDate(false);
        ShowDate();
    }

    // Select the current system date
    private void btCurrentDate_Click(object sender, EventArgs e)
    {
        current = MayanDate.FromDateTime(DateTime.Now, JDNCorrectionCurrent);
        ShowMayanDate(false);
        ShowDate();
    }
}
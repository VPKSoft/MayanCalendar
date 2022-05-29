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

namespace MayanCalendar
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lbDayMonthYear = new System.Windows.Forms.Label();
            this.lbMayanDate = new System.Windows.Forms.Label();
            this.tbDayMonthYear = new System.Windows.Forms.TextBox();
            this.tbMayanDate = new System.Windows.Forms.TextBox();
            this.lbTzolkinHaabLord = new System.Windows.Forms.Label();
            this.cmbJDNCorrection = new System.Windows.Forms.ComboBox();
            this.lbJDNCorrection = new System.Windows.Forms.Label();
            this.tbJDNCorrectionNumber = new System.Windows.Forms.TextBox();
            this.lbJDNCorrectionNumber = new System.Windows.Forms.Label();
            this.tlpMayanDate = new System.Windows.Forms.TableLayoutPanel();
            this.lbAlautunNumberName = new System.Windows.Forms.Label();
            this.lbKinchiltunNumber = new System.Windows.Forms.Label();
            this.lbKinchiltunNumberName = new System.Windows.Forms.Label();
            this.lbKalabtunNumber = new System.Windows.Forms.Label();
            this.lbKalabtunNumberName = new System.Windows.Forms.Label();
            this.lbPiktunNumber = new System.Windows.Forms.Label();
            this.lbPiktunNumberName = new System.Windows.Forms.Label();
            this.lbBaktunNumber = new System.Windows.Forms.Label();
            this.lbBaktunNumberName = new System.Windows.Forms.Label();
            this.lbKatunNumber = new System.Windows.Forms.Label();
            this.lbKatunNumberName = new System.Windows.Forms.Label();
            this.lbTunNumber = new System.Windows.Forms.Label();
            this.lbTunNumberName = new System.Windows.Forms.Label();
            this.lbWinalNumber = new System.Windows.Forms.Label();
            this.lbWinalNumberName = new System.Windows.Forms.Label();
            this.lbKinNumber = new System.Windows.Forms.Label();
            this.lbKinNumberName = new System.Windows.Forms.Label();
            this.lbTzolkinName = new System.Windows.Forms.Label();
            this.lbTzolkin = new System.Windows.Forms.Label();
            this.lbHaabName = new System.Windows.Forms.Label();
            this.lbHaab = new System.Windows.Forms.Label();
            this.lbLordOfTheNightName = new System.Windows.Forms.Label();
            this.lbLordOfTheNight = new System.Windows.Forms.Label();
            this.lbAlautunNumber = new System.Windows.Forms.Label();
            this.btIncMayanDate = new System.Windows.Forms.Button();
            this.btDecMayanDate = new System.Windows.Forms.Button();
            this.btCurrentDate = new System.Windows.Forms.Button();
            this.tlpMayanDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDayMonthYear
            // 
            this.lbDayMonthYear.AutoSize = true;
            this.lbDayMonthYear.Location = new System.Drawing.Point(16, 14);
            this.lbDayMonthYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDayMonthYear.Name = "lbDayMonthYear";
            this.lbDayMonthYear.Size = new System.Drawing.Size(177, 15);
            this.lbDayMonthYear.TabIndex = 0;
            this.lbDayMonthYear.Text = "Gregorian calendar date (d.m.y):";
            // 
            // lbMayanDate
            // 
            this.lbMayanDate.AutoSize = true;
            this.lbMayanDate.Location = new System.Drawing.Point(16, 104);
            this.lbMayanDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMayanDate.Name = "lbMayanDate";
            this.lbMayanDate.Size = new System.Drawing.Size(173, 15);
            this.lbMayanDate.TabIndex = 5;
            this.lbMayanDate.Text = "Mayan calendar date (x.x.x.x.x):";
            // 
            // tbDayMonthYear
            // 
            this.tbDayMonthYear.Location = new System.Drawing.Point(16, 33);
            this.tbDayMonthYear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbDayMonthYear.Name = "tbDayMonthYear";
            this.tbDayMonthYear.Size = new System.Drawing.Size(204, 23);
            this.tbDayMonthYear.TabIndex = 1;
            this.tbDayMonthYear.TextChanged += new System.EventHandler(this.tbDayMonthYear_TextChanged);
            // 
            // tbMayanDate
            // 
            this.tbMayanDate.Location = new System.Drawing.Point(16, 123);
            this.tbMayanDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbMayanDate.Name = "tbMayanDate";
            this.tbMayanDate.Size = new System.Drawing.Size(204, 23);
            this.tbMayanDate.TabIndex = 6;
            this.tbMayanDate.TextChanged += new System.EventHandler(this.tbMayanDate_TextChanged);
            // 
            // lbTzolkinHaabLord
            // 
            this.lbTzolkinHaabLord.AutoSize = true;
            this.lbTzolkinHaabLord.Location = new System.Drawing.Point(16, 149);
            this.lbTzolkinHaabLord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTzolkinHaabLord.Name = "lbTzolkinHaabLord";
            this.lbTzolkinHaabLord.Size = new System.Drawing.Size(12, 15);
            this.lbTzolkinHaabLord.TabIndex = 7;
            this.lbTzolkinHaabLord.Text = "-";
            // 
            // cmbJDNCorrection
            // 
            this.cmbJDNCorrection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJDNCorrection.FormattingEnabled = true;
            this.cmbJDNCorrection.Location = new System.Drawing.Point(16, 198);
            this.cmbJDNCorrection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbJDNCorrection.Name = "cmbJDNCorrection";
            this.cmbJDNCorrection.Size = new System.Drawing.Size(204, 23);
            this.cmbJDNCorrection.TabIndex = 9;
            this.cmbJDNCorrection.SelectedValueChanged += new System.EventHandler(this.cmbJDNCorrection_SelectedValueChanged);
            // 
            // lbJDNCorrection
            // 
            this.lbJDNCorrection.AutoSize = true;
            this.lbJDNCorrection.Location = new System.Drawing.Point(12, 179);
            this.lbJDNCorrection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbJDNCorrection.Name = "lbJDNCorrection";
            this.lbJDNCorrection.Size = new System.Drawing.Size(88, 15);
            this.lbJDNCorrection.TabIndex = 8;
            this.lbJDNCorrection.Text = "JDN correction:";
            // 
            // tbJDNCorrectionNumber
            // 
            this.tbJDNCorrectionNumber.Location = new System.Drawing.Point(16, 253);
            this.tbJDNCorrectionNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbJDNCorrectionNumber.Name = "tbJDNCorrectionNumber";
            this.tbJDNCorrectionNumber.Size = new System.Drawing.Size(135, 23);
            this.tbJDNCorrectionNumber.TabIndex = 11;
            this.tbJDNCorrectionNumber.TextChanged += new System.EventHandler(this.tbJDNCorrectionNumber_TextChanged);
            // 
            // lbJDNCorrectionNumber
            // 
            this.lbJDNCorrectionNumber.AutoSize = true;
            this.lbJDNCorrectionNumber.Location = new System.Drawing.Point(12, 235);
            this.lbJDNCorrectionNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbJDNCorrectionNumber.Name = "lbJDNCorrectionNumber";
            this.lbJDNCorrectionNumber.Size = new System.Drawing.Size(133, 15);
            this.lbJDNCorrectionNumber.TabIndex = 10;
            this.lbJDNCorrectionNumber.Text = "JDN correction number:";
            // 
            // tlpMayanDate
            // 
            this.tlpMayanDate.ColumnCount = 2;
            this.tlpMayanDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMayanDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMayanDate.Controls.Add(this.lbAlautunNumberName, 1, 0);
            this.tlpMayanDate.Controls.Add(this.lbKinchiltunNumber, 0, 1);
            this.tlpMayanDate.Controls.Add(this.lbKinchiltunNumberName, 1, 1);
            this.tlpMayanDate.Controls.Add(this.lbKalabtunNumber, 0, 2);
            this.tlpMayanDate.Controls.Add(this.lbKalabtunNumberName, 1, 2);
            this.tlpMayanDate.Controls.Add(this.lbPiktunNumber, 0, 3);
            this.tlpMayanDate.Controls.Add(this.lbPiktunNumberName, 1, 3);
            this.tlpMayanDate.Controls.Add(this.lbBaktunNumber, 0, 4);
            this.tlpMayanDate.Controls.Add(this.lbBaktunNumberName, 1, 4);
            this.tlpMayanDate.Controls.Add(this.lbKatunNumber, 0, 5);
            this.tlpMayanDate.Controls.Add(this.lbKatunNumberName, 1, 5);
            this.tlpMayanDate.Controls.Add(this.lbTunNumber, 0, 6);
            this.tlpMayanDate.Controls.Add(this.lbTunNumberName, 1, 6);
            this.tlpMayanDate.Controls.Add(this.lbWinalNumber, 0, 7);
            this.tlpMayanDate.Controls.Add(this.lbWinalNumberName, 1, 7);
            this.tlpMayanDate.Controls.Add(this.lbKinNumber, 0, 8);
            this.tlpMayanDate.Controls.Add(this.lbKinNumberName, 1, 8);
            this.tlpMayanDate.Controls.Add(this.lbTzolkinName, 0, 9);
            this.tlpMayanDate.Controls.Add(this.lbTzolkin, 1, 9);
            this.tlpMayanDate.Controls.Add(this.lbHaabName, 0, 10);
            this.tlpMayanDate.Controls.Add(this.lbHaab, 1, 10);
            this.tlpMayanDate.Controls.Add(this.lbLordOfTheNightName, 0, 11);
            this.tlpMayanDate.Controls.Add(this.lbLordOfTheNight, 1, 11);
            this.tlpMayanDate.Controls.Add(this.lbAlautunNumber, 0, 0);
            this.tlpMayanDate.Location = new System.Drawing.Point(306, 12);
            this.tlpMayanDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tlpMayanDate.Name = "tlpMayanDate";
            this.tlpMayanDate.RowCount = 13;
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMayanDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMayanDate.Size = new System.Drawing.Size(246, 290);
            this.tlpMayanDate.TabIndex = 12;
            // 
            // lbAlautunNumberName
            // 
            this.lbAlautunNumberName.AutoSize = true;
            this.lbAlautunNumberName.Location = new System.Drawing.Point(127, 0);
            this.lbAlautunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlautunNumberName.Name = "lbAlautunNumberName";
            this.lbAlautunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbAlautunNumberName.TabIndex = 1;
            this.lbAlautunNumberName.Text = "-";
            // 
            // lbKinchiltunNumber
            // 
            this.lbKinchiltunNumber.AutoSize = true;
            this.lbKinchiltunNumber.Location = new System.Drawing.Point(4, 23);
            this.lbKinchiltunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKinchiltunNumber.Name = "lbKinchiltunNumber";
            this.lbKinchiltunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbKinchiltunNumber.TabIndex = 2;
            this.lbKinchiltunNumber.Text = "-";
            // 
            // lbKinchiltunNumberName
            // 
            this.lbKinchiltunNumberName.AutoSize = true;
            this.lbKinchiltunNumberName.Location = new System.Drawing.Point(127, 23);
            this.lbKinchiltunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKinchiltunNumberName.Name = "lbKinchiltunNumberName";
            this.lbKinchiltunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbKinchiltunNumberName.TabIndex = 3;
            this.lbKinchiltunNumberName.Text = "-";
            // 
            // lbKalabtunNumber
            // 
            this.lbKalabtunNumber.AutoSize = true;
            this.lbKalabtunNumber.Location = new System.Drawing.Point(4, 46);
            this.lbKalabtunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKalabtunNumber.Name = "lbKalabtunNumber";
            this.lbKalabtunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbKalabtunNumber.TabIndex = 4;
            this.lbKalabtunNumber.Text = "-";
            // 
            // lbKalabtunNumberName
            // 
            this.lbKalabtunNumberName.AutoSize = true;
            this.lbKalabtunNumberName.Location = new System.Drawing.Point(127, 46);
            this.lbKalabtunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKalabtunNumberName.Name = "lbKalabtunNumberName";
            this.lbKalabtunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbKalabtunNumberName.TabIndex = 5;
            this.lbKalabtunNumberName.Text = "-";
            // 
            // lbPiktunNumber
            // 
            this.lbPiktunNumber.AutoSize = true;
            this.lbPiktunNumber.Location = new System.Drawing.Point(4, 69);
            this.lbPiktunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPiktunNumber.Name = "lbPiktunNumber";
            this.lbPiktunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbPiktunNumber.TabIndex = 6;
            this.lbPiktunNumber.Text = "-";
            // 
            // lbPiktunNumberName
            // 
            this.lbPiktunNumberName.AutoSize = true;
            this.lbPiktunNumberName.Location = new System.Drawing.Point(127, 69);
            this.lbPiktunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPiktunNumberName.Name = "lbPiktunNumberName";
            this.lbPiktunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbPiktunNumberName.TabIndex = 7;
            this.lbPiktunNumberName.Text = "-";
            // 
            // lbBaktunNumber
            // 
            this.lbBaktunNumber.AutoSize = true;
            this.lbBaktunNumber.Location = new System.Drawing.Point(4, 92);
            this.lbBaktunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBaktunNumber.Name = "lbBaktunNumber";
            this.lbBaktunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbBaktunNumber.TabIndex = 8;
            this.lbBaktunNumber.Text = "-";
            // 
            // lbBaktunNumberName
            // 
            this.lbBaktunNumberName.AutoSize = true;
            this.lbBaktunNumberName.Location = new System.Drawing.Point(127, 92);
            this.lbBaktunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBaktunNumberName.Name = "lbBaktunNumberName";
            this.lbBaktunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbBaktunNumberName.TabIndex = 9;
            this.lbBaktunNumberName.Text = "-";
            // 
            // lbKatunNumber
            // 
            this.lbKatunNumber.AutoSize = true;
            this.lbKatunNumber.Location = new System.Drawing.Point(4, 115);
            this.lbKatunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKatunNumber.Name = "lbKatunNumber";
            this.lbKatunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbKatunNumber.TabIndex = 10;
            this.lbKatunNumber.Text = "-";
            // 
            // lbKatunNumberName
            // 
            this.lbKatunNumberName.AutoSize = true;
            this.lbKatunNumberName.Location = new System.Drawing.Point(127, 115);
            this.lbKatunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKatunNumberName.Name = "lbKatunNumberName";
            this.lbKatunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbKatunNumberName.TabIndex = 11;
            this.lbKatunNumberName.Text = "-";
            // 
            // lbTunNumber
            // 
            this.lbTunNumber.AutoSize = true;
            this.lbTunNumber.Location = new System.Drawing.Point(4, 138);
            this.lbTunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTunNumber.Name = "lbTunNumber";
            this.lbTunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbTunNumber.TabIndex = 12;
            this.lbTunNumber.Text = "-";
            // 
            // lbTunNumberName
            // 
            this.lbTunNumberName.AutoSize = true;
            this.lbTunNumberName.Location = new System.Drawing.Point(127, 138);
            this.lbTunNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTunNumberName.Name = "lbTunNumberName";
            this.lbTunNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbTunNumberName.TabIndex = 13;
            this.lbTunNumberName.Text = "-";
            // 
            // lbWinalNumber
            // 
            this.lbWinalNumber.AutoSize = true;
            this.lbWinalNumber.Location = new System.Drawing.Point(4, 161);
            this.lbWinalNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWinalNumber.Name = "lbWinalNumber";
            this.lbWinalNumber.Size = new System.Drawing.Size(12, 15);
            this.lbWinalNumber.TabIndex = 14;
            this.lbWinalNumber.Text = "-";
            // 
            // lbWinalNumberName
            // 
            this.lbWinalNumberName.AutoSize = true;
            this.lbWinalNumberName.Location = new System.Drawing.Point(127, 161);
            this.lbWinalNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWinalNumberName.Name = "lbWinalNumberName";
            this.lbWinalNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbWinalNumberName.TabIndex = 15;
            this.lbWinalNumberName.Text = "-";
            // 
            // lbKinNumber
            // 
            this.lbKinNumber.AutoSize = true;
            this.lbKinNumber.Location = new System.Drawing.Point(4, 184);
            this.lbKinNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKinNumber.Name = "lbKinNumber";
            this.lbKinNumber.Size = new System.Drawing.Size(12, 15);
            this.lbKinNumber.TabIndex = 16;
            this.lbKinNumber.Text = "-";
            // 
            // lbKinNumberName
            // 
            this.lbKinNumberName.AutoSize = true;
            this.lbKinNumberName.Location = new System.Drawing.Point(127, 184);
            this.lbKinNumberName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbKinNumberName.Name = "lbKinNumberName";
            this.lbKinNumberName.Size = new System.Drawing.Size(12, 15);
            this.lbKinNumberName.TabIndex = 17;
            this.lbKinNumberName.Text = "-";
            // 
            // lbTzolkinName
            // 
            this.lbTzolkinName.AutoSize = true;
            this.lbTzolkinName.Location = new System.Drawing.Point(4, 207);
            this.lbTzolkinName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTzolkinName.Name = "lbTzolkinName";
            this.lbTzolkinName.Size = new System.Drawing.Size(12, 15);
            this.lbTzolkinName.TabIndex = 18;
            this.lbTzolkinName.Text = "-";
            // 
            // lbTzolkin
            // 
            this.lbTzolkin.AutoSize = true;
            this.lbTzolkin.Location = new System.Drawing.Point(127, 207);
            this.lbTzolkin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTzolkin.Name = "lbTzolkin";
            this.lbTzolkin.Size = new System.Drawing.Size(12, 15);
            this.lbTzolkin.TabIndex = 19;
            this.lbTzolkin.Text = "-";
            // 
            // lbHaabName
            // 
            this.lbHaabName.AutoSize = true;
            this.lbHaabName.Location = new System.Drawing.Point(4, 230);
            this.lbHaabName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHaabName.Name = "lbHaabName";
            this.lbHaabName.Size = new System.Drawing.Size(12, 15);
            this.lbHaabName.TabIndex = 20;
            this.lbHaabName.Text = "-";
            // 
            // lbHaab
            // 
            this.lbHaab.AutoSize = true;
            this.lbHaab.Location = new System.Drawing.Point(127, 230);
            this.lbHaab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHaab.Name = "lbHaab";
            this.lbHaab.Size = new System.Drawing.Size(12, 15);
            this.lbHaab.TabIndex = 21;
            this.lbHaab.Text = "-";
            // 
            // lbLordOfTheNightName
            // 
            this.lbLordOfTheNightName.AutoSize = true;
            this.lbLordOfTheNightName.Location = new System.Drawing.Point(4, 253);
            this.lbLordOfTheNightName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLordOfTheNightName.Name = "lbLordOfTheNightName";
            this.lbLordOfTheNightName.Size = new System.Drawing.Size(98, 15);
            this.lbLordOfTheNightName.TabIndex = 22;
            this.lbLordOfTheNightName.Text = "Lord of the Night";
            // 
            // lbLordOfTheNight
            // 
            this.lbLordOfTheNight.AutoSize = true;
            this.lbLordOfTheNight.Location = new System.Drawing.Point(127, 253);
            this.lbLordOfTheNight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLordOfTheNight.Name = "lbLordOfTheNight";
            this.lbLordOfTheNight.Size = new System.Drawing.Size(12, 15);
            this.lbLordOfTheNight.TabIndex = 23;
            this.lbLordOfTheNight.Text = "-";
            // 
            // lbAlautunNumber
            // 
            this.lbAlautunNumber.AutoSize = true;
            this.lbAlautunNumber.Location = new System.Drawing.Point(4, 0);
            this.lbAlautunNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAlautunNumber.Name = "lbAlautunNumber";
            this.lbAlautunNumber.Size = new System.Drawing.Size(12, 15);
            this.lbAlautunNumber.TabIndex = 0;
            this.lbAlautunNumber.Text = "-";
            // 
            // btIncMayanDate
            // 
            this.btIncMayanDate.Location = new System.Drawing.Point(227, 33);
            this.btIncMayanDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btIncMayanDate.Name = "btIncMayanDate";
            this.btIncMayanDate.Size = new System.Drawing.Size(33, 23);
            this.btIncMayanDate.TabIndex = 2;
            this.btIncMayanDate.Text = "+d";
            this.btIncMayanDate.UseVisualStyleBackColor = true;
            this.btIncMayanDate.Click += new System.EventHandler(this.btIncMayanDate_Click);
            // 
            // btDecMayanDate
            // 
            this.btDecMayanDate.Location = new System.Drawing.Point(267, 33);
            this.btDecMayanDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btDecMayanDate.Name = "btDecMayanDate";
            this.btDecMayanDate.Size = new System.Drawing.Size(33, 23);
            this.btDecMayanDate.TabIndex = 3;
            this.btDecMayanDate.Text = "-d";
            this.btDecMayanDate.UseVisualStyleBackColor = true;
            this.btDecMayanDate.Click += new System.EventHandler(this.btDecMayanDate_Click);
            // 
            // btCurrentDate
            // 
            this.btCurrentDate.Location = new System.Drawing.Point(16, 63);
            this.btCurrentDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btCurrentDate.Name = "btCurrentDate";
            this.btCurrentDate.Size = new System.Drawing.Size(135, 23);
            this.btCurrentDate.TabIndex = 4;
            this.btCurrentDate.Text = "Current date";
            this.btCurrentDate.UseVisualStyleBackColor = true;
            this.btCurrentDate.Click += new System.EventHandler(this.btCurrentDate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 321);
            this.Controls.Add(this.btCurrentDate);
            this.Controls.Add(this.btDecMayanDate);
            this.Controls.Add(this.btIncMayanDate);
            this.Controls.Add(this.tlpMayanDate);
            this.Controls.Add(this.lbJDNCorrectionNumber);
            this.Controls.Add(this.tbJDNCorrectionNumber);
            this.Controls.Add(this.lbJDNCorrection);
            this.Controls.Add(this.cmbJDNCorrection);
            this.Controls.Add(this.lbTzolkinHaabLord);
            this.Controls.Add(this.tbMayanDate);
            this.Controls.Add(this.tbDayMonthYear);
            this.Controls.Add(this.lbMayanDate);
            this.Controls.Add(this.lbDayMonthYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.Text = "Mayan calendar test application";
            this.tlpMayanDate.ResumeLayout(false);
            this.tlpMayanDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDayMonthYear;
        private System.Windows.Forms.Label lbMayanDate;
        private System.Windows.Forms.TextBox tbDayMonthYear;
        private System.Windows.Forms.TextBox tbMayanDate;
        private System.Windows.Forms.Label lbTzolkinHaabLord;
        private System.Windows.Forms.ComboBox cmbJDNCorrection;
        private System.Windows.Forms.Label lbJDNCorrection;
        private System.Windows.Forms.TextBox tbJDNCorrectionNumber;
        private System.Windows.Forms.Label lbJDNCorrectionNumber;
        private System.Windows.Forms.TableLayoutPanel tlpMayanDate;
        private System.Windows.Forms.Label lbAlautunNumber;
        private System.Windows.Forms.Label lbAlautunNumberName;
        private System.Windows.Forms.Label lbKinchiltunNumber;
        private System.Windows.Forms.Label lbKinchiltunNumberName;
        private System.Windows.Forms.Label lbKalabtunNumber;
        private System.Windows.Forms.Label lbKalabtunNumberName;
        private System.Windows.Forms.Label lbPiktunNumber;
        private System.Windows.Forms.Label lbPiktunNumberName;
        private System.Windows.Forms.Label lbBaktunNumber;
        private System.Windows.Forms.Label lbBaktunNumberName;
        private System.Windows.Forms.Label lbKatunNumber;
        private System.Windows.Forms.Label lbKatunNumberName;
        private System.Windows.Forms.Label lbTunNumber;
        private System.Windows.Forms.Label lbTunNumberName;
        private System.Windows.Forms.Label lbWinalNumber;
        private System.Windows.Forms.Label lbWinalNumberName;
        private System.Windows.Forms.Label lbKinNumber;
        private System.Windows.Forms.Label lbKinNumberName;
        private System.Windows.Forms.Label lbTzolkinName;
        private System.Windows.Forms.Label lbTzolkin;
        private System.Windows.Forms.Label lbHaabName;
        private System.Windows.Forms.Label lbHaab;
        private System.Windows.Forms.Label lbLordOfTheNightName;
        private System.Windows.Forms.Label lbLordOfTheNight;
        private System.Windows.Forms.Button btIncMayanDate;
        private System.Windows.Forms.Button btDecMayanDate;
        private System.Windows.Forms.Button btCurrentDate;
    }
}


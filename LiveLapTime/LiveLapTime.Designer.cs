namespace LiveLapTime
{
    partial class LiveLapTime
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LiveLapTime));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblEvent = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.cmbEventList = new System.Windows.Forms.ComboBox();
            this.cmbRunsList = new System.Windows.Forms.ComboBox();
            this.lblTrack = new System.Windows.Forms.Label();
            this.lblTrackName = new System.Windows.Forms.Label();
            this.lblReport = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.lblMiles = new System.Windows.Forms.Label();
            this.lblSeries = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDriversInRace = new System.Windows.Forms.Label();
            this.resultsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDrivers = new System.Windows.Forms.Label();
            this.lblLap = new System.Windows.Forms.Label();
            this.grdMain = new System.Windows.Forms.DataGridView();
            this.boxBlue = new System.Windows.Forms.Label();
            this.lblPitStop = new System.Windows.Forms.Label();
            this.lblFastestLap = new System.Windows.Forms.Label();
            this.boxMediumPurple = new System.Windows.Forms.Label();
            this.lbl2ndBestLap = new System.Windows.Forms.Label();
            this.boxPink = new System.Windows.Forms.Label();
            this.grpColorLabels = new System.Windows.Forms.GroupBox();
            this.lblLappedCar = new System.Windows.Forms.Label();
            this.boxLightGray = new System.Windows.Forms.Label();
            this.radReport = new System.Windows.Forms.RadioButton();
            this.radLive = new System.Windows.Forms.RadioButton();
            this.btnStartLive = new System.Windows.Forms.Button();
            this.btnStopLive = new System.Windows.Forms.Button();
            this.chkAutoScroll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.grpColorLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEvent
            // 
            this.lblEvent.BackColor = System.Drawing.Color.Gainsboro;
            this.lblEvent.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(0, -2);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Padding = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.lblEvent.Size = new System.Drawing.Size(83, 29);
            this.lblEvent.TabIndex = 0;
            this.lblEvent.Text = "Event:";
            this.lblEvent.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblSession
            // 
            this.lblSession.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSession.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(0, 79);
            this.lblSession.Name = "lblSession";
            this.lblSession.Padding = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.lblSession.Size = new System.Drawing.Size(83, 28);
            this.lblSession.TabIndex = 1;
            this.lblSession.Text = "Session:";
            // 
            // cmbEventList
            // 
            this.cmbEventList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventList.Enabled = false;
            this.cmbEventList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEventList.FormattingEnabled = true;
            this.cmbEventList.Location = new System.Drawing.Point(87, 5);
            this.cmbEventList.Margin = new System.Windows.Forms.Padding(0);
            this.cmbEventList.Name = "cmbEventList";
            this.cmbEventList.Size = new System.Drawing.Size(180, 23);
            this.cmbEventList.TabIndex = 2;
            this.cmbEventList.SelectedIndexChanged += new System.EventHandler(this.cmbEventList_SelectedIndexChanged);
            this.cmbEventList.Click += new System.EventHandler(this.cmbEventList_Click);
            // 
            // cmbRunsList
            // 
            this.cmbRunsList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRunsList.Enabled = false;
            this.cmbRunsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRunsList.FormattingEnabled = true;
            this.cmbRunsList.Location = new System.Drawing.Point(87, 79);
            this.cmbRunsList.Margin = new System.Windows.Forms.Padding(0);
            this.cmbRunsList.Name = "cmbRunsList";
            this.cmbRunsList.Size = new System.Drawing.Size(180, 23);
            this.cmbRunsList.TabIndex = 3;
            this.cmbRunsList.SelectedIndexChanged += new System.EventHandler(this.cmbRunsList_SelectedIndexChanged);
            // 
            // lblTrack
            // 
            this.lblTrack.BackColor = System.Drawing.Color.Gainsboro;
            this.lblTrack.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrack.Location = new System.Drawing.Point(0, 25);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Padding = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.lblTrack.Size = new System.Drawing.Size(83, 28);
            this.lblTrack.TabIndex = 4;
            this.lblTrack.Text = "Track:";
            this.lblTrack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrackName
            // 
            this.lblTrackName.AutoSize = true;
            this.lblTrackName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrackName.Location = new System.Drawing.Point(83, 29);
            this.lblTrackName.Margin = new System.Windows.Forms.Padding(0);
            this.lblTrackName.Name = "lblTrackName";
            this.lblTrackName.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.lblTrackName.Size = new System.Drawing.Size(154, 23);
            this.lblTrackName.TabIndex = 5;
            this.lblTrackName.Text = "<< Track Name >>";
            this.lblTrackName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrackName.Visible = false;
            // 
            // lblReport
            // 
            this.lblReport.BackColor = System.Drawing.Color.Gainsboro;
            this.lblReport.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReport.Location = new System.Drawing.Point(0, 51);
            this.lblReport.Name = "lblReport";
            this.lblReport.Padding = new System.Windows.Forms.Padding(5, 2, 2, 2);
            this.lblReport.Size = new System.Drawing.Size(83, 28);
            this.lblReport.TabIndex = 6;
            this.lblReport.Text = "Report:";
            this.lblReport.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(757, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(107, 107);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 8;
            this.picLogo.TabStop = false;
            // 
            // lblRound
            // 
            this.lblRound.BackColor = System.Drawing.Color.White;
            this.lblRound.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRound.Location = new System.Drawing.Point(378, 2);
            this.lblRound.Margin = new System.Windows.Forms.Padding(0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblRound.Size = new System.Drawing.Size(379, 29);
            this.lblRound.TabIndex = 11;
            this.lblRound.Text = "<< Round 999 >>";
            this.lblRound.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRound.Visible = false;
            // 
            // lblMiles
            // 
            this.lblMiles.BackColor = System.Drawing.Color.White;
            this.lblMiles.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiles.Location = new System.Drawing.Point(563, 28);
            this.lblMiles.Margin = new System.Windows.Forms.Padding(0);
            this.lblMiles.Name = "lblMiles";
            this.lblMiles.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblMiles.Size = new System.Drawing.Size(194, 23);
            this.lblMiles.TabIndex = 14;
            this.lblMiles.Text = "<< 9.999 mile(s) >>";
            this.lblMiles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMiles.Visible = false;
            // 
            // lblSeries
            // 
            this.lblSeries.BackColor = System.Drawing.Color.White;
            this.lblSeries.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeries.Location = new System.Drawing.Point(472, 59);
            this.lblSeries.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblSeries.Size = new System.Drawing.Size(285, 19);
            this.lblSeries.TabIndex = 15;
            this.lblSeries.Text = "<< Name of Series >>";
            this.lblSeries.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSeries.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.White;
            this.lblDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(472, 79);
            this.lblDate.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lblDate.Size = new System.Drawing.Size(285, 19);
            this.lblDate.TabIndex = 16;
            this.lblDate.Text = "<< Datespace 99, 9999 >>";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Visible = false;
            // 
            // lblDriversInRace
            // 
            this.lblDriversInRace.AutoSize = true;
            this.lblDriversInRace.BackColor = System.Drawing.Color.Transparent;
            this.lblDriversInRace.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblDriversInRace.Location = new System.Drawing.Point(1, 113);
            this.lblDriversInRace.Name = "lblDriversInRace";
            this.lblDriversInRace.Size = new System.Drawing.Size(101, 14);
            this.lblDriversInRace.TabIndex = 17;
            this.lblDriversInRace.Text = "Drivers in Race:";
            this.lblDriversInRace.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDrivers
            // 
            this.lblDrivers.BackColor = System.Drawing.Color.Transparent;
            this.lblDrivers.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrivers.Location = new System.Drawing.Point(4, 131);
            this.lblDrivers.Margin = new System.Windows.Forms.Padding(0);
            this.lblDrivers.Name = "lblDrivers";
            this.lblDrivers.Size = new System.Drawing.Size(263, 19);
            this.lblDrivers.TabIndex = 18;
            this.lblDrivers.Text = "<< Driver List >>";
            this.lblDrivers.Visible = false;
            // 
            // lblLap
            // 
            this.lblLap.AutoSize = true;
            this.lblLap.BackColor = System.Drawing.Color.Transparent;
            this.lblLap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLap.Location = new System.Drawing.Point(219, 113);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(48, 14);
            this.lblLap.TabIndex = 19;
            this.lblLap.Text = "Lap ->";
            this.lblLap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // grdMain
            // 
            this.grdMain.AllowUserToAddRows = false;
            this.grdMain.AllowUserToDeleteRows = false;
            this.grdMain.AllowUserToResizeColumns = false;
            this.grdMain.AllowUserToResizeRows = false;
            this.grdMain.BackgroundColor = System.Drawing.Color.White;
            this.grdMain.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdMain.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdMain.ColumnHeadersHeight = 25;
            this.grdMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMain.DefaultCellStyle = dataGridViewCellStyle10;
            this.grdMain.EnableHeadersVisualStyles = false;
            this.grdMain.GridColor = System.Drawing.Color.Black;
            this.grdMain.Location = new System.Drawing.Point(273, 113);
            this.grdMain.Name = "grdMain";
            this.grdMain.ReadOnly = true;
            this.grdMain.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.grdMain.RowHeadersWidth = 35;
            this.grdMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.grdMain.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.grdMain.RowTemplate.Height = 15;
            this.grdMain.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMain.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.grdMain.Size = new System.Drawing.Size(585, 31);
            this.grdMain.TabIndex = 20;
            this.grdMain.Visible = false;
            this.grdMain.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.grdMain_ColumnAdded);
            this.grdMain.SelectionChanged += new System.EventHandler(this.grdMain_SelectionChanged);
            // 
            // boxBlue
            // 
            this.boxBlue.BackColor = System.Drawing.Color.RoyalBlue;
            this.boxBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxBlue.Location = new System.Drawing.Point(11, 25);
            this.boxBlue.Name = "boxBlue";
            this.boxBlue.Size = new System.Drawing.Size(20, 20);
            this.boxBlue.TabIndex = 21;
            // 
            // lblPitStop
            // 
            this.lblPitStop.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblPitStop.Location = new System.Drawing.Point(37, 25);
            this.lblPitStop.Name = "lblPitStop";
            this.lblPitStop.Size = new System.Drawing.Size(60, 20);
            this.lblPitStop.TabIndex = 22;
            this.lblPitStop.Text = "Pit Stop";
            this.lblPitStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFastestLap
            // 
            this.lblFastestLap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblFastestLap.Location = new System.Drawing.Point(129, 25);
            this.lblFastestLap.Name = "lblFastestLap";
            this.lblFastestLap.Size = new System.Drawing.Size(78, 19);
            this.lblFastestLap.TabIndex = 24;
            this.lblFastestLap.Text = "Fastest Lap";
            this.lblFastestLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxMediumPurple
            // 
            this.boxMediumPurple.BackColor = System.Drawing.Color.MediumPurple;
            this.boxMediumPurple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxMediumPurple.Location = new System.Drawing.Point(103, 25);
            this.boxMediumPurple.Name = "boxMediumPurple";
            this.boxMediumPurple.Size = new System.Drawing.Size(20, 20);
            this.boxMediumPurple.TabIndex = 23;
            // 
            // lbl2ndBestLap
            // 
            this.lbl2ndBestLap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl2ndBestLap.Location = new System.Drawing.Point(239, 19);
            this.lbl2ndBestLap.Name = "lbl2ndBestLap";
            this.lbl2ndBestLap.Size = new System.Drawing.Size(78, 34);
            this.lbl2ndBestLap.TabIndex = 26;
            this.lbl2ndBestLap.Text = "2nd Fastest Lap";
            this.lbl2ndBestLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxPink
            // 
            this.boxPink.BackColor = System.Drawing.Color.Pink;
            this.boxPink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxPink.Location = new System.Drawing.Point(213, 25);
            this.boxPink.Name = "boxPink";
            this.boxPink.Size = new System.Drawing.Size(20, 20);
            this.boxPink.TabIndex = 25;
            // 
            // grpColorLabels
            // 
            this.grpColorLabels.Controls.Add(this.lblLappedCar);
            this.grpColorLabels.Controls.Add(this.boxLightGray);
            this.grpColorLabels.Controls.Add(this.lblPitStop);
            this.grpColorLabels.Controls.Add(this.lbl2ndBestLap);
            this.grpColorLabels.Controls.Add(this.boxBlue);
            this.grpColorLabels.Controls.Add(this.boxPink);
            this.grpColorLabels.Controls.Add(this.boxMediumPurple);
            this.grpColorLabels.Controls.Add(this.lblFastestLap);
            this.grpColorLabels.Location = new System.Drawing.Point(349, 150);
            this.grpColorLabels.Name = "grpColorLabels";
            this.grpColorLabels.Size = new System.Drawing.Size(433, 64);
            this.grpColorLabels.TabIndex = 27;
            this.grpColorLabels.TabStop = false;
            this.grpColorLabels.Visible = false;
            // 
            // lblLappedCar
            // 
            this.lblLappedCar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblLappedCar.Location = new System.Drawing.Point(350, 18);
            this.lblLappedCar.Name = "lblLappedCar";
            this.lblLappedCar.Size = new System.Drawing.Size(78, 34);
            this.lblLappedCar.TabIndex = 28;
            this.lblLappedCar.Text = "Lapped Car";
            this.lblLappedCar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boxLightGray
            // 
            this.boxLightGray.BackColor = System.Drawing.Color.LightGray;
            this.boxLightGray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxLightGray.Location = new System.Drawing.Point(323, 26);
            this.boxLightGray.Name = "boxLightGray";
            this.boxLightGray.Size = new System.Drawing.Size(20, 20);
            this.boxLightGray.TabIndex = 27;
            // 
            // radReport
            // 
            this.radReport.AutoSize = true;
            this.radReport.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radReport.Location = new System.Drawing.Point(87, 61);
            this.radReport.Name = "radReport";
            this.radReport.Size = new System.Drawing.Size(118, 18);
            this.radReport.TabIndex = 200;
            this.radReport.Text = "Report Lap Chart";
            this.radReport.UseVisualStyleBackColor = true;
            this.radReport.CheckedChanged += new System.EventHandler(this.radReport_CheckedChanged);
            // 
            // radLive
            // 
            this.radLive.AutoSize = true;
            this.radLive.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radLive.Location = new System.Drawing.Point(211, 61);
            this.radLive.Name = "radLive";
            this.radLive.Size = new System.Drawing.Size(102, 18);
            this.radLive.TabIndex = 201;
            this.radLive.Text = "Live Lap Chart";
            this.radLive.UseVisualStyleBackColor = true;
            this.radLive.CheckedChanged += new System.EventHandler(this.radLive_CheckedChanged);
            // 
            // btnStartLive
            // 
            this.btnStartLive.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStartLive.Enabled = false;
            this.btnStartLive.FlatAppearance.BorderSize = 0;
            this.btnStartLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartLive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLive.Location = new System.Drawing.Point(319, 56);
            this.btnStartLive.Name = "btnStartLive";
            this.btnStartLive.Size = new System.Drawing.Size(137, 28);
            this.btnStartLive.TabIndex = 30;
            this.btnStartLive.Text = "Start Live Lap Chart";
            this.btnStartLive.UseVisualStyleBackColor = false;
            this.btnStartLive.Visible = false;
            this.btnStartLive.Click += new System.EventHandler(this.btnStartLive_Click);
            // 
            // btnStopLive
            // 
            this.btnStopLive.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnStopLive.Enabled = false;
            this.btnStopLive.FlatAppearance.BorderSize = 0;
            this.btnStopLive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopLive.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopLive.Location = new System.Drawing.Point(319, 82);
            this.btnStopLive.Name = "btnStopLive";
            this.btnStopLive.Size = new System.Drawing.Size(137, 28);
            this.btnStopLive.TabIndex = 31;
            this.btnStopLive.Text = "Stop Live Lap Chart";
            this.btnStopLive.UseVisualStyleBackColor = false;
            this.btnStopLive.Visible = false;
            this.btnStopLive.Click += new System.EventHandler(this.btnStopLive_Click);
            // 
            // chkAutoScroll
            // 
            this.chkAutoScroll.AutoSize = true;
            this.chkAutoScroll.Location = new System.Drawing.Point(790, 150);
            this.chkAutoScroll.Name = "chkAutoScroll";
            this.chkAutoScroll.Size = new System.Drawing.Size(74, 17);
            this.chkAutoScroll.TabIndex = 202;
            this.chkAutoScroll.Text = "AutoScroll";
            this.chkAutoScroll.UseVisualStyleBackColor = true;
            this.chkAutoScroll.Visible = false;
            this.chkAutoScroll.CheckedChanged += new System.EventHandler(this.chkAutoScroll_CheckedChanged);
            // 
            // LiveLapTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(863, 267);
            this.Controls.Add(this.chkAutoScroll);
            this.Controls.Add(this.btnStopLive);
            this.Controls.Add(this.btnStartLive);
            this.Controls.Add(this.radLive);
            this.Controls.Add(this.radReport);
            this.Controls.Add(this.grpColorLabels);
            this.Controls.Add(this.grdMain);
            this.Controls.Add(this.lblLap);
            this.Controls.Add(this.lblDrivers);
            this.Controls.Add(this.lblDriversInRace);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSeries);
            this.Controls.Add(this.lblMiles);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.lblReport);
            this.Controls.Add(this.lblTrackName);
            this.Controls.Add(this.lblTrack);
            this.Controls.Add(this.cmbRunsList);
            this.Controls.Add(this.cmbEventList);
            this.Controls.Add(this.lblSession);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblRound);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LiveLapTime";
            this.Text = "Lap Chart";
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.grpColorLabels.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.ComboBox cmbEventList;
        private System.Windows.Forms.ComboBox cmbRunsList;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Label lblTrackName;
        private System.Windows.Forms.Label lblReport;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Label lblMiles;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDriversInRace;
        private System.Windows.Forms.BindingSource resultsBindingSource;
        private System.Windows.Forms.Label lblDrivers;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.DataGridView grdMain;
        private System.Windows.Forms.Label boxBlue;
        private System.Windows.Forms.Label lblPitStop;
        private System.Windows.Forms.Label lblFastestLap;
        private System.Windows.Forms.Label boxMediumPurple;
        private System.Windows.Forms.Label lbl2ndBestLap;
        private System.Windows.Forms.Label boxPink;
        private System.Windows.Forms.GroupBox grpColorLabels;
        private System.Windows.Forms.RadioButton radReport;
        private System.Windows.Forms.RadioButton radLive;
        private System.Windows.Forms.Button btnStartLive;
        private System.Windows.Forms.Button btnStopLive;
        private System.Windows.Forms.Label lblLappedCar;
        private System.Windows.Forms.Label boxLightGray;
        private System.Windows.Forms.CheckBox chkAutoScroll;
    }
}


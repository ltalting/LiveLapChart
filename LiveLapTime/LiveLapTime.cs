using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Timers;
using System.Reflection;

namespace LiveLapTime
{
    public partial class LiveLapTime : Form
    {
        public string selectedEventName;
        public string selectedEventID;
        public string selectedRunID;
        public string selectedRunName;
        public int totalLaps;
        public int positionCount;
        public int restoreLapNum;
        public SqlDataReader sqlReader;
        public List<Lap> lapsList = new List<Lap>();
        public Lap lap;
        public List<string> carNoList = new List<string>();
        public List<Driver> driverList = new List<Driver>();
        public Driver driver;
        public System.Timers.Timer aTimer;
        public System.Timers.Timer bTimer;
        public System.Windows.Forms.Timer dcTimer;
        public System.Windows.Forms.Timer asTimer = new System.Windows.Forms.Timer();
        public LiveDriver liveDriver;
        public List<LiveDriver> liveDrivers = new List<LiveDriver>();
        public LiveRestore liveRestore;
        public List<LiveRestore> liveRestores = new List<LiveRestore>();

        public LiveLapTime()
        {
            InitializeComponent();
        }

        private void cmbEventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEventList.SelectedIndex == -1)
            {
            }
            else
            {
                selectedEventID = getEventID();
                lblTrackNameSet();
                cmbRunsListSet();
                lblRoundSet();
                lblMilesSet();
                cmbRunsList.Enabled = true;
            }

            if (radLive.Checked == true)
            {
                btnStartLive.Enabled = false;
                btnStartLive.BackColor = SystemColors.ControlLight;
            }
        }

        private void cmbEventList_Click(object sender, EventArgs e)
        {
            cmbEventList.Items.Clear();
            if (radReport.Checked == true)
            {
                SqlConnection sqlReports;
                sqlReports = new SqlConnection("Data Source=1.1.1.1;Initial Catalog=Reports;User ID=export;Password=password");
                using (sqlReports)
                {
                    sqlReports.Open();

                    string getEvents = "SELECT DISTINCT RTRIM(Name) AS Name FROM Events";
                    SqlCommand getEventsCMD = new SqlCommand(getEvents, sqlReports);
                    getEventsCMD.CommandTimeout = 99999;
                    using (sqlReader = getEventsCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                cmbEventList.Items.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();
                }
            }

            if (radLive.Checked == true)
            {
                SqlConnection sqlReports;
                sqlReports = new SqlConnection("Data Source=1.1.1.2;Initial Catalog=Reports;User ID=export;Password=password");
                using (sqlReports)
                {
                    sqlReports.Open();

                    string getEvents = "SELECT DISTINCT RTRIM(Name) AS Name FROM Events";
                    SqlCommand getEventsCMD = new SqlCommand(getEvents, sqlReports);
                    getEventsCMD.CommandTimeout = 99999;
                    using (sqlReader = getEventsCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                cmbEventList.Items.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();
                }
            }
        }

        private void cmbRunsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRunsList.SelectedIndex == -1)
            {
            }
            else if (radReport.Checked == true)
            {
                selectedRunID = getRunID();
                lblSeriesSet();
                lblDateSet();
                grdMainSet();
                listDriversSet();
                populateVar(false);
            }
            else if (radLive.Checked == true)
            {
                selectedRunID = getRunID();
                lblSeriesSet();
                lblDateSet();
                btnStartLive.Enabled = true;
                btnStartLive.BackColor = Color.LightGreen;
            }
        }

        private void radReport_CheckedChanged(object sender, EventArgs e)
        {
            cmbEventList.Enabled = true;
            cmbRunsList.Enabled = false;
            cmbEventList.SelectedIndex = -1;
            cmbRunsList.SelectedIndex = -1;
            btnStartLive.Visible = false;
            btnStopLive.Visible = false;
            chkAutoScroll.Visible = false;
        }

        private void radLive_CheckedChanged(object sender, EventArgs e)
        {
            cmbEventList.Enabled = true;
            cmbRunsList.Enabled = false;
            cmbEventList.SelectedIndex = -1;
            cmbRunsList.SelectedIndex = -1;
            btnStartLive.Visible = true;
            btnStopLive.Visible = true;
            btnStartLive.Enabled = false;
            btnStopLive.Enabled = false;
            btnStartLive.BackColor = SystemColors.ControlLight;
            btnStopLive.BackColor = SystemColors.ControlLight;
        }

        private void btnStartLive_Click(object sender, EventArgs e)
        {
            lapsList = new List<Lap>();
            dcTimer = new System.Windows.Forms.Timer();
            dcTimer.Tick += new EventHandler(setDataCheckTimer);
            dcTimer.Interval = 5000;
            dcTimer.Start();
            btnStartLive.Enabled = false;
            btnStopLive.Enabled = true;
            btnStopLive.BackColor = ControlPaint.LightLight(Color.Red);
            btnStartLive.BackColor = SystemColors.ControlLight;
            cmbEventList.Enabled = false;
            cmbRunsList.Enabled = false;
            radReport.Enabled = false;
        }

        private void btnStopLive_Click(object sender, EventArgs e)
        {
            btnStopLive.Enabled = false;
            btnStartLive.Enabled = true;
            btnStartLive.BackColor = Color.LightGreen;
            btnStopLive.BackColor = SystemColors.ControlLight;
            cmbEventList.Enabled = true;
            cmbRunsList.Enabled = true;
            radReport.Enabled = true;
            if (chkAutoScroll.Checked == true)
            {
                chkAutoScroll.Checked = false;
            }
            if (aTimer != null)
            {
                aTimer.Enabled = false;
                aTimer.Dispose();
                aTimer = null;
            }
            if (bTimer != null)
            {
                bTimer.Enabled = false;
                bTimer.Dispose();
                bTimer = null;
            }
        }

        /* Timer to check if grdMain should be created */
        public void setDataCheckTimer(Object source, EventArgs e)
        {
            totalLaps = getTotalLaps();
            positionCount = getPositionCount();
            if (totalLaps > 0 && positionCount > 0)
            {
                grdMainSet();
                listDriversSet();
                List<string> startOrder = new List<string>();
                SqlConnection sqlReports;
                if (radReport.Checked == true)
                {
                    sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
                }
                else
                {
                    sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
                }
                using (sqlReports)
                {
                    sqlReports.Open();

                    string getStartOrder = "SELECT RTRIM(No)AS No FROM Results ORDER BY StartPosition";
                    SqlCommand getStartOrderCMD = new SqlCommand(getStartOrder, sqlReports);
                    getStartOrderCMD.CommandTimeout = 99999;
                    using (sqlReader = getStartOrderCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                startOrder.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();
                }
                int x = 0;
                while (x < startOrder.Count())
                {
                    int driverNo = Convert.ToInt32(startOrder[x].ToString());
                    liveDriver = new LiveDriver(driverNo, 0, x);
                    liveDrivers.Add(liveDriver);
                    x++;
                }
                if (restoreLap() > 0)
                {
                    populateVar(true);
                    restoreLapNum = restoreLap();
                }
                if (restoreLap() > 123)
                {
                    dcTimer.Stop();
                    dcTimer.Enabled = false;
                    dcTimer.Dispose();
                    dcTimer = null;
                    setBTimer();
                }
                else
                {
                    dcTimer.Stop();
                    dcTimer.Enabled = false;
                    dcTimer.Dispose();
                    dcTimer = null;
                    setATimer();
                }

            }
            
        }

        /* Timer used for a LapCount < 123 */
        public void setATimer()
        {
            aTimer = new System.Timers.Timer(2500);
            aTimer.Elapsed += liveCheck;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        /* Timer used for a LapCount > 123 */
        public void setBTimer()
        {
            bTimer = new System.Timers.Timer(5000);
            bTimer.Elapsed += liveCheck;
            bTimer.AutoReset = true;
            bTimer.Enabled = true;
        }

        /* Get track name based on selected event and set lblTrackName */
        public void lblTrackNameSet()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getTrackName = "SELECT RTRIM(T1.Name) AS Name FROM Events AS E1 INNER JOIN Tracks AS T1 ON E1.TrackID = T1.TrackID WHERE EventID = '" + selectedEventID + "'";
                SqlCommand getTrackNameCMD = new SqlCommand(getTrackName, sqlReports);
                getTrackNameCMD.CommandTimeout = 99999;
                using (sqlReader = getTrackNameCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            lblTrackName.Text = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            lblTrackName.Visible = true;
        }

        /* Get run names based on selected event and populate cmbRunList */
        public void cmbRunsListSet()
        {
            /* Clear out cmbRunsList */
            cmbRunsList.Items.Clear();
            /* Set lblSeries invisible */
            lblSeries.Visible = false;
            /* Set lblDate invisible */
            lblDate.Visible = false;
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getRuns = "SELECT DISTINCT RTRIM(R1.Name) AS Name FROM Events AS E1 INNER JOIN Runs AS R1 ON E1.EventID = R1.EventID WHERE R1.EventID = '" + selectedEventID + "' AND R1.Preamble LIKE 'R%'";
                SqlCommand getRunsCMD = new SqlCommand(getRuns, sqlReports);
                getRunsCMD.CommandTimeout = 99999;
                using (sqlReader = getRunsCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            cmbRunsList.Items.Add(sqlReader[0].ToString());
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
        }

        /* Get round based on selected event and set lblRound */
        public void lblRoundSet()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getRoundName = "SELECT RTRIM(RaceNo) AS RaceNo FROM Events WHERE EventID = '" + selectedEventID + "'";
                SqlCommand getRoundCMD = new SqlCommand(getRoundName, sqlReports);
                getRoundCMD.CommandTimeout = 99999;
                using (sqlReader = getRoundCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            lblRound.Text = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            lblRound.Visible = true;
        }
       
        /* Set lblMiles to correct mileage based on Event and Track */
        public void lblMilesSet()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getTrackMiles = "SELECT T1.Length AS Miles FROM Tracks T1 INNER JOIN Events E1 ON T1.TrackID = E1.TrackID WHERE E1.EventID = '" + selectedEventID + "'";
                SqlCommand getTrackMilesCMD = new SqlCommand(getTrackMiles, sqlReports);
                getTrackMilesCMD.CommandTimeout = 99999;
                using (sqlReader = getTrackMilesCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            lblMiles.Text = sqlReader[0].ToString() + " mile(s)";
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            lblMiles.Visible = true;
        }
        
        /* Set listDrivers based on selected EventID in order of start position */
        public void listDriversSet()
        {
            /* Clear any drivers already listed */
            lblDrivers.Text = "";
            string drivers = "";
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getDrivers = "SELECT (RTRIM(No) + ' - ' + RTRIM(LastName) + ', ' + RTRIM(FirstName)  + ' (' + CAST(StartPosition AS VARCHAR) + ')' ) AS Driver FROM Results WHERE RunID = '" + selectedRunID + "' ORDER BY StartPosition";
                SqlCommand getDriversCMD = new SqlCommand(getDrivers, sqlReports);
                getDriversCMD.CommandTimeout = 99999;
                using (sqlReader = getDriversCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            drivers += (sqlReader[0].ToString() + "\n");
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            lblDrivers.Height = grdMain.Height;
            drivers += "\n";
            lblDrivers.Text = drivers;
            /* Adjust font size to fill height/width available */
            SizeF extent = TextRenderer.MeasureText(lblDrivers.Text, lblDrivers.Font);
            float hRatio = lblDrivers.Height / extent.Height;
            float wRatio = lblDrivers.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;
            float newSize = lblDrivers.Font.Size * ratio;
            lblDrivers.Font = new Font(lblDrivers.Font.FontFamily, newSize, lblDrivers.Font.Style);
            lblDrivers.Visible = true;
        }
        
        /* Set lblSeries to the correct series based on event and run */
        public void lblSeriesSet()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getSeriesName = "SELECT RTRIM(Name) AS Name FROM Series WHERE Preamble = (SELECT RIGHT(RTRIM(Preamble), 1) AS Preamble FROM Runs WHERE EventID = '" + selectedEventID + "' AND RunID = '" + selectedRunID + "')";
                SqlCommand getSeriesNameCMD = new SqlCommand(getSeriesName, sqlReports);
                getSeriesNameCMD.CommandTimeout = 99999;
                using (sqlReader = getSeriesNameCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            lblSeries.Text = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            lblSeries.Visible = true;
        }

        /* Sets date based on event and run */
        public void lblDateSet()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getDate = "SELECT FORMAT(R1.StartTime, 'MMMM d, yyyy') AS Date FROM Runs R1 INNER JOIN Events E1 ON E1.EventID = R1.EventID WHERE R1.EventID = '" + selectedEventID + "'   AND R1.RunID = '" + selectedRunID + "'";
                SqlCommand getDateCMD = new SqlCommand(getDate, sqlReports);
                getDateCMD.CommandTimeout = 99999;
                using (sqlReader = getDateCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            lblDate.Text = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            lblDate.Visible = true;
        }
        
        /* Generates the DataGridView */
        public void grdMainSet()
        {
            grdMain.Rows.Clear();
            grdMain.Columns.Clear();
            grdMain.Refresh();
            totalLaps = getTotalLaps();
            positionCount = getPositionCount();
            grdMain.ColumnCount = totalLaps;
            grdMain.RowCount = positionCount;
            for (int i = 0; i < totalLaps; i++)
            {
                grdMain.Columns[i].Name = (i + 1).ToString();
                grdMain.Columns[i].Width = 25;
            }
            for (int x = 0; x < positionCount; x++)
            {
                grdMain.Rows[x].HeaderCell.Value = (x + 1).ToString();
            }
            grdMain.Height = (15 * positionCount) + 45;
            grdMain.Visible = true;
            grdMain.DoubleBuffered(true);
            grpColorLabels.Top = grdMain.Height + 115;
            grpColorLabels.Visible = true;
            if (radLive.Checked == true)
            {
                chkAutoScroll.Top = grdMain.Height + 115;
                chkAutoScroll.Visible = true;
            }
        }

        /* Populates variables which will be used to populate the table */
        public void populateVar(bool restore)
        {
            if (restore == true)
            {
                totalLaps = restoreLap();
                positionCount = getPositionCount();
            }
            else
            {
                totalLaps = getTotalLaps();
                positionCount = getPositionCount();
            }
            /* Populates positions string List and creates a Lap object that contains both current lap as an int and positions as a string list */
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                int y = 1;
                lapsList = new List<Lap>();
                while (y <= totalLaps)
                {

                    /* Get car positions for each lap */
                    sqlReports.Open();

                    List<string> positions = new List<string>();
                    string getLapOrder = "SELECT RTRIM(R1.No) AS Number FROM Results R1 INNER JOIN Passings P1 ON R1.ResultID = P1.ResultItemID WHERE P1.RunID = '" + selectedRunID + "' AND P1.LapCount = " + y + " AND Laptime > 0 ORDER BY P1.Lapcount, P1.PassingTime";
                    SqlCommand getLapOrderCMD = new SqlCommand(getLapOrder, sqlReports);
                    getLapOrderCMD.CommandTimeout = 99999;
                    using (sqlReader = getLapOrderCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                positions.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();

                    /* Get lapped cars for each lap */
                    sqlReports.Open();

                    List<string> lappedCars = new List<string>();
                    string getLappedCars = "SELECT RTRIM(R1.No) AS Number FROM Results R1 INNER JOIN Passings P1 ON R1.ResultID = P1.ResultItemID WHERE P1.RunID = " + selectedRunID + " AND P1.PassingTime > (SELECT MIN(PassingTime) FROM Passings WHERE LapCount = " + (y + 1) + ") AND P1.LapCount = " + y + " AND Laptime > 0 ORDER BY P1.PassingTime, P1.Lapcount";
                    SqlCommand getLappedCarsCMD = new SqlCommand(getLappedCars, sqlReports);
                    getLappedCarsCMD.CommandTimeout = 99999;
                    using (sqlReader = getLappedCarsCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                lappedCars.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();

                    /* Get flag color for each lap */
                    sqlReports.Open();

                    string flagColor = "";
                    string getFlagColor = "SELECT FlagState = CASE WHEN FlagState = 1 THEN 'Green' WHEN FlagState = 2 THEN 'Yellow' WHEN FlagState = 3 THEN 'Red' WHEN FlagState = 4 THEN 'Checker' WHEN FlagState = 5 THEN 'White' WHEN FlagState = 8 THEN 'Warmup' ELSE 'Checker' END FROM Passings WHERE ElapsedTime in (SELECT MIN(ElapsedTime) FROM Passings WHERE LapCount = LeaderLap AND LeaderLap > 0 AND Deleted = 0 AND LapCount = " + y + ")";
                    SqlCommand getFlagColorCMD = new SqlCommand(getFlagColor, sqlReports);
                    getFlagColorCMD.CommandTimeout = 99999;
                    using (sqlReader = getFlagColorCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                flagColor = sqlReader[0].ToString();
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();

                    /* Get pitted cars for each lap */
                    sqlReports.Open();

                    List<string> pittedCars = new List<string>();
                    string getPittedCars = "SELECT DISTINCT RTRIM(R1.No) AS PittedCar, P1.LapCount FROM Passings P1 INNER JOIN Results R1 ON P1.ResultItemID = R1.ResultID WHERE P1.Pit = 'True' AND P1.LapCount = " + y + " AND Finish = 'True' ORDER BY P1.LapCount";
                    SqlCommand getPittedCarsCMD = new SqlCommand(getPittedCars, sqlReports);
                    getPittedCarsCMD.CommandTimeout = 99999;
                    using (sqlReader = getPittedCarsCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                pittedCars.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();

                    lap = new Lap(y, positions, lappedCars, flagColor, pittedCars);
                    lapsList.Add(lap);
                    y++;
                }

                /* Gets all driver numbers and their best lap then creates Driver objects which are put in driversList */
                sqlReports.Open();

                string driverNo = "";
                string getDriverNo = "SELECT DISTINCT RTRIM(No) AS CarNo FROM Results WHERE RTRIM(No) != '' AND RunID = " + selectedRunID;
                SqlCommand getDriverNoCMD = new SqlCommand(getDriverNo, sqlReports);
                getDriverNoCMD.CommandTimeout = 99999;
                using (sqlReader = getDriverNoCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            driverNo = sqlReader[0].ToString();
                            carNoList.Add(driverNo);
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();

                /* Gets best laps and creates a list of drivers and their best laps */
                sqlReports.Open();

                foreach (string carNo in carNoList)
                {
                    string bestLap = "";
                    string getDriverBestLap = "SELECT TOP 1 P1.Laptime, P1.LapCount FROM Results R1 INNER JOIN Passings P1 ON R1.ResultID = P1.ResultItemID WHERE R1.No = '" + carNo + "' AND P1.Laptime > 0 AND P1.LapCount > 0 GROUP BY P1.LapCount, P1.Laptime HAVING P1.LapTime = MIN(P1.LapTime)";
                    SqlCommand getDriverBestLapCMD = new SqlCommand(getDriverBestLap, sqlReports);
                    getDriverBestLapCMD.CommandTimeout = 99999;
                    using (sqlReader = getDriverBestLapCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                bestLap = sqlReader[0].ToString();
                                driver = new Driver(carNo, bestLap);
                                driverList.Add(driver);
                            }
                        }
                        sqlReader.Close();
                    }
                }

                sqlReports.Close();

                if (restore == true)
                {
                    populateTable(lapsList, true);
                }
                else
                {
                    populateTable(lapsList, false);
                }
            }
        }

        /* Populates the lap chart table */
        public void populateTable(List<Lap> lapsList, bool restore)
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                totalLaps = getTotalLaps();
                if (restore == true)
                {
                    totalLaps = restoreLap();
                }
                positionCount = getPositionCount();
                string number = "";
                int x = 0;
                int y = 0;
                //while (x < totalLaps)
                while (x < lapsList.Count())
                {
                    while (y < lapsList[x].getPositions().Count())
                    {
                        /* Load lap order for each lap */
                        number = (lapsList[x].getPositions())[y].ToString();
                        grdMain[x, y].Value = number;
                        /* Load lapped cars for each lap */
                        if (lapsList[x].getLappedCars().Count() > 0)
                        {
                            lapsList[x].getLappedCars().ForEach(delegate (string car)
                            {
                                if (string.Equals(number, car))
                                {
                                    grdMain.Rows[y].Cells[x].Style.BackColor = Color.LightGray;
                                }
                            });
                        }
                        /* Load flag color for each lap */
                        switch (lapsList[x].getFlagColor())
                        {
                            case "Green":
                                grdMain.Columns[x].HeaderCell.Style.BackColor = Color.LightGreen;
                                break;
                            case "Yellow":
                                grdMain.Columns[x].HeaderCell.Style.BackColor = Color.Yellow;
                                break;
                            case "Red":
                                grdMain.Columns[x].HeaderCell.Style.BackColor = ControlPaint.LightLight(Color.Red);
                                break;
                            case "Checker":
                                grdMain.Columns[x].HeaderCell.Style.BackColor = Color.Black;
                                grdMain.Columns[x].HeaderCell.Style.ForeColor = Color.White;
                                break;
                            case "White":
                                grdMain.Columns[x].HeaderCell.Style.BackColor = Color.White;
                                break;
                            case "Warmup":
                                grdMain.Columns[x].HeaderCell.Style.BackColor = Color.Indigo;
                                break;
                        }
                        /* Load pitted cars for each lap */
                        if (lapsList[x].getPittedCars().Count() > 0)
                        {
                            lapsList[x].getPittedCars().ForEach(delegate (string car)
                            {
                                if (string.Equals(number, car))
                                {
                                    grdMain.Rows[y].Cells[x].Style.BackColor = Color.RoyalBlue;
                                }
                            });
                        }
                        y++;
                    }
                    y = 0;
                    x++;
                }
                /* Load best laps for each driver */
                foreach (Driver driver in driverList)
                {
                    sqlReports.Open();

                    List<string> bestLapPositions = new List<string>();
                    string getBestLapOrder = "SELECT RTRIM(R1.No) AS Number FROM Results R1 INNER JOIN Passings P1 ON R1.ResultID = P1.ResultItemID WHERE R1.RunID = '" + selectedRunID + "' AND P1.LapCount = " + driver.getBestLap() + " AND Laptime > 0 ORDER BY P1.Lapcount, P1.PassingTime";
                    SqlCommand getBestLapOrderCMD = new SqlCommand(getBestLapOrder, sqlReports);
                    getBestLapOrderCMD.CommandTimeout = 99999;
                    using (sqlReader = getBestLapOrderCMD.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            if (!sqlReader.IsDBNull(0))
                            {
                                bestLapPositions.Add(sqlReader[0].ToString());
                            }
                        }
                        sqlReader.Close();
                    }

                    sqlReports.Close();

                    int a = 0;
                    while (a < bestLapPositions.Count())
                    {
                        if (driver.getCarNo().Equals(bestLapPositions[a]))
                        {
                            grdMain.Rows[a].Cells[Convert.ToInt32(driver.getBestLap()) - 1].Style.BackColor = Color.MediumPurple;
                            if (restore == true)
                            {
                                sqlReports.Open();

                                int carNoRestore = Convert.ToInt32(driver.getCarNo());
                                int restoreBestX = Convert.ToInt32(driver.getBestLap()) - 1;
                                int restoreBestY = a;
                                System.Drawing.Color restoreBestColor = Color.White;
                                List<string> carsLapped = new List<string>();
                                string getCarsLapped = "SELECT RTRIM(No) AS No FROM PASSINGS INNER JOIN RESULTS ON ResultItemID = ResultID WHERE LapTime > -1 AND LapCount < LeaderLap AND LapCount = " + driver.getBestLap();
                                SqlCommand getCarsLappedCMD = new SqlCommand(getCarsLapped, sqlReports);
                                getCarsLappedCMD.CommandTimeout = 99999;
                                using (sqlReader = getCarsLappedCMD.ExecuteReader())
                                {
                                    while (sqlReader.Read())
                                    {
                                        if (!sqlReader.IsDBNull(0))
                                        {
                                            carsLapped.Add(sqlReader[0].ToString());
                                        }
                                    }
                                    sqlReader.Close();
                                }

                                sqlReports.Close();

                                foreach (string car in carsLapped)
                                {
                                    if (Convert.ToInt32(driver.getCarNo()) == Convert.ToInt32(car))
                                    {
                                        restoreBestColor = Color.LightGray;
                                    }
                                }

                                sqlReports.Open();

                                List<string> pittedCars = new List<string>();
                                string getPittedCars = "SELECT DISTINCT RTRIM(R1.No) AS PittedCar, P1.LapCount FROM Passings P1 INNER JOIN Results R1 ON P1.ResultItemID = R1.ResultID WHERE P1.Pit = 'True' AND P1.LapCount = " + driver.getBestLap() + " AND Finish = 'True' ORDER BY P1.LapCount";
                                SqlCommand getPittedCarsCMD = new SqlCommand(getPittedCars, sqlReports);
                                getPittedCarsCMD.CommandTimeout = 99999;
                                using (sqlReader = getPittedCarsCMD.ExecuteReader())
                                {
                                    while (sqlReader.Read())
                                    {
                                        if (!sqlReader.IsDBNull(0))
                                        {
                                            pittedCars.Add(sqlReader[0].ToString());
                                        }
                                    }
                                    sqlReader.Close();
                                }

                                sqlReports.Close();

                                foreach (string car in pittedCars)
                                {
                                    if (Convert.ToInt32(driver.getCarNo()) == Convert.ToInt32(car))
                                    {
                                        restoreBestColor = Color.RoyalBlue;
                                    }
                                }
                                liveRestore = new LiveRestore(carNoRestore, restoreBestX, restoreBestY, restoreBestColor);
                                liveRestores.Add(liveRestore);
                            }
                        }
                        a++;
                    }
                }
            }
        }

        /* Main method for live reporting */
        public void liveCheck(Object source, ElapsedEventArgs e)
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                List<string> currentOrder = new List<string>();
                string getCurrOrder = "SELECT RTRIM(Laps) AS Laps, RTRIM(No) AS No, RaceRank, LastPitLap, RTRIM(FlagStatus) AS FlagStatus, BestLap, SecondBestLap FROM Results ORDER BY RaceRank ASC";
                SqlCommand getCurrOrderCMD = new SqlCommand(getCurrOrder, sqlReports);
                getCurrOrderCMD.CommandTimeout = 99999;
                using (sqlReader = getCurrOrderCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            currentOrder.Add(sqlReader[0].ToString());
                        }
                        if (!sqlReader.IsDBNull(1))
                        {
                            currentOrder.Add(sqlReader[1].ToString());
                        }
                        if (!sqlReader.IsDBNull(2))
                        {
                            currentOrder.Add(sqlReader[2].ToString());
                        }
                        if (!sqlReader.IsDBNull(3))
                        {
                            currentOrder.Add(sqlReader[3].ToString());
                        }
                        if (!sqlReader.IsDBNull(4))
                        {
                            currentOrder.Add(sqlReader[4].ToString());
                        }
                        if (!sqlReader.IsDBNull(5))
                        {
                            currentOrder.Add(sqlReader[5].ToString());
                        }
                        if (!sqlReader.IsDBNull(6))
                        {
                            currentOrder.Add(sqlReader[6].ToString());
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();

                if (getCurrentLap() > 123 && aTimer != null)
                {
                    aTimer.Stop();
                    aTimer.Enabled = false;
                    aTimer.Dispose();
                    aTimer = null;
                    setBTimer();
                    Console.WriteLine("bTimer enabled, aTimer disabled");
                }
                if (liveRestores.Count() != 0)
                {
                    updatePositions(currentOrder, true);
                    liveRestores.Clear();
                }
                else
                {
                    updatePositions(currentOrder, false);
                }
            }
        }

        /* Sets live report on DataGridView */
        public void updatePositions(List<string> currentOrder, bool restore)
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                foreach (LiveDriver driver in liveDrivers)
                {
                    if (restore == true)
                    {
                        foreach (LiveRestore res in liveRestores)
                        {
                            if (res.getCarNoRestore() == driver.getCarNo())
                            {
                                driver.setBestLapX(res.getRestoreBestX());
                                driver.setBestLapY(res.getRestoreBestY());
                                driver.setSecBestLapX(res.getRestoreBestX());
                                driver.setSecBestLapY(res.getRestoreBestY());
                                driver.setSecBestLapColor(res.getRestoreBestColor());
                            }
                        }
                    }
                    else
                    {
                        int index = 0;
                        while (index < currentOrder.Count())
                        {
                            int checkLap = Convert.ToInt32(currentOrder[index]);
                            if (driver.getCarNo() == Convert.ToInt32(currentOrder[index + 1]) && checkLap > driver.getCurrentLap())
                            {
                                driver.setCurrentLap(Convert.ToInt32(currentOrder[index]));
                                driver.setCurrentPosition(Convert.ToInt32(currentOrder[index + 2]));
                                driver.setLastPit(Convert.ToInt32(currentOrder[index + 3]));
                                driver.setFlagStatus(currentOrder[index + 4]);

                                int x = driver.getCurrentLap() - 1;
                                int y = driver.getCurrentPosition() - 1;
                                
                                //sqlReports.Open();

                                //string highestLap = "";
                                //string getHighestLap = "SELECT MAX(Laps) AS MaxLap FROM Results";
                                //SqlCommand getHighestLapCMD = new SqlCommand(getHighestLap, sqlReports);
                                //getHighestLapCMD.CommandTimeout = 99999;
                                //using (sqlReader = getHighestLapCMD.ExecuteReader())
                                //{
                                //    while (sqlReader.Read())
                                //    {
                                //        if (!sqlReader.IsDBNull(0))
                                //        {
                                //            highestLap += sqlReader[0].ToString();
                                //        }
                                //    }
                                //    sqlReader.Close();
                                //}

                                //sqlReports.Close();

                                if (driver.getCurrentLap() == getCurrentLap() && y == 0)
                                {
                                    switch (driver.getFlagStatus())
                                    {
                                        case "Green":
                                            grdMain.Columns[x].HeaderCell.Style.BackColor = Color.LightGreen;
                                            break;
                                        case "Yellow":
                                            grdMain.Columns[x].HeaderCell.Style.BackColor = Color.Yellow;
                                            break;
                                        case "Red":
                                            grdMain.Columns[x].HeaderCell.Style.BackColor = ControlPaint.LightLight(Color.Red);
                                            break;
                                        case "Finish":
                                            grdMain.Columns[x].HeaderCell.Style.BackColor = Color.Black;
                                            grdMain.Columns[x].HeaderCell.Style.ForeColor = Color.White;
                                            break;
                                        case "White":
                                            grdMain.Columns[x].HeaderCell.Style.BackColor = Color.White;
                                            break;
                                        case "Warmup":
                                            grdMain.Columns[x].HeaderCell.Style.BackColor = Color.Indigo;
                                            break;
                                    }
                                }
                                if (x >= 0 && y >= 0)
                                {
                                    grdMain[x, y].Value = driver.getCarNo();
                                }

                                sqlReports.Open();

                                List<string> carsLapped = new List<string>();
                                string getCarsLapped = "SELECT RTRIM(No) AS No FROM PASSINGS INNER JOIN RESULTS ON ResultItemID = ResultID WHERE LapTime > -1 AND LapCount < LeaderLap AND LapCount = " + driver.getCurrentLap();
                                SqlCommand getCarsLappedCMD = new SqlCommand(getCarsLapped, sqlReports);
                                getCarsLappedCMD.CommandTimeout = 99999;
                                using (sqlReader = getCarsLappedCMD.ExecuteReader())
                                {
                                    while (sqlReader.Read())
                                    {
                                        if (!sqlReader.IsDBNull(0))
                                        {
                                            carsLapped.Add(sqlReader[0].ToString());
                                        }
                                    }
                                    sqlReader.Close();
                                }

                                sqlReports.Close();

                                foreach (string car in carsLapped)
                                {
                                    if (driver.getCarNo() == Convert.ToInt32(car))
                                    {
                                        grdMain.Rows[y].Cells[x].Style.BackColor = Color.LightGray;
                                    }
                                }
                                if (driver.getCurrentLap() == driver.getLastPit())
                                {
                                    grdMain.Rows[y].Cells[x].Style.BackColor = Color.RoyalBlue;
                                }
                                if (Convert.ToInt32(currentOrder[index + 5]) - 1 == 0 && x == 0)
                                {
                                    driver.setBestLapX(0);
                                    driver.setBestLapY(y);
                                    System.Drawing.Color secBestLapColor;
                                    foreach (string car in carsLapped)
                                    {
                                        if (driver.getCarNo() == Convert.ToInt32(car))
                                        {
                                            secBestLapColor = Color.LightGray;
                                        }
                                        else
                                        {
                                            secBestLapColor = Color.White;
                                        }
                                    }
                                    if (driver.getCurrentLap() == driver.getLastPit())
                                    {
                                        secBestLapColor = Color.RoyalBlue;
                                    }
                                    else
                                    {
                                        secBestLapColor = Color.White;
                                    }
                                    driver.setSecBestLapColor(secBestLapColor);
                                    grdMain.Rows[driver.getBestLapY()].Cells[driver.getBestLapX()].Style.BackColor = Color.MediumPurple;
                                }
                                if (Convert.ToInt32(currentOrder[index + 5]) - 1 > driver.getBestLapX())
                                {
                                    driver.setSecBestLapX(driver.getBestLapX());
                                    driver.setSecBestLapY(driver.getBestLapY());
                                    driver.setBestLapX(Convert.ToInt32(currentOrder[index + 5]) - 1);
                                    driver.setBestLapY(y);
                                    System.Drawing.Color restoreColor = driver.getSecBestLapColor();
                                    if (driver.getBestLapX() > 0)
                                    {
                                        grdMain.Rows[driver.getSecBestLapY()].Cells[driver.getSecBestLapX()].Style.BackColor = restoreColor;
                                    }
                                    System.Drawing.Color secBestLapColor = Color.White;
                                    foreach (string car in carsLapped)
                                    {
                                        if (driver.getCarNo() == Convert.ToInt32(car))
                                        {
                                            secBestLapColor = Color.LightGray;
                                        }
                                    }
                                    if (driver.getCurrentLap() == driver.getLastPit())
                                    {
                                        secBestLapColor = Color.RoyalBlue;
                                    }
                                    driver.setSecBestLapColor(secBestLapColor);
                                    grdMain.Rows[driver.getBestLapY()].Cells[driver.getBestLapX()].Style.BackColor = Color.MediumPurple;
                                }
                            }
                            index += 7;
                        }
                    }
                }
            }
        }

        /* Sets and stops sutoscroll depending on chkAutoScroll status */
        private void chkAutoScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoScroll.Checked == true)
            {
                asTimer.Tick += new EventHandler(autoScroll);
                asTimer.Interval = 2500;
                asTimer.Start();
            }
            else if (chkAutoScroll.Checked == false)
            {
                asTimer.Stop();
            }
        }

        /* Method to autoscroll */
        public void autoScroll(Object source, EventArgs e)
        {
            int lap = getCurrentLap();
            if (lap > 22)
            {
                grdMain.FirstDisplayedScrollingColumnIndex = lap - 22;
            }
        }
        
        /* Gets the highest LeaderLap */
        public int getCurrentLap()
        {
            int lap = 0;
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getLap = "SELECT MAX(LeaderLap) AS Lap FROM Passings";
                string temp = "";
                SqlCommand getLapCMD = new SqlCommand(getLap, sqlReports);
                getLapCMD.CommandTimeout = 99999;
                using (sqlReader = getLapCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            temp = sqlReader[0].ToString();
                        }
                        if (temp.Equals(""))
                        {
                        }
                        else
                        {
                            lap = Convert.ToInt32(temp);
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
                return lap;
            }
        }

        /* Set columns not sortable on grdMain as they are added */
        private void grdMain_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            grdMain.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        
        /* Set cells unselectable on grdMain */
        private void grdMain_SelectionChanged(object sender, EventArgs e)
        {
            grdMain.ClearSelection();
        }
        
        /* Get the EventID from selected event's name */
        public string getEventID()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                selectedEventName = cmbEventList.SelectedItem.ToString();
                string getEventID = "SELECT RTRIM(EventID) AS EventID FROM Events WHERE Name = '" + selectedEventName + "'";
                SqlCommand getEventIDCMD = new SqlCommand(getEventID, sqlReports);
                getEventIDCMD.CommandTimeout = 99999;
                using (sqlReader = getEventIDCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            selectedEventID = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
                return selectedEventID;
            }
        }

        /* Get the RunID from selected run's name */
        public string getRunID()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                selectedRunName = cmbRunsList.SelectedItem.ToString();
                string getRunID = "SELECT RTRIM(RunID) AS RunID FROM Runs WHERE Name = '" + selectedRunName + "' AND EventID = '" + selectedEventID + "'";
                SqlCommand getRunIDCMD = new SqlCommand(getRunID, sqlReports);
                getRunIDCMD.CommandTimeout = 99999;
                using (sqlReader = getRunIDCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            selectedRunID = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
                return selectedRunID;
            }
        }

        /* Get the total number of possible positions (or # of competitors at event) */
        public int getPositionCount()
        {
            int positionCount = 0;
            string temp = "";
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getPositionCount = "SELECT DISTINCT RTRIM(COUNT(StartPosition)) AS Count FROM Results WHERE RunID = '" + selectedRunID + "'";
                SqlCommand getPositionCountCMD = new SqlCommand(getPositionCount, sqlReports);
                getPositionCountCMD.CommandTimeout = 99999;
                using (sqlReader = getPositionCountCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            temp = sqlReader[0].ToString();
                        }
                    }
                    sqlReader.Close();
                }
                positionCount = Convert.ToInt32(temp);

                sqlReports.Close();
                return positionCount;
            }
        }

        /* Finds the lap that the race is currently on for restoring data */
        public int restoreLap()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {

                sqlReports.Open();

                int theLap = 0;
                string getRestoreLaps = "SELECT MAX(LeaderLap) AS Lap FROM Passings WHERE RunID = " + selectedRunID;
                SqlCommand getTotalLapsCMD = new SqlCommand(getRestoreLaps, sqlReports);
                getTotalLapsCMD.CommandTimeout = 99999;
                using (sqlReader = getTotalLapsCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            theLap = Convert.ToInt32(sqlReader[0].ToString());
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
                return theLap;
            }
        }
        
        /* Get total number of laps for the selected event and run */
        public int getTotalLaps()
        {
            SqlConnection sqlReports;
            if (radReport.Checked == true)
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.20;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            else
            {
                sqlReports = new SqlConnection("Data Source=172.30.36.11;Initial Catalog=Reports;User ID=export;Password=eXportIRL");
            }
            using (sqlReports)
            {
                sqlReports.Open();

                string getTotalLaps = "SELECT MAX(FinishAtLap) AS TotalLaps FROM Runs WHERE EventID = '" + selectedEventID + "' AND RunID = '" + selectedRunID + "'";
                SqlCommand getTotalLapsCMD = new SqlCommand(getTotalLaps, sqlReports);
                getTotalLapsCMD.CommandTimeout = 99999;
                using (sqlReader = getTotalLapsCMD.ExecuteReader())
                {
                    while (sqlReader.Read())
                    {
                        if (!sqlReader.IsDBNull(0))
                        {
                            totalLaps = Convert.ToInt32(sqlReader[0].ToString());
                        }
                    }
                    sqlReader.Close();
                }

                sqlReports.Close();
            }
            return totalLaps;
        }
    }
    public static class DataGridViewExtensioncs
    {

        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
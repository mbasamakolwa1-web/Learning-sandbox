using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyThutorManagementSystem2
{
    public partial class StudentForm2 : Form
    {
        private readonly string studentID;

        private readonly string connectionString =
            new OleDbConnectionStringBuilder
            {
                Provider = "Microsoft.ACE.OLEDB.12.0",
                DataSource = Path.Combine(
                    AppContext.BaseDirectory,
                    "Database8.accdb")
            }.ConnectionString;

        private readonly BindingSource requestBindingSource =
           new BindingSource();

        private DataTable requestTable;
        private bool loadingRequest = false;
        private bool addingNewRequest = false;

        private class VenueInfo
        {
            public int VenueID { get; set; }
            public string VenueName { get; set; }
            public string VenueLocation { get; set; }
        }

        public StudentForm2(string userID)
        {
            InitializeComponent();

            studentID = userID;

            // Set up event handlers in code.
            // Do not also wire these same handlers in the Designer.
            Load += StudentForm2_Load;

            MarkPt.ValueChanged +=
                MarkPt_ValueChanged;

            btnCreate.Click += btnCreate_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnAdd.Click += btnAdd_Click;
            btnFirst.Click += btnFirst_Click;
            btnPrev.Click += btnPrevious_Click;
            btnNxt.Click += btnNxt_Click;
            btnLast.Click += btnLast_Click;

            requestBindingSource.PositionChanged +=
                requestBindingSource_PositionChanged;

            dgvStudentRequests.SelectionChanged +=
                dgvStudentRequests_SelectionChanged;

            radOnline.CheckedChanged += radMode_CheckedChanged;
            radInPerson.CheckedChanged += radMode_CheckedChanged;
        }

        public StudentForm2()
        {
            InitializeComponent();
        }

        private void StudentForm2_Load(object sender, EventArgs e)
        {
            try
            {
                // Make sure the columns/tables this form needs exist.
                EnsureSchema();

                dtpStuAvailability.Format = DateTimePickerFormat.Custom;
                dtpStuAvailability.CustomFormat = "dd MMM yyyy";

                MarkPt.Minimum = 0;
                MarkPt.Maximum = 100;
                MarkPt.DecimalPlaces = 1;

                LoadCourses();

                cmbSessionTimeSlot.Items.Clear();

                cmbSessionTimeSlot.Items.AddRange(new object[]
                {
                  "08:00-10:00",
                  "12:00-14:00",
                  "17:00-19:00"
                });

                cmbSessionTimeSlot.SelectedIndex = -1;

                dgvStudentRequests.ReadOnly = true;
                dgvStudentRequests.AllowUserToAddRows = false;
                dgvStudentRequests.AllowUserToDeleteRows = false;
                dgvStudentRequests.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
                dgvStudentRequests.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvStudentRequests.MultiSelect = false;

                LoadStudentRequests();

                UpdatePriorityDisplay();
                UpdateActionButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The request form could not be loaded.\n\n"
                    + ex.Message,
                    "Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Load course options from the COURSE table.
        private void LoadCourses()
        {
            using (OleDbConnection connection =
                   new OleDbConnection(connectionString))
            {
                string sql =
                    "SELECT CourseCode, CourseName FROM COURSE " +
                    "ORDER BY CourseName";

                using (OleDbDataAdapter adapter =
                       new OleDbDataAdapter(sql, connection))
                {
                    DataTable courses = new DataTable();
                    adapter.Fill(courses);

                    cmbCourse.DataSource = courses;
                    cmbCourse.DisplayMember = "CourseName";
                    cmbCourse.ValueMember = "CourseCode";
                    cmbCourse.SelectedIndex = -1;
                }
            }

            cmbSuppType.Items.Clear();
            cmbSuppType.Items.AddRange(new object[]
            {
                "Exam Preparation",
                "Assignment Assistance",
                "Concept Clarification",
                "General Academic Support"
            });
            cmbSuppType.SelectedIndex = -1;
        }

        private void dgvStudentRequests_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dgvStudentRequests.CurrentRow == null)
                return;

            if (dgvStudentRequests.CurrentRow.DataBoundItem
                is DataRowView selectedRequest)
            {
                // Picking an existing row leaves "new request" mode.
                addingNewRequest = false;

                requestBindingSource.Position =
                    requestBindingSource.IndexOf(selectedRequest);
            }
        }

        // Load only the requests belonging to this logged-in student.
        private void LoadStudentRequests()
        {
            using (OleDbConnection connection =
                   new OleDbConnection(connectionString))
            {
                string sql =
                    "SELECT * FROM TUTORINGREQUEST " +
                    "WHERE StudentID = ? ORDER BY RequestID";

                using (OleDbDataAdapter adapter =
                       new OleDbDataAdapter(sql, connection))
                {
                    adapter.SelectCommand.Parameters.Add(
                        "?", OleDbType.VarWChar, 9).Value = studentID;

                    requestTable = new DataTable();
                    adapter.Fill(requestTable);
                }
            }

            // Connect the retrieved records to the BindingSource.
            requestBindingSource.DataSource = requestTable;

            // Connect the grid to the same BindingSource.
            dgvStudentRequests.AutoGenerateColumns = true;
            dgvStudentRequests.DataSource = requestBindingSource;

            ConfigureGridColumns();

            // Display the current request in the form controls.
            DisplayCurrentRequest();
        }

        // Hide legacy/internal columns and give the rest friendly headers.
        private void ConfigureGridColumns()
        {
            string[] hide = { "AdminID", "StudentID", "Availability", "SessionTime" };
            foreach (string name in hide)
            {
                if (dgvStudentRequests.Columns.Contains(name))
                    dgvStudentRequests.Columns[name].Visible = false;
            }

            if (dgvStudentRequests.Columns.Contains("RequestedDate"))
            {
                dgvStudentRequests.Columns["RequestedDate"].HeaderText = "Session Date";
                dgvStudentRequests.Columns["RequestedDate"].DefaultCellStyle.Format = "dd MMM yyyy";
            }

            if (dgvStudentRequests.Columns.Contains("SessionTimeSlot"))
                dgvStudentRequests.Columns["SessionTimeSlot"].HeaderText = "Time Slot";

            if (dgvStudentRequests.Columns.Contains("TutoringMode"))
                dgvStudentRequests.Columns["TutoringMode"].HeaderText = "Mode";

            if (dgvStudentRequests.Columns.Contains("SubmissionDate"))
                dgvStudentRequests.Columns["SubmissionDate"].DefaultCellStyle.Format = "dd MMM yyyy HH:mm";
        }

        private void requestBindingSource_PositionChanged(
            object sender, EventArgs e)
        {
            DisplayCurrentRequest();
        }

        // Read an optional column safely (returns "" if missing or null).
        private static string Val(DataRowView r, string col)
        {
            return r.Row.Table.Columns.Contains(col) && r[col] != DBNull.Value
                ? r[col].ToString()
                : "";
        }

        // Display the selected request in the form.
        private void DisplayCurrentRequest()
        {
            if (requestBindingSource.Count == 0)
            {
                ClearRequestFields();
                lblRequestStatus.Text = "Status: New request";
                UpdateActionButtons();
                return;
            }

            loadingRequest = true;

            try
            {
                DataRowView current =
                    (DataRowView)requestBindingSource.Current;

                cmbCourse.SelectedValue = current["CourseCode"];
                cmbSuppType.Text = current["SupportType"].ToString();

                // Load the requested session date.
                if (current.Row.Table.Columns.Contains("RequestedDate") &&
                    current["RequestedDate"] != DBNull.Value)
                {
                    DateTime requestedDate =
                        Convert.ToDateTime(current["RequestedDate"]);

                    // Allow old dates when viewing existing requests.
                    dtpStuAvailability.MinDate = DateTimePicker.MinimumDateTime;
                    dtpStuAvailability.Value = requestedDate.Date;
                }

                // Load the requested time slot.
                cmbSessionTimeSlot.Text = Val(current, "SessionTimeSlot");

                // Load the requested tutoring mode.
                string mode = Val(current, "TutoringMode");

                radOnline.Checked = mode == "Online";
                radInPerson.Checked = mode == "In-Person";

                txtTopic.Text = current["Topic"].ToString();

                if (current["Latest Grade"] != DBNull.Value)
                {
                    MarkPt.Value = Math.Max(
                        MarkPt.Minimum,
                        Math.Min(
                            MarkPt.Maximum,
                            Convert.ToDecimal(current["Latest Grade"])));
                }
                else
                {
                    MarkPt.Value = 0;
                }

                lblRequestStatus.Text =
                    "Status: " + current["Status"].ToString();

                UpdatePriorityDisplay();
                UpdateActionButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The selected request could not be displayed.\n\n" +
                    ex.Message);
            }
            finally
            {
                loadingRequest = false;
            }
        }

        // Enable only the buttons that are allowed for the current request.
        private void UpdateActionButtons()
        {
            DataRowView row = requestBindingSource.Current as DataRowView;
            string status = row == null ? "" : Convert.ToString(row["Status"]);

            btnCreate.Enabled = addingNewRequest;
            btnUpdate.Enabled = !addingNewRequest && status == "Submitted";
            btnDelete.Enabled = !addingNewRequest &&
                                (status == "Submitted" || status == "Assigned");

            if (!addingNewRequest && status == "Completed")
                lblRequestStatus.Text = "Status: Completed (read-only)";
        }

        // Convert a mark into a priority level.
        private string CalculatePriority(decimal mark)
        {
            if (mark < 35)
                return "Critical";

            if (mark < 50)
                return "High";

            if (mark < 70)
                return "Medium";

            return "Low";
        }

        private void UpdatePriorityDisplay()
        {
            string priority =
                CalculatePriority(MarkPt.Value);

            lblPrioLvl.Text = "Priority: " + priority;
        }

        private void MarkPt_ValueChanged(
            object sender, EventArgs e)
        {
            if (!loadingRequest)
                UpdatePriorityDisplay();
        }

        // Check that required fields have been entered.
        private bool ValidateRequest()
        {
            if (cmbCourse.SelectedIndex == -1 ||
                cmbCourse.SelectedValue == null)
            {
                MessageBox.Show("Please select a course.");
                cmbCourse.Focus();
                return false;
            }

            if (cmbSuppType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a support type.");
                cmbSuppType.Focus();
                return false;
            }

            if (!radOnline.Checked && !radInPerson.Checked)
            {
                MessageBox.Show("Please select a session mode.");
                return false;
            }

            if (cmbSessionTimeSlot.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a session time slot.");
                cmbSessionTimeSlot.Focus();
                return false;
            }

            if (dtpStuAvailability.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Please select a valid session date.");
                return false;
            }

            string selectedSlot = cmbSessionTimeSlot.Text;
            TimeSpan startTime = TimeSpan.Parse(
                selectedSlot.Substring(0, 5));

            DateTime requestedStart =
                dtpStuAvailability.Value.Date.Add(startTime);

            if (requestedStart <= DateTime.Now)
            {
                MessageBox.Show(
                    "Please select a future date and time slot.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTopic.Text))
            {
                MessageBox.Show("Please enter the topic.");
                txtTopic.Focus();
                return false;
            }

            return true;
        }

        private DateTime GetRequestedStart()
        {
            TimeSpan start = TimeSpan.Parse(
                cmbSessionTimeSlot.Text.Substring(0, 5));

            return dtpStuAvailability.Value.Date.Add(start);
        }

        private DateTime GetRequestedEnd()
        {
            TimeSpan end = TimeSpan.Parse(
                cmbSessionTimeSlot.Text.Substring(6, 5));

            return dtpStuAvailability.Value.Date.Add(end);
        }

        private string GetSelectedMode()
        {
            return radOnline.Checked ? "Online" : "In-Person";
        }

        private bool TutorHasConflict(OleDbConnection connection, string tutorID, DateTime requestedStart, DateTime requestedEnd)
        {
            string sql =
                "SELECT SessionTime, DurationMinutes " +
                "FROM TUTORINGSESSION " +
                "WHERE TutorID = ? " +
                "AND DateValue(SessionDate) = ? " +
                "AND SessionStatus = 'Scheduled'";

            using (OleDbCommand command =
                   new OleDbCommand(sql, connection))
            {
                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 9).Value = tutorID;

                command.Parameters.Add(
                    "?", OleDbType.Date).Value =
                    requestedStart.Date;

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime storedTime =
                            Convert.ToDateTime(reader["SessionTime"]);

                        DateTime existingStart =
                            requestedStart.Date.Add(storedTime.TimeOfDay);

                        DateTime existingEnd =
                            existingStart.AddMinutes(
                                Convert.ToInt32(reader["DurationMinutes"]));

                        bool overlaps =
                            requestedStart < existingEnd &&
                            requestedEnd > existingStart;

                        if (overlaps)
                            return true;
                    }
                }
            }

            return false;
        }

        private string FindAvailableTutor(OleDbConnection connection, string courseCode, DateTime requestedDate, string timeSlot, string requestedMode)
        {
            // "Tutor Course" is a multi-value field, so it is queried with .Value
            string sql =
                "SELECT T.TutorID, T.TutoringMode " +
                "FROM TUTOR AS T " +
                "WHERE T.[Tutor Course].Value = ? " +
                "AND T.IsActive = True " +
                "AND DateValue(T.AvailableDate) = ? " +
                "AND T.SessionTimeSlot = ? " +
                "AND (T.TutoringMode = ? OR T.TutoringMode = 'Hybrid')";

            using (OleDbCommand command =
                   new OleDbCommand(sql, connection))
            {
                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 10).Value = courseCode;

                command.Parameters.Add(
                    "?", OleDbType.Date).Value = requestedDate.Date;

                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 11).Value = timeSlot;

                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 10).Value = requestedMode;

                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tutorID = reader["TutorID"].ToString();

                        if (!TutorHasConflict(
                            connection,
                            tutorID,
                            GetRequestedStart(),
                            GetRequestedEnd()))
                        {
                            return tutorID;
                        }
                    }
                }
            }

            return null;
        }

        private bool DuplicateRequestExits(OleDbConnection connection, string courseCode, DateTime requestedDate, string timeSlot, string mode)
        {
            string sql =
                "SELECT COUNT(*) FROM TUTORINGREQUEST " +
                "WHERE StudentID = ? " +
                "AND CourseCode = ? " +
                "AND RequestedDate = ? " +
                "AND SessionTimeSlot = ? " +
                "AND TutoringMode = ? " +
                "AND Status <> 'Cancelled'";

            using (OleDbCommand command =
                   new OleDbCommand(sql, connection))
            {
                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 9).Value = studentID;

                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 10).Value = courseCode;

                command.Parameters.Add(
                    "?", OleDbType.Date).Value = requestedDate.Date;

                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 11).Value = timeSlot;

                command.Parameters.Add(
                    "?", OleDbType.VarWChar, 10).Value = mode;

                return Convert.ToInt32(command.ExecuteScalar()) > 0;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!addingNewRequest)
            {
                MessageBox.Show(
                    "Please click Add before creating a new request.");
                return;
            }

            if (!ValidateRequest())
                return;

            string courseCode = cmbCourse.SelectedValue.ToString();
            string timeSlot = cmbSessionTimeSlot.Text;
            string mode = GetSelectedMode();
            DateTime requestedDate = dtpStuAvailability.Value.Date;

            // Double-booking / availability checks.
            try
            {
                using (OleDbConnection check = new OleDbConnection(connectionString))
                {
                    check.Open();

                    if (DuplicateRequestExits(check, courseCode, requestedDate, timeSlot, mode))
                    {
                        MessageBox.Show("You already have a request for this course, date, slot and mode.");
                        return;
                    }

                    if (FindAvailableTutor(check, courseCode, requestedDate, timeSlot, mode) == null)
                    {
                        MessageBox.Show("No tutor is available for that course, date, time slot and mode. " +
                                        "Please choose another.");
                        return;
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("The availability check failed.\n\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql =
                "INSERT INTO TUTORINGREQUEST " +
                "(StudentID, CourseCode, SubmissionDate, " +
                "SupportType, Availability, SessionTime, Topic, " +
                "[Latest Grade], PriorityLevel, Status, " +
                "RequestedDate, SessionTimeSlot, TutoringMode) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

            try
            {
                using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
                using (OleDbCommand command =
                       new OleDbCommand(sql, connection))
                {
                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 9).Value = studentID;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 10).Value = courseCode;

                    command.Parameters.Add(
                        "?", OleDbType.Date).Value = DateTime.Now;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 30).Value =
                        cmbSuppType.Text;

                    // Availability (5th parameter) - legacy text field,
                    // e.g. "Mon 12:00-14:00".
                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 100).Value =
                        requestedDate.ToString("ddd") + " " + timeSlot;

                    // Legacy field: save the selected slot's start time.
                    command.Parameters.Add(
                        "?", OleDbType.Date).Value =
                        DateTime.Today.Add(
                            TimeSpan.Parse(timeSlot.Substring(0, 5)));

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 100).Value =
                        txtTopic.Text.Trim();

                    command.Parameters.Add(
                        "?", OleDbType.Double).Value =
                        Convert.ToDouble(MarkPt.Value);

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 10).Value =
                        CalculatePriority(MarkPt.Value);

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 15).Value = "Submitted";

                    // RequestedDate (11th parameter)
                    command.Parameters.Add(
                        "?", OleDbType.Date).Value = requestedDate;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 11).Value = timeSlot;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 10).Value = mode;

                    connection.Open();

                    command.ExecuteNonQuery();
                }

                addingNewRequest = false;
                LoadStudentRequests();

                MessageBox.Show(
                    "Your tutoring request has been submitted.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                ClearRequestFields();
                lblRequestStatus.Text =
                    "Status: Request created successfully";
                UpdateActionButtons();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(
                    "The request could not be saved.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Switch the form into new-request mode.
            addingNewRequest = true;

            // Clear the existing form inputs.
            ClearRequestFields();

            // New requests: today or later.
            dtpStuAvailability.MinDate = DateTime.Today;
            dtpStuAvailability.Value = DateTime.Today;

            // Remove the current selection from the grid.
            dgvStudentRequests.ClearSelection();
            dgvStudentRequests.CurrentCell = null;

            lblRequestStatus.Text = "Status: New request";

            UpdateActionButtons();

            // Allow the student to begin entering information.
            cmbCourse.Focus();
        }

        // Update the selected request.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (addingNewRequest)
            {
                MessageBox.Show(
                    "You are creating a new request. " +
                    "Please use Create to save it.");
                return;
            }

            if (requestBindingSource.Current == null)
            {
                MessageBox.Show(
                    "Select an existing request to update.");
                return;
            }

            if (!ValidateRequest())
                return;

            DataRowView current =
                (DataRowView)requestBindingSource.Current;

            string status = current["Status"].ToString();

            if (status != "Submitted")
            {
                MessageBox.Show(
                    "Only requests with Submitted status can be updated.");
                return;
            }

            int requestID = Convert.ToInt32(current["RequestID"]);

            string timeSlot = cmbSessionTimeSlot.Text;
            DateTime requestedDate = dtpStuAvailability.Value.Date;
            string mode = GetSelectedMode();

            string sql =
                "UPDATE TUTORINGREQUEST SET " +
                "CourseCode = ?, SupportType = ?, Availability = ?, " +
                "SessionTime = ?, Topic = ?, [Latest Grade] = ?, " +
                "PriorityLevel = ?, RequestedDate = ?, " +
                "SessionTimeSlot = ?, TutoringMode = ? " +
                "WHERE RequestID = ? AND StudentID = ? " +
                "AND Status = 'Submitted'";

            try
            {
                using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
                using (OleDbCommand command =
                       new OleDbCommand(sql, connection))
                {
                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 10).Value =
                        cmbCourse.SelectedValue.ToString();

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 30).Value =
                        cmbSuppType.Text;

                    // Availability (3rd parameter) - legacy text field.
                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 100).Value =
                        requestedDate.ToString("ddd") + " " + timeSlot;

                    // Legacy field: derive the time from the selected slot.
                    command.Parameters.Add(
                        "?", OleDbType.Date).Value =
                        DateTime.Today.Add(
                            TimeSpan.Parse(timeSlot.Substring(0, 5)));

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 100).Value =
                        txtTopic.Text.Trim();

                    command.Parameters.Add(
                        "?", OleDbType.Double).Value =
                        Convert.ToDouble(MarkPt.Value);

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 10).Value =
                        CalculatePriority(MarkPt.Value);

                    // RequestedDate (8th parameter)
                    command.Parameters.Add(
                        "?", OleDbType.Date).Value = requestedDate;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 11).Value = timeSlot;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 10).Value = mode;

                    command.Parameters.Add(
                        "?", OleDbType.Integer).Value = requestID;

                    command.Parameters.Add(
                        "?", OleDbType.VarWChar, 9).Value = studentID;

                    connection.Open();

                    int rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated == 0)
                    {
                        MessageBox.Show(
                            "No request was updated. It may have changed " +
                            "status or may no longer be editable.");
                        return;
                    }
                }

                MessageBox.Show("Your request has been updated.");

                int oldPosition = requestBindingSource.Position;

                LoadStudentRequests();

                if (requestBindingSource.Count > 0)
                {
                    requestBindingSource.Position =
                        Math.Min(oldPosition, requestBindingSource.Count - 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The request could not be updated.\n\n" + ex.Message,
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private VenueInfo FindVenue(OleDbConnection connection)
        {
            string sql =
                "SELECT VenueID, VenueName, VenueLocation " +
                "FROM VENUE " +
                "WHERE VenueName <> 'Online (Virtual Room)' " +
                "ORDER BY VenueID";

            using (OleDbCommand command =
                   new OleDbCommand(sql, connection))
            using (OleDbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new VenueInfo
                    {
                        VenueID = Convert.ToInt32(reader["VenueID"]),
                        VenueName = reader["VenueName"].ToString(),
                        VenueLocation = reader["VenueLocation"].ToString()
                    };
                }
            }

            return null;
        }

        // Show the venue for the selected session mode.
        private void UpdateVenueDisplay()
        {
            if (radInPerson.Checked)
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(connectionString))
                    {
                        conn.Open();
                        VenueInfo v = FindVenue(conn);
                        lblVenue.Text = v == null
                            ? "No venue available"
                            : v.VenueName + " (" + v.VenueLocation + ")";
                    }
                }
                catch
                {
                    lblVenue.Text = "Venue unavailable";
                }
            }
            else if (radOnline.Checked)
            {
                lblVenue.Text = "Online (Virtual Room)";
            }
            else
            {
                lblVenue.Text = "-";
            }
        }

        private void radMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVenueDisplay();
        }

        // Cancel the selected request (the Delete button).
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (requestBindingSource.Current == null)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            DataRowView current =
                (DataRowView)requestBindingSource.Current;

            int requestID = Convert.ToInt32(current["RequestID"]);
            string status = current["Status"].ToString();

            if (status == "Completed")
            {
                MessageBox.Show(
                    "Completed requests cannot be cancelled.");
                return;
            }

            if (status == "Cancelled")
            {
                MessageBox.Show(
                    "This request has already been cancelled.");
                return;
            }

            if (status != "Submitted" && status != "Assigned")
            {
                MessageBox.Show(
                    "This request cannot be cancelled because its status is invalid.");
                return;
            }

            try
            {
                using (OleDbConnection connection =
                       new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Assigned requests must pass the 48-hour check.
                    if (status == "Assigned")
                    {
                        string sessionSql =
                            "SELECT SessionDate, SessionTime " +
                            "FROM TUTORINGSESSION " +
                            "WHERE RequestID = ? " +
                            "AND SessionStatus = 'Scheduled'";

                        DateTime scheduledStart;

                        using (OleDbCommand command =
                               new OleDbCommand(sessionSql, connection))
                        {
                            command.Parameters.Add(
                                "?", OleDbType.Integer).Value = requestID;

                            using (OleDbDataReader reader =
                                   command.ExecuteReader())
                            {
                                if (!reader.Read())
                                {
                                    MessageBox.Show(
                                        "No scheduled session was found for this request.");
                                    return;
                                }

                                DateTime sessionDate =
                                    Convert.ToDateTime(reader["SessionDate"]);

                                DateTime sessionTime =
                                    Convert.ToDateTime(reader["SessionTime"]);

                                scheduledStart = sessionDate.Date
                                    .Add(sessionTime.TimeOfDay);
                            }
                        }

                        DateTime cancellationDeadline =
                            scheduledStart.AddHours(-48);

                        if (DateTime.Now >= cancellationDeadline)
                        {
                            MessageBox.Show(
                                "This request cannot be cancelled within 48 hours " +
                                "of the scheduled session.");
                            return;
                        }
                    }

                    // Save the cancellation to the database.
                    using (OleDbTransaction transaction =
                           connection.BeginTransaction())
                    {
                        try
                        {
                            string updateRequestSql =
                                "UPDATE TUTORINGREQUEST " +
                                "SET Status = 'Cancelled' " +
                                "WHERE RequestID = ? AND StudentID = ? " +
                                "AND Status = ?";

                            using (OleDbCommand command =
                                   new OleDbCommand(
                                       updateRequestSql, connection, transaction))
                            {
                                command.Parameters.Add(
                                    "?", OleDbType.Integer).Value = requestID;

                                command.Parameters.Add(
                                    "?", OleDbType.VarWChar, 9).Value = studentID;

                                command.Parameters.Add(
                                    "?", OleDbType.VarWChar, 15).Value = status;

                                if (command.ExecuteNonQuery() != 1)
                                {
                                    throw new InvalidOperationException(
                                        "The request status changed or the request " +
                                        "could not be found.");
                                }
                            }

                            if (status == "Assigned")
                            {
                                string updateSessionSql =
                                    "UPDATE TUTORINGSESSION " +
                                    "SET SessionStatus = 'Cancelled' " +
                                    "WHERE RequestID = ? " +
                                    "AND SessionStatus = 'Scheduled'";

                                using (OleDbCommand command =
                                       new OleDbCommand(
                                           updateSessionSql, connection, transaction))
                                {
                                    command.Parameters.Add(
                                        "?", OleDbType.Integer).Value = requestID;

                                    if (command.ExecuteNonQuery() == 0)
                                    {
                                        throw new InvalidOperationException(
                                            "The scheduled session could not be cancelled.");
                                    }
                                }
                            }

                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show(
                    "Your request has been cancelled successfully.",
                    "Cancellation Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                addingNewRequest = false;
                LoadStudentRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The request could not be cancelled.\n\n" + ex.Message,
                    "Cancellation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Adds any columns/tables this form needs that the database lacks.
        private void EnsureSchema()
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                HashSet<string> existing = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                DataTable cols = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Columns,
                    new object[] { null, null, "TUTORINGREQUEST", null });
                foreach (DataRow r in cols.Rows)
                    existing.Add(r["COLUMN_NAME"].ToString());

                AddColumnIfMissing(conn, existing, "RequestedDate", "DATETIME");
                AddColumnIfMissing(conn, existing, "SessionTime", "DATETIME");
                AddColumnIfMissing(conn, existing, "SessionTimeSlot", "TEXT(11)");
                AddColumnIfMissing(conn, existing, "TutoringMode", "TEXT(10)");

                bool venueExists = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, "VENUE", "TABLE" }).Rows.Count > 0;

                if (!venueExists)
                {
                    RunSql(conn,
                        "CREATE TABLE VENUE (" +
                        "VenueID COUNTER CONSTRAINT pk_venue PRIMARY KEY, " +
                        "VenueName TEXT(100) NOT NULL, " +
                        "VenueLocation TEXT(150), " +
                        "Capacity LONG)");
                }

                int venueCount;
                using (OleDbCommand c = new OleDbCommand("SELECT COUNT(*) FROM VENUE", conn))
                    venueCount = Convert.ToInt32(c.ExecuteScalar());

                if (venueCount == 0)
                {
                    RunSql(conn, "INSERT INTO VENUE (VenueName, VenueLocation, Capacity) VALUES ('Library Study Room 1', 'Main Library, Level 1', 12)");
                    RunSql(conn, "INSERT INTO VENUE (VenueName, VenueLocation, Capacity) VALUES ('Library Study Room 2', 'Main Library, Level 2', 8)");
                    RunSql(conn, "INSERT INTO VENUE (VenueName, VenueLocation, Capacity) VALUES ('Science Block Lab A', 'Science Building, Room 101', 30)");
                    RunSql(conn, "INSERT INTO VENUE (VenueName, VenueLocation, Capacity) VALUES ('Commerce Tutorial Room', 'Commerce Building, Room 204', 25)");
                    RunSql(conn, "INSERT INTO VENUE (VenueName, VenueLocation, Capacity) VALUES ('Student Centre Hall', 'Student Centre, Ground Floor', 60)");
                    RunSql(conn, "INSERT INTO VENUE (VenueName, VenueLocation, Capacity) VALUES ('Online (Virtual Room)', 'Microsoft Teams', 100)");
                }
            }
        }

        private static void AddColumnIfMissing(
            OleDbConnection conn, HashSet<string> existing, string column, string type)
        {
            if (existing.Contains(column)) return;

            RunSql(conn,
                "ALTER TABLE TUTORINGREQUEST ADD COLUMN " + column + " " + type);
        }

        private static void RunSql(OleDbConnection conn, string sql)
        {
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                cmd.ExecuteNonQuery();
        }

        private void ClearRequestFields()
        {
            loadingRequest = true;

            try
            {
                cmbCourse.SelectedIndex = -1;
                cmbSuppType.SelectedIndex = -1;

                dtpStuAvailability.Value = DateTime.Today;

                cmbSessionTimeSlot.SelectedIndex = -1;

                radOnline.Checked = false;
                radInPerson.Checked = false;

                txtTopic.Clear();
                MarkPt.Value = 0;

                lblPrioLvl.Text = "Priority: Critical";
            }
            finally
            {
                loadingRequest = false;
            }
        }

        // Navigation buttons.
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (requestBindingSource.Count > 0)
                requestBindingSource.MoveFirst();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (requestBindingSource.Count > 0)
                requestBindingSource.MovePrevious();
        }

        private void btnNxt_Click(object sender, EventArgs e)
        {
            if (requestBindingSource.Count > 0)
                requestBindingSource.MoveNext();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (requestBindingSource.Count > 0)
                requestBindingSource.MoveLast();
        }
    }
}

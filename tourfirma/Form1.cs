using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using ClosedXML.Excel;
using System.Windows.Forms.DataVisualization.Charting;

// tourfirmatest is actual database

namespace tourfirma
{
    public partial class Form1 : Form
    {

        private NpgsqlConnection con; // ����������� � PostgreSQL
        private string connString = "Host=127.0.0.1;Username=postgres;Password=1234;Database=tourfirmatest;Include Error Detail=true";
        private DataGridViewRow selectedRow; // ��������� ������ � DataGridView


        private Chart chartPie;
        private Chart chartBar;


        private void loadDiagrams()
        {
            // ������ ��� �������� ���������
            string sqlPie = @"
    SELECT t.tour_name,
           COUNT(p.putevki_id)::float / NULLIF(total.total_count, 0) * 100 AS payment_percentage
    FROM tours t
    LEFT JOIN seasons s ON s.tour_id = t.tour_id
    LEFT JOIN putevki p ON p.season_id = s.season_id
    CROSS JOIN (
        SELECT COUNT(*) AS total_count
        FROM putevki
    ) AS total
    GROUP BY t.tour_name, total.total_count
    HAVING COUNT(p.putevki_id) > 0
    ORDER BY payment_percentage DESC;";

            // �������� ���������
            Chart PieChart = new Chart();
            PieChart.Titles.Add("������� ������ �����");
            PieChart.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
            PieChart.Location = new Point(10, 75);
            PieChart.Size = new Size(400, 400);
            tabPage7.Controls.Add(PieChart);
            PieChart.ChartAreas.Add(new ChartArea());

            Series PieSeries = new Series("PaymentPercentage");
            PieSeries.ChartType = SeriesChartType.Pie;

            // ���������� ������
            using (NpgsqlCommand cmdPie = new NpgsqlCommand(sqlPie, this.con))
            {
                using (NpgsqlDataReader reader = cmdPie.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tourName = reader["tour_name"].ToString();
                        double percentage = Convert.ToDouble(reader["payment_percentage"]);
                        PieSeries.Points.AddXY(tourName, percentage);
                    }
                }
            }


            PieSeries.Label = "#PERCENT{P0}";
            PieSeries.LegendText = "#VALX";
            PieSeries.Font = new Font("Arial", 8);
            PieChart.Series.Add(PieSeries);

            // ��������� �������
            Legend pieLegend = new Legend();
            pieLegend.Docking = Docking.Bottom;
            pieLegend.Alignment = StringAlignment.Center;
            pieLegend.Font = new Font("Arial", 8);
            PieChart.Legends.Add(pieLegend);

            //// 3D-������
            //PieChart.ChartAreas[0].Area3DStyle.Enable3D = true;
            //PieChart.ChartAreas[0].Area3DStyle.Inclination = 60;

            // ������ ��� ���������� ���������
            string sqlBar = @"
    SELECT 
        t.tour_name, 
        COALESCE(SUM(CAST(pay.summa AS numeric)), 0) AS total_payments
    FROM tours t
    JOIN seasons s ON s.tour_id = t.tour_id
    JOIN putevki p ON p.season_id = s.season_id
    JOIN payment pay ON pay.putevki_id = p.putevki_id
    GROUP BY t.tour_name
    ORDER BY total_payments DESC;";

            // ���������� ���������
            Chart BarChart = new Chart();
            BarChart.Titles.Add("����� ������ �����");
            BarChart.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);
            BarChart.Location = new Point(400, 75);
            BarChart.Size = new Size(400, 400);
            tabPage7.Controls.Add(BarChart);

            BarChart.ChartAreas.Add(new ChartArea());

            Series BarSeries = new Series("TotalPayments");
            BarSeries.ChartType = SeriesChartType.Column;
            BarSeries.IsValueShownAsLabel = true;
            BarSeries.LabelFormat = "C2"; // ������ ������

            // ���������� ������ ��� ���������� ���������
            using (NpgsqlCommand cmdBar = new NpgsqlCommand(sqlBar, this.con))
            {
                using (NpgsqlDataReader reader = cmdBar.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tourName = reader["tour_name"].ToString();
                        decimal total = Convert.ToDecimal(reader["total_payments"]);
                        BarSeries.Points.AddXY(tourName, total);
                    }
                }
            }

            BarChart.Series.Add(BarSeries);
            BarChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            // ��������� �������� ���� ���������� ���������
            BarChart.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            BarChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);
            BarChart.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            BarChart.ChartAreas[0].AxisY.Title = "�����";
            BarChart.ChartAreas[0].AxisX.Title = "���";
        }


        public Form1()
        {
            InitializeComponent();
            // ������������� ����������� � ��
            con = new NpgsqlConnection(connString);
            con.Open();
            // �������� ������ �� ��� �������
            loadTouristsCombined();
            loadSeasons();
            loadTours();
            loadPutevki();
            loadPayment();
            // ���������� ��������
            //initializeCharts();
            //loadChartsData();
            loadDiagrams();
            InitializeComboBoxes();
        }

        // � ������ InitializeComponent() ��� ������������ Form1 ��������:
        private void InitializeComboBoxes()
        {
            // ���������� ComboBox1 ��� �������������� ��������
            comboBox1.Items.AddRange(new string[]
            {
        "������������ ��������� ����",
        "����������� ��������� ����",
            });
            comboBox1.SelectedIndex = 0;

            // ���������� ComboBox2 ��� ����������������� ��������
            comboBox2.Items.AddRange(new string[]
            {
        "���������� �������� �� �������",

            });
            comboBox2.SelectedIndex = 0;
        }

        // ���������� ��������� ��������� ������ � ������� ���������
        private void dataGridViewTourists_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                selectedRow = dataGridView3.SelectedRows[0];

                if (selectedRow.Cells["tourist_id"].Value != null)
                {
                    Console.WriteLine($"������� ������ � ID: {selectedRow.Cells["tourist_id"].Value}");
                }
            }
        }

        // ���������� ������ �������� ������
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string activeTab = tabControl1.SelectedTab?.Name;
                if (activeTab == null)
                {
                    MessageBox.Show("�� ������� ���������� �������� �������!", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridView currentGrid = GetCurrentDataGridView(activeTab);
                if (currentGrid == null || currentGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("�������� ������ ��� ��������!", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = currentGrid.SelectedRows[0];
                if (selectedRow == null || selectedRow.IsNewRow)
                {
                    MessageBox.Show("�������� ���������� ������ ��� ��������!", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ������ ������������� ��������
                var result = MessageBox.Show("�� �������, ��� ������ ������� ��� ������?", "������������� ��������",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                string tableName = "";
                string idColumnName = "";
                int idValue = 0;

                // ����������� ������� � ID ��� �������� � ����������� �� �������� �������
                switch (activeTab)
                {
                    case "tabPage1": // ��������� ��� ������ �������
                        tableName = "tours"; // ������� �������� �������� �������
                        idColumnName = "tour_id";    // ������� �������� �������� ID-�������
                        if (selectedRow.Cells["tour_id"].Value != null)
                            idValue = Convert.ToInt32(selectedRow.Cells["tour_id"].Value);
                        break;
                    case "tabPage2": // �������
                        tableName = "tourists";
                        idColumnName = "tourist_id";
                        if (selectedRow.Cells["tourist_id"].Value != null)
                            idValue = Convert.ToInt32(selectedRow.Cells["tourist_id"].Value);
                        break;

                    case "tabPage3": // ������
                        tableName = "seasons";
                        idColumnName = "season_id";
                        if (selectedRow.Cells["season_id"].Value != null)
                            idValue = Convert.ToInt32(selectedRow.Cells["season_id"].Value);
                        break;

                    case "tabPage4": // �������
                        tableName = "putevki";
                        idColumnName = "putevki_id";
                        if (selectedRow.Cells["putevki_id"].Value != null)
                            idValue = Convert.ToInt32(selectedRow.Cells["putevki_id"].Value);
                        break;

                    case "tabPage5": // ������
                        tableName = "payment";
                        idColumnName = "payment_id";
                        if (selectedRow.Cells["payment_id"].Value != null)
                            idValue = Convert.ToInt32(selectedRow.Cells["payment_id"].Value);
                        break;

                    default:
                        MessageBox.Show("����������� �������!", "������",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                if (idValue == 0)
                {
                    MessageBox.Show("�� ������� ���������� ID ��� ��������!", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL-������ ��� ��������
                string sql = $@"DELETE FROM {tableName} WHERE {idColumnName} = @id;";

                // ���������� � ����������
                using (var transaction = con.BeginTransaction())
                using (var cmd = new NpgsqlCommand(sql, con, transaction))
                {
                    cmd.Parameters.AddWithValue("id", idValue);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        transaction.Commit();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("������ ������� �������!", "�����",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RefreshCurrentTab();
                        }
                        else
                        {
                            MessageBox.Show("������ �� ���� �������!", "������",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Npgsql.PostgresException ex) when (ex.SqlState == "23503")
                    {
                        // ��������� ������ �������� �����
                        transaction.Rollback();
                        string errorMessage = GetForeignKeyErrorMessage(tableName);
                        MessageBox.Show(errorMessage, "������",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"������ ��� ��������: {ex.Message}", "������",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������: {ex.Message}", "������",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���������� ��������� �� ������ ��� ��������� �������� �����
        private string GetForeignKeyErrorMessage(string tableName)
        {
            switch (tableName)
            {
                case "tourists":
                    return "������ ������� �������, ��� �������� ���������� �������!\n������� ������� ��������� �������.";
                case "seasons":
                    return "������ ������� �����, ��� �������� ���������� �������!\n������� ������� ��������� �������.";
                case "putevki":
                    return "������ ������� �������, ��� ������� ���������� �������!\n������� ������� ��������� �������.";
                default:
                    return "������ ������� ������, ��� ��� �� ��� ���� ������ � ������ ��������!";
            }
        }

        // �������� ������ � �������� � ��������������� �����������
        private void loadTouristsCombined()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = @"SELECT 
                    tourist_id, 
                    tourist_surname, 
                    tourist_name, 
                    tourist_otch,
                    passport,
                    city,
                    country,
                    phone
                    FROM tourists";

                new NpgsqlDataAdapter(sql, con).Fill(dt);

                // ��������� ������������ ���� ��������
                dt.Columns["tourist_surname"].Caption = "�������";
                dt.Columns["tourist_name"].Caption = "���";
                dt.Columns["tourist_otch"].Caption = "��������";
                dt.Columns["passport"].Caption = "�������";
                dt.Columns["city"].Caption = "�����";
                dt.Columns["country"].Caption = "������";
                dt.Columns["phone"].Caption = "�������";

                dataGridView3.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ �������� ������: {ex.Message}", "������",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �������� ������ � �������
        private void loadSeasons()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM seasons", con);
            adap.Fill(dt);
            dataGridView4.DataSource = dt;
        }

        private void loadTours()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM tours", con);
            adap.Fill(dt);
            dataGridView7.DataSource = dt;
        }

        // �������� ������ � ��������
        private void loadPutevki()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM putevki", con);
            adap.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        // �������� ������ � ��������
        private void loadPayment()
        {
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("SELECT * FROM payment", con);
            adap.Fill(dt);
            dataGridView6.DataSource = dt;
        }

        // ���������� ������ ���������� ������
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string activeTab = tabControl1.SelectedTab?.Name;
                if (activeTab == null) return;

                // �������� ����� ����������
                var form = new UniversalEditForm(activeTab, null, con);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshCurrentTab();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ����� ����������: {ex.Message}", "������",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���������� ������ �������������� ������
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string activeTab = tabControl1.SelectedTab?.Name;
                if (activeTab == null) return;

                DataGridView currentGrid = GetCurrentDataGridView(activeTab);

                if (currentGrid == null || currentGrid.SelectedRows.Count == 0)
                {
                    MessageBox.Show("�������� ������ ��� ��������������!", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = currentGrid.SelectedRows[0];
                if (selectedRow == null || selectedRow.IsNewRow)
                {
                    MessageBox.Show("�������� ���������� ������ ��� ��������������!", "������",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // �������� ����� ��������������
                var form = new UniversalEditForm(activeTab, selectedRow, con);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshCurrentTab();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ����� ��������������: {ex.Message}", "������",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���������� DataGridView �������� �������
        private DataGridView GetCurrentDataGridView(string activeTab)
        {
            switch (activeTab)
            {
                case "tabPage1": return dataGridView7;
                case "tabPage2": return dataGridView3; // �������
                case "tabPage3": return dataGridView4; // ������
                case "tabPage4": return dataGridView5; // �������
                case "tabPage5": return dataGridView6; // ������
                default: return null;
            }
        }

        // ���������� ������ �������� �������
        private void RefreshCurrentTab()
        {
            string activeTab = tabControl1.SelectedTab?.Name;
            if (activeTab == null) return;

            switch (activeTab)
            {
                case "tabPage1": loadTours(); break;
                case "tabPage2": loadTouristsCombined(); break;
                case "tabPage3": loadSeasons(); break;
                case "tabPage4": loadPutevki(); break;
                case "tabPage5": loadPayment(); break;
            }

        }

        // ���������� ���������� ��������������� �������
        private void button4_Click(object sender, EventArgs e)
        {
            string query = txtAggregateQuery.Text.Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("������� �������������� ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    // ���������� ���������� ������� (COUNT, SUM � �.�.)
                    object result = cmd.ExecuteScalar();
                    MessageBox.Show($"���������: {result}", "�������������� ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� �������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ���������� ���������� ���������������� �������
        private void button5_Click(object sender, EventArgs e)
        {
            string query = txtParametricQuery.Text.Trim();
            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("������� ��������������� ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    // ����� ����� �������� ���������, ���� ��� ���� � �������
                    // cmd.Parameters.AddWithValue("@param", value);

                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // ����� ���������� � DataGridView
                        dataGridViewResult.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� �������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // �������������� ���������� (��������)
        private void button7_Click_1(object sender, EventArgs e)
        {
            // ����� �������� ��� ������� ����������
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // ���������, ���� �� ������ � dataGridView
                if (dataGridViewResult.Rows.Count == 0)
                {
                    MessageBox.Show("��� ������ ��� ��������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ������� ������ ������ �����
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel ����� (*.xlsx)|*.xlsx",
                    Title = "��������� �����",
                    FileName = "�����.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // ������� ����� ����� Excel
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("�����");

                        // ��������� ��������
                        for (int i = 0; i < dataGridViewResult.Columns.Count; i++)
                        {
                            worksheet.Cell(1, i + 1).Value = dataGridViewResult.Columns[i].HeaderText;
                            worksheet.Cell(1, i + 1).Style.Font.Bold = true;
                        }

                        // ������ �� DataGridView
                        for (int i = 0; i < dataGridViewResult.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridViewResult.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dataGridViewResult.Rows[i].Cells[j].Value?.ToString() ?? "";
                            }
                        }

                        // ���������� �������
                        worksheet.Columns().AdjustToContents();

                        // ���������� �����
                        workbook.SaveAs(filePath);
                    }

                    MessageBox.Show($"���� ������� ��������: {filePath}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ��������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // ������ ������ �����
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel ����� (*.xlsx)|*.xlsx",
                    Title = "�������� ���� ��� �������"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // ��������� ���� Excel
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet(1); // ����� ������ ����
                        var range = worksheet.RangeUsed(); // �������� ������������ ��������

                        if (range == null)
                        {
                            MessageBox.Show("���� ���� ��� �� �������� ������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DataTable dt = new DataTable();

                        // ������ ��������� (������ ������)
                        foreach (var cell in range.FirstRow().CellsUsed())
                        {
                            dt.Columns.Add(cell.Value.ToString().Trim());
                        }

                        // ������ ������ (�� ������)
                        foreach (var row in range.RowsUsed().Skip(1))
                        {
                            DataRow dataRow = dt.NewRow();
                            int columnIndex = 0;

                            foreach (var cell in row.CellsUsed())
                            {
                                dataRow[columnIndex] = cell.Value.ToString().Trim();
                                columnIndex++;
                            }

                            dt.Rows.Add(dataRow);
                        }

                        // ��������� ������ � DataGridView
                        dataGridViewResult.DataSource = dt;
                    }

                    MessageBox.Show("������ ������� �������������!", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ������ ��������
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                // ������� ������ ������� ������� (��� �����)
                var cmd = new NpgsqlCommand(@"
                    INSERT INTO tourists (tourist_surname, tourist_name, tourist_otch, passport, city, country, phone)
                    VALUES ('��������', '������', '����������', '01234123', '������', '�������', '+79289282828')
                    RETURNING tourist_id;", con
                );

                int newTouristId = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show($"�������� ����� ������ � ID: {newTouristId}", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ������������� �� ������� ��������
                tabControl1.SelectedTab = tabPage4;

                // �������� dataGridView � ��������� � ���������
                loadTouristsCombined(); // �������� ��� ������
                loadPutevki();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������� ������� � ������������ ��������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgreg_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedQuery = comboBox1.SelectedItem.ToString();
                string sql = "";

                switch (selectedQuery)
                {
                    case "���������� �������� �� �������":
                        sql = @"SELECT country AS ������, COUNT(*) AS ����������_�������� 
                        FROM tourists 
                        GROUP BY country 
                        ORDER BY ����������_�������� DESC";
                        break;

                    case "������������ ��������� ����":
                        sql = @"SELECT MAX(price) FROM tours";
                        break;
                    case "����������� ��������� ����":
                        sql = @"SELECT MIN(price) FROM tours";
                        break;
                }

                if (!string.IsNullOrEmpty(sql))
                {
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, con))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridViewResult.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ���������� ��������������� �������: {ex.Message}", "������",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnParam_Click(object sender, EventArgs e)
        {

                string selectedQuery = comboBox2.SelectedItem.ToString();
                string sql = "";
                string paramName = "";
                string prompt = "";

                switch (selectedQuery)
                {
                    case "���������� �������� �� �������":
                        sql = @"SELECT 
    country AS ������, 
    COUNT(*) AS ����������_�������� 
FROM 
    tourists 
GROUP BY 
    country 
ORDER BY 
    ����������_�������� DESC";
                        break;


                }
            if (!string.IsNullOrEmpty(sql))
            {
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridViewResult.DataSource = dt;
                }
            }




        }
    }
}
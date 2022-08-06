
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using CsvHelper;
using CsvHelper.Configuration;

namespace CSVEditor
{
    public partial class Form1 : Form
    {
        //provides access to filePath accross the program
        static string filePath = "";

        //background worker for parsing the file.
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        DataTable dataTable = new DataTable();
        
        //error message
        const string TROUBLE_LOADING_ERROR_MESSAGE = "Error Loading the CSV file.";
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();

            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWroker_ProgressCompletd;
            backgroundWorker.WorkerReportsProgress = true;

            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.ReadOnly = false;
            dataGridView1.VirtualMode = true;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.AutoResizeColumns();

        }


        /// <summary>
        /// Load file click event to open dialogue box and start the parsing of CSV file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadfile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {

                    openFileDialog.Filter = "csv files (*.csv)|*.csv";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        fileStream.Close();
                        fileStream.Dispose();
                        lblFileName.Text = " File : " + Path.GetFileName(filePath);
                        pbLoading.Visible = true;
                        backgroundWorker.RunWorkerAsync();

                    }
                }
            }
            catch (FileLoadException ex)
            {
                log.Debug(ex);
                MessageBox.Show(TROUBLE_LOADING_ERROR_MESSAGE);
            }

        }


        /// <summary>
        /// string replace button click event, gets all the selected cells and replaces a with @.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStringReplace_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach (DataGridViewCell iteam in dataGridView1.SelectedCells)
                {

                    dataGridView1[iteam.ColumnIndex, iteam.RowIndex].Value = iteam.Value.ToString().Replace('a', '@');

                }
            }

            dataGridView1.Refresh();
        }


        /// <summary>
        /// cell enter edit event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.BeginEdit(true);
        }

        /// <summary>
        /// background process to parse and fill the data table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                dataTable = new DataTable();
                var conf = new CsvConfiguration(new CultureInfo("en-US"));
                conf.IgnoreBlankLines = true;
                bool skipTheEmptyRow = false;
                using (CsvReader csv = new CsvHelper.CsvReader(new StreamReader(filePath), conf))
                {

                    csv.Read();
                    csv.ReadHeader();

                    try
                    {
                        for (int i = 0; i < csv.HeaderRecord.Length; i++)
                        {
                            dataTable.Columns.Add(csv.HeaderRecord[i], typeof(string));
                        }

                    }
                    catch (Exception ex)
                    {
                        //header info might not be found.
                        log.Info(ex);
                    }


                    var records = csv.GetRecords<dynamic>();
                    foreach (var record in records)
                    {
                        DataRow dr = dataTable.NewRow();
                        foreach (var iteam in record)
                        {
                            if (!String.IsNullOrEmpty(iteam.Value))
                            {
                                dr[iteam.Key] = iteam.Value;
                            }
                            else
                            {
                                skipTheEmptyRow = true;
                            }
                        }
                        if (!skipTheEmptyRow)
                        {
                            dataTable.Rows.Add(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Debug(ex);
                MessageBox.Show(TROUBLE_LOADING_ERROR_MESSAGE);
            }
        }

        /// <summary>
        /// background worker completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWroker_ProgressCompletd(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.Invoke(new Action(() =>
            {
                dataGridView1.DataSource = dataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.Selected = false;
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Refresh();
                pbLoading.Visible = false;


            }));
        }

        /// <summary>
        /// save the current file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveCliked(object sender, EventArgs e)
        {
            SaveFile(filePath);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            log.Debug(ex);
                            MessageBox.Show("File creation error.");
                        }
                    }
                    if (!fileError)
                    {
                        SaveFile(sfd.FileName);
                    }
                }
            }
        }

        /// <summary>
        /// Stores the file to the disk.
        /// </summary>
        /// <param name="fileName">Save fileName</param>
        private void SaveFile(string fileName)
        {
            try
            {
                int columnCount = dataGridView1.Columns.Count;
                string columnNames = "";
                //string[] outputCsv = new string[dataGridView1.Rows.Count + 1];
                using (StreamWriter outfile = new StreamWriter(fileName))
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                    }

                    outfile.WriteLine(columnNames.TrimEnd(','));

                    for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                    {
                        string currentLine = "";
                        for (int j = 0; j < columnCount; j++)
                        {
                            if (dataGridView1.Rows[i - 1].Cells[j].Value != null)
                            {
                                currentLine += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";

                            }
                        }
                        outfile.WriteLine(currentLine);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message);
            }

        }

        /// <summary>
        /// Formload event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                string FileName = "./combo_example.csv";
                if (File.Exists(FileName))
                {
                    var fileContent = File.ReadAllLines(FileName);
                    foreach (string line in fileContent)
                    {
                        var data = line.Split(',');
                        if (data.Length > 1)
                        {
                            var str = data[1];
                            cbDropdown.Items.Add(str);

                        }
                    }
                    cbDropdown.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                log.Debug(ex);
                cbDropdown.Items.Add("--ERROR--");
            }
        }
    }
}

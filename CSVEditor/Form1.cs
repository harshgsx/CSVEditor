
using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Text;

namespace CSVEditor
{
    public partial class Form1 : Form
    {

        static string filePath = "";

        BackgroundWorker backgroundWorker = new BackgroundWorker();

        DataTable dataTable = new DataTable();

        const string TROUBLE_LOADING_ERROR_MESSAGE = "Error Loading the CSV file.";


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



        private void btnLoadfile_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
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
                        lblFileName.Text = Path.GetFileName(filePath);
                        pbLoading.Visible = true;
                        backgroundWorker.RunWorkerAsync();

                    }
                }
            }
            catch (FileLoadException ex)
            {
                MessageBox.Show(TROUBLE_LOADING_ERROR_MESSAGE);

            }

        }



        private void btnStringReplace_Click(object sender, EventArgs e)
        {
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                foreach(DataGridViewCell iteam in dataGridView1.SelectedCells)
                {

                    dataGridView1[iteam.ColumnIndex, iteam.RowIndex].Value = iteam.Value.ToString().Replace('a', '@');

                }
            }

            dataGridView1.Refresh();
        }

    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.BeginEdit(true);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var conf = new CsvConfiguration(new CultureInfo("en-US"));
            conf.IgnoreBlankLines = true;
            bool skipTheEmptyRow = false;
            using (CsvReader csv = new CsvHelper.CsvReader(new StreamReader(filePath), conf))
            {

                csv.Read();
                csv.ReadHeader();

                for (int i = 0; i < csv.HeaderRecord.Length; i++)
                {
                    dataTable.Columns.Add(csv.HeaderRecord[i], typeof(string));
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFile(filePath);
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV (*.csv)|*.csv";
                sfd.FileName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") +".csv";
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
                            if(dataGridView1.Rows[i - 1].Cells[j].Value != null)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            string FileName = "./combo_example.csv";
            
            
            if (File.Exists(FileName))
            {
                var fileContent = File.ReadAllLines(FileName);
                foreach(string line in fileContent)
                {
                    var data = line.Split(',');
                    if(data.Length > 1)
                    {
                        var str = data[1];
                        cbDropdown.Items.Add(str);

                    }



                }

                cbDropdown.SelectedIndex = 0;
            }
           
        }
    }
}

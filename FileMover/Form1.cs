using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FileMoverApp
{
    public partial class Form1 : Form
    {
        private const string ConfigFilePath = "Config.xml";
        public Form1()
        {
            InitializeComponent();
            EnsureConfigFileExists();
            LoadLastTextBoxValue();
        }

        private void EnsureConfigFileExists()
        {
            if (!File.Exists(ConfigFilePath))
            {
                try
                {
                    XDocument config = new XDocument(
                        new XElement("Configuration",
                            new XElement("LastTextBoxValue", ""),
                            new XElement("LastSourceValue", ""),
                            new XElement("LastDestinationValue", "")
                        )
                    );
                    config.Save(ConfigFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao criar o arquivo de configuração: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadLastTextBoxValue()
        {
            try
            {
                XDocument config = XDocument.Load(ConfigFilePath);

                var valueElement1 = config.Root.Element("LastTextBoxValue");

                if (valueElement1 != null)
                {
                    textBox1.Text = valueElement1.Value;
                }

                var valueElement2 = config.Root.Element("LastSourceValue");

                if (valueElement2 != null)
                {
                    txtSourceFolder.Text = valueElement2.Value;
                }

                var valueElement3 = config.Root.Element("LastDestinationValue");

                if (valueElement3 != null)
                {
                    txtDestinationFolder.Text = valueElement3.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o valor: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveLastTextBoxValue()
        {
            try
            {
                XDocument config = new XDocument(
                    new XElement("Configuration",
                        new XElement("LastTextBoxValue", textBox1.Text),
                        new XElement("LastSourceValue", txtSourceFolder.Text),
                        new XElement("LastDestinationValue", txtDestinationFolder.Text)
                    )
                );
                config.Save(ConfigFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o valor: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastTextBoxValue();
        }

        private void btnSelectSource_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSourceFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSelectDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtDestinationFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnLoadGrid_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceFolder.Text))
            {
                MessageBox.Show("Please select a source folder.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var thread = new Thread(LoadGrid);
            thread.Start();
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSourceFolder.Text) || string.IsNullOrEmpty(txtDestinationFolder.Text))
            {
                MessageBox.Show("Please select both source and destination folders.");
                return;
            }

            var thread = new Thread(CopyFiles);
            thread.Start();
        }

        private void LoadGrid()
        {
            Invoke(new Action(() => 
            { 

            //string[] files = Directory.GetFiles(txtSourceFolder.Text);

                // ORIGEM : C:\Delvined\Inspeção de Pontes\Métrica\                                         -> 2023\Sub1\Km 219+300 pt
                // DESTINO: C:\Rumo\Infraestrutura e OAEs - 10. ENGENHARIA\7-Cadastro e Gestão de Ativos\   -> Sub 01\Km 219+300 pt

                string[] files = Directory.GetFiles(txtSourceFolder.Text)
                .Where(file => !IsFileHidden(file))
                .ToArray();

            string[] pathsSource = Directory.GetDirectories(txtSourceFolder.Text);

            dataGridView.Rows.Clear();

            Boolean achou = false;

            Boolean achouPathOk = false;

            int totPath = textBox1.Text.Where(char.IsDigit).Any() ? int.Parse(textBox1.Text) : 0;

            if (totPath > 0)
            {
                if (pathsSource.Length > 0)
                {
                    foreach (string pathSource in pathsSource)
                    {
                        string[] pathsSource2 = Directory.GetDirectories(pathSource);

                        if (pathsSource2.Length > 0)
                        {
                            foreach (string pathSource2 in pathsSource2)
                            {
                                string[] pathsSource3 = Directory.GetDirectories(pathSource2);

                                if (pathsSource3.Length > 0)
                                {
                                    foreach (string pathSource3 in pathsSource3)
                                    {
                                        if (totPath > 0)
                                        {
                                            string[] partesDoCaminho = pathSource3.Split('\\');

                                            string pathMatch = "";

                                            int sizeLastPath = -1;

                                            foreach (var path in partesDoCaminho)
                                            {
                                                sizeLastPath++;

                                                pathMatch += path;

                                                if (pathMatch.Replace("\\", "") ==
                                                    txtSourceFolder.Text.Replace("\\", ""))
                                                {
                                                    break;
                                                }
                                            }

                                            string ano = partesDoCaminho.ElementAtOrDefault(sizeLastPath + 1);

                                            string sub = partesDoCaminho.ElementAtOrDefault(sizeLastPath + 2);

                                            if (ano != null && sub != null)
                                            {
                                                if (ano.Where(char.IsDigit).Any() && sub.ToLower().Contains("sub"))
                                                {
                                                    achouPathOk = true;

                                                    string[] pathFilesSoure = Directory.GetFiles(pathSource3)
                                                        .Where(pathSource3 => !IsFileHidden(pathSource3))
                                                        .ToArray();

                                                    if (pathFilesSoure.Length > 0)
                                                    {
                                                        string numericPart =
                                                            new string(sub.Where(char.IsDigit).ToArray());

                                                        int number;

                                                        if (int.TryParse(numericPart, out number))
                                                        {
                                                            string formattedSub = $"Sub {number:00}";

                                                            sub = formattedSub;

                                                            Console.WriteLine("Variável formatada: " + formattedSub);

                                                            string km = partesDoCaminho
                                                                .ElementAtOrDefault(sizeLastPath + 3);

                                                            totPath--;

                                                            foreach (string pathFileSoure in pathFilesSoure)
                                                            {
                                                                string fileSource = pathFileSoure.Split('\\')
                                                                    .ElementAtOrDefault(
                                                                        pathFileSoure.Split('\\').Length - 1);

                                                                string pathDestinationVerify =
                                                                    txtDestinationFolder.Text + "\\" + sub + "\\" + km +
                                                                    "\\" +
                                                                    ano;

                                                                    //Thread.Sleep(2000);

                                                                    if (Directory.Exists(pathDestinationVerify))
                                                                {
                                                                    string[] filesDestination = Directory
                                                                        .GetFiles(pathDestinationVerify)
                                                                        .Where(pathDestinationVerify =>
                                                                            !IsFileHidden(pathDestinationVerify))
                                                                        .ToArray();

                                                                    if (filesDestination.Contains(
                                                                            pathDestinationVerify +
                                                                            "\\" +
                                                                            fileSource))
                                                                    {
                                                                        if (radioButton1.Checked ||
                                                                            radioButton3.Checked)
                                                                        {
                                                                            dataGridView.Rows.Add(pathFileSoure,
                                                                                pathDestinationVerify + "\\" +
                                                                                fileSource,
                                                                                Math.Round(
                                                                                    new FileInfo(pathFileSoure).Length /
                                                                                    (double)(1024 * 1024),
                                                                                    2) + " MB");

                                                                            DataGridViewRow row =
                                                                                dataGridView.Rows[
                                                                                    dataGridView.Rows.Count - 1];

                                                                            row.DefaultCellStyle.BackColor =
                                                                                File.Exists(pathDestinationVerify +
                                                                                    "\\" +
                                                                                    fileSource)
                                                                                    ? Color.Green
                                                                                    : Color.Tomato;

                                                                            achou = true;

                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (radioButton1.Checked ||
                                                                            radioButton2.Checked)
                                                                        {
                                                                            dataGridView.Rows.Add(pathFileSoure,
                                                                                pathDestinationVerify + "\\" +
                                                                                fileSource,
                                                                                Math.Round(
                                                                                    new FileInfo(pathFileSoure).Length /
                                                                                    (double)(1024 * 1024),
                                                                                    2) + " MB");

                                                                            DataGridViewRow row =
                                                                                dataGridView.Rows[
                                                                                    dataGridView.Rows.Count - 1];

                                                                            row.DefaultCellStyle.BackColor =
                                                                                Color.Tomato;

                                                                            achou = true;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (!radioButton3.Checked)
                                                                    {
                                                                        string[] pathSurceSplit =
                                                                            pathFileSoure.Split('\\');

                                                                        dataGridView.Rows.Add(pathFileSoure,
                                                                            pathDestinationVerify + "\\" +
                                                                            pathSurceSplit[pathSurceSplit.Length - 1],
                                                                            Math.Round(
                                                                                new FileInfo(pathFileSoure).Length /
                                                                                (double)(1024 * 1024),
                                                                                2) +
                                                                            " MB");

                                                                        DataGridViewRow row =
                                                                            dataGridView.Rows[
                                                                                dataGridView.Rows.Count - 1];

                                                                        row.DefaultCellStyle.BackColor = Color.Tomato;

                                                                        achou = true;

                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine(
                                                                "A variável 'sub' não contém uma parte numérica válida.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //MessageBox.Show("Não encontrado arquivos em -> " + pathSource3);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //MessageBox.Show("Não encontrado subpasta em -> " + pathSource2);
                                }
                            }
                        }
                        else
                        {
                            //MessageBox.Show("Não encontrado subpasta em -> " + pathSource);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("Não encontrado subpasta em -> " + txtSourceFolder.Text);
                }

                if (achouPathOk && !achou)
                {
                    MessageBox.Show("Não foi encontrado arquivos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (!achouPathOk)
                {
                    MessageBox.Show("Não foi encontrado pastas com a escrutura -> .../ano/sub[n]/km", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Preencha o limite de pastas para processamento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            }));
        }

        private void CopyFiles()
        {
            Invoke(new Action(() =>
            {
                progressBar.Maximum = dataGridView.Rows.Count;
                progressBar.Value = 0;

                Boolean achou = false;

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    string sourceFile = row.Cells[0].Value.ToString();
                    string destFile = row.Cells[1].Value.ToString();

                    if (!File.Exists(destFile))
                    {
                        try
                        {
                            string destinationDir = Path.GetDirectoryName(destFile);

                            if (!Directory.Exists(destinationDir))
                            {
                                Directory.CreateDirectory(destinationDir);
                            }

                            File.Copy(sourceFile, destFile, true);

                            achou = true;

                            //Thread.Sleep(1000);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error copy file {sourceFile}: {ex.Message}", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    //progressBar.Value++;

                    progressBar.Invoke(new Action(() => progressBar.Value++));
                }

                if (achou)
                {
                    MessageBox.Show("Arquivos movidos com sucesso!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Não foi encontrado arquivos para copiar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }));
        }
        private bool IsFileHidden(string filePath)
        {
            FileAttributes attributes = File.GetAttributes(filePath);
            return (attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtSourceFolder.Text = "C:\\temp1";
            //txtDestinationFolder.Text = "C:\\temp2";

            //txtDestinationFolder.Text = "C:\\Rumo\\Infraestrutura e OAEs - 10. ENGENHARIA\\7-Cadastro e Gestão de Ativos";
            //txtSourceFolder.Text = "C:\\Delvined\\Inspeção de Pontes\\Métrica";
        }
    }
}

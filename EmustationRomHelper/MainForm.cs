using EmustationRomHelper.Models;
using EmustationRomHelper.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.IO.Compression;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

namespace EmustationRomHelper
{
    /// <summary>
    /// The main form
    /// </summary>
    public partial class MainForm : Form
    {
        private delegate void SafeCallDelegate(object value);

        private string _inputFolderPath;
        private string _inputAlphaFolderPath;
        private string _outputFolderPath;
        private string _outputAlphaFolderPath;

        private List<Item> _filesToProcess;

        private int _maxFileLength;
        private int _trimFileLength;

        private bool _deleteAfterExtract = false;
        private bool _deleteAlphaFile = false;

        private bool _folderSameAsSource = true;

        /// <summary>
        /// Constructor for main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            var reader = new AppSettingsReader();

            _maxFileLength = (int)reader.GetValue("MaxFileLength", typeof(int));
            _trimFileLength = (int)reader.GetValue("TrimFileLength", typeof(int));
        }

        #region Form events

        private async void ButtonZipClick(object sender, EventArgs e)
        {
            SetCursorSafe(true);

            await ZipFiles().ConfigureAwait(true);

            SetCursorSafe(false);
        }



        private void ButtonBrowseClick(object sender, EventArgs e)
        {
            _inputFolderPath = GetFolderPath();

            textBoxFolderPath.Text = _inputFolderPath;
        }



        private void TextBoxFolderPathTextChanged(object sender, EventArgs e)
        {
            _inputFolderPath = textBoxFolderPath.Text;
        }



        private async void ButtonProcessClick(object sender, EventArgs e)
        {
            SetCursorSafe(true);

            await ProcessFolder().ConfigureAwait(false);

            SetCursorSafe(false);
        }



        private void ButtonValidateClick(object sender, EventArgs e)
        {
            SetCursorSafe(true);

            ValidateFolder(_inputFolderPath);

            ShowMatches();

            SetCursorSafe(false);
        }



        private async void ButtonUnZipClick(object sender, EventArgs e)
        {
            SetCursorSafe(true);

            await UnZipFiles().ConfigureAwait(false);

            SetCursorSafe(false);
        }



        private void CheckBoxDeleteAfterExtract_CheckedChanged(object sender, EventArgs e)
        {
            _deleteAfterExtract = checkBoxDeleteAfterExtract.Checked;
        }



        private void ButtonAlphaBrowseClick(object sender, EventArgs e)
        {
            _inputAlphaFolderPath = GetFolderPath();

            textBoxAlphaFolder.Text = _inputAlphaFolderPath;
        }



        private async void ButtonAlphaProcessClick(object sender, EventArgs e)
        {
            await ProcessAlphaFolders().ConfigureAwait(false);
        }



        private void CheckBoxDifferentFolderCheckedChanged(object sender, EventArgs e)
        {
            _folderSameAsSource = !checkBoxDifferentFolder.Checked;
        }



        private void CheckBoxDeleteSourceCheckedChanged(object sender, EventArgs e)
        {
            _deleteAlphaFile = checkBoxDeleteSource.Checked;
        }

        #endregion Form events



        #region Private methods

        /// <summary>
        /// Show the matches from the validation
        /// </summary>
        private void ShowMatches()
        {
            try
            {
                listViewMatches.Items.Clear();

                foreach (var item in _filesToProcess.OrderBy(x => x.FileName))
                {
                    var listViewItem = new ListViewItem(item.FileName);
                    listViewItem.SubItems.Add(Convert.ToString(item.Length));
                    listViewItem.SubItems.Add(item.NewName);
                    listViewItem.SubItems.Add(item.Extension);

                    listViewMatches.Items.Add(listViewItem);
                }

                toolTip1.SetToolTip(listViewMatches, $"{listViewMatches.Items.Count} Files found");

                listViewMatches.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception exc)
            {
                AppendTextBoxSafe($"{exc.Message}");
            }
        }



        /// <summary>
        /// Open a folder browser dialog box and retrieve the selected path
        /// </summary>
        private string GetFolderPath()
        {
            try
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        var output = dialog.SelectedPath;

                        if (string.IsNullOrWhiteSpace(output))
                        {
                            return string.Empty;
                        }

                        return output;
                    }

                    return string.Empty;
                }
            }
            catch (Exception exc)
            {
                AppendTextBoxSafe($"{exc.Message}");

                return string.Empty;
            }
        }



        /// <summary>
        /// Validate the contents of the folder path
        /// </summary>
        private void ValidateFolder(string startPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(startPath))
                {
                    return;
                }

                _filesToProcess = new List<Item>();

                foreach (var file in Directory.GetFiles(startPath))
                {
                    var info = new FileInfo(file);

                    var name = info.Name;

                    var extension = info.Extension;

                    var length = name.Length;

                    if (name.Length > _maxFileLength)
                    {
                        var newName = name;

                        // Remove the extension (if it exists)
                        if (!string.IsNullOrEmpty(extension))
                        {
                            newName = newName.Replace(extension, string.Empty);
                        }

                        // Remove special characters
                        newName = new string(newName.Where(c => Char.IsLetter(c) || Char.IsNumber(c)).ToArray());

                        // Check the length again
                        if (newName.Length > _trimFileLength)
                        {
                            newName = newName.Substring(0, _trimFileLength);
                        }

                        // Check if there are any duplicates, numerate accordingly
                        if (_filesToProcess.Any(x => x.NewName.Contains(newName)))
                        {
                            var count = _filesToProcess.Count(x => x.NewName.Contains(newName)) + 1;

                            newName = $"{newName}{count}";
                        }

                        // Add to the list
                        _filesToProcess.Add(new Item() { FileName = file, Length = length, NewName = newName, Extension = extension });
                    }
                }
            }
            catch (Exception exc)
            {
                AppendTextBoxSafe($"{exc.Message}");
            }
        }



        /// <summary>
        /// Process the folder path
        /// </summary>
        private async Task ProcessFolder()
        {
            using (var t = Task.Run(() =>
            {

                try
                {
                    if (_filesToProcess == null || _filesToProcess.Count == 0)
                    {
                        AppendTextBoxSafe($"No files to process...");
                        return;
                    }

                    using (var dialog = new FolderBrowserDialog())
                    {
                        if (dialog.ShowDialog(this) != DialogResult.OK)
                        {
                            return;
                        }

                        var output = dialog.SelectedPath;

                        if (string.IsNullOrWhiteSpace(output))
                        {
                            return;
                        }

                        _outputFolderPath = output;

                        AppendTextBoxSafe($"Processing...");

                        var value = 0;

                        SetupProgressBar(0, _filesToProcess.Count, value);

                        foreach (var item in _filesToProcess)
                        {
                            var newFileName = $"{item.NewName}{item.Extension}";
                            AppendTextBoxSafe($"Creating file {newFileName}");
                            try
                            {
                                File.Copy(item.FileName, Path.Combine(_outputFolderPath, newFileName));
                                AppendTextBoxSafe($"file {newFileName} created!");

                                value++;
                                SetProgressBarSafe(value);
                            }
                            catch (Exception exc)
                            {
                                AppendTextBoxSafe($"Could not create file {newFileName}");
                                AppendTextBoxSafe($"{exc.Message}");

                                value++;
                                SetProgressBarSafe(value);
                            }
                        }

                        AppendTextBoxSafe($"Processing Complete.");
                    }
                }
                catch (Exception exc)
                {
                    AppendTextBoxSafe($"{exc.Message}");
                }

            }))
            {
                await t.ConfigureAwait(false);
            }
        }



        /// <summary>
        /// Copy files into new Alphabetical folders
        /// Useful for xbox 4000 file limit
        /// </summary>
        private async Task ProcessAlphaFolders()
        {
            using (var t = Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(_inputAlphaFolderPath))
                    {
                        throw new Exception("Input folder path is empty or invalid");
                    }

                    for (int x = '0'; x <= 'Z'; x++)
                    {
                        // Only focus on alphanumarics
                        if (x > '9' && x < 'A')
                        {
                            continue;
                        }

                        var newFolder = (x >= '0' && x <= '9') ? "#" : Convert.ToString((char)x);

                        var files = Directory.GetFiles(_inputAlphaFolderPath, $"{newFolder}*.*", SearchOption.AllDirectories);

                        if (files.Length == 0)
                        {
                            continue;
                        }

                        if (_folderSameAsSource)
                        {
                            _outputAlphaFolderPath = _inputAlphaFolderPath;
                        }
                        else
                        {
                            _outputAlphaFolderPath = GetFolderPath();

                            if (string.IsNullOrEmpty(_outputAlphaFolderPath))
                            {
                                throw new Exception("Output folder path is empty or invalid");
                            }
                        }

                        var outputPath = Path.Combine(_outputAlphaFolderPath, newFolder);

                        foreach (var file in files)
                        {
                            var fileInfo = new FileInfo(file);

                            AppendTextBoxSafe($"Processing {fileInfo.Name}");

                            var newFile = Path.Combine(outputPath, fileInfo.Name);

                            Directory.CreateDirectory(outputPath);

                            File.Copy(file, Path.Combine(outputPath, newFile));

                            if (_deleteAlphaFile)
                            {
                                AppendTextBoxSafe($"Deleting {file}");

                                File.Delete(file);

                                AppendTextBoxSafe($"Deleting {file} Complete");
                            }

                            AppendTextBoxSafe($"Processing {fileInfo.Name} Complete");
                        }
                    }
                }
                catch (Exception exc)
                {
                    AppendTextBoxSafe($"{exc.Message}");
                }
            }))
            {
                await t.ConfigureAwait(false);
            }
        }



        /// <summary>
        /// Setup the progress bar
        /// </summary>
        /// <param name="min">The min value</param>
        /// <param name="max">The max value</param>
        /// <param name="value">The current value</param>
        private void SetupProgressBar(int min, int max, int value)
        {
            progressBar.Minimum = min;
            progressBar.Maximum = max;
            progressBar.Value = value;
        }



        /// <summary>
        /// Create zip files from individual files
        /// </summary>
        private async Task ZipFiles()
        {
            try
            {
                using (var dialog = new OpenFileDialog() { Multiselect = true })
                {
                    if (dialog.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    var fileNames = dialog.FileNames;

                    if (fileNames.Length == 0)
                    {
                        AppendTextBoxSafe($"No files selected...");
                        return;
                    }

                    var value = 0;

                    SetupProgressBar(0, fileNames.Length, value);

                    foreach (var file in fileNames)
                    {
                        AppendTextBoxSafe($"Converting...");

                        var fileInfo = new FileInfo(file);

                        var zipFile = file.Replace(fileInfo.Extension, ".zip");

                        if (File.Exists(zipFile))
                        {
                            value++;
                            SetProgressBarSafe(value);
                            continue;
                        }

                        AppendTextBoxSafe($"Converting {file}...");

                        try
                        {
                            using (var t = Task.Run(() =>
                            {
                                var zip = ZipFile.Open(zipFile, ZipArchiveMode.Create);
                                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                            }))
                            {
                                await t.ConfigureAwait(false);
                            }
                        }
                        catch (Exception exc)
                        {
                            AppendTextBoxSafe($"{exc.Message}");
                        }

                        value++;
                        SetProgressBarSafe(value);

                        AppendTextBoxSafe($"File {zipFile} Created...");
                    }

                    AppendTextBoxSafe($"Converting Completed Successfully.");
                }
            }
            catch (Exception exc)
            {
                AppendTextBoxSafe($"{exc.Message}");

                AppendTextBoxSafe($"Converting Completed with Errors.");
            }
        }



        /// <summary>
        /// Extract zip files in a directory to their respective folders
        /// </summary>
        private async Task UnZipFiles()
        {
            try
            {
                using (var dialogZipFileInput = new FolderBrowserDialog() { Description = "Zip File Location" })
                {
                    if (dialogZipFileInput.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }

                    var inputPath = dialogZipFileInput.SelectedPath;

                    var files = FileHelper.getFiles(inputPath, "*.zip|*.7z", SearchOption.AllDirectories);

                    if (files.Length == 0)
                    {
                        MessageBox.Show(this, "No files found");
                        return;
                    }

                    using (var dialogZipFileOutput = new FolderBrowserDialog() { Description = "Zip File Output folder", SelectedPath = inputPath })
                    {
                        if (dialogZipFileOutput.ShowDialog(this) != DialogResult.OK)
                        {
                            return;
                        }

                        var outputPath = dialogZipFileOutput.SelectedPath;

                        AppendTextBoxSafe($"Extracting...");

                        var value = 0;

                        SetupProgressBar(0, files.Length, value);

                        foreach (var file in files)
                        {
                            var fileInfo = new FileInfo(file);

                            var archiveFolderName = fileInfo.Name.Replace(fileInfo.Extension, "");

                            var outputFolder = Path.Combine(outputPath, archiveFolderName);

                            if (Directory.Exists(outputFolder))
                            {
                                AppendTextBoxSafe($"{outputFolder} already exists, skipping...");
                                value++;
                                SetProgressBarSafe(value);
                                continue;
                            }

                            AppendTextBoxSafe($"Extracting {file} to {outputFolder}...");

                            try
                            {
                                // run async so we free up the UI
                                using (var t = Task.Run(() =>
                                {
                                    if (fileInfo.Extension.ToLower() == "zip")
                                    {
                                        ZipFile.ExtractToDirectory(file, outputFolder);
                                    }
                                    else
                                    {
                                        string zPath = @"7zip\7za.exe"; //add to proj and set CopyToOuputDir

                                        ProcessStartInfo pro = new ProcessStartInfo
                                        {
                                            WindowStyle = ProcessWindowStyle.Hidden,
                                            FileName = zPath,
                                            Arguments = string.Format("x \"{0}\" -y -o\"{1}\"", file, outputFolder)
                                        };
                                        Process x = Process.Start(pro);
                                        x.WaitForExit();
                                    }
                                }))
                                {
                                    await t.ConfigureAwait(false);
                                }

                            }
                            catch (Exception exc)
                            {
                                // Catch here and report, so we can continue on with next file
                                AppendTextBoxSafe($"{exc.Message}");
                            }

                            value++;
                            SetProgressBarSafe(value);

                            Application.DoEvents();

                            AppendTextBoxSafe($"File {file} Extracted...");

                            if (_deleteAfterExtract)
                            {
                                AppendTextBoxSafe($"Deleting {file}...");
                                File.Delete(file);
                                AppendTextBoxSafe($"{file} Deleted...");
                            }
                        }

                        AppendTextBoxSafe($"Extraction Completed Successfully.");
                    }
                }
            }
            catch (Exception exc)
            {
                // If anything else happens, log and quit
                AppendTextBoxSafe($"{exc.Message}");

                AppendTextBoxSafe($"Extraction Completed with Errors.");
            }

        }

        #endregion Private methods



        #region Threadsafe methods

        private void SetCursorSafe(object value)
        {
            if (InvokeRequired)
            {
                var d = new SafeCallDelegate(SetCursorSafe);
                Invoke(d, new object[] { value });
            }
            else
            {
                Cursor = (bool)value ? Cursors.WaitCursor : Cursors.Default;
            }
        }

        private void SetProgressBarSafe(object value)
        {
            if (progressBar.InvokeRequired)
            {
                var d = new SafeCallDelegate(SetProgressBarSafe);
                progressBar.Invoke(d, new object[] { value });
            }
            else
            {
                progressBar.Value = (int)value;
            }
        }



        private void AppendTextBoxSafe(object value)
        {
            if (textBoxOutput.InvokeRequired)
            {
                var d = new SafeCallDelegate(AppendTextBoxSafe);
                textBoxOutput.Invoke(d, new object[] { value });
            }
            else
            {
                textBoxOutput.AppendText($"{value}\r\n");
            }
        }

        #endregion Threadsafe methods
    }
}

# Lightworks project
## Lightworks IO
The Lightworks IO library, is designed for developers who need to make a mixed and multi sectional file with desired type/extension asap for their project to save or load resource files from one single, integrated and costumized file, that we call it TFile, with their desired format extension name.

### Requirements
  .Net framework 4.5 (+)
  Microsoft Windows XP (and above)
  Support of C#, C++(Objective) and Objective pascal(Delphi) code environments
  
## Code sample
Please load the dll file to make sure you can access the code library in your project.
### Making a TFile
(TFile is abbreviation for the file made with your desired file type extension and Lightworks_IO_b lib. format)
```
  private void button_saveAs_Click(object sender, EventArgs e)
        {
            //Initializing the TFile from Lightworks_IOFile class library
            Lightworks_IOFile lwioFile = new Lightworks_IOFile(".testFile");
            //Making a list for the unverified files(Files which has error on loading into the TFile variable) 
            List<string> aborted_files = new List<string>();
            foreach (var item in listBox1.Items)
                //Returns the files had error to add to the TFile
                if (!lwioFile.AddData(item.ToString(), Path.GetFileNameWithoutExtension(item.ToString())))
                    aborted_files.Add(item.ToString());

            string err_text = "";
            bool cancelOperation = false;
            //IF there's a single error on adding files into Tfile, to make a message including the errors
            if (aborted_files.Count > 0)
            {
                foreach (string cfile in aborted_files)
                    err_text += "File access error on: " + cfile + Environment.NewLine;

                if (MessageBox.Show(err_text, "Error on adding some files", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel)
                    cancelOperation = true;
            }
            //If the operator ignored the errors or there's no errors, the operation may continued
            if (!cancelOperation)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Save Files",
                    CheckFileExists = false,
                    CheckPathExists = true,
                    RestoreDirectory = true
                };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Exception exp = lwioFile.SaveTo(saveFileDialog1.FileName);
                    if (!exp.ToString().Contains("1"))
                        MessageBox.Show(exp.ToString());
                    else
                        MessageBox.Show("Done!", "saving file " + Path.GetFileName(saveFileDialog1.FileName), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
```
        
 ### Load and extracting TFile
```
   private void button_openEx_Click(object sender, EventArgs e)
        {
            //Selecting the TFile to open it
            OpenFileDialog openFileDialog2 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse TFile",

                CheckFileExists = true,
                CheckPathExists = true,

                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog2 = new SaveFileDialog
                {
                    InitialDirectory = @"D:\",
                    Title = "Save Files",
                    CheckFileExists = false,
                    CheckPathExists = true,
                    RestoreDirectory = true
                };
                //Selecting the place you want the TFile items to be extracted there
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    Lightworks_IOFile lwFile = new Lightworks_IOFile();
                    var exp = lwFile.LoadFrom(openFileDialog2.FileName, saveFileDialog2.FileName);

                    if (exp.ToString().Contains("1"))
                    {
                        listBox2.Items.Clear();
                        listBox2.Items.AddRange(Directory.GetFiles(saveFileDialog2.FileName));
                    }
                    else
                        MessageBox.Show(exp.ToString());
                }
            }
        }
    }
```

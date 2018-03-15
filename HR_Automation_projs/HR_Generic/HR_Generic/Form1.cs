using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HR_Generic
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
         generate_pdf.Enabled = false;
      }
      private void generate_pdf_Click(object sender, EventArgs e)
      {
         count.Text =" No Of PDF's Generated.....";
         List<Employee> Employee_List = Helper.Read_excel_file(path_of_excel_file.Text);
         Helper.Generate_PDF(Employee_List,path_of_word_file.Text,text_append_to_filename.Text);
         int no_of_PDF_generated;
         if (int.TryParse(Helper.result,out no_of_PDF_generated))
         count.Text = "No Of PDF's Generated " + no_of_PDF_generated;
         else
         {
            count.Text = "Error"+"\n"+Helper.result;
         }
      }

      private void excelFile_Click(object sender, EventArgs e)
      {
         OpenFileDialog excelfile = new OpenFileDialog();
         excelfile.Title = "Excel File Open File Dialog";
         excelfile.InitialDirectory = @"c:\";
         excelfile.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
         excelfile.FilterIndex = 2;
         excelfile.RestoreDirectory = true;
         if (excelfile.ShowDialog() == DialogResult.OK)
         {
            path_of_excel_file.Text = excelfile.FileName;
         }
      }

      private void wordFile_Click(object sender, EventArgs e)
      {
         OpenFileDialog wordfile = new OpenFileDialog();
         wordfile.Title = "Excel File Open File Dialog";
         wordfile.InitialDirectory = @"c:\";
         wordfile.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
         wordfile.FilterIndex = 2;
         wordfile.RestoreDirectory = true;
         if (wordfile.ShowDialog() == DialogResult.OK)
         {
            path_of_word_file.Text = wordfile.FileName;
         }

      }

      private void path_of_excel_file_TextChanged(object sender, EventArgs e)
      {
         generate_pdf.Enabled = false;
         if (!string.IsNullOrEmpty(path_of_excel_file.Text) && !string.IsNullOrEmpty(path_of_word_file.Text) && !string.IsNullOrEmpty(text_append_to_filename.Text))
         {
            generate_pdf.Enabled = true;
         }

      }

      private void path_of_word_file_TextChanged(object sender, EventArgs e)
      {
         generate_pdf.Enabled = false;
         if (!string.IsNullOrEmpty(path_of_excel_file.Text) && !string.IsNullOrEmpty(path_of_word_file.Text) && !string.IsNullOrEmpty(text_append_to_filename.Text))
         {
            generate_pdf.Enabled = true;
         }
      }

      private void Form1_Load(object sender, EventArgs e)
      {

      }

      private void label2_Click(object sender, EventArgs e)
      {

      }

      private void text_append_to_filename_TextChanged(object sender, EventArgs e)
      {
         generate_pdf.Enabled = false;
         if (!string.IsNullOrEmpty(path_of_excel_file.Text) && !string.IsNullOrEmpty(path_of_word_file.Text) && !string.IsNullOrEmpty(text_append_to_filename.Text))
         {
            generate_pdf.Enabled = true;
         }
      }
   }
}

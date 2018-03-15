namespace HR_Generic
{
   partial class Form1
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.path_of_excel_file = new System.Windows.Forms.TextBox();
         this.path_of_word_file = new System.Windows.Forms.TextBox();
         this.excelFile = new System.Windows.Forms.Button();
         this.wordFile = new System.Windows.Forms.Button();
         this.generate_pdf = new System.Windows.Forms.Button();
         this.count = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.text_append_to_filename = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 43);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(94, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Path Of Excel File:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 94);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(94, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Path Of Word File:";
         this.label2.Click += new System.EventHandler(this.label2_Click);
         // 
         // path_of_excel_file
         // 
         this.path_of_excel_file.Location = new System.Drawing.Point(119, 36);
         this.path_of_excel_file.Name = "path_of_excel_file";
         this.path_of_excel_file.Size = new System.Drawing.Size(376, 20);
         this.path_of_excel_file.TabIndex = 2;
         this.path_of_excel_file.TextChanged += new System.EventHandler(this.path_of_excel_file_TextChanged);
         // 
         // path_of_word_file
         // 
         this.path_of_word_file.Location = new System.Drawing.Point(119, 86);
         this.path_of_word_file.Name = "path_of_word_file";
         this.path_of_word_file.Size = new System.Drawing.Size(376, 20);
         this.path_of_word_file.TabIndex = 3;
         this.path_of_word_file.TextChanged += new System.EventHandler(this.path_of_word_file_TextChanged);
         // 
         // excelFile
         // 
         this.excelFile.Location = new System.Drawing.Point(518, 36);
         this.excelFile.Name = "excelFile";
         this.excelFile.Size = new System.Drawing.Size(72, 20);
         this.excelFile.TabIndex = 4;
         this.excelFile.Text = "Browse";
         this.excelFile.UseVisualStyleBackColor = true;
         this.excelFile.Click += new System.EventHandler(this.excelFile_Click);
         // 
         // wordFile
         // 
         this.wordFile.Location = new System.Drawing.Point(518, 84);
         this.wordFile.Name = "wordFile";
         this.wordFile.Size = new System.Drawing.Size(72, 23);
         this.wordFile.TabIndex = 5;
         this.wordFile.Text = "Browse";
         this.wordFile.UseVisualStyleBackColor = true;
         this.wordFile.Click += new System.EventHandler(this.wordFile_Click);
         // 
         // generate_pdf
         // 
         this.generate_pdf.Location = new System.Drawing.Point(249, 167);
         this.generate_pdf.Name = "generate_pdf";
         this.generate_pdf.Size = new System.Drawing.Size(145, 48);
         this.generate_pdf.TabIndex = 6;
         this.generate_pdf.Text = "Generate Pdf";
         this.generate_pdf.UseVisualStyleBackColor = true;
         this.generate_pdf.Click += new System.EventHandler(this.generate_pdf_Click);
         // 
         // count
         // 
         this.count.AutoSize = true;
         this.count.Location = new System.Drawing.Point(30, 220);
         this.count.Name = "count";
         this.count.Size = new System.Drawing.Size(0, 13);
         this.count.TabIndex = 8;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 125);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(82, 26);
         this.label3.TabIndex = 9;
         this.label3.Text = "Text to append \r\n with file name:";
         // 
         // text_append_to_filename
         // 
         this.text_append_to_filename.Location = new System.Drawing.Point(119, 131);
         this.text_append_to_filename.Name = "text_append_to_filename";
         this.text_append_to_filename.Size = new System.Drawing.Size(376, 20);
         this.text_append_to_filename.TabIndex = 10;
         this.text_append_to_filename.TextChanged += new System.EventHandler(this.text_append_to_filename_TextChanged);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(611, 410);
         this.Controls.Add(this.text_append_to_filename);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.count);
         this.Controls.Add(this.generate_pdf);
         this.Controls.Add(this.wordFile);
         this.Controls.Add(this.excelFile);
         this.Controls.Add(this.path_of_word_file);
         this.Controls.Add(this.path_of_excel_file);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "Form1";
         this.Text = "PDF Generator";
         this.Load += new System.EventHandler(this.Form1_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox path_of_excel_file;
      private System.Windows.Forms.TextBox path_of_word_file;
      private System.Windows.Forms.Button excelFile;
      private System.Windows.Forms.Button wordFile;
      private System.Windows.Forms.Button generate_pdf;
      private System.Windows.Forms.Label count;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox text_append_to_filename;
   }
}


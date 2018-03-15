namespace HR_Form16_Mail_Automation
{
   partial class form16mailautomation
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
         this.generate_emails = new System.Windows.Forms.Button();
         this.excelfilepath = new System.Windows.Forms.Label();
         this.pdfpath = new System.Windows.Forms.Label();
         this.excelfilepathvalue = new System.Windows.Forms.TextBox();
         this.pdffolderpathvalue = new System.Windows.Forms.TextBox();
         this.browse_excelfilepath = new System.Windows.Forms.Button();
         this.browse_pdffolderpath = new System.Windows.Forms.Button();
         this.folderBrowserDialogExcel = new System.Windows.Forms.FolderBrowserDialog();
         this.folderBrowserDialogPDFFolder = new System.Windows.Forms.FolderBrowserDialog();
         this.errorsValue = new System.Windows.Forms.RichTextBox();
         this.Error = new System.Windows.Forms.Label();
         this.EmailSent = new System.Windows.Forms.ProgressBar();
         this.emailsentcounter = new System.Windows.Forms.Label();
         this.pathofemailtemplate = new System.Windows.Forms.Label();
         this.emailtemplatepath = new System.Windows.Forms.TextBox();
         this.emailtemplatebrowse = new System.Windows.Forms.Button();
         this.emailsubject = new System.Windows.Forms.Label();
         this.emailsubjectvalue = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // generate_emails
         // 
         this.generate_emails.Location = new System.Drawing.Point(217, 216);
         this.generate_emails.Name = "generate_emails";
         this.generate_emails.Size = new System.Drawing.Size(175, 62);
         this.generate_emails.TabIndex = 0;
         this.generate_emails.Text = "Generate Emails";
         this.generate_emails.UseVisualStyleBackColor = true;
         this.generate_emails.Click += new System.EventHandler(this.generate_emails_Click);
         // 
         // excelfilepath
         // 
         this.excelfilepath.AutoSize = true;
         this.excelfilepath.Location = new System.Drawing.Point(12, 69);
         this.excelfilepath.Name = "excelfilepath";
         this.excelfilepath.Size = new System.Drawing.Size(94, 13);
         this.excelfilepath.TabIndex = 1;
         this.excelfilepath.Text = "Path Of Excel File:";
         // 
         // pdfpath
         // 
         this.pdfpath.AutoSize = true;
         this.pdfpath.Location = new System.Drawing.Point(12, 108);
         this.pdfpath.Name = "pdfpath";
         this.pdfpath.Size = new System.Drawing.Size(97, 13);
         this.pdfpath.TabIndex = 2;
         this.pdfpath.Text = "Path Of Pdf Folder:";
         // 
         // excelfilepathvalue
         // 
         this.excelfilepathvalue.Location = new System.Drawing.Point(179, 62);
         this.excelfilepathvalue.Name = "excelfilepathvalue";
         this.excelfilepathvalue.Size = new System.Drawing.Size(308, 20);
         this.excelfilepathvalue.TabIndex = 3;
         this.excelfilepathvalue.TextChanged += new System.EventHandler(this.excelfilepathvalue_TextChanged);
         // 
         // pdffolderpathvalue
         // 
         this.pdffolderpathvalue.Location = new System.Drawing.Point(179, 101);
         this.pdffolderpathvalue.Name = "pdffolderpathvalue";
         this.pdffolderpathvalue.Size = new System.Drawing.Size(306, 20);
         this.pdffolderpathvalue.TabIndex = 4;
         this.pdffolderpathvalue.TextChanged += new System.EventHandler(this.pdffolderpathvalue_TextChanged);
         // 
         // browse_excelfilepath
         // 
         this.browse_excelfilepath.Location = new System.Drawing.Point(508, 62);
         this.browse_excelfilepath.Name = "browse_excelfilepath";
         this.browse_excelfilepath.Size = new System.Drawing.Size(75, 23);
         this.browse_excelfilepath.TabIndex = 5;
         this.browse_excelfilepath.Text = "Browse";
         this.browse_excelfilepath.UseVisualStyleBackColor = true;
         this.browse_excelfilepath.Click += new System.EventHandler(this.browse_excelfilepath_Click);
         // 
         // browse_pdffolderpath
         // 
         this.browse_pdffolderpath.Location = new System.Drawing.Point(508, 101);
         this.browse_pdffolderpath.Name = "browse_pdffolderpath";
         this.browse_pdffolderpath.Size = new System.Drawing.Size(75, 23);
         this.browse_pdffolderpath.TabIndex = 6;
         this.browse_pdffolderpath.Text = "Browse";
         this.browse_pdffolderpath.UseVisualStyleBackColor = true;
         this.browse_pdffolderpath.Click += new System.EventHandler(this.browse_pdffolderpath_Click);
         // 
         // errorsValue
         // 
         this.errorsValue.Location = new System.Drawing.Point(35, 362);
         this.errorsValue.Name = "errorsValue";
         this.errorsValue.Size = new System.Drawing.Size(507, 138);
         this.errorsValue.TabIndex = 8;
         this.errorsValue.Text = "";
         // 
         // Error
         // 
         this.Error.AutoSize = true;
         this.Error.Location = new System.Drawing.Point(32, 346);
         this.Error.Name = "Error";
         this.Error.Size = new System.Drawing.Size(29, 13);
         this.Error.TabIndex = 9;
         this.Error.Text = "Error";
         this.Error.Click += new System.EventHandler(this.Error_Click);
         // 
         // EmailSent
         // 
         this.EmailSent.Location = new System.Drawing.Point(35, 310);
         this.EmailSent.Name = "EmailSent";
         this.EmailSent.Size = new System.Drawing.Size(507, 23);
         this.EmailSent.TabIndex = 10;
         // 
         // emailsentcounter
         // 
         this.emailsentcounter.AutoSize = true;
         this.emailsentcounter.Location = new System.Drawing.Point(271, 294);
         this.emailsentcounter.Name = "emailsentcounter";
         this.emailsentcounter.Size = new System.Drawing.Size(57, 13);
         this.emailsentcounter.TabIndex = 11;
         this.emailsentcounter.Text = "Email Sent";
         // 
         // pathofemailtemplate
         // 
         this.pathofemailtemplate.AutoSize = true;
         this.pathofemailtemplate.Location = new System.Drawing.Point(12, 142);
         this.pathofemailtemplate.Name = "pathofemailtemplate";
         this.pathofemailtemplate.Size = new System.Drawing.Size(148, 13);
         this.pathofemailtemplate.TabIndex = 12;
         this.pathofemailtemplate.Text = "Path Of Email Body Template:";
         // 
         // emailtemplatepath
         // 
         this.emailtemplatepath.Location = new System.Drawing.Point(179, 142);
         this.emailtemplatepath.Name = "emailtemplatepath";
         this.emailtemplatepath.Size = new System.Drawing.Size(306, 20);
         this.emailtemplatepath.TabIndex = 13;
         this.emailtemplatepath.TextChanged += new System.EventHandler(this.emailtemplatepath_TextChanged);
         // 
         // emailtemplatebrowse
         // 
         this.emailtemplatebrowse.Location = new System.Drawing.Point(508, 142);
         this.emailtemplatebrowse.Name = "emailtemplatebrowse";
         this.emailtemplatebrowse.Size = new System.Drawing.Size(75, 21);
         this.emailtemplatebrowse.TabIndex = 14;
         this.emailtemplatebrowse.Text = "Browse";
         this.emailtemplatebrowse.UseVisualStyleBackColor = true;
         this.emailtemplatebrowse.Click += new System.EventHandler(this.emailtemplatebrowse_Click);
         // 
         // emailsubject
         // 
         this.emailsubject.AutoSize = true;
         this.emailsubject.Location = new System.Drawing.Point(15, 176);
         this.emailsubject.Name = "emailsubject";
         this.emailsubject.Size = new System.Drawing.Size(74, 13);
         this.emailsubject.TabIndex = 15;
         this.emailsubject.Text = "Email Subject:";
         // 
         // emailsubjectvalue
         // 
         this.emailsubjectvalue.Location = new System.Drawing.Point(179, 176);
         this.emailsubjectvalue.Name = "emailsubjectvalue";
         this.emailsubjectvalue.Size = new System.Drawing.Size(306, 20);
         this.emailsubjectvalue.TabIndex = 16;
         this.emailsubjectvalue.TextChanged += new System.EventHandler(this.emailsubjectvalue_TextChanged);
         // 
         // form16mailautomation
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(596, 542);
         this.Controls.Add(this.emailsubjectvalue);
         this.Controls.Add(this.emailsubject);
         this.Controls.Add(this.emailtemplatebrowse);
         this.Controls.Add(this.emailtemplatepath);
         this.Controls.Add(this.pathofemailtemplate);
         this.Controls.Add(this.emailsentcounter);
         this.Controls.Add(this.EmailSent);
         this.Controls.Add(this.Error);
         this.Controls.Add(this.errorsValue);
         this.Controls.Add(this.browse_pdffolderpath);
         this.Controls.Add(this.browse_excelfilepath);
         this.Controls.Add(this.pdffolderpathvalue);
         this.Controls.Add(this.excelfilepathvalue);
         this.Controls.Add(this.pdfpath);
         this.Controls.Add(this.excelfilepath);
         this.Controls.Add(this.generate_emails);
         this.Name = "form16mailautomation";
         this.Text = "Form16 Mail Automation";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button generate_emails;
      private System.Windows.Forms.Label excelfilepath;
      private System.Windows.Forms.Label pdfpath;
      private System.Windows.Forms.TextBox excelfilepathvalue;
      private System.Windows.Forms.TextBox pdffolderpathvalue;
      private System.Windows.Forms.Button browse_excelfilepath;
      private System.Windows.Forms.Button browse_pdffolderpath;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogExcel;
      private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPDFFolder;
      private System.Windows.Forms.RichTextBox errorsValue;
      private System.Windows.Forms.Label Error;
      private System.Windows.Forms.ProgressBar EmailSent;
      private System.Windows.Forms.Label emailsentcounter;
      private System.Windows.Forms.Label pathofemailtemplate;
      private System.Windows.Forms.TextBox emailtemplatepath;
      private System.Windows.Forms.Button emailtemplatebrowse;
      private System.Windows.Forms.Label emailsubject;
      private System.Windows.Forms.TextBox emailsubjectvalue;
   }
}


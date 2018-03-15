
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Reports_Generation
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      private Helper helper = new Helper();

      public Helper Helper
      {
         get
         {
            return helper;
         }

         set
         {
            helper = value;
         }
      }

      public MainWindow()
      {
         InitializeComponent();
         DataContext = Helper;
         Helper.WriteResultEvent += WriteResult;
      }


      private void BROWSE_DATABASE_PATH_Click(object sender, RoutedEventArgs e)
      {
         OpenFileDialog wordfile = new OpenFileDialog();
         wordfile.InitialDirectory = @"c:\";
         wordfile.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
         wordfile.FilterIndex = 2;
         wordfile.RestoreDirectory = true;
         if (wordfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
         {
            PATH_OF_ACCESS_DATABASE.Text = wordfile.FileName;
         }
      }

      private void BROWSE_REPORT_PATH_Click(object sender, RoutedEventArgs e)
      {
         FolderBrowserDialog folderDlg = new FolderBrowserDialog();
         folderDlg.ShowNewFolderButton = true;
         folderDlg.SelectedPath = @"c:\";
         DialogResult result = folderDlg.ShowDialog();
         if (result == System.Windows.Forms.DialogResult.OK)
         {
            PATH_WHERE_REPORT_NEED_TO_BE_GENERATED.Text = folderDlg.SelectedPath;
         }

      }

      private void EMPLOYEE_DATA_Click(object sender, RoutedEventArgs e)
      {
         Result.Text = string.Empty;
         Helper.OpenConnection(PATH_OF_ACCESS_DATABASE.Text);
         // helper.SetParameters(LEGAL_ENTITY_comboBox.SelectedValue.ToString(), COUNTRY_comboBox.SelectedValue.ToString(), SCOPE_OF_RESP_comboBox.SelectedValue.ToString(), REGION_AREA_COUNTRY_FOR_SCOPE_comboBox.SelectedValue.ToString(), FUNCTION_comboBox.SelectedValue.ToString(), LOB_comboBox.SelectedValue.ToString(), SOLUTION_comboBox.SelectedValue.ToString());
         Helper.SetParameters(LEGAL_ENTITY_comboBox.Text, COUNTRY_comboBox.Text, SCOPE_OF_RESP_comboBox.Text, REGION_AREA_COUNTRY_FOR_SCOPE_comboBox.Text, FUNCTION_comboBox.Text, LOB_comboBox.Text, SOLUTION_comboBox.Text);
         string queryString = "select [EMPLOYEE NAME],[ORACLE ID],[EMPLOYEE # (SYSTEM OF RECORD) in # format],[HIRE DATE (MM/DD/YYYY)],[BIRTH DATE (MM/DD/YYYY)],[EMPLOYYMENT STATUS],[STATUS DATE],[STREET ADDRESS],[STREET ADDRESSS (CONT)],[CITY],[CITY (CONT)],[STATE],[ZIP],[OFFICE PHONE NUMBER],[EMAIL ADDRESS],[FULL TIME/PART TIME],[POSITION TITLE],[SUPERVISOR],[SUPERVISOR  ORACLE  ID],[SUPERVISOR EMAIL ID],[NEW MATRIX SUPERVISOR],[HR PARTNER],[HR PARTNER ORACLE ID] from Employee where [LEGAL ENTITY] = @LE AND [PHYSICAL LOCATION (COUNTRY)] = @PhyLoc AND [SCOPE OF  RESP] = @SOR AND [REGION/AREA/COUNTRY FOR SCOPE] = @RAC AND [FUNCTION] = @function AND [LOB] = @LOB AND [SOLUTION] = @SOLUTION ";
         Helper.GetDataFromDatabase(queryString);
         Helper.GenerateReport(PATH_WHERE_REPORT_NEED_TO_BE_GENERATED.Text);
         Helper.CloseConnection();
      }

      private void COMP_DATA_Click(object sender, RoutedEventArgs e)
      {
         Result.Text = string.Empty;
         Helper.OpenConnection(PATH_OF_ACCESS_DATABASE.Text);
         Helper.SetParameters(LEGAL_ENTITY_comboBox.Text, COUNTRY_comboBox.Text, SCOPE_OF_RESP_comboBox.Text, REGION_AREA_COUNTRY_FOR_SCOPE_comboBox.Text, FUNCTION_comboBox.Text, LOB_comboBox.Text, SOLUTION_comboBox.Text);
         string queryString = "select [EMPLOYEE NAME],[ORACLE ID],[GRADE],[CUR],[BONUS ELIGIBLE SALARY LOCAL (ANNUAL BASE SALARY)],[ANNUAL FIXED SALARY LOCAL],[VARIABLE PLAN],[VARIABLE TARGET LOCAL],[TOTAL CURRENT CASH COMP LOCAL],[2017 LTI TARGET %],[2017 LTI TARGET LOCAL],[TOTAL CURRENT DIRECT COMP LOCAL],[EFFECTIVE DATE OF VARIABLE PLAN ELIGIBILITY],[2017  VARIABLE TARGET %(COLUMN 'AN' AGAINGST ANNUAL BASE SALARY)] from Employee where [LEGAL ENTITY] = @LE AND [PHYSICAL LOCATION (COUNTRY)] = @PhyLoc AND [SCOPE OF  RESP] = @SOR AND [REGION/AREA/COUNTRY FOR SCOPE] = @RAC AND [FUNCTION] = @function AND [LOB] = @LOB AND [SOLUTION] = @SOLUTION ";
         Helper.GetDataFromDatabase(queryString);
         Helper.GenerateReport(PATH_WHERE_REPORT_NEED_TO_BE_GENERATED.Text);
         Helper.CloseConnection();

      }

      private void ALL_DATA_FIELDS_Click(object sender, RoutedEventArgs e)
      {
         Result.Text = string.Empty;
         Helper.OpenConnection(PATH_OF_ACCESS_DATABASE.Text);
         Helper.SetParameters(LEGAL_ENTITY_comboBox.Text, COUNTRY_comboBox.Text, SCOPE_OF_RESP_comboBox.Text, REGION_AREA_COUNTRY_FOR_SCOPE_comboBox.Text, FUNCTION_comboBox.Text, LOB_comboBox.Text, SOLUTION_comboBox.Text);
         string queryString = "select * from Employee where [LEGAL ENTITY] = @LE AND [PHYSICAL LOCATION (COUNTRY)] = @PhyLoc AND [SCOPE OF  RESP] = @SOR AND [REGION/AREA/COUNTRY FOR SCOPE] = @RAC AND [FUNCTION] = @function AND [LOB] = @LOB AND [SOLUTION] = @SOLUTION ";
         Helper.GetDataFromDatabase(queryString);
         Helper.GenerateReport(PATH_WHERE_REPORT_NEED_TO_BE_GENERATED.Text);
         Helper.CloseConnection();

      }
      void WriteResult(string s)
      {

         Result.Text = s;
      }
   }
}

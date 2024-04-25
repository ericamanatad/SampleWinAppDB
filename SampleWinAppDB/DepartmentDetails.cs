using SampleWinAppDB.Database;
using SampleWinAppDB.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SampleWinAppDB
{
    public partial class DepartmentDetails : Form
    {
        private DBConnect dbconnect;
        private int selectedCollegeID;
        private int collegeID;
        private int id;

        private void BtnBack_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }


        public DepartmentDetails()
        {
            InitializeComponent();
            //create an instance of DB context
            dbconnect = new DBConnect("localhost", 3306, "root", "", "college_departmentdb");
        }
        public DepartmentDetails(DBConnect dbConnnect, int collegeID)
        {
            InitializeComponent();
            dbconnect = dbConnnect;
            this.collegeID = collegeID;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                //attempt to establish DB server connectivity
                if (dbconnect.Connect())
                    MessageBox.Show("Connected to DB server successfully!", "Test App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Cound not connect to DB server!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DepartmentDetails_Load(object sender, EventArgs e)
        {

            DisplayRecords(collegeID);

            CtxMenuStripDepartmentList.Items[1].Enabled = false;        //disable Update menu item
            CtxMenuStripDepartmentList.Items[2].Enabled = false;        //disable Delete menu item
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Clicked ADD");
           //load/show Add/Edit Form
           AddEditDepartmentForm departmentForm = new AddEditDepartmentForm(dbconnect, null);
           //update form label
           departmentForm.Text = "Add Record";
           departmentForm.ShowDialog();
        }

        private void DisplayRecords(int id)
        {
           List<Department> departmentRecords = new List<Department>();
           try
           {
                MessageBox.Show("collegeID: sent to DisplayRecords" + id );
               //get department records
               departmentRecords = dbconnect.GetDepartmentRecords(id);
                //populate records to the listview
                //populate records to the listview
                for (int i = 0; i < departmentRecords.Count; i++)
                {
                    Department d = departmentRecords[i];
                    //display department record to the listview
                    LsvDepartment.Items.Add(d.depID.ToString());
                    LsvDepartment.Items[i].SubItems.Add(d.depName);
                    LsvDepartment.Items[i].SubItems.Add(d.depCode);
                    /*LsvDepartment.Items.Add(d.depID.ToString());
                    ListViewItem item = LsvDepartment.Items[LsvDepartment.Items.Count - 1];
                    item.SubItems.Add(d.depName);
                    item.SubItems.Add(d.depCode);
                    */
                    MessageBox.Show("Department Records : " + d.depName + d.depCode);
                }
                MessageBox.Show("departmentRecords.Count : " + departmentRecords.Count);
           }

            /*
               List<College> collegeRecords = new List<College>();
                try
                {
                    //get college records
                    collegeRecords = dbconnect.GetCollegeRecords();
                    //populate records to the listview
                    for (int i = 0; i < collegeRecords.Count; i++)
                    {
                        c = collegeRecords[i];
                        //display college record to the listview
                        LsvCollege.Items.Add(c.CollegeID.ToString());
                        LsvCollege.Items[i].SubItems.Add(c.CollegeName);
                        LsvCollege.Items[i].SubItems.Add(c.CollegeCode);
                    }
                }
             */
            catch (Exception ex)
           {
               MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

           DisplayRecords(id);
        }

        private void RefreshRecords_Click(object sender, EventArgs e)
        {
           //clear ListView
           LsvDepartment.Items.Clear();
           DisplayRecords(id);
        }

        private void UpdateRecord_Click(object sender, EventArgs e)
        {
           //check if there is a record selected from the listview
           if (LsvDepartment.SelectedItems.Count > 0)
           {
               //get the current selected department record
               string departmentID = LsvDepartment.SelectedItems[0].Text;
               string departmentName = LsvDepartment.SelectedItems[0].SubItems[1].Text;
               string departmentCode = LsvDepartment.SelectedItems[0].SubItems[2].Text;
               //MessageBox.Show("ID: " + departmentID + " Name: " + departmentName);
               int id = Convert.ToInt32(departmentID);
               Department departmentToUpdate = new Department(id, departmentName, departmentCode, true);
               //load/show Add/Edit Form
               AddEditDepartmentForm departmentForm = new AddEditDepartmentForm(dbconnect, departmentToUpdate);
               //update form label
               departmentForm.Text = "Update Record";
               departmentForm.ShowDialog();
           }
           LsvDepartment.Items.Clear();
           DisplayRecords(id);
        }

        ////////////
        private void LsvDepartment_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
           if (LsvDepartment.SelectedItems.Count > 0)
           {
               CtxMenuStripDepartmentList.Items[1].Enabled = true;        //enable Update menu item
               CtxMenuStripDepartmentList.Items[2].Enabled = true;        //enable Delete menu item
           }
           else
           {
               CtxMenuStripDepartmentList.Items[1].Enabled = false;        //disable Update menu item
               CtxMenuStripDepartmentList.Items[2].Enabled = false;        //disable Delete menu item
           }
        }
    ////////////
    private void DeactivateRecord_Click(object sender, EventArgs e)
    {
       try
       {
           //check if there is a record selected from the listview
           if (LsvDepartment.SelectedItems.Count > 0)
           {
               //get the current selected department record
               string departmentID = LsvDepartment.SelectedItems[0].Text;
               string departmentName = LsvDepartment.SelectedItems[0].SubItems[1].Text;
               //MessageBox.Show("ID: " + departmentID + " Name: " + departmentName);
               int id = Convert.ToInt32(departmentID);
               DialogResult confirmResult = MessageBox.Show("Are you sure to delete " + departmentName + "?", "Deactivate Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (confirmResult == DialogResult.Yes)
               {
                   bool status = dbconnect.DeleteDepartmentRecords(id);
                   if (status)
                       MessageBox.Show("Record deleted successfully!", "Test App", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   else
                       MessageBox.Show("Could not delete record!", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
           }
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
       LsvDepartment.Items.Clear();
       DisplayRecords(id);
    }

   

    }
}
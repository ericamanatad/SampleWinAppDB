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
        /*
        private DBConnect dbconnect;
        private int collegeID;
        College c;

        public DepartmentDetails()
        {
            InitializeComponent();
            //create an instance of DB context
            dbconnect = new DBConnect("localhost", 3306, "root", "", "college_departmentdb");
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


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked ADD");
            //load/show Add/Edit Form
            AddEditDepartmentForm departmentForm = new AddEditDepartmentForm(dbconnect, null);
            //update form label
            departmentForm.Text = "Add Record";
            departmentForm.ShowDialog();
        }

        private void DisplayRecords()
        {
            List<Department> departmentRecords = new List<Department>();
            try
            {
                //get department records
                departmentRecords = dbconnect.GetDepartmentRecords(c.CollegeID);
                //populate records to the listview
                for (int i = 0; i < departmentRecords.Count; i++)
                {
                    Department d = departmentRecords[i];
                    //display department record to the listview
                    LsvDepartment.Items.Add(d.depID.ToString());
                    LsvDepartment.Items[i].SubItems.Add(d.depName);
                    LsvDepartment.Items[i].SubItems.Add(d.depCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DisplayRecords();
        }

        private void RefreshRecords_Click(object sender, EventArgs e)
        {
            //clear ListView
            LsvDepartment.Items.Clear();
            DisplayRecords();
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
                Department departmentToUpdate = new Department(id, departmentName, departmentCode, true, collegeID);
                //load/show Add/Edit Form
                AddEditDepartmentForm departmentForm = new AddEditDepartmentForm(dbconnect, departmentToUpdate);
                //update form label
                departmentForm.Text = "Update Record";
                departmentForm.ShowDialog();
            }
            LsvDepartment.Items.Clear();
            DisplayRecords();
        }

        ////////////
        private void lsvDepartment_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (LsvDepartment.SelectedItems.Count > 0)
            {
                CMSDepartmentList.Items[1].Enabled = true;        //enable Update menu item
                CMSDepartmentList.Items[2].Enabled = true;        //enable Delete menu item
            }
            else
            {
                CMSDepartmentList.Items[1].Enabled = false;        //disable Update menu item
                CMSDepartmentList.Items[2].Enabled = false;        //disable Delete menu item
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
            DisplayRecords();
        }

        private void DepartmentDetails_Load(object sender, EventArgs e)
        {

            DisplayRecords();
            CMSDepartmentList.Items[1].Enabled = false;        //disable Update menu item
            CMSDepartmentList.Items[2].Enabled = false;        //disable Delete menu item
        }
        */
    }
}
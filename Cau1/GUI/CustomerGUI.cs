using Cau1.BAL;
using Cau1.BEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class Form1 : Form
    {
        EmployeeBAL empBAL = new EmployeeBAL();
        DepartmentBAL depBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstemp = empBAL.ReadEmployee();
            foreach (EmployeeBEL emp in lstemp)
            {
                dgv_Employee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth.ToShortDateString(), emp.Gender, emp.PlaceBirth, emp.NameDepartment);
            }
            List<DepartmentBEL> lstDepartment = depBAL.ReadDepartmentList();
            foreach (DepartmentBEL department in lstDepartment)
            {
                cbDV.Items.Add(department);
            }

            cbDV.DisplayMember = "Name";
        }
        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgv_Employee.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                txtMa.Text = dgv_Employee.Rows[idx].Cells[0].Value.ToString();
                txtName.Text = dgv_Employee.Rows[idx].Cells[1].Value.ToString();
                txtDate.Text = dgv_Employee.Rows[idx].Cells[2].Value.ToString();
                string cb = dgv_Employee.Rows[idx].Cells[3].Value.ToString();
                if (cb == "True")
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
                txtLocation.Text = dgv_Employee.Rows[idx].Cells[4].Value.ToString();
                cbDV.Text = dgv_Employee.Rows[idx].Cells[5].Value.ToString();
                txtMa.Enabled = false;
            }


        }
        private void btNew_Click(object sender, EventArgs e)
        {
            txtMa.Enabled = true;
            List<EmployeeBEL> lstemp = empBAL.ReadEmployee();
            if (lstemp.Any(item => item.IdEmployee.ToString() == txtMa.Text) == true)
            {
                txtMa.Text = "";
                txtName.Text = "";
                txtDate.Text = "";
                cbox.Checked = false;
                txtLocation.Text = "";
                cbDV.Text = "";
            }
            else
            {
                if (txtMa.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (txtLocation.Text == "")
                {
                    MessageBox.Show("Bạn cần nhập nơi sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (txtMa.Text != "" & txtName.Text != "" & txtLocation.Text != "")
                {
                    EmployeeBEL emp = new EmployeeBEL();
                    emp.IdEmployee = txtMa.Text;
                    emp.Name = txtName.Text;
                    emp.DateBirth = txtDate.Value;
                    emp.Gender = cbox.Checked;
                    emp.PlaceBirth = txtLocation.Text;
                    emp.Department = (DepartmentBEL)cbDV.SelectedItem;
                    empBAL.NewEmployee(emp);
                    dgv_Employee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth.ToShortDateString(), emp.Gender, emp.PlaceBirth, emp.Department.Name);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }

        }
        private void btEdit_Click(object sender, EventArgs e)
        {

        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Không có đối tượng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            if (MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                EmployeeBEL emp = new EmployeeBEL();
                emp.IdEmployee = txtMa.Text.ToString();

                empBAL.DeleteEmployee(emp);
                int idx = dgv_Employee.CurrentCell.RowIndex;
                dgv_Employee.Rows.RemoveAt(idx);
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }
    }
}

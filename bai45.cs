using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsExercises
{
    public partial class Form4_5_Responsive : Form
    {
        DataTable dt = new DataTable();

        public Form4_5_Responsive()
        {
            InitializeComponent();
        }

        private void Form4_5_Responsive_Load(object sender, EventArgs e)
        {
            // Danh mục
            cboCategory.Items.AddRange(new string[] { "Điện tử", "Gia dụng", "Thời trang" });
            cboCategory.SelectedIndex = 0;

            // Bảng dữ liệu mẫu hiển thị lên DataGridView
            dt.Columns.Add("Mã SP");
            dt.Columns.Add("Tên SP");
            dt.Columns.Add("Danh mục");
            dt.Columns.Add("Đơn giá");
            dt.Columns.Add("Số lượng");

            dt.Rows.Add("SP01", "Laptop Dell", "Điện tử", "15000000", "10");
            dt.Rows.Add("SP02", "Chuột không dây", "Điện tử", "250000", "50");
            dt.Rows.Add("SP03", "Nồi cơm điện", "Gia dụng", "800000", "20");

            dgvList.DataSource = dt;
        }

        // Đổ dữ liệu từ DataGridView lên các TextBox
        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null && dgvList.CurrentRow.Index < dt.Rows.Count)
            {
                var row = dgvList.CurrentRow;
                txtId.Text = row.Cells["Mã SP"].Value?.ToString();
                txtName.Text = row.Cells["Tên SP"].Value?.ToString();
                cboCategory.Text = row.Cells["Danh mục"].Value?.ToString();
                txtPrice.Text = row.Cells["Đơn giá"].Value?.ToString();
                txtQuantity.Text = row.Cells["Số lượng"].Value?.ToString();
            }
        }

        // Nút Thêm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text) && !string.IsNullOrWhiteSpace(txtName.Text))
            {
                dt.Rows.Add(txtId.Text, txtName.Text, cboCategory.Text, txtPrice.Text, txtQuantity.Text);
                btnClearInput_Click(sender, e);
            }
        }

        // Nút Sửa
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null && dgvList.CurrentRow.Index < dt.Rows.Count)
            {
                var row = dt.Rows[dgvList.CurrentRow.Index];
                row["Mã SP"] = txtId.Text;
                row["Tên SP"] = txtName.Text;
                row["Danh mục"] = cboCategory.Text;
                row["Đơn giá"] = txtPrice.Text;
                row["Số lượng"] = txtQuantity.Text;
            }
        }

        // Nút Xóa
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null && dgvList.CurrentRow.Index < dt.Rows.Count)
            {
                dt.Rows.RemoveAt(dgvList.CurrentRow.Index);
                btnClearInput_Click(sender, e);
            }
        }

        // Nút Làm mới
        private void btnClearInput_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            txtDescription.Clear();
            txtId.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

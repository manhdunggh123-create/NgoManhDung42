using System;
using System.Windows.Forms;

namespace WinFormsExercises
{
    public partial class Form4_3_Calculator : Form
    {
        double so1 = 0;
        string phepToan = "";
        bool nhapMoi = true;

        public Form4_3_Calculator()
        {
            InitializeComponent();
        }

        // Gán chung cho 10 nút bấm số btn0..btn9 bằng tham số object sender
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (nhapMoi || txtDisplay.Text == "0")
            {
                txtDisplay.Text = btn.Text;
                nhapMoi = false;
            }
            else
            {
                txtDisplay.Text += btn.Text;
            }
        }

        // Các nút phép toán: +, -, *, /
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            so1 = double.Parse(txtDisplay.Text);
            phepToan = btn.Text;
            lblHistory.Text = $"{so1} {phepToan}";
            nhapMoi = true;
        }

        // Nút = tính kết quả
        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phepToan)) return;

            double so2 = double.Parse(txtDisplay.Text);
            double ketQua = 0;

            switch (phepToan)
            {
                case "+": ketQua = so1 + so2; break;
                case "-": ketQua = so1 - so2; break;
                case "*": ketQua = so1 * so2; break;
                case "/": ketQua = so2 != 0 ? (so1 / so2) : 0; break;
            }

            lblHistory.Text = $"{so1} {phepToan} {so2} =";
            txtDisplay.Text = ketQua.ToString();
            phepToan = "";
            nhapMoi = true;
        }

        // Nút C (Clear)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            lblHistory.Text = "";
            so1 = 0;
            phepToan = "";
            nhapMoi = true;
        }

        // Nút xóa lùi
        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                if (string.IsNullOrEmpty(txtDisplay.Text)) txtDisplay.Text = "0";
            }
        }

        // Nút dấu chấm
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
                nhapMoi = false;
            }
        }
    }
}

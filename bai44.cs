using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsExercises
{
    public partial class Form4_4_FastFood : Form
    {
        // Bảng giá các món ăn theo đề bài
        Dictionary<string, int> bangGia = new Dictionary<string, int>
        {
            { "Hamburger", 50000 },
            { "Pizza", 120000 },
            { "Gà Rán", 35000 },
            { "Pepsi", 15000 }
        };

        public Form4_4_FastFood()
        {
            InitializeComponent();
        }

        private void Form4_4_FastFood_Load(object sender, EventArgs e)
        {
            // Danh sách món ăn sẵn có
            lstMenu.Items.Add("Hamburger");
            lstMenu.Items.Add("Pizza");
            lstMenu.Items.Add("Gà Rán");
            lstMenu.Items.Add("Pepsi");
            TinhTongTien();
        }

        // Nút >: Chuyển món đang chọn sang lstSelected
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItem != null)
            {
                lstSelected.Items.Add(lstMenu.SelectedItem);
                TinhTongTien();
            }
        }

        // Nút <: Xóa món khỏi lstSelected
        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem != null)
            {
                lstSelected.Items.Remove(lstSelected.SelectedItem);
                TinhTongTien();
            }
        }

        // Xóa tất cả các món đã chọn
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstSelected.Items.Clear();
            TinhTongTien();
        }

        // Tự động cập nhật tổng tiền các món trong lstSelected
        private void TinhTongTien()
        {
            int tongTien = 0;
            foreach (var item in lstSelected.Items)
            {
                string tenMon = item.ToString()!;
                if (bangGia.ContainsKey(tenMon))
                {
                    tongTien += bangGia[tenMon];
                }
            }
            lblTotal.Text = $"Tổng tiền: {tongTien:N0} VNĐ";
        }

        // Đặt hàng
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (lstSelected.Items.Count == 0) return;

            MessageBox.Show($"Đặt hàng thành công!\n{lblTotal.Text}", "Hóa đơn");
            lstSelected.Items.Clear();
            TinhTongTien();
        }

        private void lstMenu_DoubleClick(object sender, EventArgs e) => btnMoveRight_Click(sender, e);
        private void lstSelected_DoubleClick(object sender, EventArgs e) => btnMoveLeft_Click(sender, e);
        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsExercises
{
    public partial class Form4_2_Register : Form
    {
        // Lớp đối tượng Khóa học nạp vào ComboBox
        class Course
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public Course(string ma, string ten) { Ma = ma; Ten = ten; }
        }

        public Form4_2_Register()
        {
            InitializeComponent();
        }

        private void Form4_2_Register_Load(object sender, EventArgs e)
        {
            // Binding dữ liệu cho cboCourse với DisplayMember và ValueMember
            cboCourse.DataSource = new List<Course>
            {
                new Course("CS01", "Lập trình C# & WinForms"),
                new Course("WEB02", "Lập trình Web ASP.NET"),
                new Course("DB03", "Cơ sở dữ liệu SQL Server")
            };
            cboCourse.DisplayMember = "Ten";
            cboCourse.ValueMember = "Ma";
        }

        // Nút Đăng ký: Tổng hợp và in thông tin lên MessageBox
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string gioiTinh = rdoMale.Checked ? "Nam" : (rdoFemale.Checked ? "Nữ" : "Khác");
            string ngaySinh = dtpBirthDate.Value.ToString("dd/MM/yyyy");
            string khoaHoc = $"{cboCourse.Text} (Mã: {cboCourse.SelectedValue})";

            string thongTin = $"Họ tên: {txtFullName.Text}\n" +
                              $"Ngày sinh: {ngaySinh}\n" +
                              $"Giới tính: {gioiTinh}\n" +
                              $"SĐT: {mtxtPhone.Text}\n" +
                              $"Khóa học: {khoaHoc}";

            MessageBox.Show(thongTin, "Thông tin đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            mtxtPhone.Clear();
            rdoMale.Checked = true;
            chkEnglish.Checked = chkGit.Checked = chkSoftSkills.Checked = chkProject.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;

namespace FaceRegconizer
{
    public partial class Student_Entry : Form
    {
        //khai báo variables và object
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public Student_Entry()
        {
            InitializeComponent();
        }

        //Will reset the full form data
        //------------------------------
        public void Reset()
        {
            txtPresentAbsent.Text = "";
            txtStudentName.Text = "";
            txtSubject.Text = "";
            txtTerm.Text = "";
            txtYear.Text = "";
            txtStudentID.Text = "";
            txtID.Text = "";
            txtStudentName.Focus();
            auto();
        }

        private void Student_Entry_Load(object sender, EventArgs e)
        {
            //SetFormMode("edit");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //không dùng
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //không dùng
        }

        //lấy data từ cơ sở dữ liệu và hiện lên form -> giảm thời gian nhập liệu thô nếu muốn đổi người
        private void btnGetData_Click(object sender, EventArgs e)
        {
            //KHÔNG DÙNG NỮA
        }

        //đóng
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Tạo số seri tự động
        //---------------------------------------------------
        public void auto()
        {

            int Num = 0;
            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();
            string sql = "SELECT MAX(C_ID+1) FROM dbo.Students";
            cc.cmd = new SqlCommand(sql);
            cc.cmd.Connection = cc.con;
            if (Convert.IsDBNull(cc.cmd.ExecuteScalar()))
            {
                Num = 1;
                //txtStudentID.Text = Convert.ToString(Num);
                txtID.Text = "C-" + Convert.ToString(Num);
            }
            else
            {
                Num = (int)(cc.cmd.ExecuteScalar());
                //txtStudentID.Text = Convert.ToString(Num);
                txtID.Text = "C-" + Convert.ToString(Num);
            }
            cc.cmd.Dispose();
            cc.con.Close();
            cc.con.Dispose();
            /*
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files |*.png; *.bmp; *.jpg;*.jpeg; *.gif;";
            openFileDialog1.FilterIndex = 4;
            openFileDialog1.FileName = "";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); // sửa theo tên thực tế của PictureBox
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null; // Xóa ảnh
            MessageBox.Show("Ảnh đã được xóa khỏi khung hiển thị.", "Xóa ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            txtStudentID.Enabled = false;
            if (txtStudentID.Text == "")
            {
                MessageBox.Show("Please enter student name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return;
            }

            if (txtYear.Text == "")
            {
                MessageBox.Show("Please enter year", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return;
            }
            if (txtTerm.Text == "")
            {
                MessageBox.Show("Please enter term", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTerm.Focus();
                return;
            }
            if (txtPresentAbsent.Text == "")
            {
                MessageBox.Show("Please enter PresentAbsent.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPresentAbsent.Focus();
                return;
            }
            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();
            string cb = "Update Students set StudentID=@d2,Name=@d3,Year=@d4,Term=@d5,Subject=@d6,PresentAbsent=@d7,Photo=@d8 where C_ID=@d1";
            cc.cmd = new SqlCommand(cb);
            cc.cmd.Connection = cc.con;
            cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
            cc.cmd.Parameters.AddWithValue("@d2", txtStudentID.Text);
            cc.cmd.Parameters.AddWithValue("@d3", txtStudentName.Text);
            cc.cmd.Parameters.AddWithValue("@d4", txtYear.Text);
            cc.cmd.Parameters.AddWithValue("@d5", txtTerm.Text);
            cc.cmd.Parameters.AddWithValue("@d6", txtSubject.Text);
            cc.cmd.Parameters.AddWithValue("@d7", txtPresentAbsent.Text);
            MemoryStream ms = new MemoryStream();
            Bitmap bmpImage = new Bitmap(pictureBox1.Image);
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.GetBuffer();
            SqlParameter p = new SqlParameter("@d8", SqlDbType.Image);
            p.Value = data;
            cc.cmd.Parameters.Add(p);
            cc.cmd.ExecuteReader();
            cc.con.Close();
            st1 = lblUser.Text;
            st2 = "updated the Student'" + txtStudentName.Text + "' having Student id '" + txtStudentID.Text + "'";
            //cf.LogFunc(st1, System.DateTime.Now, st2);
            btnUpdate.Enabled = false;
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            /*
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Reset();
            SetFormMode("add");
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (txtStudentName.Text == "" || txtYear.Text == "" || txtTerm.Text == "" || txtSubject.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();

            // Kiểm tra trùng mã
            string check = "SELECT COUNT(*) FROM Students WHERE StudentID = @studentID";
            SqlCommand cmdCheck = new SqlCommand(check, cc.con);
            cmdCheck.Parameters.AddWithValue("@studentID", txtStudentID.Text);
            int count = (int)cmdCheck.ExecuteScalar();

            if (count > 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cc.con.Close();
                return;
            }

            // Tiến hành lưu
            string cb = "INSERT INTO Students(StudentID, Name, Year, Term, Subject, PresentAbsent, Photo) VALUES (@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
            SqlCommand cmd = new SqlCommand(cb, cc.con);
            //cmd.Parameters.AddWithValue("@d1", txtID.Text);
            cmd.Parameters.AddWithValue("@d2", txtStudentID.Text);
            cmd.Parameters.AddWithValue("@d3", txtStudentName.Text);
            cmd.Parameters.AddWithValue("@d4", txtYear.Text);
            cmd.Parameters.AddWithValue("@d5", txtTerm.Text);
            cmd.Parameters.AddWithValue("@d6", txtSubject.Text);
            cmd.Parameters.AddWithValue("@d7", ""); // PresentAbsent để trống lúc thêm mới

            MemoryStream ms = new MemoryStream();
            Bitmap bmpImage = new Bitmap(pictureBox1.Image);
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.ToArray();
            SqlParameter p = new SqlParameter("@d8", SqlDbType.Image) { Value = data };
            cmd.Parameters.Add(p);

            cmd.ExecuteNonQuery();
            cc.con.Close();

            MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnUpdate.Enabled = true;
        }
        //de public con dung ben Student_Entry_Record
        public void SetFormMode(string mode)
        {
            if (mode == "add")
            {
                Reset();
                txtID.Enabled = false;
                txtStudentID.Enabled = true;
                btnSave.Visible = true;
                btnSave.Enabled = true;
                btnUpdate.Visible = false;
                btnUpdate.Enabled = false;
                txtPresentAbsent.Enabled = true;
            }
            else if (mode == "edit")
            {
                txtID.Enabled = false;
                txtStudentID.Enabled = false;
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btnUpdate.Enabled = true;
                txtPresentAbsent.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Confirm deletion with the user
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // If user clicks Yes, proceed with deletion
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Open the database connection
                    cc.con = new SqlConnection(cs.DBConn);
                    cc.con.Open();

                    // SQL DELETE command to remove the student record from the database
                    string deleteQuery = "DELETE FROM Students WHERE C_ID = @C_ID";
                    cc.cmd = new SqlCommand(deleteQuery, cc.con);
                    cc.cmd.Parameters.AddWithValue("@C_ID", txtID.Text); // Assuming txtID contains the C_ID of the student to delete

                    // Execute the query
                    int rowsAffected = cc.cmd.ExecuteNonQuery();
                    cc.con.Close();

                    if (rowsAffected > 0)
                    {
                        // If a record was deleted, show success message and reset the form
                        MessageBox.Show("Student record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Reset();
                    }
                    else
                    {
                        // If no record was found for deletion
                        MessageBox.Show("No matching student found to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Show error if something goes wrong
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

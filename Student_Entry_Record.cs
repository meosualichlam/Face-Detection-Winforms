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
//using Microsoft.Office.Interop.Excel;
//using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;

namespace FaceRegconizer
{
    public partial class Student_Entry_Record : Form
    {
        //khai bao
        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        public Student_Entry_Record()
        {
            InitializeComponent();
        }
        public void GetData()
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(C_ID) as [ID], RTRIM(StudentID) as [Student ID], RTRIM(Name) as [Student Name], RTRIM(Year) as [Year], RTRIM(Term) as [Term], RTRIM(Subject) as [Subject], RTRIM(PresentAbsent) as [PresentAbsent], Photo FROM dbo.Students ORDER BY Name", cc.con);
                cc.da = new SqlDataAdapter(cc.cmd);
                cc.ds = new DataSet();
                cc.da.Fill(cc.ds, "Students");
                dgw.DataSource = cc.ds.Tables["Students"].DefaultView;
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtGuestName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                cc.cmd = new SqlCommand("SELECT RTRIM(C_ID) as [ID], RTRIM(StudentID) as [Student ID], RTRIM(Name) as [Student Name], RTRIM(Year) as [Year], RTRIM(Term) as [Term], RTRIM(Subject) as [Subject], RTRIM(PresentAbsent) as [PresentAbsent], Photo FROM dbo.Students WHERE Name LIKE @Name ORDER BY Name", cc.con);
                cc.cmd.Parameters.AddWithValue("@Name", txtStudentName.Text + "%");
                cc.da = new SqlDataAdapter(cc.cmd);
                cc.ds = new DataSet();
                cc.da.Fill(cc.ds, "Students");
                dgw.DataSource = cc.ds.Tables["Students"].DefaultView;
                cc.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Reset()
        {
            txtStudentName.Text = "";
            GetData();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmStudentRecord_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgw_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgw.CurrentRow.Index != -1)
                {
                    DataGridViewRow dr = dgw.CurrentRow;

                    // Gọi form Student_Entry
                    Student_Entry frm = new Student_Entry();

                    frm.txtID.Text = dr.Cells[0].Value.ToString();
                    frm.txtStudentID.Text = dr.Cells[1].Value.ToString();
                    frm.txtStudentName.Text = dr.Cells[2].Value.ToString();
                    frm.txtYear.Text = dr.Cells[3].Value.ToString();
                    frm.txtTerm.Text = dr.Cells[4].Value.ToString();
                    frm.txtSubject.Text = dr.Cells[5].Value.ToString();
                    frm.txtPresentAbsent.Text = dr.Cells[6].Value.ToString();

                    // Ảnh
                    if (dr.Cells[7].Value != DBNull.Value)
                    {
                        byte[] data = (byte[])dr.Cells[7].Value;
                        MemoryStream ms = new MemoryStream(data);
                        frm.pictureBox1.Image = Image.FromStream(ms);
                    }

                    frm.btnUpdate.Enabled = true;
                    frm.btnSave.Visible = false;
                    frm.txtID.Enabled = false;
                    frm.txtStudentID.Enabled = false;
                    frm.ShowDialog();  // dùng ShowDialog để chờ update xong mới quay lại
                                       // Sau khi đóng form, gọi lại GetData để cập nhật
                    GetData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgw_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ControlText;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ExcelBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                // EPPlus từ v5 trở đi yêu cầu set license
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

                using (SqlConnection cnn = new SqlConnection(cs.DBConn))
                {
                    cnn.Open();
                    string sql = "SELECT C_ID, StudentID, Name, Year, Term, Subject, PresentAbsent FROM dbo.Students";
                    SqlDataAdapter dscmd = new SqlDataAdapter(sql, cnn);
                    DataSet ds = new DataSet();
                    dscmd.Fill(ds);

                    using (ExcelPackage package = new ExcelPackage())
                    {
                        var worksheet = package.Workbook.Worksheets.Add("Student Records");

                        // Ghi tiêu đề
                        for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = ds.Tables[0].Columns[i].ColumnName;
                            worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                        }

                        // Ghi dữ liệu
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = ds.Tables[0].Rows[i][j]?.ToString();
                            }
                        }

                        // Đặt kích thước tự động
                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        // Đường dẫn lưu file
                        string filePath = @"E:\DIEM_DANH_NEU\DIEMDANH-STUDENT-RECORDS.xlsx";
                        File.WriteAllBytes(filePath, package.GetAsByteArray());

                        MessageBox.Show("File Excel đã được tạo tại:\n" + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GC.Collect();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // Mở form Student_Entry ở chế độ "add"
            Student_Entry studentEntryForm = new Student_Entry();
            studentEntryForm.SetFormMode("add");
            studentEntryForm.ShowDialog();  // Hiển thị form Student_Entry
            GetData();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //private void releaseObject(object obj)
        //{
        //    try
        //    {
        //        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
        //        obj = null;
        //    }
        //    catch (Exception ex)
        //    {
        //        obj = null;
        //        MessageBox.Show("Có lỗi xảy ra khi giải phóng tài nguyên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        GC.Collect();
        //    }
        //}
    }
}

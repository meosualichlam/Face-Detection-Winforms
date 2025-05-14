using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.Diagnostics;
using System.Data.Sql;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Data;
//using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Emgu.CV.Face;
using System.Text.RegularExpressions;
using Emgu.CV.Util;

namespace FaceRegconizer
{
    public partial class FrmPrincipal : Form
    {
        Image<Bgr, Byte> currentFrame;
        VideoCapture grabber;
        //capture thay bằng videocapture
        CascadeClassifier face;
        // Thay HaarCascade bằng CascadeClassifier
        // MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d); //Gỡ bỏ MCvFont
        //MCvFont bị loại bỏ → dùng CvInvoke.PutText(...) thay thế khi cần.
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<string> NamePersons = new List<string>();
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        //List<string> labels = new List<string>();
        //List<string> NamePersons = new List<string>();
        List<int> labelIds = new List<int>();
        Dictionary<int, string> labelMap = new Dictionary<int, string>();
        //ánh xạ tên <=> số
        int ContTrain, NumLabels, t;
        public static string name = "";
        public static string names = "";
        string atten = "PRESENT";

        ConnectionString cs = new ConnectionString();
        CommonClasses cc = new CommonClasses();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;

        // Chuyển nhãn từ string sang int để Train() đúng định dạng

        public FrmPrincipal()
        {
            InitializeComponent();
            face = new CascadeClassifier("haarcascade_frontalface_default.xml");
            //Thay DetectHaarCascade(...) bằng CascadeClassifier.DetectMultiScale(...).

            try
            {
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;
                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/" + LoadFaces));
                    //labels.Add(Labels[tf]);
                    int labelId = tf - 1; // gán ID theo thứ tự 0,1,2,...
                    string labelName = Labels[tf];

                    labelIds.Add(labelId);
                    labelMap[labelId] = labelName;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Không có dữ liệu khuôn mặt trong cơ sở dữ liệu. Vui lòng huấn luyện ít nhất một khuôn mặt bằng cách nhấn nút Huấn luyện.", "Trained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtYear.Text == "" && txtTerm.Text == "" && txtSubject.Text == "")
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin để khởi động máy ảnh", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return;
            }

            grabber = new VideoCapture(0);
            Application.Idle += new EventHandler(FrameGrabber);
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Hãy nhập họ và tên trước khi huấn luyện", "Thiếu họ và tên ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ContTrain++;

                Mat matFrame = new Mat();
                grabber.Read(matFrame);
                gray = matFrame.ToImage<Gray, byte>().Resize(320, 240, Inter.Cubic);

                Rectangle[] facesDetected = face.DetectMultiScale(
                    gray,
                    1.2,
                    10,
                    new Size(20, 20),
                    Size.Empty);

                foreach (Rectangle f in facesDetected)
                {
                    TrainedFace = gray.Copy(f).Resize(100, 100, Inter.Cubic);
                    break; // chỉ lấy 1 khuôn mặt
                }

                if (TrainedFace == null)
                {
                    MessageBox.Show("Không nhận diện được khuôn mặt!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // Gán ID mới cho người dùng
                int newLabelId = labelMap.Count;
                labelIds.Add(newLabelId);
                labelMap[newLabelId] = textBox1.Text;

                trainingImages.Add(TrainedFace);
                imageBox1.Image = TrainedFace;

                // Lưu ảnh và nhãn
                string path = Application.StartupPath + "/TrainedFaces/";
                Directory.CreateDirectory(path);

                File.WriteAllText(path + "TrainedLabels.txt", trainingImages.Count.ToString() + "%");

                for (int i = 0; i < trainingImages.Count; i++)
                {
                    trainingImages[i].Save(path + "face" + (i + 1) + ".bmp");
                    File.AppendAllText(path + "TrainedLabels.txt", labelMap[labelIds[i]] + "%");
                }

                MessageBox.Show(textBox1.Text + " đã được nhận diện và thêm mới! :)", "Huấn luyện OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khởi động nhận dạng khuôn mặt trước.\n" + ex.Message, "Huấn luyện thất bại", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void FrameGrabber(object sender, EventArgs e)
        {
                label12.Text = "0";
                //NamePersons.Add("");

                // Đọc một frame từ webcam (Emgu 4.10 dùng VideoCapture.Read)
                Mat frame = new Mat(); // Mat là kiểu ảnh ma trận raw từ OpenCV
                grabber.Read(frame);

                if (frame.IsEmpty)
                    return; // Không có ảnh thì bỏ qua vòng lặp

                currentFrame = frame.ToImage<Bgr, Byte>().Resize(320, 240, Inter.Cubic);
                gray = currentFrame.Convert<Gray, Byte>();

                // Thay DetectHaarCascade(...) bằng CascadeClassifier.DetectMultiScale(...).
                Rectangle[] facesDetected = face.DetectMultiScale(
                    gray,
                    1.2,
                    10,
                    new Size(20, 20),
                    Size.Empty);

                foreach (Rectangle f in facesDetected)
                {
                    t = t + 1;
                    result = currentFrame.Copy(f).Convert<Gray, byte>().Resize(100, 100, Inter.Cubic);

                    // Dùng CvInvoke.Rectangle(...) thay cho .Draw(...)
                    CvInvoke.Rectangle(currentFrame, f, new MCvScalar(0, 0, 255), 2);

                    // Dùng CvInvoke.Rectangle(...) và CvInvoke.PutText(...) thay cho .Draw(...) và MCvFont.
                    if (trainingImages.Count != 0)
                    {
                        MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                        // Sử dụng EigenFaceRecognizer mới thay cho EigenObjectRecognizer cũ.

                        EigenFaceRecognizer recognizer = new EigenFaceRecognizer(ContTrain, double.PositiveInfinity);
                        //recognizer.Train(trainingImages.ToArray(), labelIds.ToArray());
                        // Chuyển danh sách nhãn thành Mat (kiểu Emgu.CV yêu cầu)
                        Mat labelsMat = new Mat(labelIds.Count, 1, DepthType.Cv32S, 1);
                        labelsMat.SetTo(labelIds.ToArray());

                        // Chuyển danh sách ảnh huấn luyện sang VectorOfMat
                        VectorOfMat imagesVec = new VectorOfMat();
                        foreach (var img in trainingImages)
                        {
                            imagesVec.Push(new Mat[] { img.Mat });
                        }

                        // Huấn luyện mô hình
                        recognizer.Train(imagesVec, labelsMat);

                        var resultRecognized = recognizer.Predict(result);
                        int predictedId = resultRecognized.Label;

                        name = predictedId != -1 && labelMap.ContainsKey(predictedId)
                            ? labelMap[predictedId]
                            : "Unknown";

                        //them txtID
                        if (name != "Unknown")
                        {
                            using (SqlConnection conn = new SqlConnection(cs.DBConn))
                            {
                                conn.Open();
                                SqlCommand cmd = new SqlCommand("SELECT C_ID, StudentID, Photo FROM Students WHERE Name = @Name", conn);
                                cmd.Parameters.AddWithValue("@Name", name);

                                SqlDataReader reader = cmd.ExecuteReader();
                                if (reader.Read())
                                {
                                    txtStudentID.Text = reader["StudentID"].ToString();           //student id
                                    txtID.Text = reader["C_ID"].ToString(); //stt c_id

                                //anh tu dong hien neu nhan dang duoc nguoi dung
                                if (!Convert.IsDBNull(reader["Photo"]))
                                {
                                        try
                                        {

                                            byte[] imgBytes = (byte[])reader["Photo"];
                                            using (MemoryStream ms = new MemoryStream(imgBytes))
                                            {
                                                pictureBox1.Image = Image.FromStream(ms);
                                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                            }
                                        }
                                        catch (Exception imgEx)
                                        {
                                            MessageBox.Show("Lỗi ảnh: " + imgEx.Message, "Ảnh không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            //conn.Close();
                                //else
                                //{
                                //    MessageBox.Show("Không tìm thấy sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                        }
                          
                        }


                        CvInvoke.PutText(currentFrame, name, new Point(f.X - 2, f.Y - 2),
                            FontFace.HersheyComplex, 0.5, new MCvScalar(0, 255, 0), 1);
                    }
                //if (t > 0 && t - 1 < NamePersons.Count)
                //    NamePersons[t - 1] = name;

                NamePersons.Add(name); // đảm bảo ghi tên đúng vào danh sách
                //NamePersons.Add("");
                label12.Text = facesDetected.Length.ToString();
                }

                t = 0;
                for (int nnn = 0; nnn < facesDetected.Length; nnn++)
                {
                    names += NamePersons[nnn] + ", ";
                }

                imageBoxFrameGrabber.Image = currentFrame;
                label7.Text = names;
                label10.Text = names;
                names = "";
                NamePersons.Clear();

        }
        //Button Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPresent_Click(object sender, EventArgs e) 
        {
            if (txtYear.Text == "")
            {
                MessageBox.Show("Hãy nhập năm học.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtYear.Focus();
                return;
            }
            if (txtTerm.Text == "")
            {
                MessageBox.Show("Hãy nhập kỳ học.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTerm.Focus();
                return;
            }
            if (txtSubject.Text == "")
            {
                MessageBox.Show("Hãy nhập môn học.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubject.Focus();
                return;
            }

            //Main place to save data to the database

            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();
            string cb = "insert into Students(StudentID,Name,Year,Term,Subject,PresentAbsent,Photo) VALUES (@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
            cc.cmd = new SqlCommand(cb);
            cc.cmd.Connection = cc.con;
            //cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
            cc.cmd.Parameters.AddWithValue("@d2", txtStudentID.Text);
            cc.cmd.Parameters.AddWithValue("@d3", name);
            cc.cmd.Parameters.AddWithValue("@d4", txtYear.Text);
            cc.cmd.Parameters.AddWithValue("@d5", txtTerm.Text);
            cc.cmd.Parameters.AddWithValue("@d6", txtSubject.Text);
            cc.cmd.Parameters.AddWithValue("@d7", atten);
            MemoryStream ms = new MemoryStream();
            //không có ảnh thì không thể lưu
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng chọn ảnh trước khi lưu.", "Thiếu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Bitmap bmpImage = new Bitmap(pictureBox1.Image);
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] data = ms.ToArray();
            SqlParameter p = new SqlParameter("@d8", SqlDbType.Image);
            p.Value = data;
            cc.cmd.Parameters.Add(p);
            cc.cmd.ExecuteReader();
            cc.con.Close();
            st1 = lblUser.Text;
            st2 = "thêm sinh viên mới'" + name + "' có mã sinh viên là '" + txtStudentID.Text + "'";
            //cf.LogFunc(st1, System.DateTime.Now, st2);
            btnUpdate.Enabled = false;
            MessageBox.Show("Lưu thành công", "Bản ghi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            /*  catch (Exception ex)
              {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muỗn xóa bản ghi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }
        public void Reset()
        {
            txtSubject.Text = "";
            txtTerm.Text = "";
            txtYear.Text = "";
            txtStudentID.Text = "";
            txtID.Text = "";

            btnUpdate.Enabled = true;
            //btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            //Picture.Image = Properties.Resources.photo;
            auto();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        //btn_Update (ko phai btnSave dau)
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cc.con = new SqlConnection(cs.DBConn);
                cc.con.Open();
                string updateQuery = "UPDATE Students SET StudentID = @StudentID, Name = @Name, Year = @Year, Term = @Term, Subject = @Subject, PresentAbsent = @PresentAbsent, Photo = @Photo WHERE C_ID = @C_ID";

                cc.cmd = new SqlCommand(updateQuery, cc.con);
                cc.cmd.Parameters.AddWithValue("@C_ID", txtID.Text);
                cc.cmd.Parameters.AddWithValue("@StudentID", txtStudentID.Text);
                cc.cmd.Parameters.AddWithValue("@Name", name);
                cc.cmd.Parameters.AddWithValue("@Year", txtYear.Text);
                cc.cmd.Parameters.AddWithValue("@Term", txtTerm.Text);
                cc.cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
                cc.cmd.Parameters.AddWithValue("@PresentAbsent", atten);

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Vui lòng chọn ảnh trước khi cập nhật.", "Thiếu ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    using (Bitmap bmp = new Bitmap(pictureBox1.Image)) // Tạo bản sao
                    {
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Lưu bản sao
                    }
                    byte[] imgData = ms.ToArray();
                    cc.cmd.Parameters.Add("@Photo", SqlDbType.Image).Value = imgData;
                }
                int rowsAffected = cc.cmd.ExecuteNonQuery();
                cc.con.Close();

                if (rowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Cập nhật sinh viên có mã: " + txtStudentID.Text;
                    //cf.LogFunc(st1, DateTime.Now, st2);
                    MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản ghi để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_records()
        {
            int RowsAffected = 0;
            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();
            string ct = "delete from Students where C_ID=@d1";
            cc.cmd = new SqlCommand(ct);
            cc.cmd.Connection = cc.con;
            cc.cmd.Parameters.AddWithValue("@d1", txtID.Text);
            RowsAffected = cc.cmd.ExecuteNonQuery();
            if (RowsAffected > 0)
            {
                st1 = lblUser.Text;
                st2 = "xóa sinh viên'" + label6 + "' có mã sinh viên là '" + txtStudentID.Text + "'";
                //cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Xóa thành công", "Bản ghi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            else
            {
                MessageBox.Show("Không tìm thấy bản ghi.", "Chân thành xin lỗi bạn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
            if (cc.con.State == ConnectionState.Open)
            {
                cc.con.Close();
            }


            /* catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }


        //auto  generate id
        //------------------
        public void auto()
        {
            int Num = 0;
            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();
            string sql = "SELECT MAX(C_ID+1) FROM Students";
            cc.cmd = new SqlCommand(sql);
            cc.cmd.Connection = cc.con;
            if (Convert.IsDBNull(cc.cmd.ExecuteScalar()))
            {
                Num = 1;
                txtID.Text = Convert.ToString(Num);
                txtStudentID.Text = "C-" + Convert.ToString(Num);
            }
            else
            {
                Num = (int)(cc.cmd.ExecuteScalar());
                txtID.Text = Convert.ToString(Num);
                txtStudentID.Text = "C-" + Convert.ToString(Num);
            }
            cc.cmd.Dispose();
            cc.con.Close();
            cc.con.Dispose();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Student_Entry_Record frm = new Student_Entry_Record();
            frm.Reset();
            frm.Show();
        }

        private void ExcelBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Khai báo license cho EPPlus
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Students");

                    // Header
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "Student ID";
                    worksheet.Cells[1, 3].Value = "Student Name";
                    worksheet.Cells[1, 4].Value = "Year";
                    worksheet.Cells[1, 5].Value = "Term";
                    worksheet.Cells[1, 6].Value = "Subject";
                    worksheet.Cells[1, 7].Value = "Present/Absent";

                    // Lấy dữ liệu từ DB
                    cc.con = new SqlConnection(cs.DBConn);
                    cc.con.Open();
                    string query = "SELECT C_ID, StudentID, Name, Year, Term, Subject, PresentAbsent FROM dbo.Students";
                    SqlCommand cmd = new SqlCommand(query, cc.con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    int row = 2;
                    while (reader.Read())
                    {
                        worksheet.Cells[row, 1].Value = reader["C_ID"];
                        worksheet.Cells[row, 2].Value = reader["StudentID"];
                        worksheet.Cells[row, 3].Value = reader["Name"];
                        worksheet.Cells[row, 4].Value = reader["Year"];
                        worksheet.Cells[row, 5].Value = reader["Term"];
                        worksheet.Cells[row, 6].Value = reader["Subject"];
                        worksheet.Cells[row, 7].Value = reader["PresentAbsent"];
                        row++;
                    }

                    reader.Close();
                    cc.con.Close();

                    // Lưu file Excel
                    string savePath = @"E:\DIEM_DANH_NEU\NEU-CLASS-ATTENDANCE.xlsx";
                    File.WriteAllBytes(savePath, package.GetAsByteArray());

                    MessageBox.Show("File Excel đã được tạo: " + savePath, "Xuất Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        //        MessageBox.Show("Có lỗi xảy ra khi giải phóng tài nguyên " + ex.ToString());
        //    }

        //    finally
        //    {
        //        GC.Collect();
        //    }

        //}
        //thêm csdl vào combobox
        private void LoadComboBoxData()
        {
            cc.con = new SqlConnection(cs.DBConn);
            cc.con.Open();

            // Lấy dữ liệu cho Year
            SqlCommand cmdYear = new SqlCommand("SELECT DISTINCT Year FROM dbo.Students", cc.con);
            SqlDataReader readerYear = cmdYear.ExecuteReader();
            while (readerYear.Read())
            {
                txtYear.Items.Add(readerYear["Year"].ToString());
            }
            readerYear.Close();

            // Lấy dữ liệu cho Term
            SqlCommand cmdTerm = new SqlCommand("SELECT DISTINCT Term FROM dbo.Students", cc.con);
            SqlDataReader readerTerm = cmdTerm.ExecuteReader();
            while (readerTerm.Read())
            {
                txtTerm.Items.Add(readerTerm["Term"].ToString());
            }
            readerTerm.Close();

            // Lấy dữ liệu cho Subject
            SqlCommand cmdSubject = new SqlCommand("SELECT DISTINCT Subject FROM dbo.Students", cc.con);
            SqlDataReader readerSubject = cmdSubject.ExecuteReader();
            while (readerSubject.Read())
            {
                txtSubject.Items.Add(readerSubject["Subject"].ToString());
            }
            readerSubject.Close();

            cc.con.Close();

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            LoadComboBoxData();
        }
        //xóa ảnh
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null; // Xóa ảnh
            MessageBox.Show("Ảnh đã được xóa khỏi khung hiển thị.", "Xóa ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //btnUpdate.Enabled = true; // nút cập nhật được bật
            //btnDelete.Enabled = true;
            //btnEdit.Enabled = true;
            //txtID.Enabled = false; // ID không sửa
            //txtStudentID.Enabled = true; // cho phép sửa nếu muốn
        }
    }
}

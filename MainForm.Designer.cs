namespace FaceRegconizer
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlPrincipal = new Panel();
            ExcelStore = new Button();
            btnPresent = new Button();
            panel1 = new Panel();
            btnClose = new Button();
            btnGetData = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnNew = new Button();
            pnlInfo = new Panel();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            btnBrowse = new Button();
            txtID = new TextBox();
            txtSubject = new ComboBox();
            txtTerm = new ComboBox();
            txtYear = new ComboBox();
            txtStudentID = new TextBox();
            lblUser = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            button1 = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            groupBox1 = new GroupBox();
            button2 = new Button();
            textBox1 = new TextBox();
            label8 = new Label();
            imageBox1 = new Emgu.CV.UI.ImageBox();
            label1 = new Label();
            progressBar1 = new ProgressBar();
            imageBoxFrameGrabber = new Emgu.CV.UI.ImageBox();
            lblTitle = new Label();
            pnlPrincipal.SuspendLayout();
            panel1.SuspendLayout();
            pnlInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageBoxFrameGrabber).BeginInit();
            SuspendLayout();
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = Color.White;
            pnlPrincipal.Controls.Add(ExcelStore);
            pnlPrincipal.Controls.Add(btnPresent);
            pnlPrincipal.Controls.Add(panel1);
            pnlPrincipal.Controls.Add(pnlInfo);
            pnlPrincipal.Controls.Add(groupBox2);
            pnlPrincipal.Controls.Add(groupBox1);
            pnlPrincipal.Controls.Add(label1);
            pnlPrincipal.Controls.Add(progressBar1);
            pnlPrincipal.Controls.Add(imageBoxFrameGrabber);
            pnlPrincipal.Controls.Add(lblTitle);
            pnlPrincipal.ForeColor = Color.Red;
            pnlPrincipal.Location = new Point(12, 12);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(1197, 766);
            pnlPrincipal.TabIndex = 0;
            // 
            // ExcelStore
            // 
            ExcelStore.BackColor = SystemColors.Window;
            ExcelStore.ForeColor = Color.RoyalBlue;
            ExcelStore.Location = new Point(898, 415);
            ExcelStore.Name = "ExcelStore";
            ExcelStore.Size = new Size(137, 29);
            ExcelStore.TabIndex = 13;
            ExcelStore.Text = "Xuất file Excel";
            ExcelStore.UseVisualStyleBackColor = false;
            ExcelStore.Click += ExcelBackup_Click;
            // 
            // btnPresent
            // 
            btnPresent.BackColor = SystemColors.Window;
            btnPresent.ForeColor = Color.RoyalBlue;
            btnPresent.Location = new Point(722, 415);
            btnPresent.Name = "btnPresent";
            btnPresent.Size = new Size(114, 29);
            btnPresent.TabIndex = 12;
            btnPresent.Text = "Điểm danh";
            btnPresent.UseVisualStyleBackColor = false;
            btnPresent.Click += btnPresent_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lavender;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnGetData);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(btnUpdate);
            panel1.Controls.Add(btnNew);
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(523, 343);
            panel1.Name = "panel1";
            panel1.Size = new Size(656, 48);
            panel1.TabIndex = 8;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(555, 7);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(84, 29);
            btnClose.TabIndex = 11;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(416, 7);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(133, 29);
            btnGetData.TabIndex = 10;
            btnGetData.Text = "Lấy dữ liệu";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += btnGetData_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(197, 7);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(84, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(107, 7);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(84, 29);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnSave_Click;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(17, 7);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(84, 29);
            btnNew.TabIndex = 0;
            btnNew.Text = "Mới";
            btnNew.UseVisualStyleBackColor = true;
            btnNew.Click += btnNew_Click;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.GhostWhite;
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlInfo.Controls.Add(pictureBox1);
            pnlInfo.Controls.Add(button3);
            pnlInfo.Controls.Add(btnBrowse);
            pnlInfo.Controls.Add(txtID);
            pnlInfo.Controls.Add(txtSubject);
            pnlInfo.Controls.Add(txtTerm);
            pnlInfo.Controls.Add(txtYear);
            pnlInfo.Controls.Add(txtStudentID);
            pnlInfo.Controls.Add(lblUser);
            pnlInfo.Controls.Add(label7);
            pnlInfo.Controls.Add(label6);
            pnlInfo.Controls.Add(label5);
            pnlInfo.Controls.Add(label4);
            pnlInfo.Controls.Add(label3);
            pnlInfo.Controls.Add(label2);
            pnlInfo.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlInfo.ForeColor = Color.RoyalBlue;
            pnlInfo.Location = new Point(523, 85);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Size = new Size(656, 252);
            pnlInfo.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(442, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(159, 163);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(531, 193);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 14;
            button3.Text = "Xóa ảnh";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBrowse.ForeColor = SystemColors.ActiveCaptionText;
            btnBrowse.Location = new Point(417, 193);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 12;
            btnBrowse.Text = "Chọn ảnh";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(189, 190);
            txtID.Name = "txtID";
            txtID.Size = new Size(175, 27);
            txtID.TabIndex = 11;
            // 
            // txtSubject
            // 
            txtSubject.FormattingEnabled = true;
            txtSubject.Location = new Point(189, 156);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(177, 28);
            txtSubject.TabIndex = 10;
            // 
            // txtTerm
            // 
            txtTerm.FormattingEnabled = true;
            txtTerm.Location = new Point(189, 119);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(177, 28);
            txtTerm.TabIndex = 9;
            // 
            // txtYear
            // 
            txtYear.FormattingEnabled = true;
            txtYear.Location = new Point(189, 85);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(177, 28);
            txtYear.TabIndex = 8;
            // 
            // txtStudentID
            // 
            txtStudentID.Enabled = false;
            txtStudentID.Location = new Point(189, 24);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(177, 27);
            txtStudentID.TabIndex = 7;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(36, 193);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(53, 20);
            lblUser.TabIndex = 6;
            lblUser.Text = "label8";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            lblUser.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(189, 58);
            label7.Name = "label7";
            label7.Size = new Size(212, 20);
            label7.TabIndex = 5;
            label7.Text = "Họ và tên sẽ hiển thị ở đây.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(36, 159);
            label6.Name = "label6";
            label6.Size = new Size(83, 20);
            label6.TabIndex = 4;
            label6.Text = "Môn học: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 123);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 3;
            label5.Text = "Học kỳ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 93);
            label4.Name = "label4";
            label4.Size = new Size(81, 20);
            label4.TabIndex = 2;
            label4.Text = "Năm học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 58);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 1;
            label3.Text = "Họ và tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 24);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên: ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(347, 477);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(382, 251);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Kết quả:";
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(130, 142);
            button1.Name = "button1";
            button1.Size = new Size(125, 29);
            button1.TabIndex = 18;
            button1.Text = "Bật camera";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(333, 98);
            label12.Name = "label12";
            label12.Size = new Size(17, 18);
            label12.TabIndex = 16;
            label12.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.RoyalBlue;
            label11.Location = new Point(29, 98);
            label11.Name = "label11";
            label11.Size = new Size(298, 18);
            label11.TabIndex = 17;
            label11.Text = "Số lượng khuôn mặt có thể nhận diện: ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.RoyalBlue;
            label10.Location = new Point(29, 67);
            label10.Name = "label10";
            label10.Size = new Size(103, 18);
            label10.TabIndex = 16;
            label10.Text = "Không có ai.";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ActiveCaptionText;
            label9.Location = new Point(29, 37);
            label9.Name = "label9";
            label9.Size = new Size(187, 20);
            label9.TabIndex = 16;
            label9.Text = "Số lượng người trong hình:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(imageBox1);
            groupBox1.Location = new Point(44, 477);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(266, 251);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Huấn luyện:";
            // 
            // button2
            // 
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(66, 216);
            button2.Name = "button2";
            button2.Size = new Size(125, 29);
            button2.TabIndex = 16;
            button2.Text = "Huấn luyện";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(90, 181);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 15;
            textBox1.Text = "Nhập tên";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.RoyalBlue;
            label8.Location = new Point(33, 186);
            label8.Name = "label8";
            label8.Size = new Size(41, 18);
            label8.TabIndex = 14;
            label8.Text = "Tên: ";
            // 
            // imageBox1
            // 
            imageBox1.BorderStyle = BorderStyle.FixedSingle;
            imageBox1.Location = new Point(27, 26);
            imageBox1.Name = "imageBox1";
            imageBox1.Size = new Size(223, 145);
            imageBox1.TabIndex = 13;
            imageBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(129, 349);
            label1.Name = "label1";
            label1.Size = new Size(180, 20);
            label1.TabIndex = 4;
            label1.Text = "Hãy chuẩn bị sẵn sàng";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(43, 323);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(354, 14);
            progressBar1.TabIndex = 3;
            // 
            // imageBoxFrameGrabber
            // 
            imageBoxFrameGrabber.BorderStyle = BorderStyle.FixedSingle;
            imageBoxFrameGrabber.Location = new Point(43, 85);
            imageBoxFrameGrabber.Name = "imageBoxFrameGrabber";
            imageBoxFrameGrabber.Size = new Size(354, 232);
            imageBoxFrameGrabber.TabIndex = 2;
            imageBoxFrameGrabber.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = SystemColors.Info;
            lblTitle.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(226, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(664, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hệ thống điểm danh bằng nhận dạng khuôn mặt";
            lblTitle.Click += lblTitle_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            ClientSize = new Size(1221, 790);
            Controls.Add(pnlPrincipal);
            Name = "FrmPrincipal";
            Text = "Điểm danh bằng nhận dạng khuôn mặt";
            Load += FrmPrincipal_Load;
            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();
            panel1.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageBoxFrameGrabber).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlPrincipal;
        private Label lblTitle;
        private Label label1;
        private ProgressBar progressBar1;
        private Emgu.CV.UI.ImageBox imageBoxFrameGrabber;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Panel pnlInfo;
        private Label label2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label lblUser;
        private Label label7;
        private Button button3;
        private Button btnBrowse;
        private TextBox txtID;
        private ComboBox txtSubject;
        private ComboBox txtTerm;
        private ComboBox txtYear;
        private TextBox txtStudentID;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Button btnClose;
        private Button btnGetData;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnNew;
        private Button btnPresent;
        private TextBox textBox1;
        private Label label8;
        private Emgu.CV.UI.ImageBox imageBox1;
        private Button button2;
        private Label label10;
        private Label label9;
        private Button ExcelStore;
        private Button button1;
        private Label label12;
        private Label label11;
    }
}

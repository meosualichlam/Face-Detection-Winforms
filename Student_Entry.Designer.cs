namespace FaceRegconizer
{
    partial class Student_Entry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1 = new Panel();
            panel4 = new Panel();
            btnDelete = new Button();
            btnSave = new Button();
            btnAddNew = new Button();
            btnClose = new Button();
            btnUpdate = new Button();
            panel3 = new Panel();
            txtID = new TextBox();
            txtPresentAbsent = new TextBox();
            txtSubject = new TextBox();
            txtTerm = new TextBox();
            txtYear = new TextBox();
            txtStudentName = new TextBox();
            txtStudentID = new TextBox();
            btnRemove = new Button();
            btnBrowse = new Button();
            pictureBox1 = new PictureBox();
            lblUser = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(833, 462);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(833, 462);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.GradientActiveCaption;
            panel4.Controls.Add(btnDelete);
            panel4.Controls.Add(btnSave);
            panel4.Controls.Add(btnAddNew);
            panel4.Controls.Add(btnClose);
            panel4.Controls.Add(btnUpdate);
            panel4.Location = new Point(674, 88);
            panel4.Name = "panel4";
            panel4.Size = new Size(135, 347);
            panel4.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(23, 158);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Xóa";
            btnDelete.UseCompatibleTextRendering = true;
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(23, 116);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 14;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(23, 31);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(94, 29);
            btnAddNew.TabIndex = 13;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(23, 282);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 11;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(23, 73);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Pink;
            panel3.Controls.Add(txtID);
            panel3.Controls.Add(txtPresentAbsent);
            panel3.Controls.Add(txtSubject);
            panel3.Controls.Add(txtTerm);
            panel3.Controls.Add(txtYear);
            panel3.Controls.Add(txtStudentName);
            panel3.Controls.Add(txtStudentID);
            panel3.Controls.Add(btnRemove);
            panel3.Controls.Add(btnBrowse);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(lblUser);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(41, 88);
            panel3.Name = "panel3";
            panel3.Size = new Size(624, 347);
            panel3.TabIndex = 1;
            // 
            // txtID
            // 
            txtID.Enabled = false;
            txtID.Location = new Point(132, 286);
            txtID.Name = "txtID";
            txtID.Size = new Size(125, 27);
            txtID.TabIndex = 16;
            txtID.TextChanged += textBox7_TextChanged;
            // 
            // txtPresentAbsent
            // 
            txtPresentAbsent.Location = new Point(133, 244);
            txtPresentAbsent.Name = "txtPresentAbsent";
            txtPresentAbsent.Size = new Size(199, 27);
            txtPresentAbsent.TabIndex = 15;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(133, 201);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(200, 27);
            txtSubject.TabIndex = 14;
            // 
            // txtTerm
            // 
            txtTerm.Location = new Point(132, 159);
            txtTerm.Name = "txtTerm";
            txtTerm.Size = new Size(201, 27);
            txtTerm.TabIndex = 13;
            // 
            // txtYear
            // 
            txtYear.Location = new Point(132, 117);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(201, 27);
            txtYear.TabIndex = 12;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(132, 79);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(200, 27);
            txtStudentName.TabIndex = 11;
            // 
            // txtStudentID
            // 
            txtStudentID.Location = new Point(132, 37);
            txtStudentID.Name = "txtStudentID";
            txtStudentID.Size = new Size(200, 27);
            txtStudentID.TabIndex = 10;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(454, 282);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(94, 29);
            btnRemove.TabIndex = 9;
            btnRemove.Text = "Xóa ảnh";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(454, 247);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 8;
            btnBrowse.Text = "Chọn ảnh";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(418, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(157, 201);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(33, 286);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(50, 20);
            lblUser.TabIndex = 6;
            lblUser.Text = "label8";
            lblUser.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 247);
            label7.Name = "label7";
            label7.Size = new Size(85, 20);
            label7.TabIndex = 5;
            label7.Text = "Điểm danh:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 204);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 4;
            label6.Text = "Môn học:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 162);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 3;
            label5.Text = "Kỳ học:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 120);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 2;
            label4.Text = "Năm học: ";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 82);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 1;
            label3.Text = "Họ và tên:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 40);
            label2.Name = "label2";
            label2.Size = new Size(98, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã sinh viên: ";
            label2.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(226, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(439, 51);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.HotTrack;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.InactiveBorder;
            label1.Location = new Point(71, 15);
            label1.Name = "label1";
            label1.Size = new Size(301, 25);
            label1.TabIndex = 0;
            label1.Text = "Thông tin điểm danh sinh viên";
            label1.Click += label1_Click;
            // 
            // Student_Entry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(893, 489);
            Controls.Add(flowLayoutPanel1);
            Name = "Student_Entry";
            Text = "Student_Entry";
            Load += Student_Entry_Load;
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private Label lblUser;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        public PictureBox pictureBox1;
        private Label label6;
        public Button btnUpdate;
        public Button btnRemove;
        public Button btnBrowse;
        public Button btnClose;
        public TextBox txtID;
        public TextBox txtPresentAbsent;
        public TextBox txtSubject;
        public TextBox txtTerm;
        public TextBox txtYear;
        public TextBox txtStudentName;
        public TextBox txtStudentID;
        public Button btnAddNew;
        public Button btnSave;
        private Button btnDelete;
    }
}
namespace FaceRegconizer
{
    partial class Student_Entry_Record
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
            panel1 = new Panel();
            panel2 = new Panel();
            dgw = new DataGridView();
            panel4 = new Panel();
            btnAddNew = new Button();
            txtStudentName = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            ExcelBackUp = new Button();
            btnClose = new Button();
            btnReset = new Button();
            panel6 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgw).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(15, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 496);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgw);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(21, 18);
            panel2.Name = "panel2";
            panel2.Size = new Size(749, 461);
            panel2.TabIndex = 0;
            // 
            // dgw
            // 
            dgw.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgw.Location = new Point(0, 210);
            dgw.Name = "dgw";
            dgw.RowHeadersWidth = 51;
            dgw.Size = new Size(752, 248);
            dgw.TabIndex = 3;
            dgw.CellContentClick += dgw_CellContentClick;
            dgw.RowPostPaint += dgw_RowPostPaint;
            dgw.MouseClick += dgw_MouseClick;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(btnAddNew);
            panel4.Controls.Add(txtStudentName);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(0, 106);
            panel4.Name = "panel4";
            panel4.Size = new Size(752, 104);
            panel4.TabIndex = 1;
            panel4.Paint += panel4_Paint;
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(607, 47);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(94, 29);
            btnAddNew.TabIndex = 2;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(180, 44);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(364, 27);
            txtStudentName.TabIndex = 1;
            txtStudentName.TextChanged += txtGuestName_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 47);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 0;
            label2.Text = "Tra cứu thông tin:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightGoldenrodYellow;
            panel3.Controls.Add(label1);
            panel3.Location = new Point(46, 16);
            panel3.Name = "panel3";
            panel3.Size = new Size(655, 84);
            panel3.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 33);
            label1.Name = "label1";
            label1.Size = new Size(584, 18);
            label1.TabIndex = 0;
            label1.Text = "HỆ THỐNG ĐIỂM DANH BẰNG NHẬN DẠNG KHUÔN MẶT - DANH SÁCH SINH VIÊN";
            // 
            // ExcelBackUp
            // 
            ExcelBackUp.Location = new Point(147, 3);
            ExcelBackUp.Name = "ExcelBackUp";
            ExcelBackUp.Size = new Size(143, 29);
            ExcelBackUp.TabIndex = 4;
            ExcelBackUp.Text = "Xuất file Excel";
            ExcelBackUp.UseVisualStyleBackColor = true;
            ExcelBackUp.Click += ExcelBackUp_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(694, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 1;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(36, 3);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 0;
            btnReset.Text = "Đặt lại";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnClose);
            panel6.Controls.Add(ExcelBackUp);
            panel6.Controls.Add(btnReset);
            panel6.Location = new Point(0, 493);
            panel6.Name = "panel6";
            panel6.Size = new Size(830, 43);
            panel6.TabIndex = 1;
            // 
            // Student_Entry_Record
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HighlightText;
            ClientSize = new Size(828, 535);
            Controls.Add(panel6);
            Controls.Add(panel1);
            Name = "Student_Entry_Record";
            Text = "Student_Entry_Record";
            Load += frmStudentRecord_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgw).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button3;
        private Button button2;
        private TextBox textBox1;
        private Label label1;
        private Button ExcelBackUp;
        private DataGridView dgw;
        private Button btnClose;
        private Button btnReset;
        private Panel panel6;
        private Panel panel4;
        private TextBox txtStudentName;
        private Label label2;
        private Button btnAddNew;
    }
}
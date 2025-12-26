namespace KYS.NET.STUDY.Forms.Approval
{
  partial class ApprovalRequestForm
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
      gb_info = new GroupBox();
      btn_logout = new Button();
      lbl_welcome = new Label();
      btn_insert = new Button();
      btn_save = new Button();
      btn_delete = new Button();
      btn_reset = new Button();
      btn_retrieve = new Button();
      txtb_title1 = new TextBox();
      txtb_title2 = new TextBox();
      dt_picker1 = new DateTimePicker();
      lbl_wave = new Label();
      gb_utils = new GroupBox();
      dateTimePicker1 = new DateTimePicker();
      cb_dt = new ComboBox();
      cb_search = new ComboBox();
      txtb_search = new TextBox();
      lb_approval = new ListView();
      gb_info.SuspendLayout();
      gb_utils.SuspendLayout();
      SuspendLayout();
      // 
      // gb_info
      // 
      gb_info.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      gb_info.BackColor = SystemColors.InactiveCaption;
      gb_info.Controls.Add(btn_logout);
      gb_info.Controls.Add(lbl_welcome);
      gb_info.Location = new Point(8, 13);
      gb_info.Margin = new Padding(2, 2, 2, 2);
      gb_info.Name = "gb_info";
      gb_info.Padding = new Padding(2, 2, 2, 2);
      gb_info.Size = new Size(812, 38);
      gb_info.TabIndex = 0;
      gb_info.TabStop = false;
      gb_info.Text = "Info";
      // 
      // btn_logout
      // 
      btn_logout.Font = new Font("굴림체", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_logout.Location = new Point(717, 13);
      btn_logout.Margin = new Padding(2, 2, 2, 2);
      btn_logout.Name = "btn_logout";
      btn_logout.Size = new Size(91, 20);
      btn_logout.TabIndex = 0;
      btn_logout.Text = "종료";
      btn_logout.UseVisualStyleBackColor = true;
      btn_logout.Click += btn_logout_Click;
      // 
      // lbl_welcome
      // 
      lbl_welcome.AutoSize = true;
      lbl_welcome.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      lbl_welcome.Location = new Point(13, 16);
      lbl_welcome.Margin = new Padding(2, 0, 2, 0);
      lbl_welcome.Name = "lbl_welcome";
      lbl_welcome.Size = new Size(161, 14);
      lbl_welcome.TabIndex = 0;
      lbl_welcome.Text = "홍길동님 , 환영합니다.";
      // 
      // btn_insert
      // 
      btn_insert.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_insert.Location = new Point(143, 11);
      btn_insert.Margin = new Padding(2, 2, 2, 2);
      btn_insert.Name = "btn_insert";
      btn_insert.Size = new Size(102, 27);
      btn_insert.TabIndex = 0;
      btn_insert.Text = "입력(+)";
      btn_insert.UseVisualStyleBackColor = true;
      // 
      // btn_save
      // 
      btn_save.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_save.Location = new Point(248, 11);
      btn_save.Margin = new Padding(2, 2, 2, 2);
      btn_save.Name = "btn_save";
      btn_save.Size = new Size(102, 27);
      btn_save.TabIndex = 0;
      btn_save.Text = "저장(↓)";
      btn_save.UseVisualStyleBackColor = true;
      // 
      // btn_delete
      // 
      btn_delete.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_delete.Location = new Point(354, 11);
      btn_delete.Margin = new Padding(2, 2, 2, 2);
      btn_delete.Name = "btn_delete";
      btn_delete.Size = new Size(102, 27);
      btn_delete.TabIndex = 0;
      btn_delete.Text = "삭제(X)";
      btn_delete.UseVisualStyleBackColor = true;
      // 
      // btn_reset
      // 
      btn_reset.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_reset.Location = new Point(460, 11);
      btn_reset.Margin = new Padding(2, 2, 2, 2);
      btn_reset.Name = "btn_reset";
      btn_reset.Size = new Size(102, 27);
      btn_reset.TabIndex = 0;
      btn_reset.Text = "초기화";
      btn_reset.UseVisualStyleBackColor = true;
      // 
      // btn_retrieve
      // 
      btn_retrieve.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_retrieve.Location = new Point(37, 11);
      btn_retrieve.Margin = new Padding(2, 2, 2, 2);
      btn_retrieve.Name = "btn_retrieve";
      btn_retrieve.Size = new Size(102, 27);
      btn_retrieve.TabIndex = 0;
      btn_retrieve.Text = "조회(R)";
      btn_retrieve.UseVisualStyleBackColor = true;
      // 
      // txtb_title1
      // 
      txtb_title1.BackColor = SystemColors.MenuText;
      txtb_title1.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point, 129);
      txtb_title1.ForeColor = SystemColors.ButtonFace;
      txtb_title1.Location = new Point(8, 168);
      txtb_title1.Margin = new Padding(2, 2, 2, 2);
      txtb_title1.Name = "txtb_title1";
      txtb_title1.ReadOnly = true;
      txtb_title1.Size = new Size(368, 36);
      txtb_title1.TabIndex = 7;
      txtb_title1.Text = "결재 신청 현황";
      txtb_title1.TextAlign = HorizontalAlignment.Center;
      // 
      // txtb_title2
      // 
      txtb_title2.BackColor = SystemColors.MenuText;
      txtb_title2.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point, 129);
      txtb_title2.ForeColor = SystemColors.ButtonFace;
      txtb_title2.Location = new Point(379, 168);
      txtb_title2.Margin = new Padding(2, 2, 2, 2);
      txtb_title2.Name = "txtb_title2";
      txtb_title2.ReadOnly = true;
      txtb_title2.Size = new Size(442, 36);
      txtb_title2.TabIndex = 8;
      txtb_title2.Text = "결재서 작성";
      txtb_title2.TextAlign = HorizontalAlignment.Center;
      // 
      // dt_picker1
      // 
      dt_picker1.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      dt_picker1.Location = new Point(118, 109);
      dt_picker1.Margin = new Padding(2, 2, 2, 2);
      dt_picker1.Name = "dt_picker1";
      dt_picker1.Size = new Size(198, 23);
      dt_picker1.TabIndex = 1;
      dt_picker1.Value = new DateTime(2025, 12, 1, 0, 0, 0, 0);
      // 
      // lbl_wave
      // 
      lbl_wave.AutoSize = true;
      lbl_wave.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      lbl_wave.Location = new Point(315, 108);
      lbl_wave.Margin = new Padding(2, 0, 2, 0);
      lbl_wave.Name = "lbl_wave";
      lbl_wave.Size = new Size(19, 19);
      lbl_wave.TabIndex = 0;
      lbl_wave.Text = "~";
      // 
      // gb_utils
      // 
      gb_utils.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      gb_utils.BackColor = SystemColors.InactiveCaption;
      gb_utils.Controls.Add(btn_delete);
      gb_utils.Controls.Add(btn_insert);
      gb_utils.Controls.Add(btn_save);
      gb_utils.Controls.Add(btn_reset);
      gb_utils.Controls.Add(btn_retrieve);
      gb_utils.Location = new Point(8, 54);
      gb_utils.Margin = new Padding(2, 2, 2, 2);
      gb_utils.Name = "gb_utils";
      gb_utils.Padding = new Padding(2, 2, 2, 2);
      gb_utils.Size = new Size(812, 43);
      gb_utils.TabIndex = 2;
      gb_utils.TabStop = false;
      gb_utils.Text = "Utils";
      // 
      // dateTimePicker1
      // 
      dateTimePicker1.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      dateTimePicker1.Location = new Point(332, 109);
      dateTimePicker1.Margin = new Padding(2, 2, 2, 2);
      dateTimePicker1.Name = "dateTimePicker1";
      dateTimePicker1.Size = new Size(198, 23);
      dateTimePicker1.TabIndex = 2;
      dateTimePicker1.Value = new DateTime(2025, 12, 25, 12, 6, 13, 0);
      // 
      // cb_dt
      // 
      cb_dt.BackColor = SystemColors.Info;
      cb_dt.FormattingEnabled = true;
      cb_dt.Items.AddRange(new object[] { "신청일자", "완료일자" });
      cb_dt.Location = new Point(8, 108);
      cb_dt.Margin = new Padding(2, 2, 2, 2);
      cb_dt.Name = "cb_dt";
      cb_dt.Size = new Size(105, 23);
      cb_dt.Sorted = true;
      cb_dt.TabIndex = 0;
      // 
      // cb_search
      // 
      cb_search.BackColor = SystemColors.Info;
      cb_search.FormattingEnabled = true;
      cb_search.Items.AddRange(new object[] { "내용", "전체", "제목", "제목+내용" });
      cb_search.Location = new Point(8, 131);
      cb_search.Margin = new Padding(2, 2, 2, 2);
      cb_search.Name = "cb_search";
      cb_search.Size = new Size(105, 23);
      cb_search.Sorted = true;
      cb_search.TabIndex = 0;
      // 
      // txtb_search
      // 
      txtb_search.Location = new Point(118, 133);
      txtb_search.Margin = new Padding(2, 2, 2, 2);
      txtb_search.Name = "txtb_search";
      txtb_search.Size = new Size(413, 23);
      txtb_search.TabIndex = 3;
      // 
      // lb_approval
      // 
      lb_approval.Location = new Point(8, 203);
      lb_approval.Margin = new Padding(2, 2, 2, 2);
      lb_approval.Name = "lb_approval";
      lb_approval.Size = new Size(368, 536);
      lb_approval.TabIndex = 13;
      lb_approval.UseCompatibleStateImageBehavior = false;
      // 
      // ApprovalRequestForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(829, 744);
      Controls.Add(lb_approval);
      Controls.Add(txtb_search);
      Controls.Add(cb_search);
      Controls.Add(cb_dt);
      Controls.Add(dateTimePicker1);
      Controls.Add(gb_utils);
      Controls.Add(lbl_wave);
      Controls.Add(dt_picker1);
      Controls.Add(txtb_title2);
      Controls.Add(txtb_title1);
      Controls.Add(gb_info);
      Margin = new Padding(2, 2, 2, 2);
      Name = "ApprovalRequestForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "ApprovalRequestForm";
      gb_info.ResumeLayout(false);
      gb_info.PerformLayout();
      gb_utils.ResumeLayout(false);
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private GroupBox gb_info;
    private Label lbl_welcome;
    private Button btn_logout;
    private Button btn_insert;
    private Button btn_save;
    private Button btn_delete;
    private Button btn_reset;
    private Button btn_retrieve;
    private TextBox txtb_title1;
    private TextBox txtb_title2;
    private DateTimePicker dt_picker1;
    private Label lbl_wave;
    private GroupBox gb_utils;
    private DateTimePicker dateTimePicker1;
    private ComboBox cb_dt;
    private ComboBox cb_search;
    private TextBox txtb_search;
    private ListView lb_approval;
  }
}
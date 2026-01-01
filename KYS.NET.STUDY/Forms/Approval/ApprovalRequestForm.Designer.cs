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
      lv_approval = new ListView();
      lbl_enrolldt = new Label();
      txtb_enrolldt = new TextBox();
      cb_docdiv = new ComboBox();
      lbl_docdiv = new Label();
      lbl_doctitle = new Label();
      txtb_doctitle = new TextBox();
      txtb_doccontent = new RichTextBox();
      lbl_doccontent = new Label();
      lbl_docfilenm = new Label();
      txtb_docfilenm = new TextBox();
      btn_fileupload = new Button();
      lbl_updatedt = new Label();
      txtb_updatedt = new TextBox();
      lbl_comment = new Label();
      txtb_comment = new RichTextBox();
      txtb_docno = new TextBox();
      gb_info.SuspendLayout();
      gb_utils.SuspendLayout();
      SuspendLayout();
      // 
      // gb_info
      // 
      gb_info.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      gb_info.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      gb_info.BackColor = SystemColors.InactiveCaption;
      gb_info.Controls.Add(btn_logout);
      gb_info.Controls.Add(lbl_welcome);
      gb_info.FlatStyle = FlatStyle.Flat;
      gb_info.Location = new Point(11, 22);
      gb_info.Name = "gb_info";
      gb_info.Size = new Size(1229, 63);
      gb_info.TabIndex = 0;
      gb_info.TabStop = false;
      gb_info.Text = "Info";
      // 
      // btn_logout
      // 
      btn_logout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      btn_logout.Font = new Font("굴림체", 9F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_logout.Location = new Point(1091, 22);
      btn_logout.Name = "btn_logout";
      btn_logout.Size = new Size(130, 33);
      btn_logout.TabIndex = 0;
      btn_logout.Text = "종료";
      btn_logout.UseVisualStyleBackColor = true;
      btn_logout.Click += btn_logout_Click;
      // 
      // lbl_welcome
      // 
      lbl_welcome.AutoSize = true;
      lbl_welcome.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      lbl_welcome.Location = new Point(19, 27);
      lbl_welcome.Name = "lbl_welcome";
      lbl_welcome.Size = new Size(229, 20);
      lbl_welcome.TabIndex = 0;
      lbl_welcome.Text = "홍길동님 , 환영합니다.";
      // 
      // btn_insert
      // 
      btn_insert.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_insert.Location = new Point(204, 18);
      btn_insert.Name = "btn_insert";
      btn_insert.Size = new Size(146, 45);
      btn_insert.TabIndex = 0;
      btn_insert.Text = "입력(+)";
      btn_insert.UseVisualStyleBackColor = true;
      // 
      // btn_save
      // 
      btn_save.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_save.Location = new Point(354, 18);
      btn_save.Name = "btn_save";
      btn_save.Size = new Size(146, 45);
      btn_save.TabIndex = 0;
      btn_save.Text = "저장(↓)";
      btn_save.UseVisualStyleBackColor = true;
      btn_save.Click += btn_save_Click;
      // 
      // btn_delete
      // 
      btn_delete.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_delete.Location = new Point(506, 18);
      btn_delete.Name = "btn_delete";
      btn_delete.Size = new Size(146, 45);
      btn_delete.TabIndex = 0;
      btn_delete.Text = "삭제(X)";
      btn_delete.UseVisualStyleBackColor = true;
      // 
      // btn_reset
      // 
      btn_reset.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_reset.Location = new Point(657, 18);
      btn_reset.Name = "btn_reset";
      btn_reset.Size = new Size(146, 45);
      btn_reset.TabIndex = 0;
      btn_reset.Text = "초기화";
      btn_reset.UseVisualStyleBackColor = true;
      // 
      // btn_retrieve
      // 
      btn_retrieve.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_retrieve.Location = new Point(53, 18);
      btn_retrieve.Name = "btn_retrieve";
      btn_retrieve.Size = new Size(146, 45);
      btn_retrieve.TabIndex = 0;
      btn_retrieve.Text = "조회(R)";
      btn_retrieve.UseVisualStyleBackColor = true;
      // 
      // txtb_title1
      // 
      txtb_title1.BackColor = SystemColors.MenuText;
      txtb_title1.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point, 129);
      txtb_title1.ForeColor = SystemColors.ButtonFace;
      txtb_title1.Location = new Point(11, 280);
      txtb_title1.Name = "txtb_title1";
      txtb_title1.ReadOnly = true;
      txtb_title1.Size = new Size(524, 50);
      txtb_title1.TabIndex = 7;
      txtb_title1.Text = "결재 신청 현황";
      txtb_title1.TextAlign = HorizontalAlignment.Center;
      // 
      // txtb_title2
      // 
      txtb_title2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      txtb_title2.BackColor = SystemColors.MenuText;
      txtb_title2.Font = new Font("맑은 고딕", 16F, FontStyle.Regular, GraphicsUnit.Point, 129);
      txtb_title2.ForeColor = SystemColors.ButtonFace;
      txtb_title2.Location = new Point(541, 280);
      txtb_title2.Name = "txtb_title2";
      txtb_title2.ReadOnly = true;
      txtb_title2.Size = new Size(698, 50);
      txtb_title2.TabIndex = 8;
      txtb_title2.Text = "결재서 작성";
      txtb_title2.TextAlign = HorizontalAlignment.Center;
      // 
      // dt_picker1
      // 
      dt_picker1.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      dt_picker1.Location = new Point(169, 182);
      dt_picker1.Name = "dt_picker1";
      dt_picker1.Size = new Size(281, 30);
      dt_picker1.TabIndex = 1;
      dt_picker1.Value = new DateTime(2025, 12, 1, 0, 0, 0, 0);
      // 
      // lbl_wave
      // 
      lbl_wave.AutoSize = true;
      lbl_wave.Font = new Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      lbl_wave.Location = new Point(450, 180);
      lbl_wave.Name = "lbl_wave";
      lbl_wave.Size = new Size(26, 28);
      lbl_wave.TabIndex = 0;
      lbl_wave.Text = "~";
      // 
      // gb_utils
      // 
      gb_utils.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      gb_utils.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      gb_utils.BackColor = SystemColors.InactiveCaption;
      gb_utils.Controls.Add(btn_delete);
      gb_utils.Controls.Add(btn_insert);
      gb_utils.Controls.Add(btn_save);
      gb_utils.Controls.Add(btn_reset);
      gb_utils.Controls.Add(btn_retrieve);
      gb_utils.Location = new Point(11, 90);
      gb_utils.Name = "gb_utils";
      gb_utils.Size = new Size(1229, 72);
      gb_utils.TabIndex = 2;
      gb_utils.TabStop = false;
      gb_utils.Text = "Utils";
      // 
      // dateTimePicker1
      // 
      dateTimePicker1.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      dateTimePicker1.Location = new Point(474, 182);
      dateTimePicker1.Name = "dateTimePicker1";
      dateTimePicker1.Size = new Size(281, 30);
      dateTimePicker1.TabIndex = 2;
      dateTimePicker1.Value = new DateTime(2025, 12, 25, 12, 6, 13, 0);
      // 
      // cb_dt
      // 
      cb_dt.BackColor = SystemColors.Info;
      cb_dt.DropDownStyle = ComboBoxStyle.DropDownList;
      cb_dt.ForeColor = Color.Black;
      cb_dt.FormattingEnabled = true;
      cb_dt.Location = new Point(11, 180);
      cb_dt.Name = "cb_dt";
      cb_dt.Size = new Size(148, 33);
      cb_dt.Sorted = true;
      cb_dt.TabIndex = 0;
      cb_dt.TabStop = false;
      // 
      // cb_search
      // 
      cb_search.BackColor = SystemColors.Info;
      cb_search.DropDownStyle = ComboBoxStyle.DropDownList;
      cb_search.ForeColor = Color.Black;
      cb_search.FormattingEnabled = true;
      cb_search.Location = new Point(11, 218);
      cb_search.Name = "cb_search";
      cb_search.Size = new Size(148, 33);
      cb_search.Sorted = true;
      cb_search.TabIndex = 0;
      // 
      // txtb_search
      // 
      txtb_search.ForeColor = Color.Black;
      txtb_search.Location = new Point(169, 222);
      txtb_search.Name = "txtb_search";
      txtb_search.Size = new Size(587, 31);
      txtb_search.TabIndex = 1;
      // 
      // lv_approval
      // 
      lv_approval.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      lv_approval.Location = new Point(11, 343);
      lv_approval.MultiSelect = false;
      lv_approval.Name = "lv_approval";
      lv_approval.Size = new Size(524, 886);
      lv_approval.TabIndex = 13;
      lv_approval.UseCompatibleStateImageBehavior = false;
      // 
      // lbl_enrolldt
      // 
      lbl_enrolldt.AutoSize = true;
      lbl_enrolldt.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_enrolldt.ForeColor = Color.Black;
      lbl_enrolldt.Location = new Point(546, 348);
      lbl_enrolldt.Name = "lbl_enrolldt";
      lbl_enrolldt.Size = new Size(115, 20);
      lbl_enrolldt.TabIndex = 14;
      lbl_enrolldt.Text = "접수일자 :";
      // 
      // txtb_enrolldt
      // 
      txtb_enrolldt.BackColor = SystemColors.ScrollBar;
      txtb_enrolldt.Font = new Font("굴림체", 10F);
      txtb_enrolldt.ForeColor = Color.Black;
      txtb_enrolldt.Location = new Point(673, 343);
      txtb_enrolldt.Name = "txtb_enrolldt";
      txtb_enrolldt.ReadOnly = true;
      txtb_enrolldt.Size = new Size(238, 30);
      txtb_enrolldt.TabIndex = 15;
      // 
      // cb_docdiv
      // 
      cb_docdiv.BackColor = SystemColors.Info;
      cb_docdiv.DropDownStyle = ComboBoxStyle.DropDownList;
      cb_docdiv.Font = new Font("굴림체", 10F);
      cb_docdiv.ForeColor = Color.Black;
      cb_docdiv.FormattingEnabled = true;
      cb_docdiv.Location = new Point(673, 397);
      cb_docdiv.Name = "cb_docdiv";
      cb_docdiv.Size = new Size(238, 28);
      cb_docdiv.Sorted = true;
      cb_docdiv.TabIndex = 16;
      cb_docdiv.TabStop = false;
      // 
      // lbl_docdiv
      // 
      lbl_docdiv.AutoSize = true;
      lbl_docdiv.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_docdiv.ForeColor = Color.Black;
      lbl_docdiv.Location = new Point(546, 400);
      lbl_docdiv.Name = "lbl_docdiv";
      lbl_docdiv.Size = new Size(115, 20);
      lbl_docdiv.TabIndex = 17;
      lbl_docdiv.Text = "문서구분 :";
      // 
      // lbl_doctitle
      // 
      lbl_doctitle.AutoSize = true;
      lbl_doctitle.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_doctitle.ForeColor = Color.Black;
      lbl_doctitle.Location = new Point(546, 452);
      lbl_doctitle.Name = "lbl_doctitle";
      lbl_doctitle.Size = new Size(115, 20);
      lbl_doctitle.TabIndex = 18;
      lbl_doctitle.Text = "문서제목 :";
      // 
      // txtb_doctitle
      // 
      txtb_doctitle.Font = new Font("굴림체", 10F);
      txtb_doctitle.ForeColor = Color.Black;
      txtb_doctitle.Location = new Point(673, 448);
      txtb_doctitle.Name = "txtb_doctitle";
      txtb_doctitle.Size = new Size(560, 30);
      txtb_doctitle.TabIndex = 19;
      // 
      // txtb_doccontent
      // 
      txtb_doccontent.DetectUrls = false;
      txtb_doccontent.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      txtb_doccontent.ForeColor = Color.Black;
      txtb_doccontent.HideSelection = false;
      txtb_doccontent.Location = new Point(673, 498);
      txtb_doccontent.Name = "txtb_doccontent";
      txtb_doccontent.Size = new Size(560, 411);
      txtb_doccontent.TabIndex = 20;
      txtb_doccontent.Text = "";
      // 
      // lbl_doccontent
      // 
      lbl_doccontent.AutoSize = true;
      lbl_doccontent.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_doccontent.ForeColor = Color.Black;
      lbl_doccontent.Location = new Point(546, 503);
      lbl_doccontent.Name = "lbl_doccontent";
      lbl_doccontent.Size = new Size(115, 20);
      lbl_doccontent.TabIndex = 21;
      lbl_doccontent.Text = "문서내용 :";
      // 
      // lbl_docfilenm
      // 
      lbl_docfilenm.AutoSize = true;
      lbl_docfilenm.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_docfilenm.ForeColor = Color.Black;
      lbl_docfilenm.Location = new Point(546, 928);
      lbl_docfilenm.Name = "lbl_docfilenm";
      lbl_docfilenm.Size = new Size(115, 20);
      lbl_docfilenm.TabIndex = 22;
      lbl_docfilenm.Text = "첨부파일 :";
      // 
      // txtb_docfilenm
      // 
      txtb_docfilenm.BackColor = SystemColors.ScrollBar;
      txtb_docfilenm.Font = new Font("굴림체", 10F);
      txtb_docfilenm.ForeColor = Color.Black;
      txtb_docfilenm.Location = new Point(669, 925);
      txtb_docfilenm.Name = "txtb_docfilenm";
      txtb_docfilenm.ReadOnly = true;
      txtb_docfilenm.Size = new Size(457, 30);
      txtb_docfilenm.TabIndex = 23;
      // 
      // btn_fileupload
      // 
      btn_fileupload.Cursor = Cursors.Hand;
      btn_fileupload.FlatAppearance.BorderSize = 2;
      btn_fileupload.Location = new Point(1131, 923);
      btn_fileupload.Name = "btn_fileupload";
      btn_fileupload.Size = new Size(46, 33);
      btn_fileupload.TabIndex = 25;
      btn_fileupload.Text = "▲";
      btn_fileupload.UseVisualStyleBackColor = true;
      // 
      // lbl_updatedt
      // 
      lbl_updatedt.AutoSize = true;
      lbl_updatedt.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_updatedt.ForeColor = Color.Black;
      lbl_updatedt.Location = new Point(546, 975);
      lbl_updatedt.Name = "lbl_updatedt";
      lbl_updatedt.Size = new Size(126, 20);
      lbl_updatedt.TabIndex = 26;
      lbl_updatedt.Text = "수정일자 : ";
      // 
      // txtb_updatedt
      // 
      txtb_updatedt.BackColor = SystemColors.ScrollBar;
      txtb_updatedt.Font = new Font("굴림체", 10F);
      txtb_updatedt.ForeColor = Color.Black;
      txtb_updatedt.Location = new Point(669, 972);
      txtb_updatedt.Name = "txtb_updatedt";
      txtb_updatedt.ReadOnly = true;
      txtb_updatedt.Size = new Size(238, 30);
      txtb_updatedt.TabIndex = 27;
      // 
      // lbl_comment
      // 
      lbl_comment.AutoSize = true;
      lbl_comment.Font = new Font("굴림체", 10F, FontStyle.Bold);
      lbl_comment.ForeColor = Color.Black;
      lbl_comment.Location = new Point(546, 1022);
      lbl_comment.Name = "lbl_comment";
      lbl_comment.Size = new Size(119, 20);
      lbl_comment.TabIndex = 28;
      lbl_comment.Text = "Comment  :";
      // 
      // txtb_comment
      // 
      txtb_comment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      txtb_comment.BackColor = SystemColors.ScrollBar;
      txtb_comment.Font = new Font("굴림체", 10F, FontStyle.Regular, GraphicsUnit.Point, 129);
      txtb_comment.ForeColor = Color.Black;
      txtb_comment.Location = new Point(669, 1022);
      txtb_comment.Name = "txtb_comment";
      txtb_comment.ReadOnly = true;
      txtb_comment.Size = new Size(565, 207);
      txtb_comment.TabIndex = 29;
      txtb_comment.Text = "";
      // 
      // txtb_docno
      // 
      txtb_docno.BackColor = SystemColors.ScrollBar;
      txtb_docno.Font = new Font("굴림체", 10F);
      txtb_docno.ForeColor = Color.Black;
      txtb_docno.Location = new Point(925, 343);
      txtb_docno.Name = "txtb_docno";
      txtb_docno.ReadOnly = true;
      txtb_docno.Size = new Size(309, 30);
      txtb_docno.TabIndex = 30;
      // 
      // ApprovalRequestForm
      // 
      AutoScaleDimensions = new SizeF(10F, 25F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1251, 1250);
      Controls.Add(txtb_docno);
      Controls.Add(txtb_comment);
      Controls.Add(lbl_comment);
      Controls.Add(txtb_updatedt);
      Controls.Add(lbl_updatedt);
      Controls.Add(btn_fileupload);
      Controls.Add(txtb_docfilenm);
      Controls.Add(lbl_docfilenm);
      Controls.Add(lbl_doccontent);
      Controls.Add(txtb_doccontent);
      Controls.Add(txtb_doctitle);
      Controls.Add(lbl_doctitle);
      Controls.Add(lbl_docdiv);
      Controls.Add(cb_docdiv);
      Controls.Add(txtb_enrolldt);
      Controls.Add(lbl_enrolldt);
      Controls.Add(lv_approval);
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
      Name = "ApprovalRequestForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "결재서 작성 프로그램";
      Load += ApprovalRequestForm_Load;
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
    private ListView lv_approval;
    private Label lbl_enrolldt;
    private TextBox txtb_enrolldt;
    private ComboBox cb_docdiv;
    private Label lbl_docdiv;
    private Label lbl_doctitle;
    private TextBox txtb_doctitle;
    private RichTextBox txtb_doccontent;
    private Label lbl_doccontent;
    private Label lbl_docfilenm;
    private TextBox txtb_docfilenm;
    private Button btn_fileupload;
    private Label lbl_updatedt;
    private TextBox txtb_updatedt;
    private Label lbl_comment;
    private RichTextBox txtb_comment;
    private TextBox txtb_docno;
  }
}
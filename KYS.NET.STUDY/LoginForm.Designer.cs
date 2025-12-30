namespace KYS.NET.STUDY
{
  partial class LoginForm
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      lbl_id = new Label();
      lbl_pw = new Label();
      txtb_id = new TextBox();
      txtb_pw = new TextBox();
      lbl_title = new Label();
      btn_login = new Button();
      SuspendLayout();
      // 
      // lbl_id
      // 
      lbl_id.AutoSize = true;
      lbl_id.Location = new Point(181, 138);
      lbl_id.Name = "lbl_id";
      lbl_id.Size = new Size(47, 16);
      lbl_id.TabIndex = 0;
      lbl_id.Text = "ID : ";
      // 
      // lbl_pw
      // 
      lbl_pw.AutoSize = true;
      lbl_pw.Location = new Point(181, 198);
      lbl_pw.Name = "lbl_pw";
      lbl_pw.Size = new Size(47, 16);
      lbl_pw.TabIndex = 1;
      lbl_pw.Text = "PW : ";
      // 
      // txtb_id
      // 
      txtb_id.Location = new Point(245, 133);
      txtb_id.Name = "txtb_id";
      txtb_id.Size = new Size(295, 26);
      txtb_id.TabIndex = 1;
      // 
      // txtb_pw
      // 
      txtb_pw.Location = new Point(245, 193);
      txtb_pw.Name = "txtb_pw";
      txtb_pw.PasswordChar = '*';
      txtb_pw.Size = new Size(295, 26);
      txtb_pw.TabIndex = 3;
      txtb_pw.KeyDown += txtb_pw_KeyDown;
      // 
      // lbl_title
      // 
      lbl_title.AutoSize = true;
      lbl_title.Font = new Font("굴림체", 14F, FontStyle.Regular, GraphicsUnit.Point, 129);
      lbl_title.Location = new Point(175, 62);
      lbl_title.Name = "lbl_title";
      lbl_title.Size = new Size(279, 19);
      lbl_title.TabIndex = 4;
      lbl_title.Text = "전자결재 작성 신청 프로그램";
      // 
      // btn_login
      // 
      btn_login.Font = new Font("굴림체", 14F, FontStyle.Regular, GraphicsUnit.Point, 129);
      btn_login.Location = new Point(190, 269);
      btn_login.Name = "btn_login";
      btn_login.Size = new Size(360, 60);
      btn_login.TabIndex = 5;
      btn_login.Text = "로그인";
      btn_login.UseVisualStyleBackColor = true;
      btn_login.Click += Btn_login_Click;
      // 
      // LoginForm
      // 
      AutoScaleDimensions = new SizeF(8F, 16F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(756, 393);
      Controls.Add(btn_login);
      Controls.Add(lbl_title);
      Controls.Add(txtb_pw);
      Controls.Add(txtb_id);
      Controls.Add(lbl_pw);
      Controls.Add(lbl_id);
      Font = new Font("굴림체", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
      FormBorderStyle = FormBorderStyle.Fixed3D;
      Margin = new Padding(4, 5, 4, 5);
      Name = "LoginForm";
      ShowIcon = false;
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Form1";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label lbl_id;
    private Label lbl_pw;
    private TextBox txtb_id;
    private TextBox txtb_pw;
    private Label lbl_title;
    private Button btn_login;
  }
}
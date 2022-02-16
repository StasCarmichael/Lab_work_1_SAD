
namespace PL
{
    partial class CreationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreationForm));
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.buttonAddNewUser = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonNewBankCard = new System.Windows.Forms.Button();
            this.radioButtonPrivateBank = new System.Windows.Forms.RadioButton();
            this.radioButtonMonoBank = new System.Windows.Forms.RadioButton();
            this.buttonNewInsurmcePolicy = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGoBack.Location = new System.Drawing.Point(139, 371);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(175, 56);
            this.buttonGoBack.TabIndex = 0;
            this.buttonGoBack.Text = "Back to main form";
            this.buttonGoBack.UseVisualStyleBackColor = false;
            this.buttonGoBack.Click += new System.EventHandler(this.buttonGoBack_Click);
            // 
            // buttonAddNewUser
            // 
            this.buttonAddNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAddNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddNewUser.Location = new System.Drawing.Point(129, 145);
            this.buttonAddNewUser.Name = "buttonAddNewUser";
            this.buttonAddNewUser.Size = new System.Drawing.Size(218, 39);
            this.buttonAddNewUser.TabIndex = 23;
            this.buttonAddNewUser.Text = "Create new User";
            this.buttonAddNewUser.UseVisualStyleBackColor = false;
            this.buttonAddNewUser.Click += new System.EventHandler(this.buttonAddNewUser_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(13, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 20);
            this.label18.TabIndex = 22;
            this.label18.Text = "Date of birth";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSurname.Location = new System.Drawing.Point(129, 65);
            this.textBoxSurname.MaxLength = 50;
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(249, 27);
            this.textBoxSurname.TabIndex = 21;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker.Location = new System.Drawing.Point(129, 101);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(249, 24);
            this.dateTimePicker.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(42, 68);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 20);
            this.label16.TabIndex = 20;
            this.label16.Text = "Surname";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(68, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 20);
            this.label17.TabIndex = 19;
            this.label17.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.Location = new System.Drawing.Point(129, 29);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(249, 27);
            this.textBoxName.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.buttonNewBankCard);
            this.groupBox4.Controls.Add(this.radioButtonPrivateBank);
            this.groupBox4.Controls.Add(this.radioButtonMonoBank);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(46, 201);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 99);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bank Card Creator";
            // 
            // buttonNewBankCard
            // 
            this.buttonNewBankCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonNewBankCard.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewBankCard.Location = new System.Drawing.Point(201, 31);
            this.buttonNewBankCard.Name = "buttonNewBankCard";
            this.buttonNewBankCard.Size = new System.Drawing.Size(145, 59);
            this.buttonNewBankCard.TabIndex = 21;
            this.buttonNewBankCard.Text = "Create Bank Card";
            this.buttonNewBankCard.UseVisualStyleBackColor = false;
            this.buttonNewBankCard.Click += new System.EventHandler(this.buttonNewBankCard_Click);
            // 
            // radioButtonPrivateBank
            // 
            this.radioButtonPrivateBank.AutoSize = true;
            this.radioButtonPrivateBank.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonPrivateBank.Location = new System.Drawing.Point(14, 63);
            this.radioButtonPrivateBank.Name = "radioButtonPrivateBank";
            this.radioButtonPrivateBank.Size = new System.Drawing.Size(138, 24);
            this.radioButtonPrivateBank.TabIndex = 1;
            this.radioButtonPrivateBank.Text = "Private Bank";
            this.radioButtonPrivateBank.UseVisualStyleBackColor = true;
            // 
            // radioButtonMonoBank
            // 
            this.radioButtonMonoBank.AutoSize = true;
            this.radioButtonMonoBank.Checked = true;
            this.radioButtonMonoBank.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonMonoBank.Location = new System.Drawing.Point(14, 31);
            this.radioButtonMonoBank.Name = "radioButtonMonoBank";
            this.radioButtonMonoBank.Size = new System.Drawing.Size(121, 24);
            this.radioButtonMonoBank.TabIndex = 0;
            this.radioButtonMonoBank.TabStop = true;
            this.radioButtonMonoBank.Text = "Mono Bank";
            this.radioButtonMonoBank.UseVisualStyleBackColor = true;
            // 
            // buttonNewInsurmcePolicy
            // 
            this.buttonNewInsurmcePolicy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonNewInsurmcePolicy.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonNewInsurmcePolicy.Location = new System.Drawing.Point(72, 306);
            this.buttonNewInsurmcePolicy.Name = "buttonNewInsurmcePolicy";
            this.buttonNewInsurmcePolicy.Size = new System.Drawing.Size(308, 40);
            this.buttonNewInsurmcePolicy.TabIndex = 27;
            this.buttonNewInsurmcePolicy.Text = "Create Insurmce Policy";
            this.buttonNewInsurmcePolicy.UseVisualStyleBackColor = false;
            this.buttonNewInsurmcePolicy.Click += new System.EventHandler(this.buttonNewInsurmcePolicy_Click);
            // 
            // CreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 441);
            this.Controls.Add(this.buttonNewInsurmcePolicy);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonAddNewUser);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonGoBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(460, 480);
            this.MinimumSize = new System.Drawing.Size(460, 480);
            this.Name = "CreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creator Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreationForm_FormClosing);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGoBack;
        private System.Windows.Forms.Button buttonAddNewUser;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonNewBankCard;
        private System.Windows.Forms.RadioButton radioButtonPrivateBank;
        private System.Windows.Forms.RadioButton radioButtonMonoBank;
        private System.Windows.Forms.Button buttonNewInsurmcePolicy;
    }
}
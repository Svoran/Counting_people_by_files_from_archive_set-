namespace Подсчет_людей_по_файлам_из_множества_архивов
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.BTN_Open_and_Count = new System.Windows.Forms.Button();
			this.Result_rtb = new System.Windows.Forms.RichTextBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// BTN_Open_and_Count
			// 
			this.BTN_Open_and_Count.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.BTN_Open_and_Count.Location = new System.Drawing.Point(14, 15);
			this.BTN_Open_and_Count.Name = "BTN_Open_and_Count";
			this.BTN_Open_and_Count.Size = new System.Drawing.Size(145, 61);
			this.BTN_Open_and_Count.TabIndex = 0;
			this.BTN_Open_and_Count.Text = "Выбрать архивы";
			this.BTN_Open_and_Count.UseVisualStyleBackColor = true;
			this.BTN_Open_and_Count.Click += new System.EventHandler(this.BTN_Open_and_Count_Click);
			// 
			// Result_rtb
			// 
			this.Result_rtb.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Result_rtb.Location = new System.Drawing.Point(171, 17);
			this.Result_rtb.Name = "Result_rtb";
			this.Result_rtb.Size = new System.Drawing.Size(619, 421);
			this.Result_rtb.TabIndex = 1;
			this.Result_rtb.Text = "";
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Result_rtb);
			this.Controls.Add(this.BTN_Open_and_Count);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button BTN_Open_and_Count;
		private System.Windows.Forms.RichTextBox Result_rtb;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
	}
}


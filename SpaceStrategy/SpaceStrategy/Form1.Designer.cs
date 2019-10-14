namespace SpaceStrategy
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
            this.PlanetButton = new System.Windows.Forms.Button();
            this.PlanetsInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RemovePlanetButton = new System.Windows.Forms.Button();
            this.PlanetsSelectList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PlanetButton
            // 
            this.PlanetButton.Location = new System.Drawing.Point(56, 347);
            this.PlanetButton.Name = "PlanetButton";
            this.PlanetButton.Size = new System.Drawing.Size(118, 23);
            this.PlanetButton.TabIndex = 0;
            this.PlanetButton.Text = "Create Planet";
            this.PlanetButton.UseVisualStyleBackColor = true;
            this.PlanetButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlanetsInput
            // 
            this.PlanetsInput.Location = new System.Drawing.Point(12, 319);
            this.PlanetsInput.Name = "PlanetsInput";
            this.PlanetsInput.Size = new System.Drawing.Size(213, 22);
            this.PlanetsInput.TabIndex = 1;
            this.PlanetsInput.TextChanged += new System.EventHandler(this.PlanetsInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 400);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // RemovePlanetButton
            // 
            this.RemovePlanetButton.Location = new System.Drawing.Point(56, 376);
            this.RemovePlanetButton.Name = "RemovePlanetButton";
            this.RemovePlanetButton.Size = new System.Drawing.Size(118, 23);
            this.RemovePlanetButton.TabIndex = 6;
            this.RemovePlanetButton.Text = "Remove Planet";
            this.RemovePlanetButton.UseVisualStyleBackColor = true;
            this.RemovePlanetButton.Click += new System.EventHandler(this.RemovePlanetButton_Click);
            // 
            // PlanetsSelectList
            // 
            this.PlanetsSelectList.FormattingEnabled = true;
            this.PlanetsSelectList.ItemHeight = 16;
            this.PlanetsSelectList.Location = new System.Drawing.Point(12, 27);
            this.PlanetsSelectList.Name = "PlanetsSelectList";
            this.PlanetsSelectList.Size = new System.Drawing.Size(213, 260);
            this.PlanetsSelectList.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 448);
            this.Controls.Add(this.PlanetsSelectList);
            this.Controls.Add(this.RemovePlanetButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlanetsInput);
            this.Controls.Add(this.PlanetButton);
            this.Name = "Form1";
            this.Text = "Space Strategy";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PlanetButton;
        private System.Windows.Forms.TextBox PlanetsInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RemovePlanetButton;
        private System.Windows.Forms.ListBox PlanetsSelectList;
    }
}


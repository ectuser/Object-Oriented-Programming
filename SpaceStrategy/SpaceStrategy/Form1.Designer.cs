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
            this.StatusBar = new System.Windows.Forms.Label();
            this.RemovePlanetButton = new System.Windows.Forms.Button();
            this.PlanetsSelectList = new System.Windows.Forms.ListBox();
            this.ColoniesSelectList = new System.Windows.Forms.ListBox();
            this.ColonyInput = new System.Windows.Forms.TextBox();
            this.CreateColonyButton = new System.Windows.Forms.Button();
            this.RemoveColonyButton = new System.Windows.Forms.Button();
            this.BuildingsSelectList = new System.Windows.Forms.ListBox();
            this.BuildingInput = new System.Windows.Forms.TextBox();
            this.CreateBuildingButton = new System.Windows.Forms.Button();
            this.RemoveBuildingButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlanetButton
            // 
            this.PlanetButton.Location = new System.Drawing.Point(12, 347);
            this.PlanetButton.Name = "PlanetButton";
            this.PlanetButton.Size = new System.Drawing.Size(213, 23);
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
            // StatusBar
            // 
            this.StatusBar.AutoSize = true;
            this.StatusBar.Location = new System.Drawing.Point(91, 400);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(48, 17);
            this.StatusBar.TabIndex = 5;
            this.StatusBar.Text = "Status";
            this.StatusBar.Click += new System.EventHandler(this.label1_Click);
            // 
            // RemovePlanetButton
            // 
            this.RemovePlanetButton.Location = new System.Drawing.Point(12, 376);
            this.RemovePlanetButton.Name = "RemovePlanetButton";
            this.RemovePlanetButton.Size = new System.Drawing.Size(213, 23);
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
            this.PlanetsSelectList.SelectedIndexChanged += new System.EventHandler(this.PlanetsSelectList_SelectedIndexChanged);
            // 
            // ColoniesSelectList
            // 
            this.ColoniesSelectList.FormattingEnabled = true;
            this.ColoniesSelectList.ItemHeight = 16;
            this.ColoniesSelectList.Location = new System.Drawing.Point(265, 27);
            this.ColoniesSelectList.Name = "ColoniesSelectList";
            this.ColoniesSelectList.Size = new System.Drawing.Size(213, 260);
            this.ColoniesSelectList.TabIndex = 8;
            this.ColoniesSelectList.SelectedIndexChanged += new System.EventHandler(this.ColoniesSelectList_SelectedIndexChanged);
            // 
            // ColonyInput
            // 
            this.ColonyInput.Location = new System.Drawing.Point(265, 319);
            this.ColonyInput.Name = "ColonyInput";
            this.ColonyInput.Size = new System.Drawing.Size(213, 22);
            this.ColonyInput.TabIndex = 9;
            // 
            // CreateColonyButton
            // 
            this.CreateColonyButton.Location = new System.Drawing.Point(265, 347);
            this.CreateColonyButton.Name = "CreateColonyButton";
            this.CreateColonyButton.Size = new System.Drawing.Size(213, 23);
            this.CreateColonyButton.TabIndex = 10;
            this.CreateColonyButton.Text = "Create Colony";
            this.CreateColonyButton.UseVisualStyleBackColor = true;
            this.CreateColonyButton.Click += new System.EventHandler(this.CreateColonyButton_Click);
            // 
            // RemoveColonyButton
            // 
            this.RemoveColonyButton.Location = new System.Drawing.Point(265, 376);
            this.RemoveColonyButton.Name = "RemoveColonyButton";
            this.RemoveColonyButton.Size = new System.Drawing.Size(213, 23);
            this.RemoveColonyButton.TabIndex = 11;
            this.RemoveColonyButton.Text = "Remove Colony";
            this.RemoveColonyButton.UseVisualStyleBackColor = true;
            this.RemoveColonyButton.Click += new System.EventHandler(this.RemoveColonyButton_Click);
            // 
            // BuildingsSelectList
            // 
            this.BuildingsSelectList.FormattingEnabled = true;
            this.BuildingsSelectList.ItemHeight = 16;
            this.BuildingsSelectList.Location = new System.Drawing.Point(520, 27);
            this.BuildingsSelectList.Name = "BuildingsSelectList";
            this.BuildingsSelectList.Size = new System.Drawing.Size(213, 260);
            this.BuildingsSelectList.TabIndex = 12;
            this.BuildingsSelectList.SelectedIndexChanged += new System.EventHandler(this.BuildingsSelectList_SelectedIndexChanged);
            // 
            // BuildingInput
            // 
            this.BuildingInput.Location = new System.Drawing.Point(520, 319);
            this.BuildingInput.Name = "BuildingInput";
            this.BuildingInput.Size = new System.Drawing.Size(213, 22);
            this.BuildingInput.TabIndex = 13;
            // 
            // CreateBuildingButton
            // 
            this.CreateBuildingButton.Location = new System.Drawing.Point(520, 347);
            this.CreateBuildingButton.Name = "CreateBuildingButton";
            this.CreateBuildingButton.Size = new System.Drawing.Size(213, 23);
            this.CreateBuildingButton.TabIndex = 14;
            this.CreateBuildingButton.Text = "Create Building";
            this.CreateBuildingButton.UseVisualStyleBackColor = true;
            // 
            // RemoveBuildingButton
            // 
            this.RemoveBuildingButton.Location = new System.Drawing.Point(520, 376);
            this.RemoveBuildingButton.Name = "RemoveBuildingButton";
            this.RemoveBuildingButton.Size = new System.Drawing.Size(213, 23);
            this.RemoveBuildingButton.TabIndex = 15;
            this.RemoveBuildingButton.Text = "Remove Building";
            this.RemoveBuildingButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 448);
            this.Controls.Add(this.RemoveBuildingButton);
            this.Controls.Add(this.CreateBuildingButton);
            this.Controls.Add(this.BuildingInput);
            this.Controls.Add(this.BuildingsSelectList);
            this.Controls.Add(this.RemoveColonyButton);
            this.Controls.Add(this.CreateColonyButton);
            this.Controls.Add(this.ColonyInput);
            this.Controls.Add(this.ColoniesSelectList);
            this.Controls.Add(this.PlanetsSelectList);
            this.Controls.Add(this.RemovePlanetButton);
            this.Controls.Add(this.StatusBar);
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
        private System.Windows.Forms.Button RemovePlanetButton;
        private System.Windows.Forms.ListBox PlanetsSelectList;
        private System.Windows.Forms.ListBox ColoniesSelectList;
        private System.Windows.Forms.TextBox ColonyInput;
        private System.Windows.Forms.Button CreateColonyButton;
        private System.Windows.Forms.Button RemoveColonyButton;
        public System.Windows.Forms.Label StatusBar;
        private System.Windows.Forms.ListBox BuildingsSelectList;
        private System.Windows.Forms.TextBox BuildingInput;
        private System.Windows.Forms.Button CreateBuildingButton;
        private System.Windows.Forms.Button RemoveBuildingButton;
    }
}


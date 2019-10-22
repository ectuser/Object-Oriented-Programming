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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlanetInfoTitle = new System.Windows.Forms.Label();
            this.PlanetInfoData = new System.Windows.Forms.Label();
            this.ColonyInfoData = new System.Windows.Forms.Label();
            this.ColonyInfoTitle = new System.Windows.Forms.Label();
            this.BuildingInfoData = new System.Windows.Forms.Label();
            this.BuildingInfoTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.BuildingInput.TextChanged += new System.EventHandler(this.BuildingInput_TextChanged);
            // 
            // CreateBuildingButton
            // 
            this.CreateBuildingButton.Location = new System.Drawing.Point(520, 347);
            this.CreateBuildingButton.Name = "CreateBuildingButton";
            this.CreateBuildingButton.Size = new System.Drawing.Size(213, 23);
            this.CreateBuildingButton.TabIndex = 14;
            this.CreateBuildingButton.Text = "Create Building";
            this.CreateBuildingButton.UseVisualStyleBackColor = true;
            this.CreateBuildingButton.Click += new System.EventHandler(this.CreateBuildingButton_Click);
            // 
            // RemoveBuildingButton
            // 
            this.RemoveBuildingButton.Location = new System.Drawing.Point(520, 376);
            this.RemoveBuildingButton.Name = "RemoveBuildingButton";
            this.RemoveBuildingButton.Size = new System.Drawing.Size(213, 23);
            this.RemoveBuildingButton.TabIndex = 15;
            this.RemoveBuildingButton.Text = "Remove Building";
            this.RemoveBuildingButton.UseVisualStyleBackColor = true;
            this.RemoveBuildingButton.Click += new System.EventHandler(this.RemoveBuildingButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Planet Names";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "Colony Names";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Building ID";
            // 
            // PlanetInfoTitle
            // 
            this.PlanetInfoTitle.AutoSize = true;
            this.PlanetInfoTitle.Location = new System.Drawing.Point(12, 416);
            this.PlanetInfoTitle.Name = "PlanetInfoTitle";
            this.PlanetInfoTitle.Size = new System.Drawing.Size(83, 17);
            this.PlanetInfoTitle.TabIndex = 19;
            this.PlanetInfoTitle.Text = "Planet info: ";
            // 
            // PlanetInfoData
            // 
            this.PlanetInfoData.AutoSize = true;
            this.PlanetInfoData.Location = new System.Drawing.Point(12, 433);
            this.PlanetInfoData.Name = "PlanetInfoData";
            this.PlanetInfoData.Size = new System.Drawing.Size(80, 17);
            this.PlanetInfoData.TabIndex = 20;
            this.PlanetInfoData.Text = "Planet data";
            // 
            // ColonyInfoData
            // 
            this.ColonyInfoData.AutoSize = true;
            this.ColonyInfoData.Location = new System.Drawing.Point(262, 433);
            this.ColonyInfoData.Name = "ColonyInfoData";
            this.ColonyInfoData.Size = new System.Drawing.Size(83, 17);
            this.ColonyInfoData.TabIndex = 22;
            this.ColonyInfoData.Text = "Colony data";
            this.ColonyInfoData.Click += new System.EventHandler(this.ColonyInfoData_Click);
            // 
            // ColonyInfoTitle
            // 
            this.ColonyInfoTitle.AutoSize = true;
            this.ColonyInfoTitle.Location = new System.Drawing.Point(262, 416);
            this.ColonyInfoTitle.Name = "ColonyInfoTitle";
            this.ColonyInfoTitle.Size = new System.Drawing.Size(82, 17);
            this.ColonyInfoTitle.TabIndex = 21;
            this.ColonyInfoTitle.Text = "Colony info:";
            // 
            // BuildingInfoData
            // 
            this.BuildingInfoData.AutoSize = true;
            this.BuildingInfoData.Location = new System.Drawing.Point(520, 433);
            this.BuildingInfoData.Name = "BuildingInfoData";
            this.BuildingInfoData.Size = new System.Drawing.Size(90, 17);
            this.BuildingInfoData.TabIndex = 24;
            this.BuildingInfoData.Text = "Building data";
            // 
            // BuildingInfoTitle
            // 
            this.BuildingInfoTitle.AutoSize = true;
            this.BuildingInfoTitle.Location = new System.Drawing.Point(520, 416);
            this.BuildingInfoTitle.Name = "BuildingInfoTitle";
            this.BuildingInfoTitle.Size = new System.Drawing.Size(89, 17);
            this.BuildingInfoTitle.TabIndex = 23;
            this.BuildingInfoTitle.Text = "Building info:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(753, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 34);
            this.label4.TabIndex = 26;
            this.label4.Text = "Market\r\nPrice for 5 elements\r\n";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(756, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 27;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 902);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BuildingInfoData);
            this.Controls.Add(this.BuildingInfoTitle);
            this.Controls.Add(this.ColonyInfoData);
            this.Controls.Add(this.ColonyInfoTitle);
            this.Controls.Add(this.PlanetInfoData);
            this.Controls.Add(this.PlanetInfoTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlanetInfoTitle;
        private System.Windows.Forms.Label PlanetInfoData;
        private System.Windows.Forms.Label ColonyInfoData;
        private System.Windows.Forms.Label ColonyInfoTitle;
        private System.Windows.Forms.Label BuildingInfoData;
        private System.Windows.Forms.Label BuildingInfoTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
    }
}


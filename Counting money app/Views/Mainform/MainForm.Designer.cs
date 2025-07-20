namespace MoneyCounterApp.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerLabel = new Label();
            fileInfoGroup = new GroupBox();
            fileInfoLabel = new Label();
            summaryGroup = new GroupBox();
            summaryLabel = new Label();
            tabControl = new TabControl();
            tableTab = new TabPage();
            dataGridView = new DataGridView();
            rawTab = new TabPage();
            rawTextBox = new RichTextBox();
            buttonPanel = new FlowLayoutPanel();
            loadXmlButton = new Button();
            loadLcmsTextButton = new Button();
            exportCsvButton = new Button();
            exportExcelButton = new Button();
            exportPdfButton = new Button();
            refreshButton = new Button();
            clearButton = new Button();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            fileInfoGroup.SuspendLayout();
            summaryGroup.SuspendLayout();
            tabControl.SuspendLayout();
            tableTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            rawTab.SuspendLayout();
            buttonPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(16, 14);
            headerLabel.Margin = new Padding(4, 0, 4, 0);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(446, 32);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "💰 Money Counter Converter Pro";
            // 
            // fileInfoGroup
            // 
            fileInfoGroup.Controls.Add(fileInfoLabel);
            fileInfoGroup.Location = new Point(16, 69);
            fileInfoGroup.Margin = new Padding(4, 5, 4, 5);
            fileInfoGroup.Name = "fileInfoGroup";
            fileInfoGroup.Padding = new Padding(4, 5, 4, 5);
            fileInfoGroup.Size = new Size(1147, 108);
            fileInfoGroup.TabIndex = 1;
            fileInfoGroup.TabStop = false;
            fileInfoGroup.Text = "File Information";
            // 
            // fileInfoLabel
            // 
            fileInfoLabel.AutoSize = true;
            fileInfoLabel.Location = new Point(8, 38);
            fileInfoLabel.Margin = new Padding(4, 0, 4, 0);
            fileInfoLabel.Name = "fileInfoLabel";
            fileInfoLabel.Size = new Size(105, 20);
            fileInfoLabel.TabIndex = 0;
            fileInfoLabel.Text = "No file loaded";
            // 
            // summaryGroup
            // 
            summaryGroup.Controls.Add(summaryLabel);
            summaryGroup.Location = new Point(16, 186);
            summaryGroup.Margin = new Padding(4, 5, 4, 5);
            summaryGroup.Name = "summaryGroup";
            summaryGroup.Padding = new Padding(4, 5, 4, 5);
            summaryGroup.Size = new Size(1147, 92);
            summaryGroup.TabIndex = 2;
            summaryGroup.TabStop = false;
            summaryGroup.Text = "Summary";
            // 
            // summaryLabel
            // 
            summaryLabel.AutoSize = true;
            summaryLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            summaryLabel.Location = new Point(8, 38);
            summaryLabel.Margin = new Padding(4, 0, 4, 0);
            summaryLabel.Name = "summaryLabel";
            summaryLabel.Size = new Size(0, 18);
            summaryLabel.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tableTab);
            tabControl.Controls.Add(rawTab);
            tabControl.Location = new Point(16, 288);
            tabControl.Margin = new Padding(4, 5, 4, 5);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1147, 462);
            tabControl.TabIndex = 3;
            // 
            // tableTab
            // 
            tableTab.Controls.Add(dataGridView);
            tableTab.Location = new Point(4, 29);
            tableTab.Margin = new Padding(4, 5, 4, 5);
            tableTab.Name = "tableTab";
            tableTab.Padding = new Padding(4, 5, 4, 5);
            tableTab.Size = new Size(1139, 429);
            tableTab.TabIndex = 0;
            tableTab.Text = "Table View";
            tableTab.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(4, 5);
            dataGridView.Margin = new Padding(4, 5, 4, 5);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(1131, 419);
            dataGridView.TabIndex = 0;
            // 
            // rawTab
            // 
            rawTab.Controls.Add(rawTextBox);
            rawTab.Location = new Point(4, 29);
            rawTab.Margin = new Padding(4, 5, 4, 5);
            rawTab.Name = "rawTab";
            rawTab.Padding = new Padding(4, 5, 4, 5);
            rawTab.Size = new Size(1139, 429);
            rawTab.TabIndex = 1;
            rawTab.Text = "Raw Data";
            rawTab.UseVisualStyleBackColor = true;
            // 
            // rawTextBox
            // 
            rawTextBox.Dock = DockStyle.Fill;
            rawTextBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rawTextBox.Location = new Point(4, 5);
            rawTextBox.Margin = new Padding(4, 5, 4, 5);
            rawTextBox.Name = "rawTextBox";
            rawTextBox.ReadOnly = true;
            rawTextBox.Size = new Size(1131, 419);
            rawTextBox.TabIndex = 0;
            rawTextBox.Text = "";
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(loadXmlButton);
            buttonPanel.Controls.Add(loadLcmsTextButton);
            buttonPanel.Controls.Add(exportCsvButton);
            buttonPanel.Controls.Add(exportExcelButton);
            buttonPanel.Controls.Add(exportPdfButton);
            buttonPanel.Controls.Add(refreshButton);
            buttonPanel.Controls.Add(clearButton);
            buttonPanel.Location = new Point(16, 758);
            buttonPanel.Margin = new Padding(4, 5, 4, 5);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Size = new Size(1147, 77);
            buttonPanel.TabIndex = 4;
            // 
            // loadXmlButton
            // 
            loadXmlButton.Location = new Point(4, 5);
            loadXmlButton.Margin = new Padding(4, 5, 4, 5);
            loadXmlButton.Name = "loadXmlButton";
            loadXmlButton.Size = new Size(133, 62);
            loadXmlButton.TabIndex = 0;
            loadXmlButton.Text = "📂 Load XML";
            loadXmlButton.UseVisualStyleBackColor = true;
            loadXmlButton.Click += LoadXmlButton_Click;
            // 
            // loadLcmsTextButton
            // 
            loadLcmsTextButton.Location = new Point(145, 5);
            loadLcmsTextButton.Margin = new Padding(4, 5, 4, 5);
            loadLcmsTextButton.Name = "loadLcmsTextButton";
            loadLcmsTextButton.Size = new Size(160, 62);
            loadLcmsTextButton.TabIndex = 2;
            loadLcmsTextButton.Text = "📝 LCMS Text";
            loadLcmsTextButton.UseVisualStyleBackColor = true;
            loadLcmsTextButton.Click += LoadLcmsTextButton_Click;
            // 
            // exportCsvButton
            // 
            exportCsvButton.Enabled = false;
            exportCsvButton.Location = new Point(313, 5);
            exportCsvButton.Margin = new Padding(4, 5, 4, 5);
            exportCsvButton.Name = "exportCsvButton";
            exportCsvButton.Size = new Size(107, 62);
            exportCsvButton.TabIndex = 3;
            exportCsvButton.Text = "💾 CSV";
            exportCsvButton.UseVisualStyleBackColor = true;
            exportCsvButton.Click += ExportCsvButton_Click;
            // 
            // exportExcelButton
            // 
            exportExcelButton.Enabled = false;
            exportExcelButton.Location = new Point(428, 5);
            exportExcelButton.Margin = new Padding(4, 5, 4, 5);
            exportExcelButton.Name = "exportExcelButton";
            exportExcelButton.Size = new Size(107, 62);
            exportExcelButton.TabIndex = 4;
            exportExcelButton.Text = "💾 Excel";
            exportExcelButton.UseVisualStyleBackColor = true;
            exportExcelButton.Click += ExportExcelButton_Click;
            // 
            // exportPdfButton
            // 
            exportPdfButton.Enabled = false;
            exportPdfButton.Location = new Point(543, 5);
            exportPdfButton.Margin = new Padding(4, 5, 4, 5);
            exportPdfButton.Name = "exportPdfButton";
            exportPdfButton.Size = new Size(107, 62);
            exportPdfButton.TabIndex = 5;
            exportPdfButton.Text = "🖨️ PDF";
            exportPdfButton.UseVisualStyleBackColor = true;
            exportPdfButton.Click += ExportPdfButton_Click;
            // 
            // refreshButton
            // 
            refreshButton.Enabled = false;
            refreshButton.Location = new Point(658, 5);
            refreshButton.Margin = new Padding(4, 5, 4, 5);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(107, 62);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "🔄 Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += RefreshButton_Click;
            // 
            // clearButton
            // 
            clearButton.Enabled = false;
            clearButton.Location = new Point(773, 5);
            clearButton.Margin = new Padding(4, 5, 4, 5);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(107, 62);
            clearButton.TabIndex = 7;
            clearButton.Text = "❌ Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += ClearButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip.Location = new Point(0, 854);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 19, 0);
            statusStrip.Size = new Size(1179, 26);
            statusStrip.TabIndex = 5;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 880);
            Controls.Add(statusStrip);
            Controls.Add(buttonPanel);
            Controls.Add(tabControl);
            Controls.Add(summaryGroup);
            Controls.Add(fileInfoGroup);
            Controls.Add(headerLabel);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(927, 744);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Money Counter Converter Pro";
            fileInfoGroup.ResumeLayout(false);
            fileInfoGroup.PerformLayout();
            summaryGroup.ResumeLayout(false);
            summaryGroup.PerformLayout();
            tabControl.ResumeLayout(false);
            tableTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            rawTab.ResumeLayout(false);
            buttonPanel.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.GroupBox fileInfoGroup;
        private System.Windows.Forms.Label fileInfoLabel;
        private System.Windows.Forms.GroupBox summaryGroup;
        private System.Windows.Forms.Label summaryLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tableTab;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TabPage rawTab;
        private System.Windows.Forms.RichTextBox rawTextBox;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button loadXmlButton;
        private System.Windows.Forms.Button loadLcmsImageButton;
        private System.Windows.Forms.Button loadLcmsTextButton;
        private System.Windows.Forms.Button exportCsvButton;
        private System.Windows.Forms.Button exportExcelButton;
        private System.Windows.Forms.Button exportPdfButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}
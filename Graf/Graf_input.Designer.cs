
namespace Graf
{
    partial class Graf_input
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
            this.graf_tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.is_graf = new System.Windows.Forms.RadioButton();
            this.is_orgraf = new System.Windows.Forms.RadioButton();
            this.Analyze = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graf_tableLayoutPanel
            // 
            this.graf_tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.graf_tableLayoutPanel.AutoSize = true;
            this.graf_tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.graf_tableLayoutPanel.ColumnCount = 1;
            this.graf_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.graf_tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 747F));
            this.graf_tableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.graf_tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.graf_tableLayoutPanel.Location = new System.Drawing.Point(20, 58);
            this.graf_tableLayoutPanel.Name = "graf_tableLayoutPanel";
            this.graf_tableLayoutPanel.RowCount = 1;
            this.graf_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.graf_tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.graf_tableLayoutPanel.Size = new System.Drawing.Size(53, 24);
            this.graf_tableLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Матрица смежности";
            // 
            // is_graf
            // 
            this.is_graf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.is_graf.AutoSize = true;
            this.is_graf.Checked = true;
            this.is_graf.Location = new System.Drawing.Point(18, 102);
            this.is_graf.Name = "is_graf";
            this.is_graf.Size = new System.Drawing.Size(64, 21);
            this.is_graf.TabIndex = 2;
            this.is_graf.TabStop = true;
            this.is_graf.Text = "Граф";
            this.is_graf.UseVisualStyleBackColor = true;
            // 
            // is_orgraf
            // 
            this.is_orgraf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.is_orgraf.AutoSize = true;
            this.is_orgraf.Location = new System.Drawing.Point(18, 129);
            this.is_orgraf.Name = "is_orgraf";
            this.is_orgraf.Size = new System.Drawing.Size(80, 21);
            this.is_orgraf.TabIndex = 3;
            this.is_orgraf.Text = "Орграф";
            this.is_orgraf.UseVisualStyleBackColor = true;
            // 
            // Analyze
            // 
            this.Analyze.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Analyze.Location = new System.Drawing.Point(104, 111);
            this.Analyze.Name = "Analyze";
            this.Analyze.Size = new System.Drawing.Size(128, 39);
            this.Analyze.TabIndex = 4;
            this.Analyze.Text = "Анализировать";
            this.Analyze.UseVisualStyleBackColor = true;
            this.Analyze.Click += new System.EventHandler(this.Analyze_Click);
            // 
            // Graf_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(367, 159);
            this.Controls.Add(this.Analyze);
            this.Controls.Add(this.is_orgraf);
            this.Controls.Add(this.is_graf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.graf_tableLayoutPanel);
            this.Name = "Graf_input";
            this.Text = "Graf_input";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Graf_input_FormClosing);
            this.Load += new System.EventHandler(this.Graf_input_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel graf_tableLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton is_graf;
        private System.Windows.Forms.RadioButton is_orgraf;
        private System.Windows.Forms.Button Analyze;
    }
}
namespace ImportExport
{
    partial class FuncionariosForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.importarDadosButton = new System.Windows.Forms.Button();
            this.funcionariosDataGridView = new System.Windows.Forms.DataGridView();
            this.ajustarSalariosButton = new System.Windows.Forms.Button();
            this.exportarDadosButton = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // importarDadosButton
            // 
            this.importarDadosButton.Location = new System.Drawing.Point(13, 13);
            this.importarDadosButton.Name = "importarDadosButton";
            this.importarDadosButton.Size = new System.Drawing.Size(195, 50);
            this.importarDadosButton.TabIndex = 0;
            this.importarDadosButton.Text = "Importar Dados";
            this.importarDadosButton.UseVisualStyleBackColor = true;
            this.importarDadosButton.Click += new System.EventHandler(this.importarDadosButton_Click);
            // 
            // funcionariosDataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.funcionariosDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.funcionariosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.funcionariosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.funcionariosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.funcionariosDataGridView.Location = new System.Drawing.Point(13, 69);
            this.funcionariosDataGridView.MultiSelect = false;
            this.funcionariosDataGridView.Name = "funcionariosDataGridView";
            this.funcionariosDataGridView.ReadOnly = true;
            this.funcionariosDataGridView.RowTemplate.Height = 24;
            this.funcionariosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.funcionariosDataGridView.Size = new System.Drawing.Size(648, 326);
            this.funcionariosDataGridView.TabIndex = 1;
            // 
            // ajustarSalariosButton
            // 
            this.ajustarSalariosButton.Enabled = false;
            this.ajustarSalariosButton.Location = new System.Drawing.Point(214, 13);
            this.ajustarSalariosButton.Name = "ajustarSalariosButton";
            this.ajustarSalariosButton.Size = new System.Drawing.Size(195, 50);
            this.ajustarSalariosButton.TabIndex = 2;
            this.ajustarSalariosButton.Text = "Ajustar Salários";
            this.ajustarSalariosButton.UseVisualStyleBackColor = true;
            this.ajustarSalariosButton.Click += new System.EventHandler(this.ajustarSalariosButton_Click);
            // 
            // exportarDadosButton
            // 
            this.exportarDadosButton.Enabled = false;
            this.exportarDadosButton.Location = new System.Drawing.Point(415, 13);
            this.exportarDadosButton.Name = "exportarDadosButton";
            this.exportarDadosButton.Size = new System.Drawing.Size(195, 50);
            this.exportarDadosButton.TabIndex = 2;
            this.exportarDadosButton.Text = "Exportar Dados";
            this.exportarDadosButton.UseVisualStyleBackColor = true;
            this.exportarDadosButton.Click += new System.EventHandler(this.exportarDadosButton_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // FuncionariosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 407);
            this.Controls.Add(this.exportarDadosButton);
            this.Controls.Add(this.ajustarSalariosButton);
            this.Controls.Add(this.funcionariosDataGridView);
            this.Controls.Add(this.importarDadosButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FuncionariosForm";
            this.Text = "Ferramenta ImportExport v. 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.funcionariosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importarDadosButton;
        private System.Windows.Forms.DataGridView funcionariosDataGridView;
        private System.Windows.Forms.Button ajustarSalariosButton;
        private System.Windows.Forms.Button exportarDadosButton;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}
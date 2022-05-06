
namespace AP3_FormaFlix
{
    partial class FormListeUser
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUtilisateurs = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listeDesCompétencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_modif_liste = new System.Windows.Forms.Button();
            this.btnsuppforma = new System.Windows.Forms.Button();
            this.btnFermer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilisateurs)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUtilisateurs
            // 
            this.dgvUtilisateurs.AllowUserToAddRows = false;
            this.dgvUtilisateurs.AllowUserToDeleteRows = false;
            this.dgvUtilisateurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUtilisateurs.BackgroundColor = System.Drawing.Color.White;
            this.dgvUtilisateurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUtilisateurs.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUtilisateurs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUtilisateurs.Location = new System.Drawing.Point(31, 87);
            this.dgvUtilisateurs.MultiSelect = false;
            this.dgvUtilisateurs.Name = "dgvUtilisateurs";
            this.dgvUtilisateurs.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvUtilisateurs.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUtilisateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUtilisateurs.Size = new System.Drawing.Size(1316, 529);
            this.dgvUtilisateurs.TabIndex = 11;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeDesCompétencesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(194, 26);
            // 
            // listeDesCompétencesToolStripMenuItem
            // 
            this.listeDesCompétencesToolStripMenuItem.Name = "listeDesCompétencesToolStripMenuItem";
            this.listeDesCompétencesToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.listeDesCompétencesToolStripMenuItem.Text = "Liste des compétences";
            // 
            // btn_modif_liste
            // 
            this.btn_modif_liste.BackColor = System.Drawing.Color.Black;
            this.btn_modif_liste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modif_liste.ForeColor = System.Drawing.Color.White;
            this.btn_modif_liste.Location = new System.Drawing.Point(552, 641);
            this.btn_modif_liste.Name = "btn_modif_liste";
            this.btn_modif_liste.Size = new System.Drawing.Size(113, 39);
            this.btn_modif_liste.TabIndex = 16;
            this.btn_modif_liste.Text = "MODIFIER";
            this.btn_modif_liste.UseVisualStyleBackColor = false;
            this.btn_modif_liste.Click += new System.EventHandler(this.btn_modif_liste_Click);
            // 
            // btnsuppforma
            // 
            this.btnsuppforma.BackColor = System.Drawing.Color.Black;
            this.btnsuppforma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsuppforma.ForeColor = System.Drawing.Color.White;
            this.btnsuppforma.Location = new System.Drawing.Point(671, 641);
            this.btnsuppforma.Name = "btnsuppforma";
            this.btnsuppforma.Size = new System.Drawing.Size(113, 39);
            this.btnsuppforma.TabIndex = 14;
            this.btnsuppforma.Text = "SUPPRIMER";
            this.btnsuppforma.UseVisualStyleBackColor = false;
            // 
            // btnFermer
            // 
            this.btnFermer.BackColor = System.Drawing.Color.Black;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(790, 641);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(98, 39);
            this.btnFermer.TabIndex = 13;
            this.btnFermer.Text = "FERMER";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Liste des Utilisateurs";
            // 
            // FormListeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1375, 704);
            this.Controls.Add(this.dgvUtilisateurs);
            this.Controls.Add(this.btn_modif_liste);
            this.Controls.Add(this.btnsuppforma);
            this.Controls.Add(this.btnFermer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormListeUser";
            this.Text = "FormListeUser";
            this.Load += new System.EventHandler(this.FormListeUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUtilisateurs)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUtilisateurs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listeDesCompétencesToolStripMenuItem;
        private System.Windows.Forms.Button btn_modif_liste;
        private System.Windows.Forms.Button btnsuppforma;
        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label label1;
    }
}
namespace AppFichaFamiliar.Vista
{
    partial class frmPrincipal
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlFrmPrincipa = new System.Windows.Forms.Panel();
            this.pnlFrmCuerpo = new System.Windows.Forms.Panel();
            this.subPnlFrmCuerpo = new System.Windows.Forms.Panel();
            this.pnlBarraLateral = new System.Windows.Forms.Panel();
            this.subPnlBarraLaretal = new System.Windows.Forms.Panel();
            this.btnOpenFrmFichaFamiliar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bntFichaFamiliar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlBarraEncabezado = new System.Windows.Forms.Panel();
            this.btnMinFrm = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMaxFrm = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnCerrarApp = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlFrmPrincipa.SuspendLayout();
            this.pnlFrmCuerpo.SuspendLayout();
            this.pnlBarraLateral.SuspendLayout();
            this.subPnlBarraLaretal.SuspendLayout();
            this.pnlBarraEncabezado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinFrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaxFrm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarApp)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 35;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnlFrmPrincipa
            // 
            this.pnlFrmPrincipa.Controls.Add(this.pnlFrmCuerpo);
            this.pnlFrmPrincipa.Controls.Add(this.pnlBarraEncabezado);
            this.pnlFrmPrincipa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrmPrincipa.Location = new System.Drawing.Point(0, 0);
            this.pnlFrmPrincipa.Name = "pnlFrmPrincipa";
            this.pnlFrmPrincipa.Size = new System.Drawing.Size(1750, 977);
            this.pnlFrmPrincipa.TabIndex = 0;
            // 
            // pnlFrmCuerpo
            // 
            this.pnlFrmCuerpo.Controls.Add(this.subPnlFrmCuerpo);
            this.pnlFrmCuerpo.Controls.Add(this.pnlBarraLateral);
            this.pnlFrmCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFrmCuerpo.Location = new System.Drawing.Point(0, 41);
            this.pnlFrmCuerpo.Name = "pnlFrmCuerpo";
            this.pnlFrmCuerpo.Size = new System.Drawing.Size(1750, 936);
            this.pnlFrmCuerpo.TabIndex = 1;
            // 
            // subPnlFrmCuerpo
            // 
            this.subPnlFrmCuerpo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.subPnlFrmCuerpo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subPnlFrmCuerpo.Location = new System.Drawing.Point(163, 0);
            this.subPnlFrmCuerpo.Name = "subPnlFrmCuerpo";
            this.subPnlFrmCuerpo.Size = new System.Drawing.Size(1587, 936);
            this.subPnlFrmCuerpo.TabIndex = 1;
            // 
            // pnlBarraLateral
            // 
            this.pnlBarraLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(78)))));
            this.pnlBarraLateral.Controls.Add(this.subPnlBarraLaretal);
            this.pnlBarraLateral.Controls.Add(this.bntFichaFamiliar);
            this.pnlBarraLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBarraLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraLateral.Name = "pnlBarraLateral";
            this.pnlBarraLateral.Size = new System.Drawing.Size(163, 936);
            this.pnlBarraLateral.TabIndex = 0;
            // 
            // subPnlBarraLaretal
            // 
            this.subPnlBarraLaretal.Controls.Add(this.btnOpenFrmFichaFamiliar);
            this.subPnlBarraLaretal.Dock = System.Windows.Forms.DockStyle.Top;
            this.subPnlBarraLaretal.Location = new System.Drawing.Point(0, 89);
            this.subPnlBarraLaretal.Name = "subPnlBarraLaretal";
            this.subPnlBarraLaretal.Size = new System.Drawing.Size(163, 67);
            this.subPnlBarraLaretal.TabIndex = 0;
            // 
            // btnOpenFrmFichaFamiliar
            // 
            this.btnOpenFrmFichaFamiliar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(78)))));
            this.btnOpenFrmFichaFamiliar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(236)))), ((int)(((byte)(227)))));
            this.btnOpenFrmFichaFamiliar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFrmFichaFamiliar.BorderRadius = 0;
            this.btnOpenFrmFichaFamiliar.ButtonText = "Consulta Familia";
            this.btnOpenFrmFichaFamiliar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFrmFichaFamiliar.DisabledColor = System.Drawing.Color.Gray;
            this.btnOpenFrmFichaFamiliar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenFrmFichaFamiliar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnOpenFrmFichaFamiliar.Iconimage = global::AppFichaFamiliar.Properties.Resources.icons8_find_user_male_48px;
            this.btnOpenFrmFichaFamiliar.Iconimage_right = null;
            this.btnOpenFrmFichaFamiliar.Iconimage_right_Selected = null;
            this.btnOpenFrmFichaFamiliar.Iconimage_Selected = null;
            this.btnOpenFrmFichaFamiliar.IconMarginLeft = 0;
            this.btnOpenFrmFichaFamiliar.IconMarginRight = 0;
            this.btnOpenFrmFichaFamiliar.IconRightVisible = true;
            this.btnOpenFrmFichaFamiliar.IconRightZoom = 0D;
            this.btnOpenFrmFichaFamiliar.IconVisible = true;
            this.btnOpenFrmFichaFamiliar.IconZoom = 90D;
            this.btnOpenFrmFichaFamiliar.IsTab = false;
            this.btnOpenFrmFichaFamiliar.Location = new System.Drawing.Point(0, 0);
            this.btnOpenFrmFichaFamiliar.Name = "btnOpenFrmFichaFamiliar";
            this.btnOpenFrmFichaFamiliar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(236)))), ((int)(((byte)(227)))));
            this.btnOpenFrmFichaFamiliar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.btnOpenFrmFichaFamiliar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnOpenFrmFichaFamiliar.selected = false;
            this.btnOpenFrmFichaFamiliar.Size = new System.Drawing.Size(163, 57);
            this.btnOpenFrmFichaFamiliar.TabIndex = 1;
            this.btnOpenFrmFichaFamiliar.Text = "Consulta Familia";
            this.btnOpenFrmFichaFamiliar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenFrmFichaFamiliar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(86)))));
            this.btnOpenFrmFichaFamiliar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnOpenFrmFichaFamiliar.Click += new System.EventHandler(this.btnOpenFrmFichaFamiliar_Click);
            // 
            // bntFichaFamiliar
            // 
            this.bntFichaFamiliar.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bntFichaFamiliar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(236)))), ((int)(((byte)(227)))));
            this.bntFichaFamiliar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bntFichaFamiliar.BorderRadius = 0;
            this.bntFichaFamiliar.ButtonText = "Ficha Familiar";
            this.bntFichaFamiliar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntFichaFamiliar.DisabledColor = System.Drawing.Color.Gray;
            this.bntFichaFamiliar.Dock = System.Windows.Forms.DockStyle.Top;
            this.bntFichaFamiliar.Iconcolor = System.Drawing.Color.Transparent;
            this.bntFichaFamiliar.Iconimage = global::AppFichaFamiliar.Properties.Resources.icons8_parenting_100px_3;
            this.bntFichaFamiliar.Iconimage_right = null;
            this.bntFichaFamiliar.Iconimage_right_Selected = null;
            this.bntFichaFamiliar.Iconimage_Selected = null;
            this.bntFichaFamiliar.IconMarginLeft = 0;
            this.bntFichaFamiliar.IconMarginRight = 0;
            this.bntFichaFamiliar.IconRightVisible = true;
            this.bntFichaFamiliar.IconRightZoom = 0D;
            this.bntFichaFamiliar.IconVisible = true;
            this.bntFichaFamiliar.IconZoom = 90D;
            this.bntFichaFamiliar.IsTab = false;
            this.bntFichaFamiliar.Location = new System.Drawing.Point(0, 0);
            this.bntFichaFamiliar.Name = "bntFichaFamiliar";
            this.bntFichaFamiliar.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(236)))), ((int)(((byte)(227)))));
            this.bntFichaFamiliar.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.bntFichaFamiliar.OnHoverTextColor = System.Drawing.Color.White;
            this.bntFichaFamiliar.selected = false;
            this.bntFichaFamiliar.Size = new System.Drawing.Size(163, 89);
            this.bntFichaFamiliar.TabIndex = 0;
            this.bntFichaFamiliar.Text = "Ficha Familiar";
            this.bntFichaFamiliar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntFichaFamiliar.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(87)))), ((int)(((byte)(86)))));
            this.bntFichaFamiliar.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.bntFichaFamiliar.Click += new System.EventHandler(this.bntFichaFamiliar_Click);
            // 
            // pnlBarraEncabezado
            // 
            this.pnlBarraEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(91)))), ((int)(((byte)(78)))));
            this.pnlBarraEncabezado.Controls.Add(this.btnMinFrm);
            this.pnlBarraEncabezado.Controls.Add(this.btnMaxFrm);
            this.pnlBarraEncabezado.Controls.Add(this.btnCerrarApp);
            this.pnlBarraEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraEncabezado.Name = "pnlBarraEncabezado";
            this.pnlBarraEncabezado.Size = new System.Drawing.Size(1750, 41);
            this.pnlBarraEncabezado.TabIndex = 0;
            // 
            // btnMinFrm
            // 
            this.btnMinFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.btnMinFrm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinFrm.Image = global::AppFichaFamiliar.Properties.Resources.min_64px;
            this.btnMinFrm.ImageActive = null;
            this.btnMinFrm.Location = new System.Drawing.Point(1594, 0);
            this.btnMinFrm.Name = "btnMinFrm";
            this.btnMinFrm.Size = new System.Drawing.Size(52, 41);
            this.btnMinFrm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinFrm.TabIndex = 2;
            this.btnMinFrm.TabStop = false;
            this.btnMinFrm.Zoom = 10;
            this.btnMinFrm.Click += new System.EventHandler(this.btnMinFrm_Click);
            // 
            // btnMaxFrm
            // 
            this.btnMaxFrm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(188)))), ((int)(((byte)(154)))));
            this.btnMaxFrm.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaxFrm.Image = global::AppFichaFamiliar.Properties.Resources.max_64px;
            this.btnMaxFrm.ImageActive = null;
            this.btnMaxFrm.Location = new System.Drawing.Point(1646, 0);
            this.btnMaxFrm.Name = "btnMaxFrm";
            this.btnMaxFrm.Size = new System.Drawing.Size(52, 41);
            this.btnMaxFrm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaxFrm.TabIndex = 1;
            this.btnMaxFrm.TabStop = false;
            this.btnMaxFrm.Zoom = 10;
            this.btnMaxFrm.Click += new System.EventHandler(this.btnMaxFrm_Click);
            // 
            // btnCerrarApp
            // 
            this.btnCerrarApp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(143)))), ((int)(((byte)(84)))));
            this.btnCerrarApp.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrarApp.Image = global::AppFichaFamiliar.Properties.Resources.icons8_cancel_64px;
            this.btnCerrarApp.ImageActive = null;
            this.btnCerrarApp.Location = new System.Drawing.Point(1698, 0);
            this.btnCerrarApp.Name = "btnCerrarApp";
            this.btnCerrarApp.Size = new System.Drawing.Size(52, 41);
            this.btnCerrarApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrarApp.TabIndex = 0;
            this.btnCerrarApp.TabStop = false;
            this.btnCerrarApp.Zoom = 10;
            this.btnCerrarApp.Click += new System.EventHandler(this.btnCerrarApp_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1750, 977);
            this.Controls.Add(this.pnlFrmPrincipa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrincipal";
            this.pnlFrmPrincipa.ResumeLayout(false);
            this.pnlFrmCuerpo.ResumeLayout(false);
            this.pnlBarraLateral.ResumeLayout(false);
            this.subPnlBarraLaretal.ResumeLayout(false);
            this.pnlBarraEncabezado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinFrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaxFrm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrarApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnlFrmPrincipa;
        private System.Windows.Forms.Panel pnlBarraEncabezado;
        private System.Windows.Forms.Panel pnlFrmCuerpo;
        private System.Windows.Forms.Panel pnlBarraLateral;
        private System.Windows.Forms.Panel subPnlFrmCuerpo;
        private Bunifu.Framework.UI.BunifuImageButton btnCerrarApp;
        private Bunifu.Framework.UI.BunifuImageButton btnMinFrm;
        private Bunifu.Framework.UI.BunifuImageButton btnMaxFrm;
        private System.Windows.Forms.Panel subPnlBarraLaretal;
        private Bunifu.Framework.UI.BunifuFlatButton btnOpenFrmFichaFamiliar;
        private Bunifu.Framework.UI.BunifuFlatButton bntFichaFamiliar;
    }
}
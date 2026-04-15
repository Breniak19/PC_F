namespace PC_F
{
    partial class Form1
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Paneles Modernos
            this.panelPerfiles = new System.Windows.Forms.Panel();
            this.panelAjustes = new System.Windows.Forms.Panel();
            this.panelMonitoreo = new System.Windows.Forms.Panel();

            // Etiquetas de Cabecera y Títulos
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblSignature = new System.Windows.Forms.Label();
            this.lblHeaderPerfiles = new System.Windows.Forms.Label();
            this.lblHeaderAjustes = new System.Windows.Forms.Label();
            this.lblHeaderMonitoreo = new System.Windows.Forms.Label();

            // Controles de Perfil
            this.rbPerfil4 = new System.Windows.Forms.RadioButton();
            this.rbPerfil3 = new System.Windows.Forms.RadioButton();
            this.rbPerfil2 = new System.Windows.Forms.RadioButton();
            this.rbPerfil1 = new System.Windows.Forms.RadioButton();

            // Controles de Ajustes
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numMult = new System.Windows.Forms.NumericUpDown();
            this.chkTurbo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numGpu = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numCache = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numCore = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();

            // Controles de Monitoreo
            this.lblCurrentMult = new System.Windows.Forms.Label();
            this.lblCurrentTurbo = new System.Windows.Forms.Label();
            this.lblCurrentGpu = new System.Windows.Forms.Label();
            this.lblCurrentCache = new System.Windows.Forms.Label();
            this.lblCurrentCore = new System.Windows.Forms.Label();

            // Sistema y Bandeja
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.timerMonitor = new System.Windows.Forms.Timer(this.components);

            this.panelPerfiles.SuspendLayout();
            this.panelAjustes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCache)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCore)).BeginInit();
            this.panelMonitoreo.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();

            // ==========================================
            // CONFIGURACIÓN GENERAL DEL FORMULARIO
            // ==========================================
            this.BackColor = System.Drawing.Color.FromArgb(30, 30, 32);
            this.ForeColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ClientSize = new System.Drawing.Size(640, 420);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PC_F - Motor de Hardware";

            // Título Principal
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMainTitle.ForeColor = System.Drawing.Color.FromArgb(0, 160, 255);
            this.lblMainTitle.Location = new System.Drawing.Point(15, 15);
            this.lblMainTitle.Text = "⚡ PLUSCONTROL FORCE";

            // Firma Breniak
            this.lblSignature.AutoSize = true;
            this.lblSignature.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSignature.ForeColor = System.Drawing.Color.FromArgb(100, 100, 105);
            this.lblSignature.Location = new System.Drawing.Point(465, 385);
            this.lblSignature.Text = "Engineered by Breniak";

            this.Controls.Add(this.lblMainTitle);
            this.Controls.Add(this.lblSignature);

            // ==========================================
            // SECCIÓN: PERFILES
            // ==========================================
            this.lblHeaderPerfiles.AutoSize = true;
            this.lblHeaderPerfiles.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderPerfiles.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblHeaderPerfiles.Location = new System.Drawing.Point(20, 65);
            this.lblHeaderPerfiles.Text = "SELECCIÓN DE PERFIL";
            this.Controls.Add(this.lblHeaderPerfiles);

            this.panelPerfiles.BackColor = System.Drawing.Color.FromArgb(40, 40, 43);
            this.panelPerfiles.Location = new System.Drawing.Point(20, 85);
            this.panelPerfiles.Size = new System.Drawing.Size(340, 50);
            this.Controls.Add(this.panelPerfiles);

            this.rbPerfil1.AutoSize = true; this.rbPerfil1.Checked = true; this.rbPerfil1.Location = new System.Drawing.Point(15, 14); this.rbPerfil1.Text = "Perfil 1"; this.rbPerfil1.CheckedChanged += new System.EventHandler(this.RbPerfil_CheckedChanged);
            this.rbPerfil2.AutoSize = true; this.rbPerfil2.Location = new System.Drawing.Point(90, 14); this.rbPerfil2.Text = "Perfil 2"; this.rbPerfil2.CheckedChanged += new System.EventHandler(this.RbPerfil_CheckedChanged);
            this.rbPerfil3.AutoSize = true; this.rbPerfil3.Location = new System.Drawing.Point(165, 14); this.rbPerfil3.Text = "Perfil 3"; this.rbPerfil3.CheckedChanged += new System.EventHandler(this.RbPerfil_CheckedChanged);
            this.rbPerfil4.AutoSize = true; this.rbPerfil4.Location = new System.Drawing.Point(240, 14); this.rbPerfil4.Text = "Perfil 4"; this.rbPerfil4.CheckedChanged += new System.EventHandler(this.RbPerfil_CheckedChanged);

            this.panelPerfiles.Controls.Add(this.rbPerfil1);
            this.panelPerfiles.Controls.Add(this.rbPerfil2);
            this.panelPerfiles.Controls.Add(this.rbPerfil3);
            this.panelPerfiles.Controls.Add(this.rbPerfil4);

            // ==========================================
            // SECCIÓN: AJUSTES DE HARDWARE
            // ==========================================
            this.lblHeaderAjustes.AutoSize = true;
            this.lblHeaderAjustes.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderAjustes.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblHeaderAjustes.Location = new System.Drawing.Point(20, 150);
            this.lblHeaderAjustes.Text = "CONFIGURACIÓN DEL MOTOR";
            this.Controls.Add(this.lblHeaderAjustes);

            this.panelAjustes.BackColor = System.Drawing.Color.FromArgb(40, 40, 43);
            this.panelAjustes.Location = new System.Drawing.Point(20, 170);
            this.panelAjustes.Size = new System.Drawing.Size(340, 205);
            this.Controls.Add(this.panelAjustes);

            // Textos descriptivos
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(15, 20); this.label1.Text = "CPU Core (mV):";
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(15, 55); this.label2.Text = "CPU Cache (mV):";
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(15, 90); this.label3.Text = "Intel GPU (mV):";
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(205, 55); this.label4.Text = "Multiplicador:";
            this.label5.AutoSize = true; this.label5.Location = new System.Drawing.Point(205, 105); this.label5.Text = "(0 = Modo Auto)"; this.label5.ForeColor = System.Drawing.Color.Gray; this.label5.Font = new System.Drawing.Font("Segoe UI", 8.5F);

            // Cajas Numéricas Estilizadas
            this.numCore.Location = new System.Drawing.Point(120, 18); this.numCore.Size = new System.Drawing.Size(65, 25);
            this.numCache.Location = new System.Drawing.Point(120, 53); this.numCache.Size = new System.Drawing.Size(65, 25);
            this.numGpu.Location = new System.Drawing.Point(120, 88); this.numGpu.Size = new System.Drawing.Size(65, 25);
            this.numMult.Location = new System.Drawing.Point(208, 77); this.numMult.Size = new System.Drawing.Size(110, 25);

            System.Windows.Forms.NumericUpDown[] nums = { numCore, numCache, numGpu, numMult };
            foreach (var n in nums)
            {
                n.BackColor = System.Drawing.Color.FromArgb(50, 50, 55);
                n.ForeColor = System.Drawing.Color.White;
                n.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                n.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            }
            this.numCore.Minimum = -100; this.numCore.Maximum = 0;
            this.numCache.Minimum = -100; this.numCache.Maximum = 0;
            this.numGpu.Minimum = -100; this.numGpu.Maximum = 0;
            this.numMult.Minimum = 0; this.numMult.Maximum = 40;

            this.chkTurbo.AutoSize = true; this.chkTurbo.Checked = true; this.chkTurbo.Location = new System.Drawing.Point(208, 20); this.chkTurbo.Text = "Turbo Boost";

            // Botones Flat
            this.btnGuardar.Location = new System.Drawing.Point(15, 145); this.btnGuardar.Size = new System.Drawing.Size(120, 40);
            this.btnGuardar.Text = "Guardar"; this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.FlatAppearance.BorderSize = 0; this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(60, 60, 65);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);

            this.btnAplicar.Location = new System.Drawing.Point(145, 145); this.btnAplicar.Size = new System.Drawing.Size(175, 40);
            this.btnAplicar.Text = "APLICAR HARDWARE"; this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.FlatAppearance.BorderSize = 0; this.btnAplicar.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAplicar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAplicar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);

            this.panelAjustes.Controls.Add(this.label1); this.panelAjustes.Controls.Add(this.numCore);
            this.panelAjustes.Controls.Add(this.label2); this.panelAjustes.Controls.Add(this.numCache);
            this.panelAjustes.Controls.Add(this.label3); this.panelAjustes.Controls.Add(this.numGpu);
            this.panelAjustes.Controls.Add(this.label4); this.panelAjustes.Controls.Add(this.numMult);
            this.panelAjustes.Controls.Add(this.label5); this.panelAjustes.Controls.Add(this.chkTurbo);
            this.panelAjustes.Controls.Add(this.btnGuardar); this.panelAjustes.Controls.Add(this.btnAplicar);

            // ==========================================
            // SECCIÓN: MONITOREO
            // ==========================================
            this.lblHeaderMonitoreo.AutoSize = true;
            this.lblHeaderMonitoreo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderMonitoreo.ForeColor = System.Drawing.Color.FromArgb(150, 150, 150);
            this.lblHeaderMonitoreo.Location = new System.Drawing.Point(380, 65);
            this.lblHeaderMonitoreo.Text = "ESTADO EN TIEMPO REAL";
            this.Controls.Add(this.lblHeaderMonitoreo);

            this.panelMonitoreo.BackColor = System.Drawing.Color.FromArgb(40, 40, 43);
            this.panelMonitoreo.Location = new System.Drawing.Point(380, 85);
            this.panelMonitoreo.Size = new System.Drawing.Size(235, 290);
            this.Controls.Add(this.panelMonitoreo);

            System.Windows.Forms.Label[] lblMonitors = { lblCurrentCore, lblCurrentCache, lblCurrentGpu, lblCurrentTurbo, lblCurrentMult };
            int yPos = 25;
            foreach (var lbl in lblMonitors)
            {
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.LightGray;
                lbl.Location = new System.Drawing.Point(20, yPos);
                this.panelMonitoreo.Controls.Add(lbl);
                yPos += 55;
            }

            this.lblCurrentCore.Text = "Core: Leyendo...";
            this.lblCurrentCache.Text = "Cache: Leyendo...";
            this.lblCurrentGpu.Text = "GPU: Leyendo...";
            this.lblCurrentTurbo.Text = "Turbo: Leyendo...";
            this.lblCurrentMult.Text = "Freq: Leyendo...";

            // ==========================================
            // BANDEJA Y EVENTOS
            // ==========================================
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "PC_F (PlusControl Force)";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Icon = System.Drawing.SystemIcons.Shield;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1_DoubleClick);

            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.menuMostrar, this.menuSalir });
            this.menuMostrar.Text = "Mostrar Motor"; this.menuMostrar.Click += new System.EventHandler(this.MenuMostrar_Click);
            this.menuSalir.Text = "Cerrar Motor PC_F"; this.menuSalir.Click += new System.EventHandler(this.MenuSalir_Click);

            this.timerMonitor.Enabled = true;
            this.timerMonitor.Interval = 1000;
            this.timerMonitor.Tick += new System.EventHandler(this.TimerMonitor_Tick);

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);

            this.panelPerfiles.ResumeLayout(false); this.panelPerfiles.PerformLayout();
            this.panelAjustes.ResumeLayout(false); this.panelAjustes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCache)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCore)).EndInit();
            this.panelMonitoreo.ResumeLayout(false); this.panelMonitoreo.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Variables Internas Generadas
        private System.Windows.Forms.Panel panelPerfiles;
        private System.Windows.Forms.Panel panelAjustes;
        private System.Windows.Forms.Panel panelMonitoreo;

        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.Label lblHeaderPerfiles;
        private System.Windows.Forms.Label lblHeaderAjustes;
        private System.Windows.Forms.Label lblHeaderMonitoreo;

        private System.Windows.Forms.RadioButton rbPerfil4;
        private System.Windows.Forms.RadioButton rbPerfil3;
        private System.Windows.Forms.RadioButton rbPerfil2;
        private System.Windows.Forms.RadioButton rbPerfil1;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMult;
        private System.Windows.Forms.CheckBox chkTurbo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numGpu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numCache;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnGuardar;

        private System.Windows.Forms.Label lblCurrentMult;
        private System.Windows.Forms.Label lblCurrentTurbo;
        private System.Windows.Forms.Label lblCurrentGpu;
        private System.Windows.Forms.Label lblCurrentCache;
        private System.Windows.Forms.Label lblCurrentCore;

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMostrar;
        private System.Windows.Forms.ToolStripMenuItem menuSalir;
        private System.Windows.Forms.Timer timerMonitor;
    }
}
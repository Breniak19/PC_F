using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_F
{
    // Modelo de datos para guardar los perfiles
    public class PerfilHardware
    {
        public double CoreVolt { get; set; } = 0;
        public double CacheVolt { get; set; } = 0;
        public double GpuVolt { get; set; } = 0;
        public bool TurboActivo { get; set; } = true;
        public uint Multiplicador { get; set; } = 0;
    }

    public partial class Form1 : Form
    {
        // =========================================================
        // WINRING0 Y REGISTROS
        // =========================================================
        [DllImport("WinRing0x64.dll")] public static extern bool InitializeOls();
        [DllImport("WinRing0x64.dll")] public static extern void DeinitializeOls();
        [DllImport("WinRing0x64.dll", EntryPoint = "Rdmsr")] public static extern bool ReadMsr(uint index, out uint eax, out uint edx);
        [DllImport("WinRing0x64.dll", EntryPoint = "Wrmsr")] public static extern bool WriteMsr(uint index, uint eax, uint edx);

        const uint MSR_FIVR = 0x150;
        const uint MSR_IA32_PERF_CTL = 0x199;
        const uint MSR_TURBO = 0x1A0;

        // =========================================================
        // VARIABLES GLOBALES
        // =========================================================
        private bool servicioActivo = true;
        private bool forzarCierre = false;
        private uint multiplicadorObjetivo = 0;
        private Dictionary<int, PerfilHardware> perfiles = new Dictionary<int, PerfilHardware>();
        private string archivoPerfiles = "pcf_perfiles.json";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            // 1. Iniciar WinRing0
            if (!InitializeOls())
            {
                MessageBox.Show("Error al cargar WinRing0. Por favor, ejecuta PC_F como Administrador y verifica los archivos .dll y .sys.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            // 2. Cargar perfiles guardados
            CargarPerfiles();
            MostrarPerfilEnUI(1);

            // 3. Iniciar Hilos de Segundo Plano
            Task.Run(() => BucleGuardian());
            Task.Run(() => IniciarServidorPipes());
        }

        // =========================================================
        // PIPES: ESCUCHANDO A PLUSCONTROL
        // =========================================================
        private void IniciarServidorPipes()
        {
            while (servicioActivo)
            {
                try
                {
                    using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("PlusControlPipe", PipeDirection.In))
                    {
                        pipeServer.WaitForConnection();
                        using (StreamReader reader = new StreamReader(pipeServer))
                        {
                            string orden = reader.ReadLine();
                            if (!string.IsNullOrEmpty(orden))
                            {
                                ProcesarOrdenCerebro(orden);
                            }
                        }
                    }
                }
                catch { /* Evitar caídas si hay un error de red local */ }
            }
        }

        private void ProcesarOrdenCerebro(string orden)
        {
            // El formato esperado es "PERFIL:1" o "PERFIL:4"
            if (orden.StartsWith("PERFIL:"))
            {
                if (int.TryParse(orden.Split(':')[1], out int idPerfil))
                {
                    // Necesitamos Invoke porque vamos a cambiar la interfaz gráfica desde otro hilo
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (idPerfil == 1) rbPerfil1.Checked = true;
                        if (idPerfil == 2) rbPerfil2.Checked = true;
                        if (idPerfil == 3) rbPerfil3.Checked = true;
                        if (idPerfil == 4) rbPerfil4.Checked = true;

                        AplicarHardware(perfiles[idPerfil]);
                        notifyIcon1.ShowBalloonTip(2000, "PC_F Acción Remota", $"PlusControl aplicó el Perfil {idPerfil}", ToolTipIcon.Info);
                    });
                }
            }
        }

        // =========================================================
        // GESTIÓN DE LA UI Y PERFILES
        // =========================================================
        private int ObtenerPerfilSeleccionado()
        {
            if (rbPerfil1.Checked) return 1;
            if (rbPerfil2.Checked) return 2;
            if (rbPerfil3.Checked) return 3;
            return 4;
        }

        private void CargarPerfiles()
        {
            if (File.Exists(archivoPerfiles))
            {
                string json = File.ReadAllText(archivoPerfiles);
                perfiles = JsonSerializer.Deserialize<Dictionary<int, PerfilHardware>>(json);
            }
            else
            {
                for (int i = 1; i <= 4; i++) perfiles[i] = new PerfilHardware();
            }
        }

        private void MostrarPerfilEnUI(int id)
        {
            if (perfiles.ContainsKey(id))
            {
                var p = perfiles[id];
                numCore.Value = (decimal)p.CoreVolt;
                numCache.Value = (decimal)p.CacheVolt;
                numGpu.Value = (decimal)p.GpuVolt;
                chkTurbo.Checked = p.TurboActivo;
                numMult.Value = p.Multiplicador;
            }
        }

        private void RbPerfil_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null && rb.Checked)
            {
                MostrarPerfilEnUI(ObtenerPerfilSeleccionado());
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            int id = ObtenerPerfilSeleccionado();
            perfiles[id] = new PerfilHardware
            {
                CoreVolt = (double)numCore.Value,
                CacheVolt = (double)numCache.Value,
                GpuVolt = (double)numGpu.Value,
                TurboActivo = chkTurbo.Checked,
                Multiplicador = (uint)numMult.Value
            };

            File.WriteAllText(archivoPerfiles, JsonSerializer.Serialize(perfiles));
            MessageBox.Show($"Perfil {id} guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnAplicar_Click(object sender, EventArgs e)
        {
            int id = ObtenerPerfilSeleccionado();

            var perfilTemporal = new PerfilHardware
            {
                CoreVolt = (double)numCore.Value,
                CacheVolt = (double)numCache.Value,
                GpuVolt = (double)numGpu.Value,
                TurboActivo = chkTurbo.Checked,
                Multiplicador = (uint)numMult.Value
            };

            perfiles[id] = perfilTemporal;
            AplicarHardware(perfilTemporal);
        }

        // =========================================================
        // HARDWARE Y ANILLO 0
        // =========================================================
        private void AplicarHardware(PerfilHardware p)
        {
            EscribirFivr(0, p.CoreVolt);
            EscribirFivr(2, p.CacheVolt);
            EscribirFivr(1, p.GpuVolt);

            CambiarTurbo(p.TurboActivo);

            multiplicadorObjetivo = p.Multiplicador;
            if (multiplicadorObjetivo == 0)
            {
                if (ReadMsr(MSR_IA32_PERF_CTL, out uint eax, out uint edx))
                {
                    uint eaxFinal = (eax & 0xFFFF00FF) | (31u << 8); // 31x max
                    WriteMsr(MSR_IA32_PERF_CTL, eaxFinal, edx);
                }
            }
        }

        private void EscribirFivr(uint plane, double offsetMv)
        {
            int offsetMatematico = (int)Math.Round(offsetMv * 1.024);
            uint offsetBits = (uint)offsetMatematico & 0x7FF;
            uint eaxEscribir = offsetBits << 21;
            uint edxEscribir = 0x80000011 | (plane << 8);
            WriteMsr(MSR_FIVR, eaxEscribir, edxEscribir);
            Thread.Sleep(5);
        }

        private void CambiarTurbo(bool encender)
        {
            if (ReadMsr(MSR_TURBO, out uint eax, out uint edx))
            {
                uint edxNuevo = encender ? (edx & ~(1u << 6)) : (edx | (1u << 6));
                WriteMsr(MSR_TURBO, eax, edxNuevo);
            }
        }

        private void BucleGuardian()
        {
            while (servicioActivo)
            {
                if (multiplicadorObjetivo > 0)
                {
                    if (ReadMsr(MSR_IA32_PERF_CTL, out uint eax, out uint edx))
                    {
                        uint eaxFinal = (eax & 0xFFFF00FF) | (multiplicadorObjetivo << 8);
                        WriteMsr(MSR_IA32_PERF_CTL, eaxFinal, edx);
                    }
                }
                Thread.Sleep(100);
            }
        }

        // =========================================================
        // MONITOREO EN TIEMPO REAL (UI DINÁMICA)
        // =========================================================
        private void TimerMonitor_Tick(object sender, EventArgs e)
        {
            Color colorActivo = Color.FromArgb(0, 190, 255); // Azul Cian Neón
            Color colorInactivo = Color.LightGray;

            double core = LeerFivr(0);
            lblCurrentCore.Text = $"Core: {core:F1} mV";
            lblCurrentCore.ForeColor = core < 0 ? colorActivo : colorInactivo;

            double cache = LeerFivr(2);
            lblCurrentCache.Text = $"Cache: {cache:F1} mV";
            lblCurrentCache.ForeColor = cache < 0 ? colorActivo : colorInactivo;

            double gpu = LeerFivr(1);
            lblCurrentGpu.Text = $"GPU: {gpu:F1} mV";
            lblCurrentGpu.ForeColor = gpu < 0 ? colorActivo : colorInactivo;

            bool turbo = LeerTurbo();
            lblCurrentTurbo.Text = $"Turbo: {(turbo ? "ACTIVO" : "APAGADO")}";
            lblCurrentTurbo.ForeColor = turbo ? colorActivo : Color.Gray;

            uint mult = LeerMultiplicador();
            lblCurrentMult.Text = $"Freq: {mult}x ({(mult / 10.0):F1} GHz)";
            lblCurrentMult.ForeColor = mult > 0 ? Color.White : colorInactivo;
        }

        private double LeerFivr(uint plane)
        {
            uint edxLeer = 0x80000010 | (plane << 8);
            WriteMsr(MSR_FIVR, 0, edxLeer);
            Thread.Sleep(2);
            if (ReadMsr(MSR_FIVR, out uint eax, out uint edx))
            {
                int offsetBits = (int)((eax >> 21) & 0x7FF);
                if ((offsetBits & 0x400) != 0) offsetBits = offsetBits - 2048;
                return offsetBits / 1.024;
            }
            return 0;
        }

        private bool LeerTurbo()
        {
            if (ReadMsr(MSR_TURBO, out uint eax, out uint edx))
            {
                return (edx & (1u << 6)) == 0;
            }
            return true;
        }

        private uint LeerMultiplicador()
        {
            if (ReadMsr(MSR_IA32_PERF_CTL, out uint eax, out uint edx))
            {
                return (eax >> 8) & 0xFF;
            }
            return 0;
        }

        // =========================================================
        // BANDEJA DEL SISTEMA (TRAY ICON) Y CIERRE
        // =========================================================
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !forzarCierre)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon1.ShowBalloonTip(1500, "PC_F Minimizado", "El motor sigue controlando el hardware en segundo plano.", ToolTipIcon.Info);
            }
            else
            {
                servicioActivo = false;
                DeinitializeOls();
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MenuMostrar_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MenuSalir_Click(object sender, EventArgs e)
        {
            forzarCierre = true;
            Application.Exit();
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Linq;
using FireSharp.Config;
using FireSharp.Interfaces;
using System.Threading.Tasks;


namespace WEBCAM
{
    public partial class WEBCAM_RECFACE : MaterialSkin.Controls.MaterialForm
    {

        //Variável pública para validadar detecção
        public bool valid = false;
        public bool Detectado;
        private int frameCount = 0;
        private const int processEveryNFrames = 5;
        private readonly object bitmapLock = new object(); 
        public Timer countdownTimer;
        public int countdownValue = 3;
        private bool isValidating = false;
        public WEBCAM_RECFACE()
        {
            InitializeComponent();
            //TimeStart();
            Verificador();
        }

        public void Verificador()
        {
            var quantidadeLog = Directory.GetFiles(@"C:\TESTES_AVELL\logs_webcam", "*.log", SearchOption.TopDirectoryOnly).Count().ToString();
            int valor = int.Parse(quantidadeLog);
            if (valor < 2)
            {
                //Interacao();
                         TimeStart();
                lblTime.Text = "Aguardando o Reconhecimento...";
            }
            else if (valor > 1)
            {
                using (ENVIAREPARO formEnviarReparo = new ENVIAREPARO())
                {
                    this.Hide();
                    formEnviarReparo.ShowDialog();
                }
            }
        }

        FilterInfoCollection filter;
        VideoCaptureDevice device;

        private void WEBCAM_RECFACE_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filter)
                cboDevice.Items.Add(device.Name);
            cboDevice.SelectedIndex = 0;
            device = new VideoCaptureDevice();
            Aciona();
        }

        public void Aciona()
        {
            device = new VideoCaptureDevice(filter[cboDevice.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }

        public void Interacao()
        {
            WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.URL = @"C:\TESTES_AVELL\audiofilesAlertas\WebCamReconhecimento.mp3";
            wplayer.controls.play();
        }

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Captura a imagem do frame atual
            Bitmap bitmap;
            lock (bitmapLock)
            {
                bitmap = (Bitmap)eventArgs.Frame.Clone(); // Clonando o frame para evitar conflitos
            }

            // Atualiza a imagem no PictureBox a cada frame
            pic.Image = bitmap;

            // Incrementa o contador de frames
            frameCount++;

            // Apenas processa a imagem a cada N frames
            if (frameCount % processEveryNFrames == 0)
            {
                Task.Run(() =>
                {
                    Bitmap processedBitmap;
                    lock (bitmapLock)
                    {
                        processedBitmap = (Bitmap)bitmap.Clone(); // Clonando novamente para processamento
                    }

                    try
                    {
                        Image<Bgr, byte> grayImage = processedBitmap.ToImage<Bgr, byte>();
                        Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);

                        // Executa a atualização da imagem e da label na thread principal
                        Invoke(new Action(() =>
                        {
                            if (rectangles.Length > 0 && !valid)
                            {
                                using (Graphics graphics = Graphics.FromImage(processedBitmap))
                                {
                                    using (Pen pen = new Pen(Color.Orange, 3))
                                    {
                                        foreach (Rectangle rectangle in rectangles)
                                        {
                                            graphics.DrawRectangle(pen, rectangle);
                                        }
                                    }
                                }

                                Detectado = true;
                                valid = true;
                                lblTime.Text = "Esperando...";
                                lblTime.ForeColor = Color.Red;
                                lblTime.Font = new Font(lblTime.Font, FontStyle.Bold);
                            }
                            else if(valid)
                            {
                        //        valid = false; // Permitir nova detecção
                                lblTime.Text = "IDENTIFICADO";
                                lblTime.ForeColor = Color.Green;
                                lblTime.Font = new Font(lblTime.Font, FontStyle.Regular);
                                // Aguardar 3 segundos antes de chamar ValidaOK
                                Task.Run(async () =>
                                {
                                    await Task.Delay(3000); // Aguardar 3 segundos
                                    Invoke(new Action(() =>
                                    {
                                        ValidaOK(); // Chamar a função ValidaOK na thread principal
                                    }));
                                });

                            }

                            // Atualiza a imagem com o desenho do retângulo
                    //        pic.Image = processedBitmap; // Atualiza a imagem com o desenho
                        }));
                    }
                    catch (Exception ex)
                    {
                        // Erro no processamento
                        Invoke(new Action(() =>
                        {
                            MessageBox.Show("Apresentou erros no teste: " + ex.Message);
                        }));
                    }
                });
            }
        }

        private void StopDevice()
        {
            if (device != null && device.IsRunning)
            {
                device.SignalToStop();
                device.WaitForStop();
                device.NewFrame -= Device_NewFrame; // Desassocia o evento
                device = null; // Limpa a referência
            }
        }



         private void WEBCAM_RECFACE_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
                device.Stop();
        }

        public void TimeStart()
        {
            Timer relogio = new Timer();
            relogio.Interval = 1000;
            int tempo = 8;

            relogio.Tick += delegate
            {
                tempo -= 1;
                lblTime.Text = tempo.ToString();
                if (tempo == 0)
                {
                    try
                    {
                        relogio.Stop();
                        ValidaOK();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Não foi possivel capturar Imagem" + ex);
                    }
                }
            };
            relogio.Start();
        }

        public void ValidaOK()
        {
            if (Detectado == true)
            {

                if (isValidating) return;
                isValidating = true; // Marque que a validação está em andamento
                StopDevice(); // Para a captura e desassocia o evento
                VALIDARECFACIAL formValidaRecFace = new VALIDARECFACIAL();
                this.Hide();
                formValidaRecFace.ShowDialog();
            }
            if (Detectado != true)
            {
                REPROVAFALHA formReprovaFalha = new REPROVAFALHA();
                this.Hide();
                formReprovaFalha.ShowDialog();
            }
        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Para a captura de frames e desassocia o evento
            StopDevice();
            ENVIAREPARO formReparo = new ENVIAREPARO();
            this.Hide();
            formReparo.ShowDialog();
        }
    }
}

using ShowCase.Sig.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShowCaseUtil;
using System.Diagnostics;
using Exchange.Contracts.Services;
using System.Threading;
using System.Drawing.Imaging;

namespace ShowCase.Sig
{
    public partial class frmSignature : Form
    {

        private string msInfoLabel = "Signee Name";
        private Font _sigFont = new Font("Verdana", 12f, System.Drawing.FontStyle.Regular);
        private Bitmap mbmsignhere = null;
        private int miSigPadWidth = 240;

        private const int SIG_WIDTH = 280;
        private const int SIG_HEIGHT = 100;

        private SignatureService _signatureService;

        public string[] WaivedSignatureReasons { get; set; }


        public frmSignature()
        {
            InitializeComponent();

            SignatureService.OnSignatureRequest += _signatureService_OnSignatureRequest;
            _signatureService = new SignatureService();
            _signatureService.StartService();

        }

        private void frmSignature_Load(object sender, EventArgs e)
        {
            if (IAmRunning())
            {
                MessageBox.Show("The Signature process is already running", "ShowCase.Signature", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            string singHereFile = Application.StartupPath + "\\signhere.bmp";
            
            if (File.Exists(singHereFile))
                mbmsignhere = new Bitmap(singHereFile);
            else
                mbmsignhere = Resources.PBsignhere;

            miSigPadWidth = mbmsignhere.Width;

            lblInfo.Text = msInfoLabel;

            LoadWaiverReasons();           

            //btnGetSignature_Click(sender, null);
       }

        private byte[] _signatureService_OnSignatureRequest(string signeeName, string[] waivers)
        {
            Logger.Log("Signature Request: " + signeeName);
            //validate request
            
            //_syncContext.Post(d => 
            //{
            //    //make form visible
            //    this.Show();
                
            //}, signeeName);

            this.Invoke(new Action(() =>
            {
                msInfoLabel = signeeName;
                lblInfo.Text = signeeName;

                WaivedSignatureReasons = waivers;

                LoadWaiverReasons();

                this.Show();
                this.WindowState = FormWindowState.Normal;

                btnGetSignature_Click(this, null);
            }));

            do
            {
                //await Task.Delay(1000);
                Logger.Log("Waiting for signature...");
                Thread.Sleep(3000);
            }
            while (pictureBox1.Image == null);

            Logger.Log("Signature captured");
            var s = new MemoryStream();
            pictureBox1.Image.Save(s, ImageFormat.Bmp);

            return s.ToArray();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            btnAccept.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (SigPlusNET1.TabletConnectQuery())
            {
                SigPlusNET1.SetTabletComTest(0);
                SigPlusNET1.SetTabletState(0);

                SigPlusNET1.SetTabletComTest(1);
                SigPlusNET1.SetTabletState(1);
                //open port, turn tablet on
                SigPlusNET1.ClearTablet();
            }
            //this.WindowState = FormWindowState.Minimized;
            this.Hide();
            btnGetSignature.Enabled = true;
        }       

        private void btnGetSignature_Click(object sender, EventArgs e)
        {
            try
            {
                SigPlusNET1.SetTabletComTest(1);
                SigPlusNET1.SetTabletState(1);
                //open port, turn tablet on

                while ((!SigPlusNET1.TabletConnectQuery() || SigPlusNET1.GetTabletState() != 1))
                {
                    if (MessageBox.Show("Cannot locate signature pad. Please make sure it is connected.", "Cannot locate signature pad", System.Windows.Forms.MessageBoxButtons.RetryCancel, System.Windows.Forms.MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                    {
                        //Continue, turn off test
                        SigPlusNET1.SetTabletComTest(0);
                        return;
                    }
                    else
                    {
                        //Max 08/31/2016 - We must reset the TabletCom and TabletState to zero which is the original state before retryning setting it to 1
                        SigPlusNET1.SetTabletComTest(0);
                        SigPlusNET1.SetTabletState(0);

                        SigPlusNET1.SetTabletComTest(1);
                        SigPlusNET1.SetTabletState(1);
                        //open port, turn tablet on
                        SigPlusNET1.ClearTablet();
                        //Clears the SigPlus object of ink
                    }
                }

                //Continue, turn off test
                SigPlusNET1.SetTabletComTest(0);
                SigPlusNET1.ClearTablet();
                //Clears the SigPlus object of ink

                btnGetSignature.Enabled = false;

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }

                btnAccept.Enabled = false;
                SigPlusNET1.BringToFront();
                this.Refresh();

                if (this.miSigPadWidth == 640)
                {
                    //******************************************************************'
                    // The following parameters are set in case the user's INI file is not correctly set up for an LCD 4X3 tablet
                    // Otherwise, if the INI is correctly set up, these parameters do not need to be set

                    SigPlusNET1.SetTabletXStart(300);
                    SigPlusNET1.SetTabletXStop(2370);
                    SigPlusNET1.SetTabletYStart(350);
                    SigPlusNET1.SetTabletYStop(1950);
                    SigPlusNET1.SetTabletLogicalXSize(2070);
                    SigPlusNET1.SetTabletLogicalYSize(1600);

                    SigPlusNET1.LCDSetWindow(0, 0, 1, 1);
                    //Prohibit inking on entire LCD
                    SigPlusNET1.SetSigWindow(1, 0, 0, 1, 1);
                    //Prohibit inking in SigPlus
                    SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);
                    //Refresh entire tablet


                    SigPlusNET1.SetLCDCaptureMode(2);


                    //Dim bmSignHere As New Bitmap(mbmsignhere)
                    //Dim myGR As Graphics = Graphics.FromImage(bmSignHere)
                    //Dim drawFont As Font = New System.Drawing.Font("Arial", 16.0F, System.Drawing.FontStyle.Bold)
                    //Dim drawBrush As New SolidBrush(Color.Black)
                    //Dim drawPoint As New PointF(0.0F, 0.0F)
                    //myGR.DrawString(msInfoLabel, drawFont, drawBrush, drawPoint)

                    SigPlusNET1.LCDSetPixelDepth(8);

                    SigPlusNET1.LCDSendGraphic(0, 2, 0, 0, mbmsignhere);
                    //this BMP is loaded into background

                    //SigPlusNET1.LCDRefresh(2, 0, 0, 240, 128) 'sets the BMP in the background
                    //to the foreground--note the initial argument 2

                    //Harish Ramakrishnan 05/15/2010
                    SigPlusNET1.LCDSetPixelDepth(0);
                    SigPlusNET1.LCDWriteString(0, 2, 0, 430, _sigFont, msInfoLabel);

                    SigPlusNET1.LCDSetPixelDepth(8);
                    Bitmap objBitmap = new Bitmap(640, 2);
                    Graphics objGraphic = Graphics.FromImage(objBitmap);
                    Pen blackPen = new Pen(Color.Black, 1);
                    objGraphic.DrawLine(blackPen, new Point(5, 1), new Point(630, 195));
                    SigPlusNET1.LCDSendGraphic(1, 2, 0, 428, objBitmap);
                    SigPlusNET1.LCDRefresh(2, 0, 428, 640, 2);
                    SigPlusNET1.LCDSetPixelDepth(0);

                    SigPlusNET1.LCDWriteString(0, 2, 20, 290, _sigFont, "CLEAR");
                    SigPlusNET1.LCDWriteString(0, 2, 400, 290, _sigFont, "OK");

                    SigPlusNET1.KeyPadAddHotSpot(0, 1, 0, 280, 150, 30);
                    SigPlusNET1.KeyPadAddHotSpot(1, 1, 350, 280, 100, 30);

                    //Dim label As Font
                    //label = New System.Drawing.Font("Arial", 16.0F, System.Drawing.FontStyle.Regular)
                    //SigPlusNET1.SetTabletState(1)
                    //SigPlusNET1.LCDWriteString(0, 2, 4, 0, label, msInfoLabel)
                    SigPlusNET1.LCDRefresh(2, 0, 313, 640, 115);
                    SigPlusNET1.LCDSetWindow(0, 313, 640, 115);
                    SigPlusNET1.SetSigWindow(1, 0, 313, 640, 115);
                    //SigPlusNET1.LCDSetWindow(0, 74, 240, 54) 'Permits only the section on LCD
                    //to display ink
                    //SigPlusNET1.SetSigWindow(1, 0, 68, 240, 60)
                    //specifies area in sigplus object to accept ink
                }
                else
                {
                    throw new Exception("Signature pad resolution is not supported");
                }

                //Timer1.Enabled = true;

            }
            catch (Exception ex)
            {
                Logger.LogError("Error reading the signature image from SigPlusNET", ex);
            }
        }

        private void frmSignature_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBox1 != null)
                pictureBox1.Dispose();

            if (mbmsignhere != null)
                mbmsignhere.Dispose();

            if (_signatureService != null)
                _signatureService.Dispose();

            if (SigPlusNET1 != null)
                SigPlusNET1.Dispose();
        }

        private bool IAmRunning()
        {
            foreach(var p in Process.GetProcesses())
            {
                if (p.ProcessName == Process.GetCurrentProcess().ProcessName && p.Id != Process.GetCurrentProcess().Id)
                {
                    Logger.Log("ShowCase.Sig is already running");
                    return true;
                }
            }
            return false;
        }

        private void LoadWaiverReasons()
        {
            if (WaivedSignatureReasons != null && WaivedSignatureReasons.Length > 0)
            {
                gbWaiver.Visible = true;

                foreach (string wr in WaivedSignatureReasons)
                {
                    cbWaiverReason.Items.Add(wr);
                }
            }
            else
            {
                //Hide entire group box
                gbWaiver.Visible = false;
            }
        }

        private void SigPlusNET1_PenUp(object sender, EventArgs e)
        {
            if (SigPlusNET1.KeyPadQueryHotSpot(1) > 0)
            {
                //OK
                if (SigPlusNET1.NumberOfTabletPoints() > 0)
                {
                    // strSig = SigPlusNET1.GetSigString() 'strSig now holds signature
                    SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);
                    //Clears entire LCD screen
                    Font thankyou = default(Font);
                    thankyou = new System.Drawing.Font("Arial", 16f, System.Drawing.FontStyle.Regular);
                    SigPlusNET1.SetTabletState(1);
                    SigPlusNET1.LCDWriteString(0, 2, 4, 40, thankyou, "Thank You For Signing!");
                    //Greeting after signing

                    //SigPlusNET1.LCDSendGraphic(0, 2, 58, 90, topazlogo)
                    SigPlusNET1.SetTabletState(0);
                    //turn off tablet to use justification below
                    SigPlusNET1.SetJustifyMode(5);
                    //this will zoom signature & justify to center
                    //Dim s = SigPlusNET1.GetSigString()

                    SigPlusNET1.SetImageXSize(10);
                    SigPlusNET1.SetImageYSize(10);

                    pictureBox1.Image = SigPlusNET1.GetSigImage();
                    btnAccept.Enabled = true;
                    SigPlusNET1.SendToBack();
                }
            }

            if (SigPlusNET1.KeyPadQueryHotSpot(0) > 0)
            {
                //CLEAR

            }

        }

        private void frmSignature_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!SigPlusNET1.TabletConnectQuery())
                    return;

                SigPlusNET1.SetTabletState(1);

                bool checksumReceived = false;
                if (miSigPadWidth == 640)
                    checksumReceived = SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);
                else
                    checksumReceived = SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);

                if (checksumReceived)
                {
                    SigPlusNET1.SetLCDCaptureMode(1);
                    SigPlusNET1.SetTabletState(0);
                }
            }
            catch
            { }
        }

        private void frmSignature_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch(e.ClickedItem.Text)
            {
                case "Exit":
                    this.Close();
                    break;
                case "Restore":
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void frmSignature_ResizeEnd(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipText = "ShowCase Signature";
        }
    }
}

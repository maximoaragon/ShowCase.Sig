using ShowCase.Sig.Properties;
using ShowCaseUtil;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ShowCase.Sig
{
    public partial class frmSignature : Form
    {
        private string msInfoLabel = "Signee Name";
        private string _waiverReason = "";
        private Font _sigFont = new Font("Verdana", 12f, FontStyle.Regular);
        private Bitmap mbmsignhere = null;
        private Image _signatureImage;

        private bool _clientConnected;

        private int miSigPadWidth = 240;
        private const int SIG_WIDTH = 280;
        private const int SIG_HEIGHT = 100;

        private SignatureService _signatureService;

        private readonly static object _lock = new object();

        public frmSignature()
        {
            InitializeComponent();

            if (IAmRunning())
                Environment.Exit(-1);//exit silently
            else
            {
                SignatureService.OnSignatureRequest += signatureService_OnSignatureRequest;
                _signatureService = new SignatureService();
                _signatureService.StartService();
            }
        }

        private void frmSignature_Load(object sender, EventArgs e)
        {
            //if (IAmRunning())
            //{
            //    MessageBox.Show("The Signature process is already running", "ShowCase.Signature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Application.Exit();
            //    return;
            //}

            //ScheduledACrash();

            string singHereFile = Application.StartupPath + "\\signhere.bmp";
            
            if (File.Exists(singHereFile))
                mbmsignhere = new Bitmap(new MemoryStream(File.ReadAllBytes(singHereFile)));// Use memory stream to prevent locking the file
                //mbmsignhere = new Bitmap(singHereFile);
            else
                mbmsignhere = Resources.PBsignhere;

            miSigPadWidth = mbmsignhere.Width;

            gbWaiver.Visible = false;
            lblInfo.Text = msInfoLabel;

            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (arg == "-r")
                {
                    MessageBox.Show("The signature did not save. Please get the signature again.", "ShowCase Signature", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string signatureService_OnSignatureRequest(string signeeName, string[] waivers)
        {
            _clientConnected = true;
            Logger.Log("Signature Request: " + signeeName);

            try
            {
                //this will arrive in a worker thread
                this.Invoke(new Action(() =>
                {
                    lock (_lock)
                    {
                        msInfoLabel = signeeName;
                        lblInfo.Text = signeeName;

                        LoadWaiverReasons(waivers);

                        //this.TopLevel = true;
                        //this.TopMost = true;

                        this.Show();
                        this.Refresh();

                        btnGetSignature_Click(this, null);
                    }
                }));

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["ScheduleACrash"]))
                    ScheduledACrash();

                do
                {
                    Logger.Log("Waiting for signature...", LogLevel.Verbose);
                    Thread.Sleep(3000); //this is already a worker thread so we are good waiting
                }
                while (DialogResult == DialogResult.None);

                switch (this.DialogResult)
                {
                    case DialogResult.OK:
                        Logger.Log("Signature captured/waived");
                        this.DialogResult = DialogResult.None;

                        string response = "";

                        if (cbWaive.Checked) //Waived
                        {
                            //response = cbWaiverReason.Text;
                            response = _waiverReason;
                        }
                        else if (_signatureImage != null)
                        {
                            response = Path.ChangeExtension(Path.GetTempFileName(), ".bmp");
                            _signatureImage.Save(response, ImageFormat.Bmp);
                            _signatureImage.Dispose();
                            _signatureImage = null;
                        }                                               

                        return response;

                    case DialogResult.Cancel:
                        Logger.Log("Signature cancelled");
                        this.DialogResult = DialogResult.None;

                        return null; //user cancelled
                }
            }
            catch(Exception ex)
            {
                Logger.LogError("OnSignatureRequest Error", ex);
            }
            finally
            {
                _clientConnected = false;
                ClearAndHide();
            }
            return null;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (cbWaive.Checked)
                _waiverReason = cbWaiverReason.Text;

            if (_clientConnected)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.None;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_clientConnected)
                this.DialogResult = DialogResult.Cancel;
            else
                this.DialogResult = DialogResult.None;

            ClearAndHide();           
        }       

        private void btnGetSignature_Click(object sender, EventArgs e)
        {
            try
            {
                SigPlusNET1.SetTabletComTest(1);
                if (SigPlusNET1.GetTabletState() != 1)
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
                        if (SigPlusNET1.GetTabletState() != 0)
                            SigPlusNET1.SetTabletState(0);

                        SigPlusNET1.SetTabletComTest(1);
                        if (SigPlusNET1.GetTabletState() != 1)
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

                if (_signatureImage != null)
                {
                    _signatureImage.Dispose();
                    _signatureImage = null;
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
            }
            catch (Exception ex)
            {
                Logger.LogError("Error reading the signature image from SigPlusNET", ex);
            }
        }

        private void frmSignature_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_signatureImage != null)
                _signatureImage.Dispose();

            if (mbmsignhere != null)
                mbmsignhere.Dispose();

            if (_signatureService != null)
                _signatureService.Dispose();

            if (SigPlusNET1 != null)
                SigPlusNET1.Dispose();
        }

        private static bool IAmRunning()
        {
            Process showCaseSigProc = Process.GetCurrentProcess();

            foreach (Process p in Process.GetProcesses())
            {
                if (p.ProcessName == showCaseSigProc.ProcessName && p.Id != showCaseSigProc.Id)
                {
                    Logger.Log("ShowCase.Sig is already running");
                    return true;
                }
            }
            return false;
        }

        private void LoadWaiverReasons(string[] waivers)
        {
            cbWaiverReason.Items.Clear();

            if (waivers != null && waivers.Length > 0)
            {
                gbWaiver.Visible = true;

                foreach (string wr in waivers)
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

        private void ClearAndHide()
        {
            _waiverReason = "";

            if (SigPlusNET1.TabletConnectQuery())
            {
                //clear screen
                bool checksumReceived = SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);

                SigPlusNET1.SetTabletComTest(0);
                if (SigPlusNET1.GetTabletState() != 0)
                    SigPlusNET1.SetTabletState(0);

                SigPlusNET1.SetTabletComTest(1);
                if (SigPlusNET1.GetTabletState() != 1)
                    SigPlusNET1.SetTabletState(1);
                SigPlusNET1.ClearTablet();
            }

            var uiActions = new Action(() =>
            {
                lblInfo.Text = "";
                btnGetSignature.Enabled = true;
                btnAccept.Enabled = false;
                
                gbWaiver.Visible = false;
                cbWaive.Checked = false;
                cbWaiverReason.Items.Clear();
                cbWaiverReason.Text = "";
                
                this.Hide();
            });

            if (this.InvokeRequired)
                this.Invoke(uiActions);
            else
            {
                uiActions();
            }              
        }

        private void SigPlusNET1_PenUp(object sender, EventArgs e)
        {
            if (SigPlusNET1.KeyPadQueryHotSpot(1) > 0)
            {
                //OK
                if (SigPlusNET1.NumberOfTabletPoints() > 0)
                {
                    Focus();
                    // strSig = SigPlusNET1.GetSigString() 'strSig now holds signature
                    SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);
                    //Clears entire LCD screen
                    Font thankyou = default(Font);
                    thankyou = new System.Drawing.Font("Arial", 16f, System.Drawing.FontStyle.Regular);

                    if (SigPlusNET1.GetTabletState() != 1)
                        SigPlusNET1.SetTabletState(1);

                    SigPlusNET1.LCDWriteString(0, 2, 4, 40, thankyou, "Thank You For Signing!");
                    //Greeting after signing

                    //SigPlusNET1.LCDSendGraphic(0, 2, 58, 90, topazlogo)
                    if (SigPlusNET1.GetTabletState() != 0)
                        SigPlusNET1.SetTabletState(0);
                    //turn off tablet to use justification below
                    SigPlusNET1.SetJustifyMode(5);

                    //this will zoom signature & justify to center
                    SigPlusNET1.SetImageXSize(SIG_WIDTH);
                    SigPlusNET1.SetImageYSize(SIG_HEIGHT);

                    _signatureImage = SigPlusNET1.GetSigImage();
                    
                    SigPlusNET1.SendToBack();

                    btnAccept.Enabled = true;
                    btnGetSignature.Enabled = true;
                }
                return;
            }

            if (SigPlusNET1.KeyPadQueryHotSpot(0) > 0)
            {
                this.TopLevel = true;
                this.TopMost = true;

                //CLEAR
                SigPlusNET1.ClearSigWindow(1);
                SigPlusNET1.ClearTablet();
                SigPlusNET1.LCDRefresh(1, 0, 280, 150, 30);
                Thread.Sleep(250);
                SigPlusNET1.LCDRefresh(2, 0, 313, 640, 115);
                SigPlusNET1.LCDRefresh(1, 0, 280, 150, 30);

                if (SigPlusNET1.GetTabletState() != 1)
                    SigPlusNET1.SetTabletState(1);

                return;
            }
        }

        private void frmSignature_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!SigPlusNET1.TabletConnectQuery())
                    return;

                if (SigPlusNET1.GetTabletState() != 1)
                    SigPlusNET1.SetTabletState(1);

                bool checksumReceived = false;

                //if (miSigPadWidth == 640)
                //    checksumReceived = SigPlusNET1.LCDRefresh(0, 0, 0, 640, 480);
                //else
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
        }

        private void cbWaiverReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAccept.Enabled = cbWaiverReason.Text.Length > 0;
        }

        private void cbWaiverReason_KeyUp(object sender, KeyEventArgs e)
        {
            btnAccept.Enabled = cbWaiverReason.Text.Length > 0;
        }

        private void cbWaive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWaive.Checked)
            {
                cbWaiverReason.Enabled = true;
                btnAccept.Enabled = true;
            }
            else
            {
                cbWaiverReason.Enabled = false;
                btnAccept.Enabled = false;
            }
            btnAccept.Enabled = cbWaiverReason.Text.Length > 0;
        }

        private void ScheduledACrash()
        {
            ThreadStart threadDelegate = new ThreadStart(() =>
            {
                Thread.Sleep(10000);
                throw new Exception(":-(");
            });
            Thread newThread = new Thread(threadDelegate);
            newThread.Start();
        }
    }
}

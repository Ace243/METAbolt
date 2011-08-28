//  Copyright (c) 2008 - 2011, www.metabolt.net (METAbolt)
//  Copyright (c) 2006-2008, Paul Clement (a.k.a. Delta)
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright notice, 
//    this list of conditions and the following disclaimer in the documentation 
//    and/or other materials provided with the distribution. 

//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
//  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
//  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//  IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
//  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
//  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
//  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
//  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
//  POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OpenMetaverse;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using System.Timers;
using ExceptionReporting;
using System.Globalization;


namespace METAbolt
{
    public partial class frmDebugLog : Form
    {
        private METAboltInstance instance;
        private GridClient client;

        private System.Timers.Timer aTimer1;
        private NetworkTraffic networkTraffic = new NetworkTraffic();
        //private double ins = 0.0d;
        //private double iny = 0.0d;

        //float pastval1 = 0f;
        //float pastval2 = 0f;

        //Workaround for window handle exception on login
        private List<DebugLogMessage> initQueue = new List<DebugLogMessage>();

        private ExceptionReporter reporter = new ExceptionReporter();

        internal class ThreadExceptionHandler
        {
            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {
                ExceptionReporter reporter = new ExceptionReporter();
                reporter.Show(e.Exception);
            }
        }

        public frmDebugLog(METAboltInstance instance)
        {
            InitializeComponent();

            this.Disposed += new EventHandler(frmDebugLog_Disposed);

            SetExceptionReporter();
            Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException;

            this.instance = instance;
            //netcom = this.instance.Netcom;
            client = this.instance.Client;
            AddClientEvents();

            this.dataChart3.BackColor = System.Drawing.Color.Black;
            this.dataChart3.ChartType = SystemMonitor.ChartType.Line;
            //this.dataChart2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataChart3.GridColor = System.Drawing.Color.Green;
            //this.dataChart2.GridPixels = 8;
            this.dataChart3.InitialHeight = 300;
            this.dataChart3.LineColor = System.Drawing.Color.White;
        }

        private void SetExceptionReporter()
        {
            reporter.Config.ShowSysInfoTab = false;   // alternatively, set properties programmatically
            reporter.Config.ShowFlatButtons = true;   // this particular config is code-only
            reporter.Config.CompanyName = "METAbolt";
            reporter.Config.ContactEmail = "metabolt@vistalogic.co.uk";
            reporter.Config.EmailReportAddress = "metabolt@vistalogic.co.uk";
            reporter.Config.WebUrl = "http://www.metabolt.net/metaforums/";
            reporter.Config.AppName = "METAbolt";
            reporter.Config.MailMethod = ExceptionReporting.Core.ExceptionReportInfo.EmailMethod.SimpleMAPI;
            reporter.Config.BackgroundColor = Color.White;
            reporter.Config.ShowButtonIcons = false;
            reporter.Config.ShowLessMoreDetailButton = true;
            reporter.Config.TakeScreenshot = true;
            reporter.Config.ShowContactTab = true;
            reporter.Config.ShowExceptionsTab = true;
            reporter.Config.ShowFullDetail = true;
            reporter.Config.ShowGeneralTab = true;
            reporter.Config.ShowSysInfoTab = true;
            reporter.Config.TitleText = "METAbolt Exception Reporter";
        }

        private void frmDebugLog_Disposed(object sender, EventArgs e)
        {
            Logger.OnLogMessage -= new Logger.LogCallback(client_OnLogMessage);
        }

        private void AddClientEvents()
        {
            Logger.OnLogMessage += new Logger.LogCallback(client_OnLogMessage);
        }

        //comes in on separate thread
        private void client_OnLogMessage(object message, Helpers.LogLevel level)
        {
            try
            {
                if (this.IsHandleCreated)
                    BeginInvoke(new Logger.LogCallback(ReceivedLogMessage), new object[] { message, level });
                else
                    initQueue.Add(new DebugLogMessage((string)message, level, DateTime.Now));
            }
            catch { ; }
        }

        //called on GUI thread
        private void ReceivedLogMessage(object message, Helpers.LogLevel level)
        {
            try
            {
                RichTextBox rtb = null;

                switch (level)
                {
                    case Helpers.LogLevel.Info:
                        rtb = rtbInfo;
                        break;

                    case Helpers.LogLevel.Warning:
                        rtb = rtbWarning;
                        break;

                    case Helpers.LogLevel.Error:
                        rtb = rtbError;
                        break;

                    case Helpers.LogLevel.Debug:
                        rtb = rtbDebug;
                        break;
                }

                string msg = (string)message;
                if (msg.Contains("ParticipantUpdatedEvent")) return;

                rtb.AppendText("[" + DateTime.Now.ToString() + "] " + msg + "\n");
            }
            catch (Exception ex)
            {
                Logger.Log("Logger error on receiving Log message: " + ex.Message, Helpers.LogLevel.Error);
            }
        }

        private void ReceivedLogMessage(object message, Helpers.LogLevel level, DateTime dte)
        {
            try
            {
                RichTextBox rtb = null;

                switch (level)
                {
                    case Helpers.LogLevel.Info:
                        rtb = rtbInfo;
                        break;

                    case Helpers.LogLevel.Warning:
                        rtb = rtbWarning;
                        break;

                    case Helpers.LogLevel.Error:
                        rtb = rtbError;
                        break;

                    case Helpers.LogLevel.Debug:
                        rtb = rtbDebug;
                        break;
                }

                string msg = (string)message;
                if (msg.Contains("ParticipantUpdatedEvent")) return;

                rtb.AppendText("[" + dte.ToString() + "] " + msg + "\n");
            }
            catch (Exception ex)
            {
                Logger.Log("Logger error on receiving Log message: " + ex.Message, Helpers.LogLevel.Error);
            }
        }

        private void ProcessLogMessage(DebugLogMessage logMessage)
        {
            try
            {
                ReceivedLogMessage(logMessage.Message, logMessage.Level, logMessage.TimeStamp);
            }
            catch { ; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (button5.Enabled)
            {
                button5.PerformClick();
            }

            Hide();
        }

        private void frmDebugLog_Shown(object sender, EventArgs e)
        {
            try
            {
                if (initQueue.Count > 0)
                    foreach (DebugLogMessage msg in initQueue) ProcessLogMessage(msg);
            }
            catch { ; }
        }

        private void frmDebugLog_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // this should be put into a class of it's own
            // in the future.

            rtBox1.Text = string.Empty;

            try
            {
                rtBox1.Text = "Local Host" + "\n";
                string localHostName = Dns.GetHostName();
                rtBox1.Text += "\tHost Name:          " + localHostName + "\n";

                PrintHostInfo(localHostName);

            }
            catch { rtBox1.Text += "Unable to resolve local host\n"; }

            rtBox1.Text += "\n\nRemote Host (" + textBox1.Text + ")\n";
            PrintHostInfo(textBox1.Text);
        }

        private void PrintHostInfo(string host)
        {
            // this should be put into a class of it's own
            // in the future.

            try
            {
                IPHostEntry hostinfo;

                // Attempt to resolve the DNS
                hostinfo = Dns.GetHostEntry(host);

                // Display the primary host name
                rtBox1.Text += "\tCanonical Name: " + hostinfo.HostName + "\n";

                // Display list of IP addresses for the host
                rtBox1.Text += "\tIP Adresses:   ";

                foreach (IPAddress ipadr in hostinfo.AddressList)
                {
                    rtBox1.Text += ipadr.ToString() + "\n";
                }

                // Display the list of alias names for the host
                rtBox1.Text += "\tAliases:       ";

                foreach (String alias in hostinfo.Aliases)
                {
                    rtBox1.Text += alias + "  " + "\n";
                }
            }
            catch
            {
                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtbInfo.Clear();
            rtbWarning.Clear();
            rtbError.Clear();
            rtbDebug.Clear();
            initQueue.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtBox1.Clear();

            IPAddress ip = null;

            try
            {
                ip = Dns.GetHostEntry(textBox1.Text).AddressList[0];
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                rtBox1.Text += "DNS Error: " + ex.Message;
                return;
            }

            rtBox1.Text += "Pinging " + textBox1.Text + " [" + ip.ToString() + "] with 32 bytes of data:\n";

            PingHost ping = new PingHost();
            ping.Change += new PingHost.PingResponsereceived(ping_Change);
            ping.StartPing(ip);
        }

        private void ping_Change(object sender, PingEventArgs pa)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {
                rtBox1.Text += "\n" + pa.Message();
            }));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = "Instance name/PID: " + networkTraffic.GetInstanceNme();

            button5.Enabled = true;
            button4.Enabled = false;

            aTimer1 = new System.Timers.Timer();
            aTimer1.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            // Set the Interval to 5 seconds.
            aTimer1.Interval = 5000;
            aTimer1.Enabled = true;
            aTimer1.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //pastval1 = 0f;
            //pastval2 = 0f;

            button5.Enabled = false;
            button4.Enabled = true;

            aTimer1.Stop();
            aTimer1.Enabled = false;
            aTimer1.Dispose();
        }

        private void frmDebugLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (aTimer1 != null)
                {
                    aTimer1.Stop();
                    aTimer1.Enabled = false;
                    aTimer1.Dispose();

                    //pastval1 = 0f;
                    //pastval2 = 0f;

                    button5.Enabled = false;
                    button4.Enabled = true;
                }
            }
            catch { ; }
        }

        private void tpgMonitor_Click(object sender, EventArgs e)
        {

        }

        private void PingSIM()
        {
            IPAddress ip = null;

            IPEndPoint simip = client.Network.CurrentSim.IPEndPoint;

            BeginInvoke(new MethodInvoker(delegate()
            {
                label10.Text = "SIM: " + client.Network.CurrentSim.Name + " (" + client.Network.CurrentSim.IPEndPoint.ToString() + ")";
            }));

            ip = simip.Address;

            PingHost ping = new PingHost();
            ping.Change += new PingHost.PingResponsereceived(ping_ChangeTimer);

            ping.StartPing(ip);
        }

        private void ping_ChangeTimer(object sender, PingEventArgs pa)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {
                if (pa.Message().Contains("Approximate round trip times in milli-seconds"))
                {
                    string[] ltimes = pa.Message().Split(new Char[] { '=' });
                    int enrs = ltimes.Length;

                    string lval = ltimes[enrs - 1].Trim();
                    label12.Text = "Latency: " + lval;

                    try
                    {
                        if (lval.Contains("ms"))
                        {
                            string valg = lval.Substring(0, lval.Length - 2);
                            double dvalg = Convert.ToDouble(valg, CultureInfo.CurrentCulture);

                            dataChart3.UpdateChart(dvalg);
                        }
                    }
                    catch { ; }
                }
            }));
        }

        private void OnTimedEvent1(object sender, ElapsedEventArgs e)
        {
            PingSIM();
        }
    }
}
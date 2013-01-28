﻿//  Copyright (c) 2008-2011, www.metabolt.net
//  All rights reserved.

//  Redistribution and use in source and binary forms, with or without modification, 
//  are permitted provided that the following conditions are met:

//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright notice, 
//    this list of conditions and the following disclaimer in the documentation 
//    and/or other materials provided with the distribution. 
//  * Neither the name METAbolt nor the names of its contributors may be used to 
//    endorse or promote products derived from this software without specific prior 
//    written permission. 

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
//using SLNetworkComm;
using OpenMetaverse;
using System.Threading;
using System.IO;
using ExceptionReporting;
using System.Globalization;


namespace METAbolt
{
    public partial class frmAboutLand : Form
    {
        private METAboltInstance instance;
        private GridClient client;
        //private SLNetCom netcom;
        private bool parcelowner = false;
        //private bool detsloading = true;
        //private bool detschanged = false;
        private Parcel parcel;
        private bool formloading = true;
        private List<ParcelManager.ParcelAccessEntry> blacklist;
        //private List<ParcelManager.ParcelAccessEntry> whitelist;

        private ExceptionReporter reporter = new ExceptionReporter();

        internal class ThreadExceptionHandler
        {
            public void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
            {
                ExceptionReporter reporter = new ExceptionReporter();
                reporter.Show(e.Exception);
            }
        }

        public frmAboutLand(METAboltInstance instance)
        {
            InitializeComponent();

            SetExceptionReporter();
            Application.ThreadException += new ThreadExceptionHandler().ApplicationThreadException;

            this.instance = instance;
            //netcom = this.instance.Netcom;
            client = this.instance.Client;

            while (!IsHandleCreated)
            {
                // Force handle creation
                IntPtr temp = Handle;
            }

            Disposed += new EventHandler(AboutLand_Disposed);

            this.parcel = this.instance.MainForm.parcel;

            client.Parcels.ParcelDwellReply += new EventHandler<ParcelDwellReplyEventArgs>(Parcels_OnParcelDwell);
            client.Groups.GroupMembersReply += new EventHandler<GroupMembersReplyEventArgs>(GroupMembersHandler);

            client.Parcels.RequestDwell(client.Network.CurrentSim, parcel.LocalID);

            PopData();
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

        private void AboutLand_Disposed(object sender, EventArgs e)
        {
            //client.Parcels.ParcelDwellReply -= new EventHandler<ParcelDwellReplyEventArgs>(Parcels_OnParcelDwell);
            client.Avatars.UUIDNameReply -= new EventHandler<UUIDNameReplyEventArgs>(Avatars_OnAvatarNames);
            client.Groups.GroupMembersReply -= new EventHandler<GroupMembersReplyEventArgs>(GroupMembersHandler);
        }

        private void GroupMembersHandler(object sender, GroupMembersReplyEventArgs e)
        {
            // do the stuff here
            if (e.Members.ContainsKey(client.Self.AgentID))
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    SetOwnerProperties();
                }));

                return;
            }
            else
            {
                parcelowner = false;
            }

            client.Groups.GroupMembersReply -= new EventHandler<GroupMembersReplyEventArgs>(GroupMembersHandler);
        }

        private void Parcels_OnParcelDwell(object sender, ParcelDwellReplyEventArgs ea)
        {
            try
            {
                BeginInvoke(new MethodInvoker(delegate()
                {
                    PopData();
                }));
            }
            catch
            {
                // do nothing
            }
        }

        private void SetOwnerProperties()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate()
                {
                    SetOwnerProperties();
                }));

                return;
            }

            parcelowner = true;
            txtParceldesc.ReadOnly = false;
            txtParcelname.ReadOnly = false;
            txtPrimreturn.ReadOnly = false;
            txtMusic.ReadOnly = false;
            button1.Visible = true; 

            //Populate prim owners
            //callback = new ParcelManager.ParcelPrimOwners ParcelObjectOwnersListReplyCallback(Parcel_ObjectOwners);
            //client.Parcels.OnPrimOwnersListReply += callback;

            client.Avatars.UUIDNameReply += new EventHandler<UUIDNameReplyEventArgs>(Avatars_OnAvatarNames);
            client.Parcels.ParcelObjectOwnersReply +=new EventHandler<ParcelObjectOwnersReplyEventArgs>(Parcel_ObjectOwners);
            client.Parcels.RequestObjectOwners(client.Network.CurrentSim, parcel.LocalID);

            cbcreater.Enabled = true;
            cbcreateg.Enabled = true;
            cbplace.Enabled = true;
            cbmature.Enabled = true;
            cbscriptsr.Enabled = true;
            cbsafe.Enabled = true;
            cbscriptsg.Enabled = true;
            cbentryg.Enabled = true;
            cbentryr.Enabled = true;
            cbfly.Enabled = true;
            cblandmark.Enabled = true;
            cbTerrain.Enabled = true;
            cbpush.Enabled = true;
            
            client.Parcels.ParcelAccessListReply += new EventHandler<ParcelAccessListReplyEventArgs>(Parcels_ParcelAccessListReply);
            client.Parcels.RequestParcelAccessList(client.Network.CurrentSim, parcel.LocalID, AccessList.Ban, 1);
        }

        private void PopData()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    PopData();
                }));

                return;
            }

            if (!instance.LoggedIn)
            {
                this.Close();
                return; 
            }

            try
            {
                formloading = true;

                lblTraffic.Text = this.instance.MainForm.dwell;

                if (parcel.OwnerID == client.Self.AgentID)
                {
                    SetOwnerProperties();
                }
                else
                {
                    parcelowner = false;
                    txtParceldesc.ReadOnly = true;
                    txtParcelname.ReadOnly = true;
                    txtPrimreturn.ReadOnly = true;
                    txtMusic.ReadOnly = true;
                    txtMusic.PasswordChar = '*';
                    button1.Visible = false;

                    cbcreater.Enabled = false;
                    cbcreateg.Enabled = false;
                    cbplace.Enabled = false;
                    cbmature.Enabled = false;
                    cbscriptsr.Enabled = false;
                    cbsafe.Enabled = false;
                    cbscriptsg.Enabled = false;
                    cbentryg.Enabled = false;
                    cbentryr.Enabled = false;
                    cbfly.Enabled = false;
                    cblandmark.Enabled = false;
                    cbTerrain.Enabled = false;
                    cbpush.Enabled = false;

                    lvwPrimOwners.Clear();
                    lvwPrimOwners.Enabled = false;
                }

                //main tab
                txtParcelname.Text = parcel.Name;
                txtParceldesc.Text = parcel.Desc.Replace("\n", "\r\n"); //Multi line else we have little boxes for an Enter

                if (parcel.IsGroupOwned)
                {
                    txtOwnerid.Text = "(Group Owned)";
                    txtGroupOwner.Text = this.instance.MainForm.AboutlandGroupidname; //For some reason on this new code it shows (???)(???) :-/ TODO: fix me

                    client.Groups.RequestGroupMembers(parcel.GroupID);
                }
                else
                {
                    txtOwnerid.Text = this.instance.MainForm.AboutlandOwneridname;
                    txtGroupOwner.Text = "";   //this.instance.MainForm.AboutlandOwneridname; 
                }

                txtClaimDate.Text = parcel.ClaimDate.ToString(CultureInfo.CurrentCulture);
                txtArea.Text = parcel.Area.ToString(CultureInfo.CurrentCulture) + "sq. m.";

                if (this.instance.MainForm.Aboutlandforsale)
                {
                    txtForsale.Text = "L$ " + parcel.SalePrice.ToString(CultureInfo.CurrentCulture);
                    btnBuy.Visible = true; 
                }
                else
                {
                    txtForsale.Text = "Not For Sale";
                    btnBuy.Visible = false; 
                }

                // Obects tab
                txtSimprim.Text = parcel.SimWideTotalPrims.ToString(CultureInfo.CurrentCulture) + " out of " + parcel.SimWideMaxPrims.ToString(CultureInfo.CurrentCulture) + " (" + (parcel.SimWideMaxPrims - parcel.SimWideTotalPrims).ToString(CultureInfo.CurrentCulture) + " available)";
                txtParcelprim.Text = Math.Round(parcel.MaxPrims * parcel.ParcelPrimBonus).ToString(CultureInfo.CurrentCulture);
                txtPrimonparcel.Text = parcel.TotalPrims.ToString(CultureInfo.CurrentCulture);
                txtPrimOwnedowner.Text = parcel.OwnerPrims.ToString(CultureInfo.CurrentCulture);
                txtPrimsettogroup.Text = parcel.GroupPrims.ToString(CultureInfo.CurrentCulture);
                txtPrimownedothers.Text = parcel.OtherPrims.ToString(CultureInfo.CurrentCulture);
                txtPrimsel.Text = "";  // parcel. .SelectedPrims.ToString();
                txtPrimreturn.Text = parcel.OtherCleanTime.ToString(CultureInfo.CurrentCulture);
                lblTraffic.Text = parcel.Dwell.ToString(CultureInfo.CurrentCulture);
                txtMusic.Text = parcel.MusicURL;

                lblLocalID.Text = parcel.LocalID.ToString();  

                //pictureBox1.Image = OpenJPEGNet.OpenJPEG.DecodeToImage(parcel.Bitmap);  

                if (parcel.ParcelPrimBonus != 1) txtPrimBonus.Text = "Region Object Bonus Factor: " + parcel.ParcelPrimBonus.ToString(CultureInfo.CurrentCulture);
                else txtPrimBonus.Text = "";
                // Options tab
                if (this.instance.MainForm.AboutlandCreateObj) cbcreater.Checked = false;
                else cbcreater.Checked = true;

                if (this.instance.MainForm.AboutlandGroupCreateObj) cbcreateg.Checked = false;
                else cbcreateg.Checked = true;

                if (this.instance.MainForm.AboutShow) cbplace.Checked = true;
                else cbplace.Checked = true;

                if (this.instance.MainForm.AboutMature) cbmature.Checked = false;
                else cbmature.Checked = true;

                if (this.instance.MainForm.AllowOtherScripts) cbscriptsr.Checked = false;
                else cbscriptsr.Checked = true;

                if (!this.instance.MainForm.AboutlandAllowDamage) cbsafe.Checked = false;
                else cbsafe.Checked = true;

                if (this.instance.MainForm.AllowGroupScripts) cbscriptsg.Checked = false;
                else cbscriptsg.Checked = true;

                if (this.instance.MainForm.AboutAllowGroupObjectEntry) cbentryg.Checked = true;
                else cbentryg.Checked = false;

                if (this.instance.MainForm.AboutAllowAllObjectEntry) cbentryr.Checked = true;
                else cbentryr.Checked = false;

                if (this.instance.MainForm.AboutlandAllowFly) cbfly.Checked = false;
                else cbfly.Checked = true;

                if (this.instance.MainForm.Allowcreatelm) cblandmark.Checked = true;
                else cblandmark.Checked = false;

                if (this.instance.MainForm.AllowTerraform) cbTerrain.Checked = true;
                else cbTerrain.Checked = false;

                if (this.instance.MainForm.AboutlandRestrictPush) cbpush.Checked = true;
                else cbpush.Checked = false;

                formloading = false;
            }
            catch (Exception ex)
            {
                Logger.Log("About Land error: " + ex.Message, Helpers.LogLevel.Error);     
            }
        }

        private void Parcels_ParcelAccessListReply(object sender, ParcelAccessListReplyEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {
                blacklist = e.AccessList;
                lvwBlackList.BeginUpdate();

                foreach (ParcelManager.ParcelAccessEntry pe in blacklist)
                {
                    ListViewItem item = lvwBlackList.Items.Add(pe.AgentID.ToString());
                    item.Tag = pe;

                    if (!instance.avnames.ContainsKey(pe.AgentID))
                    {
                        client.Avatars.RequestAvatarName(pe.AgentID);
                    }
                    else
                    {
                        ListViewItem foundItem = lvwBlackList.FindItemWithText(pe.AgentID.ToString());

                        if (foundItem != null)
                        {
                            foundItem.Text = instance.avnames[pe.AgentID].ToString();
                        }
                    }
                }

                lvwBlackList.EndUpdate();

                if (lvwBlackList.Items.Count > 0)
                {
                    button4.Enabled = true;
                }
                else
                    button4.Enabled = false; 

                //lvwBlackList.Sort();
            }));
        }

        private void Parcel_ObjectOwners(object sender, ParcelObjectOwnersReplyEventArgs ea)
        {
            BeginInvoke(new MethodInvoker(delegate()
            {     
                lvwPrimOwners.Enabled = true;
                lvwPrimOwners.BeginUpdate();
                //lvwPrimOwners.Items.Clear();

                List<ParcelManager.ParcelPrimOwners> primOwners = ea.PrimOwners; 

                for (int i = 0; i < primOwners.Count; i++)
                {
                    try
                    {
                        ListViewItem item = lvwPrimOwners.Items.Add(primOwners[i].OwnerID.ToString());
                        item.Tag = primOwners[i].OwnerID;
                        item.SubItems.Add(primOwners[i].Count.ToString(CultureInfo.CurrentCulture));

                        if (!instance.avnames.ContainsKey(primOwners[i].OwnerID))
                        {
                            client.Avatars.RequestAvatarName(primOwners[i].OwnerID);
                        }
                        else
                        {
                            ListViewItem foundItem = lvwPrimOwners.FindItemWithText(instance.avnames[primOwners[i].OwnerID].ToString());

                            if (foundItem != null)
                            {
                                foundItem.Text = instance.avnames[primOwners[i].OwnerID].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log("About Land (object owners) error: " + ex.Message, Helpers.LogLevel.Error); 
                    }
                }

                //button2.Enabled = true;
 
                lvwPrimOwners.EndUpdate();
                //lvwPrimOwners.Sort();
            }));
        }

        // separate thread
        private void Avatars_OnAvatarNames(object sender, UUIDNameReplyEventArgs names)
        {
            //BeginInvoke(new MethodInvoker(delegate()
            //{
            //    OwnerReceived(names.Names);
            //}));

            OwnerReceived(names.Names);
        }

        //runs on the GUI thread
        private void OwnerReceived(Dictionary<UUID, string> names)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate()
                {
                    OwnerReceived(names);
                }));

                return;
            }

            lvwPrimOwners.BeginUpdate();

            foreach (KeyValuePair<UUID, string> av in names)
            {
                if (!instance.avnames.ContainsKey(av.Key))
                {
                    instance.avnames.Add(av.Key, av.Value);
                }

                ListViewItem foundItem = lvwPrimOwners.FindItemWithText(av.Key.ToString());

                try
                {
                    if (foundItem != null)
                    {
                        foundItem.Text = av.Value;
                    }
                }
                catch
                {
                   ; 
                }
            }

            lvwPrimOwners.EndUpdate();

            lvwBlackList.BeginUpdate();

            foreach (KeyValuePair<UUID, string> av in names)
            {
                ListViewItem foundItem = lvwBlackList.FindItemWithText(av.Key.ToString());

                try
                {
                    foundItem.Text = av.Value;
                }
                catch
                {
                    ;
                }
            }

            lvwBlackList.EndUpdate(); 

            lvwBlackList.Sort();
        }

        private void tabGenral_Click(object sender, EventArgs e)
        {

        }

        private void UpdatePName()
        {
            if (formloading) return;

            this.parcel.Name = txtParcelname.Text;
            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void UpdateDesc()
        {
            if (formloading) return;

            this.parcel.Desc = txtParceldesc.Text.Replace("\r\n","\n"); 
            this.parcel.Update(client.Network.CurrentSim, false);  
        }

        private void txtParceldesc_Leave(object sender, EventArgs e)
        {
            if (!parcelowner) return;
                
            UpdateDesc();
        }

        private void txtParceldesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParcelname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParcelname_Leave(object sender, EventArgs e)
        {
            if (!parcelowner) return;
                
            UpdatePName();
        }

        private void tabObjects_Click(object sender, EventArgs e)
        {

        }

        private void lvwPrimOwners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwPrimOwners.SelectedItems == null || lvwPrimOwners.SelectedItems.Count == 0)
            {
                btnReturn.Enabled = false;
                return;
            }

            btnReturn.Enabled = true;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            List<UUID> ownersID = null;

            UUID oitem = (UUID)lvwPrimOwners.SelectedItems[0].Tag;

            if (client.Self.AgentID == oitem)
            {
                DialogResult res = MessageBox.Show("You are about to return ALL your prims.\nAre you sure you want to continue?", "METAbolt Object Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.No == res)
                {
                    return;
                }
            }
            else
            {
                DialogResult res = MessageBox.Show("You are about to return ALL prims owned by " + lvwPrimOwners.SelectedItems[0].Text + ".\nAre you sure you want to continue?", "METAbolt Object Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult.No == res)
                {
                    return;
                }
            }

            ownersID.Add(oitem);

            client.Parcels.RequestSelectObjects(parcel.LocalID, ObjectReturnType.Owner, oitem);

            client.Parcels.ReturnObjects(client.Network.CurrentSim, parcel.LocalID, ObjectReturnType.Owner, ownersID);
            client.Parcels.RequestObjectOwners(client.Network.CurrentSim, parcel.LocalID);
            PopData();
            //btnSelect.Enabled = false;
            btnReturn.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmAboutLand_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                client.Parcels.ParcelDwellReply -= new EventHandler<ParcelDwellReplyEventArgs>(Parcels_OnParcelDwell);
                client.Parcels.ParcelAccessListReply -= new EventHandler<ParcelAccessListReplyEventArgs>(Parcels_ParcelAccessListReply);
                client.Parcels.ParcelObjectOwnersReply -= new EventHandler<ParcelObjectOwnersReplyEventArgs>(Parcel_ObjectOwners);
                client.Avatars.UUIDNameReply -= new EventHandler<UUIDNameReplyEventArgs>(Avatars_OnAvatarNames);
                client.Groups.GroupMembersReply -= new EventHandler<GroupMembersReplyEventArgs>(GroupMembersHandler);
            }
            catch { ; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbTerrain_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbTerrain.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowTerraform;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowTerraform;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cblandmark_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cblandmark.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowLandmark;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowLandmark;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void txtMusic_Leave(object sender, EventArgs e)
        {
            //if (!parcelowner) return;

            //if (formloading) return;

            //this.parcel.MusicURL = txtMusic.Text;
            //this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbfly_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbfly.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowFly;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowFly;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbcreater_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbcreater.Checked)
            {
                this.parcel.Flags |= ParcelFlags.CreateObjects;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.CreateObjects;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbcreateg_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbcreateg.Checked)
            {
                this.parcel.Flags |= ParcelFlags.CreateGroupObjects;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.CreateGroupObjects;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbentryr_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbentryr.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowAPrimitiveEntry;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowAPrimitiveEntry;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbentryg_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;


            if (cbentryg.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowGroupObjectEntry;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowGroupObjectEntry;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbscriptsr_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbscriptsr.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowOtherScripts;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowOtherScripts;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbscriptsg_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbscriptsg.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowGroupScripts;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowGroupScripts;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbsafe_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (!cbsafe.Checked)
            {
                this.parcel.Flags |= ParcelFlags.AllowDamage;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.AllowDamage;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbpush_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbpush.Checked)
            {
                this.parcel.Flags |= ParcelFlags.RestrictPushObject;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.RestrictPushObject;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbplace_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbplace.Checked)
            {
                this.parcel.Flags |= ParcelFlags.ShowDirectory;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.ShowDirectory;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void cbmature_CheckedChanged(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            if (cbmature.Checked)
            {
                this.parcel.Flags |= ParcelFlags.MaturePublish;
            }
            else
            {
                this.parcel.Flags &= ~ParcelFlags.MaturePublish;
            }

            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!parcelowner) return;

            if (formloading) return;

            this.parcel.MusicURL = txtMusic.Text;
            this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void lvwBlackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = (lvwBlackList.SelectedItems.Count > 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lvwBlackList.SelectedItems.Count > 0)
            {
                ParcelManager.ParcelAccessEntry person = (ParcelManager.ParcelAccessEntry)lvwBlackList.SelectedItems[0].Tag;

                blacklist.Remove(person);
                parcel.AccessBlackList = blacklist;
                this.parcel.Update(client.Network.CurrentSim, false);  
            }
        }

        private void chkPublic_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkPublic.Checked)
            //{
            //    this.parcel.Flags |= ParcelFlags.;
            //}
            //else
            //{
            //    this.parcel.Flags &= ~ParcelFlags.MaturePublish;
            //}

            //this.parcel.Update(client.Network.CurrentSim, false);
        }

        private void frmAboutLand_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void lvwBlackList_DoubleClick(object sender, EventArgs e)
        {
            if (lvwBlackList.SelectedItems.Count > 0)
            {
                ParcelManager.ParcelAccessEntry person = (ParcelManager.ParcelAccessEntry)lvwBlackList.SelectedItems[0].Tag;

                (new frmProfile(instance, lvwBlackList.SelectedItems[0].Text, person.AgentID)).Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lvwBlackList.Items.Count > 0)   // && lstMembers2.Columns[0].ToString != "none")
            {
                Stream tstream;
                saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((tstream = saveFileDialog1.OpenFile()) != null)
                        {
                            StreamWriter SW = new StreamWriter(tstream);

                            string parcelname = client.Network.CurrentSim.ToString() + "/" + txtParcelname.Text.Replace(",", " ");

                            SW.WriteLine("Land: " + parcelname + ",List Type: Blacklist,Ttl avatars: " + lvwBlackList.Items.Count.ToString(CultureInfo.CurrentCulture));
                            SW.WriteLine(",,");
                            SW.WriteLine("Name,UUID,");

                            for (int i = 0; i < lvwBlackList.Items.Count; i++)
                            { 
                                ParcelManager.ParcelAccessEntry person = (ParcelManager.ParcelAccessEntry)lvwBlackList.Items[i].Tag;
                                string personame = lvwBlackList.Items[i].Text;
                                
                                string line = personame + "," + person.AgentID.ToString()  + ",";
                                SW.WriteLine(line);
                            }

                            SW.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                        reporter.Show(ex); 
                    }
                }
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (parcel != null)
            {
                int localid = parcel.LocalID;
                int saleprice = parcel.SalePrice;
                int parcelarea = parcel.Area;
                Simulator simulator = client.Network.CurrentSim;
                UUID buyerid = parcel.AuthBuyerID;

                if ((((buyerid == UUID.Zero) || (buyerid == client.Self.AgentID))) && ((parcel.Flags & ParcelFlags.ForSale) == ParcelFlags.ForSale))
                {
                    client.Parcels.Buy(simulator, localid, false, UUID.Zero, false, parcelarea, saleprice);
                }
                else
                {
                    MessageBox.Show("Parcel could not be bought! It is either not for sale\n or it is on sale to a specific avatar.", "METAbolt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

using AjaxControlToolkit;
using ASP;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace NBR_VAT_GROUPOFCOM.UI.UserControls
{
    public partial class MsgBoxs : UserControl
    {
        protected Button btnD;

        protected Button btnD2;

        protected Panel pnlMsgHD;

        protected GridView grvMsg;

        protected Button btnOK;

        protected Button btnPostOK;

        protected Button btnPostCancel;

        protected Panel pnlMsg;

        protected ModalPopupExtender mpeMsg;

        protected UpdatePanel udpMsj;

        private List<MsgBoxs.Message> Messages = new List<MsgBoxs.Message>();

        protected global_asax ApplicationInstance
        {
            get
            {
                return (global_asax)this.Context.ApplicationInstance;
            }
        }

        public string Args
        {
            get
            {
                if (this.ViewState["Args"] == null)
                {
                    this.ViewState["Args"] = "";
                }
                return Convert.ToString(this.ViewState["Args"]);
            }
            set
            {
                this.ViewState["Args"] = value;
            }
        }

        protected int MessageNumber
        {
            get
            {
                return this.Messages.Count;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public MsgBoxs()
        {
        }

        public void AddMessage(string msgText, MsgBoxs.enmMessageType type)
        {
            this.Messages.Add(new MsgBoxs.Message(msgText, type));
            this.Args = "";
         //   this.btnPostCancel.Visible = false;
        //    this.btnPostOK.Visible = false;
            this.btnOK.Visible = true;
        }

        public void AddMessage(string msgText, MsgBoxs.enmMessageType type, bool postPage, bool showCancelButton, string args)
        {
            this.Messages.Add(new MsgBoxs.Message(msgText, type));
            if (!string.IsNullOrEmpty(args))
            {
                this.Args = args;
            }
            this.btnPostCancel.Visible = showCancelButton;
            this.btnPostOK.Visible = postPage;
            this.btnOK.Visible = !postPage;
        }

        protected void btnPostCancel_Click(object sender, EventArgs e)
        {
            if (this.MsgBoxAnswered != null)
            {
                this.MsgBoxAnswered(this, new MsgBoxs.MsgBoxEventArgs(MsgBoxs.enmAnswer.Cancel, this.Args));
                this.Args = "";
            }
        }

        protected void btnPostOK_Click(object sender, EventArgs e)
        {
            if (this.MsgBoxAnswered != null)
            {
                this.MsgBoxAnswered(this, new MsgBoxs.MsgBoxEventArgs(MsgBoxs.enmAnswer.OK, this.Args));
                this.Args = "";
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (this.btnOK.Visible)
            {
                this.mpeMsg.OkControlID = "btnOK";
            }
            else
            {
                this.mpeMsg.OkControlID = "btnD2";
            }
            if (this.Messages.Count <= 0)
            {
                this.grvMsg.DataBind();
                this.udpMsj.Update();
            }
            else
            {
                this.btnOK.Focus();
                this.grvMsg.DataSource = this.Messages;
                this.grvMsg.DataBind();
                this.mpeMsg.Show();
                this.udpMsj.Update();
            }
            if (this.Parent.GetType() == typeof(UpdatePanel))
            {
                (this.Parent as UpdatePanel).Update();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public event MsgBoxs.MsgBoxEventHandler MsgBoxAnswered;

        public enum enmAnswer
        {
            OK,
            Cancel
        }

        public enum enmMessageType
        {
            Error,
            Success,
            Attention,
            Info
        }

        public class Message
        {
            private MsgBoxs.enmMessageType _messageType = MsgBoxs.enmMessageType.Info;

            private string _messageText = "";

            public string MessageText
            {
                get
                {
                    return this._messageText;
                }
                set
                {
                    this._messageText = value;
                }
            }

            public MsgBoxs.enmMessageType MessageType
            {
                get
                {
                    return this._messageType;
                }
                set
                {
                    this._messageType = value;
                }
            }

            public Message(string messageText, MsgBoxs.enmMessageType messageType)
            {
                this._messageText = messageText;
                this._messageType = messageType;
            }
        }

        public class MsgBoxEventArgs : EventArgs
        {
            public MsgBoxs.enmAnswer Answer;

            public string Args;

            public MsgBoxEventArgs(MsgBoxs.enmAnswer answer, string args)
            {
                this.Answer = answer;
                this.Args = args;
            }
        }

        public delegate void MsgBoxEventHandler(object sender, MsgBoxs.MsgBoxEventArgs e);
    }
}

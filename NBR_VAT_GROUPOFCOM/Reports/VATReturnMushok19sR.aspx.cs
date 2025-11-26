using AjaxControlToolkit;
using ASP;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using NBR_VAT_GROUPOFCOM.BLL;
using NBR_VAT_GROUPOFCOM.Api;

namespace NBR_VAT_GROUPOFCOM.Reports
{
    public partial class VATReturnMushok19sR :  Page, IRequiresSessionState
    {
        private NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL objVatReturn = new NBR_VAT_GROUPOFCOM.BLL.VATReturnBLL();

        private NBR_VAT_GROUPOFCOM.BLL.CSVXMLBLL dbBLL = new NBR_VAT_GROUPOFCOM.BLL.CSVXMLBLL();

        private string ErrorList = "";
        //protected MsgBoxs msgBox;

        // protected UpdatePanel upDetail35Modal;

        protected global_asax ApplicationInstance
        {
            get
            {
                return (global_asax)this.Context.ApplicationInstance;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public VATReturnMushok19sR()
        {
        }

        protected void btnCancelToSaveInvoice(object sender, EventArgs e)
        {
            this.mpeYesNoModal.Hide();
        }

        protected void btnExportXML_OnClick(object sender, EventArgs e)
        {
            this.LoadReport();
        }

        protected void btnOkToReload(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            List<NBR_VAT_GROUPOFCOM.BLL.MonthClosingBalance> item = (List<NBR_VAT_GROUPOFCOM.BLL.MonthClosingBalance>)this.Session["report_values"];
            int num = 0;
            num = Convert.ToInt16(this.Session["transecID"]);
            if (this.objVatReturn.updateMontClosingBalance(item, dateTime, dateTime1, num))
            {
                // this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                return;
            }
            // this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string empty = string.Empty;
                DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateTo.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str = dateTime.ToString("MM");
                DateTime dateTime2 = Convert.ToDateTime(this.dtpDateFrom.Text);
                string str1 = dateTime2.ToString("yyyy");
                object[] objArray = new object[] { "01", '/', str, '/', str1 };
                string str2 = string.Concat(objArray);
                string str3 = this.dtpDateTo.Text.ToString();
                string empty1 = string.Empty;
                List<NBR_VAT_GROUPOFCOM.BLL.MonthClosingBalance> item = (List<NBR_VAT_GROUPOFCOM.BLL.MonthClosingBalance>)this.Session["report_values"];
                if (this.chkClosing.Text == "Yes")
                {
                    DataTable monthClosingInfo = this.objVatReturn.getMonthClosingInfo(str2, str3);
                    if (monthClosingInfo.Rows.Count > 0)
                    {
                        this.Session["transecID"] = Convert.ToInt16(monthClosingInfo.Rows[0]["transec_id"]);
                        this.mpeYesNoModal.Show();
                    }
                    else if (!this.objVatReturn.insertMontClosingBalance(item, dateTime, dateTime1))
                    {
                        //  this.msgBox.AddMessage("Failed to save.", MsgBoxs.enmMessageType.Error);
                    }
                    else
                    {
                        // this.msgBox.AddMessage("Information Successfully Saved.", MsgBoxs.enmMessageType.Success);
                    }
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            this.ShowReport();
        }

        public static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("/IvasWebService.asmx");
            httpWebRequest.Headers.Add("SOAP:Action");
            httpWebRequest.ContentType = "text/xml;charset=\"utf-8\"";
            httpWebRequest.Accept = "text/xml";
            httpWebRequest.Method = "POST";
            return httpWebRequest;
        }

        protected void Details27_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Details_Note_27s.aspx");
        }

        protected void Details33_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Details_Note_33s.aspx");
        }

        private void DownloadFile(string filePath)
        {
            DateTime today = DateTime.Today;
            string str = string.Concat("VATReturnMushok19sR", today.ToString("ddMMyy"));
            base.Response.ContentType = "application/xml";
            base.Response.AddHeader("Content-Disposition", string.Concat("attachment;filename=", str, ".xml"));
            base.Response.WriteFile(filePath);
            base.Response.End();
        }

        private XElement GenerateElementNote1_23(DataTable dt, string noteNo, XElement IT_SUBF_GOSERV)
        {
            try
            {
                List<IT_SUBF_GOSERV> tSUBFGOSERVs = this.GenerateIT_SUBF_GOSERV(dt, noteNo);
                XNamespace xNamespace = "http://nbr.gov.bd/regist91";
                if (tSUBFGOSERVs.Count != 0)
                {
                    IT_SUBF_GOSERV.Add((
                        from x in tSUBFGOSERVs
                        select new XElement(xNamespace + "ITEM", new XElement[] { new XElement(xNamespace + "FIELD_ID", x.FIELD_ID), new XElement(xNamespace + "ACT_SALE_VALUE", x.ACT_SALE_VALUE), new XElement(xNamespace + "ASSESS_VALUE", x.ASSESS_VALUE), new XElement(xNamespace + "AT", x.AT), new XElement(xNamespace + "BOE_DATE", x.BOE_DATE), new XElement(xNamespace + "BOE_ITM_NO", x.BOE_ITM_NO), new XElement(xNamespace + "BOE_NO", x.BOE_NO), new XElement(xNamespace + "BOE_OFF_CODE", x.BOE_OFF_CODE), new XElement(xNamespace + "BOE_TYPE", x.BOE_TYPE), new XElement(xNamespace + "CATEGORY", x.CATEGORY), new XElement(xNamespace + "CPC_CODE", x.CPC_CODE), new XElement(xNamespace + "DESCRIPTION", x.DESCRIPTION), new XElement(xNamespace + "GOOD_SERVICE", x.GOOD_SERVICE), new XElement(xNamespace + "INVOICE_DATE", x.INVOICE_DATE), new XElement(xNamespace + "INVOICE_NO", x.INVOICE_NO), new XElement(xNamespace + "ITEM_ID", x.ITEM_ID), new XElement(xNamespace + "NAME", x.NAME), new XElement(xNamespace + "NOTES", x.NOTES), new XElement(xNamespace + "QUANTITY", x.QUANTITY), new XElement(xNamespace + "SD", x.SD), new XElement(xNamespace + "UNIT", x.UNIT), new XElement(xNamespace + "VALUE", x.VALUE), new XElement(xNamespace + "VAT", x.VAT) })).ToArray<XElement>());
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return IT_SUBF_GOSERV;
        }

        private XElement GenerateElementNote24_29(DataTable dt, string noteNo, XElement IT_SUBF_VDS)
        {
            List<NoteVDS> noteVDs = this.GenerateIT_SUBF_VDS(dt, noteNo);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            if (noteVDs.Count != 0)
            {
                IT_SUBF_VDS.Add((
                    from x in noteVDs
                    select new XElement(xNamespace + "ITEM", new XElement[] { new XElement(xNamespace + "FIELD_ID", noteNo), new XElement(xNamespace + "BIN", "000141519-0503"), new XElement(xNamespace + "NAME", x.NAME), new XElement(xNamespace + "ADDRESS", x.ADDRESS), new XElement(xNamespace + "VALUE", x.VALUE), new XElement(xNamespace + "DEDUCT_VAT", x.DEDUCT_VAT), new XElement(xNamespace + "INVOICE_NO", x.INVOICE_NO), new XElement(xNamespace + "INVOICE_DATE", x.INVOICE_DATE), new XElement(xNamespace + "CERT_NO", x.CERT_NO), new XElement(xNamespace + "CERT_DATE", x.CERT_DATE), new XElement(xNamespace + "ACCOUNT_CODE", x.ACCOUNT_CODE), new XElement(xNamespace + "DEPOSIT_NO", x.DEPOSIT_NO), new XElement(xNamespace + "DEPOSIT_DATE", x.DEPOSIT_DATE), new XElement(xNamespace + "NOTE", x.NOTE) })).ToArray<XElement>());
            }
            return IT_SUBF_VDS;
        }

        private XElement GenerateElementNote26_31(DataTable dt, string noteNo, XElement IT_SUBF_ADJUST)
        {
            List<IT_SUBF_ADJUST> tSUBFADJUSTs = this.GenerateIT_SUBF_ADJUST(dt, noteNo);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            if (tSUBFADJUSTs.Count != 0)
            {
                IT_SUBF_ADJUST.Add((
                    from x in tSUBFADJUSTs
                    select new XElement(xNamespace + "ITEM", new XElement[] { new XElement(xNamespace + "FIELD_ID", x.FIELD_ID), new XElement(xNamespace + "NOTE_NO", x.NOTE_NO), new XElement(xNamespace + "ISSUE_DAT", x.ISSUE_DAT), new XElement(xNamespace + "CHALL_NO", x.CHALL_NO), new XElement(xNamespace + "CHALL_DAT", x.CHALL_DATE), new XElement(xNamespace + "REASON", x.REASON), new XElement(xNamespace + "VALUE", x.VALUE), new XElement(xNamespace + "QUANTITY", x.QUANTITY), new XElement(xNamespace + "VAT", x.VAT), new XElement(xNamespace + "SD", x.SD), new XElement(xNamespace + "VALUE_ADJ", x.VALUE_ADJ), new XElement(xNamespace + "QUANTITY_ADJ", x.QUANTITY_ADJ), new XElement(xNamespace + "VAT_ADJ", x.VAT_ADJ), new XElement(xNamespace + "SD_ADJ", x.SD_ADJ), new XElement(xNamespace + "NOTES", x.NOTE) })).ToArray<XElement>());
            }
            return IT_SUBF_ADJUST;
        }

        private XElement GenerateElementNote27_32(DataTable dt, string noteNo, XElement IT_SUBF_OTHER)
        {
            List<IT_SUBF_OTHER> tSUBFOTHERs = this.GenerateIT_SUBF_OTHER(dt, noteNo);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            if (tSUBFOTHERs.Count != 0)
            {
                IT_SUBF_OTHER.Add((
                    from x in tSUBFOTHERs
                    select new XElement(xNamespace + "ITEM", new XElement[] { new XElement(xNamespace + "FIELD_ID", x.FIELD_ID), new XElement(xNamespace + "CHALL_NO", x.CHALL_NO), new XElement(xNamespace + "CHALL_DATE", x.CHALL_DATE), new XElement(xNamespace + "AMOUNT", x.AMOUNT), new XElement(xNamespace + "VAT", x.VAT), new XElement(xNamespace + "NOTES", x.NOTES) })).ToArray<XElement>());
            }
            return IT_SUBF_OTHER;
        }

        private XElement GenerateElementNote58_64(DataTable dt, string noteNo, XElement IT_SUBF_CHALLAN)
        {
            List<IT_SUBF_CHALLAN> tSUBFCHALLANs = this.GenerateIT_SUBF_CHALLAN(dt, noteNo);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            if (tSUBFCHALLANs.Count != 0)
            {
                IT_SUBF_CHALLAN.Add((
                    from x in tSUBFCHALLANs
                    select new XElement(xNamespace + "ITEM", new XElement[] { new XElement(xNamespace + "FIELD_ID", x.FIELD_ID), new XElement(xNamespace + "CHALL_NO", x.CHALL_NO), new XElement(xNamespace + "CHALL_DATE", x.CHALL_DATE), new XElement(xNamespace + "ACCOUNT_CODE", x.ACCOUNT_CODE), new XElement(xNamespace + "CHAN_AMT", x.CHAN_AMT), new XElement(xNamespace + "NOTES", x.NOTES), new XElement(xNamespace + "BANCD", x.BANCD), new XElement(xNamespace + "BANKL", x.BANKL), new XElement(xNamespace + "A_NAMEOFBANK", x.A_NAMEOFBANK), new XElement(xNamespace + "A_BRANCH", x.A_BRANCH) })).ToArray<XElement>());
            }
            return IT_SUBF_CHALLAN;
        }

        private XElement GenerateI_MAIN_FORM()
        {
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "I_MAIN_FORM") };
            XDocument xDocument = new XDocument(xDeclaration, xElement);
            XElement firstNode = (XElement)xDocument.FirstNode;
            I_MAIN_FORM iMAINFORM = new I_MAIN_FORM();
            List<I_MAIN_FORM> iMAINFORMs = new List<I_MAIN_FORM>();
            string empty = string.Empty;
            string str = string.Empty;
            DateTime dateTime = DateTime.ParseExact(this.dtpDateFrom.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            empty = this.dtpDateFrom.Text.ToString();
            str = this.dtpDateTo.Text.ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            DataTable vatReturnPart5Data = this.dbBLL.getVatReturnPart5Data(empty, str, num);
            DataTable note48 = this.dbBLL.GetNote48(empty, str, num);
            iMAINFORM.A_F_S1_BIN = this.Session["ORGANIZATION_BIN"].ToString();
            iMAINFORM.PERIOD_KEY = string.Concat(dateTime.ToString("yy"), dateTime.ToString("MM"));
            this.Session["periodkey"] = iMAINFORM.PERIOD_KEY;
            iMAINFORM.A_F_S2_SUBMISSION_DAT = DateTime.Today.ToString("dd/MM/yyyy");
            iMAINFORM.A_F_S10_NAME = this.Session["EMPLOYEE_NAME"].ToString();
            iMAINFORM.A_F_S10_EMAIL = this.Session["EMAIL"].ToString();
            iMAINFORM.A_F_S10_MOBILE = this.Session["MOBILE_NO"].ToString();
            iMAINFORM.A_F_S10_NID_PP = this.Session["EMPLOYEE_NID"].ToString();
            iMAINFORM.A_F_S10_DESIGNATION = this.objVatReturn.GetDesignation(Convert.ToInt32(this.Session["DESIGNATION_ID"]));
            Convert.ToInt32(this.Session["ORGANIZATION_ID"]);
            if (vatReturnPart5Data != null && vatReturnPart5Data.Rows.Count > 0)
            {
                iMAINFORM.A_F_S5_PAYMENT_NOT_BANKING_AMT = vatReturnPart5Data.Rows[0]["rebatable_amount"].ToString();
            }
            if (note48 != null && note48.Rows.Count > 0)
            {
                iMAINFORM.A_F_S7_HEALTH_CARE_SURCHARGE = note48.Rows[0]["amount"].ToString();
            }
            iMAINFORM.A_F_S2_ANY_ACTIVITIES = "1";
            iMAINFORM.A_F_S10_REFUND = "2";
            iMAINFORM.A_F_S2_TYPE_RETURN = "1";
            iMAINFORMs.Add(iMAINFORM);
            firstNode.Add((
                from x in iMAINFORMs
                select new XElement[] { new XElement(xNamespace + "A_F_S1_BIN", x.A_F_S1_BIN), new XElement(xNamespace + "PERIOD_KEY", x.PERIOD_KEY), new XElement(xNamespace + "A_F_S2_TYPE_RETURN", x.A_F_S2_TYPE_RETURN), new XElement(xNamespace + "A_F_S2_ANY_ACTIVITIES", x.A_F_S2_ANY_ACTIVITIES), new XElement(xNamespace + "A_F_S2_SUBMISSION_DAT", x.A_F_S2_SUBMISSION_DAT), new XElement(xNamespace + "A_F_S2_REASON_AMENDED", x.A_F_S2_REASON_AMENDED), new XElement(xNamespace + "A_F_S5_PAYMENT_NOT_BANKING_AMT", x.A_F_S5_PAYMENT_NOT_BANKING_AMT), new XElement(xNamespace + "A_F_S7_SD_AGAINST_EXPORT", x.A_F_S7_SD_AGAINST_EXPORT), new XElement(xNamespace + "A_F_S7_FINE_PENALTY_OTHER", x.A_F_S7_FINE_PENALTY_OTHER), new XElement(xNamespace + "A_F_S7_EXCISE_DUTY", x.A_F_S7_EXCISE_DUTY), new XElement(xNamespace + "A_F_S7_DEVELOP_SURCHARGE", x.A_F_S7_DEVELOP_SURCHARGE), new XElement(xNamespace + "A_F_S7_ICT_DEVELOP_SURCHARGE", x.A_F_S7_ICT_DEVELOP_SURCHARGE), new XElement(xNamespace + "A_F_S7_HEALTH_CARE_SURCHARGE", x.A_F_S7_HEALTH_CARE_SURCHARGE), new XElement(xNamespace + "A_F_S7_ENV_PROTECT_SURCHARGE", x.A_F_S7_ENV_PROTECT_SURCHARGE), new XElement(xNamespace + "A_F_S7_CB_LAST_TP_VAT", x.A_F_S7_CB_LAST_TP_VAT), new XElement(xNamespace + "A_F_S7_CB_LAST_TP_SD", x.A_F_S7_CB_LAST_TP_SD), new XElement(xNamespace + "A_F_S11_REFUND_VAT", x.A_F_S11_REFUND_VAT), new XElement(xNamespace + "A_F_S11_REFUND_SD", x.A_F_S11_REFUND_SD), new XElement(xNamespace + "A_F_S10_REFUND", x.A_F_S10_REFUND), new XElement(xNamespace + "A_F_S10_NAME", x.A_F_S10_NAME), new XElement(xNamespace + "A_F_S10_DESIGNATION", x.A_F_S10_DESIGNATION), new XElement(xNamespace + "A_F_S10_MOBILE", x.A_F_S10_MOBILE), new XElement(xNamespace + "A_F_S10_NID_PP", x.A_F_S10_NID_PP), new XElement(xNamespace + "A_F_S10_EMAIL", x.A_F_S10_EMAIL), new XElement(xNamespace + "A_F_S7_INTEREST_OVERDUE_VAT", x.A_F_S7_INTEREST_OVERDUE_VAT), new XElement(xNamespace + "A_F_S7_INTEREST_OVERDUE_SD", x.A_F_S7_INTEREST_OVERDUE_SD), new XElement(xNamespace + "A_F_S7_FINE_PENALTY", x.A_F_S7_FINE_PENALTY) }).ToArray<XElement[]>());
            xDocument.ToString();
            xDocument.Save(base.Server.MapPath("FileName.xml"));
            return firstNode;
        }

        private XElement GenerateI_MSG_HDR()
        {
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "I_MSG_HDR") };
            XDocument xDocument = new XDocument(xDeclaration, xElement);
            XElement firstNode = (XElement)xDocument.FirstNode;
            I_MSG_HDR iMSGHDR = new I_MSG_HDR();
            List<I_MSG_HDR> iMSGHDRs = new List<I_MSG_HDR>();
            DateTime today = DateTime.Today;
            iMSGHDR.MSGID = "R9103112202000000001";
            iMSGHDR.SEND_DATE = "";
            iMSGHDR.SEND_TIME = "";
            iMSGHDRs.Add(iMSGHDR);
            firstNode.Add((
                from x in iMSGHDRs
                select new XElement[] { new XElement(xNamespace + "MSGID", x.MSGID), new XElement(xNamespace + "SEND_DATE", x.SEND_DATE), new XElement(xNamespace + "SEND_TIME", x.SEND_TIME) }).ToArray<XElement[]>());
            xDocument.ToString();
            xDocument.Save(base.Server.MapPath("FileName.xml"));
            return firstNode;
        }

        private List<IT_SUBF_ADJUST> GenerateIT_SUBF_ADJUST(DataTable dt, string noteNo)
        {
            List<IT_SUBF_ADJUST> tSUBFADJUSTs = new List<IT_SUBF_ADJUST>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IT_SUBF_ADJUST tSUBFADJUST = new IT_SUBF_ADJUST()
                    {
                        FIELD_ID = noteNo
                    };
                    if (noteNo != "SL26")
                    {
                        tSUBFADJUST.NOTE_NO = "31";
                    }
                    else
                    {
                        tSUBFADJUST.NOTE_NO = "26";
                    }
                    tSUBFADJUST.ISSUE_DAT = dt.Rows[i]["note_date"].ToString();
                    tSUBFADJUST.CHALL_NO = dt.Rows[i]["challan_challan_no"].ToString();
                    tSUBFADJUST.CHALL_DATE = dt.Rows[i]["challan_challan_date"].ToString();
                    tSUBFADJUST.REASON = dt.Rows[i]["return_reason"].ToString();
                    decimal num = Convert.ToDecimal(dt.Rows[i]["challan_price"]);
                    tSUBFADJUST.VALUE = num.ToString("0.00");
                    tSUBFADJUST.QUANTITY = Utilities.formatFraction(Convert.ToDecimal(dt.Rows[i]["challan_quantity"]));
                    decimal num1 = Convert.ToDecimal(dt.Rows[i]["challan_vat"]);
                    tSUBFADJUST.VAT = num1.ToString("0.00");
                    decimal num2 = Convert.ToDecimal(dt.Rows[i]["challan_sd"]);
                    tSUBFADJUST.SD = num2.ToString("0.00");
                    decimal num3 = Convert.ToDecimal(dt.Rows[i]["note_price"]);
                    tSUBFADJUST.VALUE_ADJ = num3.ToString("0.00");
                    tSUBFADJUST.QUANTITY_ADJ = Utilities.formatFraction(Convert.ToDecimal(dt.Rows[i]["quantity"]));
                    decimal num4 = Convert.ToDecimal(dt.Rows[i]["note_vat"]);
                    tSUBFADJUST.VAT_ADJ = num4.ToString("0.00");
                    decimal num5 = Convert.ToDecimal(dt.Rows[i]["note_sd"]);
                    tSUBFADJUST.SD_ADJ = num5.ToString("0.00");
                    tSUBFADJUST.NOTE = "";
                    tSUBFADJUSTs.Add(tSUBFADJUST);
                }
            }
            return tSUBFADJUSTs;
        }

        private XElement GenerateIT_SUBF_ADJUSTNode()
        {
            string empty = string.Empty;
            string str = string.Empty;
            empty = this.dtpDateFrom.Text.ToString();
            str = this.dtpDateTo.Text.ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "IT_SUBF_ADJUST") };
            XElement firstNode = (XElement)(new XDocument(xDeclaration, xElement)).FirstNode;
            DataTable subformData26 = this.dbBLL.getSubformData26(empty, str, num);
            DataTable subformData31 = this.dbBLL.getSubformData31(empty, str, num);
            this.GenerateElementNote26_31(subformData26, "SL126", firstNode);
            this.GenerateElementNote26_31(subformData31, "SL131", firstNode);
            return firstNode;
        }

        private List<IT_SUBF_CHALLAN> GenerateIT_SUBF_CHALLAN(DataTable dt, string noteNo)
        {
            List<IT_SUBF_CHALLAN> tSUBFCHALLANs = new List<IT_SUBF_CHALLAN>();
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IT_SUBF_CHALLAN tSUBFCHALLAN = new IT_SUBF_CHALLAN()
                        {
                            FIELD_ID = noteNo,
                            CHALL_NO = dt.Rows[i]["tr_challan_no"].ToString(),
                            CHALL_DATE = dt.Rows[i]["date_challan"].ToString()
                        };
                        decimal num = Convert.ToDecimal(dt.Rows[i]["amount"]);
                        tSUBFCHALLAN.CHAN_AMT = num.ToString("0.00");
                        tSUBFCHALLAN.NOTES = dt.Rows[i]["remarks"].ToString();
                        tSUBFCHALLAN.BANCD = dt.Rows[i]["bank_code"].ToString();
                        tSUBFCHALLAN.BANKL = dt.Rows[i]["branch_code"].ToString();
                        tSUBFCHALLAN.A_NAMEOFBANK = dt.Rows[i]["bank_name"].ToString();
                        tSUBFCHALLAN.A_BRANCH = dt.Rows[i]["branch_name"].ToString();
                        tSUBFCHALLANs.Add(tSUBFCHALLAN);
                    }
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
            return tSUBFCHALLANs;
        }

        private XElement GenerateIT_SUBF_CHALLANNode()
        {
            string empty = string.Empty;
            string str = string.Empty;
            empty = this.dtpDateFrom.Text.ToString();
            str = this.dtpDateTo.Text.ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "IT_SUBF_CHALLAN") };
            XElement firstNode = (XElement)(new XDocument(xDeclaration, xElement)).FirstNode;
            DataTable vatReturnPart852DataSubReport = this.dbBLL.getVatReturnPart852DataSubReport(empty, str, num);
            DataTable vatReturnPart853DataSubReport = this.dbBLL.getVatReturnPart853DataSubReport(empty, str, num);
            DataTable vatReturnPart857DataSubReport = this.dbBLL.getVatReturnPart857DataSubReport(empty, str, num);
            DataTable vatReturnPart858DataSubReport = this.dbBLL.getVatReturnPart858DataSubReport(empty, str, num);
            DataTable vatReturnPart859DataSubReport = this.dbBLL.getVatReturnPart859DataSubReport(empty, str, num);
            DataTable vatReturnPart860DataSubReport = this.dbBLL.getVatReturnPart860DataSubReport(empty, str, num);
            DataTable vatReturnPart861DataSubReport = this.dbBLL.getVatReturnPart861DataSubReport(empty, str, num);
            this.GenerateElementNote58_64(vatReturnPart852DataSubReport, "SL53", firstNode);
            this.GenerateElementNote58_64(vatReturnPart853DataSubReport, "SL54", firstNode);
            this.GenerateElementNote58_64(vatReturnPart857DataSubReport, "SL58", firstNode);
            this.GenerateElementNote58_64(vatReturnPart858DataSubReport, "SL59", firstNode);
            this.GenerateElementNote58_64(vatReturnPart859DataSubReport, "SL60", firstNode);
            this.GenerateElementNote58_64(vatReturnPart860DataSubReport, "SL61", firstNode);
            this.GenerateElementNote58_64(vatReturnPart861DataSubReport, "SL52", firstNode);
            return firstNode;
        }

        private XElement GenerateIT_SUBF_GOSER()
        {
            string empty = string.Empty;
            string str = string.Empty;
            empty = this.dtpDateFrom.Text.ToString();
            str = this.dtpDateTo.Text.ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "IT_SUBF_GOSERV") };
            XElement firstNode = (XElement)(new XDocument(xDeclaration, xElement)).FirstNode;
            DataTable vatReturnPart3DataRow1SubReport = this.dbBLL.getVatReturnPart3DataRow1SubReport(empty, str, num);
            DataTable vatReturnPart3DataRow2SubReport = this.dbBLL.getVatReturnPart3DataRow2SubReport(empty, str, num);
            DataTable vatReturnPart3DataRow3SubReport = this.dbBLL.getVatReturnPart3DataRow3SubReport(empty, str, num);
            DataTable vatReturnPart3DataSubReport = this.dbBLL.getVatReturnPart3DataSubReport(empty, str, num);
            DataTable vatReturnPart3SubReport5 = this.dbBLL.getVatReturnPart3SubReport5(empty, str, num);
            DataTable vatSubFormNote6 = this.dbBLL.getVatSubFormNote6(empty, str, num);
            DataTable vatReturnPart3DataRow7SubReport = this.dbBLL.getVatReturnPart3DataRow7SubReport(empty, str, num);
            DataTable note8SubReport = this.dbBLL.getNote8SubReport(empty, str, num);
            DataTable vatReturnPart4DataRow10SubReport = this.dbBLL.getVatReturnPart4DataRow10SubReport(empty, str, num);
            DataTable vatReturnPart4DataRow11SubReport = this.dbBLL.getVatReturnPart4DataRow11SubReport(empty, str, num);
            DataTable subFormKaNote12 = this.dbBLL.getSubFormKa_Note12(empty, str, num);
            DataTable subFormKaNote13 = this.dbBLL.getSubFormKa_Note13(empty, str, num);
            DataTable vatReturnPart4DataRow14DataSubReport = this.dbBLL.getVatReturnPart4DataRow14DataSubReport(empty, str, num);
            DataTable vatReturnPart4DataRow15DataSubReport = this.dbBLL.getVatReturnPart4DataRow15DataSubReport(empty, str, num);
            DataTable vatReturnPart4DataRow16DataSubReport = this.dbBLL.getVatReturnPart4DataRow16DataSubReport(empty, str, num);
            DataTable vatReturnPart4DataRow17DataSubReport = this.dbBLL.getVatReturnPart4DataRow17DataSubReport(empty, str, num);
            DataTable vatSubFormNote18 = this.dbBLL.getVatSubFormNote18(empty, str, num);
            DataTable vatReturnPart4DataturnoverSubReport = this.dbBLL.getVatReturnPart4DataturnoverSubReport(empty, str, num);
            DataTable vatReturnPart4DataNotregisteredSubReport = this.dbBLL.getVatReturnPart4DataNotregisteredSubReport(empty, str, num);
            DataTable vatReturnPart4DataSubReport = this.dbBLL.getVatReturnPart4DataSubReport(empty, str, num);
            DataTable vatReturnPartImport4DataSubReport = this.dbBLL.getVatReturnPartImport4DataSubReport(empty, str, num);
            this.GenerateElementNote1_23(vatReturnPart3DataRow1SubReport, "SL01", firstNode);
            this.GenerateElementNote1_23(vatReturnPart3DataRow2SubReport, "SL02", firstNode);
            this.GenerateElementNote1_23(vatReturnPart3DataRow3SubReport, "SL03", firstNode);
            this.GenerateElementNote1_23(vatReturnPart3DataSubReport, "SL04", firstNode);
            this.GenerateElementNote1_23(vatReturnPart3SubReport5, "SL05", firstNode);
            this.GenerateElementNote1_23(vatSubFormNote6, "SL06", firstNode);
            this.GenerateElementNote1_23(vatReturnPart3DataRow7SubReport, "SL07", firstNode);
            this.GenerateElementNote1_23(note8SubReport, "SL08", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataRow10SubReport, "SL10", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataRow11SubReport, "SL11", firstNode);
            this.GenerateElementNote1_23(subFormKaNote12, "SL12", firstNode);
            this.GenerateElementNote1_23(subFormKaNote13, "SL13", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataRow14DataSubReport, "SL14", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataRow15DataSubReport, "SL15", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataRow16DataSubReport, "SL16", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataRow17DataSubReport, "SL17", firstNode);
            this.GenerateElementNote1_23(vatSubFormNote18, "SL18", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataturnoverSubReport, "SL20", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataNotregisteredSubReport, "SL21", firstNode);
            this.GenerateElementNote1_23(vatReturnPart4DataSubReport, "SL22", firstNode);
            this.GenerateElementNote1_23(vatReturnPartImport4DataSubReport, "SL23", firstNode);
            return firstNode;
        }

        private List<IT_SUBF_GOSERV> GenerateIT_SUBF_GOSERV(DataTable dt, string noteNo)
        {
            List<IT_SUBF_GOSERV> tSUBFGOSERVs = new List<IT_SUBF_GOSERV>();
            decimal num = new decimal(0);
            decimal num1 = new decimal(0);
            string str = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IT_SUBF_GOSERV tSUBFGOSERV = new IT_SUBF_GOSERV()
                    {
                        FIELD_ID = noteNo
                    };
                    num = Convert.ToDecimal(dt.Rows[i]["vat_rate"]);
                    num1 = Convert.ToDecimal(dt.Rows[i]["sd_rate"]);
                    tSUBFGOSERV.GOOD_SERVICE = dt.Rows[i]["hs_code"].ToString();
                    if (noteNo == "SL01" || noteNo == "SL11" || noteNo == "SL13" || noteNo == "SL15" || noteNo == "SL17" || noteNo == "SL23")
                    {
                        decimal num2 = Convert.ToDecimal(dt.Rows[i]["assesment_amount"]);
                        tSUBFGOSERV.ASSESS_VALUE = num2.ToString("0.00");
                        decimal num3 = Convert.ToDecimal(dt.Rows[i]["at"]);
                        tSUBFGOSERV.AT = num3.ToString("0.00");
                        tSUBFGOSERV.BOE_DATE = dt.Rows[i]["date_challan"].ToString();
                        tSUBFGOSERV.BOE_ITM_NO = dt.Rows[i]["no_of_item"].ToString();
                        tSUBFGOSERV.BOE_NO = dt.Rows[i]["challan_no"].ToString();
                        tSUBFGOSERV.BOE_OFF_CODE = dt.Rows[i]["port_code"].ToString();
                        str = dt.Rows[i]["cpc"].ToString();
                        tSUBFGOSERV.CPC_CODE = VATReturnMushok19sR.get_cpccode(str, noteNo);
                        if (tSUBFGOSERV.CPC_CODE == "")
                        {
                            VATReturnMushok19sR vATReturnMushok19 = this;
                            string errorList = vATReturnMushok19.ErrorList;
                            string[] gOODSERVICE = new string[] { errorList, "Invalid CPC for ", tSUBFGOSERV.GOOD_SERVICE, " ", noteNo, ". \n" };
                            vATReturnMushok19.ErrorList = string.Concat(gOODSERVICE);
                        }
                    }
                    if (noteNo == "SL13" || noteNo == "SL15" || noteNo == "SL17" || noteNo == "SL23")
                    {
                        tSUBFGOSERV.BOE_TYPE = "3";
                    }
                    if (noteNo == "SL02")
                    {
                        tSUBFGOSERV.INVOICE_DATE = dt.Rows[i]["date_challan"].ToString();
                        tSUBFGOSERV.INVOICE_NO = dt.Rows[i]["challan_no"].ToString();
                    }
                    if (noteNo == "SL08")
                    {
                        tSUBFGOSERV.CATEGORY = "01";
                    }
                    if (noteNo == "SL06" || noteNo == "SL18")
                    {
                        decimal num4 = Convert.ToDecimal(dt.Rows[i]["price"]);
                        tSUBFGOSERV.ACT_SALE_VALUE = num4.ToString("0.00");
                        tSUBFGOSERV.QUANTITY = Utilities.formatFraction(Convert.ToDecimal(dt.Rows[i]["quantity"]));
                    }
                    tSUBFGOSERV.DESCRIPTION = dt.Rows[i]["details"].ToString();
                    if (noteNo == "SL06" || noteNo == "SL18")
                    {
                        tSUBFGOSERV.ITEM_ID = VATReturnMushok19sR.get_goodsService1(num, num1, tSUBFGOSERV.GOOD_SERVICE, noteNo);
                    }
                    else if (noteNo == "SL14" || noteNo == "SL15")
                    {
                        tSUBFGOSERV.ITEM_ID = VATReturnMushok19sR.get_goodsService2(num, num1, tSUBFGOSERV.GOOD_SERVICE, noteNo);
                    }
                    else if (noteNo != "SL20")
                    {
                        tSUBFGOSERV.ITEM_ID = VATReturnMushok19sR.get_goodsService(num, num1, tSUBFGOSERV.GOOD_SERVICE, noteNo);
                    }
                    else
                    {
                        tSUBFGOSERV.ITEM_ID = VATReturnMushok19sR.get_goodsService3(num, num1, tSUBFGOSERV.GOOD_SERVICE, noteNo);
                    }
                    if (tSUBFGOSERV.ITEM_ID == "")
                    {
                        VATReturnMushok19sR vATReturnMushok191 = this;
                        string errorList1 = vATReturnMushok191.ErrorList;
                        string[] strArrays = new string[] { errorList1, "Invalid for ", tSUBFGOSERV.GOOD_SERVICE, " ", noteNo, ". \n" };
                        vATReturnMushok191.ErrorList = string.Concat(strArrays);
                    }
                    tSUBFGOSERV.NOTES = dt.Rows[i]["remarks"].ToString();
                    if (noteNo != "SL06" && noteNo != "SL18")
                    {
                        decimal num5 = Convert.ToDecimal(dt.Rows[i]["price"]);
                        tSUBFGOSERV.VALUE = num5.ToString("0.00");
                    }
                    if (noteNo == "SL01" || noteNo == "SL02" || noteNo == "SL11" || noteNo == "SL13" || noteNo == "SL15" || noteNo == "SL17" || noteNo == "SL23")
                    {
                        decimal num6 = Convert.ToDecimal(dt.Rows[i]["sd"]);
                        tSUBFGOSERV.SD = num6.ToString("0.00");
                        decimal num7 = Convert.ToDecimal(dt.Rows[i]["vat"]);
                        tSUBFGOSERV.VAT = num7.ToString("0.00");
                    }
                    tSUBFGOSERVs.Add(tSUBFGOSERV);
                }
            }
            return tSUBFGOSERVs;
        }

        private List<IT_SUBF_OTHER> GenerateIT_SUBF_OTHER(DataTable dt, string noteNo)
        {
            List<IT_SUBF_OTHER> tSUBFOTHERs = new List<IT_SUBF_OTHER>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IT_SUBF_OTHER tSUBFOTHER = new IT_SUBF_OTHER()
                    {
                        FIELD_ID = noteNo,
                        CHALL_NO = dt.Rows[i]["note_no"].ToString(),
                        CHALL_DATE = dt.Rows[i]["date_note"].ToString()
                    };
                    decimal num = Convert.ToDecimal(dt.Rows[i]["rent"]);
                    tSUBFOTHER.AMOUNT = num.ToString("0.00");
                    decimal num1 = Convert.ToDecimal(dt.Rows[i]["VAT"]);
                    tSUBFOTHER.VAT = num1.ToString("0.00");
                    tSUBFOTHER.NOTES = string.Concat(dt.Rows[i]["oa_case_no"].ToString(), "  ", dt.Rows[i]["particulars"].ToString());
                    tSUBFOTHERs.Add(tSUBFOTHER);
                }
            }
            return tSUBFOTHERs;
        }

        private XElement GenerateIT_SUBF_OTHERNode()
        {
            string empty = string.Empty;
            string str = string.Empty;
            empty = this.dtpDateFrom.Text.ToString();
            str = this.dtpDateTo.Text.ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "IT_SUBF_OTHER") };
            XElement firstNode = (XElement)(new XDocument(xDeclaration, xElement)).FirstNode;
            DataTable details27 = this.dbBLL.getDetails27(empty, str, num);
            DataTable details33 = this.dbBLL.getDetails33(empty, str, num);
            this.GenerateElementNote27_32(details27, "SL127", firstNode);
            this.GenerateElementNote27_32(details33, "SL132", firstNode);
            return firstNode;
        }

        private List<NoteVDS> GenerateIT_SUBF_VDS(DataTable dt, string noteNo)
        {
            string str = "";
            List<NoteVDS> noteVDs = new List<NoteVDS>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NoteVDS noteVD = new NoteVDS()
                    {
                        FIELD_ID = noteNo,
                        BIN = dt.Rows[i]["party_bin"].ToString().Trim(),
                        NAME = dt.Rows[i]["party_name"].ToString(),
                        ADDRESS = dt.Rows[i]["party_address"].ToString()
                    };
                    decimal num = Convert.ToDecimal(dt.Rows[i]["price1"]);
                    noteVD.VALUE = num.ToString("0.00");
                    decimal num1 = Convert.ToDecimal(dt.Rows[i]["Vat"]);
                    noteVD.DEDUCT_VAT = num1.ToString("0.00");
                    noteVD.INVOICE_NO = dt.Rows[i]["challan_no"].ToString();
                    noteVD.INVOICE_DATE = dt.Rows[i]["date_challan"].ToString();
                    noteVD.CERT_NO = dt.Rows[i]["vds_cert_issued_no"].ToString();
                    noteVD.CERT_DATE = dt.Rows[i]["vds_cert_issued_date"].ToString();
                    str = dt.Rows[i]["account_code"].ToString();
                    string[] strArrays = new string[str.Length];
                    for (int j = 0; j <= str.Length - 1; j++)
                    {
                        strArrays[j] = str[j].ToString();
                    }
                    string[] strArrays1 = new string[] { strArrays[0], "/", strArrays[1], strArrays[2], strArrays[3], strArrays[4], "/", strArrays[5], strArrays[6], strArrays[7], strArrays[8], "/", strArrays[9], strArrays[10], strArrays[11], strArrays[12] };
                    noteVD.ACCOUNT_CODE = string.Concat(strArrays1);
                    noteVD.DEPOSIT_NO = dt.Rows[i]["tax_deposit_serial_no"].ToString();
                    noteVD.DEPOSIT_DATE = dt.Rows[i]["tax_deposit_date"].ToString();
                    noteVD.NOTE = dt.Rows[i]["remarks"].ToString();
                    noteVDs.Add(noteVD);
                }
            }
            return noteVDs;
        }

        private XElement GenerateIT_SUBF_VDSNode()
        {
            string empty = string.Empty;
            string str = string.Empty;
            empty = this.dtpDateFrom.Text.ToString();
            str = this.dtpDateTo.Text.ToString();
            int num = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
            XNamespace xNamespace = "http://nbr.gov.bd/regist91";
            XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
            object[] xElement = new object[] { new XElement(xNamespace + "IT_SUBF_VDS") };
            XElement firstNode = (XElement)(new XDocument(xDeclaration, xElement)).FirstNode;
            DataTable vatReturnPart6DataRow29SubReport = this.dbBLL.getVatReturnPart6DataRow29SubReport(empty, str, num);
            DataTable vatReturnNote29SubReport = this.dbBLL.getVatReturnNote29SubReport(empty, str, num);
            this.GenerateElementNote24_29(vatReturnPart6DataRow29SubReport, "SL25", firstNode);
            this.GenerateElementNote24_29(vatReturnNote29SubReport, "SL30", firstNode);
            return firstNode;
        }

        public static string get_cpccode(string cpcCode, string noteNo)
        {
            HttpContext.Current.Session["periodkey"].ToString();
            string str = string.Concat("%", noteNo, "%");
            string end = "";
            HttpWebRequest httpWebRequest = VATReturnMushok19sR.CreateWebRequest();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(string.Concat(" <soap:Envelope xmlns:tem=\"http://tempuri.org/\"  xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">\r\n                  <soap:Header/>\r\n                  <soap:Body>\r\n                   <tem:Action>\r\n                     <!--Optional:-->\r\n                     <tem:json>{\r\n                        \"auth\": {\r\n                        \"username\":\"nbr\",\r\n                        \"password\":\"nbr@return\"\r\n                                    },\r\n                        \"body\": {\r\n                         \"api\":\"get_cpc_code\",\r\n                        \"method\":\"get\",\r\n                         \"list\": [{\"parameter\": \r\n                 [{ \"param_name\":\"SERIAL\",\"value\":'", str, "'}]}]\r\n                                }     \r\n                                 } \r\n                     </tem:json >\r\n                    </tem:Action >  \r\n                    </soap:Body>\r\n                     </soap:Envelope>"));
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                xmlDocument.Save(requestStream);
            }
            string cPCCODE = "";
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    end = streamReader.ReadToEnd();
                    XElement xElement = VATReturnMushok19sR.RemoveAllNamespaces(XElement.Parse(end));
                    string str1 = xElement.ToString();
                    XmlDocument xmlDocument1 = new XmlDocument();
                    xmlDocument1.LoadXml(str1);
                    string str2 = JsonConvert.SerializeXmlNode(xmlDocument1.ChildNodes[0].ChildNodes[0].ChildNodes[0], Newtonsoft.Json.Formatting.None, true);
                    string actionResult = JsonConvert.DeserializeObject<VATReturnMushok19sR.ActionRoot>(str2).ActionResult;
                    List<VATReturnMushok19sR.CpcCode> cpcCodes = JsonConvert.DeserializeObject<VATReturnMushok19sR.CpcCodeRoot>(actionResult).response.items;
                    if (cpcCodes != null && cpcCodes.Count > 0)
                    {
                        int num = 0;
                        while (num < cpcCodes.Count)
                        {
                            if (cpcCodes[num].CPC_CODE != cpcCode)
                            {
                                num++;
                            }
                            else
                            {
                                cPCCODE = cpcCodes[num].CPC_CODE;
                                break;
                            }
                        }
                    }
                }
            }
            return cPCCODE;
        }

        public static string get_goodsService(decimal vatRate, decimal sdRate, string hsCode, string noteNo)
        {
            string str = HttpContext.Current.Session["periodkey"].ToString();
            string str1 = string.Concat("%", noteNo, "%");
            string end = "";
            HttpWebRequest httpWebRequest = VATReturnMushok19sR.CreateWebRequest();
            XmlDocument xmlDocument = new XmlDocument();
            string[] strArrays = new string[] { " <soap:Envelope xmlns:tem=\"http://tempuri.org/\"  xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">\r\n                  <soap:Header/>\r\n                  <soap:Body>\r\n                   <tem:Action>\r\n                     <!--Optional:-->\r\n                     <tem:json>{\r\n                        \"auth\": {\r\n                        \"username\":\"nbr\",\r\n                        \"password\":\"nbr@return\"\r\n                                    },\r\n                        \"body\": {\r\n                         \"api\":\"get_goodsService\",\r\n                        \"method\":\"get\",\r\n                         \"list\": [{\"parameter\": \r\n                 [{ \"param_name\":\"GOSERV_CODE\",\"value\":'", hsCode, "'},\r\n                  { \"param_name\":\"PERIOD_KEY\",\"value\":'", str, "'},\r\n                  { \"param_name\":\"SERIAL\",\"value\":'", str1, "'}]}]\r\n                                }     \r\n                                 } \r\n                     </tem:json >\r\n                    </tem:Action >  \r\n                    </soap:Body>\r\n                     </soap:Envelope>" };
            xmlDocument.LoadXml(string.Concat(strArrays));
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                xmlDocument.Save(requestStream);
            }
            string tEMID = "";
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    end = streamReader.ReadToEnd();
                    XElement xElement = VATReturnMushok19sR.RemoveAllNamespaces(XElement.Parse(end));
                    string str2 = xElement.ToString();
                    XmlDocument xmlDocument1 = new XmlDocument();
                    xmlDocument1.LoadXml(str2);
                    string str3 = JsonConvert.SerializeXmlNode(xmlDocument1.ChildNodes[0].ChildNodes[0].ChildNodes[0], Newtonsoft.Json.Formatting.None, true);
                    string actionResult = JsonConvert.DeserializeObject<VATReturnMushok19sR.ActionRoot>(str3).ActionResult;
                    List<VATReturnMushok19sR.ApiItem> apiItems = JsonConvert.DeserializeObject<VATReturnMushok19sR.ResponseRoot>(actionResult).response.items;
                    decimal num = new decimal(0);
                    decimal num1 = new decimal(0);
                    if (apiItems != null && apiItems.Count > 0)
                    {
                        int num2 = 0;
                        while (num2 < apiItems.Count)
                        {
                            num = Convert.ToDecimal(apiItems[num2].VAT_RATE);
                            num1 = Convert.ToDecimal(apiItems[num2].SD_RATE);
                            if (!(apiItems[num2].VALID_TO == " ") || !(num == vatRate) || !(num1 == sdRate))
                            {
                                num2++;
                            }
                            else
                            {
                                tEMID = apiItems[num2].ITEM_ID;
                                break;
                            }
                        }
                    }
                }
            }
            return tEMID;
        }

        public static string get_goodsService1(decimal vatRate, decimal sdRate, string hsCode, string noteNo)
        {
            string str = HttpContext.Current.Session["periodkey"].ToString();
            string str1 = string.Concat("%", noteNo, "%");
            string end = "";
            HttpWebRequest httpWebRequest = VATReturnMushok19sR.CreateWebRequest();
            XmlDocument xmlDocument = new XmlDocument();
            string[] strArrays = new string[] { " <soap:Envelope xmlns:tem=\"http://tempuri.org/\"  xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">\r\n                  <soap:Header/>\r\n                  <soap:Body>\r\n                   <tem:Action>\r\n                     <!--Optional:-->\r\n                     <tem:json>{\r\n                        \"auth\": {\r\n                        \"username\":\"nbr\",\r\n                        \"password\":\"nbr@return\"\r\n                                    },\r\n                        \"body\": {\r\n                         \"api\":\"get_goodsService_01\",\r\n                        \"method\":\"get\",\r\n                         \"list\": [{\"parameter\": \r\n                 [{ \"param_name\":\"GOSERV_CODE\",\"value\":'", hsCode, "'},\r\n                  { \"param_name\":\"PERIOD_KEY\",\"value\":'", str, "'},\r\n                  { \"param_name\":\"SERIAL\",\"value\":'", str1, "'}]}]\r\n                                }     \r\n                                 } \r\n                     </tem:json >\r\n                    </tem:Action >  \r\n                    </soap:Body>\r\n                     </soap:Envelope>" };
            xmlDocument.LoadXml(string.Concat(strArrays));
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                xmlDocument.Save(requestStream);
            }
            string tEMID = "";
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    end = streamReader.ReadToEnd();
                    XElement xElement = VATReturnMushok19sR.RemoveAllNamespaces(XElement.Parse(end));
                    string str2 = xElement.ToString();
                    XmlDocument xmlDocument1 = new XmlDocument();
                    xmlDocument1.LoadXml(str2);
                    string str3 = JsonConvert.SerializeXmlNode(xmlDocument1.ChildNodes[0].ChildNodes[0].ChildNodes[0], Newtonsoft.Json.Formatting.None, true);
                    string actionResult = JsonConvert.DeserializeObject<VATReturnMushok19sR.ActionRoot>(str3).ActionResult;
                    List<VATReturnMushok19sR.ApiItem> apiItems = JsonConvert.DeserializeObject<VATReturnMushok19sR.ResponseRoot>(actionResult).response.items;
                    if (apiItems != null && apiItems.Count > 0)
                    {
                        int num = 0;
                        while (num < apiItems.Count)
                        {
                            if (!(apiItems[num].VALID_TO == " ") || !(Convert.ToDecimal(apiItems[num].SPECIFIC_RATE) == vatRate))
                            {
                                num++;
                            }
                            else
                            {
                                tEMID = apiItems[num].ITEM_ID;
                                break;
                            }
                        }
                    }
                }
            }
            return tEMID;
        }

        public static string get_goodsService2(decimal vatRate, decimal sdRate, string hsCode, string noteNo)
        {
            string str = HttpContext.Current.Session["periodkey"].ToString();
            string str1 = string.Concat("%", noteNo, "%");
            string end = "";
            HttpWebRequest httpWebRequest = VATReturnMushok19sR.CreateWebRequest();
            XmlDocument xmlDocument = new XmlDocument();
            string[] strArrays = new string[] { " <soap:Envelope xmlns:tem=\"http://tempuri.org/\"  xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">\r\n                  <soap:Header/>\r\n                  <soap:Body>\r\n                   <tem:Action>\r\n                     <!--Optional:-->\r\n                     <tem:json>{\r\n                        \"auth\": {\r\n                        \"username\":\"nbr\",\r\n                        \"password\":\"nbr@return\"\r\n                                    },\r\n                        \"body\": {\r\n                         \"api\":\"get_goodsService_02\",\r\n                        \"method\":\"get\",\r\n                         \"list\": [{\"parameter\": \r\n                 [{ \"param_name\":\"GOSERV_CODE\",\"value\":'", hsCode, "'},\r\n                  { \"param_name\":\"PERIOD_KEY\",\"value\":'", str, "'},\r\n                  { \"param_name\":\"SERIAL\",\"value\":'", str1, "'}]}]\r\n                                }     \r\n                                 } \r\n                     </tem:json >\r\n                    </tem:Action >  \r\n                    </soap:Body>\r\n                     </soap:Envelope>" };
            xmlDocument.LoadXml(string.Concat(strArrays));
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                xmlDocument.Save(requestStream);
            }
            string tEMID = "";
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    end = streamReader.ReadToEnd();
                    XElement xElement = VATReturnMushok19sR.RemoveAllNamespaces(XElement.Parse(end));
                    string str2 = xElement.ToString();
                    XmlDocument xmlDocument1 = new XmlDocument();
                    xmlDocument1.LoadXml(str2);
                    string str3 = JsonConvert.SerializeXmlNode(xmlDocument1.ChildNodes[0].ChildNodes[0].ChildNodes[0], Newtonsoft.Json.Formatting.None, true);
                    string actionResult = JsonConvert.DeserializeObject<VATReturnMushok19sR.ActionRoot>(str3).ActionResult;
                    List<VATReturnMushok19sR.ApiItem> apiItems = JsonConvert.DeserializeObject<VATReturnMushok19sR.ResponseRoot>(actionResult).response.items;
                    if (apiItems != null && apiItems.Count > 0)
                    {
                        int num = 0;
                        while (num < apiItems.Count)
                        {
                            if (!(apiItems[num].VALID_TO == " ") || !(Convert.ToDecimal(apiItems[num].VAT_RATE) == vatRate) || !(Convert.ToDecimal(apiItems[num].SD_RATE) == sdRate))
                            {
                                num++;
                            }
                            else
                            {
                                tEMID = apiItems[num].ITEM_ID;
                                break;
                            }
                        }
                    }
                }
            }
            return tEMID;
        }

        public static string get_goodsService3(decimal vatRate, decimal sdRate, string hsCode, string noteNo)
        {
            string str = HttpContext.Current.Session["periodkey"].ToString();
            string str1 = string.Concat("%", noteNo, "%");
            string end = "";
            HttpWebRequest httpWebRequest = VATReturnMushok19sR.CreateWebRequest();
            XmlDocument xmlDocument = new XmlDocument();
            string[] strArrays = new string[] { " <soap:Envelope xmlns:tem=\"http://tempuri.org/\"  xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\">\r\n                  <soap:Header/>\r\n                  <soap:Body>\r\n                   <tem:Action>\r\n                     <!--Optional:-->\r\n                     <tem:json>{\r\n                        \"auth\": {\r\n                        \"username\":\"nbr\",\r\n                        \"password\":\"nbr@return\"\r\n                                    },\r\n                        \"body\": {\r\n                         \"api\":\"get_goodsService_03\",\r\n                        \"method\":\"get\",\r\n                         \"list\": [{\"parameter\": \r\n                 [{ \"param_name\":\"GOSERV_CODE\",\"value\":'", hsCode, "'},\r\n                  { \"param_name\":\"PERIOD_KEY\",\"value\":'", str, "'},\r\n                  { \"param_name\":\"SERIAL\",\"value\":'", str1, "'}]}]\r\n                                }     \r\n                                 } \r\n                     </tem:json >\r\n                    </tem:Action >  \r\n                    </soap:Body>\r\n                     </soap:Envelope>" };
            xmlDocument.LoadXml(string.Concat(strArrays));
            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                xmlDocument.Save(requestStream);
            }
            string tEMID = "";
            using (WebResponse response = httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                {
                    end = streamReader.ReadToEnd();
                    XElement xElement = VATReturnMushok19sR.RemoveAllNamespaces(XElement.Parse(end));
                    string str2 = xElement.ToString();
                    XmlDocument xmlDocument1 = new XmlDocument();
                    xmlDocument1.LoadXml(str2);
                    string str3 = JsonConvert.SerializeXmlNode(xmlDocument1.ChildNodes[0].ChildNodes[0].ChildNodes[0], Newtonsoft.Json.Formatting.None, true);
                    string actionResult = JsonConvert.DeserializeObject<VATReturnMushok19sR.ActionRoot>(str3).ActionResult;
                    List<VATReturnMushok19sR.ApiItem> apiItems = JsonConvert.DeserializeObject<VATReturnMushok19sR.ResponseRoot>(actionResult).response.items;
                    if (apiItems != null && apiItems.Count > 0)
                    {
                        int num = 0;
                        while (num < apiItems.Count)
                        {
                            if (!(apiItems[num].VALID_TO == " ") || !(Convert.ToDecimal(apiItems[num].VAT_RATE) == vatRate) || !(Convert.ToDecimal(apiItems[num].SD_RATE) == sdRate))
                            {
                                num++;
                            }
                            else
                            {
                                tEMID = apiItems[num].ITEM_ID;
                                break;
                            }
                        }
                    }
                }
            }
            return tEMID;
        }

        private void LoadReport()
        {
            this.ErrorList = "";
            try
            {
                XNamespace xNamespace = XNamespace.Get("http://www.w3.org/2001/XMLSchema-instance");
                XNamespace xNamespace1 = XNamespace.Get("http://nbr.gov.bd/regist91");
                XDeclaration xDeclaration = new XDeclaration("1.0", "UTF-8", string.Empty);
                object[] xElement = new object[1];
                XName xName = xNamespace1 + "MT_RET_MSG_REQ";
                object[] xAttribute = new object[] { new XAttribute(XNamespace.Xmlns + "xsi", xNamespace.NamespaceName), new XAttribute(xNamespace + "schemaLocation", "http://nbr.gov.bd/regist91 schema.xsd") };
                xElement[0] = new XElement(new XElement(xName, xAttribute));
                XDocument xDocument = new XDocument(xDeclaration, xElement);
                XElement firstNode = (XElement)xDocument.FirstNode;
                firstNode.Add(this.GenerateI_MSG_HDR());
                firstNode.Add(this.GenerateI_MAIN_FORM());
                firstNode.Add(this.GenerateIT_SUBF_GOSER());
                firstNode.Add(this.GenerateIT_SUBF_VDSNode());
                firstNode.Add(this.GenerateIT_SUBF_CHALLANNode());
                firstNode.Add(this.GenerateIT_SUBF_ADJUSTNode());
                firstNode.Add(this.GenerateIT_SUBF_OTHERNode());
                xDocument.Save(base.Server.MapPath("FileName.xml"));
                xDocument.ToString();
                this.ValidateXML(base.Server.MapPath("FileName.xml"));
                if (this.ErrorList != "")
                {
                    this.ErrorList = this.ErrorList.Replace("\n", string.Concat("\n", Environment.NewLine));
                    this.lblError.Text = this.ErrorList;
                }
                else if (this.lblStatus.Text == "Validation Passed")
                {
                    this.DownloadFile(base.Server.MapPath("FileName.xml"));
                }
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // MQMM.LoginCheckForUser();
            if (!base.IsPostBack)
            {
                this.Session["transecID"] = "";
                this.Session["report_values"] = "";
                this.dtpDateFrom.Text = DateTime.Now.ToString("01/MM/yyyy");
                this.dtpDateTo.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //KALLOL CHEMICAL LIMITED

                //this.TaxOrganizationName.Text = "KALLOL CHEMICALS LIMITED";
                //this.TaxOrganizationAddress.Text = "147,148,153,154 Tongi I/A, Gazipur-1710, Tongi PS,Gazipur-1710, Bangladesh";
                //string str = "000002317-0102";

                txtSubmit.Text = DateTime.Now.ToString("dd/MM/yyyy");

                //LION KALLOL LIMITED
                this.TaxOrganizationName.Text = "LION KALLOL LIMITED";
                this.TaxOrganizationAddress.Text = "199, Tejgaon Industrial Area, Dhaka-1208; Tejgaon Industrial Area PS; Dhaka-1208; Bangladesh";
                string str = "005088304-0203";



                //   KALLOL INDUSTRIES LTD

                //this.TaxOrganizationName.Text = "KALLOL INDUSTRIES LTD";
                //this.TaxOrganizationAddress.Text = "199, Tejgaon Industrial Area, Dhaka-1208, Tejgaon PS, Bangladesh";
                //string str = "000310265-0203";






                string str1 = "";
                for (int i = 0; i < str.Length; i++)
                {
                    object obj = str1;
                    object[] objArray = new object[] { obj, "<input type='text' value = '", str[i], "' runat='server' style='width:25px; text-align:center;border:1px solid #000'>" };
                    str1 = string.Concat(objArray);
                    this.TaxOrganizationBIN.Text = str1;
                }
                this.lblStatus.Text = "";
             
                //(this.Session["EMPLOYEE_NAME"] != null ? this.Session["EMPLOYEE_NAME"].ToString() : "NA");
                string designation = this.objVatReturn.GetDesignation(Convert.ToInt32(this.Session["DESIGNATION_ID"]));

                //designation;
             
                //(this.Session["EMAIL"] != null ? this.Session["EMAIL"].ToString() : "NA");
                this.lblPrintDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
                this.lblUser.Text = this.Session["employee_name"].ToString();
                int num = Convert.ToInt32(this.Session["ORGANIZATION_ID"]);

                // KALLOL CHEMICAL
                //this.TaxpayerNameP10.Text = "GULAM MOSTAFA";
                //this.TaxpayerDesignationP10.Text = "Managing Director";
                //this.TaxpayerMobileNoP10.Text = "01918784278";
                ////(this.Session["MOBILE_NO"] != null ? this.Session["MOBILE_NO"].ToString() : "NA");
                //this.TaxpayerEmailP10.Text = "ar_atik@ymail.com";
                //this.txtNID.Text = "4193412089";

                //// KALLOL HOLDINGS
                //this.TaxpayerNameP10.Text = "GHULAM MOSTAFA";
                //this.TaxpayerDesignationP10.Text = "Managing Director";
                //this.TaxpayerMobileNoP10.Text = "01787675121";
                ////(this.Session["MOBILE_NO"] != null ? this.Session["MOBILE_NO"].ToString() : "NA");
                //this.TaxpayerEmailP10.Text = "vat2@kallolgroup.com";
                //this.txtNID.Text = "4193412089";

                // LION KALLOL
                this.TaxpayerNameP10.Text = "MITSUI MASAAKI";
                this.TaxpayerDesignationP10.Text = "Managing Director";
                this.TaxpayerMobileNoP10.Text = "01787-675121";
                //(this.Session["MOBILE_NO"] != null ? this.Session["MOBILE_NO"].ToString() : "NA");
                this.TaxpayerEmailP10.Text = "ryoharu@lion.co.jp";
                this.txtNID.Text = "TR7100783";

                // KALLOL industries
                //this.TaxpayerNameP10.Text = "GULAM MOSTAFA";
                //this.TaxpayerDesignationP10.Text = "Managing Director";
                //this.TaxpayerMobileNoP10.Text = "01787675121";
                ////(this.Session["MOBILE_NO"] != null ? this.Session["MOBILE_NO"].ToString() : "NA");
                //this.TaxpayerEmailP10.Text = "vat2@kallolgroup.com";
                //this.txtNID.Text = "4193412089";




                DataTable nIDAuthorizePerson = this.dbBLL.getNIDAuthorizePerson(num);
          
                if (nIDAuthorizePerson.Rows.Count > 0)
                {
                   
                        //nIDAuthorizePerson.Rows[0]["nid"].ToString();
                }
                this.OrganizationBusinessNature.Text = " Private Limited";
                //organizationName.Rows[0]["business_type_name"].ToString();
                this.NatureOfBusiness.Text = "Services, Retail/Wholesale Trading, Imports";
                DataTable organizationName = this.dbBLL.getOrganizationName(this.TaxOrganizationName.Text.Trim());
                DataTable economicSpecification = this.dbBLL.getEconomicSpecification(num);
       
                string str2 = "";
                if (economicSpecification.Rows.Count > 0)
                {
                    for (int j = 0; j < economicSpecification.Rows.Count; j++)
                    {
                        str2 = string.Concat(str2, economicSpecification.Rows[j]["specification"].ToString(), ',');
                    }
                }
                if (organizationName.Rows.Count > 0)
                {
                    if (organizationName.Rows[0]["manufacturing_name"].ToString() != "")
                    {
                        str2 = string.Concat(str2, organizationName.Rows[0]["manufacturing_name"].ToString(), ',');
                    }
                    if (organizationName.Rows[0]["service_name"].ToString() != "")
                    {
                        str2 = string.Concat(str2, organizationName.Rows[0]["service_name"].ToString());
                    }
                    object obj1 = '(';
                    char[] chrArray = new char[] { ',' };
                    string.Concat(obj1, str2.TrimEnd(chrArray), ')');
                   
                        //organizationName.Rows[0]["economic_process_activity_name"].ToString();
                }
                this.dbBLL.getOrganizationCommissionarateCode(this.TaxOrganizationName.Text.Trim());
                this.Session["fDateSub"] = "";
                this.Session["tDateSub"] = "";
            }
        }

        protected void refresh()
        {
            this.AdvanceVatAmountN28P7.Text = "-";
        }

        public static string RemoveAllNamespaces(string xmlDocument)
        {
            return VATReturnMushok19sR.RemoveAllNamespaces(XElement.Parse(xmlDocument)).ToString();
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (xmlDocument.HasElements)
            {
                return new XElement(xmlDocument.Name.LocalName,
                    from el in xmlDocument.Elements()
                    select VATReturnMushok19sR.RemoveAllNamespaces(el));
            }
            XElement xElement = new XElement(xmlDocument.Name.LocalName)
            {
                Value = xmlDocument.Value
            };
            foreach (XAttribute xAttribute in xmlDocument.Attributes())
            {
                xElement.Add(xAttribute);
            }
            return xElement;
        }

        protected void SetDetail35Data()
        {
            decimal num = (this.Label26.Text.ToString().Length > 0 ? Convert.ToDecimal(this.Label26.Text.ToString()) : new decimal(0));
            if (num != new decimal(0))
            {
                this.node50Value.Text = num.ToString();
            }
            else
            {
                this.node50Value.Text = "-";
            }
            decimal num1 = (this.lblNineMushokKhaTotal.Text.ToString().Length > 0 ? Convert.ToDecimal(this.lblNineMushokKhaTotal.Text.ToString()) : new decimal(0));
            if (num1 != new decimal(0))
            {
                this.node9Value.Text = num1.ToString();
            }
            else
            {
                this.node9Value.Text = "-";
            }
            decimal num2 = num + num1;
            if (num2 != new decimal(0))
            {
                this.totalOf50and9Value.Text = num2.ToString();
            }
            else
            {
                this.totalOf50and9Value.Text = "-";
            }
            decimal num3 = (this.standardLocalPurchaseVatN12P4.Text.ToString().Length > 0 ? Convert.ToDecimal(this.standardLocalPurchaseVatN12P4.Text.ToString()) : new decimal(0));
            decimal num4 = num3 + (this.lblAdorshoHarBatitoMushokLcl.Text.ToString().Length > 0 ? Convert.ToDecimal(this.lblAdorshoHarBatitoMushokLcl.Text.ToString()) : new decimal(0));
            this.localPurchase23Value.Text = num4.ToString();
            decimal num5 = (this.standardForeignPurchaseVatN13P4.Text.ToString().Length > 0 ? Convert.ToDecimal(this.standardForeignPurchaseVatN13P4.Text.ToString()) : new decimal(0));
            decimal num6 = num5 + (this.lblAdorshoHarBatitoMushokImp.Text.ToString().Length > 0 ? Convert.ToDecimal(this.lblAdorshoHarBatitoMushokImp.Text.ToString()) : new decimal(0));
            this.import23Value.Text = num6.ToString();
            decimal num7 = num4 + num6;
            this.subTotal23Value.Text = num7.ToString();
            decimal num8 = num2 - num7;
            this.total23Value.Text = num8.ToString();
            decimal num9 = (this.lblTotalVatN21P5.Text.ToString().Length > 0 ? Convert.ToDecimal(this.lblTotalVatN21P5.Text.ToString()) : new decimal(0));
            this.node28Value.Text = num9.ToString();
            decimal num10 = num8 + num9;
            this.node28Total.Text = num10.ToString();
            decimal num11 = (this.lblTotalVatN26P6.Text.ToString().Length > 0 ? Convert.ToDecimal(this.lblTotalVatN26P6.Text.ToString()) : new decimal(0));
            this.node34Value.Text = num11.ToString();
            this.node34Total.Text = (num10 - num11).ToString();
        }

        private void ShowReport()
        {
            object[] objArray;
            char[] chrArray;
            this.refresh();
            ArrayList arrayLists = new ArrayList();
            int num = (!string.IsNullOrWhiteSpace(this.precisionTxtBox.Text) ? (int)Convert.ToInt16(this.precisionTxtBox.Text) : -1);
            DateTime minValue = DateTime.MinValue;
            DateTime dateTime = DateTime.MinValue;
            decimal num1 = new decimal(0);
            decimal num2 = new decimal(0);
            decimal num3 = new decimal(0);
            decimal num4 = new decimal(0);
            decimal num5 = new decimal(0);
            decimal num6 = new decimal(0);
            decimal num7 = new decimal(0);
            decimal num8 = new decimal(0);
            decimal num9 = new decimal(0);
            decimal num10 = new decimal(0);
            decimal num11 = new decimal(0);
            decimal num12 = new decimal(0);
            decimal num13 = new decimal(0);
            decimal num14 = new decimal(0);
            decimal num15 = new decimal(0);
            decimal num16 = new decimal(0);
            decimal num17 = new decimal(0);
            decimal num18 = new decimal(0);
            decimal num19 = new decimal(0);
            decimal num20 = new decimal(0);
            decimal num21 = new decimal(0);
            decimal num22 = new decimal(0);
            decimal num23 = new decimal(0);
            decimal num24 = new decimal(0);
            decimal num25 = new decimal(0);
            decimal num26 = new decimal(0);
            decimal num27 = new decimal(0);
            decimal num28 = new decimal(0);
            decimal num29 = new decimal(0);
            decimal num30 = new decimal(0);
            decimal num31 = new decimal(0);
            decimal num32 = new decimal(0);
            decimal num33 = new decimal(0);
            decimal num34 = new decimal(0);
            decimal num35 = new decimal(0);
            decimal num36 = new decimal(0);
            decimal num37 = new decimal(0);
            decimal num38 = new decimal(0);
            decimal num39 = new decimal(0);
            decimal num40 = new decimal(0);
            decimal num41 = new decimal(0);
            decimal num42 = new decimal(0);
            decimal num43 = new decimal(0);
            decimal num44 = new decimal(0);
            decimal num45 = new decimal(0);
            decimal num46 = new decimal(0);
            decimal num47 = new decimal(0);
            decimal num48 = new decimal(0);
            decimal num49 = new decimal(0);
            decimal num50 = new decimal(0);
            decimal num51 = new decimal(0);
            decimal num52 = new decimal(0);
            decimal num53 = new decimal(0);
            decimal num54 = new decimal(0);
            decimal num55 = new decimal(0);
            decimal num56 = new decimal(0);
            decimal num57 = new decimal(0);
            decimal num58 = new decimal(0);
            decimal num59 = new decimal(0);
            decimal num60 = new decimal(0);
            decimal num61 = new decimal(0);
            try
            {
                int num62 = Convert.ToInt32(HttpContext.Current.Session["ORGANIZATION_ID"]);
                string empty = string.Empty;
                DateTime dateTime1 = DateTime.ParseExact(this.dtpDateFrom.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string str = string.Empty;
                string empty1 = string.Empty;
                empty = this.dtpDateFrom.Text.ToString();
                str = this.dtpDateTo.Text.ToString();
                DateTime dateTime2 = DateTime.ParseExact(str, "dd/MM/yyyy", null);
                dateTime2.AddDays(1);
                empty1 = this.dtpDateTo.Text.ToString();
                this.Session["fDateSub"] = empty;
                this.Session["tDateSub"] = empty1;
                DateTime dt = DateTime.Parse(str, CultureInfo.GetCultureInfo("en-gb"));
                this.Session["fDateSubs"] = Convert.ToDateTime(this.dtpDateFrom.Text).ToString();
                this.Session["tDateSubs"] = Convert.ToDateTime(str).ToString();

                DateTime fromDate = Convert.ToDateTime(this.dtpDateFrom.Text);
                //if(fromDate.Month<6)
                //{
                //    throw new Exception(string.Concat("Data Not Found!"));
                //}







                this.Session["precision"] = num;
                this.lblTaxPeriod.Text = string.Concat(dateTime1.ToString("MMMM"), " / ", dateTime1.ToString("yyyy"));
                //  string str1 = DateTime.Now.ToString("dd/MM/yyyy");
                string str1 = Convert.ToDateTime(txtSubmit.Text).ToString("dd/MM/yyyy");
                string str2 = "";

                dateTime.ToString("dd/MM/yyyy");
                for (int i = 0; i < str1.Length; i++)
                {
                    object obj = str2;
                    objArray = new object[] { obj, "<input type='text' value = '", str1[i], "' runat='server' style = 'width:25px; text-align:center;border:1px solid #000'>" };
                    str2 = string.Concat(objArray);
                    this.lblReturnSubmitDate.Text = str2;
                }
                DataTable vatReturnPart3Data = this.dbBLL.getVatReturnPart3Data(empty, empty1, num62);
                DataTable vatReturnPart3DataAdorshoHarBatito = this.dbBLL.getVatReturnPart3DataAdorshoHarBatito(empty, empty1, num62);
                DataTable vatReturnPart3DataAdorsho = this.dbBLL.getVatReturnPart3DataAdorsho(empty, empty1, num62);
                DataTable saleExempted = this.dbBLL.getSaleExempted(empty, empty1, num62);
                DataTable fixedVatInfo = this.dbBLL.getFixedVatInfo(empty, empty1, num62);
                DataTable mRPInfo5 = this.dbBLL.getMRPInfo5(empty, empty1, num62);
                DataTable note8Data = this.dbBLL.getNote8Data(empty, empty1, num62);
                if (vatReturnPart3Data != null && vatReturnPart3Data.Rows.Count > 0)
                {
                    for (int j = 0; j < vatReturnPart3Data.Rows.Count; j++)
                    {
                        decimal num63 = new decimal(0);
                        char chr = '0';
                        bool flag = Convert.ToBoolean(vatReturnPart3Data.Rows[j]["deemed_export"]);
                        bool flag1 = Convert.ToBoolean(vatReturnPart3Data.Rows[j]["is_exempted"]);
                        num63 = Convert.ToDecimal(vatReturnPart3Data.Rows[j]["price"]);
                        Convert.ToDecimal(vatReturnPart3Data.Rows[j]["vat"]);
                        Convert.ToDecimal(vatReturnPart3Data.Rows[j]["sd"]);
                        char chr1 = Convert.ToChar(vatReturnPart3Data.Rows[j]["trans_type"]);
                        if (vatReturnPart3Data.Rows[j]["real_property"].ToString() != "")
                        {
                            chr = Convert.ToChar(vatReturnPart3Data.Rows[j]["real_property"]);
                        }
                        if (chr1 == 'E' && flag)
                        {
                            num2 += num63;
                        }
                        if (chr1 == 'E' && !flag)
                        {
                            num1 += num63;
                        }
                        if (flag1 && !flag)
                        {
                            num3 += num63;
                        }
                    }
                    if (num2 != new decimal(0))
                    {
                        this.zerorateDeemedExportAmountN1P3.Text = Utilities.convertEnglistNumberIntoBangla(num2.ToString("N2"));
                    }
                    else
                    {
                        this.zerorateDeemedExportAmountN1P3.Text = "-";
                    }
                    if (num1 != new decimal(0))
                    {
                        this.zerorateDirectExportAmountN2P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num1, num));
                    }
                    else
                    {
                        this.zerorateDirectExportAmountN2P3.Text = "-";
                    }
                    if (num3 != new decimal(0))
                    {
                        this.exemptedSupplyAmountN3P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num));
                    }
                    else
                    {
                        this.exemptedSupplyAmountN3P3.Text = "-";
                    }
                    if (num3 != new decimal(0))
                    {
                        this.nonTypicalSupplyAmountN6P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num3, num));
                    }
                    else
                    {
                        this.nonTypicalSupplyAmountN6P3.Text = "-";
                    }
                    if (num9 != new decimal(0))
                    {
                        this.nonTypicalSupplySDN6P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num9, num));
                    }
                    else
                    {
                        this.nonTypicalSupplySDN6P3.Text = "-";
                    }
                }
                decimal num64 = new decimal(0);
                decimal num65 = new decimal(0);
                decimal num66 = new decimal(0);
                if (mRPInfo5 == null || mRPInfo5.Rows.Count <= 0)
                {
                    this.note5AmountP3.Text = "-";
                    this.note5VATP3.Text = "-";
                    this.note5SDP3.Text = "-";
                }
                else
                {
                    for (int k = 0; k < mRPInfo5.Rows.Count; k++)
                    {
                        decimal num67 = new decimal(0);
                        decimal num68 = new decimal(0);
                        decimal num69 = new decimal(0);
                        num67 = Convert.ToDecimal(mRPInfo5.Rows[k]["price"]);
                        num68 = Convert.ToDecimal(mRPInfo5.Rows[k]["vat"]);
                        num69 = Convert.ToDecimal(mRPInfo5.Rows[k]["sd"]);
                        num64 += num67;
                        num65 += num68;
                        num66 += num69;
                    }
                    if (num64 != new decimal(0))
                    {
                        this.note5AmountP3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num64, num));
                    }
                    else
                    {
                        this.note5AmountP3.Text = "-";
                    }
                    if (num65 != new decimal(0))
                    {
                        this.note5VATP3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num65, num));
                    }
                    else
                    {
                        this.note5VATP3.Text = "-";
                    }
                    if (num66 != new decimal(0))
                    {
                        this.note5SDP3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num66, num));
                    }
                    else
                    {
                        this.note5SDP3.Text = "-";
                    }
                }
                if (vatReturnPart3DataAdorshoHarBatito == null || vatReturnPart3DataAdorshoHarBatito.Rows.Count <= 0)
                {
                    this.lblAdorshoHarBatitoMullo.Text = "-";
                    this.lblAdorshoHarBatitoMushok.Text = "-";
                    this.lblAdorshHarBatitoSD.Text = "-";
                }
                else
                {
                    for (int l = 0; l < vatReturnPart3DataAdorshoHarBatito.Rows.Count; l++)
                    {
                        decimal num70 = new decimal(0);
                        decimal num71 = new decimal(0);
                        decimal num72 = new decimal(0);
                        num70 = Convert.ToDecimal(vatReturnPart3DataAdorshoHarBatito.Rows[l]["price"]);
                        num71 = Convert.ToDecimal(vatReturnPart3DataAdorshoHarBatito.Rows[l]["vat"]);
                        num72 = Convert.ToDecimal(vatReturnPart3DataAdorshoHarBatito.Rows[l]["sd"]);
                        num12 += num70;
                        num13 += num71;
                        num14 += num72;
                    }
                    if (num12 != new decimal(0))
                    {
                        this.lblAdorshoHarBatitoMullo.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num12, num));
                    }
                    else
                    {
                        this.lblAdorshoHarBatitoMullo.Text = "-";
                    }
                    if (num13 != new decimal(0))
                    {
                        this.lblAdorshoHarBatitoMushok.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num13, num));
                    }
                    else
                    {
                        this.lblAdorshoHarBatitoMushok.Text = "-";
                    }
                    if (num14 != new decimal(0))
                    {
                        this.lblAdorshHarBatitoSD.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num14, num));
                    }
                    else
                    {
                        this.lblAdorshHarBatitoSD.Text = "-";
                    }
                }
                if (vatReturnPart3DataAdorsho == null || vatReturnPart3DataAdorsho.Rows.Count <= 0)
                {
                    this.typicalSupplyAmountN4P3.Text = "-";
                    this.typicalSupplyVATN4P3.Text = "-";
                    this.typicalSupplySDN4P3.Text = "-";
                    decimal tradingSalesAmount = 0;
                    decimal tradingVatAmount = 0;

                    string start_date = Convert.ToDateTime(dtpDateFrom.Text).ToString("yyyy-MM-dd");
                    string end_date = Convert.ToDateTime(dtpDateTo.Text).ToString("yyyy-MM-dd");
                    //var salesAmount = MushakAPI.LoadMukhak(start_date, end_date);

                    //if (salesAmount != null)
                    //{
                    //    tradingSalesAmount = salesAmount.Sum(s => s.netamount);
                    //    num4 = num4 + tradingSalesAmount;
                    //    tradingVatAmount = salesAmount.Sum(s => s.vat_amount);
                    //    num5 = num5 + tradingVatAmount;
                    //}


                    if (num4 != new decimal(0))
                    {
                        this.typicalSupplyAmountN4P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num));
                    }
                    else
                    {
                        this.typicalSupplyAmountN4P3.Text = "-";
                    }
                    if (num5 != new decimal(0))
                    {
                        this.typicalSupplyVATN4P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num));
                    }
                    else
                    {
                        this.typicalSupplyVATN4P3.Text = "-";
                    }
                    if (num6 != new decimal(0))
                    {
                        this.typicalSupplySDN4P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num));
                    }
                    else
                    {
                        this.typicalSupplySDN4P3.Text = "-";
                    }

                }
                else
                {
                    for (int m = 0; m < vatReturnPart3DataAdorsho.Rows.Count; m++)
                    {
                        decimal num73 = new decimal(0);
                        decimal num74 = new decimal(0);
                        decimal num75 = new decimal(0);
                        char chr2 = '0';
                        num73 = Convert.ToDecimal(vatReturnPart3DataAdorsho.Rows[m]["price"]);
                        num74 = Convert.ToDecimal(vatReturnPart3DataAdorsho.Rows[m]["vat"]);
                        num75 = Convert.ToDecimal(vatReturnPart3DataAdorsho.Rows[m]["sd"]);
                        bool flag2 = false;
                        bool flag3 = false;
                        if (vatReturnPart3DataAdorsho.Rows.Count > 0)
                        {
                            flag2 = Convert.ToBoolean(vatReturnPart3DataAdorsho.Rows[m]["deemed_export"]);
                            flag3 = Convert.ToBoolean(vatReturnPart3DataAdorsho.Rows[m]["is_exempted"]);
                        }
                        char chr3 = '0';
                        if (vatReturnPart3DataAdorsho.Rows.Count > 0)
                        {
                            chr3 = Convert.ToChar(vatReturnPart3DataAdorsho.Rows[m]["trans_type"]);
                        }
                        if (vatReturnPart3DataAdorsho.Rows[m]["real_property"].ToString() != "")
                        {
                            chr2 = Convert.ToChar(vatReturnPart3DataAdorsho.Rows[m]["real_property"]);
                        }
                        if (chr2 != 'W' && chr3 == 'L' && !flag3 && !flag2)
                        {
                            num4 += num73;
                            num5 += num74;
                            num6 += num75;
                        }
                    }

                    decimal tradingSalesAmount = 0;
                    decimal tradingVatAmount = 0;
                    //string start_date = Convert.ToDateTime(dtpDateFrom.Text).AddYears(1).ToString("yyyy-MM-dd");
                    //string end_date = Convert.ToDateTime(dtpDateTo.Text).AddYears(1).ToString("yyyy-MM-dd");
                    //var salesAmount = MushakAPI.LoadMukhak(start_date, end_date);

                    //if (salesAmount!=null)
                    //{
                    //    tradingSalesAmount = salesAmount.Sum(s => s.netamount);
                    //    num4 = num4 + tradingSalesAmount;
                    //    tradingVatAmount = salesAmount.Sum(s => s.vat_amount);
                    //    num5 = num5 + tradingVatAmount;
                    //}


                    if (num4 != new decimal(0))
                    {
                        this.typicalSupplyAmountN4P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num4, num));
                    }
                    else
                    {
                        this.typicalSupplyAmountN4P3.Text = "-";
                    }
                    if (num5 != new decimal(0))
                    {
                        this.typicalSupplyVATN4P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num5, num));
                    }
                    else
                    {
                        this.typicalSupplyVATN4P3.Text = "-";
                    }
                    if (num6 != new decimal(0))
                    {
                        this.typicalSupplySDN4P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num6, num));
                    }
                    else
                    {
                        this.typicalSupplySDN4P3.Text = "-";
                    }
                }
                if (saleExempted == null || saleExempted.Rows.Count <= 0)
                {
                    this.exemptedSupplyAmountN3P3.Text = "-";
                }
                else
                {
                    for (int n = 0; n < saleExempted.Rows.Count; n++)
                    {
                        decimal num76 = new decimal(0);
                        decimal num77 = new decimal(0);
                        decimal num78 = new decimal(0);
                        num76 = Convert.ToDecimal(saleExempted.Rows[n]["price"]);
                        num77 = Convert.ToDecimal(saleExempted.Rows[n]["vat"]);
                        num78 = Convert.ToDecimal(saleExempted.Rows[n]["sd"]);
                        num15 += num76;
                        num16 += num77;
                        num17 += num78;
                    }
                    if (num15 != new decimal(0))
                    {
                        this.exemptedSupplyAmountN3P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num15, num));
                    }
                    else
                    {
                        this.exemptedSupplyAmountN3P3.Text = "-";
                    }
                }
                decimal num79 = new decimal(0);
                decimal num80 = new decimal(0);
                if (fixedVatInfo == null || fixedVatInfo.Rows.Count <= 0)
                {
                    this.nonTypicalSupplyAmountN6P3.Text = "-";
                    this.nonTypicalSupplyVATN6P3.Text = "-";
                }
                else
                {
                    for (int o = 0; o < fixedVatInfo.Rows.Count; o++)
                    {
                        decimal num81 = new decimal(0);
                        decimal num82 = new decimal(0);
                        num81 = Convert.ToDecimal(fixedVatInfo.Rows[o]["price"]);
                        num82 = Convert.ToDecimal(fixedVatInfo.Rows[o]["vat"]);
                        num79 += num81;
                        num80 += num82;
                    }
                    if (num79 != new decimal(0))
                    {
                        this.nonTypicalSupplyAmountN6P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num79, num));
                    }
                    else
                    {
                        this.nonTypicalSupplyAmountN6P3.Text = "-";
                    }
                    if (num80 != new decimal(0))
                    {
                        this.nonTypicalSupplyVATN6P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num80, num));
                    }
                    else
                    {
                        this.nonTypicalSupplyVATN6P3.Text = "-";
                    }
                }
                decimal num83 = new decimal(0);
                decimal num84 = new decimal(0);
                decimal num85 = new decimal(0);
                if (note8Data == null || note8Data.Rows.Count <= 0)
                {
                    this.Label2.Text = "-";
                    this.Label3.Text = "-";
                    this.Label4.Text = "-";
                }
                else
                {
                    num83 = Convert.ToDecimal(note8Data.Rows[0]["price"]);
                    num84 = Convert.ToDecimal(note8Data.Rows[0]["purchase_vat"]);
                    num85 = Convert.ToDecimal(note8Data.Rows[0]["purchase_sd"]);
                    if (num83 != new decimal(0))
                    {
                        this.Label2.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num83, num));
                    }
                    else
                    {
                        this.Label2.Text = "-";
                    }
                    if (num84 != new decimal(0))
                    {
                        this.Label3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num84, num));
                    }
                    else
                    {
                        this.Label3.Text = "-";
                    }
                    if (num85 != new decimal(0))
                    {
                        this.Label4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num85, num));
                    }
                    else
                    {
                        this.Label4.Text = "-";
                    }
                }
                decimal num86 = new decimal(0);
                num86 = (((((((num1 + num2) + num3) + num4) + num64) + num7) + num83) + num12) + num79;
                if (num86 != new decimal(0))
                {
                    this.lblTotalPriceP3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num86, num));
                }
                else
                {
                    this.lblTotalPriceP3.Text = "-";
                }
                decimal num87 = new decimal(0);
                num87 = (((num6 + num66) + num9) + num14) + num85;
                if (num87 != new decimal(0))
                {
                    this.lblTotalVatN7P3.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num87, num));
                }
                else
                {
                    this.lblTotalVatN7P3.Text = "-";
                }
                decimal num88 = new decimal(0);
                num88 = ((((num5 + num65) + num8) + num13) + num80) + num84;
                if (num88 != new decimal(0))
                {
                    this.lblNineMushokKhaTotal.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num88, num));
                }
                else
                {
                    this.lblNineMushokKhaTotal.Text = "-";
                }
                DataTable vatReturnPart4Data = this.dbBLL.getVatReturnPart4Data(empty, empty1, num62);
                DataTable vatReturnPart4DataImport = this.dbBLL.getVatReturnPart4DataImport(empty, empty1, num62);
                DataTable vatReturnPart4DataAdorshoLocal = this.dbBLL.getVatReturnPart4DataAdorshoLocal(empty, empty1, num62);
                DataTable vatReturnPart4DataAdorshoImport = this.dbBLL.getVatReturnPart4DataAdorshoImport(empty, empty1, num62);
                DataTable part4DataForExemptedLocal = this.dbBLL.getPart4DataForExemptedLocal(empty, empty1, num62);
                DataTable part4DataForExemptedImport = this.dbBLL.getPart4DataForExemptedImport(empty, empty1, num62);
                DataTable part4DataForFixedLocal = this.dbBLL.getPart4DataForFixedLocal(empty, empty1, num62);
                DataTable zeroRateNote10 = this.dbBLL.getZeroRateNote10(empty, empty1, num62);
                DataTable zeroRateNote11 = this.dbBLL.getZeroRateNote11(empty, empty1, num62);
                DataTable note19Data = this.dbBLL.getNote19Data(empty, empty1, num62);
                DataTable note20Data = this.dbBLL.getNote20Data(empty, empty1, num62);
                DataTable note21Data = this.dbBLL.getNote21Data(empty, empty1, num62);
                DataTable note22Data = this.dbBLL.getNote22Data(empty, empty1, num62);
                if (vatReturnPart4Data == null || vatReturnPart4Data.Rows.Count <= 0)
                {
                    this.lblAdorshoHarBatitoMulloLcl.Text = "-";
                    this.zerorateForeignPurchaseAmountN11P4.Text = "-";
                    this.zerorateLocalPurchaseAmountN10P4.Text = "-";
                    this.nonRebatePurchaseAmountN15P4.Text = "-";
                }
                else
                {
                    for (int p = 0; p < vatReturnPart4Data.Rows.Count; p++)
                    {
                        decimal num89 = new decimal(0);
                        decimal num90 = new decimal(0);
                        decimal num91 = new decimal(0);
                        decimal num92 = new decimal(0);
                        decimal num93 = new decimal(0);
                        char chr4 = '0';
                        bool flag4 = Convert.ToBoolean(vatReturnPart4Data.Rows[p]["is_exempted"]);
                        bool flag5 = Convert.ToBoolean(vatReturnPart4Data.Rows[p]["zero_rate"]);
                        num89 = Convert.ToDecimal(vatReturnPart4Data.Rows[p]["price"]);
                        num90 = Convert.ToDecimal(vatReturnPart4Data.Rows[p]["vat"]);
                        num91 = Convert.ToDecimal(vatReturnPart4Data.Rows[p]["purchase_sd"]);
                        num92 = Convert.ToDecimal(vatReturnPart4Data.Rows[p]["cd"]);
                        num93 = Convert.ToDecimal(vatReturnPart4Data.Rows[p]["rd"]);
                        char chr5 = Convert.ToChar(vatReturnPart4Data.Rows[p]["purchase_type"]);
                        if (vatReturnPart4Data.Rows[p]["real_property"].ToString() != "")
                        {
                            chr4 = Convert.ToChar(vatReturnPart4Data.Rows[p]["real_property"]);
                        }
                        if (flag4 && chr5 == 'L')
                        {
                            num18 += num89;
                        }
                        if (flag4 && chr5 == 'I')
                        {
                            num19 += num89;
                        }
                        if (flag5 && chr5 == 'L')
                        {
                            num20 += num89;
                        }
                        if (flag5 && chr5 == 'I')
                        {
                            num21 += num89;
                        }
                        if (!flag4 && chr5 == 'I')
                        {
                            num27 += num89;
                            num28 += num90;
                        }
                        if (chr4 == 'W')
                        {
                            num34 += num89;
                            num35 += num90;
                        }
                        num39 += num89;
                        num40 += num90;
                        num41 += num91;
                        num42 += num92;
                        num43 += num93;
                    }
                    if (num39 != new decimal(0))
                    {
                        this.lblAdorshoHarBatitoMulloLcl.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num39, num));
                    }
                    else
                    {
                        this.lblAdorshoHarBatitoMulloLcl.Text = "-";
                    }
                    if (num40 != new decimal(0))
                    {
                        this.lblAdorshoHarBatitoMushokLcl.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num40, num));
                    }
                    else
                    {
                        this.lblAdorshoHarBatitoMushokLcl.Text = "-";
                    }
                    if (num20 != new decimal(0))
                    {
                        this.zerorateLocalPurchaseAmountN10P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num20, num));
                    }
                    else
                    {
                        this.zerorateLocalPurchaseAmountN10P4.Text = "-";
                    }
                    if (num21 != new decimal(0))
                    {
                        this.zerorateForeignPurchaseAmountN11P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num21, num));
                    }
                    else
                    {
                        this.zerorateForeignPurchaseAmountN11P4.Text = "-";
                    }
                    if (num36 != new decimal(0))
                    {
                        this.partialRebatePurchaseVatN14P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num36, num));
                    }
                    else
                    {
                        this.partialRebatePurchaseVatN14P4.Text = "-";
                    }
                    if (num37 != new decimal(0))
                    {
                        this.nonRebatePurchaseAmountN15P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num37, num));
                    }
                    else
                    {
                        this.nonRebatePurchaseAmountN15P4.Text = "-";
                    }
                    if (num38 != new decimal(0))
                    {
                        this.nonRebatePurchaseVatN15P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num38, num));
                    }
                    else
                    {
                        this.nonRebatePurchaseVatN15P4.Text = "-";
                    }
                }
                if (vatReturnPart4DataImport == null || vatReturnPart4DataImport.Rows.Count <= 0)
                {
                    this.lblAdorshoHarBatitoMulloImp.Text = "-";
                    this.lblAdorshoHarBatitoMushokImp.Text = "-";
                }
                else
                {
                    for (int q = 0; q < vatReturnPart4DataImport.Rows.Count; q++)
                    {
                        decimal num94 = new decimal(0);
                        decimal num95 = new decimal(0);
                        decimal num96 = new decimal(0);
                        decimal num97 = new decimal(0);
                        decimal num98 = new decimal(0);
                        num94 = Convert.ToDecimal(vatReturnPart4DataImport.Rows[q]["price"]);
                        num95 = Convert.ToDecimal(vatReturnPart4DataImport.Rows[q]["vat"]);
                        num96 = Convert.ToDecimal(vatReturnPart4DataImport.Rows[q]["purchase_sd"]);
                        num97 = Convert.ToDecimal(vatReturnPart4DataImport.Rows[q]["cd"]);
                        num98 = Convert.ToDecimal(vatReturnPart4DataImport.Rows[q]["rd"]);
                        num44 += num94;
                        num45 += num95;
                        num46 += num96;
                        num47 += num97;
                        num48 += num98;
                    }
                    if (num44 != new decimal(0))
                    {
                        this.lblAdorshoHarBatitoMulloImp.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num44, num));
                    }
                    else
                    {
                        this.lblAdorshoHarBatitoMulloImp.Text = "-";
                    }
                    if (num45 != new decimal(0))
                    {
                        this.lblAdorshoHarBatitoMushokImp.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num45, num));
                    }
                    else
                    {
                        this.lblAdorshoHarBatitoMushokImp.Text = "-";
                    }
                }
                if (vatReturnPart4DataAdorshoLocal == null || vatReturnPart4DataAdorshoLocal.Rows.Count <= 0)
                {
                    this.standardLocalPurchaseAmountN12P4.Text = "-";
                    this.standardLocalPurchaseVatN12P4.Text = "-";


                    //string start_date = Convert.ToDateTime(HttpContext.Current.Session["fDateSubs"]).AddYears(1).ToString("yyyy-MM-dd");
                    //string end_date = Convert.ToDateTime(HttpContext.Current.Session["tDateSubs"]).AddYears(1).ToString("yyyy-MM-dd");
                    //var purchaseList = MushakAPI.SubForm_k_Note_14(start_date, end_date);

                    //if (purchaseList != null)
                    //{
                    //    num23 = num23 + purchaseList.Sum(s => s.vat);
                    //    num22 = num22 + purchaseList.Sum(s => s.price);
                    //}

                    if (num22 != new decimal(0))
                    {
                        this.standardLocalPurchaseAmountN12P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num22, num));
                    }
                    else
                    {
                        this.standardLocalPurchaseAmountN12P4.Text = "-";
                    }

                    if (num23 != new decimal(0))
                    {
                        this.standardLocalPurchaseVatN12P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num23, num));
                    }
                    else
                    {
                        this.standardLocalPurchaseVatN12P4.Text = "-";
                    }
                }
                else
                {
                    for (int r = 0; r < vatReturnPart4DataAdorshoLocal.Rows.Count; r++)
                    {
                        char chr6 = '0';
                        if (vatReturnPart4DataAdorshoLocal.Rows[r]["real_property"].ToString() != "")
                        {
                            chr6 = Convert.ToChar(vatReturnPart4DataAdorshoLocal.Rows[r]["real_property"]);
                        }
                        bool flag6 = Convert.ToBoolean(vatReturnPart4DataAdorshoLocal.Rows[r]["is_exempted"]);
                        char chr7 = Convert.ToChar(vatReturnPart4DataAdorshoLocal.Rows[r]["purchase_type"]);
                        decimal num99 = new decimal(0);
                        decimal num100 = new decimal(0);
                        decimal num101 = new decimal(0);
                        decimal num102 = new decimal(0);
                        decimal num103 = new decimal(0);
                        num99 = Convert.ToDecimal(vatReturnPart4DataAdorshoLocal.Rows[r]["price"]);
                        num100 = Convert.ToDecimal(vatReturnPart4DataAdorshoLocal.Rows[r]["vat"]);
                        num101 = Convert.ToDecimal(vatReturnPart4DataAdorshoLocal.Rows[r]["purchase_sd"]);
                        num102 = Convert.ToDecimal(vatReturnPart4DataAdorshoLocal.Rows[r]["cd"]);
                        num103 = Convert.ToDecimal(vatReturnPart4DataAdorshoLocal.Rows[r]["rd"]);
                        if (chr6 != 'W' && !flag6 && chr7 == 'L')
                        {
                            num22 += num99;
                            num23 += num100;
                            num24 += num101;
                            num25 += num102;
                            num26 += num103;
                        }
                    }
                  



                    //string start_date = Convert.ToDateTime(HttpContext.Current.Session["fDateSubs"]).ToString("yyyy-MM-dd");
                    //string end_date = Convert.ToDateTime(HttpContext.Current.Session["tDateSubs"]).ToString("yyyy-MM-dd");
                    //var purchaseList = MushakAPI.SubForm_k_Note_14(start_date, end_date);

                    //if(purchaseList!=null)
                    //{
                    //    num23 = num23 + purchaseList.Sum(s => s.vat);
                    //    num22 = num22 + purchaseList.Sum(s => s.price);
                    //}

                    if (num22 != new decimal(0))
                    {
                        this.standardLocalPurchaseAmountN12P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num22, num));
                    }
                    else
                    {
                        this.standardLocalPurchaseAmountN12P4.Text = "-";
                    }

                    if (num23 != new decimal(0))
                    {
                        this.standardLocalPurchaseVatN12P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num23, num));
                    }
                    else
                    {
                        this.standardLocalPurchaseVatN12P4.Text = "-";
                    }
                }
                if (vatReturnPart4DataAdorshoImport == null || vatReturnPart4DataAdorshoImport.Rows.Count <= 0)
                {
                    this.standardForeignPurchaseAmountN13P4.Text = "-";
                    this.standardForeignPurchaseVatN13P4.Text = "-";
                }
                else
                {
                    for (int s = 0; s < vatReturnPart4DataAdorshoImport.Rows.Count; s++)
                    {
                        if (vatReturnPart4DataAdorshoImport.Rows[s]["real_property"].ToString() != "")
                        {
                            Convert.ToChar(vatReturnPart4DataAdorshoImport.Rows[s]["real_property"]);
                        }
                        bool flag7 = Convert.ToBoolean(vatReturnPart4DataAdorshoImport.Rows[s]["is_exempted"]);
                        char chr8 = Convert.ToChar(vatReturnPart4DataAdorshoImport.Rows[s]["purchase_type"]);
                        decimal num104 = new decimal(0);
                        decimal num105 = new decimal(0);
                        decimal num106 = new decimal(0);
                        decimal num107 = new decimal(0);
                        decimal num108 = new decimal(0);
                        num104 = Convert.ToDecimal(vatReturnPart4DataAdorshoImport.Rows[s]["price"]);
                        num105 = Convert.ToDecimal(vatReturnPart4DataAdorshoImport.Rows[s]["vat"]);
                        num106 = Convert.ToDecimal(vatReturnPart4DataAdorshoImport.Rows[s]["purchase_sd"]);
                        num107 = Convert.ToDecimal(vatReturnPart4DataAdorshoImport.Rows[s]["cd"]);
                        num108 = Convert.ToDecimal(vatReturnPart4DataAdorshoImport.Rows[s]["rd"]);
                        if (!flag7 && chr8 == 'I')
                        {
                            num27 += num104;
                            num28 += num105;
                            num29 += num106;
                            num30 += num107;
                            num31 += num108;
                        }
                    }
                    if (num27 != new decimal(0))
                    {
                        this.standardForeignPurchaseAmountN13P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num27, num));

                        DateTime selectedDate;

                        if (DateTime.TryParse(this.dtpDateFrom.Text.ToString(), out selectedDate))
                        {
                            if (selectedDate.Month == 9 && selectedDate.Year == 2025)
                            {
                                this.standardForeignPurchaseAmountN13P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(843503, num)); 
                            }
                        }


                    }
                    else
                    {
                        this.standardForeignPurchaseAmountN13P4.Text = "-";
                    }
                    if (num28 != new decimal(0))
                    {
                        this.standardForeignPurchaseVatN13P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num28, num));
                    }
                    else
                    {
                        this.standardForeignPurchaseVatN13P4.Text = "-";
                    }
                }
                if (part4DataForExemptedLocal == null || part4DataForExemptedLocal.Rows.Count <= 0)
                {
                    this.exemptedLocalPurchaseAmountN8P4.Text = "-";
                }
                else
                {
                    for (int t = 0; t < part4DataForExemptedLocal.Rows.Count; t++)
                    {
                        decimal num109 = new decimal(0);
                        num109 = Convert.ToDecimal(part4DataForExemptedLocal.Rows[t]["price"]);
                        num32 += num109;
                    }
                    if (num32 != new decimal(0))
                    {
                        this.exemptedLocalPurchaseAmountN8P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num32, num));
                    }
                    else
                    {
                        this.exemptedLocalPurchaseAmountN8P4.Text = "-";
                    }
                }
                if (part4DataForExemptedImport == null || part4DataForExemptedImport.Rows.Count <= 0)
                {
                    this.exemptedForeignPurchaseAmountN9P4.Text = "-";
                }
                else
                {
                    for (int u = 0; u < part4DataForExemptedImport.Rows.Count; u++)
                    {
                        decimal num110 = new decimal(0);
                        num110 = Convert.ToDecimal(part4DataForExemptedImport.Rows[u]["price"]);
                        num33 += num110;
                    }
                    if (num33 != new decimal(0))
                    {
                        this.exemptedForeignPurchaseAmountN9P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num33, num));
                    }
                    else
                    {
                        this.exemptedForeignPurchaseAmountN9P4.Text = "-";
                    }
                }
                decimal num111 = new decimal(0);
                decimal num112 = new decimal(0);
                if (part4DataForFixedLocal == null || part4DataForFixedLocal.Rows.Count <= 0)
                {
                    this.partialRebatePurchaseAmountN14P4.Text = "-";
                    this.partialRebatePurchaseVatN14P4.Text = "-";
                }
                else
                {
                    for (int v = 0; v < part4DataForFixedLocal.Rows.Count; v++)
                    {
                        decimal num113 = new decimal(0);
                        decimal num114 = new decimal(0);
                        num113 = Convert.ToDecimal(part4DataForFixedLocal.Rows[v]["price"]);
                        num114 = Convert.ToDecimal(part4DataForFixedLocal.Rows[v]["vat"]);
                        num111 += num113;
                        num112 += num114;
                    }
                    if (num111 != new decimal(0))
                    {
                        this.partialRebatePurchaseAmountN14P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num111, num));
                    }
                    else
                    {
                        this.partialRebatePurchaseAmountN14P4.Text = "-";
                    }
                    if (num112 != new decimal(0))
                    {
                        this.partialRebatePurchaseVatN14P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num112, num));
                    }
                    else
                    {
                        this.partialRebatePurchaseVatN14P4.Text = "-";
                    }
                }
                decimal num115 = new decimal(0);
                if (zeroRateNote10 == null || zeroRateNote10.Rows.Count <= 0)
                {
                    this.zerorateLocalPurchaseAmountN10P4.Text = "-";
                }
                else
                {
                    for (int w = 0; w < zeroRateNote10.Rows.Count; w++)
                    {
                        decimal num116 = new decimal(0);
                        num116 = Convert.ToDecimal(zeroRateNote10.Rows[w]["price"]);
                        num115 += num116;
                    }
                    if (num115 != new decimal(0))
                    {
                        this.zerorateLocalPurchaseAmountN10P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num115, num));
                    }
                    else
                    {
                        this.zerorateLocalPurchaseAmountN10P4.Text = "-";
                    }
                }
                decimal num117 = new decimal(0);
                if (zeroRateNote11 == null || zeroRateNote11.Rows.Count <= 0)
                {
                    this.zerorateForeignPurchaseAmountN11P4.Text = "-";
                }
                else
                {
                    for (int x = 0; x < zeroRateNote11.Rows.Count; x++)
                    {
                        decimal num118 = new decimal(0);
                        num118 = Convert.ToDecimal(zeroRateNote11.Rows[x]["price"]);
                        num117 += num118;
                    }
                    if (num117 != new decimal(0))
                    {
                        this.zerorateForeignPurchaseAmountN11P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num117, num));
                    }
                    else
                    {
                        this.zerorateForeignPurchaseAmountN11P4.Text = "-";
                    }
                }
                decimal num119 = new decimal(0);
                decimal num120 = new decimal(0);
                if (note19Data == null || note19Data.Rows.Count <= 0)
                {
                    this.nonRebatePurchaseAmountN15P4.Text = "-";
                    this.nonRebatePurchaseVatN15P4.Text = "-";
                }
                else
                {
                    for (int y = 0; y < note19Data.Rows.Count; y++)
                    {
                        decimal num121 = new decimal(0);
                        decimal num122 = new decimal(0);
                        num121 = Convert.ToDecimal(note19Data.Rows[y]["price"]);
                        num119 += num121;
                        num122 = Convert.ToDecimal(note19Data.Rows[y]["Vat"]);
                        num120 += num122;
                    }
                    if (num119 != new decimal(0))
                    {
                        this.nonRebatePurchaseAmountN15P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num119, num));
                    }
                    else
                    {
                        this.nonRebatePurchaseAmountN15P4.Text = "-";
                    }
                    if (num120 != new decimal(0))
                    {
                        this.nonRebatePurchaseVatN15P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num120, num));
                    }
                    else
                    {
                        this.nonRebatePurchaseVatN15P4.Text = "-";
                    }
                }
                decimal num123 = new decimal(0);
                decimal num124 = new decimal(0);
                if (note20Data == null || note20Data.Rows.Count <= 0)
                {
                    this.Label9.Text = "-";
                    this.Label10.Text = "-";
                }
                else
                {
                    for (int a = 0; a < note20Data.Rows.Count; a++)
                    {
                        decimal num125 = new decimal(0);
                        decimal num126 = new decimal(0);
                        num125 = Convert.ToDecimal(note20Data.Rows[a]["price"]);
                        num123 += num125;
                        num126 = Convert.ToDecimal(note20Data.Rows[a]["Vat"]);
                        num124 += num126;
                    }
                    if (num123 != new decimal(0))
                    {
                        this.Label9.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num123, num));
                    }
                    else
                    {
                        this.Label9.Text = "-";
                    }
                    if (num124 != new decimal(0))
                    {
                        this.Label10.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num124, num));
                    }
                    else
                    {
                        this.Label10.Text = "-";
                    }
                }
                decimal num127 = new decimal(0);
                decimal num128 = new decimal(0);
                if (note21Data == null || note21Data.Rows.Count <= 0)
                {
                    this.Label11.Text = "-";
                    this.Label12.Text = "-";
                }
                else
                {
                    for (int b = 0; b < note21Data.Rows.Count; b++)
                    {
                        decimal num129 = new decimal(0);
                        decimal num130 = new decimal(0);
                        num129 = Convert.ToDecimal(note21Data.Rows[b]["price"]);
                        num127 += num129;
                        num130 = Convert.ToDecimal(note21Data.Rows[b]["Vat"]);
                        num128 += num130;
                    }
                    if (num127 != new decimal(0))
                    {
                        this.Label11.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num127, num));
                    }
                    else
                    {
                        this.Label11.Text = "-";
                    }
                    if (num128 != new decimal(0))
                    {
                        this.Label12.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num128, num));
                    }
                    else
                    {
                        this.Label12.Text = "-";
                    }
                }
                decimal num131 = new decimal(0);
                decimal num132 = new decimal(0);
                if (note22Data == null || note22Data.Rows.Count <= 0)
                {
                    this.Label13.Text = "-";
                    this.Label14.Text = "-";
                }
                else
                {
                    for (int c = 0; c < note22Data.Rows.Count; c++)
                    {
                        decimal num133 = new decimal(0);
                        decimal num134 = new decimal(0);
                        num133 = Convert.ToDecimal(note22Data.Rows[c]["price"]);
                        num131 += num133;
                        num134 = Convert.ToDecimal(note22Data.Rows[c]["Vat"]);
                        num132 += num134;
                    }
                    if (num131 != new decimal(0))
                    {
                        this.Label13.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num131, num));
                    }
                    else
                    {
                        this.Label13.Text = "-";
                    }
                    if (num132 != new decimal(0))
                    {
                        this.Label14.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num132, num));
                    }
                    else
                    {
                        this.Label14.Text = "-";
                    }
                }
                decimal num135 = new decimal(0);
                decimal num136 = new decimal(0);
                decimal num137 = new decimal(0);
                decimal num138 = new decimal(0);
                decimal num139 = new decimal(0);
                decimal num140 = new decimal(0);
                decimal num141 = new decimal(0);
                decimal num142 = new decimal(0);
                decimal num143 = new decimal(0);
                decimal num144 = new decimal(0);
                decimal num145 = new decimal(0);
                decimal num146 = new decimal(0);
                num137 = num22;
                num138 = num27;
                num139 = num39;
                num140 = num44;
                num141 = num111;
                num135 = ((((((((((((((num20 + num115) + num117) + num21) + num32) + num33) + num137) + num138) + num139) + num140) + num141) + num119) + num37) + num123) + num127) + num131;
                if (num135 != new decimal(0))
                {
                    this.lblTotalPriceP4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num135, num));
                }
                else
                {
                    this.lblTotalPriceP4.Text = "-";
                }
                num142 = num23;
                num143 = num28;
                num144 = num40;
                num145 = num45;
                num146 = num112;
                num136 = (((num142 + num143) + num144) + num145) + num146;
                if (num136 != new decimal(0))
                {
                    this.lblTotalVatN16P4.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num136, num));
                }
                else
                {
                    this.lblTotalVatN16P4.Text = "-";
                }
                decimal num147 = new decimal(0);
                DataTable vatReturnPart5Data = this.dbBLL.getVatReturnPart5Data(empty, empty1, num62);
                DataTable vatReturnPart5Data27 = this.dbBLL.getVatReturnPart5Data27(empty, empty1, num62);
                DataTable vatReturnPart5Data26 = this.dbBLL.getVatReturnPart5Data26(empty, empty1, num62);
                if (vatReturnPart5Data != null && vatReturnPart5Data.Rows.Count > 0)
                {
                    for (int d = 0; d < vatReturnPart5Data.Rows.Count; d++)
                    {
                        num49 += Convert.ToDecimal(vatReturnPart5Data.Rows[d]["TotalVDS"]);
                        num50 += Convert.ToDecimal(vatReturnPart5Data.Rows[d]["rebatable_amount"]);
                        num51 += Convert.ToDecimal(vatReturnPart5Data.Rows[d]["return_amount"]);
                        num52 += Convert.ToDecimal(vatReturnPart5Data.Rows[d]["other_tax"]);
                    }
                    if (num49 != new decimal(0))
                    {
                        this.receiveVDSAmountN17P5.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num49, num));
                    }
                    else
                    {
                        this.receiveVDSAmountN17P5.Text = "-";
                    }
                    if (num50 != new decimal(0))
                    {
                        this.nonBankingPaymentVatN18P5.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num50, num));
                    }
                    else
                    {
                        this.nonBankingPaymentVatN18P5.Text = "-";
                    }
                }
                if (vatReturnPart5Data27 == null || vatReturnPart5Data27.Rows.Count <= 0)
                {
                    this.otherAdjusmentVatN20P5.Text = "-";
                }
                else
                {
                    num147 = Convert.ToDecimal(vatReturnPart5Data27.Rows[0]["price"]);
                    if (num147 != new decimal(0))
                    {
                        this.otherAdjusmentVatN20P5.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num147, num));
                    }
                    else
                    {
                        this.otherAdjusmentVatN20P5.Text = "-";
                    }
                }
                decimal num148 = new decimal(0);
                if (vatReturnPart5Data26 == null || vatReturnPart5Data26.Rows.Count <= 0)
                {
                    this.changePurchaseAllVatN19P5.Text = "-";
                }
                else
                {
                    num148 = Convert.ToDecimal(vatReturnPart5Data26.Rows[0]["vat"]);
                    if (num148 != new decimal(0))
                    {
                        this.changePurchaseAllVatN19P5.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num148, num));
                    }
                    else
                    {
                        this.changePurchaseAllVatN19P5.Text = "-";
                    }
                }
                decimal num149 = new decimal(0);
                decimal num150 = new decimal(0);
                decimal num151 = new decimal(0);
                decimal num152 = new decimal(0);
                if (this.receiveVDSAmountN17P5.Text != "")
                {
                    num149 = Convert.ToDecimal(num49);
                }
                if (this.nonBankingPaymentVatN18P5.Text != "")
                {
                    num150 = Convert.ToDecimal(num50);
                }
                if (this.changePurchaseAllVatN19P5.Text != "")
                {
                    num151 = Convert.ToDecimal(num148);
                }
                if (this.otherAdjusmentVatN20P5.Text != "")
                {
                    num152 = Convert.ToDecimal(num147);
                }
                decimal num153 = ((num149 + num150) + num151) + num152;
                if (num153 != new decimal(0))
                {
                    this.lblTotalVatN21P5.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num153, num));
                }
                else
                {
                    this.lblTotalVatN21P5.Text = "-";
                }
                decimal num154 = new decimal(0);
                decimal num155 = new decimal(0);
                DataTable vatReturnPart6Data = this.dbBLL.getVatReturnPart6Data(empty, empty1, num62);
                DataTable aTDataPart6 = this.dbBLL.getATDataPart6(empty, empty1, num62);
                DataTable vatReturnPart5Data33 = this.dbBLL.getVatReturnPart5Data33(empty, empty1, num62);
                DataTable vatReturnPart6Data32 = this.dbBLL.getVatReturnPart6Data32(empty, empty1, num62);
                decimal vatReturnNote29 = this.dbBLL.getVatReturnNote29(empty, empty1, num62);
                if (vatReturnPart6Data != null && vatReturnPart6Data.Rows.Count > 0)
                {
                    for (int e = 0; e < vatReturnPart6Data.Rows.Count; e++)
                    {
                        num53 += Convert.ToDecimal(vatReturnPart6Data.Rows[e]["vds_amt"]);
                        num54 += Convert.ToDecimal(vatReturnPart6Data.Rows[e]["return_vat"]);
                        num55 += Convert.ToDecimal(vatReturnPart6Data.Rows[e]["return_sd"]);
                        num56 += Convert.ToDecimal(vatReturnPart6Data.Rows[e]["other_tax"]);
                        num155 += Convert.ToDecimal(vatReturnPart6Data.Rows[e]["return_amount"]);
                    }
                    if (vatReturnNote29 != new decimal(0))
                    {
                        this.paidVDSAmountN22P6.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(vatReturnNote29, num));
                    }
                    else
                    {
                        this.paidVDSAmountN22P6.Text = "-";
                    }
                }
                decimal num156 = new decimal(0);
                if (aTDataPart6 != null && aTDataPart6.Rows.Count > 0)
                {
                    num156 = Convert.ToDecimal(aTDataPart6.Rows[0]["at"]);
                    if (num156 != new decimal(0))
                    {
                        this.changeSaleAllVatN23P6.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num156, num));
                    }
                    else
                    {
                        this.changeSaleAllVatN23P6.Text = "-";
                    }
                }
                decimal num157 = new decimal(0);
                string str35 = HttpContext.Current.Session["fDateSubs"].ToString();
                string str45 = HttpContext.Current.Session["tDateSubs"].ToString();
                string start_dates = Convert.ToDateTime(str35).ToString("yyyy-MM-dd");
                string end_dates = Convert.ToDateTime(str45).ToString("yyyy-MM-dd");
                //var returnList = MushakAPI.Subform_Note_31API(start_dates, end_dates);

                //if (returnList != null)
                //{
                //    num157 = num157 + returnList.Sum(s => s.vat_amount);
                //    lblforCreditNoteIssue.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num157, num));
                //}


                if (vatReturnPart6Data32 == null || vatReturnPart6Data32.Rows.Count <= 0)
                {
                    this.lblforCreditNoteIssue.Text = "-";
                }
                else
                {
                    num157 = num157+Convert.ToDecimal(vatReturnPart6Data32.Rows[0]["vat"]);
                    if (num157 != new decimal(0))
                    {
                        this.lblforCreditNoteIssue.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num157, num));
                    }
                    else
                    {
                        this.lblforCreditNoteIssue.Text = "-";
                    }
                }
                if (vatReturnPart5Data33 == null || vatReturnPart5Data33.Rows.Count <= 0)
                {
                    this.otherAdjusmentAmountN25P6.Text = "-";
                }
                else
                {
                    num154 = Convert.ToDecimal(vatReturnPart5Data33.Rows[0]["price"]);


                    //string str31 = HttpContext.Current.Session["fDateSubs"].ToString();
                    //string str41 = HttpContext.Current.Session["tDateSubs"].ToString();
                    //string start_date = Convert.ToDateTime(str31).ToString("yyyy-MM-dd");
                    //string end_date = Convert.ToDateTime(str41).ToString("yyyy-MM-dd");
                    //var returnList = MushakAPI.Subform_Note_31API(start_date, end_date);

                  


                    if (num154 != new decimal(0))
                    {
                        this.otherAdjusmentAmountN25P6.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num154, num));
                    }
                    else
                    {
                        this.otherAdjusmentAmountN25P6.Text = "-";
                    }
                }
                decimal num158 = new decimal(0);
                decimal num159 = new decimal(0);
                decimal num160 = new decimal(0);
                decimal num161 = new decimal(0);
                num158 = vatReturnNote29;
                num159 = Convert.ToDecimal(num156);
                num160 = num157;
                num161 = num154;
                decimal num162 = ((num158 + num159) + num160) + num161;
                if (num162 != new decimal(0))
                {
                    this.lblTotalVatN26P6.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num162, num));
                }
                else
                {
                    this.lblTotalVatN26P6.Text = "-";
                }
                DataTable vatReturnPart7Data = this.dbBLL.getVatReturnPart7Data(empty, empty1, num62);
                DataTable vatReturnPart7Data39 = this.dbBLL.getVatReturnPart7Data39(empty, empty1, num62);
                DataTable vatReturnPart7Data40 = this.dbBLL.getVatReturnPart7Data40(empty, empty1, num62);
                DataTable note42 = this.dbBLL.GetNote42(empty, empty1, num62);
                DataTable note43 = this.dbBLL.GetNote43(empty, empty1, num62);
                DataTable note48 = this.dbBLL.GetNote48(empty, empty1, num62);
                if (vatReturnPart7Data != null && vatReturnPart7Data.Rows.Count > 0)
                {
                    num57 += Convert.ToDecimal(vatReturnPart7Data.Rows[0]["at"]);
                }
                decimal num163 = new decimal(0);
                if (vatReturnPart7Data39 == null || vatReturnPart7Data39.Rows.Count <= 0)
                {
                    this.SurchargeN31P7.Text = "-";
                }
                else
                {
                    num163 = Convert.ToDecimal(vatReturnPart7Data39.Rows[0]["sd"]);
                    if (num163 != new decimal(0))
                    {
                        this.SurchargeN31P7.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num163, num));
                    }
                    else
                    {
                        this.SurchargeN31P7.Text = "-";
                    }
                }
                decimal num164 = new decimal(0);
                if (vatReturnPart7Data40 == null || vatReturnPart7Data40.Rows.Count <= 0)
                {
                    this.Label16.Text = "-";
                }
                else
                {
                    num164 = Convert.ToDecimal(vatReturnPart7Data40.Rows[0]["sd"]);
                    if (num164 != new decimal(0))
                    {
                        this.Label16.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num164, num));
                    }
                    else
                    {
                        this.Label16.Text = "-";
                    }
                }
                decimal num165 = new decimal(0);
                decimal num166 = new decimal(0);
                decimal num167 = new decimal(0);
                decimal num168 = new decimal(0);
                decimal num169 = new decimal(0);
                num165 = (this.lblNineMushokKhaTotal.Text == "" ? new decimal(0) : Convert.ToDecimal(((((num5 + num65) + num8) + num13) + num80) + num84));
                num166 = (this.AdvanceVatAmountN28P7.Text == "" ? new decimal(0) : num136);
                num167 = (this.lblTotalVatN21P5.Text == "" ? new decimal(0) : Convert.ToDecimal(num153));
                num168 = ((num158 + num159) + num160) + num161;
                if (this.lblTotalVatN26P6.Text != "")
                {
                }
                string str3 = "";
                DateTime dateTime3 = dateTime1.AddMonths(-1);
                string str4 = dateTime3.ToString("MM");
                string str5 = dateTime1.ToString("yyyy");
                dateTime3 = dateTime1.AddYears(-1);
                string str6 = dateTime3.ToString("yyyy");
                if (str4 != "12")
                {
                    objArray = new object[] { "01", '/', str4, '/', str5 };
                    str3 = string.Concat(objArray);
                }
                else
                {
                    objArray = new object[] { "01", '/', str4, '/', str6 };
                    str3 = string.Concat(objArray);
                }
                Convert.ToDateTime(str3);
                decimal num170 = new decimal(0);
                decimal num171 = new decimal(0);
                decimal num172 = new decimal(0);
                decimal num173 = new decimal(0);
                DataTable closingVatSd = this.dbBLL.GetClosingVatSd(str3, empty, num62);
                if (closingVatSd == null || closingVatSd.Rows.Count <= 0)
                {
                    DataTable monthClosingVat = this.dbBLL.GetMonthClosingVat(str3, empty, num62);
                    DataTable monthClosingSd = this.dbBLL.GetMonthClosingSd(str3, empty, num62);
                    if (monthClosingVat != null && monthClosingVat.Rows.Count > 0)
                    {
                        num170 = Convert.ToDecimal(monthClosingVat.Rows[0]["credit_amount"]);
                        num171 = Convert.ToDecimal(monthClosingVat.Rows[0]["debit_amount"]);
                        num58 = (num170 != new decimal(0) ? num170 : num171);
                    }
                    if (monthClosingSd != null && monthClosingSd.Rows.Count > 0)
                    {
                        num172 = Convert.ToDecimal(monthClosingSd.Rows[0]["credit_amount"]);
                        num173 = Convert.ToDecimal(monthClosingSd.Rows[0]["debit_amount"]);
                        num59 = (num170 != new decimal(0) ? num172 : num173);
                    }
                }
                else
                {
                    num58 = Convert.ToDecimal(closingVatSd.Rows[0]["vat_closing_balance"]);
                    num59 = Convert.ToDecimal(closingVatSd.Rows[0]["sd_closing_balance"]);
                    if (num58 == new decimal(0))
                    {
                        DataTable dataTable = this.dbBLL.GetMonthClosingVat(str3, empty, num62);
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            num170 = Convert.ToDecimal(dataTable.Rows[0]["credit_amount"]);
                            num171 = Convert.ToDecimal(dataTable.Rows[0]["debit_amount"]);
                            num58 = (num170 != new decimal(0) ? num170 : num171);
                        }
                    }
                    if (num59 == new decimal(0))
                    {
                        DataTable monthClosingSd1 = this.dbBLL.GetMonthClosingSd(str3, empty, num62);
                        if (monthClosingSd1 != null && monthClosingSd1.Rows.Count > 0)
                        {
                            num172 = Convert.ToDecimal(monthClosingSd1.Rows[0]["credit_amount"]);
                            num173 = Convert.ToDecimal(monthClosingSd1.Rows[0]["debit_amount"]);
                            num59 = (num170 != new decimal(0) ? num172 : num173);
                        }
                    }
                }
                if (num58 != new decimal(0))
                {
                    Label label26 = this.Label26;
                    object obj1 = '(';
                    string withString = Utilities.RoundUpToWithString(num58, num);
                    chrArray = new char[] { '-' };
                    label26.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj1, withString.TrimStart(chrArray), ')'));
                }
                else
                {
                    this.Label26.Text = "-";
                }
                if (num59 != new decimal(0))
                {
                    Label label27 = this.Label27;
                    object obj2 = '(';
                    string withString1 = Utilities.RoundUpToWithString(num59, num);
                    chrArray = new char[] { '-' };
                    label27.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj2, withString1.TrimStart(chrArray), ')'));
                }
                else
                {
                    this.Label27.Text = "-";
                }
                decimal num174 = new decimal(0);
                num174 = (num165 - num166) + (num167 - num168);
                if (num174 == new decimal(0))
                {
                    this.TotalVatSDAmountN27P7.Text = "-";
                }
                else if (num174 >= new decimal(0))
                {
                    this.TotalVatSDAmountN27P7.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString((num165 - num166) + (num167 - num168), num));
                }
                else
                {
                    Label totalVatSDAmountN27P7 = this.TotalVatSDAmountN27P7;
                    object obj3 = '(';
                    string withString2 = Utilities.RoundUpToWithString(num174, num);
                    chrArray = new char[] { '-' };
                    totalVatSDAmountN27P7.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj3, withString2.TrimStart(chrArray), ')'));
                }
                decimal num175 = new decimal(0);
                if (note48 == null || note48.Rows.Count <= 0)
                {
                    this.Label24.Text = "-";
                }
                else
                {
                    num175 = Convert.ToDecimal(note48.Rows[0]["amount"]);
                    if (num175 != new decimal(0))
                    {
                        this.Label24.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num175, num));
                    }
                    else
                    {
                        this.Label24.Text = "-";
                    }
                }
                decimal num176 = new decimal(0);
                num169 = num174;
                decimal num177 = new decimal(0);
                decimal num178 = new decimal(0);
                decimal num179 = new decimal(0);
                decimal num180 = new decimal(0);
                decimal num181 = new decimal(0);
                num177 = (((num6 + num66) + num9) + num14) + num85;
                num178 = num163;
                num179 = num164;
                num180 = (this.Label17.Text != "" ? Convert.ToDecimal(this.Label17.Text.Trim()) : new decimal(0));
                num181 = (num177 + num178) - (num179 - num180);
                if (num181 == new decimal(0))
                {
                    this.PrevAdvanceAmountN29P7.Text = "-";
                }
                else if (num181 >= new decimal(0))
                {
                    this.PrevAdvanceAmountN29P7.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString((num177 + num178) - (num179 - num180), num));
                }
                else
                {
                    Label prevAdvanceAmountN29P7 = this.PrevAdvanceAmountN29P7;
                    object obj4 = '(';
                    string withString3 = Utilities.RoundUpToWithString(num181, num);
                    chrArray = new char[] { '-' };
                    prevAdvanceAmountN29P7.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj4, withString3.TrimStart(chrArray), ')'));
                }
                decimal num182 = new decimal(0);
                num182 = (num59 >= new decimal(0) ? num181 - num59 : num181 + num59);
                if (num182 == new decimal(0))
                {
                    this.ExciseDutyN30P7.Text = "-";
                }
                else if (num182 >= new decimal(0))
                {
                    this.ExciseDutyN30P7.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num182, num));
                }
                else
                {
                    Label exciseDutyN30P7 = this.ExciseDutyN30P7;
                    object obj5 = '(';
                    string withString4 = Utilities.RoundUpToWithString(num182, num);
                    chrArray = new char[] { '-' };
                    exciseDutyN30P7.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj5, withString4.TrimStart(chrArray), ')'));
                }
                decimal num183 = new decimal(0);
                num183 = Convert.ToDecimal(note42.Rows[0]["amount"]);
                if (num183 != new decimal(0))
                {
                    this.Label18.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num183, num));
                }
                else
                {
                    this.Label18.Text = "-";
                }
                decimal num184 = new decimal(0);
                num184 = Convert.ToDecimal(note43.Rows[0]["amount"]);
                if (num184 != new decimal(0))
                {
                    this.Label19.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num184, num));
                }
                else
                {
                    this.Label19.Text = "-";
                }
                decimal num185 = new decimal(0);
                num185 = num182;
                num184 = Convert.ToDecimal(note43.Rows[0]["amount"]);
                num61 = num185 + num184;
                if (num61 == new decimal(0))
                {
                    this.Label6.Text = "-";
                }
                else if (num61 >= new decimal(0))
                {
                    this.Label6.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num61, num));
                }
                else
                {
                    Label label6 = this.Label6;
                    object obj6 = '(';
                    string withString5 = Utilities.RoundUpToWithString(num61, num);
                    chrArray = new char[] { '-' };
                    label6.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj6, withString5.TrimStart(chrArray), ')'));
                }
                DataTable monthClosingAdjustmentVat = this.dbBLL.GetMonthClosingAdjustmentVat(str3, empty, num62);
                DataTable monthClosingAdjustmentSd = this.dbBLL.GetMonthClosingAdjustmentSd(str3, empty, num62);
                DataTable adjustmentVatSd = this.dbBLL.GetAdjustmentVatSd(str3, empty1, num62);
                decimal num186 = new decimal(0);
                decimal num187 = new decimal(0);
                decimal num188 = new decimal(0);
                decimal num189 = new decimal(0);
                decimal num190 = new decimal(0);
                decimal num191 = new decimal(0);
                if (monthClosingAdjustmentVat != null && monthClosingAdjustmentVat.Rows.Count > 0)
                {
                    num170 = Convert.ToDecimal(monthClosingAdjustmentVat.Rows[0]["credit_amount"]);
                    num171 = Convert.ToDecimal(monthClosingAdjustmentVat.Rows[0]["debit_amount"]);
                }
                if (monthClosingAdjustmentSd != null && monthClosingAdjustmentSd.Rows.Count > 0)
                {
                    num172 = Convert.ToDecimal(monthClosingAdjustmentSd.Rows[0]["credit_amount"]);
                    num173 = Convert.ToDecimal(monthClosingAdjustmentSd.Rows[0]["debit_amount"]);
                }
                if (adjustmentVatSd.Rows.Count <= 0)
                {
                    DataTable monthClosingAdjustmentVatnote54 = this.dbBLL.GetMonthClosingAdjustmentVatnote54(str3, empty1, num62);
                    if (monthClosingAdjustmentVatnote54.Rows.Count > 0)
                    {
                        num190 = Convert.ToDecimal(monthClosingAdjustmentVatnote54.Rows[0]["credit_amount"]);
                    }
                    DataTable monthClosingAdjustmentVatnote55 = this.dbBLL.GetMonthClosingAdjustmentVatnote55(str3, empty1, num62);
                    if (monthClosingAdjustmentVatnote54.Rows.Count > 0)
                    {
                        num191 = Convert.ToDecimal(monthClosingAdjustmentVatnote55.Rows[0]["credit_amount"]);
                    }
                }
                else
                {
                    num190 = Convert.ToDecimal(adjustmentVatSd.Rows[0]["vat_closing_balance"]);
                    num191 = Convert.ToDecimal(adjustmentVatSd.Rows[0]["sd_closing_balance"]);
                }
                num188 = (num190 >= new decimal(0) ? num190 - num170 : num190 + num170);
                num189 = (num191 >= new decimal(0) ? num191 - num172 : num191 + num172);
                num186 = (num174 < new decimal(0) || num188 == new decimal(0) ? new decimal(0) : (num174 * new decimal(30)) / new decimal(100));
                num187 = (num181 < new decimal(0) || num189 == new decimal(0) ? new decimal(0) : (num181 * new decimal(30)) / new decimal(100));
                if (num188 == new decimal(0))
                {
                    this.txtnote54.Text = "-";
                }
                else if (num188 >= new decimal(0))
                {
                    this.txtnote54.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num188, num));
                }
                else
                {
                    Label label = this.txtnote54;
                    object obj7 = '(';
                    string withString6 = Utilities.RoundUpToWithString(num188, num);
                    chrArray = new char[] { '-' };
                    label.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj7, withString6.TrimStart(chrArray), ')'));
                }
                if (num189 != new decimal(0))
                {
                    this.txtnote55.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num189, num));
                }
                else
                {
                    this.txtnote55.Text = "-";
                }
                if (num186 != new decimal(0))
                {
                    this.txtnote56.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num186, num));
                }
                else
                {
                    this.txtnote56.Text = "-";
                }
                if (num187 != new decimal(0))
                {
                    this.txtnote57.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num187, num));
                }
                else
                {
                    this.txtnote57.Text = "-";
                }
                num176 = ((num58 + -num186) >= new decimal(0) ? num169 - (num58 + -num186) : num169 + num58 + -num186);
                if (num176 == new decimal(0))
                {
                    this.AdvanceVatAmountN28P7.Text = "-";
                }
                else if (num176 >= new decimal(0))
                {
                    this.AdvanceVatAmountN28P7.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num176, num));
                }
                else
                {
                    Label advanceVatAmountN28P7 = this.AdvanceVatAmountN28P7;
                    object obj8 = '(';
                    string withString7 = Utilities.RoundUpToWithString(num176, num);
                    chrArray = new char[] { '-' };
                    advanceVatAmountN28P7.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj8, withString7.TrimStart(chrArray), ')'));
                }
                decimal num192 = new decimal(0);
                decimal num193 = new decimal(0);
                decimal num194 = new decimal(0);
                num192 = num176;
                num183 = Convert.ToDecimal(note42.Rows[0]["amount"]);
                num193 = (this.Label20.Text != "" ? Convert.ToDecimal(this.Label20.Text.Trim()) : new decimal(0));
                num194 = (this.Label5.Text != "" ? Convert.ToDecimal(this.Label5.Text.Trim()) : new decimal(0));
                num60 = ((num192 + num183) + num193) + num194;
                if (num60 == new decimal(0))
                {
                    this.lbl50.Text = "-";
                }
                else if (num60 >= new decimal(0))
                {
                    this.lbl50.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num60, num));
                }
                else
                {
                    Label label1 = this.lbl50;
                    object obj9 = '(';
                    string str7 = Utilities.RoundUpToWithString(num60, num);
                    chrArray = new char[] { '-' };
                    label1.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj9, str7.TrimStart(chrArray), ')'));
                }
                DataTable vatReturnPart852Data = this.dbBLL.getVatReturnPart852Data(empty, empty1, num62);
                decimal num195 = new decimal(0);
                if (vatReturnPart852Data == null || vatReturnPart852Data.Rows.Count <= 0)
                {
                    this.TotalVatN32P8.Text = "-";
                    this.oc1.Text = "";
                }
                else
                {
                    num195 = Convert.ToDecimal(vatReturnPart852Data.Rows[0]["amount"]);
                    this.TotalVatN32P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num195, num));
                    this.oc1.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart852Data.Rows[0]["code_no"].ToString());
                }
                DataTable vatReturnPart853Data = this.dbBLL.getVatReturnPart853Data(empty, empty1, num62);
                decimal num196 = new decimal(0);
                if (vatReturnPart853Data == null || vatReturnPart853Data.Rows.Count <= 0)
                {
                    this.SDdepositN33P8.Text = "-";
                    this.oc2.Text = "";
                }
                else
                {
                    num196 = Convert.ToDecimal(vatReturnPart853Data.Rows[0]["amount"]);
                    this.SDdepositN33P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num196, num));
                    this.oc2.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart853Data.Rows[0]["code_no"].ToString());
                }
                DataTable vatReturnPart854Data = this.dbBLL.getVatReturnPart854Data(empty, empty1, num62);
                if (vatReturnPart854Data != null)
                {
                    int count = vatReturnPart854Data.Rows.Count;
                }
                DataTable vatReturnPart855Data = this.dbBLL.getVatReturnPart855Data(empty, empty1, num62);
                if (vatReturnPart855Data != null)
                {
                    int count1 = vatReturnPart855Data.Rows.Count;
                }
                DataTable vatReturnPart856Data = this.dbBLL.getVatReturnPart856Data(empty, empty1, num62);
                if (vatReturnPart856Data != null)
                {
                    int count2 = vatReturnPart856Data.Rows.Count;
                }
                DataTable vatReturnPart857Data = this.dbBLL.getVatReturnPart857Data(empty, empty1, num62);
                decimal num197 = new decimal(0);
                decimal num198 = new decimal(0);
                decimal num199 = new decimal(0);
                decimal num200 = new decimal(0);
                decimal num201 = new decimal(0);
                if (vatReturnPart857Data == null || vatReturnPart857Data.Rows.Count <= 0)
                {
                    this.ExciseDutyN33P8.Text = "-";
                    this.oc6.Text = "";
                }
                else
                {
                    num197 = Convert.ToDecimal(vatReturnPart857Data.Rows[0]["amount"]);
                    this.ExciseDutyN33P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num197, num));
                    this.oc6.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart857Data.Rows[0]["code_no"].ToString());
                }
                DataTable vatReturnPart858Data = this.dbBLL.getVatReturnPart858Data(empty, empty1, num62);
                if (vatReturnPart858Data == null || vatReturnPart858Data.Rows.Count <= 0)
                {
                    this.DevelopmentN33P8.Text = "-";
                    this.oc7.Text = "";
                }
                else
                {
                    num198 = Convert.ToDecimal(vatReturnPart858Data.Rows[0]["amount"]);
                    this.DevelopmentN33P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num198, num));
                    this.oc7.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart858Data.Rows[0]["code_no"].ToString());
                }
                DataTable vatReturnPart859Data = this.dbBLL.getVatReturnPart859Data(empty, empty1, num62);
                if (vatReturnPart859Data == null || vatReturnPart859Data.Rows.Count <= 0)
                {
                    this.ICTN33P8.Text = "-";
                    this.oc8.Text = "";
                }
                else
                {
                    num199 = Convert.ToDecimal(vatReturnPart859Data.Rows[0]["amount"]);
                    this.ICTN33P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num199, num));
                    this.oc8.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart859Data.Rows[0]["code_no"].ToString());
                }
                DataTable vatReturnPart860Data = this.dbBLL.getVatReturnPart860Data(empty, empty1, num62);
                if (vatReturnPart860Data == null || vatReturnPart860Data.Rows.Count <= 0)
                {
                    this.HealthN33P8.Text = "-";
                    this.oc9.Text = "";
                }
                else
                {
                    num200 = Convert.ToDecimal(vatReturnPart860Data.Rows[0]["amount"]);
                    this.HealthN33P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num200, num));
                    this.oc9.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart860Data.Rows[0]["code_no"].ToString());
                }
                DataTable vatReturnPart861Data = this.dbBLL.getVatReturnPart861Data(empty, empty1, num62);
                if (vatReturnPart861Data == null || vatReturnPart861Data.Rows.Count <= 0)
                {
                    this.EnvironmentN33P8.Text = "-";
                    this.oc10.Text = "";
                }
                else
                {
                    num201 = Convert.ToDecimal(vatReturnPart861Data.Rows[0]["amount"]);
                    this.EnvironmentN33P8.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num201, num));
                    this.oc10.Text = Utilities.convertEnglistNumberIntoBangla(vatReturnPart861Data.Rows[0]["code_no"].ToString());
                }
                decimal num202 = new decimal(0);
                decimal num203 = new decimal(0);
                if (this.lblTotalVatN26P6.Text != "")
                {
                    Convert.ToDecimal(((num158 + num159) + num160) + num161);
                }
                num202 = (this.SDdepositN33P8.Text == "" ? new decimal(0) : num196);
                num203 = (this.ExciseDutyN30P7.Text == "" ? new decimal(0) : num182);
                decimal num204 = new decimal(0);
                decimal num205 = new decimal(0);
                decimal num206 = new decimal(0);
                decimal num207 = new decimal(0);
                decimal num208 = new decimal(0);
                decimal num209 = new decimal(0);
                num204 = num195;
                num205 = (this.Label7.Text != "" ? Convert.ToDecimal(this.Label7.Text.Trim()) : new decimal(0));
                num206 = -num204 + num60 + num205;
                if (num206 == new decimal(0))
                {
                    this.txtRefundMoneyN35P9.Text = "-";
                }
                else if (num206 >= new decimal(0))
                {
                    this.txtRefundMoneyN35P9.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num206, num));
                }
                else
                {
                    TextBox textBox = this.txtRefundMoneyN35P9;
                    object obj10 = '(';
                    string withString8 = Utilities.RoundUpToWithString(num206, num);
                    chrArray = new char[] { '-' };
                    textBox.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj10, withString8.TrimStart(chrArray), ')'));
                }
                num207 = num196;
                num208 = (this.Label8.Text != "" ? Convert.ToDecimal(this.Label8.Text.Trim()) : new decimal(0));
                num209 = -num207 + num208 + num61;
                if (num209 == new decimal(0))
                {
                    this.txtRefundSD.Text = "-";
                }
                else if (num209 >= new decimal(0))
                {
                    this.txtRefundSD.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num209, num));
                }
                else
                {
                    TextBox textBox1 = this.txtRefundSD;
                    object obj11 = '(';
                    string str8 = Utilities.RoundUpToWithString(num209, num);
                    chrArray = new char[] { '-' };
                    textBox1.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj11, str8.TrimStart(chrArray), ')'));
                }
                decimal num210 = new decimal(0);
                num210 = num58;
                if (num210 != new decimal(0))
                {
                    this.node50Value.Text = Utilities.convertEnglistNumberIntoBangla(num210.ToString());
                }
                else
                {
                    this.node50Value.Text = "-";
                }
                decimal num211 = new decimal(0);
                num211 = num88;
                this.node9Value.Text = Utilities.convertEnglistNumberIntoBangla(num211.ToString());
                decimal num212 = num210 + num211;
                if (num212 == new decimal(0))
                {
                    this.totalOf50and9Value.Text = "-";
                }
                else if (num212 >= new decimal(0))
                {
                    this.totalOf50and9Value.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num212, num));
                }
                else
                {
                    Label label2 = this.totalOf50and9Value;
                    object obj12 = '(';
                    string str9 = num212.ToString("N2");
                    chrArray = new char[] { '-' };
                    label2.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj12, str9.TrimStart(chrArray), ')'));
                }
                decimal num213 = new decimal(0);
                num213 = num23;
                decimal num214 = new decimal(0);
                decimal num215 = num213 + num40;
                if (num215 == new decimal(0))
                {
                    this.localPurchase23Value.Text = "-";
                }
                else if (num215 >= new decimal(0))
                {
                    this.localPurchase23Value.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num215, num));
                }
                else
                {
                    Label label3 = this.localPurchase23Value;
                    object obj13 = '(';
                    string withString9 = Utilities.RoundUpToWithString(num215, num);
                    chrArray = new char[] { '-' };
                    label3.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj13, withString9.TrimStart(chrArray), ')'));
                }
                decimal num216 = new decimal(0);
                num216 = num28;
                decimal num217 = new decimal(0);
                decimal num218 = num216 + num45;
                if (num218 == new decimal(0))
                {
                    this.import23Value.Text = "-";
                }
                else if (num218 >= new decimal(0))
                {
                    this.import23Value.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num218, num));
                }
                else
                {
                    Label label4 = this.import23Value;
                    object obj14 = '(';
                    string withString10 = Utilities.RoundUpToWithString(num218, num);
                    chrArray = new char[] { '-' };
                    label4.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj14, withString10.TrimStart(chrArray), ')'));
                }
                decimal num219 = num215 + num218;
                if (num219 == new decimal(0))
                {
                    this.subTotal23Value.Text = "-";
                }
                else if (num219 >= new decimal(0))
                {
                    this.subTotal23Value.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num219, num));
                }
                else
                {
                    Label label5 = this.subTotal23Value;
                    object obj15 = '(';
                    string str10 = Utilities.RoundUpToWithString(num219, num);
                    chrArray = new char[] { '-' };
                    label5.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj15, str10.TrimStart(chrArray), ')'));
                }
                decimal num220 = num212 - num219;
                if (num220 == new decimal(0))
                {
                    this.total23Value.Text = "-";
                }
                else if (num220 >= new decimal(0))
                {
                    this.total23Value.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num220, num));
                }
                else
                {
                    Label label7 = this.total23Value;
                    object obj16 = '(';
                    string withString11 = Utilities.RoundUpToWithString(num220, num);
                    chrArray = new char[] { '-' };
                    label7.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj16, withString11.TrimStart(chrArray), ')'));
                }
                decimal num221 = new decimal(0);
                num221 = Convert.ToDecimal(num153);
                this.node28Value.Text = Utilities.convertEnglistNumberIntoBangla(num221.ToString());
                decimal num222 = num220 + num221;
                if (num222 == new decimal(0))
                {
                    this.node28Total.Text = "-";
                }
                else if (num222 >= new decimal(0))
                {
                    this.node28Total.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num222, num));
                }
                else
                {
                    Label label8 = this.node28Total;
                    object obj17 = '(';
                    string str11 = Utilities.RoundUpToWithString(num222, num);
                    chrArray = new char[] { '-' };
                    label8.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj17, str11.TrimStart(chrArray), ')'));
                }
                decimal num223 = new decimal(0);
                num223 = Convert.ToDecimal(num162);
                this.node34Value.Text = Utilities.convertEnglistNumberIntoBangla(num223.ToString());
                decimal num224 = num222 - num223;
                if (num224 == new decimal(0))
                {
                    this.node34Total.Text = "-";
                }
                else if (num224 >= new decimal(0))
                {
                    this.node34Total.Text = Utilities.convertEnglistNumberIntoBangla(Utilities.RoundUpToWithString(num224, num));
                }
                else
                {
                    Label label9 = this.node34Total;
                    object obj18 = '(';
                    string withString12 = Utilities.RoundUpToWithString(num224, num);
                    chrArray = new char[] { '-' };
                    label9.Text = Utilities.convertEnglistNumberIntoBangla(string.Concat(obj18, withString12.TrimStart(chrArray), ')'));
                }
                List<MonthClosingBalance> monthClosingBalances = new List<MonthClosingBalance>();
                MonthClosingBalance monthClosingBalance = new MonthClosingBalance()
                {
                    Noteno = 1,
                    Credit_amount = num3,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance);
                MonthClosingBalance monthClosingBalance1 = new MonthClosingBalance()
                {
                    Noteno = 2,
                    Credit_amount = num2,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance1);
                MonthClosingBalance monthClosingBalance2 = new MonthClosingBalance()
                {
                    Noteno = 3,
                    Credit_amount = num3,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance2);
                MonthClosingBalance monthClosingBalance3 = new MonthClosingBalance()
                {
                    Noteno = 4,
                    Credit_amount = num4,
                    Debit_amount = new decimal(0),
                    Sd_amount = num6,
                    Vat_amount = num5
                };
                monthClosingBalances.Add(monthClosingBalance3);
                MonthClosingBalance monthClosingBalance4 = new MonthClosingBalance()
                {
                    Noteno = 5,
                    Credit_amount = num64,
                    Debit_amount = new decimal(0),
                    Sd_amount = num66,
                    Vat_amount = num65
                };
                monthClosingBalances.Add(monthClosingBalance4);
                MonthClosingBalance monthClosingBalance5 = new MonthClosingBalance()
                {
                    Noteno = 6,
                    Credit_amount = num3,
                    Debit_amount = new decimal(0),
                    Sd_amount = num9,
                    Vat_amount = num80
                };
                monthClosingBalances.Add(monthClosingBalance5);
                MonthClosingBalance monthClosingBalance6 = new MonthClosingBalance()
                {
                    Noteno = 7,
                    Credit_amount = num12,
                    Debit_amount = new decimal(0),
                    Sd_amount = num14,
                    Vat_amount = num13
                };
                monthClosingBalances.Add(monthClosingBalance6);
                MonthClosingBalance monthClosingBalance7 = new MonthClosingBalance()
                {
                    Noteno = 8,
                    Credit_amount = num83,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num84
                };
                monthClosingBalances.Add(monthClosingBalance7);
                MonthClosingBalance monthClosingBalance8 = new MonthClosingBalance()
                {
                    Noteno = 9,
                    Credit_amount = num83,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num84
                };
                monthClosingBalances.Add(monthClosingBalance8);
                MonthClosingBalance monthClosingBalance9 = new MonthClosingBalance()
                {
                    Noteno = 10,
                    Credit_amount = num20,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance9);
                MonthClosingBalance monthClosingBalance10 = new MonthClosingBalance()
                {
                    Noteno = 11,
                    Credit_amount = num21,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance10);
                MonthClosingBalance monthClosingBalance11 = new MonthClosingBalance()
                {
                    Noteno = 12,
                    Credit_amount = num32,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance11);
                MonthClosingBalance monthClosingBalance12 = new MonthClosingBalance()
                {
                    Noteno = 13,
                    Credit_amount = num33,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance12);
                MonthClosingBalance monthClosingBalance13 = new MonthClosingBalance()
                {
                    Noteno = 14,
                    Credit_amount = num22,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num23
                };
                monthClosingBalances.Add(monthClosingBalance13);
                MonthClosingBalance monthClosingBalance14 = new MonthClosingBalance()
                {
                    Noteno = 15,
                    Credit_amount = num27,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num28
                };
                monthClosingBalances.Add(monthClosingBalance14);
                MonthClosingBalance monthClosingBalance15 = new MonthClosingBalance()
                {
                    Noteno = 16,
                    Credit_amount = num22,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num23
                };
                monthClosingBalances.Add(monthClosingBalance15);
                MonthClosingBalance monthClosingBalance16 = new MonthClosingBalance()
                {
                    Noteno = 17,
                    Credit_amount = num44,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num45
                };
                monthClosingBalances.Add(monthClosingBalance16);
                MonthClosingBalance monthClosingBalance17 = new MonthClosingBalance()
                {
                    Noteno = 18,
                    Credit_amount = num111,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num112
                };
                monthClosingBalances.Add(monthClosingBalance17);
                MonthClosingBalance monthClosingBalance18 = new MonthClosingBalance()
                {
                    Noteno = 19,
                    Credit_amount = num119,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num38
                };
                monthClosingBalances.Add(monthClosingBalance18);
                MonthClosingBalance monthClosingBalance19 = new MonthClosingBalance()
                {
                    Noteno = 20,
                    Credit_amount = num123,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num124
                };
                monthClosingBalances.Add(monthClosingBalance19);
                MonthClosingBalance monthClosingBalance20 = new MonthClosingBalance()
                {
                    Noteno = 21,
                    Credit_amount = num127,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num128
                };
                monthClosingBalances.Add(monthClosingBalance20);
                MonthClosingBalance monthClosingBalance21 = new MonthClosingBalance()
                {
                    Noteno = 22,
                    Credit_amount = num131,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num132
                };
                monthClosingBalances.Add(monthClosingBalance21);
                MonthClosingBalance monthClosingBalance22 = new MonthClosingBalance()
                {
                    Noteno = 23,
                    Credit_amount = num135,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = num136
                };
                monthClosingBalances.Add(monthClosingBalance22);
                MonthClosingBalance monthClosingBalance23 = new MonthClosingBalance()
                {
                    Noteno = 24,
                    Credit_amount = num49,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance23);
                MonthClosingBalance monthClosingBalance24 = new MonthClosingBalance()
                {
                    Noteno = 25,
                    Credit_amount = num50,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance24);
                MonthClosingBalance monthClosingBalance25 = new MonthClosingBalance()
                {
                    Noteno = 26,
                    Credit_amount = num148,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance25);
                MonthClosingBalance monthClosingBalance26 = new MonthClosingBalance()
                {
                    Noteno = 27,
                    Credit_amount = num147,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance26);
                MonthClosingBalance monthClosingBalance27 = new MonthClosingBalance()
                {
                    Noteno = 28,
                    Credit_amount = num153,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance27);
                MonthClosingBalance monthClosingBalance28 = new MonthClosingBalance()
                {
                    Noteno = 29,
                    Credit_amount = num53,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance28);
                MonthClosingBalance monthClosingBalance29 = new MonthClosingBalance()
                {
                    Noteno = 30,
                    Credit_amount = num156,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance29);
                MonthClosingBalance monthClosingBalance30 = new MonthClosingBalance()
                {
                    Noteno = 31,
                    Credit_amount = num157,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance30);
                MonthClosingBalance monthClosingBalance31 = new MonthClosingBalance()
                {
                    Noteno = 32,
                    Credit_amount = num154,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance31);
                MonthClosingBalance monthClosingBalance32 = new MonthClosingBalance()
                {
                    Noteno = 33,
                    Credit_amount = num154,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance32);
                if (num174 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance33 = new MonthClosingBalance()
                    {
                        Noteno = 34,
                        Credit_amount = num174,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance33);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance34 = new MonthClosingBalance()
                    {
                        Noteno = 34,
                        Credit_amount = new decimal(0),
                        Debit_amount = num174,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance34);
                }
                if (num176 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance35 = new MonthClosingBalance()
                    {
                        Noteno = 35,
                        Credit_amount = num176,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance35);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance36 = new MonthClosingBalance()
                    {
                        Noteno = 35,
                        Credit_amount = new decimal(0),
                        Debit_amount = num176,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance36);
                }
                if (num181 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance37 = new MonthClosingBalance()
                    {
                        Noteno = 36,
                        Credit_amount = num181,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance37);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance38 = new MonthClosingBalance()
                    {
                        Noteno = 36,
                        Credit_amount = new decimal(0),
                        Debit_amount = num181,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance38);
                }
                if (num182 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance39 = new MonthClosingBalance()
                    {
                        Noteno = 37,
                        Credit_amount = num182,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance39);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance40 = new MonthClosingBalance()
                    {
                        Noteno = 37,
                        Credit_amount = new decimal(0),
                        Debit_amount = num182,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance40);
                }
                MonthClosingBalance monthClosingBalance41 = new MonthClosingBalance()
                {
                    Noteno = 38,
                    Credit_amount = num163,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance41);
                MonthClosingBalance monthClosingBalance42 = new MonthClosingBalance()
                {
                    Noteno = 39,
                    Credit_amount = num164,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance42);
                MonthClosingBalance monthClosingBalance43 = new MonthClosingBalance()
                {
                    Noteno = 40,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance43);
                MonthClosingBalance monthClosingBalance44 = new MonthClosingBalance()
                {
                    Noteno = 41,
                    Credit_amount = num183,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance44);
                MonthClosingBalance monthClosingBalance45 = new MonthClosingBalance()
                {
                    Noteno = 42,
                    Credit_amount = num184,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance45);
                MonthClosingBalance monthClosingBalance46 = new MonthClosingBalance()
                {
                    Noteno = 43,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance46);
                MonthClosingBalance monthClosingBalance47 = new MonthClosingBalance()
                {
                    Noteno = 44,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance47);
                MonthClosingBalance monthClosingBalance48 = new MonthClosingBalance()
                {
                    Noteno = 45,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance48);
                MonthClosingBalance monthClosingBalance49 = new MonthClosingBalance()
                {
                    Noteno = 46,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance49);
                MonthClosingBalance monthClosingBalance50 = new MonthClosingBalance()
                {
                    Noteno = 47,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance50);
                MonthClosingBalance monthClosingBalance51 = new MonthClosingBalance()
                {
                    Noteno = 48,
                    Credit_amount = num175,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance51);
                MonthClosingBalance monthClosingBalance52 = new MonthClosingBalance()
                {
                    Noteno = 49,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance52);
                if (num60 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance53 = new MonthClosingBalance()
                    {
                        Noteno = 50,
                        Credit_amount = num60,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance53);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance54 = new MonthClosingBalance()
                    {
                        Noteno = 50,
                        Credit_amount = new decimal(0),
                        Debit_amount = num60,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance54);
                }
                if (num61 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance55 = new MonthClosingBalance()
                    {
                        Noteno = 51,
                        Credit_amount = num61,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance55);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance56 = new MonthClosingBalance()
                    {
                        Noteno = 51,
                        Credit_amount = new decimal(0),
                        Debit_amount = num61,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance56);
                }
                if (num58 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance57 = new MonthClosingBalance()
                    {
                        Noteno = 52,
                        Credit_amount = num58,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance57);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance58 = new MonthClosingBalance()
                    {
                        Noteno = 52,
                        Credit_amount = new decimal(0),
                        Debit_amount = num58,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance58);
                }
                if (num59 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance59 = new MonthClosingBalance()
                    {
                        Noteno = 53,
                        Credit_amount = num59,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance59);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance60 = new MonthClosingBalance()
                    {
                        Noteno = 53,
                        Credit_amount = new decimal(0),
                        Debit_amount = num59,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance60);
                }
                MonthClosingBalance monthClosingBalance61 = new MonthClosingBalance()
                {
                    Noteno = 54,
                    Credit_amount = num188,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance61);
                MonthClosingBalance monthClosingBalance62 = new MonthClosingBalance()
                {
                    Noteno = 55,
                    Credit_amount = num189,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance62);
                MonthClosingBalance monthClosingBalance63 = new MonthClosingBalance()
                {
                    Noteno = 56,
                    Credit_amount = num186,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance63);
                MonthClosingBalance monthClosingBalance64 = new MonthClosingBalance()
                {
                    Noteno = 57,
                    Credit_amount = num187,
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance64);
                MonthClosingBalance monthClosingBalance65 = new MonthClosingBalance()
                {
                    Noteno = 58,
                    Credit_amount = new decimal(0),
                    Debit_amount = num195,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance65);
                MonthClosingBalance monthClosingBalance66 = new MonthClosingBalance()
                {
                    Noteno = 59,
                    Credit_amount = new decimal(0),
                    Debit_amount = num196,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance66);
                MonthClosingBalance monthClosingBalance67 = new MonthClosingBalance()
                {
                    Noteno = 60,
                    Credit_amount = new decimal(0),
                    Debit_amount = num197,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance67);
                MonthClosingBalance monthClosingBalance68 = new MonthClosingBalance()
                {
                    Noteno = 61,
                    Credit_amount = new decimal(0),
                    Debit_amount = num198,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance68);
                MonthClosingBalance monthClosingBalance69 = new MonthClosingBalance()
                {
                    Noteno = 62,
                    Credit_amount = new decimal(0),
                    Debit_amount = num199,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance69);
                MonthClosingBalance monthClosingBalance70 = new MonthClosingBalance()
                {
                    Noteno = 63,
                    Credit_amount = new decimal(0),
                    Debit_amount = num200,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance70);
                MonthClosingBalance monthClosingBalance71 = new MonthClosingBalance()
                {
                    Noteno = 64,
                    Credit_amount = new decimal(0),
                    Debit_amount = num201,
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance71);
                if (num206 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance72 = new MonthClosingBalance()
                    {
                        Noteno = 65,
                        Credit_amount = num206,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance72);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance73 = new MonthClosingBalance()
                    {
                        Noteno = 65,
                        Credit_amount = new decimal(0),
                        Debit_amount = num206,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance73);
                }
                if (num209 >= new decimal(0))
                {
                    MonthClosingBalance monthClosingBalance74 = new MonthClosingBalance()
                    {
                        Noteno = 66,
                        Credit_amount = num209,
                        Debit_amount = new decimal(0),
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance74);
                }
                else
                {
                    MonthClosingBalance monthClosingBalance75 = new MonthClosingBalance()
                    {
                        Noteno = 66,
                        Credit_amount = new decimal(0),
                        Debit_amount = num209,
                        Sd_amount = new decimal(0),
                        Vat_amount = new decimal(0)
                    };
                    monthClosingBalances.Add(monthClosingBalance75);
                }
                MonthClosingBalance monthClosingBalance76 = new MonthClosingBalance()
                {
                    Noteno = 67,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance76);
                MonthClosingBalance monthClosingBalance77 = new MonthClosingBalance()
                {
                    Noteno = 68,
                    Credit_amount = new decimal(0),
                    Debit_amount = new decimal(0),
                    Sd_amount = new decimal(0),
                    Vat_amount = new decimal(0)
                };
                monthClosingBalances.Add(monthClosingBalance77);
                this.Session["report_values"] = monthClosingBalances;
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                BLL.Utility.InsertErrorTrackNew(exception.Message, "VATReturnMushok19sR.aspx", "ShowReport", fileLineNumber);
            }
        }

        protected void SubForm_3Row1K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_1s.aspx");
        }

        protected void SubForm_3Row2K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_2s.aspx");
        }

        protected void SubForm_3Row3K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_3s.aspx");
        }

        protected void SubForm_3Row4K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_ks.aspx");
        }

        protected void SubForm_3Row5K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_5s.aspx");
        }

        protected void SubForm_3Row6K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_Gha_Note_6s.aspx");
        }

        protected void SubForm_3Row7K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_7s.aspx");
        }

        protected void SubForm_3Row8KH_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_Kha_Note_8s.aspx");
        }

        protected void SubForm_4Row10k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_10s.aspx");
        }

        protected void SubForm_4ROW11K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_11s.aspx");
        }

        protected void SubForm_4Row12k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note12s.aspx");
        }

        protected void SubForm_4Row13k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note13s.aspx");
        }

        protected void SubForm_4Row14k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note_14s1.aspx");
        }

        protected void SubForm_4Row15k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_15s.aspx");
        }

        protected void SubForm_4Row16k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k_Note_16s.aspx");
        }

        protected void SubForm_4Row17k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_Note_17s.aspx");
        }

        protected void SubForm_4Row18k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_Gha_Note_18s.aspx");
        }

        protected void SubForm_4Row19k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k19s.aspx");
        }

        protected void SubForm_4Row20k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_k20s.aspx");
        }

        protected void SubForm_4Row21k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_K_Note_21s.aspx");
        }

        protected void SubForm_4Row22k_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_K_Note_22s.aspx");
        }

        protected void SubForm_5_K_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_K_5s.aspx");
        }

        protected void SubForm_5Row24GHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_GHA_Note_24s.aspx");
        }

        protected void SubForm_6Row30CH_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_CHs.aspx");
        }

        protected void SubForm_9Row58CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_CHAs.aspx");
        }

        protected void SubForm_9Row59CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note53s.aspx");
        }

        protected void SubForm_9Row60CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note57s.aspx");
        }

        protected void SubForm_9Row61CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note58s.aspx");
        }

        protected void SubForm_9Row62CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note59s.aspx");
        }

        protected void SubForm_9Row63CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note60s.aspx");
        }

        protected void SubForm_9Row64CHA_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Sub_Form_CHA_Note61s.aspx");
        }

        protected void Subform26_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Subform_Note_26s.aspx");
        }

        protected void Subform31_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/Subform_Note_31s.aspx");
        }

        protected void SunForm_6Row29UMO_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("SubForms/SubForm_UMO_Note_29s.aspx");
        }

        private void ValidateXML(string filename)
        {
            XmlReader xmlReader = null;
            try
            {
                try
                {
                    XmlReaderSettings xmlReaderSetting = new XmlReaderSettings()
                    {
                        ValidationType = ValidationType.Schema
                    };
                    XmlReaderSettings validationFlags = xmlReaderSetting;
                    validationFlags.ValidationFlags = validationFlags.ValidationFlags | XmlSchemaValidationFlags.ProcessSchemaLocation;
                    XmlReaderSettings validationFlags1 = xmlReaderSetting;
                    validationFlags1.ValidationFlags = validationFlags1.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
                    xmlReaderSetting.ValidationEventHandler += new ValidationEventHandler(this.ValidationEventHandler);
                    xmlReader = XmlReader.Create(filename, xmlReaderSetting);
                    while (xmlReader.Read())
                    {
                    }
                    this.lblStatus.Text = "Validation Passed";
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    this.lblStatus.Text = string.Concat("Error Validating", exception.Message);
                }
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }

        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            XmlSeverityType xmlSeverityType = XmlSeverityType.Warning;
            if (!Enum.TryParse<XmlSeverityType>("Error", out xmlSeverityType) || xmlSeverityType != XmlSeverityType.Error)
            {
                Console.WriteLine(string.Concat("\r\n\tValidation Error:", e.Message));
                this.lblStatus.Text = string.Concat("Validation Failed", e.Message);
                throw new Exception(string.Concat("Validation Failed", e.Message));
            }
            throw new Exception(e.Message);
        }

        private void xmlVAT19()
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlNode xmlNodes = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(xmlNodes);
                XmlElement xmlElement = xmlDocument.CreateElement("ArrayOfVAT_18");
                xmlDocument.AppendChild(xmlElement);
                XmlNode xmlNodes1 = csXML.XmlHelper.AddElement("VAT19", null, xmlElement);
                csXML.XmlHelper.AddElement("sessionvalue", "999", xmlNodes1);
                csXML.XmlHelper.AddElement("VatRegistrationNo", this.Session["ORGANIZATION_BIN"].ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP1A", this.TaxOrganizationName.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP1B", this.Session["ORGANIZATION_BIN"].ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP2A", this.lblTaxPeriod.Text.ToString(), xmlNodes1);
                bool flag = (this.chkHa.Checked ? true : false);
                csXML.XmlHelper.AddElement("ColumnP2B", flag.ToString(), xmlNodes1);
                DateTime utcNow = DateTime.UtcNow;
                csXML.XmlHelper.AddElement("ColumnP2C", utcNow.ToString("dd-MMM-yyyy"), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N1A", this.zerorateDeemedExportAmountN1P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N2A", this.zerorateDirectExportAmountN2P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N3A", this.exemptedSupplyAmountN3P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N4A", this.typicalSupplyAmountN4P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N4B", this.typicalSupplyVATN4P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N4C", this.typicalSupplySDN4P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N5A", this.note5AmountP3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N5B", this.note5VATP3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N5C", this.note5SDP3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N6A", this.nonTypicalSupplyAmountN6P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N6B", this.nonTypicalSupplyVATN6P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N6C", this.nonTypicalSupplySDN6P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP3N7BC", this.lblTotalVatN7P3.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N8A", this.exemptedLocalPurchaseAmountN8P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N9A", this.exemptedForeignPurchaseAmountN9P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N10A", this.zerorateLocalPurchaseAmountN10P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N11A", this.zerorateForeignPurchaseAmountN11P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N12A", this.standardLocalPurchaseAmountN12P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N12B", this.standardLocalPurchaseVatN12P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N13A", this.standardForeignPurchaseAmountN13P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N13B", this.standardForeignPurchaseVatN13P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N14A", this.partialRebatePurchaseAmountN14P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N14B", this.partialRebatePurchaseVatN14P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N15A", this.nonRebatePurchaseAmountN15P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N15B", this.nonRebatePurchaseVatN15P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP4N16B", this.lblTotalVatN16P4.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP5N17A", this.receiveVDSAmountN17P5.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP5N18A", this.nonBankingPaymentVatN18P5.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP5N19A", this.changePurchaseAllVatN19P5.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP5N20A", this.otherAdjusmentVatN20P5.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP5N21A", this.lblTotalVatN21P5.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP6N22A", this.paidVDSAmountN22P6.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP6N23A", this.changeSaleAllVatN23P6.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP6N25A", this.otherAdjusmentAmountN25P6.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP6N26A", this.lblTotalVatN26P6.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP7N27A", this.TotalVatSDAmountN27P7.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP7N28A", this.AdvanceVatAmountN28P7.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP7N29A", this.PrevAdvanceAmountN29P7.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP7N30A", this.ExciseDutyN30P7.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP7N31A", this.SurchargeN31P7.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N32A", this.TotalVatN32P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N33A", this.SDdepositN33P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N37A", this.ExciseDutyN33P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N38A", this.DevelopmentN33P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N39A", this.ICTN33P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N310A", this.HealthN33P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP8N311A", this.EnvironmentN33P8.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP9N35A", this.txtRefundMoneyN35P9.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP10A", this.TaxpayerNameP10.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP10B", this.TaxpayerDesignationP10.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP10D", this.TaxpayerMobileNoP10.Text.ToString(), xmlNodes1);
                csXML.XmlHelper.AddElement("ColumnP10E", this.TaxpayerEmailP10.Text.ToString(), xmlNodes1);
                xmlDocument.Save(base.Server.MapPath("VAT_19.xml"));
                string fullPath = Path.GetFullPath(base.Server.MapPath("VAT_19.xml"));
                FileInfo fileInfo = new FileInfo(fullPath);
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.Cache.SetCacheability(HttpCacheability.Private);
                response.AddHeader("Content-Disposition", string.Concat("attachment; filename=", fileInfo.Name));
                response.ContentType = "application/xml";
                response.WriteFile(fullPath);
                response.End();
            }
            catch (Exception exception)
            {
                ReallySimpleLog.WriteLog(exception);
            }
        }

        public class ActionRoot
        {
            public string ActionResult
            {
                get;
                set;
            }

            public ActionRoot()
            {
            }
        }

        public class ApiItem
        {
            public string GOODS_SERVICE_CODE
            {
                get;
                set;
            }

            public string GOODS_SERVICE_NAME
            {
                get;
                set;
            }

            public string ITEM_ID
            {
                get;
                set;
            }

            public string MANUAL_INPUT
            {
                get;
                set;
            }

            public string NOTE
            {
                get;
                set;
            }

            public string SD_RATE
            {
                get;
                set;
            }

            public string SPECIFIC_RATE
            {
                get;
                set;
            }

            public string TYPE
            {
                get;
                set;
            }

            public string VALID_FROM
            {
                get;
                set;
            }

            public string VALID_TO
            {
                get;
                set;
            }

            public string VAT_RATE
            {
                get;
                set;
            }

            public ApiItem()
            {
            }
        }

        public class ApiResponse
        {
            public List<VATReturnMushok19sR.ApiItem> items
            {
                get;
                set;
            }

            public string message
            {
                get;
                set;
            }

            public ApiResponse()
            {
            }
        }

        public class CpcCode
        {
            public string CPC_CODE
            {
                get;
                set;
            }

            public string DESCRIPTION
            {
                get;
                set;
            }

            public CpcCode()
            {
            }
        }

        public class CpcCodeResponse
        {
            public List<VATReturnMushok19sR.CpcCode> items
            {
                get;
                set;
            }

            public string message
            {
                get;
                set;
            }

            public CpcCodeResponse()
            {
            }
        }

        public class CpcCodeRoot
        {
            public VATReturnMushok19sR.CpcCodeResponse response
            {
                get;
                set;
            }

            public CpcCodeRoot()
            {
            }
        }

        public class ResponseRoot
        {
            public VATReturnMushok19sR.ApiResponse response
            {
                get;
                set;
            }

            public ResponseRoot()
            {
            }
        }
    }
}
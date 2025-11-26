using System;
using System.Collections;
using System.Diagnostics;



namespace NBR_VAT_GROUPOFCOM.BLL
{
    public class BandrollManagementBLL
    {
        private DBUtility connDB = new DBUtility();

        public BandrollManagementBLL()
        {
        }

        private ArrayList getBandrollDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int challanID)
        {
            ArrayList arrayLists;
            try
            {
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                for (int i = 0; i < arrDeailDAO.Count; i++)
                {
                    str = " NULL";
                    str1 = " NULL";
                    str2 = " NULL";
                    str3 = " NULL";
                    str4 = " NULL";
                    BandrollIManagementDAO bandrollIManagementDAO = new BandrollIManagementDAO();
                    bandrollIManagementDAO = (BandrollIManagementDAO)arrDeailDAO[i];
                    int num = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('bandroll_id')"));
                    if (bandrollIManagementDAO.Property_id1 != 0)
                    {
                        str = bandrollIManagementDAO.Property_id1.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id2 != 0)
                    {
                        str1 = bandrollIManagementDAO.Property_id2.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id3 != 0)
                    {
                        str2 = bandrollIManagementDAO.Property_id3.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id4 != 0)
                    {
                        str3 = bandrollIManagementDAO.Property_id4.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id5 != 0)
                    {
                        str4 = bandrollIManagementDAO.Property_id5.ToString();
                    }
                    object[] objArray = new object[] { " INSERT INTO trns_bandroll_uses_d (challan_id,rcv_challan_id, row_no,bandroll_id,quantity,unit_price, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, user_id_insert)\r\n                                VALUES (", challanID, ",", challanID, ", ", bandrollIManagementDAO.Row_No, ",", num, ",", bandrollIManagementDAO.Quantity, ",", bandrollIManagementDAO.BandrollAdjAmount, ", ", bandrollIManagementDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",", bandrollIManagementDAO.User_id_insert, ")" };
                    arrDetailList.Add(string.Concat(objArray));
                }
                arrayLists = arrDetailList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return arrayLists;
        }

        private ArrayList getBandrollReceiveDetails(ArrayList arrDetailList, ArrayList arrDeailDAO, int challanID)
        {
            ArrayList arrayLists;
            try
            {
                string str = "";
                string str1 = "";
                string str2 = "";
                string str3 = "";
                string str4 = "";
                for (int i = 0; i < arrDeailDAO.Count; i++)
                {
                    str = " NULL";
                    str1 = " NULL";
                    str2 = " NULL";
                    str3 = " NULL";
                    str4 = " NULL";
                    BandrollIManagementDAO bandrollIManagementDAO = new BandrollIManagementDAO();
                    bandrollIManagementDAO = (BandrollIManagementDAO)arrDeailDAO[i];
                    int num = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('bandroll_id')"));
                    if (bandrollIManagementDAO.Property_id1 != 0)
                    {
                        str = bandrollIManagementDAO.Property_id1.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id2 != 0)
                    {
                        str1 = bandrollIManagementDAO.Property_id2.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id3 != 0)
                    {
                        str2 = bandrollIManagementDAO.Property_id3.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id4 != 0)
                    {
                        str3 = bandrollIManagementDAO.Property_id4.ToString();
                    }
                    if (bandrollIManagementDAO.Property_id5 != 0)
                    {
                        str4 = bandrollIManagementDAO.Property_id5.ToString();
                    }
                    object[] objArray = new object[] { " INSERT INTO trns_bandroll_rcv_d (challan_id, row_no,bandroll_id,quantity,unit_price, Item_id, property_id1, property_id2, property_id3, property_id4, property_id5, user_id_insert)\r\n                                VALUES (", challanID, ", ", bandrollIManagementDAO.Row_No, ",", num, ",", bandrollIManagementDAO.Quantity, ",", bandrollIManagementDAO.BandrollAdjAmount, ", ", bandrollIManagementDAO.Item_id, ", ", str, ", ", str1, ", ", str2, ", ", str3, ", ", str4, ",", bandrollIManagementDAO.User_id_insert, ")" };
                    arrDetailList.Add(string.Concat(objArray));
                }
                arrayLists = arrDetailList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return arrayLists;
        }

        public bool insertBandrollIssueData(BandrollIManagementMasterDAO objCPM, ArrayList arrDetail)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                objCPM.Challan_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('bandroll_uses_challan_id_seq')"));
                object[] challanId = new object[] { "INSERT INTO trns_bandroll_uses_m (challan_id, organization_id, challan_no, date_challan, user_id_insert)\r\n                                VALUES (", objCPM.Challan_id, ",", objCPM.Organization_id, ", '", objCPM.Challan_no, "', \r\n                                       \r\n\r\n                                        to_timestamp('", null, null, null, null };
                challanId[7] = objCPM.Date_challan.ToString("MM/dd/yyyy HH:mm");
                challanId[8] = "','MM/dd/yyyy HH24:MI'), ";
                challanId[9] = objCPM.User_id_insert;
                challanId[10] = ")";
                arrayLists.Add(string.Concat(challanId));
                arrayLists = this.getBandrollDetails(arrayLists, arrDetail, objCPM.Challan_id);
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                bool flag1 = Utility.InsertErrorTrackNew(exception.Message, "Bandroll", "insertBandrollIssueData", fileLineNumber);
                flag = flag1;
            }
            return flag;
        }

        public bool insertBandrollReceiveData(BandrollIManagementMasterDAO objCPM, ArrayList arrDetail)
        {
            bool flag;
            try
            {
                ArrayList arrayLists = new ArrayList();
                objCPM.Challan_id = Convert.ToInt32(this.connDB.GetSingleValue("SELECT  nextval('bandroll_rcv_challan_id_seq')"));
                object[] challanId = new object[] { "INSERT INTO trns_bandroll_rcv_m (challan_id, organization_id, receive_challan_no, date_receive, user_id_insert,provided_challan_id)\r\n                                VALUES (", objCPM.Challan_id, ",", objCPM.Organization_id, ", '", objCPM.Challan_no, "', \r\n                                       \r\n\r\n                                        to_timestamp('", null, null, null, null, null, null };
                challanId[7] = objCPM.Date_challan.ToString("MM/dd/yyyy HH:mm");
                challanId[8] = "','MM/dd/yyyy HH24:MI'), ";
                challanId[9] = objCPM.User_id_insert;
                challanId[10] = ", ";
                challanId[11] = objCPM.Providedchallan_id;
                challanId[12] = ")";
                arrayLists.Add(string.Concat(challanId));
                arrayLists = this.getBandrollReceiveDetails(arrayLists, arrDetail, objCPM.Challan_id);
                flag = this.connDB.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                StackTrace stackTrace = new StackTrace(exception, true);
                StackFrame frame = stackTrace.GetFrame(stackTrace.FrameCount - 1);
                int fileLineNumber = frame.GetFileLineNumber();
                bool flag1 = Utility.InsertErrorTrackNew(exception.Message, "Bandroll", "insertBandrollIssueData", fileLineNumber);
                flag = flag1;
            }
            return flag;
        }
    }
}


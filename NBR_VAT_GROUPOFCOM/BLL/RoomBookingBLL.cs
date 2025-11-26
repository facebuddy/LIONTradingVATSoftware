using System;
using System.Collections;
using System.Data;



namespace NBR_VAT_GROUPOFCOM.BLL
{


    public class RoomBookingBLL
    {
        private DBUtility db = new DBUtility();

        public RoomBookingBLL()
        {
        }

        private ArrayList AddDeailInsertSQL(ArrayList arrDetailList, ArrayList arrDeailDAO, int BookingID)
        {
            try
            {
                for (int i = 0; i < arrDeailDAO.Count; i++)
                {
                    RoomBookingDetail roomBookingDetail = new RoomBookingDetail();
                    roomBookingDetail = (RoomBookingDetail)arrDeailDAO[i];
                    roomBookingDetail.DetailID = (long)Convert.ToInt32(this.db.GetSingleValue("SELECT  nextval('booking_detail_id_seq')"));
                    object[] bookingID = new object[] { "INSERT INTO room_booking_detail(booking_id, row_no, person_name, address, gender_id_m, gender_id_d, \r\n                                    religion_id_m, religion_id_d, person_age, country_id, nationality, \r\n                                    passport_no, comming_from, purpose_of_visit, vehicle_type, vehicle_no, \r\n                                    mobile_no, national_id_no, detail_id,user_id_insert)\r\n                                VALUES (", BookingID, ", ", roomBookingDetail.RowNo, ", '", roomBookingDetail.PersonName, "',  '", roomBookingDetail.PersonAddress, "', ", roomBookingDetail.GenderIDM, ", ", roomBookingDetail.GenderID, ", \r\n                                        ", roomBookingDetail.ReligionIDM, ", ", roomBookingDetail.ReligionID, ", ", roomBookingDetail.Age, ", ", roomBookingDetail.CountryID, ", '", roomBookingDetail.Nationality, "', \r\n                                       '", roomBookingDetail.PassportNo, "', '", roomBookingDetail.CommingFrom, "', '", roomBookingDetail.PurposeOfVisit, "', \r\n                                       '", roomBookingDetail.VehicleType, "', '", roomBookingDetail.VehicleNo, "', '", roomBookingDetail.Mobile, "', '", roomBookingDetail.NID, "', ", roomBookingDetail.DetailID, ", \r\n                                       ", roomBookingDetail.UserIdInsert, ")" };
                    arrDetailList.Add(string.Concat(bookingID));
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return arrDetailList;
        }

        public bool CancelRoomBooking(long BookingID, int UID)
        {
            bool flag = false;
            try
            {
                object[] uID = new object[] { "update room_booking_master set is_deleted = true,user_id_update=", UID, ", date_update = now() where booking_id = ", BookingID };
                string str = string.Concat(uID);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public bool CheckoutRoomBooking(long BookingID, int UID)
        {
            bool flag = false;
            try
            {
                object[] uID = new object[] { "update room_booking_master set booking_status = false,user_id_update=", UID, ", date_update = now() where booking_id = ", BookingID };
                string str = string.Concat(uID);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public bool ExtendsRoomBooking(long BookingID, int UID, int ED)
        {
            bool flag = false;
            try
            {
                object[] eD = new object[] { "update room_booking_master set extends_day = ", ED, ",user_id_update=", UID, ", date_update = now() where booking_id = ", BookingID };
                string str = string.Concat(eD);
                flag = this.db.ExecuteDML(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }

        public DataTable GetAllAppCodeData(int ID)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string str = string.Concat("select code_id_d as ID, code_name as Name from app_code_detail where code_id_m = ", ID, " and is_deleted = false order by code_id_d");
                dataTable = this.db.GetDataTable(str);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAllCountry()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select country_id as ID, country_name as Name from set_country where is_deleted = false order by country_id");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetAllCustomer()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select customer_id as ID, customer_name as Name from set_customer where is_deleted = false order by customer_id");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public DataTable GetBookingRoomDetails()
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = this.db.GetDataTable("select booking_id, room_no, register_no, no_of_days, no_of_person,check_in_datetime, check_out_datetime,booking_status,\r\n                            customer_name,customer_address,customer_mobile\r\n                            from room_booking_master m\r\n                            inner join set_customer c on m.customer_id = c.customer_id\r\n                            where booking_status = true\r\n                            and m.is_deleted = false ");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return dataTable;
        }

        public bool InsertBookingData(RoomBookingMaster objMDAO, ArrayList arrDeailDAO)
        {
            bool flag = false;
            try
            {
                ArrayList arrayLists = new ArrayList();
                objMDAO.BookingID = Convert.ToInt32(this.db.GetSingleValue("SELECT  nextval('booking_id_seq')"));
                object[] bookingID = new object[] { "INSERT INTO room_booking_master(booking_id, register_no, customer_id, room_no, room_rate, no_of_days, \r\n                                discount, no_of_xperson, xperson_bill_daily, check_in_datetime, \r\n                                check_out_datetime, user_id_insert,no_of_person)\r\n                          VALUES ( ", objMDAO.BookingID, ",'", objMDAO.RegisterNo, "', ", objMDAO.CustomerID, ", ", objMDAO.RoomNo, ", ", objMDAO.RoomRate, ",\r\n                                   ", objMDAO.NoOfDays, ", ", objMDAO.Discount, ",", objMDAO.NoOfXPerson, ",", objMDAO.XPersonBill, ",\r\n                                    to_timestamp('", null, null, null, null, null, null, null, null };
                bookingID[19] = objMDAO.ChechInDateTime.ToString("MM/dd/yyyy HH:mm");
                bookingID[20] = "','MM/dd/yyyy HH24:MI'), \r\n                                    to_timestamp('";
                bookingID[21] = objMDAO.ChechOutDateTime.ToString("MM/dd/yyyy HH:mm");
                bookingID[22] = "','MM/dd/yyyy HH24:MI'), \r\n                                    ";
                bookingID[23] = objMDAO.UserIdInsert;
                bookingID[24] = ", ";
                bookingID[25] = objMDAO.NoOfPerson;
                bookingID[26] = " )";
                arrayLists.Add(string.Concat(bookingID));
                arrayLists = this.AddDeailInsertSQL(arrayLists, arrDeailDAO, objMDAO.BookingID);
                DataTable dataTable = new DataTable();
                flag = this.db.ExecuteBatchDML(arrayLists);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.ToString());
            }
            return flag;
        }
    }
}




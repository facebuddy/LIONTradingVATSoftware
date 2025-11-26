using System;
using System.Runtime.CompilerServices;


namespace NBR_VAT_GROUPOFCOM.BLL
{


    public class RoomBookingMaster
    {
        public int BookingID
        {
            get;
            set;
        }

        public DateTime ChechInDateTime
        {
            get;
            set;
        }

        public DateTime ChechOutDateTime
        {
            get;
            set;
        }

        public int CustomerID
        {
            get;
            set;
        }

        public int Discount
        {
            get;
            set;
        }

        public int NoOfDays
        {
            get;
            set;
        }

        public int NoOfPerson
        {
            get;
            set;
        }

        public int NoOfXPerson
        {
            get;
            set;
        }

        public string RegisterNo
        {
            get;
            set;
        }

        public int RoomID
        {
            get;
            set;
        }

        public string RoomNo
        {
            get;
            set;
        }

        public decimal RoomRate
        {
            get;
            set;
        }

        public int UserIdInsert
        {
            get;
            set;
        }

        public int UserIdUpdate
        {
            get;
            set;
        }

        public decimal XPersonBill
        {
            get;
            set;
        }

        public RoomBookingMaster()
        {
        }
    }
}

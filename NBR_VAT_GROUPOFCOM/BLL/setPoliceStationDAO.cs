using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class setPoliceStationDAO
    {
        private short policeStationId;

        private string policeStatioinName;

        private string district;

        private bool isDeleted;

        public string District
        {
            get
            {
                return this.district;
            }
            set
            {
                this.district = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this.isDeleted;
            }
            set
            {
                this.isDeleted = value;
            }
        }

        public string PoliceStatioinName
        {
            get
            {
                return this.policeStatioinName;
            }
            set
            {
                this.policeStatioinName = value;
            }
        }

        public short PoliceStationId
        {
            get
            {
                return this.policeStationId;
            }
            set
            {
                this.policeStationId = value;
            }
        }

        public setPoliceStationDAO()
        {
        }
    }
}
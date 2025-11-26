using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SetUnitDAO
    {
        private int intUnitId;

        private int intCenterId;

        private string strUnitName;

        private string strUnitCode;

        private int intMeasurementIdM;

        private int intMeasurementIdD;

        public int CenterId
        {
            get
            {
                return this.intCenterId;
            }
            set
            {
                this.intCenterId = value;
            }
        }

        public int MeasurementIdD
        {
            get
            {
                return this.intMeasurementIdD;
            }
            set
            {
                this.intMeasurementIdD = value;
            }
        }

        public int MeasurementIdM
        {
            get
            {
                return this.intMeasurementIdM;
            }
            set
            {
                this.intMeasurementIdM = value;
            }
        }

        public string UnitCode
        {
            get
            {
                return this.strUnitCode;
            }
            set
            {
                this.strUnitCode = value;
            }
        }

        public int UnitId
        {
            get
            {
                return this.intUnitId;
            }
            set
            {
                this.intUnitId = value;
            }
        }

        public string UnitName
        {
            get
            {
                return this.strUnitName;
            }
            set
            {
                this.strUnitName = value;
            }
        }

        public SetUnitDAO()
        {
        }
    }
}
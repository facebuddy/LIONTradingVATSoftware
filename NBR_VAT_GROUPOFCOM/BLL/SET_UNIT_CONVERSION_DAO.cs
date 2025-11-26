using System;
namespace NBR_VAT_GROUPOFCOM.BLL
{

    public class SET_UNIT_CONVERSION_DAO
    {
        private short intMeasurementIDM;

        private short intMeasurementIDD;

        private int intConversionId;

        private int intCenterId;

        private int intUnitIdFrom;

        private int intUnitFromCenterId;

        private double dblValueFrom;

        private int intUnitIdTo;

        private int intUnitToCenterId;

        private double dblValueTo;

        private char strConversionType;

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

        public int ConversionId
        {
            get
            {
                return this.intConversionId;
            }
            set
            {
                this.intConversionId = value;
            }
        }

        public char ConversionType
        {
            get
            {
                return this.strConversionType;
            }
            set
            {
                this.strConversionType = value;
            }
        }

        public short measurementIDD
        {
            get
            {
                return this.intMeasurementIDD;
            }
            set
            {
                this.intMeasurementIDD = value;
            }
        }

        public short measurementIDM
        {
            get
            {
                return this.intMeasurementIDM;
            }
            set
            {
                this.intMeasurementIDM = value;
            }
        }

        public int UnitFromCenterId
        {
            get
            {
                return this.intUnitFromCenterId;
            }
            set
            {
                this.intUnitFromCenterId = value;
            }
        }

        public int UnitIdFrom
        {
            get
            {
                return this.intUnitIdFrom;
            }
            set
            {
                this.intUnitIdFrom = value;
            }
        }

        public int UnitIdTo
        {
            get
            {
                return this.intUnitIdTo;
            }
            set
            {
                this.intUnitIdTo = value;
            }
        }

        public int UnitToCenterId
        {
            get
            {
                return this.intUnitToCenterId;
            }
            set
            {
                this.intUnitToCenterId = value;
            }
        }

        public double ValueFrom
        {
            get
            {
                return this.dblValueFrom;
            }
            set
            {
                this.dblValueFrom = value;
            }
        }

        public double ValueTo
        {
            get
            {
                return this.dblValueTo;
            }
            set
            {
                this.dblValueTo = value;
            }
        }

        public SET_UNIT_CONVERSION_DAO()
        {
        }
    }
}
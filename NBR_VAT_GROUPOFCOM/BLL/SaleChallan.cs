using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;



namespace NBR_VAT_GROUPOFCOM.BLL
{

    [DesignerCategory("code")]
    [HelpKeyword("vs.data.DataSet")]
    [Serializable]
    [ToolboxItem(true)]
    [XmlRoot("SaleChallan")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class SaleChallan : DataSet
    {
        private SaleChallan.dtSaleChallanDataTable tabledtSaleChallan;

        private SaleChallan.dtSaleReportDataTable tabledtSaleReport;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public SaleChallan.dtSaleChallanDataTable dtSaleChallan
        {
            get
            {
                return this.tabledtSaleChallan;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public SaleChallan.dtSaleReportDataTable dtSaleReport
        {
            get
            {
                return this.tabledtSaleReport;
            }
        }

        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public new DataRelationCollection Relations
        {
            get
            {
                return base.Relations;
            }
        }

        [Browsable(true)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override SchemaSerializationMode SchemaSerializationMode
        {
            get
            {
                return this._schemaSerializationMode;
            }
            set
            {
                this._schemaSerializationMode = value;
            }
        }

        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public new DataTableCollection Tables
        {
            get
            {
                return base.Tables;
            }
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public SaleChallan()
        {
            base.BeginInit();
            this.InitClass();
            CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += collectionChangeEventHandler;
            base.Relations.CollectionChanged += collectionChangeEventHandler;
            base.EndInit();
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected SaleChallan(SerializationInfo info, StreamingContext context) : base(info, context, false)
        {
            if (base.IsBinarySerialized(info, context))
            {
                this.InitVars(false);
                CollectionChangeEventHandler collectionChangeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += collectionChangeEventHandler;
                this.Relations.CollectionChanged += collectionChangeEventHandler;
                return;
            }
            string value = (string)info.GetValue("XmlSchema", typeof(string));
            if (base.DetermineSchemaSerializationMode(info, context) != SchemaSerializationMode.IncludeSchema)
            {
                base.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
            }
            else
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXmlSchema(new XmlTextReader(new StringReader(value)));
                if (dataSet.Tables["dtSaleChallan"] != null)
                {
                    base.Tables.Add(new SaleChallan.dtSaleChallanDataTable(dataSet.Tables["dtSaleChallan"]));
                }
                if (dataSet.Tables["dtSaleReport"] != null)
                {
                    base.Tables.Add(new SaleChallan.dtSaleReportDataTable(dataSet.Tables["dtSaleReport"]));
                }
                base.DataSetName = dataSet.DataSetName;
                base.Prefix = dataSet.Prefix;
                base.Namespace = dataSet.Namespace;
                base.Locale = dataSet.Locale;
                base.CaseSensitive = dataSet.CaseSensitive;
                base.EnforceConstraints = dataSet.EnforceConstraints;
                base.Merge(dataSet, false, MissingSchemaAction.Add);
                this.InitVars();
            }
            base.GetSerializationData(info, context);
            CollectionChangeEventHandler collectionChangeEventHandler1 = new CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += collectionChangeEventHandler1;
            this.Relations.CollectionChanged += collectionChangeEventHandler1;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public override DataSet Clone()
        {
            SaleChallan schemaSerializationMode = (SaleChallan)base.Clone();
            schemaSerializationMode.InitVars();
            schemaSerializationMode.SchemaSerializationMode = this.SchemaSerializationMode;
            return schemaSerializationMode;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override XmlSchema GetSchemaSerializable()
        {
            MemoryStream memoryStream = new MemoryStream();
            base.WriteXmlSchema(new XmlTextWriter(memoryStream, null));
            memoryStream.Position = (long)0;
            return XmlSchema.Read(new XmlTextReader(memoryStream), null);
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
        {
            XmlSchemaComplexType xmlSchemaComplexType;
            XmlSchema xmlSchema;
            SaleChallan saleChallan = new SaleChallan();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = saleChallan.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = saleChallan.GetSchemaSerializable();
            if (xs.Contains(schemaSerializable.TargetNamespace))
            {
                MemoryStream memoryStream = new MemoryStream();
                MemoryStream memoryStream1 = new MemoryStream();
                try
                {
                    XmlSchema current = null;
                    schemaSerializable.Write(memoryStream);
                    IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        current = (XmlSchema)enumerator.Current;
                        memoryStream1.SetLength((long)0);
                        current.Write(memoryStream1);
                        if (memoryStream.Length != memoryStream1.Length)
                        {
                            continue;
                        }
                        memoryStream.Position = (long)0;
                        memoryStream1.Position = (long)0;
                        while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
                        {
                        }
                        if (memoryStream.Position != memoryStream.Length)
                        {
                            continue;
                        }
                        xmlSchemaComplexType = xmlSchemaComplexType1;
                        return xmlSchemaComplexType;
                    }
                    xmlSchema = xs.Add(schemaSerializable);
                    return xmlSchemaComplexType1;
                }
                finally
                {
                    if (memoryStream != null)
                    {
                        memoryStream.Close();
                    }
                    if (memoryStream1 != null)
                    {
                        memoryStream1.Close();
                    }
                }
                return xmlSchemaComplexType;
            }
            xmlSchema = xs.Add(schemaSerializable);
            return xmlSchemaComplexType1;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void InitClass()
        {
            base.DataSetName = "SaleChallan";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/SaleChallan.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tabledtSaleChallan = new SaleChallan.dtSaleChallanDataTable();
            base.Tables.Add(this.tabledtSaleChallan);
            this.tabledtSaleReport = new SaleChallan.dtSaleReportDataTable();
            base.Tables.Add(this.tabledtSaleReport);
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void InitializeDerivedDataSet()
        {
            base.BeginInit();
            this.InitClass();
            base.EndInit();
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars()
        {
            this.InitVars(true);
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        internal void InitVars(bool initTable)
        {
            this.tabledtSaleChallan = (SaleChallan.dtSaleChallanDataTable)base.Tables["dtSaleChallan"];
            if (initTable && this.tabledtSaleChallan != null)
            {
                this.tabledtSaleChallan.InitVars();
            }
            this.tabledtSaleReport = (SaleChallan.dtSaleReportDataTable)base.Tables["dtSaleReport"];
            if (initTable && this.tabledtSaleReport != null)
            {
                this.tabledtSaleReport.InitVars();
            }
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override void ReadXmlSerializable(XmlReader reader)
        {
            if (base.DetermineSchemaSerializationMode(reader) != SchemaSerializationMode.IncludeSchema)
            {
                base.ReadXml(reader);
                this.InitVars();
                return;
            }
            this.Reset();
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(reader);
            if (dataSet.Tables["dtSaleChallan"] != null)
            {
                base.Tables.Add(new SaleChallan.dtSaleChallanDataTable(dataSet.Tables["dtSaleChallan"]));
            }
            if (dataSet.Tables["dtSaleReport"] != null)
            {
                base.Tables.Add(new SaleChallan.dtSaleReportDataTable(dataSet.Tables["dtSaleReport"]));
            }
            base.DataSetName = dataSet.DataSetName;
            base.Prefix = dataSet.Prefix;
            base.Namespace = dataSet.Namespace;
            base.Locale = dataSet.Locale;
            base.CaseSensitive = dataSet.CaseSensitive;
            base.EnforceConstraints = dataSet.EnforceConstraints;
            base.Merge(dataSet, false, MissingSchemaAction.Add);
            this.InitVars();
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private void SchemaChanged(object sender, CollectionChangeEventArgs e)
        {
            if (e.Action == CollectionChangeAction.Remove)
            {
                this.InitVars();
            }
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializedtSaleChallan()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializedtSaleReport()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class dtSaleChallanDataTable : TypedTableBase<SaleChallan.dtSaleChallanRow>
        {
            private DataColumn columnTRANS_TYPE;

            private DataColumn columnCHALLAN_ID;

            private DataColumn columnDATE_CHALLAN;

            private DataColumn columnITEM_ID;

            private DataColumn columnITEM_NAME;

            private DataColumn columnOPENING_STOCK;

            private DataColumn columnTOTAL_OPENING_PRICE;

            private DataColumn columnQUANTITY;

            private DataColumn columnUNIT_PRICE;

            private DataColumn columnTOTAL_PRICE;

            private DataColumn columnTOTAL_SD;

            private DataColumn columnTOTAL_VAT;

            private DataColumn columnSALE_PARTY_NAME;

            private DataColumn columnPARTY_TIN;

            private DataColumn columnPARTY_ADDRESS;

            private DataColumn columnCHALLAN_NO;

            private DataColumn columnSALE_QTY;

            private DataColumn columnTOTAL_SALE_PRICE;

            private DataColumn columnUNIT_CODE;

            private DataColumn columnREMARKS;

            private DataColumn columnTOTAL_PURCHASE_PRICE;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CHALLAN_IDColumn
            {
                get
                {
                    return this.columnCHALLAN_ID;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn CHALLAN_NOColumn
            {
                get
                {
                    return this.columnCHALLAN_NO;
                }
            }

            [Browsable(false)]
            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DATE_CHALLANColumn
            {
                get
                {
                    return this.columnDATE_CHALLAN;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleChallanRow this[int index]
            {
                get
                {
                    return (SaleChallan.dtSaleChallanRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ITEM_IDColumn
            {
                get
                {
                    return this.columnITEM_ID;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ITEM_NAMEColumn
            {
                get
                {
                    return this.columnITEM_NAME;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn OPENING_STOCKColumn
            {
                get
                {
                    return this.columnOPENING_STOCK;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PARTY_ADDRESSColumn
            {
                get
                {
                    return this.columnPARTY_ADDRESS;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PARTY_TINColumn
            {
                get
                {
                    return this.columnPARTY_TIN;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn QUANTITYColumn
            {
                get
                {
                    return this.columnQUANTITY;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn REMARKSColumn
            {
                get
                {
                    return this.columnREMARKS;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SALE_PARTY_NAMEColumn
            {
                get
                {
                    return this.columnSALE_PARTY_NAME;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SALE_QTYColumn
            {
                get
                {
                    return this.columnSALE_QTY;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_OPENING_PRICEColumn
            {
                get
                {
                    return this.columnTOTAL_OPENING_PRICE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_PRICEColumn
            {
                get
                {
                    return this.columnTOTAL_PRICE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_PURCHASE_PRICEColumn
            {
                get
                {
                    return this.columnTOTAL_PURCHASE_PRICE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_SALE_PRICEColumn
            {
                get
                {
                    return this.columnTOTAL_SALE_PRICE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_SDColumn
            {
                get
                {
                    return this.columnTOTAL_SD;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_VATColumn
            {
                get
                {
                    return this.columnTOTAL_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TRANS_TYPEColumn
            {
                get
                {
                    return this.columnTRANS_TYPE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UNIT_CODEColumn
            {
                get
                {
                    return this.columnUNIT_CODE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UNIT_PRICEColumn
            {
                get
                {
                    return this.columnUNIT_PRICE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtSaleChallanDataTable()
            {
                base.TableName = "dtSaleChallan";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtSaleChallanDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected dtSaleChallanDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AdddtSaleChallanRow(SaleChallan.dtSaleChallanRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleChallanRow AdddtSaleChallanRow(string TRANS_TYPE, int CHALLAN_ID, DateTime DATE_CHALLAN, int ITEM_ID, string ITEM_NAME, double OPENING_STOCK, double TOTAL_OPENING_PRICE, double QUANTITY, double UNIT_PRICE, double TOTAL_PRICE, double TOTAL_SD, double TOTAL_VAT, string SALE_PARTY_NAME, string PARTY_TIN, string PARTY_ADDRESS, string CHALLAN_NO, double SALE_QTY, double TOTAL_SALE_PRICE, string UNIT_CODE, string REMARKS, string TOTAL_PURCHASE_PRICE)
            {
                SaleChallan.dtSaleChallanRow _dtSaleChallanRow = (SaleChallan.dtSaleChallanRow)base.NewRow();
                object[] tRANSTYPE = new object[] { TRANS_TYPE, CHALLAN_ID, DATE_CHALLAN, ITEM_ID, ITEM_NAME, OPENING_STOCK, TOTAL_OPENING_PRICE, QUANTITY, UNIT_PRICE, TOTAL_PRICE, TOTAL_SD, TOTAL_VAT, SALE_PARTY_NAME, PARTY_TIN, PARTY_ADDRESS, CHALLAN_NO, SALE_QTY, TOTAL_SALE_PRICE, UNIT_CODE, REMARKS, TOTAL_PURCHASE_PRICE };
                _dtSaleChallanRow.ItemArray = tRANSTYPE;
                base.Rows.Add(_dtSaleChallanRow);
                return _dtSaleChallanRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                SaleChallan.dtSaleChallanDataTable _dtSaleChallanDataTable = (SaleChallan.dtSaleChallanDataTable)base.Clone();
                _dtSaleChallanDataTable.InitVars();
                return _dtSaleChallanDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new SaleChallan.dtSaleChallanDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(SaleChallan.dtSaleChallanRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                SaleChallan saleChallan = new SaleChallan();
                XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = new decimal(0),
                    MaxOccurs = new decimal(-1, -1, -1, false, 0),
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                xmlSchemaSequence.Items.Add(xmlSchemaAny);
                XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = new decimal(1),
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                xmlSchemaSequence.Items.Add(xmlSchemaAny1);
                XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
                {
                    Name = "namespace",
                    FixedValue = saleChallan.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "dtSaleChallanDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = saleChallan.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    MemoryStream memoryStream1 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(memoryStream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            memoryStream1.SetLength((long)0);
                            current.Write(memoryStream1);
                            if (memoryStream.Length != memoryStream1.Length)
                            {
                                continue;
                            }
                            memoryStream.Position = (long)0;
                            memoryStream1.Position = (long)0;
                            while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
                            {
                            }
                            if (memoryStream.Position != memoryStream.Length)
                            {
                                continue;
                            }
                            xmlSchemaComplexType = xmlSchemaComplexType1;
                            return xmlSchemaComplexType;
                        }
                        xmlSchema = xs.Add(schemaSerializable);
                        return xmlSchemaComplexType1;
                    }
                    finally
                    {
                        if (memoryStream != null)
                        {
                            memoryStream.Close();
                        }
                        if (memoryStream1 != null)
                        {
                            memoryStream1.Close();
                        }
                    }
                    return xmlSchemaComplexType;
                }
                xmlSchema = xs.Add(schemaSerializable);
                return xmlSchemaComplexType1;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnTRANS_TYPE = new DataColumn("TRANS_TYPE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTRANS_TYPE);
                this.columnCHALLAN_ID = new DataColumn("CHALLAN_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnCHALLAN_ID);
                this.columnDATE_CHALLAN = new DataColumn("DATE_CHALLAN", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATE_CHALLAN);
                this.columnITEM_ID = new DataColumn("ITEM_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnITEM_ID);
                this.columnITEM_NAME = new DataColumn("ITEM_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnITEM_NAME);
                this.columnOPENING_STOCK = new DataColumn("OPENING_STOCK", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnOPENING_STOCK);
                this.columnTOTAL_OPENING_PRICE = new DataColumn("TOTAL_OPENING_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_OPENING_PRICE);
                this.columnQUANTITY = new DataColumn("QUANTITY", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnQUANTITY);
                this.columnUNIT_PRICE = new DataColumn("UNIT_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnUNIT_PRICE);
                this.columnTOTAL_PRICE = new DataColumn("TOTAL_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_PRICE);
                this.columnTOTAL_SD = new DataColumn("TOTAL_SD", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_SD);
                this.columnTOTAL_VAT = new DataColumn("TOTAL_VAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_VAT);
                this.columnSALE_PARTY_NAME = new DataColumn("SALE_PARTY_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSALE_PARTY_NAME);
                this.columnPARTY_TIN = new DataColumn("PARTY_TIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPARTY_TIN);
                this.columnPARTY_ADDRESS = new DataColumn("PARTY_ADDRESS", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPARTY_ADDRESS);
                this.columnCHALLAN_NO = new DataColumn("CHALLAN_NO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCHALLAN_NO);
                this.columnSALE_QTY = new DataColumn("SALE_QTY", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnSALE_QTY);
                this.columnTOTAL_SALE_PRICE = new DataColumn("TOTAL_SALE_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_SALE_PRICE);
                this.columnUNIT_CODE = new DataColumn("UNIT_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUNIT_CODE);
                this.columnREMARKS = new DataColumn("REMARKS", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnREMARKS);
                this.columnTOTAL_PURCHASE_PRICE = new DataColumn("TOTAL_PURCHASE_PRICE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_PURCHASE_PRICE);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnTRANS_TYPE = base.Columns["TRANS_TYPE"];
                this.columnCHALLAN_ID = base.Columns["CHALLAN_ID"];
                this.columnDATE_CHALLAN = base.Columns["DATE_CHALLAN"];
                this.columnITEM_ID = base.Columns["ITEM_ID"];
                this.columnITEM_NAME = base.Columns["ITEM_NAME"];
                this.columnOPENING_STOCK = base.Columns["OPENING_STOCK"];
                this.columnTOTAL_OPENING_PRICE = base.Columns["TOTAL_OPENING_PRICE"];
                this.columnQUANTITY = base.Columns["QUANTITY"];
                this.columnUNIT_PRICE = base.Columns["UNIT_PRICE"];
                this.columnTOTAL_PRICE = base.Columns["TOTAL_PRICE"];
                this.columnTOTAL_SD = base.Columns["TOTAL_SD"];
                this.columnTOTAL_VAT = base.Columns["TOTAL_VAT"];
                this.columnSALE_PARTY_NAME = base.Columns["SALE_PARTY_NAME"];
                this.columnPARTY_TIN = base.Columns["PARTY_TIN"];
                this.columnPARTY_ADDRESS = base.Columns["PARTY_ADDRESS"];
                this.columnCHALLAN_NO = base.Columns["CHALLAN_NO"];
                this.columnSALE_QTY = base.Columns["SALE_QTY"];
                this.columnTOTAL_SALE_PRICE = base.Columns["TOTAL_SALE_PRICE"];
                this.columnUNIT_CODE = base.Columns["UNIT_CODE"];
                this.columnREMARKS = base.Columns["REMARKS"];
                this.columnTOTAL_PURCHASE_PRICE = base.Columns["TOTAL_PURCHASE_PRICE"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleChallanRow NewdtSaleChallanRow()
            {
                return (SaleChallan.dtSaleChallanRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SaleChallan.dtSaleChallanRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtSaleChallanRowChanged != null)
                {
                    this.dtSaleChallanRowChanged(this, new SaleChallan.dtSaleChallanRowChangeEvent((SaleChallan.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtSaleChallanRowChanging != null)
                {
                    this.dtSaleChallanRowChanging(this, new SaleChallan.dtSaleChallanRowChangeEvent((SaleChallan.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtSaleChallanRowDeleted != null)
                {
                    this.dtSaleChallanRowDeleted(this, new SaleChallan.dtSaleChallanRowChangeEvent((SaleChallan.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtSaleChallanRowDeleting != null)
                {
                    this.dtSaleChallanRowDeleting(this, new SaleChallan.dtSaleChallanRowChangeEvent((SaleChallan.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtSaleChallanRow(SaleChallan.dtSaleChallanRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleChallanRowChangeEventHandler dtSaleChallanRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleChallanRowChangeEventHandler dtSaleChallanRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleChallanRowChangeEventHandler dtSaleChallanRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleChallanRowChangeEventHandler dtSaleChallanRowDeleting;
        }

        public class dtSaleChallanRow : DataRow
        {
            private SaleChallan.dtSaleChallanDataTable tabledtSaleChallan;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int CHALLAN_ID
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tabledtSaleChallan.CHALLAN_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'CHALLAN_ID' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.CHALLAN_IDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string CHALLAN_NO
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.CHALLAN_NOColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'CHALLAN_NO' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.CHALLAN_NOColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime DATE_CHALLAN
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tabledtSaleChallan.DATE_CHALLANColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'DATE_CHALLAN' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.DATE_CHALLANColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ITEM_ID
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tabledtSaleChallan.ITEM_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ITEM_ID' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.ITEM_IDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ITEM_NAME
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.ITEM_NAMEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ITEM_NAME' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.ITEM_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double OPENING_STOCK
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.OPENING_STOCKColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OPENING_STOCK' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.OPENING_STOCKColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PARTY_ADDRESS
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.PARTY_ADDRESSColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PARTY_ADDRESS' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.PARTY_ADDRESSColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PARTY_TIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.PARTY_TINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PARTY_TIN' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.PARTY_TINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double QUANTITY
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.QUANTITYColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'QUANTITY' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.QUANTITYColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string REMARKS
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.REMARKSColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'REMARKS' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.REMARKSColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SALE_PARTY_NAME
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.SALE_PARTY_NAMEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SALE_PARTY_NAME' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.SALE_PARTY_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double SALE_QTY
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.SALE_QTYColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SALE_QTY' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.SALE_QTYColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_OPENING_PRICE
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.TOTAL_OPENING_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_OPENING_PRICE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TOTAL_OPENING_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_PRICE
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.TOTAL_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_PRICE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TOTAL_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TOTAL_PURCHASE_PRICE
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.TOTAL_PURCHASE_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_PURCHASE_PRICE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TOTAL_PURCHASE_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_SALE_PRICE
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.TOTAL_SALE_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_SALE_PRICE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TOTAL_SALE_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_SD
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.TOTAL_SDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_SD' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TOTAL_SDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_VAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.TOTAL_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_VAT' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TOTAL_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TRANS_TYPE
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.TRANS_TYPEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TRANS_TYPE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.TRANS_TYPEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string UNIT_CODE
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.UNIT_CODEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_CODE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.UNIT_CODEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double UNIT_PRICE
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.UNIT_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_PRICE' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.UNIT_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtSaleChallanRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledtSaleChallan = (SaleChallan.dtSaleChallanDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCHALLAN_IDNull()
            {
                return base.IsNull(this.tabledtSaleChallan.CHALLAN_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCHALLAN_NONull()
            {
                return base.IsNull(this.tabledtSaleChallan.CHALLAN_NOColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDATE_CHALLANNull()
            {
                return base.IsNull(this.tabledtSaleChallan.DATE_CHALLANColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsITEM_IDNull()
            {
                return base.IsNull(this.tabledtSaleChallan.ITEM_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsITEM_NAMENull()
            {
                return base.IsNull(this.tabledtSaleChallan.ITEM_NAMEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOPENING_STOCKNull()
            {
                return base.IsNull(this.tabledtSaleChallan.OPENING_STOCKColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPARTY_ADDRESSNull()
            {
                return base.IsNull(this.tabledtSaleChallan.PARTY_ADDRESSColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPARTY_TINNull()
            {
                return base.IsNull(this.tabledtSaleChallan.PARTY_TINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQUANTITYNull()
            {
                return base.IsNull(this.tabledtSaleChallan.QUANTITYColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsREMARKSNull()
            {
                return base.IsNull(this.tabledtSaleChallan.REMARKSColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSALE_PARTY_NAMENull()
            {
                return base.IsNull(this.tabledtSaleChallan.SALE_PARTY_NAMEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSALE_QTYNull()
            {
                return base.IsNull(this.tabledtSaleChallan.SALE_QTYColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_OPENING_PRICENull()
            {
                return base.IsNull(this.tabledtSaleChallan.TOTAL_OPENING_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_PRICENull()
            {
                return base.IsNull(this.tabledtSaleChallan.TOTAL_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_PURCHASE_PRICENull()
            {
                return base.IsNull(this.tabledtSaleChallan.TOTAL_PURCHASE_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_SALE_PRICENull()
            {
                return base.IsNull(this.tabledtSaleChallan.TOTAL_SALE_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_SDNull()
            {
                return base.IsNull(this.tabledtSaleChallan.TOTAL_SDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_VATNull()
            {
                return base.IsNull(this.tabledtSaleChallan.TOTAL_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTRANS_TYPENull()
            {
                return base.IsNull(this.tabledtSaleChallan.TRANS_TYPEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_CODENull()
            {
                return base.IsNull(this.tabledtSaleChallan.UNIT_CODEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_PRICENull()
            {
                return base.IsNull(this.tabledtSaleChallan.UNIT_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCHALLAN_IDNull()
            {
                base[this.tabledtSaleChallan.CHALLAN_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCHALLAN_NONull()
            {
                base[this.tabledtSaleChallan.CHALLAN_NOColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDATE_CHALLANNull()
            {
                base[this.tabledtSaleChallan.DATE_CHALLANColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetITEM_IDNull()
            {
                base[this.tabledtSaleChallan.ITEM_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetITEM_NAMENull()
            {
                base[this.tabledtSaleChallan.ITEM_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOPENING_STOCKNull()
            {
                base[this.tabledtSaleChallan.OPENING_STOCKColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPARTY_ADDRESSNull()
            {
                base[this.tabledtSaleChallan.PARTY_ADDRESSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPARTY_TINNull()
            {
                base[this.tabledtSaleChallan.PARTY_TINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQUANTITYNull()
            {
                base[this.tabledtSaleChallan.QUANTITYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetREMARKSNull()
            {
                base[this.tabledtSaleChallan.REMARKSColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSALE_PARTY_NAMENull()
            {
                base[this.tabledtSaleChallan.SALE_PARTY_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSALE_QTYNull()
            {
                base[this.tabledtSaleChallan.SALE_QTYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_OPENING_PRICENull()
            {
                base[this.tabledtSaleChallan.TOTAL_OPENING_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_PRICENull()
            {
                base[this.tabledtSaleChallan.TOTAL_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_PURCHASE_PRICENull()
            {
                base[this.tabledtSaleChallan.TOTAL_PURCHASE_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_SALE_PRICENull()
            {
                base[this.tabledtSaleChallan.TOTAL_SALE_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_SDNull()
            {
                base[this.tabledtSaleChallan.TOTAL_SDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_VATNull()
            {
                base[this.tabledtSaleChallan.TOTAL_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTRANS_TYPENull()
            {
                base[this.tabledtSaleChallan.TRANS_TYPEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_CODENull()
            {
                base[this.tabledtSaleChallan.UNIT_CODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_PRICENull()
            {
                base[this.tabledtSaleChallan.UNIT_PRICEColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class dtSaleChallanRowChangeEvent : EventArgs
        {
            private SaleChallan.dtSaleChallanRow eventRow;

            private DataRowAction eventAction;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleChallanRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtSaleChallanRowChangeEvent(SaleChallan.dtSaleChallanRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtSaleChallanRowChangeEventHandler(object sender, SaleChallan.dtSaleChallanRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class dtSaleReportDataTable : TypedTableBase<SaleChallan.dtSaleReportRow>
        {
            private DataColumn columnITEM_ID;

            private DataColumn columnITEM_NAME;

            private DataColumn columnUNIT_ID;

            private DataColumn columnUNIT_CODE;

            private DataColumn columnQUANTITY;

            private DataColumn columnTOTAL_PRICE;

            private DataColumn columnTOTAL_SD;

            private DataColumn columnTOTAL_VAT;

            private DataColumn columnTOTAL_PRICE_WITH_SD_VAT;

            [Browsable(false)]
            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Count
            {
                get
                {
                    return base.Rows.Count;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleReportRow this[int index]
            {
                get
                {
                    return (SaleChallan.dtSaleReportRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ITEM_IDColumn
            {
                get
                {
                    return this.columnITEM_ID;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ITEM_NAMEColumn
            {
                get
                {
                    return this.columnITEM_NAME;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn QUANTITYColumn
            {
                get
                {
                    return this.columnQUANTITY;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_PRICE_WITH_SD_VATColumn
            {
                get
                {
                    return this.columnTOTAL_PRICE_WITH_SD_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_PRICEColumn
            {
                get
                {
                    return this.columnTOTAL_PRICE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_SDColumn
            {
                get
                {
                    return this.columnTOTAL_SD;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_VATColumn
            {
                get
                {
                    return this.columnTOTAL_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UNIT_CODEColumn
            {
                get
                {
                    return this.columnUNIT_CODE;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn UNIT_IDColumn
            {
                get
                {
                    return this.columnUNIT_ID;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtSaleReportDataTable()
            {
                base.TableName = "dtSaleReport";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtSaleReportDataTable(DataTable table)
            {
                base.TableName = table.TableName;
                if (table.CaseSensitive != table.DataSet.CaseSensitive)
                {
                    base.CaseSensitive = table.CaseSensitive;
                }
                if (table.Locale.ToString() != table.DataSet.Locale.ToString())
                {
                    base.Locale = table.Locale;
                }
                if (table.Namespace != table.DataSet.Namespace)
                {
                    base.Namespace = table.Namespace;
                }
                base.Prefix = table.Prefix;
                base.MinimumCapacity = table.MinimumCapacity;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected dtSaleReportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AdddtSaleReportRow(SaleChallan.dtSaleReportRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleReportRow AdddtSaleReportRow(int ITEM_ID, string ITEM_NAME, short UNIT_ID, string UNIT_CODE, double QUANTITY, double TOTAL_PRICE, double TOTAL_SD, double TOTAL_VAT, double TOTAL_PRICE_WITH_SD_VAT)
            {
                SaleChallan.dtSaleReportRow _dtSaleReportRow = (SaleChallan.dtSaleReportRow)base.NewRow();
                object[] tEMID = new object[] { ITEM_ID, ITEM_NAME, UNIT_ID, UNIT_CODE, QUANTITY, TOTAL_PRICE, TOTAL_SD, TOTAL_VAT, TOTAL_PRICE_WITH_SD_VAT };
                _dtSaleReportRow.ItemArray = tEMID;
                base.Rows.Add(_dtSaleReportRow);
                return _dtSaleReportRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                SaleChallan.dtSaleReportDataTable _dtSaleReportDataTable = (SaleChallan.dtSaleReportDataTable)base.Clone();
                _dtSaleReportDataTable.InitVars();
                return _dtSaleReportDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new SaleChallan.dtSaleReportDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(SaleChallan.dtSaleReportRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                SaleChallan saleChallan = new SaleChallan();
                XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
                {
                    Namespace = "http://www.w3.org/2001/XMLSchema",
                    MinOccurs = new decimal(0),
                    MaxOccurs = new decimal(-1, -1, -1, false, 0),
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                xmlSchemaSequence.Items.Add(xmlSchemaAny);
                XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny()
                {
                    Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1",
                    MinOccurs = new decimal(1),
                    ProcessContents = XmlSchemaContentProcessing.Lax
                };
                xmlSchemaSequence.Items.Add(xmlSchemaAny1);
                XmlSchemaAttribute xmlSchemaAttribute = new XmlSchemaAttribute()
                {
                    Name = "namespace",
                    FixedValue = saleChallan.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "dtSaleReportDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = saleChallan.GetSchemaSerializable();
                if (xs.Contains(schemaSerializable.TargetNamespace))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    MemoryStream memoryStream1 = new MemoryStream();
                    try
                    {
                        XmlSchema current = null;
                        schemaSerializable.Write(memoryStream);
                        IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
                        while (enumerator.MoveNext())
                        {
                            current = (XmlSchema)enumerator.Current;
                            memoryStream1.SetLength((long)0);
                            current.Write(memoryStream1);
                            if (memoryStream.Length != memoryStream1.Length)
                            {
                                continue;
                            }
                            memoryStream.Position = (long)0;
                            memoryStream1.Position = (long)0;
                            while (memoryStream.Position != memoryStream.Length && memoryStream.ReadByte() == memoryStream1.ReadByte())
                            {
                            }
                            if (memoryStream.Position != memoryStream.Length)
                            {
                                continue;
                            }
                            xmlSchemaComplexType = xmlSchemaComplexType1;
                            return xmlSchemaComplexType;
                        }
                        xmlSchema = xs.Add(schemaSerializable);
                        return xmlSchemaComplexType1;
                    }
                    finally
                    {
                        if (memoryStream != null)
                        {
                            memoryStream.Close();
                        }
                        if (memoryStream1 != null)
                        {
                            memoryStream1.Close();
                        }
                    }
                    return xmlSchemaComplexType;
                }
                xmlSchema = xs.Add(schemaSerializable);
                return xmlSchemaComplexType1;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            private void InitClass()
            {
                this.columnITEM_ID = new DataColumn("ITEM_ID", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnITEM_ID);
                this.columnITEM_NAME = new DataColumn("ITEM_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnITEM_NAME);
                this.columnUNIT_ID = new DataColumn("UNIT_ID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnUNIT_ID);
                this.columnUNIT_CODE = new DataColumn("UNIT_CODE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnUNIT_CODE);
                this.columnQUANTITY = new DataColumn("QUANTITY", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnQUANTITY);
                this.columnTOTAL_PRICE = new DataColumn("TOTAL_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_PRICE);
                this.columnTOTAL_SD = new DataColumn("TOTAL_SD", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_SD);
                this.columnTOTAL_VAT = new DataColumn("TOTAL_VAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_VAT);
                this.columnTOTAL_PRICE_WITH_SD_VAT = new DataColumn("TOTAL_PRICE_WITH_SD_VAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_PRICE_WITH_SD_VAT);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnITEM_ID = base.Columns["ITEM_ID"];
                this.columnITEM_NAME = base.Columns["ITEM_NAME"];
                this.columnUNIT_ID = base.Columns["UNIT_ID"];
                this.columnUNIT_CODE = base.Columns["UNIT_CODE"];
                this.columnQUANTITY = base.Columns["QUANTITY"];
                this.columnTOTAL_PRICE = base.Columns["TOTAL_PRICE"];
                this.columnTOTAL_SD = base.Columns["TOTAL_SD"];
                this.columnTOTAL_VAT = base.Columns["TOTAL_VAT"];
                this.columnTOTAL_PRICE_WITH_SD_VAT = base.Columns["TOTAL_PRICE_WITH_SD_VAT"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleReportRow NewdtSaleReportRow()
            {
                return (SaleChallan.dtSaleReportRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SaleChallan.dtSaleReportRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtSaleReportRowChanged != null)
                {
                    this.dtSaleReportRowChanged(this, new SaleChallan.dtSaleReportRowChangeEvent((SaleChallan.dtSaleReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtSaleReportRowChanging != null)
                {
                    this.dtSaleReportRowChanging(this, new SaleChallan.dtSaleReportRowChangeEvent((SaleChallan.dtSaleReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtSaleReportRowDeleted != null)
                {
                    this.dtSaleReportRowDeleted(this, new SaleChallan.dtSaleReportRowChangeEvent((SaleChallan.dtSaleReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtSaleReportRowDeleting != null)
                {
                    this.dtSaleReportRowDeleting(this, new SaleChallan.dtSaleReportRowChangeEvent((SaleChallan.dtSaleReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtSaleReportRow(SaleChallan.dtSaleReportRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleReportRowChangeEventHandler dtSaleReportRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleReportRowChangeEventHandler dtSaleReportRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleReportRowChangeEventHandler dtSaleReportRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleChallan.dtSaleReportRowChangeEventHandler dtSaleReportRowDeleting;
        }

        public class dtSaleReportRow : DataRow
        {
            private SaleChallan.dtSaleReportDataTable tabledtSaleReport;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int ITEM_ID
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tabledtSaleReport.ITEM_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ITEM_ID' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.ITEM_IDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ITEM_NAME
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleReport.ITEM_NAMEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ITEM_NAME' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.ITEM_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double QUANTITY
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleReport.QUANTITYColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'QUANTITY' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.QUANTITYColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_PRICE
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleReport.TOTAL_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_PRICE' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.TOTAL_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_PRICE_WITH_SD_VAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleReport.TOTAL_PRICE_WITH_SD_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_PRICE_WITH_SD_VAT' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.TOTAL_PRICE_WITH_SD_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_SD
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleReport.TOTAL_SDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_SD' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.TOTAL_SDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_VAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleReport.TOTAL_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_VAT' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.TOTAL_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string UNIT_CODE
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleReport.UNIT_CODEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_CODE' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.UNIT_CODEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short UNIT_ID
            {
                get
                {
                    short item;
                    try
                    {
                        item = (short)base[this.tabledtSaleReport.UNIT_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_ID' in table 'dtSaleReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleReport.UNIT_IDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtSaleReportRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledtSaleReport = (SaleChallan.dtSaleReportDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsITEM_IDNull()
            {
                return base.IsNull(this.tabledtSaleReport.ITEM_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsITEM_NAMENull()
            {
                return base.IsNull(this.tabledtSaleReport.ITEM_NAMEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQUANTITYNull()
            {
                return base.IsNull(this.tabledtSaleReport.QUANTITYColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_PRICE_WITH_SD_VATNull()
            {
                return base.IsNull(this.tabledtSaleReport.TOTAL_PRICE_WITH_SD_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_PRICENull()
            {
                return base.IsNull(this.tabledtSaleReport.TOTAL_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_SDNull()
            {
                return base.IsNull(this.tabledtSaleReport.TOTAL_SDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_VATNull()
            {
                return base.IsNull(this.tabledtSaleReport.TOTAL_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_CODENull()
            {
                return base.IsNull(this.tabledtSaleReport.UNIT_CODEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_IDNull()
            {
                return base.IsNull(this.tabledtSaleReport.UNIT_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetITEM_IDNull()
            {
                base[this.tabledtSaleReport.ITEM_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetITEM_NAMENull()
            {
                base[this.tabledtSaleReport.ITEM_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQUANTITYNull()
            {
                base[this.tabledtSaleReport.QUANTITYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_PRICE_WITH_SD_VATNull()
            {
                base[this.tabledtSaleReport.TOTAL_PRICE_WITH_SD_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_PRICENull()
            {
                base[this.tabledtSaleReport.TOTAL_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_SDNull()
            {
                base[this.tabledtSaleReport.TOTAL_SDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_VATNull()
            {
                base[this.tabledtSaleReport.TOTAL_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_CODENull()
            {
                base[this.tabledtSaleReport.UNIT_CODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_IDNull()
            {
                base[this.tabledtSaleReport.UNIT_IDColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class dtSaleReportRowChangeEvent : EventArgs
        {
            private SaleChallan.dtSaleReportRow eventRow;

            private DataRowAction eventAction;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataRowAction Action
            {
                get
                {
                    return this.eventAction;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleChallan.dtSaleReportRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtSaleReportRowChangeEvent(SaleChallan.dtSaleReportRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtSaleReportRowChangeEventHandler(object sender, SaleChallan.dtSaleReportRowChangeEvent e);
    }
}




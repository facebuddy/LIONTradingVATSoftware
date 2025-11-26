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
    [XmlRoot("PurchaseChallan")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class PurchaseChallan : DataSet
    {
        private PurchaseChallan.dtPurchaseReportDataTable tabledtPurchaseReport;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public PurchaseChallan.dtPurchaseReportDataTable dtPurchaseReport
        {
            get
            {
                return this.tabledtPurchaseReport;
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
        public PurchaseChallan()
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
        protected PurchaseChallan(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["dtPurchaseReport"] != null)
                {
                    base.Tables.Add(new PurchaseChallan.dtPurchaseReportDataTable(dataSet.Tables["dtPurchaseReport"]));
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
            PurchaseChallan schemaSerializationMode = (PurchaseChallan)base.Clone();
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
            PurchaseChallan purchaseChallan = new PurchaseChallan();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = purchaseChallan.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = purchaseChallan.GetSchemaSerializable();
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
            base.DataSetName = "PurchaseChallan";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/PurchaseChallan.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tabledtPurchaseReport = new PurchaseChallan.dtPurchaseReportDataTable();
            base.Tables.Add(this.tabledtPurchaseReport);
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
            this.tabledtPurchaseReport = (PurchaseChallan.dtPurchaseReportDataTable)base.Tables["dtPurchaseReport"];
            if (initTable && this.tabledtPurchaseReport != null)
            {
                this.tabledtPurchaseReport.InitVars();
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
            if (dataSet.Tables["dtPurchaseReport"] != null)
            {
                base.Tables.Add(new PurchaseChallan.dtPurchaseReportDataTable(dataSet.Tables["dtPurchaseReport"]));
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
        private bool ShouldSerializedtPurchaseReport()
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
        public class dtPurchaseReportDataTable : TypedTableBase<PurchaseChallan.dtPurchaseReportRow>
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

            private DataColumn columnTRANS_TYPE;

            private DataColumn columnCHALLAN_ID;

            private DataColumn columnCHALLAN_NO;

            private DataColumn columnDATE_CHALLAN;

            private DataColumn columnTOTAL_CD;

            private DataColumn columnTOTAL_RD;

            private DataColumn columnTOTAL_AIT;

            private DataColumn columnTOTAL_ATV;

            private DataColumn columnTOTAL_TTI;

            private DataColumn columnUNIT_PRICE;

            private DataColumn columnPURCHASE_TYPE;

            private DataColumn columnTOTAL_OTHER_DUTY;

            private DataColumn columnOrgName;

            private DataColumn columnOrgAddress;

            private DataColumn columnBIN;

            private DataColumn columnFilter;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn BINColumn
            {
                get
                {
                    return this.columnBIN;
                }
            }

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
            public DataColumn FilterColumn
            {
                get
                {
                    return this.columnFilter;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public PurchaseChallan.dtPurchaseReportRow this[int index]
            {
                get
                {
                    return (PurchaseChallan.dtPurchaseReportRow)base.Rows[index];
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
            public DataColumn OrgAddressColumn
            {
                get
                {
                    return this.columnOrgAddress;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn OrgNameColumn
            {
                get
                {
                    return this.columnOrgName;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PURCHASE_TYPEColumn
            {
                get
                {
                    return this.columnPURCHASE_TYPE;
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
            public DataColumn TOTAL_AITColumn
            {
                get
                {
                    return this.columnTOTAL_AIT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_ATVColumn
            {
                get
                {
                    return this.columnTOTAL_ATV;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_CDColumn
            {
                get
                {
                    return this.columnTOTAL_CD;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TOTAL_OTHER_DUTYColumn
            {
                get
                {
                    return this.columnTOTAL_OTHER_DUTY;
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
            public DataColumn TOTAL_RDColumn
            {
                get
                {
                    return this.columnTOTAL_RD;
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
            public DataColumn TOTAL_TTIColumn
            {
                get
                {
                    return this.columnTOTAL_TTI;
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
            public DataColumn UNIT_IDColumn
            {
                get
                {
                    return this.columnUNIT_ID;
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
            public dtPurchaseReportDataTable()
            {
                base.TableName = "dtPurchaseReport";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtPurchaseReportDataTable(DataTable table)
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
            protected dtPurchaseReportDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AdddtPurchaseReportRow(PurchaseChallan.dtPurchaseReportRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public PurchaseChallan.dtPurchaseReportRow AdddtPurchaseReportRow(int ITEM_ID, string ITEM_NAME, short UNIT_ID, string UNIT_CODE, double QUANTITY, double TOTAL_PRICE, double TOTAL_SD, double TOTAL_VAT, double TOTAL_PRICE_WITH_SD_VAT, string TRANS_TYPE, short CHALLAN_ID, string CHALLAN_NO, DateTime DATE_CHALLAN, double TOTAL_CD, double TOTAL_RD, double TOTAL_AIT, double TOTAL_ATV, double TOTAL_TTI, double UNIT_PRICE, string PURCHASE_TYPE, string TOTAL_OTHER_DUTY, string OrgName, string OrgAddress, string BIN, string Filter)
            {
                PurchaseChallan.dtPurchaseReportRow _dtPurchaseReportRow = (PurchaseChallan.dtPurchaseReportRow)base.NewRow();
                object[] tEMID = new object[] { ITEM_ID, ITEM_NAME, UNIT_ID, UNIT_CODE, QUANTITY, TOTAL_PRICE, TOTAL_SD, TOTAL_VAT, TOTAL_PRICE_WITH_SD_VAT, TRANS_TYPE, CHALLAN_ID, CHALLAN_NO, DATE_CHALLAN, TOTAL_CD, TOTAL_RD, TOTAL_AIT, TOTAL_ATV, TOTAL_TTI, UNIT_PRICE, PURCHASE_TYPE, TOTAL_OTHER_DUTY, OrgName, OrgAddress, BIN, Filter };
                _dtPurchaseReportRow.ItemArray = tEMID;
                base.Rows.Add(_dtPurchaseReportRow);
                return _dtPurchaseReportRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                PurchaseChallan.dtPurchaseReportDataTable _dtPurchaseReportDataTable = (PurchaseChallan.dtPurchaseReportDataTable)base.Clone();
                _dtPurchaseReportDataTable.InitVars();
                return _dtPurchaseReportDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new PurchaseChallan.dtPurchaseReportDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(PurchaseChallan.dtPurchaseReportRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                PurchaseChallan purchaseChallan = new PurchaseChallan();
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
                    FixedValue = purchaseChallan.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "dtPurchaseReportDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = purchaseChallan.GetSchemaSerializable();
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
                this.columnTRANS_TYPE = new DataColumn("TRANS_TYPE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTRANS_TYPE);
                this.columnCHALLAN_ID = new DataColumn("CHALLAN_ID", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnCHALLAN_ID);
                this.columnCHALLAN_NO = new DataColumn("CHALLAN_NO", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCHALLAN_NO);
                this.columnDATE_CHALLAN = new DataColumn("DATE_CHALLAN", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDATE_CHALLAN);
                this.columnTOTAL_CD = new DataColumn("TOTAL_CD", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_CD);
                this.columnTOTAL_RD = new DataColumn("TOTAL_RD", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_RD);
                this.columnTOTAL_AIT = new DataColumn("TOTAL_AIT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_AIT);
                this.columnTOTAL_ATV = new DataColumn("TOTAL_ATV", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_ATV);
                this.columnTOTAL_TTI = new DataColumn("TOTAL_TTI", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_TTI);
                this.columnUNIT_PRICE = new DataColumn("UNIT_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnUNIT_PRICE);
                this.columnPURCHASE_TYPE = new DataColumn("PURCHASE_TYPE", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPURCHASE_TYPE);
                this.columnTOTAL_OTHER_DUTY = new DataColumn("TOTAL_OTHER_DUTY", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_OTHER_DUTY);
                this.columnOrgName = new DataColumn("OrgName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgName);
                this.columnOrgAddress = new DataColumn("OrgAddress", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgAddress);
                this.columnBIN = new DataColumn("BIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBIN);
                this.columnFilter = new DataColumn("Filter", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFilter);
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
                this.columnTRANS_TYPE = base.Columns["TRANS_TYPE"];
                this.columnCHALLAN_ID = base.Columns["CHALLAN_ID"];
                this.columnCHALLAN_NO = base.Columns["CHALLAN_NO"];
                this.columnDATE_CHALLAN = base.Columns["DATE_CHALLAN"];
                this.columnTOTAL_CD = base.Columns["TOTAL_CD"];
                this.columnTOTAL_RD = base.Columns["TOTAL_RD"];
                this.columnTOTAL_AIT = base.Columns["TOTAL_AIT"];
                this.columnTOTAL_ATV = base.Columns["TOTAL_ATV"];
                this.columnTOTAL_TTI = base.Columns["TOTAL_TTI"];
                this.columnUNIT_PRICE = base.Columns["UNIT_PRICE"];
                this.columnPURCHASE_TYPE = base.Columns["PURCHASE_TYPE"];
                this.columnTOTAL_OTHER_DUTY = base.Columns["TOTAL_OTHER_DUTY"];
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnBIN = base.Columns["BIN"];
                this.columnFilter = base.Columns["Filter"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public PurchaseChallan.dtPurchaseReportRow NewdtPurchaseReportRow()
            {
                return (PurchaseChallan.dtPurchaseReportRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new PurchaseChallan.dtPurchaseReportRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtPurchaseReportRowChanged != null)
                {
                    this.dtPurchaseReportRowChanged(this, new PurchaseChallan.dtPurchaseReportRowChangeEvent((PurchaseChallan.dtPurchaseReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtPurchaseReportRowChanging != null)
                {
                    this.dtPurchaseReportRowChanging(this, new PurchaseChallan.dtPurchaseReportRowChangeEvent((PurchaseChallan.dtPurchaseReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtPurchaseReportRowDeleted != null)
                {
                    this.dtPurchaseReportRowDeleted(this, new PurchaseChallan.dtPurchaseReportRowChangeEvent((PurchaseChallan.dtPurchaseReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtPurchaseReportRowDeleting != null)
                {
                    this.dtPurchaseReportRowDeleting(this, new PurchaseChallan.dtPurchaseReportRowChangeEvent((PurchaseChallan.dtPurchaseReportRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtPurchaseReportRow(PurchaseChallan.dtPurchaseReportRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event PurchaseChallan.dtPurchaseReportRowChangeEventHandler dtPurchaseReportRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event PurchaseChallan.dtPurchaseReportRowChangeEventHandler dtPurchaseReportRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event PurchaseChallan.dtPurchaseReportRowChangeEventHandler dtPurchaseReportRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event PurchaseChallan.dtPurchaseReportRowChangeEventHandler dtPurchaseReportRowDeleting;
        }

        public class dtPurchaseReportRow : DataRow
        {
            private PurchaseChallan.dtPurchaseReportDataTable tabledtPurchaseReport;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string BIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtPurchaseReport.BINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'BIN' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.BINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short CHALLAN_ID
            {
                get
                {
                    short item;
                    try
                    {
                        item = (short)base[this.tabledtPurchaseReport.CHALLAN_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'CHALLAN_ID' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.CHALLAN_IDColumn] = value;
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
                        item = (string)base[this.tabledtPurchaseReport.CHALLAN_NOColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'CHALLAN_NO' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.CHALLAN_NOColumn] = value;
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
                        item = (DateTime)base[this.tabledtPurchaseReport.DATE_CHALLANColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'DATE_CHALLAN' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.DATE_CHALLANColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Filter
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtPurchaseReport.FilterColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Filter' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.FilterColumn] = value;
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
                        item = (int)base[this.tabledtPurchaseReport.ITEM_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ITEM_ID' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.ITEM_IDColumn] = value;
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
                        item = (string)base[this.tabledtPurchaseReport.ITEM_NAMEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ITEM_NAME' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.ITEM_NAMEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgAddress
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtPurchaseReport.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.OrgAddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgName
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtPurchaseReport.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.OrgNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PURCHASE_TYPE
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtPurchaseReport.PURCHASE_TYPEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PURCHASE_TYPE' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.PURCHASE_TYPEColumn] = value;
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
                        item = (double)base[this.tabledtPurchaseReport.QUANTITYColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'QUANTITY' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.QUANTITYColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_AIT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_AITColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_AIT' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_AITColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_ATV
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_ATVColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_ATV' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_ATVColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_CD
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_CDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_CD' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_CDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TOTAL_OTHER_DUTY
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtPurchaseReport.TOTAL_OTHER_DUTYColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_OTHER_DUTY' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_OTHER_DUTYColumn] = value;
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
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_PRICE' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_PRICEColumn] = value;
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
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_PRICE_WITH_SD_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_PRICE_WITH_SD_VAT' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_PRICE_WITH_SD_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_RD
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_RDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_RD' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_RDColumn] = value;
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
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_SDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_SD' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_SDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TOTAL_TTI
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_TTIColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_TTI' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_TTIColumn] = value;
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
                        item = (double)base[this.tabledtPurchaseReport.TOTAL_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TOTAL_VAT' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TOTAL_VATColumn] = value;
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
                        item = (string)base[this.tabledtPurchaseReport.TRANS_TYPEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TRANS_TYPE' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.TRANS_TYPEColumn] = value;
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
                        item = (string)base[this.tabledtPurchaseReport.UNIT_CODEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_CODE' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.UNIT_CODEColumn] = value;
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
                        item = (short)base[this.tabledtPurchaseReport.UNIT_IDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_ID' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.UNIT_IDColumn] = value;
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
                        item = (double)base[this.tabledtPurchaseReport.UNIT_PRICEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'UNIT_PRICE' in table 'dtPurchaseReport' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtPurchaseReport.UNIT_PRICEColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtPurchaseReportRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledtPurchaseReport = (PurchaseChallan.dtPurchaseReportDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBINNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.BINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCHALLAN_IDNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.CHALLAN_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCHALLAN_NONull()
            {
                return base.IsNull(this.tabledtPurchaseReport.CHALLAN_NOColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDATE_CHALLANNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.DATE_CHALLANColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFilterNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.FilterColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsITEM_IDNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.ITEM_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsITEM_NAMENull()
            {
                return base.IsNull(this.tabledtPurchaseReport.ITEM_NAMEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPURCHASE_TYPENull()
            {
                return base.IsNull(this.tabledtPurchaseReport.PURCHASE_TYPEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQUANTITYNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.QUANTITYColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_AITNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_AITColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_ATVNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_ATVColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_CDNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_CDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_OTHER_DUTYNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_OTHER_DUTYColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_PRICE_WITH_SD_VATNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_PRICE_WITH_SD_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_PRICENull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_RDNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_RDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_SDNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_SDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_TTINull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_TTIColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTOTAL_VATNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TOTAL_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTRANS_TYPENull()
            {
                return base.IsNull(this.tabledtPurchaseReport.TRANS_TYPEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_CODENull()
            {
                return base.IsNull(this.tabledtPurchaseReport.UNIT_CODEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_IDNull()
            {
                return base.IsNull(this.tabledtPurchaseReport.UNIT_IDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsUNIT_PRICENull()
            {
                return base.IsNull(this.tabledtPurchaseReport.UNIT_PRICEColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBINNull()
            {
                base[this.tabledtPurchaseReport.BINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCHALLAN_IDNull()
            {
                base[this.tabledtPurchaseReport.CHALLAN_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCHALLAN_NONull()
            {
                base[this.tabledtPurchaseReport.CHALLAN_NOColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDATE_CHALLANNull()
            {
                base[this.tabledtPurchaseReport.DATE_CHALLANColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFilterNull()
            {
                base[this.tabledtPurchaseReport.FilterColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetITEM_IDNull()
            {
                base[this.tabledtPurchaseReport.ITEM_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetITEM_NAMENull()
            {
                base[this.tabledtPurchaseReport.ITEM_NAMEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tabledtPurchaseReport.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tabledtPurchaseReport.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPURCHASE_TYPENull()
            {
                base[this.tabledtPurchaseReport.PURCHASE_TYPEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQUANTITYNull()
            {
                base[this.tabledtPurchaseReport.QUANTITYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_AITNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_AITColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_ATVNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_ATVColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_CDNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_CDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_OTHER_DUTYNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_OTHER_DUTYColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_PRICE_WITH_SD_VATNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_PRICE_WITH_SD_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_PRICENull()
            {
                base[this.tabledtPurchaseReport.TOTAL_PRICEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_RDNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_RDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_SDNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_SDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_TTINull()
            {
                base[this.tabledtPurchaseReport.TOTAL_TTIColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTOTAL_VATNull()
            {
                base[this.tabledtPurchaseReport.TOTAL_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTRANS_TYPENull()
            {
                base[this.tabledtPurchaseReport.TRANS_TYPEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_CODENull()
            {
                base[this.tabledtPurchaseReport.UNIT_CODEColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_IDNull()
            {
                base[this.tabledtPurchaseReport.UNIT_IDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetUNIT_PRICENull()
            {
                base[this.tabledtPurchaseReport.UNIT_PRICEColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class dtPurchaseReportRowChangeEvent : EventArgs
        {
            private PurchaseChallan.dtPurchaseReportRow eventRow;

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
            public PurchaseChallan.dtPurchaseReportRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtPurchaseReportRowChangeEvent(PurchaseChallan.dtPurchaseReportRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtPurchaseReportRowChangeEventHandler(object sender, PurchaseChallan.dtPurchaseReportRowChangeEvent e);
    }
}

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
    [XmlRoot("VAT_REPORT")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class VAT_REPORT : DataSet
    {
        private VAT_REPORT.dtVATDataTable tabledtVAT;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public VAT_REPORT.dtVATDataTable dtVAT
        {
            get
            {
                return this.tabledtVAT;
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
        public VAT_REPORT()
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
        protected VAT_REPORT(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["dtVAT"] != null)
                {
                    base.Tables.Add(new VAT_REPORT.dtVATDataTable(dataSet.Tables["dtVAT"]));
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
            VAT_REPORT schemaSerializationMode = (VAT_REPORT)base.Clone();
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
            VAT_REPORT vATREPORT = new VAT_REPORT();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = vATREPORT.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = vATREPORT.GetSchemaSerializable();
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
            base.DataSetName = "VAT_REPORT";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/VAT_REPORT.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tabledtVAT = new VAT_REPORT.dtVATDataTable();
            base.Tables.Add(this.tabledtVAT);
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
            this.tabledtVAT = (VAT_REPORT.dtVATDataTable)base.Tables["dtVAT"];
            if (initTable && this.tabledtVAT != null)
            {
                this.tabledtVAT.InitVars();
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
            if (dataSet.Tables["dtVAT"] != null)
            {
                base.Tables.Add(new VAT_REPORT.dtVATDataTable(dataSet.Tables["dtVAT"]));
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
        private bool ShouldSerializedtVAT()
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
        public class dtVATDataTable : TypedTableBase<VAT_REPORT.dtVATRow>
        {
            private DataColumn columnTransMonth;

            private DataColumn columnPurchaseVAT;

            private DataColumn columnSaleVAT;

            private DataColumn columnTreasuryChallan;

            private DataColumn columnDebitNoteVAT;

            private DataColumn columnCreditNoteVAT;

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
            public DataColumn CreditNoteVATColumn
            {
                get
                {
                    return this.columnCreditNoteVAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DebitNoteVATColumn
            {
                get
                {
                    return this.columnDebitNoteVAT;
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
            public VAT_REPORT.dtVATRow this[int index]
            {
                get
                {
                    return (VAT_REPORT.dtVATRow)base.Rows[index];
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
            public DataColumn PurchaseVATColumn
            {
                get
                {
                    return this.columnPurchaseVAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SaleVATColumn
            {
                get
                {
                    return this.columnSaleVAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TransMonthColumn
            {
                get
                {
                    return this.columnTransMonth;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TreasuryChallanColumn
            {
                get
                {
                    return this.columnTreasuryChallan;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtVATDataTable()
            {
                base.TableName = "dtVAT";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtVATDataTable(DataTable table)
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
            protected dtVATDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AdddtVATRow(VAT_REPORT.dtVATRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VAT_REPORT.dtVATRow AdddtVATRow(string TransMonth, double PurchaseVAT, double SaleVAT, double TreasuryChallan, double DebitNoteVAT, double CreditNoteVAT, string OrgName, string OrgAddress, string BIN, string Filter)
            {
                VAT_REPORT.dtVATRow _dtVATRow = (VAT_REPORT.dtVATRow)base.NewRow();
                object[] transMonth = new object[] { TransMonth, PurchaseVAT, SaleVAT, TreasuryChallan, DebitNoteVAT, CreditNoteVAT, OrgName, OrgAddress, BIN, Filter };
                _dtVATRow.ItemArray = transMonth;
                base.Rows.Add(_dtVATRow);
                return _dtVATRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                VAT_REPORT.dtVATDataTable _dtVATDataTable = (VAT_REPORT.dtVATDataTable)base.Clone();
                _dtVATDataTable.InitVars();
                return _dtVATDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new VAT_REPORT.dtVATDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(VAT_REPORT.dtVATRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                VAT_REPORT vATREPORT = new VAT_REPORT();
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
                    FixedValue = vATREPORT.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "dtVATDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = vATREPORT.GetSchemaSerializable();
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
                this.columnTransMonth = new DataColumn("TransMonth", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTransMonth);
                this.columnPurchaseVAT = new DataColumn("PurchaseVAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnPurchaseVAT);
                this.columnSaleVAT = new DataColumn("SaleVAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnSaleVAT);
                this.columnTreasuryChallan = new DataColumn("TreasuryChallan", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTreasuryChallan);
                this.columnDebitNoteVAT = new DataColumn("DebitNoteVAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnDebitNoteVAT);
                this.columnCreditNoteVAT = new DataColumn("CreditNoteVAT", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnCreditNoteVAT);
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
                this.columnTransMonth = base.Columns["TransMonth"];
                this.columnPurchaseVAT = base.Columns["PurchaseVAT"];
                this.columnSaleVAT = base.Columns["SaleVAT"];
                this.columnTreasuryChallan = base.Columns["TreasuryChallan"];
                this.columnDebitNoteVAT = base.Columns["DebitNoteVAT"];
                this.columnCreditNoteVAT = base.Columns["CreditNoteVAT"];
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnBIN = base.Columns["BIN"];
                this.columnFilter = base.Columns["Filter"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VAT_REPORT.dtVATRow NewdtVATRow()
            {
                return (VAT_REPORT.dtVATRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VAT_REPORT.dtVATRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtVATRowChanged != null)
                {
                    this.dtVATRowChanged(this, new VAT_REPORT.dtVATRowChangeEvent((VAT_REPORT.dtVATRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtVATRowChanging != null)
                {
                    this.dtVATRowChanging(this, new VAT_REPORT.dtVATRowChangeEvent((VAT_REPORT.dtVATRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtVATRowDeleted != null)
                {
                    this.dtVATRowDeleted(this, new VAT_REPORT.dtVATRowChangeEvent((VAT_REPORT.dtVATRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtVATRowDeleting != null)
                {
                    this.dtVATRowDeleting(this, new VAT_REPORT.dtVATRowChangeEvent((VAT_REPORT.dtVATRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtVATRow(VAT_REPORT.dtVATRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VAT_REPORT.dtVATRowChangeEventHandler dtVATRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VAT_REPORT.dtVATRowChangeEventHandler dtVATRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VAT_REPORT.dtVATRowChangeEventHandler dtVATRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VAT_REPORT.dtVATRowChangeEventHandler dtVATRowDeleting;
        }

        public class dtVATRow : DataRow
        {
            private VAT_REPORT.dtVATDataTable tabledtVAT;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string BIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtVAT.BINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'BIN' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.BINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double CreditNoteVAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtVAT.CreditNoteVATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'CreditNoteVAT' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.CreditNoteVATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double DebitNoteVAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtVAT.DebitNoteVATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'DebitNoteVAT' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.DebitNoteVATColumn] = value;
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
                        item = (string)base[this.tabledtVAT.FilterColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Filter' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.FilterColumn] = value;
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
                        item = (string)base[this.tabledtVAT.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.OrgAddressColumn] = value;
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
                        item = (string)base[this.tabledtVAT.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.OrgNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double PurchaseVAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtVAT.PurchaseVATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PurchaseVAT' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.PurchaseVATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double SaleVAT
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtVAT.SaleVATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SaleVAT' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.SaleVATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TransMonth
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtVAT.TransMonthColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TransMonth' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.TransMonthColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TreasuryChallan
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtVAT.TreasuryChallanColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TreasuryChallan' in table 'dtVAT' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtVAT.TreasuryChallanColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal dtVATRow(DataRowBuilder rb) : base(rb)
            {
                this.tabledtVAT = (VAT_REPORT.dtVATDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBINNull()
            {
                return base.IsNull(this.tabledtVAT.BINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCreditNoteVATNull()
            {
                return base.IsNull(this.tabledtVAT.CreditNoteVATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDebitNoteVATNull()
            {
                return base.IsNull(this.tabledtVAT.DebitNoteVATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFilterNull()
            {
                return base.IsNull(this.tabledtVAT.FilterColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tabledtVAT.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tabledtVAT.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPurchaseVATNull()
            {
                return base.IsNull(this.tabledtVAT.PurchaseVATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSaleVATNull()
            {
                return base.IsNull(this.tabledtVAT.SaleVATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTransMonthNull()
            {
                return base.IsNull(this.tabledtVAT.TransMonthColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTreasuryChallanNull()
            {
                return base.IsNull(this.tabledtVAT.TreasuryChallanColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBINNull()
            {
                base[this.tabledtVAT.BINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCreditNoteVATNull()
            {
                base[this.tabledtVAT.CreditNoteVATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDebitNoteVATNull()
            {
                base[this.tabledtVAT.DebitNoteVATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFilterNull()
            {
                base[this.tabledtVAT.FilterColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tabledtVAT.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tabledtVAT.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPurchaseVATNull()
            {
                base[this.tabledtVAT.PurchaseVATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSaleVATNull()
            {
                base[this.tabledtVAT.SaleVATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTransMonthNull()
            {
                base[this.tabledtVAT.TransMonthColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTreasuryChallanNull()
            {
                base[this.tabledtVAT.TreasuryChallanColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class dtVATRowChangeEvent : EventArgs
        {
            private VAT_REPORT.dtVATRow eventRow;

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
            public VAT_REPORT.dtVATRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtVATRowChangeEvent(VAT_REPORT.dtVATRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtVATRowChangeEventHandler(object sender, VAT_REPORT.dtVATRowChangeEvent e);
    }
}

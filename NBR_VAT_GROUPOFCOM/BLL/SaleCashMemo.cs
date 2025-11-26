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
    [XmlRoot("SaleCashMemo")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class SaleCashMemo : DataSet
    {
        private SaleCashMemo.SaleCashMemoDataTable tableSaleCashMemo;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public SaleCashMemo.SaleCashMemoDataTable _SaleCashMemo
        {
            get
            {
                return this.tableSaleCashMemo;
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
        public SaleCashMemo()
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
        protected SaleCashMemo(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["SaleCashMemo"] != null)
                {
                    base.Tables.Add(new SaleCashMemo.SaleCashMemoDataTable(dataSet.Tables["SaleCashMemo"]));
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
            SaleCashMemo schemaSerializationMode = (SaleCashMemo)base.Clone();
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
            SaleCashMemo saleCashMemo = new SaleCashMemo();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = saleCashMemo.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = saleCashMemo.GetSchemaSerializable();
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
            base.DataSetName = "SaleCashMemo";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/SaleCashMemo.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableSaleCashMemo = new SaleCashMemo.SaleCashMemoDataTable();
            base.Tables.Add(this.tableSaleCashMemo);
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
            this.tableSaleCashMemo = (SaleCashMemo.SaleCashMemoDataTable)base.Tables["SaleCashMemo"];
            if (initTable && this.tableSaleCashMemo != null)
            {
                this.tableSaleCashMemo.InitVars();
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
            if (dataSet.Tables["SaleCashMemo"] != null)
            {
                base.Tables.Add(new SaleCashMemo.SaleCashMemoDataTable(dataSet.Tables["SaleCashMemo"]));
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
        private bool ShouldSerialize_SaleCashMemo()
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
        public class SaleCashMemoDataTable : TypedTableBase<SaleCashMemo.SaleCashMemoRow>
        {
            private DataColumn columnOrgName;

            private DataColumn columnOrgAddress;

            private DataColumn columnOrgBIN;

            private DataColumn columnPartyName;

            private DataColumn columnPartyAddress;

            private DataColumn columnChallanNo;

            private DataColumn columnItemDetails;

            private DataColumn columnQuantity;

            private DataColumn columnTotalPrice;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ChallanNoColumn
            {
                get
                {
                    return this.columnChallanNo;
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
            public SaleCashMemo.SaleCashMemoRow this[int index]
            {
                get
                {
                    return (SaleCashMemo.SaleCashMemoRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ItemDetailsColumn
            {
                get
                {
                    return this.columnItemDetails;
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
            public DataColumn OrgBINColumn
            {
                get
                {
                    return this.columnOrgBIN;
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
            public DataColumn PartyAddressColumn
            {
                get
                {
                    return this.columnPartyAddress;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn PartyNameColumn
            {
                get
                {
                    return this.columnPartyName;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn QuantityColumn
            {
                get
                {
                    return this.columnQuantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TotalPriceColumn
            {
                get
                {
                    return this.columnTotalPrice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleCashMemoDataTable()
            {
                base.TableName = "SaleCashMemo";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SaleCashMemoDataTable(DataTable table)
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
            protected SaleCashMemoDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSaleCashMemoRow(SaleCashMemo.SaleCashMemoRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleCashMemo.SaleCashMemoRow AddSaleCashMemoRow(string OrgName, string OrgAddress, string OrgBIN, string PartyName, string PartyAddress, string ChallanNo, string ItemDetails, double Quantity, double TotalPrice)
            {
                SaleCashMemo.SaleCashMemoRow saleCashMemoRow = (SaleCashMemo.SaleCashMemoRow)base.NewRow();
                object[] orgName = new object[] { OrgName, OrgAddress, OrgBIN, PartyName, PartyAddress, ChallanNo, ItemDetails, Quantity, TotalPrice };
                saleCashMemoRow.ItemArray = orgName;
                base.Rows.Add(saleCashMemoRow);
                return saleCashMemoRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                SaleCashMemo.SaleCashMemoDataTable saleCashMemoDataTable = (SaleCashMemo.SaleCashMemoDataTable)base.Clone();
                saleCashMemoDataTable.InitVars();
                return saleCashMemoDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new SaleCashMemo.SaleCashMemoDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(SaleCashMemo.SaleCashMemoRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                SaleCashMemo saleCashMemo = new SaleCashMemo();
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
                    FixedValue = saleCashMemo.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "SaleCashMemoDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = saleCashMemo.GetSchemaSerializable();
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
                this.columnOrgName = new DataColumn("OrgName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgName);
                this.columnOrgAddress = new DataColumn("OrgAddress", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgAddress);
                this.columnOrgBIN = new DataColumn("OrgBIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgBIN);
                this.columnPartyName = new DataColumn("PartyName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPartyName);
                this.columnPartyAddress = new DataColumn("PartyAddress", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPartyAddress);
                this.columnChallanNo = new DataColumn("ChallanNo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnChallanNo);
                this.columnItemDetails = new DataColumn("ItemDetails", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnItemDetails);
                this.columnQuantity = new DataColumn("Quantity", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnQuantity);
                this.columnTotalPrice = new DataColumn("TotalPrice", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTotalPrice);
                base.ExtendedProperties.Add("Generator_TablePropName", "_SaleCashMemo");
                base.ExtendedProperties.Add("Generator_UserTableName", "SaleCashMemo");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnOrgBIN = base.Columns["OrgBIN"];
                this.columnPartyName = base.Columns["PartyName"];
                this.columnPartyAddress = base.Columns["PartyAddress"];
                this.columnChallanNo = base.Columns["ChallanNo"];
                this.columnItemDetails = base.Columns["ItemDetails"];
                this.columnQuantity = base.Columns["Quantity"];
                this.columnTotalPrice = base.Columns["TotalPrice"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new SaleCashMemo.SaleCashMemoRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleCashMemo.SaleCashMemoRow NewSaleCashMemoRow()
            {
                return (SaleCashMemo.SaleCashMemoRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.SaleCashMemoRowChanged != null)
                {
                    this.SaleCashMemoRowChanged(this, new SaleCashMemo.SaleCashMemoRowChangeEvent((SaleCashMemo.SaleCashMemoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.SaleCashMemoRowChanging != null)
                {
                    this.SaleCashMemoRowChanging(this, new SaleCashMemo.SaleCashMemoRowChangeEvent((SaleCashMemo.SaleCashMemoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.SaleCashMemoRowDeleted != null)
                {
                    this.SaleCashMemoRowDeleted(this, new SaleCashMemo.SaleCashMemoRowChangeEvent((SaleCashMemo.SaleCashMemoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.SaleCashMemoRowDeleting != null)
                {
                    this.SaleCashMemoRowDeleting(this, new SaleCashMemo.SaleCashMemoRowChangeEvent((SaleCashMemo.SaleCashMemoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveSaleCashMemoRow(SaleCashMemo.SaleCashMemoRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleCashMemo.SaleCashMemoRowChangeEventHandler SaleCashMemoRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleCashMemo.SaleCashMemoRowChangeEventHandler SaleCashMemoRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleCashMemo.SaleCashMemoRowChangeEventHandler SaleCashMemoRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event SaleCashMemo.SaleCashMemoRowChangeEventHandler SaleCashMemoRowDeleting;
        }

        public class SaleCashMemoRow : DataRow
        {
            private SaleCashMemo.SaleCashMemoDataTable tableSaleCashMemo;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ChallanNo
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSaleCashMemo.ChallanNoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ChallanNo' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.ChallanNoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ItemDetails
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSaleCashMemo.ItemDetailsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ItemDetails' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.ItemDetailsColumn] = value;
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
                        item = (string)base[this.tableSaleCashMemo.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.OrgAddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgBIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSaleCashMemo.OrgBINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgBIN' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.OrgBINColumn] = value;
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
                        item = (string)base[this.tableSaleCashMemo.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.OrgNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PartyAddress
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSaleCashMemo.PartyAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PartyAddress' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.PartyAddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PartyName
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSaleCashMemo.PartyNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PartyName' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.PartyNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Quantity
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableSaleCashMemo.QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Quantity' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double TotalPrice
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableSaleCashMemo.TotalPriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TotalPrice' in table 'SaleCashMemo' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSaleCashMemo.TotalPriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal SaleCashMemoRow(DataRowBuilder rb) : base(rb)
            {
                this.tableSaleCashMemo = (SaleCashMemo.SaleCashMemoDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallanNoNull()
            {
                return base.IsNull(this.tableSaleCashMemo.ChallanNoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsItemDetailsNull()
            {
                return base.IsNull(this.tableSaleCashMemo.ItemDetailsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tableSaleCashMemo.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgBINNull()
            {
                return base.IsNull(this.tableSaleCashMemo.OrgBINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tableSaleCashMemo.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPartyAddressNull()
            {
                return base.IsNull(this.tableSaleCashMemo.PartyAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPartyNameNull()
            {
                return base.IsNull(this.tableSaleCashMemo.PartyNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQuantityNull()
            {
                return base.IsNull(this.tableSaleCashMemo.QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTotalPriceNull()
            {
                return base.IsNull(this.tableSaleCashMemo.TotalPriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallanNoNull()
            {
                base[this.tableSaleCashMemo.ChallanNoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetItemDetailsNull()
            {
                base[this.tableSaleCashMemo.ItemDetailsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tableSaleCashMemo.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgBINNull()
            {
                base[this.tableSaleCashMemo.OrgBINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tableSaleCashMemo.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPartyAddressNull()
            {
                base[this.tableSaleCashMemo.PartyAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPartyNameNull()
            {
                base[this.tableSaleCashMemo.PartyNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQuantityNull()
            {
                base[this.tableSaleCashMemo.QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTotalPriceNull()
            {
                base[this.tableSaleCashMemo.TotalPriceColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class SaleCashMemoRowChangeEvent : EventArgs
        {
            private SaleCashMemo.SaleCashMemoRow eventRow;

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
            public SaleCashMemo.SaleCashMemoRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public SaleCashMemoRowChangeEvent(SaleCashMemo.SaleCashMemoRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void SaleCashMemoRowChangeEventHandler(object sender, SaleCashMemo.SaleCashMemoRowChangeEvent e);
    }
}






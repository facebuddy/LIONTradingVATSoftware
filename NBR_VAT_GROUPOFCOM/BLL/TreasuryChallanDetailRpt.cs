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
    [XmlRoot("TreasuryChallanDetailRpt")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class TreasuryChallanDetailRpt : DataSet
    {
        private TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable tableTreasuryChallanDetailRpt;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable _TreasuryChallanDetailRpt
        {
            get
            {
                return this.tableTreasuryChallanDetailRpt;
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
        public TreasuryChallanDetailRpt()
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
        protected TreasuryChallanDetailRpt(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["TreasuryChallanDetailRpt"] != null)
                {
                    base.Tables.Add(new TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable(dataSet.Tables["TreasuryChallanDetailRpt"]));
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
            TreasuryChallanDetailRpt schemaSerializationMode = (TreasuryChallanDetailRpt)base.Clone();
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
            TreasuryChallanDetailRpt treasuryChallanDetailRpt = new TreasuryChallanDetailRpt();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = treasuryChallanDetailRpt.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = treasuryChallanDetailRpt.GetSchemaSerializable();
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
            base.DataSetName = "TreasuryChallanDetailRpt";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/TreasuryChallanDetailRpt.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableTreasuryChallanDetailRpt = new TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable();
            base.Tables.Add(this.tableTreasuryChallanDetailRpt);
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
            this.tableTreasuryChallanDetailRpt = (TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable)base.Tables["TreasuryChallanDetailRpt"];
            if (initTable && this.tableTreasuryChallanDetailRpt != null)
            {
                this.tableTreasuryChallanDetailRpt.InitVars();
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
            if (dataSet.Tables["TreasuryChallanDetailRpt"] != null)
            {
                base.Tables.Add(new TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable(dataSet.Tables["TreasuryChallanDetailRpt"]));
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
        private bool ShouldSerialize_TreasuryChallanDetailRpt()
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
        public class TreasuryChallanDetailRptDataTable : TypedTableBase<TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow>
        {
            private DataColumn columnchallan_no;

            private DataColumn columnchallan_date;

            private DataColumn columncode_no;

            private DataColumn columnbearer_name_address;

            private DataColumn columnbank_name;

            private DataColumn columnbranch_name;

            private DataColumn columnbehalf_of;

            private DataColumn columndeposit_description;

            private DataColumn columninstrument_description;

            private DataColumn columnunit_price;

            private DataColumn columndesignation;

            private DataColumn columnunit;

            private DataColumn columnamount;

            private DataColumn columninstrument_type;

            private DataColumn columnchallan_for;

            private DataColumn columnOrgName;

            private DataColumn columnOrgAddress;

            private DataColumn columnBIN;

            private DataColumn columnFilter;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn amountColumn
            {
                get
                {
                    return this.columnamount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn bank_nameColumn
            {
                get
                {
                    return this.columnbank_name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn bearer_name_addressColumn
            {
                get
                {
                    return this.columnbearer_name_address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn behalf_ofColumn
            {
                get
                {
                    return this.columnbehalf_of;
                }
            }

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
            public DataColumn branch_nameColumn
            {
                get
                {
                    return this.columnbranch_name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn challan_dateColumn
            {
                get
                {
                    return this.columnchallan_date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn challan_forColumn
            {
                get
                {
                    return this.columnchallan_for;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn challan_noColumn
            {
                get
                {
                    return this.columnchallan_no;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn code_noColumn
            {
                get
                {
                    return this.columncode_no;
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
            public DataColumn deposit_descriptionColumn
            {
                get
                {
                    return this.columndeposit_description;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn designationColumn
            {
                get
                {
                    return this.columndesignation;
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
            public DataColumn instrument_descriptionColumn
            {
                get
                {
                    return this.columninstrument_description;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn instrument_typeColumn
            {
                get
                {
                    return this.columninstrument_type;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow this[int index]
            {
                get
                {
                    return (TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)base.Rows[index];
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
            public DataColumn unit_priceColumn
            {
                get
                {
                    return this.columnunit_price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn unitColumn
            {
                get
                {
                    return this.columnunit;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public TreasuryChallanDetailRptDataTable()
            {
                base.TableName = "TreasuryChallanDetailRpt";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal TreasuryChallanDetailRptDataTable(DataTable table)
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
            protected TreasuryChallanDetailRptDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddTreasuryChallanDetailRptRow(TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow AddTreasuryChallanDetailRptRow(string challan_no, DateTime challan_date, string code_no, string bearer_name_address, string bank_name, string branch_name, string behalf_of, string deposit_description, string instrument_description, double unit_price, string designation, string unit, double amount, string instrument_type, string challan_for, string OrgName, string OrgAddress, string BIN, string Filter)
            {
                TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow treasuryChallanDetailRptRow = (TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)base.NewRow();
                object[] challanNo = new object[] { challan_no, challan_date, code_no, bearer_name_address, bank_name, branch_name, behalf_of, deposit_description, instrument_description, unit_price, designation, unit, amount, instrument_type, challan_for, OrgName, OrgAddress, BIN, Filter };
                treasuryChallanDetailRptRow.ItemArray = challanNo;
                base.Rows.Add(treasuryChallanDetailRptRow);
                return treasuryChallanDetailRptRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable treasuryChallanDetailRptDataTable = (TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable)base.Clone();
                treasuryChallanDetailRptDataTable.InitVars();
                return treasuryChallanDetailRptDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                TreasuryChallanDetailRpt treasuryChallanDetailRpt = new TreasuryChallanDetailRpt();
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
                    FixedValue = treasuryChallanDetailRpt.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "TreasuryChallanDetailRptDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = treasuryChallanDetailRpt.GetSchemaSerializable();
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
                this.columnchallan_no = new DataColumn("challan_no", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_no);
                this.columnchallan_date = new DataColumn("challan_date", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_date);
                this.columncode_no = new DataColumn("code_no", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columncode_no);
                this.columnbearer_name_address = new DataColumn("bearer_name_address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnbearer_name_address);
                this.columnbank_name = new DataColumn("bank_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnbank_name);
                this.columnbranch_name = new DataColumn("branch_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnbranch_name);
                this.columnbehalf_of = new DataColumn("behalf_of", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnbehalf_of);
                this.columndeposit_description = new DataColumn("deposit_description", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndeposit_description);
                this.columninstrument_description = new DataColumn("instrument_description", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columninstrument_description);
                this.columnunit_price = new DataColumn("unit_price", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnunit_price);
                this.columndesignation = new DataColumn("designation", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndesignation);
                this.columnunit = new DataColumn("unit", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnunit);
                this.columnamount = new DataColumn("amount", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnamount);
                this.columninstrument_type = new DataColumn("instrument_type", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columninstrument_type);
                this.columnchallan_for = new DataColumn("challan_for", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_for);
                this.columnOrgName = new DataColumn("OrgName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgName);
                this.columnOrgAddress = new DataColumn("OrgAddress", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgAddress);
                this.columnBIN = new DataColumn("BIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBIN);
                this.columnFilter = new DataColumn("Filter", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFilter);
                base.ExtendedProperties.Add("Generator_TablePropName", "_TreasuryChallanDetailRpt");
                base.ExtendedProperties.Add("Generator_UserTableName", "TreasuryChallanDetailRpt");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnchallan_no = base.Columns["challan_no"];
                this.columnchallan_date = base.Columns["challan_date"];
                this.columncode_no = base.Columns["code_no"];
                this.columnbearer_name_address = base.Columns["bearer_name_address"];
                this.columnbank_name = base.Columns["bank_name"];
                this.columnbranch_name = base.Columns["branch_name"];
                this.columnbehalf_of = base.Columns["behalf_of"];
                this.columndeposit_description = base.Columns["deposit_description"];
                this.columninstrument_description = base.Columns["instrument_description"];
                this.columnunit_price = base.Columns["unit_price"];
                this.columndesignation = base.Columns["designation"];
                this.columnunit = base.Columns["unit"];
                this.columnamount = base.Columns["amount"];
                this.columninstrument_type = base.Columns["instrument_type"];
                this.columnchallan_for = base.Columns["challan_for"];
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnBIN = base.Columns["BIN"];
                this.columnFilter = base.Columns["Filter"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow NewTreasuryChallanDetailRptRow()
            {
                return (TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.TreasuryChallanDetailRptRowChanged != null)
                {
                    this.TreasuryChallanDetailRptRowChanged(this, new TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEvent((TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.TreasuryChallanDetailRptRowChanging != null)
                {
                    this.TreasuryChallanDetailRptRowChanging(this, new TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEvent((TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.TreasuryChallanDetailRptRowDeleted != null)
                {
                    this.TreasuryChallanDetailRptRowDeleted(this, new TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEvent((TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.TreasuryChallanDetailRptRowDeleting != null)
                {
                    this.TreasuryChallanDetailRptRowDeleting(this, new TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEvent((TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveTreasuryChallanDetailRptRow(TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEventHandler TreasuryChallanDetailRptRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEventHandler TreasuryChallanDetailRptRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEventHandler TreasuryChallanDetailRptRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEventHandler TreasuryChallanDetailRptRowDeleting;
        }

        public class TreasuryChallanDetailRptRow : DataRow
        {
            private TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable tableTreasuryChallanDetailRpt;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double amount
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableTreasuryChallanDetailRpt.amountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'amount' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.amountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string bank_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.bank_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'bank_name' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.bank_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string bearer_name_address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.bearer_name_addressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'bearer_name_address' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.bearer_name_addressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string behalf_of
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.behalf_ofColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'behalf_of' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.behalf_ofColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string BIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.BINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'BIN' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.BINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string branch_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.branch_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'branch_name' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.branch_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime challan_date
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tableTreasuryChallanDetailRpt.challan_dateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_date' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.challan_dateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string challan_for
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.challan_forColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_for' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.challan_forColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string challan_no
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.challan_noColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_no' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.challan_noColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string code_no
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.code_noColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'code_no' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.code_noColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string deposit_description
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.deposit_descriptionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'deposit_description' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.deposit_descriptionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string designation
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.designationColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'designation' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.designationColumn] = value;
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
                        item = (string)base[this.tableTreasuryChallanDetailRpt.FilterColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Filter' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.FilterColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string instrument_description
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.instrument_descriptionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'instrument_description' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.instrument_descriptionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string instrument_type
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.instrument_typeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'instrument_type' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.instrument_typeColumn] = value;
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
                        item = (string)base[this.tableTreasuryChallanDetailRpt.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.OrgAddressColumn] = value;
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
                        item = (string)base[this.tableTreasuryChallanDetailRpt.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.OrgNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string unit
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableTreasuryChallanDetailRpt.unitColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'unit' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.unitColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double unit_price
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableTreasuryChallanDetailRpt.unit_priceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'unit_price' in table 'TreasuryChallanDetailRpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableTreasuryChallanDetailRpt.unit_priceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal TreasuryChallanDetailRptRow(DataRowBuilder rb) : base(rb)
            {
                this.tableTreasuryChallanDetailRpt = (TreasuryChallanDetailRpt.TreasuryChallanDetailRptDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsamountNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.amountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbank_nameNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.bank_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbearer_name_addressNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.bearer_name_addressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbehalf_ofNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.behalf_ofColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBINNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.BINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbranch_nameNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.branch_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_dateNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.challan_dateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_forNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.challan_forColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_noNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.challan_noColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Iscode_noNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.code_noColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isdeposit_descriptionNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.deposit_descriptionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsdesignationNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.designationColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFilterNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.FilterColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isinstrument_descriptionNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.instrument_descriptionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isinstrument_typeNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.instrument_typeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isunit_priceNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.unit_priceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsunitNull()
            {
                return base.IsNull(this.tableTreasuryChallanDetailRpt.unitColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetamountNull()
            {
                base[this.tableTreasuryChallanDetailRpt.amountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbank_nameNull()
            {
                base[this.tableTreasuryChallanDetailRpt.bank_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbearer_name_addressNull()
            {
                base[this.tableTreasuryChallanDetailRpt.bearer_name_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbehalf_ofNull()
            {
                base[this.tableTreasuryChallanDetailRpt.behalf_ofColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBINNull()
            {
                base[this.tableTreasuryChallanDetailRpt.BINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbranch_nameNull()
            {
                base[this.tableTreasuryChallanDetailRpt.branch_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_dateNull()
            {
                base[this.tableTreasuryChallanDetailRpt.challan_dateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_forNull()
            {
                base[this.tableTreasuryChallanDetailRpt.challan_forColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_noNull()
            {
                base[this.tableTreasuryChallanDetailRpt.challan_noColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setcode_noNull()
            {
                base[this.tableTreasuryChallanDetailRpt.code_noColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setdeposit_descriptionNull()
            {
                base[this.tableTreasuryChallanDetailRpt.deposit_descriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetdesignationNull()
            {
                base[this.tableTreasuryChallanDetailRpt.designationColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFilterNull()
            {
                base[this.tableTreasuryChallanDetailRpt.FilterColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setinstrument_descriptionNull()
            {
                base[this.tableTreasuryChallanDetailRpt.instrument_descriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setinstrument_typeNull()
            {
                base[this.tableTreasuryChallanDetailRpt.instrument_typeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tableTreasuryChallanDetailRpt.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tableTreasuryChallanDetailRpt.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setunit_priceNull()
            {
                base[this.tableTreasuryChallanDetailRpt.unit_priceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetunitNull()
            {
                base[this.tableTreasuryChallanDetailRpt.unitColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class TreasuryChallanDetailRptRowChangeEvent : EventArgs
        {
            private TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow eventRow;

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
            public TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public TreasuryChallanDetailRptRowChangeEvent(TreasuryChallanDetailRpt.TreasuryChallanDetailRptRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void TreasuryChallanDetailRptRowChangeEventHandler(object sender, TreasuryChallanDetailRpt.TreasuryChallanDetailRptRowChangeEvent e);
    }

}

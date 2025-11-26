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
    [XmlRoot("RawMaterialConsumptionData")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class RawMaterialConsumptionData : DataSet
    {
        private RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable tableRawMaterialConsumptionData;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable _RawMaterialConsumptionData
        {
            get
            {
                return this.tableRawMaterialConsumptionData;
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
        public RawMaterialConsumptionData()
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
        protected RawMaterialConsumptionData(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["RawMaterialConsumptionData"] != null)
                {
                    base.Tables.Add(new RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable(dataSet.Tables["RawMaterialConsumptionData"]));
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
            RawMaterialConsumptionData schemaSerializationMode = (RawMaterialConsumptionData)base.Clone();
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
            RawMaterialConsumptionData rawMaterialConsumptionDatum = new RawMaterialConsumptionData();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = rawMaterialConsumptionDatum.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = rawMaterialConsumptionDatum.GetSchemaSerializable();
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
            base.DataSetName = "RawMaterialConsumptionData";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/RawMaterialConsumptionData.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableRawMaterialConsumptionData = new RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable();
            base.Tables.Add(this.tableRawMaterialConsumptionData);
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
            this.tableRawMaterialConsumptionData = (RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable)base.Tables["RawMaterialConsumptionData"];
            if (initTable && this.tableRawMaterialConsumptionData != null)
            {
                this.tableRawMaterialConsumptionData.InitVars();
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
            if (dataSet.Tables["RawMaterialConsumptionData"] != null)
            {
                base.Tables.Add(new RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable(dataSet.Tables["RawMaterialConsumptionData"]));
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
        private bool ShouldSerialize_RawMaterialConsumptionData()
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
        public class RawMaterialConsumptionDataDataTable : TypedTableBase<RawMaterialConsumptionData.RawMaterialConsumptionDataRow>
        {
            private DataColumn columnorganization_name;

            private DataColumn columnbusiness_address;

            private DataColumn columnBIN;

            private DataColumn columnchallan_id;

            private DataColumn columnchallan_no;

            private DataColumn columnchallan_date;

            private DataColumn columnitem_name;

            private DataColumn columnunit_code;

            private DataColumn columnquantity;

            private DataColumn columnactual_price;

            private DataColumn columnsd;

            private DataColumn columnvat;

            private DataColumn columnFilter;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn actual_priceColumn
            {
                get
                {
                    return this.columnactual_price;
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
            public DataColumn business_addressColumn
            {
                get
                {
                    return this.columnbusiness_address;
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
            public DataColumn challan_idColumn
            {
                get
                {
                    return this.columnchallan_id;
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
            public DataColumn FilterColumn
            {
                get
                {
                    return this.columnFilter;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RawMaterialConsumptionData.RawMaterialConsumptionDataRow this[int index]
            {
                get
                {
                    return (RawMaterialConsumptionData.RawMaterialConsumptionDataRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn item_nameColumn
            {
                get
                {
                    return this.columnitem_name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn organization_nameColumn
            {
                get
                {
                    return this.columnorganization_name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn quantityColumn
            {
                get
                {
                    return this.columnquantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn sdColumn
            {
                get
                {
                    return this.columnsd;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn unit_codeColumn
            {
                get
                {
                    return this.columnunit_code;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn vatColumn
            {
                get
                {
                    return this.columnvat;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RawMaterialConsumptionDataDataTable()
            {
                base.TableName = "RawMaterialConsumptionData";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RawMaterialConsumptionDataDataTable(DataTable table)
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
            protected RawMaterialConsumptionDataDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddRawMaterialConsumptionDataRow(RawMaterialConsumptionData.RawMaterialConsumptionDataRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RawMaterialConsumptionData.RawMaterialConsumptionDataRow AddRawMaterialConsumptionDataRow(string organization_name, string business_address, string BIN, string challan_id, string challan_no, DateTime challan_date, string item_name, string unit_code, double quantity, double actual_price, double sd, double vat, string Filter)
            {
                RawMaterialConsumptionData.RawMaterialConsumptionDataRow rawMaterialConsumptionDataRow = (RawMaterialConsumptionData.RawMaterialConsumptionDataRow)base.NewRow();
                object[] organizationName = new object[] { organization_name, business_address, BIN, challan_id, challan_no, challan_date, item_name, unit_code, quantity, actual_price, sd, vat, Filter };
                rawMaterialConsumptionDataRow.ItemArray = organizationName;
                base.Rows.Add(rawMaterialConsumptionDataRow);
                return rawMaterialConsumptionDataRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable rawMaterialConsumptionDataDataTable = (RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable)base.Clone();
                rawMaterialConsumptionDataDataTable.InitVars();
                return rawMaterialConsumptionDataDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(RawMaterialConsumptionData.RawMaterialConsumptionDataRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                RawMaterialConsumptionData rawMaterialConsumptionDatum = new RawMaterialConsumptionData();
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
                    FixedValue = rawMaterialConsumptionDatum.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "RawMaterialConsumptionDataDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = rawMaterialConsumptionDatum.GetSchemaSerializable();
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
                this.columnorganization_name = new DataColumn("organization_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnorganization_name);
                this.columnbusiness_address = new DataColumn("business_address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnbusiness_address);
                this.columnBIN = new DataColumn("BIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBIN);
                this.columnchallan_id = new DataColumn("challan_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_id);
                this.columnchallan_no = new DataColumn("challan_no", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_no);
                this.columnchallan_date = new DataColumn("challan_date", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_date);
                this.columnitem_name = new DataColumn("item_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnitem_name);
                this.columnunit_code = new DataColumn("unit_code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnunit_code);
                this.columnquantity = new DataColumn("quantity", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnquantity);
                this.columnactual_price = new DataColumn("actual_price", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnactual_price);
                this.columnsd = new DataColumn("sd", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnsd);
                this.columnvat = new DataColumn("vat", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnvat);
                this.columnFilter = new DataColumn("Filter", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFilter);
                base.ExtendedProperties.Add("Generator_TablePropName", "_RawMaterialConsumptionData");
                base.ExtendedProperties.Add("Generator_UserTableName", "RawMaterialConsumptionData");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnorganization_name = base.Columns["organization_name"];
                this.columnbusiness_address = base.Columns["business_address"];
                this.columnBIN = base.Columns["BIN"];
                this.columnchallan_id = base.Columns["challan_id"];
                this.columnchallan_no = base.Columns["challan_no"];
                this.columnchallan_date = base.Columns["challan_date"];
                this.columnitem_name = base.Columns["item_name"];
                this.columnunit_code = base.Columns["unit_code"];
                this.columnquantity = base.Columns["quantity"];
                this.columnactual_price = base.Columns["actual_price"];
                this.columnsd = base.Columns["sd"];
                this.columnvat = base.Columns["vat"];
                this.columnFilter = base.Columns["Filter"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RawMaterialConsumptionData.RawMaterialConsumptionDataRow NewRawMaterialConsumptionDataRow()
            {
                return (RawMaterialConsumptionData.RawMaterialConsumptionDataRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new RawMaterialConsumptionData.RawMaterialConsumptionDataRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.RawMaterialConsumptionDataRowChanged != null)
                {
                    this.RawMaterialConsumptionDataRowChanged(this, new RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEvent((RawMaterialConsumptionData.RawMaterialConsumptionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.RawMaterialConsumptionDataRowChanging != null)
                {
                    this.RawMaterialConsumptionDataRowChanging(this, new RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEvent((RawMaterialConsumptionData.RawMaterialConsumptionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.RawMaterialConsumptionDataRowDeleted != null)
                {
                    this.RawMaterialConsumptionDataRowDeleted(this, new RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEvent((RawMaterialConsumptionData.RawMaterialConsumptionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.RawMaterialConsumptionDataRowDeleting != null)
                {
                    this.RawMaterialConsumptionDataRowDeleting(this, new RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEvent((RawMaterialConsumptionData.RawMaterialConsumptionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveRawMaterialConsumptionDataRow(RawMaterialConsumptionData.RawMaterialConsumptionDataRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEventHandler RawMaterialConsumptionDataRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEventHandler RawMaterialConsumptionDataRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEventHandler RawMaterialConsumptionDataRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEventHandler RawMaterialConsumptionDataRowDeleting;
        }

        public class RawMaterialConsumptionDataRow : DataRow
        {
            private RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable tableRawMaterialConsumptionData;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double actual_price
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableRawMaterialConsumptionData.actual_priceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'actual_price' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.actual_priceColumn] = value;
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
                        item = (string)base[this.tableRawMaterialConsumptionData.BINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'BIN' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.BINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string business_address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableRawMaterialConsumptionData.business_addressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'business_address' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.business_addressColumn] = value;
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
                        item = (DateTime)base[this.tableRawMaterialConsumptionData.challan_dateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_date' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.challan_dateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string challan_id
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableRawMaterialConsumptionData.challan_idColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_id' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.challan_idColumn] = value;
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
                        item = (string)base[this.tableRawMaterialConsumptionData.challan_noColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_no' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.challan_noColumn] = value;
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
                        item = (string)base[this.tableRawMaterialConsumptionData.FilterColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Filter' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.FilterColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string item_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableRawMaterialConsumptionData.item_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'item_name' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.item_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string organization_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableRawMaterialConsumptionData.organization_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'organization_name' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.organization_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double quantity
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableRawMaterialConsumptionData.quantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'quantity' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.quantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double sd
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableRawMaterialConsumptionData.sdColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'sd' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.sdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string unit_code
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableRawMaterialConsumptionData.unit_codeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'unit_code' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.unit_codeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double vat
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableRawMaterialConsumptionData.vatColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'vat' in table 'RawMaterialConsumptionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableRawMaterialConsumptionData.vatColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal RawMaterialConsumptionDataRow(DataRowBuilder rb) : base(rb)
            {
                this.tableRawMaterialConsumptionData = (RawMaterialConsumptionData.RawMaterialConsumptionDataDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isactual_priceNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.actual_priceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBINNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.BINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbusiness_addressNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.business_addressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_dateNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.challan_dateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_idNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.challan_idColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_noNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.challan_noColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFilterNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.FilterColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isitem_nameNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.item_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isorganization_nameNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.organization_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsquantityNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.quantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IssdNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.sdColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isunit_codeNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.unit_codeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsvatNull()
            {
                return base.IsNull(this.tableRawMaterialConsumptionData.vatColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setactual_priceNull()
            {
                base[this.tableRawMaterialConsumptionData.actual_priceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBINNull()
            {
                base[this.tableRawMaterialConsumptionData.BINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbusiness_addressNull()
            {
                base[this.tableRawMaterialConsumptionData.business_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_dateNull()
            {
                base[this.tableRawMaterialConsumptionData.challan_dateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_idNull()
            {
                base[this.tableRawMaterialConsumptionData.challan_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_noNull()
            {
                base[this.tableRawMaterialConsumptionData.challan_noColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFilterNull()
            {
                base[this.tableRawMaterialConsumptionData.FilterColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setitem_nameNull()
            {
                base[this.tableRawMaterialConsumptionData.item_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setorganization_nameNull()
            {
                base[this.tableRawMaterialConsumptionData.organization_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetquantityNull()
            {
                base[this.tableRawMaterialConsumptionData.quantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetsdNull()
            {
                base[this.tableRawMaterialConsumptionData.sdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setunit_codeNull()
            {
                base[this.tableRawMaterialConsumptionData.unit_codeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetvatNull()
            {
                base[this.tableRawMaterialConsumptionData.vatColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class RawMaterialConsumptionDataRowChangeEvent : EventArgs
        {
            private RawMaterialConsumptionData.RawMaterialConsumptionDataRow eventRow;

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
            public RawMaterialConsumptionData.RawMaterialConsumptionDataRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public RawMaterialConsumptionDataRowChangeEvent(RawMaterialConsumptionData.RawMaterialConsumptionDataRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void RawMaterialConsumptionDataRowChangeEventHandler(object sender, RawMaterialConsumptionData.RawMaterialConsumptionDataRowChangeEvent e);
    }
}


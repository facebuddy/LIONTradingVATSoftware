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
    [XmlRoot("FinishGoodProdutionData")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class FinishGoodProdutionData : DataSet
    {
        private FinishGoodProdutionData.FinishGoodProdutionDataDataTable tableFinishGoodProdutionData;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public FinishGoodProdutionData.FinishGoodProdutionDataDataTable _FinishGoodProdutionData
        {
            get
            {
                return this.tableFinishGoodProdutionData;
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
        public FinishGoodProdutionData()
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
        protected FinishGoodProdutionData(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["FinishGoodProdutionData"] != null)
                {
                    base.Tables.Add(new FinishGoodProdutionData.FinishGoodProdutionDataDataTable(dataSet.Tables["FinishGoodProdutionData"]));
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
            FinishGoodProdutionData schemaSerializationMode = (FinishGoodProdutionData)base.Clone();
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
            FinishGoodProdutionData finishGoodProdutionDatum = new FinishGoodProdutionData();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = finishGoodProdutionDatum.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = finishGoodProdutionDatum.GetSchemaSerializable();
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
            base.DataSetName = "FinishGoodProdutionData";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/FinishGoodProdutionData.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableFinishGoodProdutionData = new FinishGoodProdutionData.FinishGoodProdutionDataDataTable();
            base.Tables.Add(this.tableFinishGoodProdutionData);
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
            this.tableFinishGoodProdutionData = (FinishGoodProdutionData.FinishGoodProdutionDataDataTable)base.Tables["FinishGoodProdutionData"];
            if (initTable && this.tableFinishGoodProdutionData != null)
            {
                this.tableFinishGoodProdutionData.InitVars();
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
            if (dataSet.Tables["FinishGoodProdutionData"] != null)
            {
                base.Tables.Add(new FinishGoodProdutionData.FinishGoodProdutionDataDataTable(dataSet.Tables["FinishGoodProdutionData"]));
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
        private bool ShouldSerialize_FinishGoodProdutionData()
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
        public class FinishGoodProdutionDataDataTable : TypedTableBase<FinishGoodProdutionData.FinishGoodProdutionDataRow>
        {
            private DataColumn columnorganization_name;

            private DataColumn columnbusiness_address;

            private DataColumn columnBIN;

            private DataColumn columnchallan_id;

            private DataColumn columnchallan_date;

            private DataColumn columnchallan_no;

            private DataColumn columnitem_name;

            private DataColumn columnunit_code;

            private DataColumn columnquantity;

            private DataColumn columnunitPrice;

            private DataColumn columntotalSd;

            private DataColumn columntotalVat;

            private DataColumn columnTotalPrice;

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
            public FinishGoodProdutionData.FinishGoodProdutionDataRow this[int index]
            {
                get
                {
                    return (FinishGoodProdutionData.FinishGoodProdutionDataRow)base.Rows[index];
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
            public DataColumn TotalPriceColumn
            {
                get
                {
                    return this.columnTotalPrice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn totalSdColumn
            {
                get
                {
                    return this.columntotalSd;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn totalVatColumn
            {
                get
                {
                    return this.columntotalVat;
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
            public DataColumn unitPriceColumn
            {
                get
                {
                    return this.columnunitPrice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public FinishGoodProdutionDataDataTable()
            {
                base.TableName = "FinishGoodProdutionData";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal FinishGoodProdutionDataDataTable(DataTable table)
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
            protected FinishGoodProdutionDataDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddFinishGoodProdutionDataRow(FinishGoodProdutionData.FinishGoodProdutionDataRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public FinishGoodProdutionData.FinishGoodProdutionDataRow AddFinishGoodProdutionDataRow(string organization_name, string business_address, string BIN, string challan_id, DateTime challan_date, string challan_no, string item_name, string unit_code, double quantity, double unitPrice, double totalSd, double totalVat, double TotalPrice, string Filter)
            {
                FinishGoodProdutionData.FinishGoodProdutionDataRow finishGoodProdutionDataRow = (FinishGoodProdutionData.FinishGoodProdutionDataRow)base.NewRow();
                object[] organizationName = new object[] { organization_name, business_address, BIN, challan_id, challan_date, challan_no, item_name, unit_code, quantity, unitPrice, totalSd, totalVat, TotalPrice, Filter };
                finishGoodProdutionDataRow.ItemArray = organizationName;
                base.Rows.Add(finishGoodProdutionDataRow);
                return finishGoodProdutionDataRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                FinishGoodProdutionData.FinishGoodProdutionDataDataTable finishGoodProdutionDataDataTable = (FinishGoodProdutionData.FinishGoodProdutionDataDataTable)base.Clone();
                finishGoodProdutionDataDataTable.InitVars();
                return finishGoodProdutionDataDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new FinishGoodProdutionData.FinishGoodProdutionDataDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(FinishGoodProdutionData.FinishGoodProdutionDataRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                FinishGoodProdutionData finishGoodProdutionDatum = new FinishGoodProdutionData();
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
                    FixedValue = finishGoodProdutionDatum.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "FinishGoodProdutionDataDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = finishGoodProdutionDatum.GetSchemaSerializable();
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
                this.columnchallan_date = new DataColumn("challan_date", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_date);
                this.columnchallan_no = new DataColumn("challan_no", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_no);
                this.columnitem_name = new DataColumn("item_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnitem_name);
                this.columnunit_code = new DataColumn("unit_code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnunit_code);
                this.columnquantity = new DataColumn("quantity", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnquantity);
                this.columnunitPrice = new DataColumn("unitPrice", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnunitPrice);
                this.columntotalSd = new DataColumn("totalSd", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columntotalSd);
                this.columntotalVat = new DataColumn("totalVat", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columntotalVat);
                this.columnTotalPrice = new DataColumn("TotalPrice", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTotalPrice);
                this.columnFilter = new DataColumn("Filter", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnFilter);
                base.ExtendedProperties.Add("Generator_TablePropName", "_FinishGoodProdutionData");
                base.ExtendedProperties.Add("Generator_UserTableName", "FinishGoodProdutionData");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnorganization_name = base.Columns["organization_name"];
                this.columnbusiness_address = base.Columns["business_address"];
                this.columnBIN = base.Columns["BIN"];
                this.columnchallan_id = base.Columns["challan_id"];
                this.columnchallan_date = base.Columns["challan_date"];
                this.columnchallan_no = base.Columns["challan_no"];
                this.columnitem_name = base.Columns["item_name"];
                this.columnunit_code = base.Columns["unit_code"];
                this.columnquantity = base.Columns["quantity"];
                this.columnunitPrice = base.Columns["unitPrice"];
                this.columntotalSd = base.Columns["totalSd"];
                this.columntotalVat = base.Columns["totalVat"];
                this.columnTotalPrice = base.Columns["TotalPrice"];
                this.columnFilter = base.Columns["Filter"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public FinishGoodProdutionData.FinishGoodProdutionDataRow NewFinishGoodProdutionDataRow()
            {
                return (FinishGoodProdutionData.FinishGoodProdutionDataRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new FinishGoodProdutionData.FinishGoodProdutionDataRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.FinishGoodProdutionDataRowChanged != null)
                {
                    this.FinishGoodProdutionDataRowChanged(this, new FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEvent((FinishGoodProdutionData.FinishGoodProdutionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.FinishGoodProdutionDataRowChanging != null)
                {
                    this.FinishGoodProdutionDataRowChanging(this, new FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEvent((FinishGoodProdutionData.FinishGoodProdutionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.FinishGoodProdutionDataRowDeleted != null)
                {
                    this.FinishGoodProdutionDataRowDeleted(this, new FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEvent((FinishGoodProdutionData.FinishGoodProdutionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.FinishGoodProdutionDataRowDeleting != null)
                {
                    this.FinishGoodProdutionDataRowDeleting(this, new FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEvent((FinishGoodProdutionData.FinishGoodProdutionDataRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveFinishGoodProdutionDataRow(FinishGoodProdutionData.FinishGoodProdutionDataRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEventHandler FinishGoodProdutionDataRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEventHandler FinishGoodProdutionDataRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEventHandler FinishGoodProdutionDataRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEventHandler FinishGoodProdutionDataRowDeleting;
        }

        public class FinishGoodProdutionDataRow : DataRow
        {
            private FinishGoodProdutionData.FinishGoodProdutionDataDataTable tableFinishGoodProdutionData;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string BIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableFinishGoodProdutionData.BINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'BIN' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.BINColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.business_addressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'business_address' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.business_addressColumn] = value;
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
                        item = (DateTime)base[this.tableFinishGoodProdutionData.challan_dateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_date' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.challan_dateColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.challan_idColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_id' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.challan_idColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.challan_noColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_no' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.challan_noColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.FilterColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Filter' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.FilterColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.item_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'item_name' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.item_nameColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.organization_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'organization_name' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.organization_nameColumn] = value;
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
                        item = (double)base[this.tableFinishGoodProdutionData.quantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'quantity' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.quantityColumn] = value;
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
                        item = (double)base[this.tableFinishGoodProdutionData.TotalPriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TotalPrice' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.TotalPriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double totalSd
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableFinishGoodProdutionData.totalSdColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'totalSd' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.totalSdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double totalVat
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableFinishGoodProdutionData.totalVatColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'totalVat' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.totalVatColumn] = value;
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
                        item = (string)base[this.tableFinishGoodProdutionData.unit_codeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'unit_code' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.unit_codeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double unitPrice
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableFinishGoodProdutionData.unitPriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'unitPrice' in table 'FinishGoodProdutionData' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableFinishGoodProdutionData.unitPriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal FinishGoodProdutionDataRow(DataRowBuilder rb) : base(rb)
            {
                this.tableFinishGoodProdutionData = (FinishGoodProdutionData.FinishGoodProdutionDataDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBINNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.BINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbusiness_addressNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.business_addressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_dateNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.challan_dateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_idNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.challan_idColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_noNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.challan_noColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsFilterNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.FilterColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isitem_nameNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.item_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isorganization_nameNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.organization_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsquantityNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.quantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTotalPriceNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.TotalPriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IstotalSdNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.totalSdColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IstotalVatNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.totalVatColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isunit_codeNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.unit_codeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsunitPriceNull()
            {
                return base.IsNull(this.tableFinishGoodProdutionData.unitPriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBINNull()
            {
                base[this.tableFinishGoodProdutionData.BINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbusiness_addressNull()
            {
                base[this.tableFinishGoodProdutionData.business_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_dateNull()
            {
                base[this.tableFinishGoodProdutionData.challan_dateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_idNull()
            {
                base[this.tableFinishGoodProdutionData.challan_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_noNull()
            {
                base[this.tableFinishGoodProdutionData.challan_noColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetFilterNull()
            {
                base[this.tableFinishGoodProdutionData.FilterColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setitem_nameNull()
            {
                base[this.tableFinishGoodProdutionData.item_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setorganization_nameNull()
            {
                base[this.tableFinishGoodProdutionData.organization_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetquantityNull()
            {
                base[this.tableFinishGoodProdutionData.quantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTotalPriceNull()
            {
                base[this.tableFinishGoodProdutionData.TotalPriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SettotalSdNull()
            {
                base[this.tableFinishGoodProdutionData.totalSdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SettotalVatNull()
            {
                base[this.tableFinishGoodProdutionData.totalVatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setunit_codeNull()
            {
                base[this.tableFinishGoodProdutionData.unit_codeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetunitPriceNull()
            {
                base[this.tableFinishGoodProdutionData.unitPriceColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class FinishGoodProdutionDataRowChangeEvent : EventArgs
        {
            private FinishGoodProdutionData.FinishGoodProdutionDataRow eventRow;

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
            public FinishGoodProdutionData.FinishGoodProdutionDataRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public FinishGoodProdutionDataRowChangeEvent(FinishGoodProdutionData.FinishGoodProdutionDataRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void FinishGoodProdutionDataRowChangeEventHandler(object sender, FinishGoodProdutionData.FinishGoodProdutionDataRowChangeEvent e);
    }
}


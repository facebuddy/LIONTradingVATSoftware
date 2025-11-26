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
    [XmlRoot("Stock_Declaration")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class Stock_Declaration : DataSet
    {
        private Stock_Declaration.Stock_Declaration_rptDataTable tableStock_Declaration_rpt;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

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

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Stock_Declaration.Stock_Declaration_rptDataTable Stock_Declaration_rpt
        {
            get
            {
                return this.tableStock_Declaration_rpt;
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
        public Stock_Declaration()
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
        protected Stock_Declaration(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Stock_Declaration_rpt"] != null)
                {
                    base.Tables.Add(new Stock_Declaration.Stock_Declaration_rptDataTable(dataSet.Tables["Stock_Declaration_rpt"]));
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
            Stock_Declaration schemaSerializationMode = (Stock_Declaration)base.Clone();
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
            Stock_Declaration stockDeclaration = new Stock_Declaration();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = stockDeclaration.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = stockDeclaration.GetSchemaSerializable();
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
            base.DataSetName = "Stock_Declaration";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Stock_Declaration.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableStock_Declaration_rpt = new Stock_Declaration.Stock_Declaration_rptDataTable();
            base.Tables.Add(this.tableStock_Declaration_rpt);
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
            this.tableStock_Declaration_rpt = (Stock_Declaration.Stock_Declaration_rptDataTable)base.Tables["Stock_Declaration_rpt"];
            if (initTable && this.tableStock_Declaration_rpt != null)
            {
                this.tableStock_Declaration_rpt.InitVars();
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
            if (dataSet.Tables["Stock_Declaration_rpt"] != null)
            {
                base.Tables.Add(new Stock_Declaration.Stock_Declaration_rptDataTable(dataSet.Tables["Stock_Declaration_rpt"]));
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
        protected override bool ShouldSerializeRelations()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeStock_Declaration_rpt()
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
        public class Stock_Declaration_rptDataTable : TypedTableBase<Stock_Declaration.Stock_Declaration_rptRow>
        {
            private DataColumn columnOrgName;

            private DataColumn columnOrgAddress;

            private DataColumn columnOrgBIN;

            private DataColumn columnOrgTelephone;

            private DataColumn columnOrgArea;

            private DataColumn columnOrgBusinessActivity;

            private DataColumn columnDeclaration_Date;

            private DataColumn columnSl_No_1;

            private DataColumn columnHS_Code;

            private DataColumn columnGoods_Name;

            private DataColumn columnGoods_Description_2;

            private DataColumn columnStock_Amount_3;

            private DataColumn columnStock_Price_4;

            private DataColumn columnAvg_Price_of_Stock_5;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Avg_Price_of_Stock_5Column
            {
                get
                {
                    return this.columnAvg_Price_of_Stock_5;
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
            public DataColumn Declaration_DateColumn
            {
                get
                {
                    return this.columnDeclaration_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_Description_2Column
            {
                get
                {
                    return this.columnGoods_Description_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_NameColumn
            {
                get
                {
                    return this.columnGoods_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn HS_CodeColumn
            {
                get
                {
                    return this.columnHS_Code;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Stock_Declaration.Stock_Declaration_rptRow this[int index]
            {
                get
                {
                    return (Stock_Declaration.Stock_Declaration_rptRow)base.Rows[index];
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
            public DataColumn OrgAreaColumn
            {
                get
                {
                    return this.columnOrgArea;
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
            public DataColumn OrgBusinessActivityColumn
            {
                get
                {
                    return this.columnOrgBusinessActivity;
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
            public DataColumn OrgTelephoneColumn
            {
                get
                {
                    return this.columnOrgTelephone;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sl_No_1Column
            {
                get
                {
                    return this.columnSl_No_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Stock_Amount_3Column
            {
                get
                {
                    return this.columnStock_Amount_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Stock_Price_4Column
            {
                get
                {
                    return this.columnStock_Price_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Stock_Declaration_rptDataTable()
            {
                base.TableName = "Stock_Declaration_rpt";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Stock_Declaration_rptDataTable(DataTable table)
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
            protected Stock_Declaration_rptDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddStock_Declaration_rptRow(Stock_Declaration.Stock_Declaration_rptRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Stock_Declaration.Stock_Declaration_rptRow AddStock_Declaration_rptRow(string OrgName, string OrgAddress, string OrgBIN, string OrgTelephone, string OrgArea, string OrgBusinessActivity, DateTime Declaration_Date, string HS_Code, string Goods_Name, string Goods_Description_2, double Stock_Amount_3, double Stock_Price_4, double Avg_Price_of_Stock_5)
            {
                Stock_Declaration.Stock_Declaration_rptRow stockDeclarationRptRow = (Stock_Declaration.Stock_Declaration_rptRow)base.NewRow();
                object[] orgName = new object[] { OrgName, OrgAddress, OrgBIN, OrgTelephone, OrgArea, OrgBusinessActivity, Declaration_Date, null, HS_Code, Goods_Name, Goods_Description_2, Stock_Amount_3, Stock_Price_4, Avg_Price_of_Stock_5 };
                stockDeclarationRptRow.ItemArray = orgName;
                base.Rows.Add(stockDeclarationRptRow);
                return stockDeclarationRptRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Stock_Declaration.Stock_Declaration_rptDataTable stockDeclarationRptDataTable = (Stock_Declaration.Stock_Declaration_rptDataTable)base.Clone();
                stockDeclarationRptDataTable.InitVars();
                return stockDeclarationRptDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new Stock_Declaration.Stock_Declaration_rptDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Stock_Declaration.Stock_Declaration_rptRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                Stock_Declaration stockDeclaration = new Stock_Declaration();
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
                    FixedValue = stockDeclaration.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Stock_Declaration_rptDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = stockDeclaration.GetSchemaSerializable();
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
                this.columnOrgTelephone = new DataColumn("OrgTelephone", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgTelephone);
                this.columnOrgArea = new DataColumn("OrgArea", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgArea);
                this.columnOrgBusinessActivity = new DataColumn("OrgBusinessActivity", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgBusinessActivity);
                this.columnDeclaration_Date = new DataColumn("Declaration_Date", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnDeclaration_Date);
                this.columnSl_No_1 = new DataColumn("Sl_No_1", typeof(short), null, MappingType.Element);
                base.Columns.Add(this.columnSl_No_1);
                this.columnHS_Code = new DataColumn("HS_Code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnHS_Code);
                this.columnGoods_Name = new DataColumn("Goods_Name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Name);
                this.columnGoods_Description_2 = new DataColumn("Goods_Description_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Description_2);
                this.columnStock_Amount_3 = new DataColumn("Stock_Amount_3", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnStock_Amount_3);
                this.columnStock_Price_4 = new DataColumn("Stock_Price_4", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnStock_Price_4);
                this.columnAvg_Price_of_Stock_5 = new DataColumn("Avg_Price_of_Stock_5", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnAvg_Price_of_Stock_5);
                this.columnSl_No_1.AutoIncrement = true;
                this.columnSl_No_1.AutoIncrementSeed = (long)-1;
                this.columnSl_No_1.AutoIncrementStep = (long)-1;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnOrgBIN = base.Columns["OrgBIN"];
                this.columnOrgTelephone = base.Columns["OrgTelephone"];
                this.columnOrgArea = base.Columns["OrgArea"];
                this.columnOrgBusinessActivity = base.Columns["OrgBusinessActivity"];
                this.columnDeclaration_Date = base.Columns["Declaration_Date"];
                this.columnSl_No_1 = base.Columns["Sl_No_1"];
                this.columnHS_Code = base.Columns["HS_Code"];
                this.columnGoods_Name = base.Columns["Goods_Name"];
                this.columnGoods_Description_2 = base.Columns["Goods_Description_2"];
                this.columnStock_Amount_3 = base.Columns["Stock_Amount_3"];
                this.columnStock_Price_4 = base.Columns["Stock_Price_4"];
                this.columnAvg_Price_of_Stock_5 = base.Columns["Avg_Price_of_Stock_5"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Stock_Declaration.Stock_Declaration_rptRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Stock_Declaration.Stock_Declaration_rptRow NewStock_Declaration_rptRow()
            {
                return (Stock_Declaration.Stock_Declaration_rptRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Stock_Declaration_rptRowChanged != null)
                {
                    this.Stock_Declaration_rptRowChanged(this, new Stock_Declaration.Stock_Declaration_rptRowChangeEvent((Stock_Declaration.Stock_Declaration_rptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Stock_Declaration_rptRowChanging != null)
                {
                    this.Stock_Declaration_rptRowChanging(this, new Stock_Declaration.Stock_Declaration_rptRowChangeEvent((Stock_Declaration.Stock_Declaration_rptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Stock_Declaration_rptRowDeleted != null)
                {
                    this.Stock_Declaration_rptRowDeleted(this, new Stock_Declaration.Stock_Declaration_rptRowChangeEvent((Stock_Declaration.Stock_Declaration_rptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Stock_Declaration_rptRowDeleting != null)
                {
                    this.Stock_Declaration_rptRowDeleting(this, new Stock_Declaration.Stock_Declaration_rptRowChangeEvent((Stock_Declaration.Stock_Declaration_rptRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveStock_Declaration_rptRow(Stock_Declaration.Stock_Declaration_rptRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Stock_Declaration.Stock_Declaration_rptRowChangeEventHandler Stock_Declaration_rptRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Stock_Declaration.Stock_Declaration_rptRowChangeEventHandler Stock_Declaration_rptRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Stock_Declaration.Stock_Declaration_rptRowChangeEventHandler Stock_Declaration_rptRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Stock_Declaration.Stock_Declaration_rptRowChangeEventHandler Stock_Declaration_rptRowDeleting;
        }

        public class Stock_Declaration_rptRow : DataRow
        {
            private Stock_Declaration.Stock_Declaration_rptDataTable tableStock_Declaration_rpt;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Avg_Price_of_Stock_5
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableStock_Declaration_rpt.Avg_Price_of_Stock_5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Avg_Price_of_Stock_5' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Avg_Price_of_Stock_5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime Declaration_Date
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tableStock_Declaration_rpt.Declaration_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Declaration_Date' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Declaration_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_Description_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableStock_Declaration_rpt.Goods_Description_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Description_2' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Goods_Description_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableStock_Declaration_rpt.Goods_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Name' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Goods_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string HS_Code
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableStock_Declaration_rpt.HS_CodeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'HS_Code' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.HS_CodeColumn] = value;
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
                        item = (string)base[this.tableStock_Declaration_rpt.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.OrgAddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgArea
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableStock_Declaration_rpt.OrgAreaColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgArea' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.OrgAreaColumn] = value;
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
                        item = (string)base[this.tableStock_Declaration_rpt.OrgBINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgBIN' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.OrgBINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgBusinessActivity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableStock_Declaration_rpt.OrgBusinessActivityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgBusinessActivity' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.OrgBusinessActivityColumn] = value;
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
                        item = (string)base[this.tableStock_Declaration_rpt.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.OrgNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgTelephone
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableStock_Declaration_rpt.OrgTelephoneColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgTelephone' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.OrgTelephoneColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public short Sl_No_1
            {
                get
                {
                    short item;
                    try
                    {
                        item = (short)base[this.tableStock_Declaration_rpt.Sl_No_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sl_No_1' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Sl_No_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Stock_Amount_3
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableStock_Declaration_rpt.Stock_Amount_3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Stock_Amount_3' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Stock_Amount_3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Stock_Price_4
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableStock_Declaration_rpt.Stock_Price_4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Stock_Price_4' in table 'Stock_Declaration_rpt' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableStock_Declaration_rpt.Stock_Price_4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Stock_Declaration_rptRow(DataRowBuilder rb) : base(rb)
            {
                this.tableStock_Declaration_rpt = (Stock_Declaration.Stock_Declaration_rptDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsAvg_Price_of_Stock_5Null()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Avg_Price_of_Stock_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDeclaration_DateNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Declaration_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_Description_2Null()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Goods_Description_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_NameNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Goods_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsHS_CodeNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.HS_CodeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAreaNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.OrgAreaColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgBINNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.OrgBINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgBusinessActivityNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.OrgBusinessActivityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgTelephoneNull()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.OrgTelephoneColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSl_No_1Null()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Sl_No_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStock_Amount_3Null()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Stock_Amount_3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsStock_Price_4Null()
            {
                return base.IsNull(this.tableStock_Declaration_rpt.Stock_Price_4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetAvg_Price_of_Stock_5Null()
            {
                base[this.tableStock_Declaration_rpt.Avg_Price_of_Stock_5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDeclaration_DateNull()
            {
                base[this.tableStock_Declaration_rpt.Declaration_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_Description_2Null()
            {
                base[this.tableStock_Declaration_rpt.Goods_Description_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_NameNull()
            {
                base[this.tableStock_Declaration_rpt.Goods_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetHS_CodeNull()
            {
                base[this.tableStock_Declaration_rpt.HS_CodeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tableStock_Declaration_rpt.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAreaNull()
            {
                base[this.tableStock_Declaration_rpt.OrgAreaColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgBINNull()
            {
                base[this.tableStock_Declaration_rpt.OrgBINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgBusinessActivityNull()
            {
                base[this.tableStock_Declaration_rpt.OrgBusinessActivityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tableStock_Declaration_rpt.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgTelephoneNull()
            {
                base[this.tableStock_Declaration_rpt.OrgTelephoneColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSl_No_1Null()
            {
                base[this.tableStock_Declaration_rpt.Sl_No_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetStock_Amount_3Null()
            {
                base[this.tableStock_Declaration_rpt.Stock_Amount_3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetStock_Price_4Null()
            {
                base[this.tableStock_Declaration_rpt.Stock_Price_4Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Stock_Declaration_rptRowChangeEvent : EventArgs
        {
            private Stock_Declaration.Stock_Declaration_rptRow eventRow;

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
            public Stock_Declaration.Stock_Declaration_rptRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Stock_Declaration_rptRowChangeEvent(Stock_Declaration.Stock_Declaration_rptRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Stock_Declaration_rptRowChangeEventHandler(object sender, Stock_Declaration.Stock_Declaration_rptRowChangeEvent e);
    }
}

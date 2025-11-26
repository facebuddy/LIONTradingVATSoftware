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
    [XmlRoot("OrgInfoDS")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class OrgInfoDS : DataSet
    {
        private OrgInfoDS.CountryDataTable tableCountry;

        private OrgInfoDS.dtSaleChallanDataTable tabledtSaleChallan;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public OrgInfoDS.CountryDataTable Country
        {
            get
            {
                return this.tableCountry;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public OrgInfoDS.dtSaleChallanDataTable dtSaleChallan
        {
            get
            {
                return this.tabledtSaleChallan;
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
        public OrgInfoDS()
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
        protected OrgInfoDS(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Country"] != null)
                {
                    base.Tables.Add(new OrgInfoDS.CountryDataTable(dataSet.Tables["Country"]));
                }
                if (dataSet.Tables["dtSaleChallan"] != null)
                {
                    base.Tables.Add(new OrgInfoDS.dtSaleChallanDataTable(dataSet.Tables["dtSaleChallan"]));
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
            OrgInfoDS schemaSerializationMode = (OrgInfoDS)base.Clone();
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
            OrgInfoDS orgInfoD = new OrgInfoDS();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = orgInfoD.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = orgInfoD.GetSchemaSerializable();
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
            base.DataSetName = "OrgInfoDS";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/OrgInfoDS.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableCountry = new OrgInfoDS.CountryDataTable();
            base.Tables.Add(this.tableCountry);
            this.tabledtSaleChallan = new OrgInfoDS.dtSaleChallanDataTable();
            base.Tables.Add(this.tabledtSaleChallan);
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
            this.tableCountry = (OrgInfoDS.CountryDataTable)base.Tables["Country"];
            if (initTable && this.tableCountry != null)
            {
                this.tableCountry.InitVars();
            }
            this.tabledtSaleChallan = (OrgInfoDS.dtSaleChallanDataTable)base.Tables["dtSaleChallan"];
            if (initTable && this.tabledtSaleChallan != null)
            {
                this.tabledtSaleChallan.InitVars();
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
            if (dataSet.Tables["Country"] != null)
            {
                base.Tables.Add(new OrgInfoDS.CountryDataTable(dataSet.Tables["Country"]));
            }
            if (dataSet.Tables["dtSaleChallan"] != null)
            {
                base.Tables.Add(new OrgInfoDS.dtSaleChallanDataTable(dataSet.Tables["dtSaleChallan"]));
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
        private bool ShouldSerializeCountry()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializedtSaleChallan()
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
        public class CountryDataTable : TypedTableBase<OrgInfoDS.CountryRow>
        {
            private DataColumn columnpurchase_lprice;

            private DataColumn columnpurchase_ltax;

            private DataColumn columnpurchase_imprice;

            private DataColumn columnpurchase_imtax;

            private DataColumn columnpurchase_exprice;

            private DataColumn columnpurchase_extax;

            private DataColumn columnpurchase_exmprice;

            private DataColumn columnpurchase_exmtax;

            private DataColumn columnsalePrice;

            private DataColumn columnsaleSD;

            private DataColumn columnsaleVAT;

            private DataColumn columnsaleExm;

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
            public OrgInfoDS.CountryRow this[int index]
            {
                get
                {
                    return (OrgInfoDS.CountryRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_exmpriceColumn
            {
                get
                {
                    return this.columnpurchase_exmprice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_exmtaxColumn
            {
                get
                {
                    return this.columnpurchase_exmtax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_expriceColumn
            {
                get
                {
                    return this.columnpurchase_exprice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_extaxColumn
            {
                get
                {
                    return this.columnpurchase_extax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_impriceColumn
            {
                get
                {
                    return this.columnpurchase_imprice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_imtaxColumn
            {
                get
                {
                    return this.columnpurchase_imtax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_lpriceColumn
            {
                get
                {
                    return this.columnpurchase_lprice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_ltaxColumn
            {
                get
                {
                    return this.columnpurchase_ltax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn saleExmColumn
            {
                get
                {
                    return this.columnsaleExm;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn salePriceColumn
            {
                get
                {
                    return this.columnsalePrice;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn saleSDColumn
            {
                get
                {
                    return this.columnsaleSD;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn saleVATColumn
            {
                get
                {
                    return this.columnsaleVAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CountryDataTable()
            {
                base.TableName = "Country";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CountryDataTable(DataTable table)
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
            protected CountryDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddCountryRow(OrgInfoDS.CountryRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public OrgInfoDS.CountryRow AddCountryRow(string purchase_lprice, string purchase_ltax, string purchase_imprice, string purchase_imtax, string purchase_exprice, string purchase_extax, string purchase_exmprice, string purchase_exmtax, string salePrice, string saleSD, string saleVAT, string saleExm)
            {
                OrgInfoDS.CountryRow countryRow = (OrgInfoDS.CountryRow)base.NewRow();
                object[] purchaseLprice = new object[] { purchase_lprice, purchase_ltax, purchase_imprice, purchase_imtax, purchase_exprice, purchase_extax, purchase_exmprice, purchase_exmtax, salePrice, saleSD, saleVAT, saleExm };
                countryRow.ItemArray = purchaseLprice;
                base.Rows.Add(countryRow);
                return countryRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                OrgInfoDS.CountryDataTable countryDataTable = (OrgInfoDS.CountryDataTable)base.Clone();
                countryDataTable.InitVars();
                return countryDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new OrgInfoDS.CountryDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(OrgInfoDS.CountryRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                OrgInfoDS orgInfoD = new OrgInfoDS();
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
                    FixedValue = orgInfoD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "CountryDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = orgInfoD.GetSchemaSerializable();
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
                this.columnpurchase_lprice = new DataColumn("purchase_lprice", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_lprice);
                this.columnpurchase_ltax = new DataColumn("purchase_ltax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_ltax);
                this.columnpurchase_imprice = new DataColumn("purchase_imprice", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_imprice);
                this.columnpurchase_imtax = new DataColumn("purchase_imtax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_imtax);
                this.columnpurchase_exprice = new DataColumn("purchase_exprice", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_exprice);
                this.columnpurchase_extax = new DataColumn("purchase_extax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_extax);
                this.columnpurchase_exmprice = new DataColumn("purchase_exmprice", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_exmprice);
                this.columnpurchase_exmtax = new DataColumn("purchase_exmtax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_exmtax);
                this.columnsalePrice = new DataColumn("salePrice", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnsalePrice);
                this.columnsaleSD = new DataColumn("saleSD", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnsaleSD);
                this.columnsaleVAT = new DataColumn("saleVAT", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnsaleVAT);
                this.columnsaleExm = new DataColumn("saleExm", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnsaleExm);
                this.columnpurchase_lprice.Caption = "Sl_No_1";
                this.columnpurchase_ltax.Caption = "HS_Code_2";
                this.columnpurchase_imprice.Caption = "Goods_Name_3";
                this.columnpurchase_imtax.Caption = "Goods_Description_31";
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnpurchase_lprice = base.Columns["purchase_lprice"];
                this.columnpurchase_ltax = base.Columns["purchase_ltax"];
                this.columnpurchase_imprice = base.Columns["purchase_imprice"];
                this.columnpurchase_imtax = base.Columns["purchase_imtax"];
                this.columnpurchase_exprice = base.Columns["purchase_exprice"];
                this.columnpurchase_extax = base.Columns["purchase_extax"];
                this.columnpurchase_exmprice = base.Columns["purchase_exmprice"];
                this.columnpurchase_exmtax = base.Columns["purchase_exmtax"];
                this.columnsalePrice = base.Columns["salePrice"];
                this.columnsaleSD = base.Columns["saleSD"];
                this.columnsaleVAT = base.Columns["saleVAT"];
                this.columnsaleExm = base.Columns["saleExm"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public OrgInfoDS.CountryRow NewCountryRow()
            {
                return (OrgInfoDS.CountryRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OrgInfoDS.CountryRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.CountryRowChanged != null)
                {
                    this.CountryRowChanged(this, new OrgInfoDS.CountryRowChangeEvent((OrgInfoDS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.CountryRowChanging != null)
                {
                    this.CountryRowChanging(this, new OrgInfoDS.CountryRowChangeEvent((OrgInfoDS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.CountryRowDeleted != null)
                {
                    this.CountryRowDeleted(this, new OrgInfoDS.CountryRowChangeEvent((OrgInfoDS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.CountryRowDeleting != null)
                {
                    this.CountryRowDeleting(this, new OrgInfoDS.CountryRowChangeEvent((OrgInfoDS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCountryRow(OrgInfoDS.CountryRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.CountryRowChangeEventHandler CountryRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.CountryRowChangeEventHandler CountryRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.CountryRowChangeEventHandler CountryRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.CountryRowChangeEventHandler CountryRowDeleting;
        }

        public class CountryRow : DataRow
        {
            private OrgInfoDS.CountryDataTable tableCountry;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_exmprice
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_exmpriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_exmprice' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_exmpriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_exmtax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_exmtaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_exmtax' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_exmtaxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_exprice
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_expriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_exprice' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_expriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_extax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_extaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_extax' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_extaxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_imprice
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_impriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_imprice' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_impriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_imtax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_imtaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_imtax' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_imtaxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_lprice
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_lpriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_lprice' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_lpriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchase_ltax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.purchase_ltaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_ltax' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.purchase_ltaxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string saleExm
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.saleExmColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'saleExm' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.saleExmColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string salePrice
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.salePriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'salePrice' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.salePriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string saleSD
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.saleSDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'saleSD' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.saleSDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string saleVAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.saleVATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'saleVAT' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.saleVATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CountryRow(DataRowBuilder rb) : base(rb)
            {
                this.tableCountry = (OrgInfoDS.CountryDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_exmpriceNull()
            {
                return base.IsNull(this.tableCountry.purchase_exmpriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_exmtaxNull()
            {
                return base.IsNull(this.tableCountry.purchase_exmtaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_expriceNull()
            {
                return base.IsNull(this.tableCountry.purchase_expriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_extaxNull()
            {
                return base.IsNull(this.tableCountry.purchase_extaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_impriceNull()
            {
                return base.IsNull(this.tableCountry.purchase_impriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_imtaxNull()
            {
                return base.IsNull(this.tableCountry.purchase_imtaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_lpriceNull()
            {
                return base.IsNull(this.tableCountry.purchase_lpriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_ltaxNull()
            {
                return base.IsNull(this.tableCountry.purchase_ltaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IssaleExmNull()
            {
                return base.IsNull(this.tableCountry.saleExmColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IssalePriceNull()
            {
                return base.IsNull(this.tableCountry.salePriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IssaleSDNull()
            {
                return base.IsNull(this.tableCountry.saleSDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IssaleVATNull()
            {
                return base.IsNull(this.tableCountry.saleVATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_exmpriceNull()
            {
                base[this.tableCountry.purchase_exmpriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_exmtaxNull()
            {
                base[this.tableCountry.purchase_exmtaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_expriceNull()
            {
                base[this.tableCountry.purchase_expriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_extaxNull()
            {
                base[this.tableCountry.purchase_extaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_impriceNull()
            {
                base[this.tableCountry.purchase_impriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_imtaxNull()
            {
                base[this.tableCountry.purchase_imtaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_lpriceNull()
            {
                base[this.tableCountry.purchase_lpriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_ltaxNull()
            {
                base[this.tableCountry.purchase_ltaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetsaleExmNull()
            {
                base[this.tableCountry.saleExmColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetsalePriceNull()
            {
                base[this.tableCountry.salePriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetsaleSDNull()
            {
                base[this.tableCountry.saleSDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetsaleVATNull()
            {
                base[this.tableCountry.saleVATColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class CountryRowChangeEvent : EventArgs
        {
            private OrgInfoDS.CountryRow eventRow;

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
            public OrgInfoDS.CountryRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CountryRowChangeEvent(OrgInfoDS.CountryRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void CountryRowChangeEventHandler(object sender, OrgInfoDS.CountryRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class dtSaleChallanDataTable : TypedTableBase<OrgInfoDS.dtSaleChallanRow>
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

            private DataColumn columnPARTY_NAME;

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
            public OrgInfoDS.dtSaleChallanRow this[int index]
            {
                get
                {
                    return (OrgInfoDS.dtSaleChallanRow)base.Rows[index];
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
            public DataColumn PARTY_NAMEColumn
            {
                get
                {
                    return this.columnPARTY_NAME;
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
            public void AdddtSaleChallanRow(OrgInfoDS.dtSaleChallanRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public OrgInfoDS.dtSaleChallanRow AdddtSaleChallanRow(string TRANS_TYPE, int CHALLAN_ID, DateTime DATE_CHALLAN, int ITEM_ID, string ITEM_NAME, double OPENING_STOCK, double TOTAL_OPENING_PRICE, double QUANTITY, double UNIT_PRICE, double TOTAL_PRICE, double TOTAL_SD, double TOTAL_VAT, string PARTY_NAME, string PARTY_TIN, string PARTY_ADDRESS, string CHALLAN_NO, double SALE_QTY, double TOTAL_SALE_PRICE, string UNIT_CODE, string REMARKS, double TOTAL_PURCHASE_PRICE)
            {
                OrgInfoDS.dtSaleChallanRow _dtSaleChallanRow = (OrgInfoDS.dtSaleChallanRow)base.NewRow();
                object[] tRANSTYPE = new object[] { TRANS_TYPE, CHALLAN_ID, DATE_CHALLAN, ITEM_ID, ITEM_NAME, OPENING_STOCK, TOTAL_OPENING_PRICE, QUANTITY, UNIT_PRICE, TOTAL_PRICE, TOTAL_SD, TOTAL_VAT, PARTY_NAME, PARTY_TIN, PARTY_ADDRESS, CHALLAN_NO, SALE_QTY, TOTAL_SALE_PRICE, UNIT_CODE, REMARKS, TOTAL_PURCHASE_PRICE };
                _dtSaleChallanRow.ItemArray = tRANSTYPE;
                base.Rows.Add(_dtSaleChallanRow);
                return _dtSaleChallanRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                OrgInfoDS.dtSaleChallanDataTable _dtSaleChallanDataTable = (OrgInfoDS.dtSaleChallanDataTable)base.Clone();
                _dtSaleChallanDataTable.InitVars();
                return _dtSaleChallanDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new OrgInfoDS.dtSaleChallanDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(OrgInfoDS.dtSaleChallanRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                OrgInfoDS orgInfoD = new OrgInfoDS();
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
                    FixedValue = orgInfoD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "dtSaleChallanDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = orgInfoD.GetSchemaSerializable();
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
                this.columnPARTY_NAME = new DataColumn("PARTY_NAME", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPARTY_NAME);
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
                this.columnTOTAL_PURCHASE_PRICE = new DataColumn("TOTAL_PURCHASE_PRICE", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTOTAL_PURCHASE_PRICE);
                this.columnPARTY_NAME.Caption = "SALE_PARTY_NAME";
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
                this.columnPARTY_NAME = base.Columns["PARTY_NAME"];
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
            public OrgInfoDS.dtSaleChallanRow NewdtSaleChallanRow()
            {
                return (OrgInfoDS.dtSaleChallanRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new OrgInfoDS.dtSaleChallanRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.dtSaleChallanRowChanged != null)
                {
                    this.dtSaleChallanRowChanged(this, new OrgInfoDS.dtSaleChallanRowChangeEvent((OrgInfoDS.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.dtSaleChallanRowChanging != null)
                {
                    this.dtSaleChallanRowChanging(this, new OrgInfoDS.dtSaleChallanRowChangeEvent((OrgInfoDS.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.dtSaleChallanRowDeleted != null)
                {
                    this.dtSaleChallanRowDeleted(this, new OrgInfoDS.dtSaleChallanRowChangeEvent((OrgInfoDS.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.dtSaleChallanRowDeleting != null)
                {
                    this.dtSaleChallanRowDeleting(this, new OrgInfoDS.dtSaleChallanRowChangeEvent((OrgInfoDS.dtSaleChallanRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovedtSaleChallanRow(OrgInfoDS.dtSaleChallanRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.dtSaleChallanRowChangeEventHandler dtSaleChallanRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.dtSaleChallanRowChangeEventHandler dtSaleChallanRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.dtSaleChallanRowChangeEventHandler dtSaleChallanRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event OrgInfoDS.dtSaleChallanRowChangeEventHandler dtSaleChallanRowDeleting;
        }

        public class dtSaleChallanRow : DataRow
        {
            private OrgInfoDS.dtSaleChallanDataTable tabledtSaleChallan;

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
            public string PARTY_NAME
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabledtSaleChallan.PARTY_NAMEColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PARTY_NAME' in table 'dtSaleChallan' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabledtSaleChallan.PARTY_NAMEColumn] = value;
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
            public double TOTAL_PURCHASE_PRICE
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tabledtSaleChallan.TOTAL_PURCHASE_PRICEColumn];
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
                this.tabledtSaleChallan = (OrgInfoDS.dtSaleChallanDataTable)base.Table;
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
            public bool IsPARTY_NAMENull()
            {
                return base.IsNull(this.tabledtSaleChallan.PARTY_NAMEColumn);
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
            public void SetPARTY_NAMENull()
            {
                base[this.tabledtSaleChallan.PARTY_NAMEColumn] = Convert.DBNull;
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
            private OrgInfoDS.dtSaleChallanRow eventRow;

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
            public OrgInfoDS.dtSaleChallanRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public dtSaleChallanRowChangeEvent(OrgInfoDS.dtSaleChallanRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void dtSaleChallanRowChangeEventHandler(object sender, OrgInfoDS.dtSaleChallanRowChangeEvent e);
    }
}


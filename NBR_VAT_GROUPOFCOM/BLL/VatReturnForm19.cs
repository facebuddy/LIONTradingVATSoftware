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
    [XmlRoot("VatReturnForm19")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class VatReturnForm19 : DataSet
    {
        private VatReturnForm19.VatReturnForm19DataTable tableVatReturnForm19;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public VatReturnForm19.VatReturnForm19DataTable _VatReturnForm19
        {
            get
            {
                return this.tableVatReturnForm19;
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
        public VatReturnForm19()
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
        protected VatReturnForm19(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["VatReturnForm19"] != null)
                {
                    base.Tables.Add(new VatReturnForm19.VatReturnForm19DataTable(dataSet.Tables["VatReturnForm19"]));
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
            VatReturnForm19 schemaSerializationMode = (VatReturnForm19)base.Clone();
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
            VatReturnForm19 vatReturnForm19 = new VatReturnForm19();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = vatReturnForm19.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = vatReturnForm19.GetSchemaSerializable();
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
            base.DataSetName = "VatReturnForm19";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/VatReturnForm19.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableVatReturnForm19 = new VatReturnForm19.VatReturnForm19DataTable();
            base.Tables.Add(this.tableVatReturnForm19);
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
            this.tableVatReturnForm19 = (VatReturnForm19.VatReturnForm19DataTable)base.Tables["VatReturnForm19"];
            if (initTable && this.tableVatReturnForm19 != null)
            {
                this.tableVatReturnForm19.InitVars();
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
            if (dataSet.Tables["VatReturnForm19"] != null)
            {
                base.Tables.Add(new VatReturnForm19.VatReturnForm19DataTable(dataSet.Tables["VatReturnForm19"]));
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
        private bool ShouldSerialize_VatReturnForm19()
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
        public class VatReturnForm19DataTable : TypedTableBase<VatReturnForm19.VatReturnForm19Row>
        {
            private DataColumn columnsale_price;

            private DataColumn columnsale_sd;

            private DataColumn columnsale_vat;

            private DataColumn columnsale_exmp;

            private DataColumn columnexmp_item_sale;

            private DataColumn columnother_adjustment;

            private DataColumn columnpurchase_value;

            private DataColumn columnrebatable_tax;

            private DataColumn columnpurchase_value_import;

            private DataColumn columnrebatable_tax_import;

            private DataColumn columnrebate_on_export;

            private DataColumn columnpurchase;

            private DataColumn columnother_adj_purchase;

            private DataColumn columnpre_m_cls_b;

            private DataColumn columntreasury_deposit;

            private DataColumn columnreturn_tax_office;

            private DataColumn columnts_tax_deduct;

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
            public DataColumn exmp_item_saleColumn
            {
                get
                {
                    return this.columnexmp_item_sale;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VatReturnForm19.VatReturnForm19Row this[int index]
            {
                get
                {
                    return (VatReturnForm19.VatReturnForm19Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn other_adj_purchaseColumn
            {
                get
                {
                    return this.columnother_adj_purchase;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn other_adjustmentColumn
            {
                get
                {
                    return this.columnother_adjustment;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn pre_m_cls_bColumn
            {
                get
                {
                    return this.columnpre_m_cls_b;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_value_importColumn
            {
                get
                {
                    return this.columnpurchase_value_import;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchase_valueColumn
            {
                get
                {
                    return this.columnpurchase_value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchaseColumn
            {
                get
                {
                    return this.columnpurchase;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn rebatable_tax_importColumn
            {
                get
                {
                    return this.columnrebatable_tax_import;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn rebatable_taxColumn
            {
                get
                {
                    return this.columnrebatable_tax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn rebate_on_exportColumn
            {
                get
                {
                    return this.columnrebate_on_export;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn return_tax_officeColumn
            {
                get
                {
                    return this.columnreturn_tax_office;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn sale_exmpColumn
            {
                get
                {
                    return this.columnsale_exmp;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn sale_priceColumn
            {
                get
                {
                    return this.columnsale_price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn sale_sdColumn
            {
                get
                {
                    return this.columnsale_sd;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn sale_vatColumn
            {
                get
                {
                    return this.columnsale_vat;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn treasury_depositColumn
            {
                get
                {
                    return this.columntreasury_deposit;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ts_tax_deductColumn
            {
                get
                {
                    return this.columnts_tax_deduct;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VatReturnForm19DataTable()
            {
                base.TableName = "VatReturnForm19";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal VatReturnForm19DataTable(DataTable table)
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
            protected VatReturnForm19DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddVatReturnForm19Row(VatReturnForm19.VatReturnForm19Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VatReturnForm19.VatReturnForm19Row AddVatReturnForm19Row(double sale_price, double sale_sd, double sale_vat, double sale_exmp, double exmp_item_sale, double other_adjustment, double purchase_value, double rebatable_tax, double purchase_value_import, double rebatable_tax_import, double rebate_on_export, double purchase, double other_adj_purchase, double pre_m_cls_b, double treasury_deposit, double return_tax_office, double ts_tax_deduct)
            {
                VatReturnForm19.VatReturnForm19Row vatReturnForm19Row = (VatReturnForm19.VatReturnForm19Row)base.NewRow();
                object[] salePrice = new object[] { sale_price, sale_sd, sale_vat, sale_exmp, exmp_item_sale, other_adjustment, purchase_value, rebatable_tax, purchase_value_import, rebatable_tax_import, rebate_on_export, purchase, other_adj_purchase, pre_m_cls_b, treasury_deposit, return_tax_office, ts_tax_deduct };
                vatReturnForm19Row.ItemArray = salePrice;
                base.Rows.Add(vatReturnForm19Row);
                return vatReturnForm19Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                VatReturnForm19.VatReturnForm19DataTable vatReturnForm19DataTable = (VatReturnForm19.VatReturnForm19DataTable)base.Clone();
                vatReturnForm19DataTable.InitVars();
                return vatReturnForm19DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new VatReturnForm19.VatReturnForm19DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(VatReturnForm19.VatReturnForm19Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                VatReturnForm19 vatReturnForm19 = new VatReturnForm19();
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
                    FixedValue = vatReturnForm19.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "VatReturnForm19DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = vatReturnForm19.GetSchemaSerializable();
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
                this.columnsale_price = new DataColumn("sale_price", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnsale_price);
                this.columnsale_sd = new DataColumn("sale_sd", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnsale_sd);
                this.columnsale_vat = new DataColumn("sale_vat", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnsale_vat);
                this.columnsale_exmp = new DataColumn("sale_exmp", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnsale_exmp);
                this.columnexmp_item_sale = new DataColumn("exmp_item_sale", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnexmp_item_sale);
                this.columnother_adjustment = new DataColumn("other_adjustment", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnother_adjustment);
                this.columnpurchase_value = new DataColumn("purchase_value", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_value);
                this.columnrebatable_tax = new DataColumn("rebatable_tax", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnrebatable_tax);
                this.columnpurchase_value_import = new DataColumn("purchase_value_import", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase_value_import);
                this.columnrebatable_tax_import = new DataColumn("rebatable_tax_import", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnrebatable_tax_import);
                this.columnrebate_on_export = new DataColumn("rebate_on_export", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnrebate_on_export);
                this.columnpurchase = new DataColumn("purchase", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnpurchase);
                this.columnother_adj_purchase = new DataColumn("other_adj_purchase", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnother_adj_purchase);
                this.columnpre_m_cls_b = new DataColumn("pre_m_cls_b", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnpre_m_cls_b);
                this.columntreasury_deposit = new DataColumn("treasury_deposit", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columntreasury_deposit);
                this.columnreturn_tax_office = new DataColumn("return_tax_office", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnreturn_tax_office);
                this.columnts_tax_deduct = new DataColumn("ts_tax_deduct", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnts_tax_deduct);
                base.ExtendedProperties.Add("Generator_TablePropName", "_VatReturnForm19");
                base.ExtendedProperties.Add("Generator_UserTableName", "VatReturnForm19");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnsale_price = base.Columns["sale_price"];
                this.columnsale_sd = base.Columns["sale_sd"];
                this.columnsale_vat = base.Columns["sale_vat"];
                this.columnsale_exmp = base.Columns["sale_exmp"];
                this.columnexmp_item_sale = base.Columns["exmp_item_sale"];
                this.columnother_adjustment = base.Columns["other_adjustment"];
                this.columnpurchase_value = base.Columns["purchase_value"];
                this.columnrebatable_tax = base.Columns["rebatable_tax"];
                this.columnpurchase_value_import = base.Columns["purchase_value_import"];
                this.columnrebatable_tax_import = base.Columns["rebatable_tax_import"];
                this.columnrebate_on_export = base.Columns["rebate_on_export"];
                this.columnpurchase = base.Columns["purchase"];
                this.columnother_adj_purchase = base.Columns["other_adj_purchase"];
                this.columnpre_m_cls_b = base.Columns["pre_m_cls_b"];
                this.columntreasury_deposit = base.Columns["treasury_deposit"];
                this.columnreturn_tax_office = base.Columns["return_tax_office"];
                this.columnts_tax_deduct = base.Columns["ts_tax_deduct"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new VatReturnForm19.VatReturnForm19Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VatReturnForm19.VatReturnForm19Row NewVatReturnForm19Row()
            {
                return (VatReturnForm19.VatReturnForm19Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VatReturnForm19RowChanged != null)
                {
                    this.VatReturnForm19RowChanged(this, new VatReturnForm19.VatReturnForm19RowChangeEvent((VatReturnForm19.VatReturnForm19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VatReturnForm19RowChanging != null)
                {
                    this.VatReturnForm19RowChanging(this, new VatReturnForm19.VatReturnForm19RowChangeEvent((VatReturnForm19.VatReturnForm19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VatReturnForm19RowDeleted != null)
                {
                    this.VatReturnForm19RowDeleted(this, new VatReturnForm19.VatReturnForm19RowChangeEvent((VatReturnForm19.VatReturnForm19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VatReturnForm19RowDeleting != null)
                {
                    this.VatReturnForm19RowDeleting(this, new VatReturnForm19.VatReturnForm19RowChangeEvent((VatReturnForm19.VatReturnForm19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveVatReturnForm19Row(VatReturnForm19.VatReturnForm19Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VatReturnForm19.VatReturnForm19RowChangeEventHandler VatReturnForm19RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VatReturnForm19.VatReturnForm19RowChangeEventHandler VatReturnForm19RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VatReturnForm19.VatReturnForm19RowChangeEventHandler VatReturnForm19RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event VatReturnForm19.VatReturnForm19RowChangeEventHandler VatReturnForm19RowDeleting;
        }

        public class VatReturnForm19Row : DataRow
        {
            private VatReturnForm19.VatReturnForm19DataTable tableVatReturnForm19;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double exmp_item_sale
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.exmp_item_saleColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'exmp_item_sale' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.exmp_item_saleColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double other_adj_purchase
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.other_adj_purchaseColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'other_adj_purchase' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.other_adj_purchaseColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double other_adjustment
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.other_adjustmentColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'other_adjustment' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.other_adjustmentColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double pre_m_cls_b
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.pre_m_cls_bColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'pre_m_cls_b' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.pre_m_cls_bColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double purchase
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.purchaseColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.purchaseColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double purchase_value
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.purchase_valueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_value' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.purchase_valueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double purchase_value_import
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.purchase_value_importColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchase_value_import' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.purchase_value_importColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double rebatable_tax
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.rebatable_taxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'rebatable_tax' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.rebatable_taxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double rebatable_tax_import
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.rebatable_tax_importColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'rebatable_tax_import' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.rebatable_tax_importColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double rebate_on_export
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.rebate_on_exportColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'rebate_on_export' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.rebate_on_exportColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double return_tax_office
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.return_tax_officeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'return_tax_office' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.return_tax_officeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double sale_exmp
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.sale_exmpColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'sale_exmp' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.sale_exmpColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double sale_price
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.sale_priceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'sale_price' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.sale_priceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double sale_sd
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.sale_sdColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'sale_sd' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.sale_sdColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double sale_vat
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.sale_vatColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'sale_vat' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.sale_vatColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double treasury_deposit
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.treasury_depositColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'treasury_deposit' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.treasury_depositColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double ts_tax_deduct
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableVatReturnForm19.ts_tax_deductColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ts_tax_deduct' in table 'VatReturnForm19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVatReturnForm19.ts_tax_deductColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal VatReturnForm19Row(DataRowBuilder rb) : base(rb)
            {
                this.tableVatReturnForm19 = (VatReturnForm19.VatReturnForm19DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isexmp_item_saleNull()
            {
                return base.IsNull(this.tableVatReturnForm19.exmp_item_saleColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isother_adj_purchaseNull()
            {
                return base.IsNull(this.tableVatReturnForm19.other_adj_purchaseColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isother_adjustmentNull()
            {
                return base.IsNull(this.tableVatReturnForm19.other_adjustmentColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispre_m_cls_bNull()
            {
                return base.IsNull(this.tableVatReturnForm19.pre_m_cls_bColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_value_importNull()
            {
                return base.IsNull(this.tableVatReturnForm19.purchase_value_importColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchase_valueNull()
            {
                return base.IsNull(this.tableVatReturnForm19.purchase_valueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IspurchaseNull()
            {
                return base.IsNull(this.tableVatReturnForm19.purchaseColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isrebatable_tax_importNull()
            {
                return base.IsNull(this.tableVatReturnForm19.rebatable_tax_importColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isrebatable_taxNull()
            {
                return base.IsNull(this.tableVatReturnForm19.rebatable_taxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isrebate_on_exportNull()
            {
                return base.IsNull(this.tableVatReturnForm19.rebate_on_exportColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isreturn_tax_officeNull()
            {
                return base.IsNull(this.tableVatReturnForm19.return_tax_officeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Issale_exmpNull()
            {
                return base.IsNull(this.tableVatReturnForm19.sale_exmpColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Issale_priceNull()
            {
                return base.IsNull(this.tableVatReturnForm19.sale_priceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Issale_sdNull()
            {
                return base.IsNull(this.tableVatReturnForm19.sale_sdColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Issale_vatNull()
            {
                return base.IsNull(this.tableVatReturnForm19.sale_vatColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Istreasury_depositNull()
            {
                return base.IsNull(this.tableVatReturnForm19.treasury_depositColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ists_tax_deductNull()
            {
                return base.IsNull(this.tableVatReturnForm19.ts_tax_deductColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setexmp_item_saleNull()
            {
                base[this.tableVatReturnForm19.exmp_item_saleColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setother_adj_purchaseNull()
            {
                base[this.tableVatReturnForm19.other_adj_purchaseColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setother_adjustmentNull()
            {
                base[this.tableVatReturnForm19.other_adjustmentColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpre_m_cls_bNull()
            {
                base[this.tableVatReturnForm19.pre_m_cls_bColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_value_importNull()
            {
                base[this.tableVatReturnForm19.purchase_value_importColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchase_valueNull()
            {
                base[this.tableVatReturnForm19.purchase_valueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetpurchaseNull()
            {
                base[this.tableVatReturnForm19.purchaseColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setrebatable_tax_importNull()
            {
                base[this.tableVatReturnForm19.rebatable_tax_importColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setrebatable_taxNull()
            {
                base[this.tableVatReturnForm19.rebatable_taxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setrebate_on_exportNull()
            {
                base[this.tableVatReturnForm19.rebate_on_exportColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setreturn_tax_officeNull()
            {
                base[this.tableVatReturnForm19.return_tax_officeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setsale_exmpNull()
            {
                base[this.tableVatReturnForm19.sale_exmpColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setsale_priceNull()
            {
                base[this.tableVatReturnForm19.sale_priceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setsale_sdNull()
            {
                base[this.tableVatReturnForm19.sale_sdColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setsale_vatNull()
            {
                base[this.tableVatReturnForm19.sale_vatColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Settreasury_depositNull()
            {
                base[this.tableVatReturnForm19.treasury_depositColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setts_tax_deductNull()
            {
                base[this.tableVatReturnForm19.ts_tax_deductColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class VatReturnForm19RowChangeEvent : EventArgs
        {
            private VatReturnForm19.VatReturnForm19Row eventRow;

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
            public VatReturnForm19.VatReturnForm19Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VatReturnForm19RowChangeEvent(VatReturnForm19.VatReturnForm19Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void VatReturnForm19RowChangeEventHandler(object sender, VatReturnForm19.VatReturnForm19RowChangeEvent e);
    }
}

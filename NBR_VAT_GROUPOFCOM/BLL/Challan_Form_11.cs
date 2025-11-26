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
    [XmlRoot("Challan_Form_11")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class Challan_Form_11 : DataSet
    {
        private Challan_Form_11.Challan_Form_11DataTable tableChallan_Form_11;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Challan_Form_11.Challan_Form_11DataTable _Challan_Form_11
        {
            get
            {
                return this.tableChallan_Form_11;
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
        public Challan_Form_11()
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
        protected Challan_Form_11(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Challan_Form_11"] != null)
                {
                    base.Tables.Add(new Challan_Form_11.Challan_Form_11DataTable(dataSet.Tables["Challan_Form_11"]));
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
            Challan_Form_11 schemaSerializationMode = (Challan_Form_11)base.Clone();
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
            Challan_Form_11 challanForm11 = new Challan_Form_11();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = challanForm11.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = challanForm11.GetSchemaSerializable();
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
            base.DataSetName = "Challan_Form_11";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Challan_Form_11.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableChallan_Form_11 = new Challan_Form_11.Challan_Form_11DataTable();
            base.Tables.Add(this.tableChallan_Form_11);
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
            this.tableChallan_Form_11 = (Challan_Form_11.Challan_Form_11DataTable)base.Tables["Challan_Form_11"];
            if (initTable && this.tableChallan_Form_11 != null)
            {
                this.tableChallan_Form_11.InitVars();
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
            if (dataSet.Tables["Challan_Form_11"] != null)
            {
                base.Tables.Add(new Challan_Form_11.Challan_Form_11DataTable(dataSet.Tables["Challan_Form_11"]));
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
        private bool ShouldSerialize_Challan_Form_11()
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
        public class Challan_Form_11DataTable : TypedTableBase<Challan_Form_11.Challan_Form_11Row>
        {
            private DataColumn columnOrgName;

            private DataColumn columnOrgAddress;

            private DataColumn columnOrgTin;

            private DataColumn columnCustomer_name;

            private DataColumn columnCustomer_Address;

            private DataColumn columnCustomer_TIN;

            private DataColumn columnGoods_Services_Shipping_Address;

            private DataColumn columnVehicle_Type;

            private DataColumn columnChallan_No;

            private DataColumn columnChallan_Date;

            private DataColumn columnChallan_Time;

            private DataColumn columnGoods_Unload_Date_Time;

            private DataColumn columnSl_No;

            private DataColumn columnGoods_Services_Name;

            private DataColumn columnQuantity;

            private DataColumn columnSD_Applicable_Price;

            private DataColumn columnSD_Amount;

            private DataColumn columnVAT_Amount;

            private DataColumn columnVehicle_No;

            private DataColumn columnTextDate;

            private DataColumn columnTextTime;

            private DataColumn columnVehicle;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Challan_DateColumn
            {
                get
                {
                    return this.columnChallan_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Challan_NoColumn
            {
                get
                {
                    return this.columnChallan_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Challan_TimeColumn
            {
                get
                {
                    return this.columnChallan_Time;
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
            public DataColumn Customer_AddressColumn
            {
                get
                {
                    return this.columnCustomer_Address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Customer_nameColumn
            {
                get
                {
                    return this.columnCustomer_name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Customer_TINColumn
            {
                get
                {
                    return this.columnCustomer_TIN;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_Services_NameColumn
            {
                get
                {
                    return this.columnGoods_Services_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_Services_Shipping_AddressColumn
            {
                get
                {
                    return this.columnGoods_Services_Shipping_Address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_Unload_Date_TimeColumn
            {
                get
                {
                    return this.columnGoods_Unload_Date_Time;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Challan_Form_11.Challan_Form_11Row this[int index]
            {
                get
                {
                    return (Challan_Form_11.Challan_Form_11Row)base.Rows[index];
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
            public DataColumn OrgTinColumn
            {
                get
                {
                    return this.columnOrgTin;
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
            public DataColumn SD_AmountColumn
            {
                get
                {
                    return this.columnSD_Amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SD_Applicable_PriceColumn
            {
                get
                {
                    return this.columnSD_Applicable_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sl_NoColumn
            {
                get
                {
                    return this.columnSl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TextDateColumn
            {
                get
                {
                    return this.columnTextDate;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn TextTimeColumn
            {
                get
                {
                    return this.columnTextTime;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VAT_AmountColumn
            {
                get
                {
                    return this.columnVAT_Amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Vehicle_NoColumn
            {
                get
                {
                    return this.columnVehicle_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Vehicle_TypeColumn
            {
                get
                {
                    return this.columnVehicle_Type;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VehicleColumn
            {
                get
                {
                    return this.columnVehicle;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Challan_Form_11DataTable()
            {
                base.TableName = "Challan_Form_11";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Challan_Form_11DataTable(DataTable table)
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
            protected Challan_Form_11DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddChallan_Form_11Row(Challan_Form_11.Challan_Form_11Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Challan_Form_11.Challan_Form_11Row AddChallan_Form_11Row(string OrgName, string OrgAddress, string OrgTin, string Customer_name, string Customer_Address, string Customer_TIN, string Goods_Services_Shipping_Address, string Vehicle_Type, string Challan_No, string Challan_Date, string Challan_Time, DateTime Goods_Unload_Date_Time, string Goods_Services_Name, double Quantity, double SD_Applicable_Price, double SD_Amount, double VAT_Amount, string Vehicle_No, string TextDate, string TextTime, string Vehicle)
            {
                Challan_Form_11.Challan_Form_11Row challanForm11Row = (Challan_Form_11.Challan_Form_11Row)base.NewRow();
                object[] orgName = new object[] { OrgName, OrgAddress, OrgTin, Customer_name, Customer_Address, Customer_TIN, Goods_Services_Shipping_Address, Vehicle_Type, Challan_No, Challan_Date, Challan_Time, Goods_Unload_Date_Time, null, Goods_Services_Name, Quantity, SD_Applicable_Price, SD_Amount, VAT_Amount, Vehicle_No, TextDate, TextTime, Vehicle };
                challanForm11Row.ItemArray = orgName;
                base.Rows.Add(challanForm11Row);
                return challanForm11Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Challan_Form_11.Challan_Form_11DataTable challanForm11DataTable = (Challan_Form_11.Challan_Form_11DataTable)base.Clone();
                challanForm11DataTable.InitVars();
                return challanForm11DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new Challan_Form_11.Challan_Form_11DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Challan_Form_11.Challan_Form_11Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                Challan_Form_11 challanForm11 = new Challan_Form_11();
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
                    FixedValue = challanForm11.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Challan_Form_11DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = challanForm11.GetSchemaSerializable();
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
                this.columnOrgTin = new DataColumn("OrgTin", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgTin);
                this.columnCustomer_name = new DataColumn("Customer_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCustomer_name);
                this.columnCustomer_Address = new DataColumn("Customer_Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCustomer_Address);
                this.columnCustomer_TIN = new DataColumn("Customer_TIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCustomer_TIN);
                this.columnGoods_Services_Shipping_Address = new DataColumn("Goods_Services_Shipping_Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Services_Shipping_Address);
                this.columnVehicle_Type = new DataColumn("Vehicle_Type", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_Type);
                this.columnChallan_No = new DataColumn("Challan_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnChallan_No);
                this.columnChallan_Date = new DataColumn("Challan_Date", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnChallan_Date);
                this.columnChallan_Time = new DataColumn("Challan_Time", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnChallan_Time);
                this.columnGoods_Unload_Date_Time = new DataColumn("Goods_Unload_Date_Time", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Unload_Date_Time);
                this.columnSl_No = new DataColumn("Sl_No", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSl_No);
                this.columnGoods_Services_Name = new DataColumn("Goods_Services_Name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Services_Name);
                this.columnQuantity = new DataColumn("Quantity", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnQuantity);
                this.columnSD_Applicable_Price = new DataColumn("SD_Applicable_Price", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnSD_Applicable_Price);
                this.columnSD_Amount = new DataColumn("SD_Amount", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnSD_Amount);
                this.columnVAT_Amount = new DataColumn("VAT_Amount", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnVAT_Amount);
                this.columnVehicle_No = new DataColumn("Vehicle_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_No);
                this.columnTextDate = new DataColumn("TextDate", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTextDate);
                this.columnTextTime = new DataColumn("TextTime", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTextTime);
                this.columnVehicle = new DataColumn("Vehicle", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle);
                this.columnSl_No.AutoIncrement = true;
                base.ExtendedProperties.Add("Generator_TablePropName", "_Challan_Form_11");
                base.ExtendedProperties.Add("Generator_UserTableName", "Challan_Form_11");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnOrgTin = base.Columns["OrgTin"];
                this.columnCustomer_name = base.Columns["Customer_name"];
                this.columnCustomer_Address = base.Columns["Customer_Address"];
                this.columnCustomer_TIN = base.Columns["Customer_TIN"];
                this.columnGoods_Services_Shipping_Address = base.Columns["Goods_Services_Shipping_Address"];
                this.columnVehicle_Type = base.Columns["Vehicle_Type"];
                this.columnChallan_No = base.Columns["Challan_No"];
                this.columnChallan_Date = base.Columns["Challan_Date"];
                this.columnChallan_Time = base.Columns["Challan_Time"];
                this.columnGoods_Unload_Date_Time = base.Columns["Goods_Unload_Date_Time"];
                this.columnSl_No = base.Columns["Sl_No"];
                this.columnGoods_Services_Name = base.Columns["Goods_Services_Name"];
                this.columnQuantity = base.Columns["Quantity"];
                this.columnSD_Applicable_Price = base.Columns["SD_Applicable_Price"];
                this.columnSD_Amount = base.Columns["SD_Amount"];
                this.columnVAT_Amount = base.Columns["VAT_Amount"];
                this.columnVehicle_No = base.Columns["Vehicle_No"];
                this.columnTextDate = base.Columns["TextDate"];
                this.columnTextTime = base.Columns["TextTime"];
                this.columnVehicle = base.Columns["Vehicle"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Challan_Form_11.Challan_Form_11Row NewChallan_Form_11Row()
            {
                return (Challan_Form_11.Challan_Form_11Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Challan_Form_11.Challan_Form_11Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Challan_Form_11RowChanged != null)
                {
                    this.Challan_Form_11RowChanged(this, new Challan_Form_11.Challan_Form_11RowChangeEvent((Challan_Form_11.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Challan_Form_11RowChanging != null)
                {
                    this.Challan_Form_11RowChanging(this, new Challan_Form_11.Challan_Form_11RowChangeEvent((Challan_Form_11.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Challan_Form_11RowDeleted != null)
                {
                    this.Challan_Form_11RowDeleted(this, new Challan_Form_11.Challan_Form_11RowChangeEvent((Challan_Form_11.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Challan_Form_11RowDeleting != null)
                {
                    this.Challan_Form_11RowDeleting(this, new Challan_Form_11.Challan_Form_11RowChangeEvent((Challan_Form_11.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveChallan_Form_11Row(Challan_Form_11.Challan_Form_11Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Challan_Form_11.Challan_Form_11RowChangeEventHandler Challan_Form_11RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Challan_Form_11.Challan_Form_11RowChangeEventHandler Challan_Form_11RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Challan_Form_11.Challan_Form_11RowChangeEventHandler Challan_Form_11RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Challan_Form_11.Challan_Form_11RowChangeEventHandler Challan_Form_11RowDeleting;
        }

        public class Challan_Form_11Row : DataRow
        {
            private Challan_Form_11.Challan_Form_11DataTable tableChallan_Form_11;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Challan_Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Challan_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Challan_Date' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Challan_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Challan_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Challan_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Challan_No' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Challan_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Challan_Time
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Challan_TimeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Challan_Time' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Challan_TimeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Customer_Address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Customer_AddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Customer_Address' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Customer_AddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Customer_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Customer_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Customer_name' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Customer_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Customer_TIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Customer_TINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Customer_TIN' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Customer_TINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_Services_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Goods_Services_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Services_Name' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Goods_Services_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_Services_Shipping_Address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Goods_Services_Shipping_AddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Services_Shipping_Address' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Goods_Services_Shipping_AddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime Goods_Unload_Date_Time
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tableChallan_Form_11.Goods_Unload_Date_TimeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Unload_Date_Time' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Goods_Unload_Date_TimeColumn] = value;
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
                        item = (string)base[this.tableChallan_Form_11.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.OrgAddressColumn] = value;
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
                        item = (string)base[this.tableChallan_Form_11.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.OrgNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgTin
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.OrgTinColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgTin' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.OrgTinColumn] = value;
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
                        item = (double)base[this.tableChallan_Form_11.QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Quantity' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double SD_Amount
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableChallan_Form_11.SD_AmountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SD_Amount' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.SD_AmountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double SD_Applicable_Price
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableChallan_Form_11.SD_Applicable_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SD_Applicable_Price' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.SD_Applicable_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int Sl_No
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tableChallan_Form_11.Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sl_No' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TextDate
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.TextDateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TextDate' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.TextDateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string TextTime
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.TextTimeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'TextTime' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.TextTimeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double VAT_Amount
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableChallan_Form_11.VAT_AmountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'VAT_Amount' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.VAT_AmountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Vehicle
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.VehicleColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.VehicleColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Vehicle_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Vehicle_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle_No' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Vehicle_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Vehicle_Type
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Vehicle_TypeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle_Type' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Vehicle_TypeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Challan_Form_11Row(DataRowBuilder rb) : base(rb)
            {
                this.tableChallan_Form_11 = (Challan_Form_11.Challan_Form_11DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallan_DateNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Challan_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallan_NoNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Challan_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallan_TimeNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Challan_TimeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCustomer_AddressNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Customer_AddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCustomer_nameNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Customer_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCustomer_TINNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Customer_TINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_Services_NameNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Goods_Services_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_Services_Shipping_AddressNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Goods_Services_Shipping_AddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_Unload_Date_TimeNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Goods_Unload_Date_TimeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tableChallan_Form_11.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tableChallan_Form_11.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgTinNull()
            {
                return base.IsNull(this.tableChallan_Form_11.OrgTinColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQuantityNull()
            {
                return base.IsNull(this.tableChallan_Form_11.QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSD_AmountNull()
            {
                return base.IsNull(this.tableChallan_Form_11.SD_AmountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSD_Applicable_PriceNull()
            {
                return base.IsNull(this.tableChallan_Form_11.SD_Applicable_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSl_NoNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTextDateNull()
            {
                return base.IsNull(this.tableChallan_Form_11.TextDateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTextTimeNull()
            {
                return base.IsNull(this.tableChallan_Form_11.TextTimeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVAT_AmountNull()
            {
                return base.IsNull(this.tableChallan_Form_11.VAT_AmountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicle_NoNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Vehicle_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicle_TypeNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Vehicle_TypeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicleNull()
            {
                return base.IsNull(this.tableChallan_Form_11.VehicleColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallan_DateNull()
            {
                base[this.tableChallan_Form_11.Challan_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallan_NoNull()
            {
                base[this.tableChallan_Form_11.Challan_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallan_TimeNull()
            {
                base[this.tableChallan_Form_11.Challan_TimeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCustomer_AddressNull()
            {
                base[this.tableChallan_Form_11.Customer_AddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCustomer_nameNull()
            {
                base[this.tableChallan_Form_11.Customer_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCustomer_TINNull()
            {
                base[this.tableChallan_Form_11.Customer_TINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_Services_NameNull()
            {
                base[this.tableChallan_Form_11.Goods_Services_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_Services_Shipping_AddressNull()
            {
                base[this.tableChallan_Form_11.Goods_Services_Shipping_AddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_Unload_Date_TimeNull()
            {
                base[this.tableChallan_Form_11.Goods_Unload_Date_TimeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tableChallan_Form_11.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tableChallan_Form_11.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgTinNull()
            {
                base[this.tableChallan_Form_11.OrgTinColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQuantityNull()
            {
                base[this.tableChallan_Form_11.QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSD_AmountNull()
            {
                base[this.tableChallan_Form_11.SD_AmountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSD_Applicable_PriceNull()
            {
                base[this.tableChallan_Form_11.SD_Applicable_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSl_NoNull()
            {
                base[this.tableChallan_Form_11.Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTextDateNull()
            {
                base[this.tableChallan_Form_11.TextDateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTextTimeNull()
            {
                base[this.tableChallan_Form_11.TextTimeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVAT_AmountNull()
            {
                base[this.tableChallan_Form_11.VAT_AmountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicle_NoNull()
            {
                base[this.tableChallan_Form_11.Vehicle_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicle_TypeNull()
            {
                base[this.tableChallan_Form_11.Vehicle_TypeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicleNull()
            {
                base[this.tableChallan_Form_11.VehicleColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Challan_Form_11RowChangeEvent : EventArgs
        {
            private Challan_Form_11.Challan_Form_11Row eventRow;

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
            public Challan_Form_11.Challan_Form_11Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Challan_Form_11RowChangeEvent(Challan_Form_11.Challan_Form_11Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Challan_Form_11RowChangeEventHandler(object sender, Challan_Form_11.Challan_Form_11RowChangeEvent e);
    }
}







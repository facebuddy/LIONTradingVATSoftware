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
    [XmlRoot("Credit_Note_Form_12")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class Credit_Note_Form_12 : DataSet
    {
        private Credit_Note_Form_12.Credit_Note_Form_12DataTable tableCredit_Note_Form_12;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Credit_Note_Form_12.Credit_Note_Form_12DataTable _Credit_Note_Form_12
        {
            get
            {
                return this.tableCredit_Note_Form_12;
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
        public Credit_Note_Form_12()
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
        protected Credit_Note_Form_12(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Credit_Note_Form_12"] != null)
                {
                    base.Tables.Add(new Credit_Note_Form_12.Credit_Note_Form_12DataTable(dataSet.Tables["Credit_Note_Form_12"]));
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
            Credit_Note_Form_12 schemaSerializationMode = (Credit_Note_Form_12)base.Clone();
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
            Credit_Note_Form_12 creditNoteForm12 = new Credit_Note_Form_12();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = creditNoteForm12.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = creditNoteForm12.GetSchemaSerializable();
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
            base.DataSetName = "Credit_Note_Form_12";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Credit_Note_Form_12.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableCredit_Note_Form_12 = new Credit_Note_Form_12.Credit_Note_Form_12DataTable();
            base.Tables.Add(this.tableCredit_Note_Form_12);
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
            this.tableCredit_Note_Form_12 = (Credit_Note_Form_12.Credit_Note_Form_12DataTable)base.Tables["Credit_Note_Form_12"];
            if (initTable && this.tableCredit_Note_Form_12 != null)
            {
                this.tableCredit_Note_Form_12.InitVars();
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
            if (dataSet.Tables["Credit_Note_Form_12"] != null)
            {
                base.Tables.Add(new Credit_Note_Form_12.Credit_Note_Form_12DataTable(dataSet.Tables["Credit_Note_Form_12"]));
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
        private bool ShouldSerialize_Credit_Note_Form_12()
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
        public class Credit_Note_Form_12DataTable : TypedTableBase<Credit_Note_Form_12.Credit_Note_Form_12Row>
        {
            private DataColumn columnOrgName;

            private DataColumn columnOrgAddress;

            private DataColumn columnOrgBIN;

            private DataColumn columnOrgTelephone;

            private DataColumn columnOrgFax;

            private DataColumn columnPartyName;

            private DataColumn columnPartyAddress;

            private DataColumn columnPartyTIN;

            private DataColumn columnVehicle_Type;

            private DataColumn columnVehicle_No;

            private DataColumn columnVehicleTypeAndNo;

            private DataColumn columnCredit_Note_No;

            private DataColumn columnCredit_Note_Date;

            private DataColumn columnSlNo_1;

            private DataColumn columnChallan_Sl_No;

            private DataColumn columnChallan_Date;

            private DataColumn columnChallan_SlAndDate_2;

            private DataColumn columnName_of_Goods;

            private DataColumn columnQuantity_of_Goods;

            private DataColumn columnGoods_NameAndQty_3;

            private DataColumn columnTotal_Price_4;

            private DataColumn columnRbt_Other_Tax_Amount_5;

            private DataColumn columnRbt_VAT_Amount_6;

            private DataColumn columnCln_Other_Tax_Amount_7;

            private DataColumn columnCln_VAT_Amount_8;

            private DataColumn columnDif_Other_Tax_Amount_9;

            private DataColumn columnDif_VAT_Amount_10;

            private DataColumn columnRemarks;

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
            public DataColumn Challan_Sl_NoColumn
            {
                get
                {
                    return this.columnChallan_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Challan_SlAndDate_2Column
            {
                get
                {
                    return this.columnChallan_SlAndDate_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Cln_Other_Tax_Amount_7Column
            {
                get
                {
                    return this.columnCln_Other_Tax_Amount_7;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Cln_VAT_Amount_8Column
            {
                get
                {
                    return this.columnCln_VAT_Amount_8;
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
            public DataColumn Credit_Note_DateColumn
            {
                get
                {
                    return this.columnCredit_Note_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Credit_Note_NoColumn
            {
                get
                {
                    return this.columnCredit_Note_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Dif_Other_Tax_Amount_9Column
            {
                get
                {
                    return this.columnDif_Other_Tax_Amount_9;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Dif_VAT_Amount_10Column
            {
                get
                {
                    return this.columnDif_VAT_Amount_10;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_NameAndQty_3Column
            {
                get
                {
                    return this.columnGoods_NameAndQty_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Credit_Note_Form_12.Credit_Note_Form_12Row this[int index]
            {
                get
                {
                    return (Credit_Note_Form_12.Credit_Note_Form_12Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Name_of_GoodsColumn
            {
                get
                {
                    return this.columnName_of_Goods;
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
            public DataColumn OrgFaxColumn
            {
                get
                {
                    return this.columnOrgFax;
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
            public DataColumn PartyTINColumn
            {
                get
                {
                    return this.columnPartyTIN;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Quantity_of_GoodsColumn
            {
                get
                {
                    return this.columnQuantity_of_Goods;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Rbt_Other_Tax_Amount_5Column
            {
                get
                {
                    return this.columnRbt_Other_Tax_Amount_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Rbt_VAT_Amount_6Column
            {
                get
                {
                    return this.columnRbt_VAT_Amount_6;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn RemarksColumn
            {
                get
                {
                    return this.columnRemarks;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SlNo_1Column
            {
                get
                {
                    return this.columnSlNo_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Total_Price_4Column
            {
                get
                {
                    return this.columnTotal_Price_4;
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
            public DataColumn VehicleTypeAndNoColumn
            {
                get
                {
                    return this.columnVehicleTypeAndNo;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Credit_Note_Form_12DataTable()
            {
                base.TableName = "Credit_Note_Form_12";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Credit_Note_Form_12DataTable(DataTable table)
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
            protected Credit_Note_Form_12DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddCredit_Note_Form_12Row(Credit_Note_Form_12.Credit_Note_Form_12Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Credit_Note_Form_12.Credit_Note_Form_12Row AddCredit_Note_Form_12Row(string OrgName, string OrgAddress, string OrgBIN, string OrgTelephone, string OrgFax, string PartyName, string PartyAddress, string PartyTIN, string Vehicle_Type, string Vehicle_No, string VehicleTypeAndNo, string Credit_Note_No, DateTime Credit_Note_Date, string Challan_Sl_No, DateTime Challan_Date, string Challan_SlAndDate_2, string Name_of_Goods, double Quantity_of_Goods, string Goods_NameAndQty_3, double Total_Price_4, double Rbt_Other_Tax_Amount_5, double Rbt_VAT_Amount_6, double Cln_Other_Tax_Amount_7, double Cln_VAT_Amount_8, double Dif_Other_Tax_Amount_9, double Dif_VAT_Amount_10, string Remarks)
            {
                Credit_Note_Form_12.Credit_Note_Form_12Row creditNoteForm12Row = (Credit_Note_Form_12.Credit_Note_Form_12Row)base.NewRow();
                object[] orgName = new object[] { OrgName, OrgAddress, OrgBIN, OrgTelephone, OrgFax, PartyName, PartyAddress, PartyTIN, Vehicle_Type, Vehicle_No, VehicleTypeAndNo, Credit_Note_No, Credit_Note_Date, null, Challan_Sl_No, Challan_Date, Challan_SlAndDate_2, Name_of_Goods, Quantity_of_Goods, Goods_NameAndQty_3, Total_Price_4, Rbt_Other_Tax_Amount_5, Rbt_VAT_Amount_6, Cln_Other_Tax_Amount_7, Cln_VAT_Amount_8, Dif_Other_Tax_Amount_9, Dif_VAT_Amount_10, Remarks };
                creditNoteForm12Row.ItemArray = orgName;
                base.Rows.Add(creditNoteForm12Row);
                return creditNoteForm12Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Credit_Note_Form_12.Credit_Note_Form_12DataTable creditNoteForm12DataTable = (Credit_Note_Form_12.Credit_Note_Form_12DataTable)base.Clone();
                creditNoteForm12DataTable.InitVars();
                return creditNoteForm12DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new Credit_Note_Form_12.Credit_Note_Form_12DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Credit_Note_Form_12.Credit_Note_Form_12Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                Credit_Note_Form_12 creditNoteForm12 = new Credit_Note_Form_12();
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
                    FixedValue = creditNoteForm12.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Credit_Note_Form_12DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = creditNoteForm12.GetSchemaSerializable();
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
                this.columnOrgFax = new DataColumn("OrgFax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrgFax);
                this.columnPartyName = new DataColumn("PartyName", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPartyName);
                this.columnPartyAddress = new DataColumn("PartyAddress", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPartyAddress);
                this.columnPartyTIN = new DataColumn("PartyTIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPartyTIN);
                this.columnVehicle_Type = new DataColumn("Vehicle_Type", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_Type);
                this.columnVehicle_No = new DataColumn("Vehicle_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_No);
                this.columnVehicleTypeAndNo = new DataColumn("VehicleTypeAndNo", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicleTypeAndNo);
                this.columnCredit_Note_No = new DataColumn("Credit_Note_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCredit_Note_No);
                this.columnCredit_Note_Date = new DataColumn("Credit_Note_Date", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnCredit_Note_Date);
                this.columnSlNo_1 = new DataColumn("SlNo_1", typeof(int), null, MappingType.Element);
                base.Columns.Add(this.columnSlNo_1);
                this.columnChallan_Sl_No = new DataColumn("Challan_Sl_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnChallan_Sl_No);
                this.columnChallan_Date = new DataColumn("Challan_Date", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columnChallan_Date);
                this.columnChallan_SlAndDate_2 = new DataColumn("Challan_SlAndDate_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnChallan_SlAndDate_2);
                this.columnName_of_Goods = new DataColumn("Name_of_Goods", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnName_of_Goods);
                this.columnQuantity_of_Goods = new DataColumn("Quantity_of_Goods", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnQuantity_of_Goods);
                this.columnGoods_NameAndQty_3 = new DataColumn("Goods_NameAndQty_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_NameAndQty_3);
                this.columnTotal_Price_4 = new DataColumn("Total_Price_4", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnTotal_Price_4);
                this.columnRbt_Other_Tax_Amount_5 = new DataColumn("Rbt_Other_Tax_Amount_5", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnRbt_Other_Tax_Amount_5);
                this.columnRbt_VAT_Amount_6 = new DataColumn("Rbt_VAT_Amount_6", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnRbt_VAT_Amount_6);
                this.columnCln_Other_Tax_Amount_7 = new DataColumn("Cln_Other_Tax_Amount_7", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnCln_Other_Tax_Amount_7);
                this.columnCln_VAT_Amount_8 = new DataColumn("Cln_VAT_Amount_8", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnCln_VAT_Amount_8);
                this.columnDif_Other_Tax_Amount_9 = new DataColumn("Dif_Other_Tax_Amount_9", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnDif_Other_Tax_Amount_9);
                this.columnDif_VAT_Amount_10 = new DataColumn("Dif_VAT_Amount_10", typeof(double), null, MappingType.Element);
                base.Columns.Add(this.columnDif_VAT_Amount_10);
                this.columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRemarks);
                this.columnSlNo_1.AutoIncrement = true;
                base.ExtendedProperties.Add("Generator_TablePropName", "_Credit_Note_Form_12");
                base.ExtendedProperties.Add("Generator_UserTableName", "Credit_Note_Form_12");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnOrgName = base.Columns["OrgName"];
                this.columnOrgAddress = base.Columns["OrgAddress"];
                this.columnOrgBIN = base.Columns["OrgBIN"];
                this.columnOrgTelephone = base.Columns["OrgTelephone"];
                this.columnOrgFax = base.Columns["OrgFax"];
                this.columnPartyName = base.Columns["PartyName"];
                this.columnPartyAddress = base.Columns["PartyAddress"];
                this.columnPartyTIN = base.Columns["PartyTIN"];
                this.columnVehicle_Type = base.Columns["Vehicle_Type"];
                this.columnVehicle_No = base.Columns["Vehicle_No"];
                this.columnVehicleTypeAndNo = base.Columns["VehicleTypeAndNo"];
                this.columnCredit_Note_No = base.Columns["Credit_Note_No"];
                this.columnCredit_Note_Date = base.Columns["Credit_Note_Date"];
                this.columnSlNo_1 = base.Columns["SlNo_1"];
                this.columnChallan_Sl_No = base.Columns["Challan_Sl_No"];
                this.columnChallan_Date = base.Columns["Challan_Date"];
                this.columnChallan_SlAndDate_2 = base.Columns["Challan_SlAndDate_2"];
                this.columnName_of_Goods = base.Columns["Name_of_Goods"];
                this.columnQuantity_of_Goods = base.Columns["Quantity_of_Goods"];
                this.columnGoods_NameAndQty_3 = base.Columns["Goods_NameAndQty_3"];
                this.columnTotal_Price_4 = base.Columns["Total_Price_4"];
                this.columnRbt_Other_Tax_Amount_5 = base.Columns["Rbt_Other_Tax_Amount_5"];
                this.columnRbt_VAT_Amount_6 = base.Columns["Rbt_VAT_Amount_6"];
                this.columnCln_Other_Tax_Amount_7 = base.Columns["Cln_Other_Tax_Amount_7"];
                this.columnCln_VAT_Amount_8 = base.Columns["Cln_VAT_Amount_8"];
                this.columnDif_Other_Tax_Amount_9 = base.Columns["Dif_Other_Tax_Amount_9"];
                this.columnDif_VAT_Amount_10 = base.Columns["Dif_VAT_Amount_10"];
                this.columnRemarks = base.Columns["Remarks"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Credit_Note_Form_12.Credit_Note_Form_12Row NewCredit_Note_Form_12Row()
            {
                return (Credit_Note_Form_12.Credit_Note_Form_12Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Credit_Note_Form_12.Credit_Note_Form_12Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Credit_Note_Form_12RowChanged != null)
                {
                    this.Credit_Note_Form_12RowChanged(this, new Credit_Note_Form_12.Credit_Note_Form_12RowChangeEvent((Credit_Note_Form_12.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Credit_Note_Form_12RowChanging != null)
                {
                    this.Credit_Note_Form_12RowChanging(this, new Credit_Note_Form_12.Credit_Note_Form_12RowChangeEvent((Credit_Note_Form_12.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Credit_Note_Form_12RowDeleted != null)
                {
                    this.Credit_Note_Form_12RowDeleted(this, new Credit_Note_Form_12.Credit_Note_Form_12RowChangeEvent((Credit_Note_Form_12.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Credit_Note_Form_12RowDeleting != null)
                {
                    this.Credit_Note_Form_12RowDeleting(this, new Credit_Note_Form_12.Credit_Note_Form_12RowChangeEvent((Credit_Note_Form_12.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCredit_Note_Form_12Row(Credit_Note_Form_12.Credit_Note_Form_12Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Credit_Note_Form_12.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Credit_Note_Form_12.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Credit_Note_Form_12.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Credit_Note_Form_12.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowDeleting;
        }

        public class Credit_Note_Form_12Row : DataRow
        {
            private Credit_Note_Form_12.Credit_Note_Form_12DataTable tableCredit_Note_Form_12;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime Challan_Date
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tableCredit_Note_Form_12.Challan_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Challan_Date' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Challan_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Challan_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Challan_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Challan_Sl_No' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Challan_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Challan_SlAndDate_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Challan_SlAndDate_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Challan_SlAndDate_2' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Challan_SlAndDate_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Cln_Other_Tax_Amount_7
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Cln_Other_Tax_Amount_7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Cln_Other_Tax_Amount_7' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Cln_Other_Tax_Amount_7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Cln_VAT_Amount_8
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Cln_VAT_Amount_8Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Cln_VAT_Amount_8' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Cln_VAT_Amount_8Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime Credit_Note_Date
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tableCredit_Note_Form_12.Credit_Note_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Credit_Note_Date' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Credit_Note_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Credit_Note_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Credit_Note_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Credit_Note_No' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Credit_Note_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Dif_Other_Tax_Amount_9
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Dif_Other_Tax_Amount_9Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Dif_Other_Tax_Amount_9' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Dif_Other_Tax_Amount_9Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Dif_VAT_Amount_10
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Dif_VAT_Amount_10Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Dif_VAT_Amount_10' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Dif_VAT_Amount_10Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_NameAndQty_3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Goods_NameAndQty_3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_NameAndQty_3' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Goods_NameAndQty_3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Name_of_Goods
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Name_of_GoodsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Name_of_Goods' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Name_of_GoodsColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.OrgAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgAddress' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.OrgAddressColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.OrgBINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgBIN' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.OrgBINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string OrgFax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.OrgFaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgFax' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.OrgFaxColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.OrgNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgName' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.OrgNameColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.OrgTelephoneColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'OrgTelephone' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.OrgTelephoneColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.PartyAddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PartyAddress' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.PartyAddressColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.PartyNameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PartyName' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.PartyNameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string PartyTIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.PartyTINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'PartyTIN' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.PartyTINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Quantity_of_Goods
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Quantity_of_GoodsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Quantity_of_Goods' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Quantity_of_GoodsColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Rbt_Other_Tax_Amount_5
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Rbt_Other_Tax_Amount_5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Rbt_Other_Tax_Amount_5' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Rbt_Other_Tax_Amount_5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Rbt_VAT_Amount_6
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Rbt_VAT_Amount_6Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Rbt_VAT_Amount_6' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Rbt_VAT_Amount_6Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Remarks
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.RemarksColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Remarks' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.RemarksColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int SlNo_1
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tableCredit_Note_Form_12.SlNo_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SlNo_1' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.SlNo_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public double Total_Price_4
            {
                get
                {
                    double item;
                    try
                    {
                        item = (double)base[this.tableCredit_Note_Form_12.Total_Price_4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Total_Price_4' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Total_Price_4Column] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.Vehicle_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle_No' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Vehicle_NoColumn] = value;
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
                        item = (string)base[this.tableCredit_Note_Form_12.Vehicle_TypeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle_Type' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Vehicle_TypeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string VehicleTypeAndNo
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.VehicleTypeAndNoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'VehicleTypeAndNo' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.VehicleTypeAndNoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Credit_Note_Form_12Row(DataRowBuilder rb) : base(rb)
            {
                this.tableCredit_Note_Form_12 = (Credit_Note_Form_12.Credit_Note_Form_12DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallan_DateNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Challan_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallan_Sl_NoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Challan_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsChallan_SlAndDate_2Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Challan_SlAndDate_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCln_Other_Tax_Amount_7Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Cln_Other_Tax_Amount_7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCln_VAT_Amount_8Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Cln_VAT_Amount_8Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCredit_Note_DateNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Credit_Note_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCredit_Note_NoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Credit_Note_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDif_Other_Tax_Amount_9Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Dif_Other_Tax_Amount_9Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDif_VAT_Amount_10Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Dif_VAT_Amount_10Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_NameAndQty_3Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Goods_NameAndQty_3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsName_of_GoodsNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Name_of_GoodsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgAddressNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.OrgAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgBINNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.OrgBINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgFaxNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.OrgFaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgNameNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.OrgNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrgTelephoneNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.OrgTelephoneColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPartyAddressNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.PartyAddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPartyNameNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.PartyNameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPartyTINNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.PartyTINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQuantity_of_GoodsNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Quantity_of_GoodsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRbt_Other_Tax_Amount_5Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Rbt_Other_Tax_Amount_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRbt_VAT_Amount_6Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Rbt_VAT_Amount_6Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRemarksNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.RemarksColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSlNo_1Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.SlNo_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTotal_Price_4Null()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Total_Price_4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicle_NoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Vehicle_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicle_TypeNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Vehicle_TypeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicleTypeAndNoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.VehicleTypeAndNoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallan_DateNull()
            {
                base[this.tableCredit_Note_Form_12.Challan_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallan_Sl_NoNull()
            {
                base[this.tableCredit_Note_Form_12.Challan_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetChallan_SlAndDate_2Null()
            {
                base[this.tableCredit_Note_Form_12.Challan_SlAndDate_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCln_Other_Tax_Amount_7Null()
            {
                base[this.tableCredit_Note_Form_12.Cln_Other_Tax_Amount_7Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCln_VAT_Amount_8Null()
            {
                base[this.tableCredit_Note_Form_12.Cln_VAT_Amount_8Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCredit_Note_DateNull()
            {
                base[this.tableCredit_Note_Form_12.Credit_Note_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCredit_Note_NoNull()
            {
                base[this.tableCredit_Note_Form_12.Credit_Note_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDif_Other_Tax_Amount_9Null()
            {
                base[this.tableCredit_Note_Form_12.Dif_Other_Tax_Amount_9Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDif_VAT_Amount_10Null()
            {
                base[this.tableCredit_Note_Form_12.Dif_VAT_Amount_10Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_NameAndQty_3Null()
            {
                base[this.tableCredit_Note_Form_12.Goods_NameAndQty_3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetName_of_GoodsNull()
            {
                base[this.tableCredit_Note_Form_12.Name_of_GoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgAddressNull()
            {
                base[this.tableCredit_Note_Form_12.OrgAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgBINNull()
            {
                base[this.tableCredit_Note_Form_12.OrgBINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgFaxNull()
            {
                base[this.tableCredit_Note_Form_12.OrgFaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgNameNull()
            {
                base[this.tableCredit_Note_Form_12.OrgNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrgTelephoneNull()
            {
                base[this.tableCredit_Note_Form_12.OrgTelephoneColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPartyAddressNull()
            {
                base[this.tableCredit_Note_Form_12.PartyAddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPartyNameNull()
            {
                base[this.tableCredit_Note_Form_12.PartyNameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPartyTINNull()
            {
                base[this.tableCredit_Note_Form_12.PartyTINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQuantity_of_GoodsNull()
            {
                base[this.tableCredit_Note_Form_12.Quantity_of_GoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRbt_Other_Tax_Amount_5Null()
            {
                base[this.tableCredit_Note_Form_12.Rbt_Other_Tax_Amount_5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRbt_VAT_Amount_6Null()
            {
                base[this.tableCredit_Note_Form_12.Rbt_VAT_Amount_6Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRemarksNull()
            {
                base[this.tableCredit_Note_Form_12.RemarksColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSlNo_1Null()
            {
                base[this.tableCredit_Note_Form_12.SlNo_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTotal_Price_4Null()
            {
                base[this.tableCredit_Note_Form_12.Total_Price_4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicle_NoNull()
            {
                base[this.tableCredit_Note_Form_12.Vehicle_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicle_TypeNull()
            {
                base[this.tableCredit_Note_Form_12.Vehicle_TypeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicleTypeAndNoNull()
            {
                base[this.tableCredit_Note_Form_12.VehicleTypeAndNoColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Credit_Note_Form_12RowChangeEvent : EventArgs
        {
            private Credit_Note_Form_12.Credit_Note_Form_12Row eventRow;

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
            public Credit_Note_Form_12.Credit_Note_Form_12Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Credit_Note_Form_12RowChangeEvent(Credit_Note_Form_12.Credit_Note_Form_12Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Credit_Note_Form_12RowChangeEventHandler(object sender, Credit_Note_Form_12.Credit_Note_Form_12RowChangeEvent e);
    }
}


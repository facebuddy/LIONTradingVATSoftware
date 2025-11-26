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
    [XmlRoot("CurrentAccount18DS")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class CurrentAccount18DS : DataSet
    {
        private CurrentAccount18DS.CurrentAccount18DSDataTable tableCurrentAccount18DS;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public CurrentAccount18DS.CurrentAccount18DSDataTable _CurrentAccount18DS
        {
            get
            {
                return this.tableCurrentAccount18DS;
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
        public CurrentAccount18DS()
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
        protected CurrentAccount18DS(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["CurrentAccount18DS"] != null)
                {
                    base.Tables.Add(new CurrentAccount18DS.CurrentAccount18DSDataTable(dataSet.Tables["CurrentAccount18DS"]));
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
            CurrentAccount18DS schemaSerializationMode = (CurrentAccount18DS)base.Clone();
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
            CurrentAccount18DS currentAccount18D = new CurrentAccount18DS();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = currentAccount18D.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = currentAccount18D.GetSchemaSerializable();
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
            base.DataSetName = "CurrentAccount18DS";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/CurrentAccount18DS.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableCurrentAccount18DS = new CurrentAccount18DS.CurrentAccount18DSDataTable();
            base.Tables.Add(this.tableCurrentAccount18DS);
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
            this.tableCurrentAccount18DS = (CurrentAccount18DS.CurrentAccount18DSDataTable)base.Tables["CurrentAccount18DS"];
            if (initTable && this.tableCurrentAccount18DS != null)
            {
                this.tableCurrentAccount18DS.InitVars();
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
            if (dataSet.Tables["CurrentAccount18DS"] != null)
            {
                base.Tables.Add(new CurrentAccount18DS.CurrentAccount18DSDataTable(dataSet.Tables["CurrentAccount18DS"]));
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
        private bool ShouldSerialize_CurrentAccount18DS()
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
        public class CurrentAccount18DSDataTable : TypedTableBase<CurrentAccount18DS.CurrentAccount18DSRow>
        {
            private DataColumn columndate_challan;

            private DataColumn columntrns_desc;

            private DataColumn columnchallan_no;

            private DataColumn columntreasury_deposit;

            private DataColumn columnexempt_amount;

            private DataColumn columnpay_amount;

            private DataColumn columnbalance_amount;

            private DataColumn columnbalance_action;

            private DataColumn columnremarks;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn balance_actionColumn
            {
                get
                {
                    return this.columnbalance_action;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn balance_amountColumn
            {
                get
                {
                    return this.columnbalance_amount;
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
            public DataColumn date_challanColumn
            {
                get
                {
                    return this.columndate_challan;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn exempt_amountColumn
            {
                get
                {
                    return this.columnexempt_amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccount18DS.CurrentAccount18DSRow this[int index]
            {
                get
                {
                    return (CurrentAccount18DS.CurrentAccount18DSRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn pay_amountColumn
            {
                get
                {
                    return this.columnpay_amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn remarksColumn
            {
                get
                {
                    return this.columnremarks;
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
            public DataColumn trns_descColumn
            {
                get
                {
                    return this.columntrns_desc;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccount18DSDataTable()
            {
                base.TableName = "CurrentAccount18DS";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CurrentAccount18DSDataTable(DataTable table)
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
            protected CurrentAccount18DSDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddCurrentAccount18DSRow(CurrentAccount18DS.CurrentAccount18DSRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccount18DS.CurrentAccount18DSRow AddCurrentAccount18DSRow(DateTime date_challan, string trns_desc, string challan_no, decimal treasury_deposit, decimal exempt_amount, decimal pay_amount, decimal balance_amount, decimal balance_action, string remarks)
            {
                CurrentAccount18DS.CurrentAccount18DSRow currentAccount18DSRow = (CurrentAccount18DS.CurrentAccount18DSRow)base.NewRow();
                object[] dateChallan = new object[] { date_challan, trns_desc, challan_no, treasury_deposit, exempt_amount, pay_amount, balance_amount, balance_action, remarks };
                currentAccount18DSRow.ItemArray = dateChallan;
                base.Rows.Add(currentAccount18DSRow);
                return currentAccount18DSRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                CurrentAccount18DS.CurrentAccount18DSDataTable currentAccount18DSDataTable = (CurrentAccount18DS.CurrentAccount18DSDataTable)base.Clone();
                currentAccount18DSDataTable.InitVars();
                return currentAccount18DSDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new CurrentAccount18DS.CurrentAccount18DSDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(CurrentAccount18DS.CurrentAccount18DSRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                CurrentAccount18DS currentAccount18D = new CurrentAccount18DS();
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
                    FixedValue = currentAccount18D.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "CurrentAccount18DSDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = currentAccount18D.GetSchemaSerializable();
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
                this.columndate_challan = new DataColumn("date_challan", typeof(DateTime), null, MappingType.Element);
                base.Columns.Add(this.columndate_challan);
                this.columntrns_desc = new DataColumn("trns_desc", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntrns_desc);
                this.columnchallan_no = new DataColumn("challan_no", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnchallan_no);
                this.columntreasury_deposit = new DataColumn("treasury_deposit", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columntreasury_deposit);
                this.columnexempt_amount = new DataColumn("exempt_amount", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnexempt_amount);
                this.columnpay_amount = new DataColumn("pay_amount", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnpay_amount);
                this.columnbalance_amount = new DataColumn("balance_amount", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnbalance_amount);
                this.columnbalance_action = new DataColumn("balance_action", typeof(decimal), null, MappingType.Element);
                base.Columns.Add(this.columnbalance_action);
                this.columnremarks = new DataColumn("remarks", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnremarks);
                base.ExtendedProperties.Add("Generator_TablePropName", "_CurrentAccount18DS");
                base.ExtendedProperties.Add("Generator_UserTableName", "CurrentAccount18DS");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columndate_challan = base.Columns["date_challan"];
                this.columntrns_desc = base.Columns["trns_desc"];
                this.columnchallan_no = base.Columns["challan_no"];
                this.columntreasury_deposit = base.Columns["treasury_deposit"];
                this.columnexempt_amount = base.Columns["exempt_amount"];
                this.columnpay_amount = base.Columns["pay_amount"];
                this.columnbalance_amount = base.Columns["balance_amount"];
                this.columnbalance_action = base.Columns["balance_action"];
                this.columnremarks = base.Columns["remarks"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccount18DS.CurrentAccount18DSRow NewCurrentAccount18DSRow()
            {
                return (CurrentAccount18DS.CurrentAccount18DSRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new CurrentAccount18DS.CurrentAccount18DSRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.CurrentAccount18DSRowChanged != null)
                {
                    this.CurrentAccount18DSRowChanged(this, new CurrentAccount18DS.CurrentAccount18DSRowChangeEvent((CurrentAccount18DS.CurrentAccount18DSRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.CurrentAccount18DSRowChanging != null)
                {
                    this.CurrentAccount18DSRowChanging(this, new CurrentAccount18DS.CurrentAccount18DSRowChangeEvent((CurrentAccount18DS.CurrentAccount18DSRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.CurrentAccount18DSRowDeleted != null)
                {
                    this.CurrentAccount18DSRowDeleted(this, new CurrentAccount18DS.CurrentAccount18DSRowChangeEvent((CurrentAccount18DS.CurrentAccount18DSRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.CurrentAccount18DSRowDeleting != null)
                {
                    this.CurrentAccount18DSRowDeleting(this, new CurrentAccount18DS.CurrentAccount18DSRowChangeEvent((CurrentAccount18DS.CurrentAccount18DSRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCurrentAccount18DSRow(CurrentAccount18DS.CurrentAccount18DSRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event CurrentAccount18DS.CurrentAccount18DSRowChangeEventHandler CurrentAccount18DSRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event CurrentAccount18DS.CurrentAccount18DSRowChangeEventHandler CurrentAccount18DSRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event CurrentAccount18DS.CurrentAccount18DSRowChangeEventHandler CurrentAccount18DSRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event CurrentAccount18DS.CurrentAccount18DSRowChangeEventHandler CurrentAccount18DSRowDeleting;
        }

        public class CurrentAccount18DSRow : DataRow
        {
            private CurrentAccount18DS.CurrentAccount18DSDataTable tableCurrentAccount18DS;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal balance_action
            {
                get
                {
                    decimal item;
                    try
                    {
                        item = (decimal)base[this.tableCurrentAccount18DS.balance_actionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'balance_action' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.balance_actionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal balance_amount
            {
                get
                {
                    decimal item;
                    try
                    {
                        item = (decimal)base[this.tableCurrentAccount18DS.balance_amountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'balance_amount' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.balance_amountColumn] = value;
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
                        item = (string)base[this.tableCurrentAccount18DS.challan_noColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'challan_no' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.challan_noColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DateTime date_challan
            {
                get
                {
                    DateTime item;
                    try
                    {
                        item = (DateTime)base[this.tableCurrentAccount18DS.date_challanColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'date_challan' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.date_challanColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal exempt_amount
            {
                get
                {
                    decimal item;
                    try
                    {
                        item = (decimal)base[this.tableCurrentAccount18DS.exempt_amountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'exempt_amount' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.exempt_amountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal pay_amount
            {
                get
                {
                    decimal item;
                    try
                    {
                        item = (decimal)base[this.tableCurrentAccount18DS.pay_amountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'pay_amount' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.pay_amountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string remarks
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccount18DS.remarksColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'remarks' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.remarksColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public decimal treasury_deposit
            {
                get
                {
                    decimal item;
                    try
                    {
                        item = (decimal)base[this.tableCurrentAccount18DS.treasury_depositColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'treasury_deposit' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.treasury_depositColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string trns_desc
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccount18DS.trns_descColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'trns_desc' in table 'CurrentAccount18DS' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccount18DS.trns_descColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CurrentAccount18DSRow(DataRowBuilder rb) : base(rb)
            {
                this.tableCurrentAccount18DS = (CurrentAccount18DS.CurrentAccount18DSDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbalance_actionNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.balance_actionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbalance_amountNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.balance_amountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ischallan_noNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.challan_noColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isdate_challanNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.date_challanColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isexempt_amountNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.exempt_amountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispay_amountNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.pay_amountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsremarksNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.remarksColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Istreasury_depositNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.treasury_depositColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Istrns_descNull()
            {
                return base.IsNull(this.tableCurrentAccount18DS.trns_descColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbalance_actionNull()
            {
                base[this.tableCurrentAccount18DS.balance_actionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbalance_amountNull()
            {
                base[this.tableCurrentAccount18DS.balance_amountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setchallan_noNull()
            {
                base[this.tableCurrentAccount18DS.challan_noColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setdate_challanNull()
            {
                base[this.tableCurrentAccount18DS.date_challanColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setexempt_amountNull()
            {
                base[this.tableCurrentAccount18DS.exempt_amountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpay_amountNull()
            {
                base[this.tableCurrentAccount18DS.pay_amountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetremarksNull()
            {
                base[this.tableCurrentAccount18DS.remarksColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Settreasury_depositNull()
            {
                base[this.tableCurrentAccount18DS.treasury_depositColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Settrns_descNull()
            {
                base[this.tableCurrentAccount18DS.trns_descColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class CurrentAccount18DSRowChangeEvent : EventArgs
        {
            private CurrentAccount18DS.CurrentAccount18DSRow eventRow;

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
            public CurrentAccount18DS.CurrentAccount18DSRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccount18DSRowChangeEvent(CurrentAccount18DS.CurrentAccount18DSRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void CurrentAccount18DSRowChangeEventHandler(object sender, CurrentAccount18DS.CurrentAccount18DSRowChangeEvent e);
    }
}



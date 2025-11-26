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
    [XmlRoot("Form1Kha")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class Form1Kha : DataSet
    {
        private Form1Kha.Form1KhaDataTable tableForm1Kha;

        private Form1Kha.Form1GaDataTable tableForm1Ga;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Form1Kha.Form1KhaDataTable _Form1Kha
        {
            get
            {
                return this.tableForm1Kha;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public Form1Kha.Form1GaDataTable Form1Ga
        {
            get
            {
                return this.tableForm1Ga;
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
        public Form1Kha()
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
        protected Form1Kha(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Form1Kha"] != null)
                {
                    base.Tables.Add(new Form1Kha.Form1KhaDataTable(dataSet.Tables["Form1Kha"]));
                }
                if (dataSet.Tables["Form1Ga"] != null)
                {
                    base.Tables.Add(new Form1Kha.Form1GaDataTable(dataSet.Tables["Form1Ga"]));
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
            Form1Kha schemaSerializationMode = (Form1Kha)base.Clone();
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
            Form1Kha form1Kha = new Form1Kha();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = form1Kha.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = form1Kha.GetSchemaSerializable();
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
            base.DataSetName = "Form1Kha";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/Form1Kha.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableForm1Kha = new Form1Kha.Form1KhaDataTable();
            base.Tables.Add(this.tableForm1Kha);
            this.tableForm1Ga = new Form1Kha.Form1GaDataTable();
            base.Tables.Add(this.tableForm1Ga);
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
            this.tableForm1Kha = (Form1Kha.Form1KhaDataTable)base.Tables["Form1Kha"];
            if (initTable && this.tableForm1Kha != null)
            {
                this.tableForm1Kha.InitVars();
            }
            this.tableForm1Ga = (Form1Kha.Form1GaDataTable)base.Tables["Form1Ga"];
            if (initTable && this.tableForm1Ga != null)
            {
                this.tableForm1Ga.InitVars();
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
            if (dataSet.Tables["Form1Kha"] != null)
            {
                base.Tables.Add(new Form1Kha.Form1KhaDataTable(dataSet.Tables["Form1Kha"]));
            }
            if (dataSet.Tables["Form1Ga"] != null)
            {
                base.Tables.Add(new Form1Kha.Form1GaDataTable(dataSet.Tables["Form1Ga"]));
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
        private bool ShouldSerialize_Form1Kha()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeForm1Ga()
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
        public class Form1GaDataTable : TypedTableBase<Form1Kha.Form1GaRow>
        {
            private DataColumn column_1;

            private DataColumn column_2;

            private DataColumn column_3;

            private DataColumn column_3_1;

            private DataColumn column_4;

            private DataColumn column_5;

            private DataColumn column_5_1;

            private DataColumn column_6;

            private DataColumn column_7;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1Column
            {
                get
                {
                    return this.column_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2Column
            {
                get
                {
                    return this.column_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_1Column
            {
                get
                {
                    return this.column_3_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3Column
            {
                get
                {
                    return this.column_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4Column
            {
                get
                {
                    return this.column_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_1Column
            {
                get
                {
                    return this.column_5_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5Column
            {
                get
                {
                    return this.column_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6Column
            {
                get
                {
                    return this.column_6;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7Column
            {
                get
                {
                    return this.column_7;
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
            public Form1Kha.Form1GaRow this[int index]
            {
                get
                {
                    return (Form1Kha.Form1GaRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1GaDataTable()
            {
                base.TableName = "Form1Ga";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Form1GaDataTable(DataTable table)
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
            protected Form1GaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddForm1GaRow(Form1Kha.Form1GaRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1Kha.Form1GaRow AddForm1GaRow(string _1, string _2, string _3, string _3_1, string _4, string _5, string _5_1, string _6, string _7)
            {
                Form1Kha.Form1GaRow form1GaRow = (Form1Kha.Form1GaRow)base.NewRow();
                object[] objArray = new object[] { _1, _2, _3, _3_1, _4, _5, _5_1, _6, _7 };
                form1GaRow.ItemArray = objArray;
                base.Rows.Add(form1GaRow);
                return form1GaRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Form1Kha.Form1GaDataTable form1GaDataTable = (Form1Kha.Form1GaDataTable)base.Clone();
                form1GaDataTable.InitVars();
                return form1GaDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new Form1Kha.Form1GaDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Form1Kha.Form1GaRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                Form1Kha form1Kha = new Form1Kha();
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
                    FixedValue = form1Kha.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Form1GaDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = form1Kha.GetSchemaSerializable();
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
                this.column_1 = new DataColumn("_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_1);
                this.column_2 = new DataColumn("_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_2);
                this.column_3 = new DataColumn("_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_3);
                this.column_3_1 = new DataColumn("_3_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_3_1);
                this.column_4 = new DataColumn("_4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_4);
                this.column_5 = new DataColumn("_5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_5);
                this.column_5_1 = new DataColumn("_5_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_5_1);
                this.column_6 = new DataColumn("_6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_6);
                this.column_7 = new DataColumn("_7", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_7);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.column_1 = base.Columns["_1"];
                this.column_2 = base.Columns["_2"];
                this.column_3 = base.Columns["_3"];
                this.column_3_1 = base.Columns["_3_1"];
                this.column_4 = base.Columns["_4"];
                this.column_5 = base.Columns["_5"];
                this.column_5_1 = base.Columns["_5_1"];
                this.column_6 = base.Columns["_6"];
                this.column_7 = base.Columns["_7"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1Kha.Form1GaRow NewForm1GaRow()
            {
                return (Form1Kha.Form1GaRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Form1Kha.Form1GaRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Form1GaRowChanged != null)
                {
                    this.Form1GaRowChanged(this, new Form1Kha.Form1GaRowChangeEvent((Form1Kha.Form1GaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Form1GaRowChanging != null)
                {
                    this.Form1GaRowChanging(this, new Form1Kha.Form1GaRowChangeEvent((Form1Kha.Form1GaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Form1GaRowDeleted != null)
                {
                    this.Form1GaRowDeleted(this, new Form1Kha.Form1GaRowChangeEvent((Form1Kha.Form1GaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Form1GaRowDeleting != null)
                {
                    this.Form1GaRowDeleting(this, new Form1Kha.Form1GaRowChangeEvent((Form1Kha.Form1GaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveForm1GaRow(Form1Kha.Form1GaRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1GaRowChangeEventHandler Form1GaRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1GaRowChangeEventHandler Form1GaRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1GaRowChangeEventHandler Form1GaRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1GaRowChangeEventHandler Form1GaRowDeleting;
        }

        public class Form1GaRow : DataRow
        {
            private Form1Kha.Form1GaDataTable tableForm1Ga;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_1' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_2' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_3' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._3_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_3_1' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._3_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_4' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_5' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._5_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_5_1' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._5_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._6Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_6' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._6Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Ga._7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_7' in table 'Form1Ga' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Ga._7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Form1GaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableForm1Ga = (Form1Kha.Form1GaDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1Null()
            {
                return base.IsNull(this.tableForm1Ga._1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2Null()
            {
                return base.IsNull(this.tableForm1Ga._2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_1Null()
            {
                return base.IsNull(this.tableForm1Ga._3_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3Null()
            {
                return base.IsNull(this.tableForm1Ga._3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4Null()
            {
                return base.IsNull(this.tableForm1Ga._4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_1Null()
            {
                return base.IsNull(this.tableForm1Ga._5_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5Null()
            {
                return base.IsNull(this.tableForm1Ga._5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6Null()
            {
                return base.IsNull(this.tableForm1Ga._6Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7Null()
            {
                return base.IsNull(this.tableForm1Ga._7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_1Null()
            {
                base[this.tableForm1Ga._1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2Null()
            {
                base[this.tableForm1Ga._2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_1Null()
            {
                base[this.tableForm1Ga._3_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3Null()
            {
                base[this.tableForm1Ga._3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4Null()
            {
                base[this.tableForm1Ga._4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_1Null()
            {
                base[this.tableForm1Ga._5_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5Null()
            {
                base[this.tableForm1Ga._5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6Null()
            {
                base[this.tableForm1Ga._6Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7Null()
            {
                base[this.tableForm1Ga._7Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Form1GaRowChangeEvent : EventArgs
        {
            private Form1Kha.Form1GaRow eventRow;

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
            public Form1Kha.Form1GaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1GaRowChangeEvent(Form1Kha.Form1GaRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Form1GaRowChangeEventHandler(object sender, Form1Kha.Form1GaRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Form1KhaDataTable : TypedTableBase<Form1Kha.Form1KhaRow>
        {
            private DataColumn column_1;

            private DataColumn column_2;

            private DataColumn column_3;

            private DataColumn column_3_1;

            private DataColumn column_4;

            private DataColumn column_5;

            private DataColumn column_6_7;

            private DataColumn column_8;

            private DataColumn column_9_10;

            private DataColumn column_11_12;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _11_12Column
            {
                get
                {
                    return this.column_11_12;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1Column
            {
                get
                {
                    return this.column_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2Column
            {
                get
                {
                    return this.column_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_1Column
            {
                get
                {
                    return this.column_3_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3Column
            {
                get
                {
                    return this.column_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4Column
            {
                get
                {
                    return this.column_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5Column
            {
                get
                {
                    return this.column_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6_7Column
            {
                get
                {
                    return this.column_6_7;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _8Column
            {
                get
                {
                    return this.column_8;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _9_10Column
            {
                get
                {
                    return this.column_9_10;
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
            public Form1Kha.Form1KhaRow this[int index]
            {
                get
                {
                    return (Form1Kha.Form1KhaRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1KhaDataTable()
            {
                base.TableName = "Form1Kha";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Form1KhaDataTable(DataTable table)
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
            protected Form1KhaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddForm1KhaRow(Form1Kha.Form1KhaRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1Kha.Form1KhaRow AddForm1KhaRow(string _1, string _2, string _3, string _3_1, string _4, string _5, string _6_7, string _8, string _9_10, string _11_12)
            {
                Form1Kha.Form1KhaRow form1KhaRow = (Form1Kha.Form1KhaRow)base.NewRow();
                object[] objArray = new object[] { _1, _2, _3, _3_1, _4, _5, _6_7, _8, _9_10, _11_12 };
                form1KhaRow.ItemArray = objArray;
                base.Rows.Add(form1KhaRow);
                return form1KhaRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                Form1Kha.Form1KhaDataTable form1KhaDataTable = (Form1Kha.Form1KhaDataTable)base.Clone();
                form1KhaDataTable.InitVars();
                return form1KhaDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new Form1Kha.Form1KhaDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(Form1Kha.Form1KhaRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                Form1Kha form1Kha = new Form1Kha();
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
                    FixedValue = form1Kha.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Form1KhaDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = form1Kha.GetSchemaSerializable();
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
                this.column_1 = new DataColumn("_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_1);
                this.column_2 = new DataColumn("_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_2);
                this.column_3 = new DataColumn("_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_3);
                this.column_3_1 = new DataColumn("_3_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_3_1);
                this.column_4 = new DataColumn("_4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_4);
                this.column_5 = new DataColumn("_5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_5);
                this.column_6_7 = new DataColumn("_6_7", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_6_7);
                this.column_8 = new DataColumn("_8", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_8);
                this.column_9_10 = new DataColumn("_9_10", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_9_10);
                this.column_11_12 = new DataColumn("_11_12", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.column_11_12);
                base.ExtendedProperties.Add("Generator_TablePropName", "_Form1Kha");
                base.ExtendedProperties.Add("Generator_UserTableName", "Form1Kha");
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.column_1 = base.Columns["_1"];
                this.column_2 = base.Columns["_2"];
                this.column_3 = base.Columns["_3"];
                this.column_3_1 = base.Columns["_3_1"];
                this.column_4 = base.Columns["_4"];
                this.column_5 = base.Columns["_5"];
                this.column_6_7 = base.Columns["_6_7"];
                this.column_8 = base.Columns["_8"];
                this.column_9_10 = base.Columns["_9_10"];
                this.column_11_12 = base.Columns["_11_12"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1Kha.Form1KhaRow NewForm1KhaRow()
            {
                return (Form1Kha.Form1KhaRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new Form1Kha.Form1KhaRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Form1KhaRowChanged != null)
                {
                    this.Form1KhaRowChanged(this, new Form1Kha.Form1KhaRowChangeEvent((Form1Kha.Form1KhaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Form1KhaRowChanging != null)
                {
                    this.Form1KhaRowChanging(this, new Form1Kha.Form1KhaRowChangeEvent((Form1Kha.Form1KhaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Form1KhaRowDeleted != null)
                {
                    this.Form1KhaRowDeleted(this, new Form1Kha.Form1KhaRowChangeEvent((Form1Kha.Form1KhaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Form1KhaRowDeleting != null)
                {
                    this.Form1KhaRowDeleting(this, new Form1Kha.Form1KhaRowChangeEvent((Form1Kha.Form1KhaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveForm1KhaRow(Form1Kha.Form1KhaRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1KhaRowChangeEventHandler Form1KhaRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1KhaRowChangeEventHandler Form1KhaRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1KhaRowChangeEventHandler Form1KhaRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event Form1Kha.Form1KhaRowChangeEventHandler Form1KhaRowDeleting;
        }

        public class Form1KhaRow : DataRow
        {
            private Form1Kha.Form1KhaDataTable tableForm1Kha;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_1' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _11_12
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._11_12Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_11_12' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._11_12Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_2' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_3' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._3_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_3_1' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._3_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_4' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_5' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6_7
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._6_7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_6_7' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._6_7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _8
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._8Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_8' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._8Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _9_10
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableForm1Kha._9_10Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '_9_10' in table 'Form1Kha' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableForm1Kha._9_10Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Form1KhaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableForm1Kha = (Form1Kha.Form1KhaDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_11_12Null()
            {
                return base.IsNull(this.tableForm1Kha._11_12Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1Null()
            {
                return base.IsNull(this.tableForm1Kha._1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2Null()
            {
                return base.IsNull(this.tableForm1Kha._2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_1Null()
            {
                return base.IsNull(this.tableForm1Kha._3_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3Null()
            {
                return base.IsNull(this.tableForm1Kha._3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4Null()
            {
                return base.IsNull(this.tableForm1Kha._4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5Null()
            {
                return base.IsNull(this.tableForm1Kha._5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6_7Null()
            {
                return base.IsNull(this.tableForm1Kha._6_7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_8Null()
            {
                return base.IsNull(this.tableForm1Kha._8Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_9_10Null()
            {
                return base.IsNull(this.tableForm1Kha._9_10Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_11_12Null()
            {
                base[this.tableForm1Kha._11_12Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_1Null()
            {
                base[this.tableForm1Kha._1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2Null()
            {
                base[this.tableForm1Kha._2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_1Null()
            {
                base[this.tableForm1Kha._3_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3Null()
            {
                base[this.tableForm1Kha._3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4Null()
            {
                base[this.tableForm1Kha._4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5Null()
            {
                base[this.tableForm1Kha._5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6_7Null()
            {
                base[this.tableForm1Kha._6_7Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_8Null()
            {
                base[this.tableForm1Kha._8Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_9_10Null()
            {
                base[this.tableForm1Kha._9_10Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Form1KhaRowChangeEvent : EventArgs
        {
            private Form1Kha.Form1KhaRow eventRow;

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
            public Form1Kha.Form1KhaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Form1KhaRowChangeEvent(Form1Kha.Form1KhaRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Form1KhaRowChangeEventHandler(object sender, Form1Kha.Form1KhaRowChangeEvent e);
    }
}


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
    [XmlRoot("DisposeDataset")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class DisposeDataset : DataSet
    {
        private DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable tableDisposal_of_UnusedUnfit_Inputs_Form_26;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable Disposal_of_UnusedUnfit_Inputs_Form_26
        {
            get
            {
                return this.tableDisposal_of_UnusedUnfit_Inputs_Form_26;
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
        public DisposeDataset()
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
        protected DisposeDataset(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"] != null)
                {
                    base.Tables.Add(new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable(dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"]));
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
            DisposeDataset schemaSerializationMode = (DisposeDataset)base.Clone();
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
            DisposeDataset disposeDataset = new DisposeDataset();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = disposeDataset.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = disposeDataset.GetSchemaSerializable();
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
            base.DataSetName = "DisposeDataset";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/DisposeDataset.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 = new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable();
            base.Tables.Add(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26);
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
            this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 = (DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable)base.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"];
            if (initTable && this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 != null)
            {
                this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.InitVars();
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
            if (dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"] != null)
            {
                base.Tables.Add(new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable(dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"]));
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
        private bool ShouldSerializeDisposal_of_UnusedUnfit_Inputs_Form_26()
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
        public class Disposal_of_UnusedUnfit_Inputs_Form_26DataTable : TypedTableBase<DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row>
        {
            private DataColumn columnOrganization_name;

            private DataColumn columnOrganization_address;

            private DataColumn columnOrganization_BIN;

            private DataColumn columnBusiness_activity_code;

            private DataColumn columnArea_code;

            private DataColumn columnTelephone_no;

            private DataColumn columnSl_No_1;

            private DataColumn columnName_of_Inputs_2;

            private DataColumn columnSl_No_of_Purchase_Challan_and_Sales_Book_3;

            private DataColumn columnQuantity_4;

            private DataColumn columnActual_Value_5;

            private DataColumn columnVAT_Paid_6;

            private DataColumn columnPresent_Value_7;

            private DataColumn columnReason_for_the_Unfit_8;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Actual_Value_5Column
            {
                get
                {
                    return this.columnActual_Value_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Area_codeColumn
            {
                get
                {
                    return this.columnArea_code;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Business_activity_codeColumn
            {
                get
                {
                    return this.columnBusiness_activity_code;
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
            public DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row this[int index]
            {
                get
                {
                    return (DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Name_of_Inputs_2Column
            {
                get
                {
                    return this.columnName_of_Inputs_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Organization_addressColumn
            {
                get
                {
                    return this.columnOrganization_address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Organization_BINColumn
            {
                get
                {
                    return this.columnOrganization_BIN;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Organization_nameColumn
            {
                get
                {
                    return this.columnOrganization_name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Present_Value_7Column
            {
                get
                {
                    return this.columnPresent_Value_7;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Quantity_4Column
            {
                get
                {
                    return this.columnQuantity_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Reason_for_the_Unfit_8Column
            {
                get
                {
                    return this.columnReason_for_the_Unfit_8;
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
            public DataColumn Sl_No_of_Purchase_Challan_and_Sales_Book_3Column
            {
                get
                {
                    return this.columnSl_No_of_Purchase_Challan_and_Sales_Book_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Telephone_noColumn
            {
                get
                {
                    return this.columnTelephone_no;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VAT_Paid_6Column
            {
                get
                {
                    return this.columnVAT_Paid_6;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Disposal_of_UnusedUnfit_Inputs_Form_26DataTable()
            {
                base.TableName = "Disposal_of_UnusedUnfit_Inputs_Form_26";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Disposal_of_UnusedUnfit_Inputs_Form_26DataTable(DataTable table)
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
            protected Disposal_of_UnusedUnfit_Inputs_Form_26DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddDisposal_of_UnusedUnfit_Inputs_Form_26Row(DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row AddDisposal_of_UnusedUnfit_Inputs_Form_26Row(string Organization_name, string Organization_address, string Organization_BIN, string Business_activity_code, string Area_code, string Telephone_no, string Sl_No_1, string Name_of_Inputs_2, string Sl_No_of_Purchase_Challan_and_Sales_Book_3, string Quantity_4, string Actual_Value_5, string VAT_Paid_6, string Present_Value_7, string Reason_for_the_Unfit_8)
            {
                DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row disposalOfUnusedUnfitInputsForm26Row = (DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)base.NewRow();
                object[] organizationName = new object[] { Organization_name, Organization_address, Organization_BIN, Business_activity_code, Area_code, Telephone_no, Sl_No_1, Name_of_Inputs_2, Sl_No_of_Purchase_Challan_and_Sales_Book_3, Quantity_4, Actual_Value_5, VAT_Paid_6, Present_Value_7, Reason_for_the_Unfit_8 };
                disposalOfUnusedUnfitInputsForm26Row.ItemArray = organizationName;
                base.Rows.Add(disposalOfUnusedUnfitInputsForm26Row);
                return disposalOfUnusedUnfitInputsForm26Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable disposalOfUnusedUnfitInputsForm26DataTable = (DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable)base.Clone();
                disposalOfUnusedUnfitInputsForm26DataTable.InitVars();
                return disposalOfUnusedUnfitInputsForm26DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                DisposeDataset disposeDataset = new DisposeDataset();
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
                    FixedValue = disposeDataset.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Disposal_of_UnusedUnfit_Inputs_Form_26DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = disposeDataset.GetSchemaSerializable();
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
                this.columnOrganization_name = new DataColumn("Organization_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrganization_name);
                this.columnOrganization_address = new DataColumn("Organization_address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrganization_address);
                this.columnOrganization_BIN = new DataColumn("Organization_BIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOrganization_BIN);
                this.columnBusiness_activity_code = new DataColumn("Business_activity_code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBusiness_activity_code);
                this.columnArea_code = new DataColumn("Area_code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnArea_code);
                this.columnTelephone_no = new DataColumn("Telephone_no", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTelephone_no);
                this.columnSl_No_1 = new DataColumn("Sl_No_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSl_No_1);
                this.columnName_of_Inputs_2 = new DataColumn("Name_of_Inputs_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnName_of_Inputs_2);
                this.columnSl_No_of_Purchase_Challan_and_Sales_Book_3 = new DataColumn("Sl_No_of_Purchase_Challan_and_Sales_Book_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSl_No_of_Purchase_Challan_and_Sales_Book_3);
                this.columnQuantity_4 = new DataColumn("Quantity_4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnQuantity_4);
                this.columnActual_Value_5 = new DataColumn("Actual_Value_5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnActual_Value_5);
                this.columnVAT_Paid_6 = new DataColumn("VAT_Paid_6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVAT_Paid_6);
                this.columnPresent_Value_7 = new DataColumn("Present_Value_7", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPresent_Value_7);
                this.columnReason_for_the_Unfit_8 = new DataColumn("Reason_for_the_Unfit_8", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnReason_for_the_Unfit_8);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnOrganization_name = base.Columns["Organization_name"];
                this.columnOrganization_address = base.Columns["Organization_address"];
                this.columnOrganization_BIN = base.Columns["Organization_BIN"];
                this.columnBusiness_activity_code = base.Columns["Business_activity_code"];
                this.columnArea_code = base.Columns["Area_code"];
                this.columnTelephone_no = base.Columns["Telephone_no"];
                this.columnSl_No_1 = base.Columns["Sl_No_1"];
                this.columnName_of_Inputs_2 = base.Columns["Name_of_Inputs_2"];
                this.columnSl_No_of_Purchase_Challan_and_Sales_Book_3 = base.Columns["Sl_No_of_Purchase_Challan_and_Sales_Book_3"];
                this.columnQuantity_4 = base.Columns["Quantity_4"];
                this.columnActual_Value_5 = base.Columns["Actual_Value_5"];
                this.columnVAT_Paid_6 = base.Columns["VAT_Paid_6"];
                this.columnPresent_Value_7 = base.Columns["Present_Value_7"];
                this.columnReason_for_the_Unfit_8 = base.Columns["Reason_for_the_Unfit_8"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row NewDisposal_of_UnusedUnfit_Inputs_Form_26Row()
            {
                return (DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanged != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanged(this, new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanging != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanging(this, new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleted != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleted(this, new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleting != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleting(this, new DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveDisposal_of_UnusedUnfit_Inputs_Form_26Row(DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleting;
        }

        public class Disposal_of_UnusedUnfit_Inputs_Form_26Row : DataRow
        {
            private DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable tableDisposal_of_UnusedUnfit_Inputs_Form_26;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Actual_Value_5
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Actual_Value_5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Actual_Value_5' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Actual_Value_5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Area_code
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Area_codeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Area_code' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Area_codeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Business_activity_code
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Business_activity_codeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Business_activity_code' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Business_activity_codeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Name_of_Inputs_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Name_of_Inputs_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Name_of_Inputs_2' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Name_of_Inputs_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Organization_address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_addressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Organization_address' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_addressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Organization_BIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_BINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Organization_BIN' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_BINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Organization_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Organization_name' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Present_Value_7
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Present_Value_7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Present_Value_7' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Present_Value_7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Quantity_4
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Quantity_4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Quantity_4' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Quantity_4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Reason_for_the_Unfit_8
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Reason_for_the_Unfit_8Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Reason_for_the_Unfit_8' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Reason_for_the_Unfit_8Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sl_No_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sl_No_1' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sl_No_of_Purchase_Challan_and_Sales_Book_3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_of_Purchase_Challan_and_Sales_Book_3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sl_No_of_Purchase_Challan_and_Sales_Book_3' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_of_Purchase_Challan_and_Sales_Book_3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Telephone_no
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Telephone_noColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Telephone_no' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Telephone_noColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string VAT_Paid_6
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.VAT_Paid_6Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'VAT_Paid_6' in table 'Disposal_of_UnusedUnfit_Inputs_Form_26' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.VAT_Paid_6Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Disposal_of_UnusedUnfit_Inputs_Form_26Row(DataRowBuilder rb) : base(rb)
            {
                this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 = (DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsActual_Value_5Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Actual_Value_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsArea_codeNull()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Area_codeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBusiness_activity_codeNull()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Business_activity_codeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsName_of_Inputs_2Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Name_of_Inputs_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrganization_addressNull()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_addressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrganization_BINNull()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_BINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOrganization_nameNull()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPresent_Value_7Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Present_Value_7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsQuantity_4Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Quantity_4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsReason_for_the_Unfit_8Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Reason_for_the_Unfit_8Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSl_No_1Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSl_No_of_Purchase_Challan_and_Sales_Book_3Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_of_Purchase_Challan_and_Sales_Book_3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTelephone_noNull()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Telephone_noColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVAT_Paid_6Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.VAT_Paid_6Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetActual_Value_5Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Actual_Value_5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetArea_codeNull()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Area_codeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBusiness_activity_codeNull()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Business_activity_codeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetName_of_Inputs_2Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Name_of_Inputs_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrganization_addressNull()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrganization_BINNull()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_BINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOrganization_nameNull()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Organization_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPresent_Value_7Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Present_Value_7Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetQuantity_4Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Quantity_4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetReason_for_the_Unfit_8Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Reason_for_the_Unfit_8Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSl_No_1Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSl_No_of_Purchase_Challan_and_Sales_Book_3Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Sl_No_of_Purchase_Challan_and_Sales_Book_3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTelephone_noNull()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Telephone_noColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVAT_Paid_6Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.VAT_Paid_6Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent : EventArgs
        {
            private DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row eventRow;

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
            public DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent(DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler(object sender, DisposeDataset.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent e);
    }
}

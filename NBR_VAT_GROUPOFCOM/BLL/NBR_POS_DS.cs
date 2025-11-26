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
    [XmlRoot("NBR_POS_DS")]
    [XmlSchemaProvider("GetTypedDataSetSchema")]
    public class NBR_POS_DS : DataSet
    {
        private NBR_POS_DS.Price_Declaration_Form_1DataTable tablePrice_Declaration_Form_1;

        private NBR_POS_DS.testDataTable tabletest;

        private NBR_POS_DS.Company_InfoDataTable tableCompany_Info;

        private NBR_POS_DS.CountryDataTable tableCountry;

        private NBR_POS_DS.Challan_Form_11DataTable tableChallan_Form_11;

        private NBR_POS_DS.Credit_Note_Form_12DataTable tableCredit_Note_Form_12;

        private NBR_POS_DS.Debit_Note_Form_12_KaDataTable tableDebit_Note_Form_12_Ka;

        private NBR_POS_DS.Purchase_Account_Form_16DataTable tablePurchase_Account_Form_16;

        private NBR_POS_DS.Sales_Account_Form_17DataTable tableSales_Account_Form_17;

        private NBR_POS_DS.CurrentAccountForm18DataTable tableCurrentAccountForm18;

        private NBR_POS_DS.VAT_Return_Form_19DataTable tableVAT_Return_Form_19;

        private NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable tableDisposal_of_UnusedUnfit_Inputs_Form_26;

        private NBR_POS_DS.PDFDataTable tablePDF;

        private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Challan_Form_11DataTable Challan_Form_11
        {
            get
            {
                return this.tableChallan_Form_11;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Company_InfoDataTable Company_Info
        {
            get
            {
                return this.tableCompany_Info;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.CountryDataTable Country
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
        public NBR_POS_DS.Credit_Note_Form_12DataTable Credit_Note_Form_12
        {
            get
            {
                return this.tableCredit_Note_Form_12;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.CurrentAccountForm18DataTable CurrentAccountForm18
        {
            get
            {
                return this.tableCurrentAccountForm18;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Debit_Note_Form_12_KaDataTable Debit_Note_Form_12_Ka
        {
            get
            {
                return this.tableDebit_Note_Form_12_Ka;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable Disposal_of_UnusedUnfit_Inputs_Form_26
        {
            get
            {
                return this.tableDisposal_of_UnusedUnfit_Inputs_Form_26;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.PDFDataTable PDF
        {
            get
            {
                return this.tablePDF;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Price_Declaration_Form_1DataTable Price_Declaration_Form_1
        {
            get
            {
                return this.tablePrice_Declaration_Form_1;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Purchase_Account_Form_16DataTable Purchase_Account_Form_16
        {
            get
            {
                return this.tablePurchase_Account_Form_16;
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

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.Sales_Account_Form_17DataTable Sales_Account_Form_17
        {
            get
            {
                return this.tableSales_Account_Form_17;
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

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.testDataTable test
        {
            get
            {
                return this.tabletest;
            }
        }

        [Browsable(false)]
        [DebuggerNonUserCode]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS.VAT_Return_Form_19DataTable VAT_Return_Form_19
        {
            get
            {
                return this.tableVAT_Return_Form_19;
            }
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public NBR_POS_DS()
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
        protected NBR_POS_DS(SerializationInfo info, StreamingContext context) : base(info, context, false)
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
                if (dataSet.Tables["Price_Declaration_Form_1"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Price_Declaration_Form_1DataTable(dataSet.Tables["Price_Declaration_Form_1"]));
                }
                if (dataSet.Tables["test"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.testDataTable(dataSet.Tables["test"]));
                }
                if (dataSet.Tables["Company_Info"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Company_InfoDataTable(dataSet.Tables["Company_Info"]));
                }
                if (dataSet.Tables["Country"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.CountryDataTable(dataSet.Tables["Country"]));
                }
                if (dataSet.Tables["Challan_Form_11"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Challan_Form_11DataTable(dataSet.Tables["Challan_Form_11"]));
                }
                if (dataSet.Tables["Credit_Note_Form_12"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Credit_Note_Form_12DataTable(dataSet.Tables["Credit_Note_Form_12"]));
                }
                if (dataSet.Tables["Debit_Note_Form_12_Ka"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Debit_Note_Form_12_KaDataTable(dataSet.Tables["Debit_Note_Form_12_Ka"]));
                }
                if (dataSet.Tables["Purchase_Account_Form_16"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Purchase_Account_Form_16DataTable(dataSet.Tables["Purchase_Account_Form_16"]));
                }
                if (dataSet.Tables["Sales_Account_Form_17"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Sales_Account_Form_17DataTable(dataSet.Tables["Sales_Account_Form_17"]));
                }
                if (dataSet.Tables["CurrentAccountForm18"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.CurrentAccountForm18DataTable(dataSet.Tables["CurrentAccountForm18"]));
                }
                if (dataSet.Tables["VAT_Return_Form_19"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.VAT_Return_Form_19DataTable(dataSet.Tables["VAT_Return_Form_19"]));
                }
                if (dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable(dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"]));
                }
                if (dataSet.Tables["PDF"] != null)
                {
                    base.Tables.Add(new NBR_POS_DS.PDFDataTable(dataSet.Tables["PDF"]));
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
            NBR_POS_DS schemaSerializationMode = (NBR_POS_DS)base.Clone();
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
            NBR_POS_DS nBRPOSD = new NBR_POS_DS();
            XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
            XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
            XmlSchemaAny xmlSchemaAny = new XmlSchemaAny()
            {
                Namespace = nBRPOSD.Namespace
            };
            xmlSchemaSequence.Items.Add(xmlSchemaAny);
            xmlSchemaComplexType1.Particle = xmlSchemaSequence;
            XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
            base.DataSetName = "NBR_POS_DS";
            base.Prefix = "";
            base.Namespace = "http://tempuri.org/NBR_POS_DS.xsd";
            base.EnforceConstraints = true;
            this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
            this.tablePrice_Declaration_Form_1 = new NBR_POS_DS.Price_Declaration_Form_1DataTable();
            base.Tables.Add(this.tablePrice_Declaration_Form_1);
            this.tabletest = new NBR_POS_DS.testDataTable();
            base.Tables.Add(this.tabletest);
            this.tableCompany_Info = new NBR_POS_DS.Company_InfoDataTable();
            base.Tables.Add(this.tableCompany_Info);
            this.tableCountry = new NBR_POS_DS.CountryDataTable();
            base.Tables.Add(this.tableCountry);
            this.tableChallan_Form_11 = new NBR_POS_DS.Challan_Form_11DataTable();
            base.Tables.Add(this.tableChallan_Form_11);
            this.tableCredit_Note_Form_12 = new NBR_POS_DS.Credit_Note_Form_12DataTable();
            base.Tables.Add(this.tableCredit_Note_Form_12);
            this.tableDebit_Note_Form_12_Ka = new NBR_POS_DS.Debit_Note_Form_12_KaDataTable();
            base.Tables.Add(this.tableDebit_Note_Form_12_Ka);
            this.tablePurchase_Account_Form_16 = new NBR_POS_DS.Purchase_Account_Form_16DataTable();
            base.Tables.Add(this.tablePurchase_Account_Form_16);
            this.tableSales_Account_Form_17 = new NBR_POS_DS.Sales_Account_Form_17DataTable();
            base.Tables.Add(this.tableSales_Account_Form_17);
            this.tableCurrentAccountForm18 = new NBR_POS_DS.CurrentAccountForm18DataTable();
            base.Tables.Add(this.tableCurrentAccountForm18);
            this.tableVAT_Return_Form_19 = new NBR_POS_DS.VAT_Return_Form_19DataTable();
            base.Tables.Add(this.tableVAT_Return_Form_19);
            this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 = new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable();
            base.Tables.Add(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26);
            this.tablePDF = new NBR_POS_DS.PDFDataTable();
            base.Tables.Add(this.tablePDF);
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
            this.tablePrice_Declaration_Form_1 = (NBR_POS_DS.Price_Declaration_Form_1DataTable)base.Tables["Price_Declaration_Form_1"];
            if (initTable && this.tablePrice_Declaration_Form_1 != null)
            {
                this.tablePrice_Declaration_Form_1.InitVars();
            }
            this.tabletest = (NBR_POS_DS.testDataTable)base.Tables["test"];
            if (initTable && this.tabletest != null)
            {
                this.tabletest.InitVars();
            }
            this.tableCompany_Info = (NBR_POS_DS.Company_InfoDataTable)base.Tables["Company_Info"];
            if (initTable && this.tableCompany_Info != null)
            {
                this.tableCompany_Info.InitVars();
            }
            this.tableCountry = (NBR_POS_DS.CountryDataTable)base.Tables["Country"];
            if (initTable && this.tableCountry != null)
            {
                this.tableCountry.InitVars();
            }
            this.tableChallan_Form_11 = (NBR_POS_DS.Challan_Form_11DataTable)base.Tables["Challan_Form_11"];
            if (initTable && this.tableChallan_Form_11 != null)
            {
                this.tableChallan_Form_11.InitVars();
            }
            this.tableCredit_Note_Form_12 = (NBR_POS_DS.Credit_Note_Form_12DataTable)base.Tables["Credit_Note_Form_12"];
            if (initTable && this.tableCredit_Note_Form_12 != null)
            {
                this.tableCredit_Note_Form_12.InitVars();
            }
            this.tableDebit_Note_Form_12_Ka = (NBR_POS_DS.Debit_Note_Form_12_KaDataTable)base.Tables["Debit_Note_Form_12_Ka"];
            if (initTable && this.tableDebit_Note_Form_12_Ka != null)
            {
                this.tableDebit_Note_Form_12_Ka.InitVars();
            }
            this.tablePurchase_Account_Form_16 = (NBR_POS_DS.Purchase_Account_Form_16DataTable)base.Tables["Purchase_Account_Form_16"];
            if (initTable && this.tablePurchase_Account_Form_16 != null)
            {
                this.tablePurchase_Account_Form_16.InitVars();
            }
            this.tableSales_Account_Form_17 = (NBR_POS_DS.Sales_Account_Form_17DataTable)base.Tables["Sales_Account_Form_17"];
            if (initTable && this.tableSales_Account_Form_17 != null)
            {
                this.tableSales_Account_Form_17.InitVars();
            }
            this.tableCurrentAccountForm18 = (NBR_POS_DS.CurrentAccountForm18DataTable)base.Tables["CurrentAccountForm18"];
            if (initTable && this.tableCurrentAccountForm18 != null)
            {
                this.tableCurrentAccountForm18.InitVars();
            }
            this.tableVAT_Return_Form_19 = (NBR_POS_DS.VAT_Return_Form_19DataTable)base.Tables["VAT_Return_Form_19"];
            if (initTable && this.tableVAT_Return_Form_19 != null)
            {
                this.tableVAT_Return_Form_19.InitVars();
            }
            this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 = (NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable)base.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"];
            if (initTable && this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 != null)
            {
                this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.InitVars();
            }
            this.tablePDF = (NBR_POS_DS.PDFDataTable)base.Tables["PDF"];
            if (initTable && this.tablePDF != null)
            {
                this.tablePDF.InitVars();
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
            if (dataSet.Tables["Price_Declaration_Form_1"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Price_Declaration_Form_1DataTable(dataSet.Tables["Price_Declaration_Form_1"]));
            }
            if (dataSet.Tables["test"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.testDataTable(dataSet.Tables["test"]));
            }
            if (dataSet.Tables["Company_Info"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Company_InfoDataTable(dataSet.Tables["Company_Info"]));
            }
            if (dataSet.Tables["Country"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.CountryDataTable(dataSet.Tables["Country"]));
            }
            if (dataSet.Tables["Challan_Form_11"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Challan_Form_11DataTable(dataSet.Tables["Challan_Form_11"]));
            }
            if (dataSet.Tables["Credit_Note_Form_12"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Credit_Note_Form_12DataTable(dataSet.Tables["Credit_Note_Form_12"]));
            }
            if (dataSet.Tables["Debit_Note_Form_12_Ka"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Debit_Note_Form_12_KaDataTable(dataSet.Tables["Debit_Note_Form_12_Ka"]));
            }
            if (dataSet.Tables["Purchase_Account_Form_16"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Purchase_Account_Form_16DataTable(dataSet.Tables["Purchase_Account_Form_16"]));
            }
            if (dataSet.Tables["Sales_Account_Form_17"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Sales_Account_Form_17DataTable(dataSet.Tables["Sales_Account_Form_17"]));
            }
            if (dataSet.Tables["CurrentAccountForm18"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.CurrentAccountForm18DataTable(dataSet.Tables["CurrentAccountForm18"]));
            }
            if (dataSet.Tables["VAT_Return_Form_19"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.VAT_Return_Form_19DataTable(dataSet.Tables["VAT_Return_Form_19"]));
            }
            if (dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable(dataSet.Tables["Disposal_of_UnusedUnfit_Inputs_Form_26"]));
            }
            if (dataSet.Tables["PDF"] != null)
            {
                base.Tables.Add(new NBR_POS_DS.PDFDataTable(dataSet.Tables["PDF"]));
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
        private bool ShouldSerializeChallan_Form_11()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeCompany_Info()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeCountry()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeCredit_Note_Form_12()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeCurrentAccountForm18()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeDebit_Note_Form_12_Ka()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeDisposal_of_UnusedUnfit_Inputs_Form_26()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializePDF()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializePrice_Declaration_Form_1()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializePurchase_Account_Form_16()
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
        private bool ShouldSerializeSales_Account_Form_17()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        protected override bool ShouldSerializeTables()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializetest()
        {
            return false;
        }

        [DebuggerNonUserCode]
        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        private bool ShouldSerializeVAT_Return_Form_19()
        {
            return false;
        }

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Challan_Form_11DataTable : TypedTableBase<NBR_POS_DS.Challan_Form_11Row>
        {
            private DataColumn columnCustomer_Name;

            private DataColumn columnCustomer_Address;

            private DataColumn columnCustomer_TIN;

            private DataColumn columnGoods_Services_Shipping_Address;

            private DataColumn columnVehicle_Type;

            private DataColumn columnChallan_No;

            private DataColumn columnChallan_Date;

            private DataColumn columnChallan_Time;

            private DataColumn columnGoods_Unload_Date_Time;

            private DataColumn column1_Sl_No;

            private DataColumn column2_Goods_Services_Name;

            private DataColumn column3_Quantity;

            private DataColumn column4_SD_Applicable_Price;

            private DataColumn column5_SD_Amount;

            private DataColumn column7_VAT_Amount;

            private DataColumn columnVehicle_No;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1_Sl_NoColumn
            {
                get
                {
                    return this.column1_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_Goods_Services_NameColumn
            {
                get
                {
                    return this.column2_Goods_Services_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_QuantityColumn
            {
                get
                {
                    return this.column3_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4_SD_Applicable_PriceColumn
            {
                get
                {
                    return this.column4_SD_Applicable_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_SD_AmountColumn
            {
                get
                {
                    return this.column5_SD_Amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7_VAT_AmountColumn
            {
                get
                {
                    return this.column7_VAT_Amount;
                }
            }

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
            public DataColumn Customer_NameColumn
            {
                get
                {
                    return this.columnCustomer_Name;
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
            public NBR_POS_DS.Challan_Form_11Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Challan_Form_11Row)base.Rows[index];
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
            public void AddChallan_Form_11Row(NBR_POS_DS.Challan_Form_11Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Challan_Form_11Row AddChallan_Form_11Row(string Customer_Name, string Customer_Address, string Customer_TIN, string Goods_Services_Shipping_Address, string Vehicle_Type, string Challan_No, string Challan_Date, string Challan_Time, string Goods_Unload_Date_Time, string _2_Goods_Services_Name, string _3_Quantity, string _4_SD_Applicable_Price, string _5_SD_Amount, string _7_VAT_Amount, string Vehicle_No)
            {
                NBR_POS_DS.Challan_Form_11Row challanForm11Row = (NBR_POS_DS.Challan_Form_11Row)base.NewRow();
                object[] customerName = new object[] { Customer_Name, Customer_Address, Customer_TIN, Goods_Services_Shipping_Address, Vehicle_Type, Challan_No, Challan_Date, Challan_Time, Goods_Unload_Date_Time, null, _2_Goods_Services_Name, _3_Quantity, _4_SD_Applicable_Price, _5_SD_Amount, _7_VAT_Amount, Vehicle_No };
                challanForm11Row.ItemArray = customerName;
                base.Rows.Add(challanForm11Row);
                return challanForm11Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Challan_Form_11DataTable challanForm11DataTable = (NBR_POS_DS.Challan_Form_11DataTable)base.Clone();
                challanForm11DataTable.InitVars();
                return challanForm11DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Challan_Form_11DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Challan_Form_11Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Challan_Form_11DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnCustomer_Name = new DataColumn("Customer_Name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCustomer_Name);
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
                this.columnGoods_Unload_Date_Time = new DataColumn("Goods_Unload_Date_Time", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Unload_Date_Time);
                this.column1_Sl_No = new DataColumn("1_Sl_No", typeof(int), null, MappingType.Element);
                this.column1_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column1_Sl_No");
                this.column1_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "1_Sl_No");
                base.Columns.Add(this.column1_Sl_No);
                this.column2_Goods_Services_Name = new DataColumn("2_Goods_Services_Name", typeof(string), null, MappingType.Element);
                this.column2_Goods_Services_Name.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column2_Goods_Services_Name");
                this.column2_Goods_Services_Name.ExtendedProperties.Add("Generator_UserColumnName", "2_Goods_Services_Name");
                base.Columns.Add(this.column2_Goods_Services_Name);
                this.column3_Quantity = new DataColumn("3_Quantity", typeof(string), null, MappingType.Element);
                this.column3_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column3_Quantity");
                this.column3_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "3_Quantity");
                base.Columns.Add(this.column3_Quantity);
                this.column4_SD_Applicable_Price = new DataColumn("4_SD_Applicable_Price", typeof(string), null, MappingType.Element);
                this.column4_SD_Applicable_Price.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column4_SD_Applicable_Price");
                this.column4_SD_Applicable_Price.ExtendedProperties.Add("Generator_UserColumnName", "4_SD_Applicable_Price");
                base.Columns.Add(this.column4_SD_Applicable_Price);
                this.column5_SD_Amount = new DataColumn("5_SD_Amount", typeof(string), null, MappingType.Element);
                this.column5_SD_Amount.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column5_SD_Amount");
                this.column5_SD_Amount.ExtendedProperties.Add("Generator_UserColumnName", "5_SD_Amount");
                base.Columns.Add(this.column5_SD_Amount);
                this.column7_VAT_Amount = new DataColumn("7_VAT_Amount", typeof(string), null, MappingType.Element);
                this.column7_VAT_Amount.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column7_VAT_Amount");
                this.column7_VAT_Amount.ExtendedProperties.Add("Generator_UserColumnName", "7_VAT_Amount");
                base.Columns.Add(this.column7_VAT_Amount);
                this.columnVehicle_No = new DataColumn("Vehicle_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_No);
                this.column1_Sl_No.AutoIncrement = true;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnCustomer_Name = base.Columns["Customer_Name"];
                this.columnCustomer_Address = base.Columns["Customer_Address"];
                this.columnCustomer_TIN = base.Columns["Customer_TIN"];
                this.columnGoods_Services_Shipping_Address = base.Columns["Goods_Services_Shipping_Address"];
                this.columnVehicle_Type = base.Columns["Vehicle_Type"];
                this.columnChallan_No = base.Columns["Challan_No"];
                this.columnChallan_Date = base.Columns["Challan_Date"];
                this.columnChallan_Time = base.Columns["Challan_Time"];
                this.columnGoods_Unload_Date_Time = base.Columns["Goods_Unload_Date_Time"];
                this.column1_Sl_No = base.Columns["1_Sl_No"];
                this.column2_Goods_Services_Name = base.Columns["2_Goods_Services_Name"];
                this.column3_Quantity = base.Columns["3_Quantity"];
                this.column4_SD_Applicable_Price = base.Columns["4_SD_Applicable_Price"];
                this.column5_SD_Amount = base.Columns["5_SD_Amount"];
                this.column7_VAT_Amount = base.Columns["7_VAT_Amount"];
                this.columnVehicle_No = base.Columns["Vehicle_No"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Challan_Form_11Row NewChallan_Form_11Row()
            {
                return (NBR_POS_DS.Challan_Form_11Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Challan_Form_11Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Challan_Form_11RowChanged != null)
                {
                    this.Challan_Form_11RowChanged(this, new NBR_POS_DS.Challan_Form_11RowChangeEvent((NBR_POS_DS.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Challan_Form_11RowChanging != null)
                {
                    this.Challan_Form_11RowChanging(this, new NBR_POS_DS.Challan_Form_11RowChangeEvent((NBR_POS_DS.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Challan_Form_11RowDeleted != null)
                {
                    this.Challan_Form_11RowDeleted(this, new NBR_POS_DS.Challan_Form_11RowChangeEvent((NBR_POS_DS.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Challan_Form_11RowDeleting != null)
                {
                    this.Challan_Form_11RowDeleting(this, new NBR_POS_DS.Challan_Form_11RowChangeEvent((NBR_POS_DS.Challan_Form_11Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveChallan_Form_11Row(NBR_POS_DS.Challan_Form_11Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Challan_Form_11RowChangeEventHandler Challan_Form_11RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Challan_Form_11RowChangeEventHandler Challan_Form_11RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Challan_Form_11RowChangeEventHandler Challan_Form_11RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Challan_Form_11RowChangeEventHandler Challan_Form_11RowDeleting;
        }

        public class Challan_Form_11Row : DataRow
        {
            private NBR_POS_DS.Challan_Form_11DataTable tableChallan_Form_11;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int _1_Sl_No
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tableChallan_Form_11._1_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '1_Sl_No' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11._1_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_Goods_Services_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11._2_Goods_Services_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2_Goods_Services_Name' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11._2_Goods_Services_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11._3_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3_Quantity' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11._3_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4_SD_Applicable_Price
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11._4_SD_Applicable_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '4_SD_Applicable_Price' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11._4_SD_Applicable_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_SD_Amount
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11._5_SD_AmountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5_SD_Amount' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11._5_SD_AmountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7_VAT_Amount
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11._7_VAT_AmountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '7_VAT_Amount' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11._7_VAT_AmountColumn] = value;
                }
            }

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
            public string Customer_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Customer_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Customer_Name' in table 'Challan_Form_11' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableChallan_Form_11.Customer_NameColumn] = value;
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
            public string Goods_Unload_Date_Time
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableChallan_Form_11.Goods_Unload_Date_TimeColumn];
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
                this.tableChallan_Form_11 = (NBR_POS_DS.Challan_Form_11DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1_Sl_NoNull()
            {
                return base.IsNull(this.tableChallan_Form_11._1_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_Goods_Services_NameNull()
            {
                return base.IsNull(this.tableChallan_Form_11._2_Goods_Services_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_QuantityNull()
            {
                return base.IsNull(this.tableChallan_Form_11._3_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4_SD_Applicable_PriceNull()
            {
                return base.IsNull(this.tableChallan_Form_11._4_SD_Applicable_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_SD_AmountNull()
            {
                return base.IsNull(this.tableChallan_Form_11._5_SD_AmountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7_VAT_AmountNull()
            {
                return base.IsNull(this.tableChallan_Form_11._7_VAT_AmountColumn);
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
            public bool IsCustomer_NameNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Customer_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCustomer_TINNull()
            {
                return base.IsNull(this.tableChallan_Form_11.Customer_TINColumn);
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
            public void Set_1_Sl_NoNull()
            {
                base[this.tableChallan_Form_11._1_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_Goods_Services_NameNull()
            {
                base[this.tableChallan_Form_11._2_Goods_Services_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_QuantityNull()
            {
                base[this.tableChallan_Form_11._3_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4_SD_Applicable_PriceNull()
            {
                base[this.tableChallan_Form_11._4_SD_Applicable_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_SD_AmountNull()
            {
                base[this.tableChallan_Form_11._5_SD_AmountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7_VAT_AmountNull()
            {
                base[this.tableChallan_Form_11._7_VAT_AmountColumn] = Convert.DBNull;
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
            public void SetCustomer_NameNull()
            {
                base[this.tableChallan_Form_11.Customer_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCustomer_TINNull()
            {
                base[this.tableChallan_Form_11.Customer_TINColumn] = Convert.DBNull;
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
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Challan_Form_11RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Challan_Form_11Row eventRow;

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
            public NBR_POS_DS.Challan_Form_11Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Challan_Form_11RowChangeEvent(NBR_POS_DS.Challan_Form_11Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Challan_Form_11RowChangeEventHandler(object sender, NBR_POS_DS.Challan_Form_11RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Company_InfoDataTable : TypedTableBase<NBR_POS_DS.Company_InfoRow>
        {
            private DataColumn columnorganization_name;

            private DataColumn columnbusiness_address;

            private DataColumn columntin_company;

            private DataColumn columnarea_id;

            private DataColumn columnba_phone;

            private DataColumn columnba_fax;

            private DataColumn columnba_email;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn area_idColumn
            {
                get
                {
                    return this.columnarea_id;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ba_emailColumn
            {
                get
                {
                    return this.columnba_email;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ba_faxColumn
            {
                get
                {
                    return this.columnba_fax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn ba_phoneColumn
            {
                get
                {
                    return this.columnba_phone;
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
            public NBR_POS_DS.Company_InfoRow this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Company_InfoRow)base.Rows[index];
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
            public DataColumn tin_companyColumn
            {
                get
                {
                    return this.columntin_company;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Company_InfoDataTable()
            {
                base.TableName = "Company_Info";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Company_InfoDataTable(DataTable table)
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
            protected Company_InfoDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddCompany_InfoRow(NBR_POS_DS.Company_InfoRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Company_InfoRow AddCompany_InfoRow(string organization_name, string business_address, string tin_company, string area_id, string ba_phone, string ba_fax, string ba_email)
            {
                NBR_POS_DS.Company_InfoRow companyInfoRow = (NBR_POS_DS.Company_InfoRow)base.NewRow();
                object[] organizationName = new object[] { organization_name, business_address, tin_company, area_id, ba_phone, ba_fax, ba_email };
                companyInfoRow.ItemArray = organizationName;
                base.Rows.Add(companyInfoRow);
                return companyInfoRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Company_InfoDataTable companyInfoDataTable = (NBR_POS_DS.Company_InfoDataTable)base.Clone();
                companyInfoDataTable.InitVars();
                return companyInfoDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Company_InfoDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Company_InfoRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Company_InfoDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columntin_company = new DataColumn("tin_company", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntin_company);
                this.columnarea_id = new DataColumn("area_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnarea_id);
                this.columnba_phone = new DataColumn("ba_phone", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnba_phone);
                this.columnba_fax = new DataColumn("ba_fax", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnba_fax);
                this.columnba_email = new DataColumn("ba_email", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnba_email);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnorganization_name = base.Columns["organization_name"];
                this.columnbusiness_address = base.Columns["business_address"];
                this.columntin_company = base.Columns["tin_company"];
                this.columnarea_id = base.Columns["area_id"];
                this.columnba_phone = base.Columns["ba_phone"];
                this.columnba_fax = base.Columns["ba_fax"];
                this.columnba_email = base.Columns["ba_email"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Company_InfoRow NewCompany_InfoRow()
            {
                return (NBR_POS_DS.Company_InfoRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Company_InfoRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Company_InfoRowChanged != null)
                {
                    this.Company_InfoRowChanged(this, new NBR_POS_DS.Company_InfoRowChangeEvent((NBR_POS_DS.Company_InfoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Company_InfoRowChanging != null)
                {
                    this.Company_InfoRowChanging(this, new NBR_POS_DS.Company_InfoRowChangeEvent((NBR_POS_DS.Company_InfoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Company_InfoRowDeleted != null)
                {
                    this.Company_InfoRowDeleted(this, new NBR_POS_DS.Company_InfoRowChangeEvent((NBR_POS_DS.Company_InfoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Company_InfoRowDeleting != null)
                {
                    this.Company_InfoRowDeleting(this, new NBR_POS_DS.Company_InfoRowChangeEvent((NBR_POS_DS.Company_InfoRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCompany_InfoRow(NBR_POS_DS.Company_InfoRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Company_InfoRowChangeEventHandler Company_InfoRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Company_InfoRowChangeEventHandler Company_InfoRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Company_InfoRowChangeEventHandler Company_InfoRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Company_InfoRowChangeEventHandler Company_InfoRowDeleting;
        }

        public class Company_InfoRow : DataRow
        {
            private NBR_POS_DS.Company_InfoDataTable tableCompany_Info;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string area_id
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCompany_Info.area_idColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'area_id' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.area_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ba_email
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCompany_Info.ba_emailColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ba_email' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.ba_emailColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ba_fax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCompany_Info.ba_faxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ba_fax' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.ba_faxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string ba_phone
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCompany_Info.ba_phoneColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'ba_phone' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.ba_phoneColumn] = value;
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
                        item = (string)base[this.tableCompany_Info.business_addressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'business_address' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.business_addressColumn] = value;
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
                        item = (string)base[this.tableCompany_Info.organization_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'organization_name' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.organization_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string tin_company
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCompany_Info.tin_companyColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'tin_company' in table 'Company_Info' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCompany_Info.tin_companyColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Company_InfoRow(DataRowBuilder rb) : base(rb)
            {
                this.tableCompany_Info = (NBR_POS_DS.Company_InfoDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isarea_idNull()
            {
                return base.IsNull(this.tableCompany_Info.area_idColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isba_emailNull()
            {
                return base.IsNull(this.tableCompany_Info.ba_emailColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isba_faxNull()
            {
                return base.IsNull(this.tableCompany_Info.ba_faxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isba_phoneNull()
            {
                return base.IsNull(this.tableCompany_Info.ba_phoneColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbusiness_addressNull()
            {
                return base.IsNull(this.tableCompany_Info.business_addressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isorganization_nameNull()
            {
                return base.IsNull(this.tableCompany_Info.organization_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Istin_companyNull()
            {
                return base.IsNull(this.tableCompany_Info.tin_companyColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setarea_idNull()
            {
                base[this.tableCompany_Info.area_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setba_emailNull()
            {
                base[this.tableCompany_Info.ba_emailColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setba_faxNull()
            {
                base[this.tableCompany_Info.ba_faxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setba_phoneNull()
            {
                base[this.tableCompany_Info.ba_phoneColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbusiness_addressNull()
            {
                base[this.tableCompany_Info.business_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setorganization_nameNull()
            {
                base[this.tableCompany_Info.organization_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Settin_companyNull()
            {
                base[this.tableCompany_Info.tin_companyColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Company_InfoRowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Company_InfoRow eventRow;

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
            public NBR_POS_DS.Company_InfoRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Company_InfoRowChangeEvent(NBR_POS_DS.Company_InfoRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Company_InfoRowChangeEventHandler(object sender, NBR_POS_DS.Company_InfoRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class CountryDataTable : TypedTableBase<NBR_POS_DS.CountryRow>
        {
            private DataColumn columnSl_No_1;

            private DataColumn columnHS_Code_2;

            private DataColumn columnGoods_Name_3;

            private DataColumn columnGoods_Description_31;

            private DataColumn columnSale_Unit_4;

            private DataColumn columnRaw_Materials_Name_5;

            private DataColumn columnRaw_Meterials_Description_51;

            private DataColumn columnRaw_Meterials_Quantity_6;

            private DataColumn columnTotal_Purchase_Price_7;

            private DataColumn columnValue_Add_8;

            private DataColumn columnValue_Added_Per_Unit_9;

            private DataColumn columnPrice_With_SD_Present_10;

            private DataColumn columnPrice_With_SD_Applied_11;

            private DataColumn columnSD_On_Applied_Price_12;

            private DataColumn columnVAT_Applicable_Price_Present_13;

            private DataColumn columnVAT_Applicable_Price_Applied_14;

            private DataColumn columnSale_Price_With_DutyNTax_Wholesale_15;

            private DataColumn columnSale_Price_With_DutyNTax_Retail_Price_16;

            private DataColumn columnRaw_Meterials_Depriciation_61;

            private DataColumn columnitem_id;

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
            public DataColumn Goods_Description_31Column
            {
                get
                {
                    return this.columnGoods_Description_31;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Goods_Name_3Column
            {
                get
                {
                    return this.columnGoods_Name_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn HS_Code_2Column
            {
                get
                {
                    return this.columnHS_Code_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.CountryRow this[int index]
            {
                get
                {
                    return (NBR_POS_DS.CountryRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn item_idColumn
            {
                get
                {
                    return this.columnitem_id;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Price_With_SD_Applied_11Column
            {
                get
                {
                    return this.columnPrice_With_SD_Applied_11;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Price_With_SD_Present_10Column
            {
                get
                {
                    return this.columnPrice_With_SD_Present_10;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Raw_Materials_Name_5Column
            {
                get
                {
                    return this.columnRaw_Materials_Name_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Raw_Meterials_Depriciation_61Column
            {
                get
                {
                    return this.columnRaw_Meterials_Depriciation_61;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Raw_Meterials_Description_51Column
            {
                get
                {
                    return this.columnRaw_Meterials_Description_51;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Raw_Meterials_Quantity_6Column
            {
                get
                {
                    return this.columnRaw_Meterials_Quantity_6;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sale_Price_With_DutyNTax_Retail_Price_16Column
            {
                get
                {
                    return this.columnSale_Price_With_DutyNTax_Retail_Price_16;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sale_Price_With_DutyNTax_Wholesale_15Column
            {
                get
                {
                    return this.columnSale_Price_With_DutyNTax_Wholesale_15;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sale_Unit_4Column
            {
                get
                {
                    return this.columnSale_Unit_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn SD_On_Applied_Price_12Column
            {
                get
                {
                    return this.columnSD_On_Applied_Price_12;
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
            public DataColumn Total_Purchase_Price_7Column
            {
                get
                {
                    return this.columnTotal_Purchase_Price_7;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Value_Add_8Column
            {
                get
                {
                    return this.columnValue_Add_8;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Value_Added_Per_Unit_9Column
            {
                get
                {
                    return this.columnValue_Added_Per_Unit_9;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VAT_Applicable_Price_Applied_14Column
            {
                get
                {
                    return this.columnVAT_Applicable_Price_Applied_14;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn VAT_Applicable_Price_Present_13Column
            {
                get
                {
                    return this.columnVAT_Applicable_Price_Present_13;
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
            public void AddCountryRow(NBR_POS_DS.CountryRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.CountryRow AddCountryRow(string Sl_No_1, string HS_Code_2, string Goods_Name_3, string Goods_Description_31, string Sale_Unit_4, string Raw_Materials_Name_5, string Raw_Meterials_Description_51, string Raw_Meterials_Quantity_6, string Total_Purchase_Price_7, string Value_Add_8, string Value_Added_Per_Unit_9, string Price_With_SD_Present_10, string Price_With_SD_Applied_11, string SD_On_Applied_Price_12, string VAT_Applicable_Price_Present_13, string VAT_Applicable_Price_Applied_14, string Sale_Price_With_DutyNTax_Wholesale_15, string Sale_Price_With_DutyNTax_Retail_Price_16, string Raw_Meterials_Depriciation_61, string item_id)
            {
                NBR_POS_DS.CountryRow countryRow = (NBR_POS_DS.CountryRow)base.NewRow();
                object[] slNo1 = new object[] { Sl_No_1, HS_Code_2, Goods_Name_3, Goods_Description_31, Sale_Unit_4, Raw_Materials_Name_5, Raw_Meterials_Description_51, Raw_Meterials_Quantity_6, Total_Purchase_Price_7, Value_Add_8, Value_Added_Per_Unit_9, Price_With_SD_Present_10, Price_With_SD_Applied_11, SD_On_Applied_Price_12, VAT_Applicable_Price_Present_13, VAT_Applicable_Price_Applied_14, Sale_Price_With_DutyNTax_Wholesale_15, Sale_Price_With_DutyNTax_Retail_Price_16, Raw_Meterials_Depriciation_61, item_id };
                countryRow.ItemArray = slNo1;
                base.Rows.Add(countryRow);
                return countryRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.CountryDataTable countryDataTable = (NBR_POS_DS.CountryDataTable)base.Clone();
                countryDataTable.InitVars();
                return countryDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.CountryDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.CountryRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "CountryDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnSl_No_1 = new DataColumn("Sl_No_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSl_No_1);
                this.columnHS_Code_2 = new DataColumn("HS_Code_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnHS_Code_2);
                this.columnGoods_Name_3 = new DataColumn("Goods_Name_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Name_3);
                this.columnGoods_Description_31 = new DataColumn("Goods_Description_31", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnGoods_Description_31);
                this.columnSale_Unit_4 = new DataColumn("Sale_Unit_4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSale_Unit_4);
                this.columnRaw_Materials_Name_5 = new DataColumn("Raw_Materials_Name_5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRaw_Materials_Name_5);
                this.columnRaw_Meterials_Description_51 = new DataColumn("Raw_Meterials_Description_51", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRaw_Meterials_Description_51);
                this.columnRaw_Meterials_Quantity_6 = new DataColumn("Raw_Meterials_Quantity_6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRaw_Meterials_Quantity_6);
                this.columnTotal_Purchase_Price_7 = new DataColumn("Total_Purchase_Price_7", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTotal_Purchase_Price_7);
                this.columnValue_Add_8 = new DataColumn("Value_Add_8", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnValue_Add_8);
                this.columnValue_Added_Per_Unit_9 = new DataColumn("Value_Added_Per_Unit_9", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnValue_Added_Per_Unit_9);
                this.columnPrice_With_SD_Present_10 = new DataColumn("Price_With_SD_Present_10", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPrice_With_SD_Present_10);
                this.columnPrice_With_SD_Applied_11 = new DataColumn("Price_With_SD_Applied_11", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPrice_With_SD_Applied_11);
                this.columnSD_On_Applied_Price_12 = new DataColumn("SD_On_Applied_Price_12", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSD_On_Applied_Price_12);
                this.columnVAT_Applicable_Price_Present_13 = new DataColumn("VAT_Applicable_Price_Present_13", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVAT_Applicable_Price_Present_13);
                this.columnVAT_Applicable_Price_Applied_14 = new DataColumn("VAT_Applicable_Price_Applied_14", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVAT_Applicable_Price_Applied_14);
                this.columnSale_Price_With_DutyNTax_Wholesale_15 = new DataColumn("Sale_Price_With_DutyNTax_Wholesale_15", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSale_Price_With_DutyNTax_Wholesale_15);
                this.columnSale_Price_With_DutyNTax_Retail_Price_16 = new DataColumn("Sale_Price_With_DutyNTax_Retail_Price_16", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSale_Price_With_DutyNTax_Retail_Price_16);
                this.columnRaw_Meterials_Depriciation_61 = new DataColumn("Raw_Meterials_Depriciation_61", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRaw_Meterials_Depriciation_61);
                this.columnitem_id = new DataColumn("item_id", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnitem_id);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSl_No_1 = base.Columns["Sl_No_1"];
                this.columnHS_Code_2 = base.Columns["HS_Code_2"];
                this.columnGoods_Name_3 = base.Columns["Goods_Name_3"];
                this.columnGoods_Description_31 = base.Columns["Goods_Description_31"];
                this.columnSale_Unit_4 = base.Columns["Sale_Unit_4"];
                this.columnRaw_Materials_Name_5 = base.Columns["Raw_Materials_Name_5"];
                this.columnRaw_Meterials_Description_51 = base.Columns["Raw_Meterials_Description_51"];
                this.columnRaw_Meterials_Quantity_6 = base.Columns["Raw_Meterials_Quantity_6"];
                this.columnTotal_Purchase_Price_7 = base.Columns["Total_Purchase_Price_7"];
                this.columnValue_Add_8 = base.Columns["Value_Add_8"];
                this.columnValue_Added_Per_Unit_9 = base.Columns["Value_Added_Per_Unit_9"];
                this.columnPrice_With_SD_Present_10 = base.Columns["Price_With_SD_Present_10"];
                this.columnPrice_With_SD_Applied_11 = base.Columns["Price_With_SD_Applied_11"];
                this.columnSD_On_Applied_Price_12 = base.Columns["SD_On_Applied_Price_12"];
                this.columnVAT_Applicable_Price_Present_13 = base.Columns["VAT_Applicable_Price_Present_13"];
                this.columnVAT_Applicable_Price_Applied_14 = base.Columns["VAT_Applicable_Price_Applied_14"];
                this.columnSale_Price_With_DutyNTax_Wholesale_15 = base.Columns["Sale_Price_With_DutyNTax_Wholesale_15"];
                this.columnSale_Price_With_DutyNTax_Retail_Price_16 = base.Columns["Sale_Price_With_DutyNTax_Retail_Price_16"];
                this.columnRaw_Meterials_Depriciation_61 = base.Columns["Raw_Meterials_Depriciation_61"];
                this.columnitem_id = base.Columns["item_id"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.CountryRow NewCountryRow()
            {
                return (NBR_POS_DS.CountryRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.CountryRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.CountryRowChanged != null)
                {
                    this.CountryRowChanged(this, new NBR_POS_DS.CountryRowChangeEvent((NBR_POS_DS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.CountryRowChanging != null)
                {
                    this.CountryRowChanging(this, new NBR_POS_DS.CountryRowChangeEvent((NBR_POS_DS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.CountryRowDeleted != null)
                {
                    this.CountryRowDeleted(this, new NBR_POS_DS.CountryRowChangeEvent((NBR_POS_DS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.CountryRowDeleting != null)
                {
                    this.CountryRowDeleting(this, new NBR_POS_DS.CountryRowChangeEvent((NBR_POS_DS.CountryRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCountryRow(NBR_POS_DS.CountryRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CountryRowChangeEventHandler CountryRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CountryRowChangeEventHandler CountryRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CountryRowChangeEventHandler CountryRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CountryRowChangeEventHandler CountryRowDeleting;
        }

        public class CountryRow : DataRow
        {
            private NBR_POS_DS.CountryDataTable tableCountry;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_Description_31
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Goods_Description_31Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Description_31' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Goods_Description_31Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Goods_Name_3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Goods_Name_3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Goods_Name_3' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Goods_Name_3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string HS_Code_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.HS_Code_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'HS_Code_2' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.HS_Code_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string item_id
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.item_idColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'item_id' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.item_idColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Price_With_SD_Applied_11
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Price_With_SD_Applied_11Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Price_With_SD_Applied_11' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Price_With_SD_Applied_11Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Price_With_SD_Present_10
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Price_With_SD_Present_10Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Price_With_SD_Present_10' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Price_With_SD_Present_10Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Raw_Materials_Name_5
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Raw_Materials_Name_5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Raw_Materials_Name_5' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Raw_Materials_Name_5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Raw_Meterials_Depriciation_61
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Raw_Meterials_Depriciation_61Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Raw_Meterials_Depriciation_61' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Raw_Meterials_Depriciation_61Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Raw_Meterials_Description_51
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Raw_Meterials_Description_51Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Raw_Meterials_Description_51' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Raw_Meterials_Description_51Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Raw_Meterials_Quantity_6
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Raw_Meterials_Quantity_6Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Raw_Meterials_Quantity_6' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Raw_Meterials_Quantity_6Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sale_Price_With_DutyNTax_Retail_Price_16
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Sale_Price_With_DutyNTax_Retail_Price_16Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sale_Price_With_DutyNTax_Retail_Price_16' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Sale_Price_With_DutyNTax_Retail_Price_16Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sale_Price_With_DutyNTax_Wholesale_15
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Sale_Price_With_DutyNTax_Wholesale_15Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sale_Price_With_DutyNTax_Wholesale_15' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Sale_Price_With_DutyNTax_Wholesale_15Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sale_Unit_4
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Sale_Unit_4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sale_Unit_4' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Sale_Unit_4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string SD_On_Applied_Price_12
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.SD_On_Applied_Price_12Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'SD_On_Applied_Price_12' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.SD_On_Applied_Price_12Column] = value;
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
                        item = (string)base[this.tableCountry.Sl_No_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sl_No_1' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Sl_No_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Total_Purchase_Price_7
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Total_Purchase_Price_7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Total_Purchase_Price_7' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Total_Purchase_Price_7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Value_Add_8
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Value_Add_8Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Value_Add_8' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Value_Add_8Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Value_Added_Per_Unit_9
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.Value_Added_Per_Unit_9Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Value_Added_Per_Unit_9' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.Value_Added_Per_Unit_9Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string VAT_Applicable_Price_Applied_14
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.VAT_Applicable_Price_Applied_14Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'VAT_Applicable_Price_Applied_14' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.VAT_Applicable_Price_Applied_14Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string VAT_Applicable_Price_Present_13
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCountry.VAT_Applicable_Price_Present_13Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'VAT_Applicable_Price_Present_13' in table 'Country' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCountry.VAT_Applicable_Price_Present_13Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CountryRow(DataRowBuilder rb) : base(rb)
            {
                this.tableCountry = (NBR_POS_DS.CountryDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_Description_31Null()
            {
                return base.IsNull(this.tableCountry.Goods_Description_31Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsGoods_Name_3Null()
            {
                return base.IsNull(this.tableCountry.Goods_Name_3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsHS_Code_2Null()
            {
                return base.IsNull(this.tableCountry.HS_Code_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isitem_idNull()
            {
                return base.IsNull(this.tableCountry.item_idColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPrice_With_SD_Applied_11Null()
            {
                return base.IsNull(this.tableCountry.Price_With_SD_Applied_11Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPrice_With_SD_Present_10Null()
            {
                return base.IsNull(this.tableCountry.Price_With_SD_Present_10Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRaw_Materials_Name_5Null()
            {
                return base.IsNull(this.tableCountry.Raw_Materials_Name_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRaw_Meterials_Depriciation_61Null()
            {
                return base.IsNull(this.tableCountry.Raw_Meterials_Depriciation_61Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRaw_Meterials_Description_51Null()
            {
                return base.IsNull(this.tableCountry.Raw_Meterials_Description_51Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRaw_Meterials_Quantity_6Null()
            {
                return base.IsNull(this.tableCountry.Raw_Meterials_Quantity_6Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSale_Price_With_DutyNTax_Retail_Price_16Null()
            {
                return base.IsNull(this.tableCountry.Sale_Price_With_DutyNTax_Retail_Price_16Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSale_Price_With_DutyNTax_Wholesale_15Null()
            {
                return base.IsNull(this.tableCountry.Sale_Price_With_DutyNTax_Wholesale_15Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSale_Unit_4Null()
            {
                return base.IsNull(this.tableCountry.Sale_Unit_4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSD_On_Applied_Price_12Null()
            {
                return base.IsNull(this.tableCountry.SD_On_Applied_Price_12Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSl_No_1Null()
            {
                return base.IsNull(this.tableCountry.Sl_No_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTotal_Purchase_Price_7Null()
            {
                return base.IsNull(this.tableCountry.Total_Purchase_Price_7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsValue_Add_8Null()
            {
                return base.IsNull(this.tableCountry.Value_Add_8Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsValue_Added_Per_Unit_9Null()
            {
                return base.IsNull(this.tableCountry.Value_Added_Per_Unit_9Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVAT_Applicable_Price_Applied_14Null()
            {
                return base.IsNull(this.tableCountry.VAT_Applicable_Price_Applied_14Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVAT_Applicable_Price_Present_13Null()
            {
                return base.IsNull(this.tableCountry.VAT_Applicable_Price_Present_13Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_Description_31Null()
            {
                base[this.tableCountry.Goods_Description_31Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetGoods_Name_3Null()
            {
                base[this.tableCountry.Goods_Name_3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetHS_Code_2Null()
            {
                base[this.tableCountry.HS_Code_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setitem_idNull()
            {
                base[this.tableCountry.item_idColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPrice_With_SD_Applied_11Null()
            {
                base[this.tableCountry.Price_With_SD_Applied_11Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPrice_With_SD_Present_10Null()
            {
                base[this.tableCountry.Price_With_SD_Present_10Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRaw_Materials_Name_5Null()
            {
                base[this.tableCountry.Raw_Materials_Name_5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRaw_Meterials_Depriciation_61Null()
            {
                base[this.tableCountry.Raw_Meterials_Depriciation_61Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRaw_Meterials_Description_51Null()
            {
                base[this.tableCountry.Raw_Meterials_Description_51Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRaw_Meterials_Quantity_6Null()
            {
                base[this.tableCountry.Raw_Meterials_Quantity_6Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSale_Price_With_DutyNTax_Retail_Price_16Null()
            {
                base[this.tableCountry.Sale_Price_With_DutyNTax_Retail_Price_16Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSale_Price_With_DutyNTax_Wholesale_15Null()
            {
                base[this.tableCountry.Sale_Price_With_DutyNTax_Wholesale_15Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSale_Unit_4Null()
            {
                base[this.tableCountry.Sale_Unit_4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSD_On_Applied_Price_12Null()
            {
                base[this.tableCountry.SD_On_Applied_Price_12Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSl_No_1Null()
            {
                base[this.tableCountry.Sl_No_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTotal_Purchase_Price_7Null()
            {
                base[this.tableCountry.Total_Purchase_Price_7Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetValue_Add_8Null()
            {
                base[this.tableCountry.Value_Add_8Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetValue_Added_Per_Unit_9Null()
            {
                base[this.tableCountry.Value_Added_Per_Unit_9Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVAT_Applicable_Price_Applied_14Null()
            {
                base[this.tableCountry.VAT_Applicable_Price_Applied_14Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVAT_Applicable_Price_Present_13Null()
            {
                base[this.tableCountry.VAT_Applicable_Price_Present_13Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class CountryRowChangeEvent : EventArgs
        {
            private NBR_POS_DS.CountryRow eventRow;

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
            public NBR_POS_DS.CountryRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CountryRowChangeEvent(NBR_POS_DS.CountryRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void CountryRowChangeEventHandler(object sender, NBR_POS_DS.CountryRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Credit_Note_Form_12DataTable : TypedTableBase<NBR_POS_DS.Credit_Note_Form_12Row>
        {
            private DataColumn columnName_of_buyer;

            private DataColumn columnbuyer_address;

            private DataColumn columnBuyer_TIN;

            private DataColumn columnVehicle_Type;

            private DataColumn columnVehicle_No;

            private DataColumn columnCredit_Note_Sl_No;

            private DataColumn columnDate;

            private DataColumn column1_Sl_No;

            private DataColumn column2_Challan_Sl_No;

            private DataColumn _column2_1_Challan_Date;

            private DataColumn column3_Name_of_Goods;

            private DataColumn _column3_1_Quantity_of_Goods;

            private DataColumn column4_Total_Price;

            private DataColumn column5_Other_Tax_Amount;

            private DataColumn column6_VAT_Amount;

            private DataColumn column7_Amount_of_Other_Tax;

            private DataColumn column8_Amount_of_VAT;

            private DataColumn column9_Other_Tax;

            private DataColumn column10_VAT;

            private DataColumn columnRemarks;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1_Sl_NoColumn
            {
                get
                {
                    return this.column1_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _10_VATColumn
            {
                get
                {
                    return this.column10_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_1_Challan_DateColumn
            {
                get
                {
                    return this._column2_1_Challan_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_Challan_Sl_NoColumn
            {
                get
                {
                    return this.column2_Challan_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_1_Quantity_of_GoodsColumn
            {
                get
                {
                    return this._column3_1_Quantity_of_Goods;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_Name_of_GoodsColumn
            {
                get
                {
                    return this.column3_Name_of_Goods;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4_Total_PriceColumn
            {
                get
                {
                    return this.column4_Total_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_Other_Tax_AmountColumn
            {
                get
                {
                    return this.column5_Other_Tax_Amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6_VAT_AmountColumn
            {
                get
                {
                    return this.column6_VAT_Amount;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7_Amount_of_Other_TaxColumn
            {
                get
                {
                    return this.column7_Amount_of_Other_Tax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _8_Amount_of_VATColumn
            {
                get
                {
                    return this.column8_Amount_of_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _9_Other_TaxColumn
            {
                get
                {
                    return this.column9_Other_Tax;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn buyer_addressColumn
            {
                get
                {
                    return this.columnbuyer_address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Buyer_TINColumn
            {
                get
                {
                    return this.columnBuyer_TIN;
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
            public DataColumn Credit_Note_Sl_NoColumn
            {
                get
                {
                    return this.columnCredit_Note_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn DateColumn
            {
                get
                {
                    return this.columnDate;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Credit_Note_Form_12Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Credit_Note_Form_12Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Name_of_buyerColumn
            {
                get
                {
                    return this.columnName_of_buyer;
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
            public void AddCredit_Note_Form_12Row(NBR_POS_DS.Credit_Note_Form_12Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Credit_Note_Form_12Row AddCredit_Note_Form_12Row(string Name_of_buyer, string buyer_address, string Buyer_TIN, string Vehicle_Type, string Vehicle_No, string Credit_Note_Sl_No, string Date, string _2_Challan_Sl_No, string _2_1_Challan_Date, string _3_Name_of_Goods, string _3_1_Quantity_of_Goods, string _4_Total_Price, string _5_Other_Tax_Amount, string _6_VAT_Amount, string _7_Amount_of_Other_Tax, string _8_Amount_of_VAT, string _9_Other_Tax, string _10_VAT, string Remarks)
            {
                NBR_POS_DS.Credit_Note_Form_12Row creditNoteForm12Row = (NBR_POS_DS.Credit_Note_Form_12Row)base.NewRow();
                object[] nameOfBuyer = new object[] { Name_of_buyer, buyer_address, Buyer_TIN, Vehicle_Type, Vehicle_No, Credit_Note_Sl_No, Date, null, _2_Challan_Sl_No, _2_1_Challan_Date, _3_Name_of_Goods, _3_1_Quantity_of_Goods, _4_Total_Price, _5_Other_Tax_Amount, _6_VAT_Amount, _7_Amount_of_Other_Tax, _8_Amount_of_VAT, _9_Other_Tax, _10_VAT, Remarks };
                creditNoteForm12Row.ItemArray = nameOfBuyer;
                base.Rows.Add(creditNoteForm12Row);
                return creditNoteForm12Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Credit_Note_Form_12DataTable creditNoteForm12DataTable = (NBR_POS_DS.Credit_Note_Form_12DataTable)base.Clone();
                creditNoteForm12DataTable.InitVars();
                return creditNoteForm12DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Credit_Note_Form_12DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Credit_Note_Form_12Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Credit_Note_Form_12DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnName_of_buyer = new DataColumn("Name_of_buyer", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnName_of_buyer);
                this.columnbuyer_address = new DataColumn("buyer_address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnbuyer_address);
                this.columnBuyer_TIN = new DataColumn("Buyer_TIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBuyer_TIN);
                this.columnVehicle_Type = new DataColumn("Vehicle_Type", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_Type);
                this.columnVehicle_No = new DataColumn("Vehicle_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_No);
                this.columnCredit_Note_Sl_No = new DataColumn("Credit_Note_Sl_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCredit_Note_Sl_No);
                this.columnDate = new DataColumn("Date", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDate);
                this.column1_Sl_No = new DataColumn("1_Sl_No", typeof(int), null, MappingType.Element);
                this.column1_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column1_Sl_No");
                this.column1_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "1_Sl_No");
                base.Columns.Add(this.column1_Sl_No);
                this.column2_Challan_Sl_No = new DataColumn("2_Challan_Sl_No", typeof(string), null, MappingType.Element);
                this.column2_Challan_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column2_Challan_Sl_No");
                this.column2_Challan_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "2_Challan_Sl_No");
                base.Columns.Add(this.column2_Challan_Sl_No);
                this._column2_1_Challan_Date = new DataColumn("2.1_Challan_Date", typeof(string), null, MappingType.Element);
                this._column2_1_Challan_Date.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_column2_1_Challan_Date");
                this._column2_1_Challan_Date.ExtendedProperties.Add("Generator_UserColumnName", "2.1_Challan_Date");
                base.Columns.Add(this._column2_1_Challan_Date);
                this.column3_Name_of_Goods = new DataColumn("3_Name_of_Goods", typeof(string), null, MappingType.Element);
                this.column3_Name_of_Goods.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column3_Name_of_Goods");
                this.column3_Name_of_Goods.ExtendedProperties.Add("Generator_UserColumnName", "3_Name_of_Goods");
                base.Columns.Add(this.column3_Name_of_Goods);
                this._column3_1_Quantity_of_Goods = new DataColumn("3.1_Quantity_of_Goods", typeof(string), null, MappingType.Element);
                this._column3_1_Quantity_of_Goods.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_column3_1_Quantity_of_Goods");
                this._column3_1_Quantity_of_Goods.ExtendedProperties.Add("Generator_UserColumnName", "3.1_Quantity_of_Goods");
                base.Columns.Add(this._column3_1_Quantity_of_Goods);
                this.column4_Total_Price = new DataColumn("4_Total_Price", typeof(string), null, MappingType.Element);
                this.column4_Total_Price.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column4_Total_Price");
                this.column4_Total_Price.ExtendedProperties.Add("Generator_UserColumnName", "4_Total_Price");
                base.Columns.Add(this.column4_Total_Price);
                this.column5_Other_Tax_Amount = new DataColumn("5_Other_Tax_Amount", typeof(string), null, MappingType.Element);
                this.column5_Other_Tax_Amount.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column5_Other_Tax_Amount");
                this.column5_Other_Tax_Amount.ExtendedProperties.Add("Generator_UserColumnName", "5_Other_Tax_Amount");
                base.Columns.Add(this.column5_Other_Tax_Amount);
                this.column6_VAT_Amount = new DataColumn("6_VAT_Amount", typeof(string), null, MappingType.Element);
                this.column6_VAT_Amount.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column6_VAT_Amount");
                this.column6_VAT_Amount.ExtendedProperties.Add("Generator_UserColumnName", "6_VAT_Amount");
                base.Columns.Add(this.column6_VAT_Amount);
                this.column7_Amount_of_Other_Tax = new DataColumn("7_Amount_of_Other_Tax", typeof(string), null, MappingType.Element);
                this.column7_Amount_of_Other_Tax.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column7_Amount_of_Other_Tax");
                this.column7_Amount_of_Other_Tax.ExtendedProperties.Add("Generator_UserColumnName", "7_Amount_of_Other_Tax");
                base.Columns.Add(this.column7_Amount_of_Other_Tax);
                this.column8_Amount_of_VAT = new DataColumn("8_Amount_of_VAT", typeof(string), null, MappingType.Element);
                this.column8_Amount_of_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column8_Amount_of_VAT");
                this.column8_Amount_of_VAT.ExtendedProperties.Add("Generator_UserColumnName", "8_Amount_of_VAT");
                base.Columns.Add(this.column8_Amount_of_VAT);
                this.column9_Other_Tax = new DataColumn("9_Other_Tax", typeof(string), null, MappingType.Element);
                this.column9_Other_Tax.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column9_Other_Tax");
                this.column9_Other_Tax.ExtendedProperties.Add("Generator_UserColumnName", "9_Other_Tax");
                base.Columns.Add(this.column9_Other_Tax);
                this.column10_VAT = new DataColumn("10_VAT", typeof(string), null, MappingType.Element);
                this.column10_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column10_VAT");
                this.column10_VAT.ExtendedProperties.Add("Generator_UserColumnName", "10_VAT");
                base.Columns.Add(this.column10_VAT);
                this.columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRemarks);
                this.column1_Sl_No.AutoIncrement = true;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnName_of_buyer = base.Columns["Name_of_buyer"];
                this.columnbuyer_address = base.Columns["buyer_address"];
                this.columnBuyer_TIN = base.Columns["Buyer_TIN"];
                this.columnVehicle_Type = base.Columns["Vehicle_Type"];
                this.columnVehicle_No = base.Columns["Vehicle_No"];
                this.columnCredit_Note_Sl_No = base.Columns["Credit_Note_Sl_No"];
                this.columnDate = base.Columns["Date"];
                this.column1_Sl_No = base.Columns["1_Sl_No"];
                this.column2_Challan_Sl_No = base.Columns["2_Challan_Sl_No"];
                this._column2_1_Challan_Date = base.Columns["2.1_Challan_Date"];
                this.column3_Name_of_Goods = base.Columns["3_Name_of_Goods"];
                this._column3_1_Quantity_of_Goods = base.Columns["3.1_Quantity_of_Goods"];
                this.column4_Total_Price = base.Columns["4_Total_Price"];
                this.column5_Other_Tax_Amount = base.Columns["5_Other_Tax_Amount"];
                this.column6_VAT_Amount = base.Columns["6_VAT_Amount"];
                this.column7_Amount_of_Other_Tax = base.Columns["7_Amount_of_Other_Tax"];
                this.column8_Amount_of_VAT = base.Columns["8_Amount_of_VAT"];
                this.column9_Other_Tax = base.Columns["9_Other_Tax"];
                this.column10_VAT = base.Columns["10_VAT"];
                this.columnRemarks = base.Columns["Remarks"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Credit_Note_Form_12Row NewCredit_Note_Form_12Row()
            {
                return (NBR_POS_DS.Credit_Note_Form_12Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Credit_Note_Form_12Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Credit_Note_Form_12RowChanged != null)
                {
                    this.Credit_Note_Form_12RowChanged(this, new NBR_POS_DS.Credit_Note_Form_12RowChangeEvent((NBR_POS_DS.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Credit_Note_Form_12RowChanging != null)
                {
                    this.Credit_Note_Form_12RowChanging(this, new NBR_POS_DS.Credit_Note_Form_12RowChangeEvent((NBR_POS_DS.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Credit_Note_Form_12RowDeleted != null)
                {
                    this.Credit_Note_Form_12RowDeleted(this, new NBR_POS_DS.Credit_Note_Form_12RowChangeEvent((NBR_POS_DS.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Credit_Note_Form_12RowDeleting != null)
                {
                    this.Credit_Note_Form_12RowDeleting(this, new NBR_POS_DS.Credit_Note_Form_12RowChangeEvent((NBR_POS_DS.Credit_Note_Form_12Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCredit_Note_Form_12Row(NBR_POS_DS.Credit_Note_Form_12Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Credit_Note_Form_12RowChangeEventHandler Credit_Note_Form_12RowDeleting;
        }

        public class Credit_Note_Form_12Row : DataRow
        {
            private NBR_POS_DS.Credit_Note_Form_12DataTable tableCredit_Note_Form_12;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int _1_Sl_No
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tableCredit_Note_Form_12._1_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '1_Sl_No' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._1_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _10_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._10_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '10_VAT' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._10_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_1_Challan_Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._2_1_Challan_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2.1_Challan_Date' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._2_1_Challan_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_Challan_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._2_Challan_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2_Challan_Sl_No' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._2_Challan_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_1_Quantity_of_Goods
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._3_1_Quantity_of_GoodsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3.1_Quantity_of_Goods' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._3_1_Quantity_of_GoodsColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_Name_of_Goods
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._3_Name_of_GoodsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3_Name_of_Goods' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._3_Name_of_GoodsColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4_Total_Price
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._4_Total_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '4_Total_Price' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._4_Total_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_Other_Tax_Amount
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._5_Other_Tax_AmountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5_Other_Tax_Amount' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._5_Other_Tax_AmountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6_VAT_Amount
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._6_VAT_AmountColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '6_VAT_Amount' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._6_VAT_AmountColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7_Amount_of_Other_Tax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._7_Amount_of_Other_TaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '7_Amount_of_Other_Tax' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._7_Amount_of_Other_TaxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _8_Amount_of_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._8_Amount_of_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '8_Amount_of_VAT' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._8_Amount_of_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _9_Other_Tax
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12._9_Other_TaxColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '9_Other_Tax' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12._9_Other_TaxColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string buyer_address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.buyer_addressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'buyer_address' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.buyer_addressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Buyer_TIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Buyer_TINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Buyer_TIN' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Buyer_TINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Credit_Note_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Credit_Note_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Credit_Note_Sl_No' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Credit_Note_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Date' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Name_of_buyer
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCredit_Note_Form_12.Name_of_buyerColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Name_of_buyer' in table 'Credit_Note_Form_12' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCredit_Note_Form_12.Name_of_buyerColumn] = value;
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
            internal Credit_Note_Form_12Row(DataRowBuilder rb) : base(rb)
            {
                this.tableCredit_Note_Form_12 = (NBR_POS_DS.Credit_Note_Form_12DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1_Sl_NoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._1_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_10_VATNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._10_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_1_Challan_DateNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._2_1_Challan_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_Challan_Sl_NoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._2_Challan_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_1_Quantity_of_GoodsNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._3_1_Quantity_of_GoodsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_Name_of_GoodsNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._3_Name_of_GoodsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4_Total_PriceNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._4_Total_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_Other_Tax_AmountNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._5_Other_Tax_AmountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6_VAT_AmountNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._6_VAT_AmountColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7_Amount_of_Other_TaxNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._7_Amount_of_Other_TaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_8_Amount_of_VATNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._8_Amount_of_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_9_Other_TaxNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12._9_Other_TaxColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isbuyer_addressNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.buyer_addressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBuyer_TINNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Buyer_TINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCredit_Note_Sl_NoNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Credit_Note_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDateNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsName_of_buyerNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.Name_of_buyerColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRemarksNull()
            {
                return base.IsNull(this.tableCredit_Note_Form_12.RemarksColumn);
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
            public void Set_1_Sl_NoNull()
            {
                base[this.tableCredit_Note_Form_12._1_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_10_VATNull()
            {
                base[this.tableCredit_Note_Form_12._10_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_1_Challan_DateNull()
            {
                base[this.tableCredit_Note_Form_12._2_1_Challan_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_Challan_Sl_NoNull()
            {
                base[this.tableCredit_Note_Form_12._2_Challan_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_1_Quantity_of_GoodsNull()
            {
                base[this.tableCredit_Note_Form_12._3_1_Quantity_of_GoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_Name_of_GoodsNull()
            {
                base[this.tableCredit_Note_Form_12._3_Name_of_GoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4_Total_PriceNull()
            {
                base[this.tableCredit_Note_Form_12._4_Total_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_Other_Tax_AmountNull()
            {
                base[this.tableCredit_Note_Form_12._5_Other_Tax_AmountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6_VAT_AmountNull()
            {
                base[this.tableCredit_Note_Form_12._6_VAT_AmountColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7_Amount_of_Other_TaxNull()
            {
                base[this.tableCredit_Note_Form_12._7_Amount_of_Other_TaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_8_Amount_of_VATNull()
            {
                base[this.tableCredit_Note_Form_12._8_Amount_of_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_9_Other_TaxNull()
            {
                base[this.tableCredit_Note_Form_12._9_Other_TaxColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setbuyer_addressNull()
            {
                base[this.tableCredit_Note_Form_12.buyer_addressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBuyer_TINNull()
            {
                base[this.tableCredit_Note_Form_12.Buyer_TINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCredit_Note_Sl_NoNull()
            {
                base[this.tableCredit_Note_Form_12.Credit_Note_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDateNull()
            {
                base[this.tableCredit_Note_Form_12.DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetName_of_buyerNull()
            {
                base[this.tableCredit_Note_Form_12.Name_of_buyerColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRemarksNull()
            {
                base[this.tableCredit_Note_Form_12.RemarksColumn] = Convert.DBNull;
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
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Credit_Note_Form_12RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Credit_Note_Form_12Row eventRow;

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
            public NBR_POS_DS.Credit_Note_Form_12Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Credit_Note_Form_12RowChangeEvent(NBR_POS_DS.Credit_Note_Form_12Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Credit_Note_Form_12RowChangeEventHandler(object sender, NBR_POS_DS.Credit_Note_Form_12RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class CurrentAccountForm18DataTable : TypedTableBase<NBR_POS_DS.CurrentAccountForm18Row>
        {
            private DataColumn columnsl_no_1;

            private DataColumn columndate_2;

            private DataColumn columntransaction_detail_3;

            private DataColumn columnpurchasesale_book_sl_no_4;

            private DataColumn columnpurchasesale_book_date_5;

            private DataColumn columntreasury_deposit_6;

            private DataColumn columnrebate_7;

            private DataColumn columnpayable_8;

            private DataColumn columnclosing_balance_9;

            private DataColumn columnremarks_10;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn closing_balance_9Column
            {
                get
                {
                    return this.columnclosing_balance_9;
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
            public DataColumn date_2Column
            {
                get
                {
                    return this.columndate_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.CurrentAccountForm18Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.CurrentAccountForm18Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn payable_8Column
            {
                get
                {
                    return this.columnpayable_8;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchasesale_book_date_5Column
            {
                get
                {
                    return this.columnpurchasesale_book_date_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn purchasesale_book_sl_no_4Column
            {
                get
                {
                    return this.columnpurchasesale_book_sl_no_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn rebate_7Column
            {
                get
                {
                    return this.columnrebate_7;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn remarks_10Column
            {
                get
                {
                    return this.columnremarks_10;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn sl_no_1Column
            {
                get
                {
                    return this.columnsl_no_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn transaction_detail_3Column
            {
                get
                {
                    return this.columntransaction_detail_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn treasury_deposit_6Column
            {
                get
                {
                    return this.columntreasury_deposit_6;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccountForm18DataTable()
            {
                base.TableName = "CurrentAccountForm18";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CurrentAccountForm18DataTable(DataTable table)
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
            protected CurrentAccountForm18DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddCurrentAccountForm18Row(NBR_POS_DS.CurrentAccountForm18Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.CurrentAccountForm18Row AddCurrentAccountForm18Row(string sl_no_1, string date_2, string transaction_detail_3, string purchasesale_book_sl_no_4, string purchasesale_book_date_5, string treasury_deposit_6, string rebate_7, string payable_8, string closing_balance_9, string remarks_10)
            {
                NBR_POS_DS.CurrentAccountForm18Row currentAccountForm18Row = (NBR_POS_DS.CurrentAccountForm18Row)base.NewRow();
                object[] slNo1 = new object[] { sl_no_1, date_2, transaction_detail_3, purchasesale_book_sl_no_4, purchasesale_book_date_5, treasury_deposit_6, rebate_7, payable_8, closing_balance_9, remarks_10 };
                currentAccountForm18Row.ItemArray = slNo1;
                base.Rows.Add(currentAccountForm18Row);
                return currentAccountForm18Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.CurrentAccountForm18DataTable currentAccountForm18DataTable = (NBR_POS_DS.CurrentAccountForm18DataTable)base.Clone();
                currentAccountForm18DataTable.InitVars();
                return currentAccountForm18DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.CurrentAccountForm18DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.CurrentAccountForm18Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "CurrentAccountForm18DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnsl_no_1 = new DataColumn("sl_no_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnsl_no_1);
                this.columndate_2 = new DataColumn("date_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columndate_2);
                this.columntransaction_detail_3 = new DataColumn("transaction_detail_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntransaction_detail_3);
                this.columnpurchasesale_book_sl_no_4 = new DataColumn("purchasesale_book_sl_no_4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchasesale_book_sl_no_4);
                this.columnpurchasesale_book_date_5 = new DataColumn("purchasesale_book_date_5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpurchasesale_book_date_5);
                this.columntreasury_deposit_6 = new DataColumn("treasury_deposit_6", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntreasury_deposit_6);
                this.columnrebate_7 = new DataColumn("rebate_7", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnrebate_7);
                this.columnpayable_8 = new DataColumn("payable_8", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnpayable_8);
                this.columnclosing_balance_9 = new DataColumn("closing_balance_9", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnclosing_balance_9);
                this.columnremarks_10 = new DataColumn("remarks_10", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnremarks_10);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnsl_no_1 = base.Columns["sl_no_1"];
                this.columndate_2 = base.Columns["date_2"];
                this.columntransaction_detail_3 = base.Columns["transaction_detail_3"];
                this.columnpurchasesale_book_sl_no_4 = base.Columns["purchasesale_book_sl_no_4"];
                this.columnpurchasesale_book_date_5 = base.Columns["purchasesale_book_date_5"];
                this.columntreasury_deposit_6 = base.Columns["treasury_deposit_6"];
                this.columnrebate_7 = base.Columns["rebate_7"];
                this.columnpayable_8 = base.Columns["payable_8"];
                this.columnclosing_balance_9 = base.Columns["closing_balance_9"];
                this.columnremarks_10 = base.Columns["remarks_10"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.CurrentAccountForm18Row NewCurrentAccountForm18Row()
            {
                return (NBR_POS_DS.CurrentAccountForm18Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.CurrentAccountForm18Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.CurrentAccountForm18RowChanged != null)
                {
                    this.CurrentAccountForm18RowChanged(this, new NBR_POS_DS.CurrentAccountForm18RowChangeEvent((NBR_POS_DS.CurrentAccountForm18Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.CurrentAccountForm18RowChanging != null)
                {
                    this.CurrentAccountForm18RowChanging(this, new NBR_POS_DS.CurrentAccountForm18RowChangeEvent((NBR_POS_DS.CurrentAccountForm18Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.CurrentAccountForm18RowDeleted != null)
                {
                    this.CurrentAccountForm18RowDeleted(this, new NBR_POS_DS.CurrentAccountForm18RowChangeEvent((NBR_POS_DS.CurrentAccountForm18Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.CurrentAccountForm18RowDeleting != null)
                {
                    this.CurrentAccountForm18RowDeleting(this, new NBR_POS_DS.CurrentAccountForm18RowChangeEvent((NBR_POS_DS.CurrentAccountForm18Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveCurrentAccountForm18Row(NBR_POS_DS.CurrentAccountForm18Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CurrentAccountForm18RowChangeEventHandler CurrentAccountForm18RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CurrentAccountForm18RowChangeEventHandler CurrentAccountForm18RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CurrentAccountForm18RowChangeEventHandler CurrentAccountForm18RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.CurrentAccountForm18RowChangeEventHandler CurrentAccountForm18RowDeleting;
        }

        public class CurrentAccountForm18Row : DataRow
        {
            private NBR_POS_DS.CurrentAccountForm18DataTable tableCurrentAccountForm18;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string closing_balance_9
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.closing_balance_9Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'closing_balance_9' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.closing_balance_9Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string date_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.date_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'date_2' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.date_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string payable_8
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.payable_8Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'payable_8' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.payable_8Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchasesale_book_date_5
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.purchasesale_book_date_5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchasesale_book_date_5' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.purchasesale_book_date_5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string purchasesale_book_sl_no_4
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.purchasesale_book_sl_no_4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'purchasesale_book_sl_no_4' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.purchasesale_book_sl_no_4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string rebate_7
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.rebate_7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'rebate_7' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.rebate_7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string remarks_10
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.remarks_10Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'remarks_10' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.remarks_10Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string sl_no_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.sl_no_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'sl_no_1' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.sl_no_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string transaction_detail_3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.transaction_detail_3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'transaction_detail_3' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.transaction_detail_3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string treasury_deposit_6
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableCurrentAccountForm18.treasury_deposit_6Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'treasury_deposit_6' in table 'CurrentAccountForm18' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableCurrentAccountForm18.treasury_deposit_6Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal CurrentAccountForm18Row(DataRowBuilder rb) : base(rb)
            {
                this.tableCurrentAccountForm18 = (NBR_POS_DS.CurrentAccountForm18DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isclosing_balance_9Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.closing_balance_9Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isdate_2Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.date_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispayable_8Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.payable_8Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchasesale_book_date_5Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.purchasesale_book_date_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Ispurchasesale_book_sl_no_4Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.purchasesale_book_sl_no_4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isrebate_7Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.rebate_7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isremarks_10Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.remarks_10Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Issl_no_1Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.sl_no_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Istransaction_detail_3Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.transaction_detail_3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Istreasury_deposit_6Null()
            {
                return base.IsNull(this.tableCurrentAccountForm18.treasury_deposit_6Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setclosing_balance_9Null()
            {
                base[this.tableCurrentAccountForm18.closing_balance_9Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setdate_2Null()
            {
                base[this.tableCurrentAccountForm18.date_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpayable_8Null()
            {
                base[this.tableCurrentAccountForm18.payable_8Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchasesale_book_date_5Null()
            {
                base[this.tableCurrentAccountForm18.purchasesale_book_date_5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setpurchasesale_book_sl_no_4Null()
            {
                base[this.tableCurrentAccountForm18.purchasesale_book_sl_no_4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setrebate_7Null()
            {
                base[this.tableCurrentAccountForm18.rebate_7Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setremarks_10Null()
            {
                base[this.tableCurrentAccountForm18.remarks_10Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setsl_no_1Null()
            {
                base[this.tableCurrentAccountForm18.sl_no_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Settransaction_detail_3Null()
            {
                base[this.tableCurrentAccountForm18.transaction_detail_3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Settreasury_deposit_6Null()
            {
                base[this.tableCurrentAccountForm18.treasury_deposit_6Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class CurrentAccountForm18RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.CurrentAccountForm18Row eventRow;

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
            public NBR_POS_DS.CurrentAccountForm18Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public CurrentAccountForm18RowChangeEvent(NBR_POS_DS.CurrentAccountForm18Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void CurrentAccountForm18RowChangeEventHandler(object sender, NBR_POS_DS.CurrentAccountForm18RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Debit_Note_Form_12_KaDataTable : TypedTableBase<NBR_POS_DS.Debit_Note_Form_12_KaRow>
        {
            private DataColumn columnBuyer_Name;

            private DataColumn columnBuyer_Address;

            private DataColumn columnBuyer_TIN;

            private DataColumn columnVehicle_Type;

            private DataColumn columnVehicle_No;

            private DataColumn columnDebit_Note_Sl_No;

            private DataColumn columnDate;

            private DataColumn column1_Sl_No;

            private DataColumn column2_Challan_Sl_No;

            private DataColumn _column2_1_Challan_Date;

            private DataColumn column3_Name_of_Goods;

            private DataColumn _column3_1_Quantity_of_Goods;

            private DataColumn column4_Total_Price;

            private DataColumn column5_Amount_of_Other_Taxes;

            private DataColumn column6_Amount_of_VAT;

            private DataColumn column7_Other_Taxes;

            private DataColumn column8_VAT;

            private DataColumn columnRemarks;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1_Sl_NoColumn
            {
                get
                {
                    return this.column1_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_1_Challan_DateColumn
            {
                get
                {
                    return this._column2_1_Challan_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_Challan_Sl_NoColumn
            {
                get
                {
                    return this.column2_Challan_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_1_Quantity_of_GoodsColumn
            {
                get
                {
                    return this._column3_1_Quantity_of_Goods;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_Name_of_GoodsColumn
            {
                get
                {
                    return this.column3_Name_of_Goods;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4_Total_PriceColumn
            {
                get
                {
                    return this.column4_Total_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_Amount_of_Other_TaxesColumn
            {
                get
                {
                    return this.column5_Amount_of_Other_Taxes;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6_Amount_of_VATColumn
            {
                get
                {
                    return this.column6_Amount_of_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7_Other_TaxesColumn
            {
                get
                {
                    return this.column7_Other_Taxes;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _8_VATColumn
            {
                get
                {
                    return this.column8_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Buyer_AddressColumn
            {
                get
                {
                    return this.columnBuyer_Address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Buyer_NameColumn
            {
                get
                {
                    return this.columnBuyer_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Buyer_TINColumn
            {
                get
                {
                    return this.columnBuyer_TIN;
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
            public DataColumn DateColumn
            {
                get
                {
                    return this.columnDate;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Debit_Note_Sl_NoColumn
            {
                get
                {
                    return this.columnDebit_Note_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Debit_Note_Form_12_KaRow this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Debit_Note_Form_12_KaRow)base.Rows[index];
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
            public Debit_Note_Form_12_KaDataTable()
            {
                base.TableName = "Debit_Note_Form_12_Ka";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Debit_Note_Form_12_KaDataTable(DataTable table)
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
            protected Debit_Note_Form_12_KaDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddDebit_Note_Form_12_KaRow(NBR_POS_DS.Debit_Note_Form_12_KaRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Debit_Note_Form_12_KaRow AddDebit_Note_Form_12_KaRow(string Buyer_Name, string Buyer_Address, string Buyer_TIN, string Vehicle_Type, string Vehicle_No, string Debit_Note_Sl_No, string Date, string _1_Sl_No, string _2_Challan_Sl_No, string _2_1_Challan_Date, string _3_Name_of_Goods, string _3_1_Quantity_of_Goods, string _4_Total_Price, string _5_Amount_of_Other_Taxes, string _6_Amount_of_VAT, string _7_Other_Taxes, string _8_VAT, string Remarks)
            {
                NBR_POS_DS.Debit_Note_Form_12_KaRow debitNoteForm12KaRow = (NBR_POS_DS.Debit_Note_Form_12_KaRow)base.NewRow();
                object[] buyerName = new object[] { Buyer_Name, Buyer_Address, Buyer_TIN, Vehicle_Type, Vehicle_No, Debit_Note_Sl_No, Date, _1_Sl_No, _2_Challan_Sl_No, _2_1_Challan_Date, _3_Name_of_Goods, _3_1_Quantity_of_Goods, _4_Total_Price, _5_Amount_of_Other_Taxes, _6_Amount_of_VAT, _7_Other_Taxes, _8_VAT, Remarks };
                debitNoteForm12KaRow.ItemArray = buyerName;
                base.Rows.Add(debitNoteForm12KaRow);
                return debitNoteForm12KaRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Debit_Note_Form_12_KaDataTable debitNoteForm12KaDataTable = (NBR_POS_DS.Debit_Note_Form_12_KaDataTable)base.Clone();
                debitNoteForm12KaDataTable.InitVars();
                return debitNoteForm12KaDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Debit_Note_Form_12_KaDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Debit_Note_Form_12_KaRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Debit_Note_Form_12_KaDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnBuyer_Name = new DataColumn("Buyer_Name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBuyer_Name);
                this.columnBuyer_Address = new DataColumn("Buyer_Address", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBuyer_Address);
                this.columnBuyer_TIN = new DataColumn("Buyer_TIN", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBuyer_TIN);
                this.columnVehicle_Type = new DataColumn("Vehicle_Type", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_Type);
                this.columnVehicle_No = new DataColumn("Vehicle_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnVehicle_No);
                this.columnDebit_Note_Sl_No = new DataColumn("Debit_Note_Sl_No", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDebit_Note_Sl_No);
                this.columnDate = new DataColumn("Date", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDate);
                this.column1_Sl_No = new DataColumn("1_Sl_No", typeof(string), null, MappingType.Element);
                this.column1_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column1_Sl_No");
                this.column1_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "1_Sl_No");
                base.Columns.Add(this.column1_Sl_No);
                this.column2_Challan_Sl_No = new DataColumn("2_Challan_Sl_No", typeof(string), null, MappingType.Element);
                this.column2_Challan_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column2_Challan_Sl_No");
                this.column2_Challan_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "2_Challan_Sl_No");
                base.Columns.Add(this.column2_Challan_Sl_No);
                this._column2_1_Challan_Date = new DataColumn("2.1_Challan_Date", typeof(string), null, MappingType.Element);
                this._column2_1_Challan_Date.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_column2_1_Challan_Date");
                this._column2_1_Challan_Date.ExtendedProperties.Add("Generator_UserColumnName", "2.1_Challan_Date");
                base.Columns.Add(this._column2_1_Challan_Date);
                this.column3_Name_of_Goods = new DataColumn("3_Name_of_Goods", typeof(string), null, MappingType.Element);
                this.column3_Name_of_Goods.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column3_Name_of_Goods");
                this.column3_Name_of_Goods.ExtendedProperties.Add("Generator_UserColumnName", "3_Name_of_Goods");
                base.Columns.Add(this.column3_Name_of_Goods);
                this._column3_1_Quantity_of_Goods = new DataColumn("3.1_Quantity_of_Goods", typeof(string), null, MappingType.Element);
                this._column3_1_Quantity_of_Goods.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_column3_1_Quantity_of_Goods");
                this._column3_1_Quantity_of_Goods.ExtendedProperties.Add("Generator_UserColumnName", "3.1_Quantity_of_Goods");
                base.Columns.Add(this._column3_1_Quantity_of_Goods);
                this.column4_Total_Price = new DataColumn("4_Total_Price", typeof(string), null, MappingType.Element);
                this.column4_Total_Price.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column4_Total_Price");
                this.column4_Total_Price.ExtendedProperties.Add("Generator_UserColumnName", "4_Total_Price");
                base.Columns.Add(this.column4_Total_Price);
                this.column5_Amount_of_Other_Taxes = new DataColumn("5_Amount_of_Other_Taxes", typeof(string), null, MappingType.Element);
                this.column5_Amount_of_Other_Taxes.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column5_Amount_of_Other_Taxes");
                this.column5_Amount_of_Other_Taxes.ExtendedProperties.Add("Generator_UserColumnName", "5_Amount_of_Other_Taxes");
                base.Columns.Add(this.column5_Amount_of_Other_Taxes);
                this.column6_Amount_of_VAT = new DataColumn("6_Amount_of_VAT", typeof(string), null, MappingType.Element);
                this.column6_Amount_of_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column6_Amount_of_VAT");
                this.column6_Amount_of_VAT.ExtendedProperties.Add("Generator_UserColumnName", "6_Amount_of_VAT");
                base.Columns.Add(this.column6_Amount_of_VAT);
                this.column7_Other_Taxes = new DataColumn("7_Other_Taxes", typeof(string), null, MappingType.Element);
                this.column7_Other_Taxes.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column7_Other_Taxes");
                this.column7_Other_Taxes.ExtendedProperties.Add("Generator_UserColumnName", "7_Other_Taxes");
                base.Columns.Add(this.column7_Other_Taxes);
                this.column8_VAT = new DataColumn("8_VAT", typeof(string), null, MappingType.Element);
                this.column8_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column8_VAT");
                this.column8_VAT.ExtendedProperties.Add("Generator_UserColumnName", "8_VAT");
                base.Columns.Add(this.column8_VAT);
                this.columnRemarks = new DataColumn("Remarks", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnRemarks);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnBuyer_Name = base.Columns["Buyer_Name"];
                this.columnBuyer_Address = base.Columns["Buyer_Address"];
                this.columnBuyer_TIN = base.Columns["Buyer_TIN"];
                this.columnVehicle_Type = base.Columns["Vehicle_Type"];
                this.columnVehicle_No = base.Columns["Vehicle_No"];
                this.columnDebit_Note_Sl_No = base.Columns["Debit_Note_Sl_No"];
                this.columnDate = base.Columns["Date"];
                this.column1_Sl_No = base.Columns["1_Sl_No"];
                this.column2_Challan_Sl_No = base.Columns["2_Challan_Sl_No"];
                this._column2_1_Challan_Date = base.Columns["2.1_Challan_Date"];
                this.column3_Name_of_Goods = base.Columns["3_Name_of_Goods"];
                this._column3_1_Quantity_of_Goods = base.Columns["3.1_Quantity_of_Goods"];
                this.column4_Total_Price = base.Columns["4_Total_Price"];
                this.column5_Amount_of_Other_Taxes = base.Columns["5_Amount_of_Other_Taxes"];
                this.column6_Amount_of_VAT = base.Columns["6_Amount_of_VAT"];
                this.column7_Other_Taxes = base.Columns["7_Other_Taxes"];
                this.column8_VAT = base.Columns["8_VAT"];
                this.columnRemarks = base.Columns["Remarks"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Debit_Note_Form_12_KaRow NewDebit_Note_Form_12_KaRow()
            {
                return (NBR_POS_DS.Debit_Note_Form_12_KaRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Debit_Note_Form_12_KaRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Debit_Note_Form_12_KaRowChanged != null)
                {
                    this.Debit_Note_Form_12_KaRowChanged(this, new NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEvent((NBR_POS_DS.Debit_Note_Form_12_KaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Debit_Note_Form_12_KaRowChanging != null)
                {
                    this.Debit_Note_Form_12_KaRowChanging(this, new NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEvent((NBR_POS_DS.Debit_Note_Form_12_KaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Debit_Note_Form_12_KaRowDeleted != null)
                {
                    this.Debit_Note_Form_12_KaRowDeleted(this, new NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEvent((NBR_POS_DS.Debit_Note_Form_12_KaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Debit_Note_Form_12_KaRowDeleting != null)
                {
                    this.Debit_Note_Form_12_KaRowDeleting(this, new NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEvent((NBR_POS_DS.Debit_Note_Form_12_KaRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveDebit_Note_Form_12_KaRow(NBR_POS_DS.Debit_Note_Form_12_KaRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEventHandler Debit_Note_Form_12_KaRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEventHandler Debit_Note_Form_12_KaRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEventHandler Debit_Note_Form_12_KaRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEventHandler Debit_Note_Form_12_KaRowDeleting;
        }

        public class Debit_Note_Form_12_KaRow : DataRow
        {
            private NBR_POS_DS.Debit_Note_Form_12_KaDataTable tableDebit_Note_Form_12_Ka;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _1_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._1_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '1_Sl_No' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._1_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_1_Challan_Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._2_1_Challan_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2.1_Challan_Date' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._2_1_Challan_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_Challan_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._2_Challan_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2_Challan_Sl_No' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._2_Challan_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_1_Quantity_of_Goods
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._3_1_Quantity_of_GoodsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3.1_Quantity_of_Goods' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._3_1_Quantity_of_GoodsColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_Name_of_Goods
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._3_Name_of_GoodsColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3_Name_of_Goods' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._3_Name_of_GoodsColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4_Total_Price
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._4_Total_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '4_Total_Price' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._4_Total_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_Amount_of_Other_Taxes
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._5_Amount_of_Other_TaxesColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5_Amount_of_Other_Taxes' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._5_Amount_of_Other_TaxesColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6_Amount_of_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._6_Amount_of_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '6_Amount_of_VAT' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._6_Amount_of_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7_Other_Taxes
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._7_Other_TaxesColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '7_Other_Taxes' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._7_Other_TaxesColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _8_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka._8_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '8_VAT' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka._8_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Buyer_Address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.Buyer_AddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Buyer_Address' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.Buyer_AddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Buyer_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.Buyer_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Buyer_Name' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.Buyer_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Buyer_TIN
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.Buyer_TINColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Buyer_TIN' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.Buyer_TINColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Date' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Debit_Note_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.Debit_Note_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Debit_Note_Sl_No' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.Debit_Note_Sl_NoColumn] = value;
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
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.RemarksColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Remarks' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.RemarksColumn] = value;
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
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.Vehicle_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle_No' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.Vehicle_NoColumn] = value;
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
                        item = (string)base[this.tableDebit_Note_Form_12_Ka.Vehicle_TypeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Vehicle_Type' in table 'Debit_Note_Form_12_Ka' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableDebit_Note_Form_12_Ka.Vehicle_TypeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Debit_Note_Form_12_KaRow(DataRowBuilder rb) : base(rb)
            {
                this.tableDebit_Note_Form_12_Ka = (NBR_POS_DS.Debit_Note_Form_12_KaDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1_Sl_NoNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._1_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_1_Challan_DateNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._2_1_Challan_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_Challan_Sl_NoNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._2_Challan_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_1_Quantity_of_GoodsNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._3_1_Quantity_of_GoodsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_Name_of_GoodsNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._3_Name_of_GoodsColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4_Total_PriceNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._4_Total_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_Amount_of_Other_TaxesNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._5_Amount_of_Other_TaxesColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6_Amount_of_VATNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._6_Amount_of_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7_Other_TaxesNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._7_Other_TaxesColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_8_VATNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka._8_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBuyer_AddressNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.Buyer_AddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBuyer_NameNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.Buyer_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBuyer_TINNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.Buyer_TINColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDateNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDebit_Note_Sl_NoNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.Debit_Note_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsRemarksNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.RemarksColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicle_NoNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.Vehicle_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsVehicle_TypeNull()
            {
                return base.IsNull(this.tableDebit_Note_Form_12_Ka.Vehicle_TypeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_1_Sl_NoNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._1_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_1_Challan_DateNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._2_1_Challan_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_Challan_Sl_NoNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._2_Challan_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_1_Quantity_of_GoodsNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._3_1_Quantity_of_GoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_Name_of_GoodsNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._3_Name_of_GoodsColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4_Total_PriceNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._4_Total_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_Amount_of_Other_TaxesNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._5_Amount_of_Other_TaxesColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6_Amount_of_VATNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._6_Amount_of_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7_Other_TaxesNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._7_Other_TaxesColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_8_VATNull()
            {
                base[this.tableDebit_Note_Form_12_Ka._8_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBuyer_AddressNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.Buyer_AddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBuyer_NameNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.Buyer_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBuyer_TINNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.Buyer_TINColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDateNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDebit_Note_Sl_NoNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.Debit_Note_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetRemarksNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.RemarksColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicle_NoNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.Vehicle_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetVehicle_TypeNull()
            {
                base[this.tableDebit_Note_Form_12_Ka.Vehicle_TypeColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Debit_Note_Form_12_KaRowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Debit_Note_Form_12_KaRow eventRow;

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
            public NBR_POS_DS.Debit_Note_Form_12_KaRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Debit_Note_Form_12_KaRowChangeEvent(NBR_POS_DS.Debit_Note_Form_12_KaRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Debit_Note_Form_12_KaRowChangeEventHandler(object sender, NBR_POS_DS.Debit_Note_Form_12_KaRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Disposal_of_UnusedUnfit_Inputs_Form_26DataTable : TypedTableBase<NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row>
        {
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
            public NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)base.Rows[index];
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
            public void AddDisposal_of_UnusedUnfit_Inputs_Form_26Row(NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row AddDisposal_of_UnusedUnfit_Inputs_Form_26Row(string Sl_No_1, string Name_of_Inputs_2, string Sl_No_of_Purchase_Challan_and_Sales_Book_3, string Quantity_4, string Actual_Value_5, string VAT_Paid_6, string Present_Value_7, string Reason_for_the_Unfit_8)
            {
                NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row disposalOfUnusedUnfitInputsForm26Row = (NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)base.NewRow();
                object[] slNo1 = new object[] { Sl_No_1, Name_of_Inputs_2, Sl_No_of_Purchase_Challan_and_Sales_Book_3, Quantity_4, Actual_Value_5, VAT_Paid_6, Present_Value_7, Reason_for_the_Unfit_8 };
                disposalOfUnusedUnfitInputsForm26Row.ItemArray = slNo1;
                base.Rows.Add(disposalOfUnusedUnfitInputsForm26Row);
                return disposalOfUnusedUnfitInputsForm26Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable disposalOfUnusedUnfitInputsForm26DataTable = (NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable)base.Clone();
                disposalOfUnusedUnfitInputsForm26DataTable.InitVars();
                return disposalOfUnusedUnfitInputsForm26DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Disposal_of_UnusedUnfit_Inputs_Form_26DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
            public NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row NewDisposal_of_UnusedUnfit_Inputs_Form_26Row()
            {
                return (NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanged != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanged(this, new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanging != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowChanging(this, new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleted != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleted(this, new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleting != null)
                {
                    this.Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleting(this, new NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent((NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveDisposal_of_UnusedUnfit_Inputs_Form_26Row(NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler Disposal_of_UnusedUnfit_Inputs_Form_26RowDeleting;
        }

        public class Disposal_of_UnusedUnfit_Inputs_Form_26Row : DataRow
        {
            private NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable tableDisposal_of_UnusedUnfit_Inputs_Form_26;

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
                this.tableDisposal_of_UnusedUnfit_Inputs_Form_26 = (NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsActual_Value_5Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Actual_Value_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsName_of_Inputs_2Null()
            {
                return base.IsNull(this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Name_of_Inputs_2Column);
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
            public void SetName_of_Inputs_2Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.Name_of_Inputs_2Column] = Convert.DBNull;
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
            public void SetVAT_Paid_6Null()
            {
                base[this.tableDisposal_of_UnusedUnfit_Inputs_Form_26.VAT_Paid_6Column] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row eventRow;

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
            public NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent(NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEventHandler(object sender, NBR_POS_DS.Disposal_of_UnusedUnfit_Inputs_Form_26RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class PDFDataTable : TypedTableBase<NBR_POS_DS.PDFRow>
        {
            private DataColumn columnSl_No_1;

            private DataColumn columnHS_Code_2;

            private DataColumn columnabbr_name;

            private DataColumn columntest;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn abbr_nameColumn
            {
                get
                {
                    return this.columnabbr_name;
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
            public DataColumn HS_Code_2Column
            {
                get
                {
                    return this.columnHS_Code_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.PDFRow this[int index]
            {
                get
                {
                    return (NBR_POS_DS.PDFRow)base.Rows[index];
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
            public DataColumn testColumn
            {
                get
                {
                    return this.columntest;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public PDFDataTable()
            {
                base.TableName = "PDF";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal PDFDataTable(DataTable table)
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
            protected PDFDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddPDFRow(NBR_POS_DS.PDFRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.PDFRow AddPDFRow(string Sl_No_1, string HS_Code_2, string abbr_name, string test)
            {
                NBR_POS_DS.PDFRow pDFRow = (NBR_POS_DS.PDFRow)base.NewRow();
                object[] slNo1 = new object[] { Sl_No_1, HS_Code_2, abbr_name, test };
                pDFRow.ItemArray = slNo1;
                base.Rows.Add(pDFRow);
                return pDFRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.PDFDataTable pDFDataTable = (NBR_POS_DS.PDFDataTable)base.Clone();
                pDFDataTable.InitVars();
                return pDFDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.PDFDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.PDFRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "PDFDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnSl_No_1 = new DataColumn("Sl_No_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSl_No_1);
                this.columnHS_Code_2 = new DataColumn("HS_Code_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnHS_Code_2);
                this.columnabbr_name = new DataColumn("abbr_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnabbr_name);
                this.columntest = new DataColumn("test", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntest);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnSl_No_1 = base.Columns["Sl_No_1"];
                this.columnHS_Code_2 = base.Columns["HS_Code_2"];
                this.columnabbr_name = base.Columns["abbr_name"];
                this.columntest = base.Columns["test"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.PDFRow NewPDFRow()
            {
                return (NBR_POS_DS.PDFRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.PDFRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.PDFRowChanged != null)
                {
                    this.PDFRowChanged(this, new NBR_POS_DS.PDFRowChangeEvent((NBR_POS_DS.PDFRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.PDFRowChanging != null)
                {
                    this.PDFRowChanging(this, new NBR_POS_DS.PDFRowChangeEvent((NBR_POS_DS.PDFRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.PDFRowDeleted != null)
                {
                    this.PDFRowDeleted(this, new NBR_POS_DS.PDFRowChangeEvent((NBR_POS_DS.PDFRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.PDFRowDeleting != null)
                {
                    this.PDFRowDeleting(this, new NBR_POS_DS.PDFRowChangeEvent((NBR_POS_DS.PDFRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovePDFRow(NBR_POS_DS.PDFRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.PDFRowChangeEventHandler PDFRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.PDFRowChangeEventHandler PDFRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.PDFRowChangeEventHandler PDFRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.PDFRowChangeEventHandler PDFRowDeleting;
        }

        public class PDFRow : DataRow
        {
            private NBR_POS_DS.PDFDataTable tablePDF;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string abbr_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePDF.abbr_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'abbr_name' in table 'PDF' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePDF.abbr_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string HS_Code_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePDF.HS_Code_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'HS_Code_2' in table 'PDF' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePDF.HS_Code_2Column] = value;
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
                        item = (string)base[this.tablePDF.Sl_No_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sl_No_1' in table 'PDF' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePDF.Sl_No_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string test
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePDF.testColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'test' in table 'PDF' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePDF.testColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal PDFRow(DataRowBuilder rb) : base(rb)
            {
                this.tablePDF = (NBR_POS_DS.PDFDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isabbr_nameNull()
            {
                return base.IsNull(this.tablePDF.abbr_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsHS_Code_2Null()
            {
                return base.IsNull(this.tablePDF.HS_Code_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSl_No_1Null()
            {
                return base.IsNull(this.tablePDF.Sl_No_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IstestNull()
            {
                return base.IsNull(this.tablePDF.testColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setabbr_nameNull()
            {
                base[this.tablePDF.abbr_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetHS_Code_2Null()
            {
                base[this.tablePDF.HS_Code_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSl_No_1Null()
            {
                base[this.tablePDF.Sl_No_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SettestNull()
            {
                base[this.tablePDF.testColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class PDFRowChangeEvent : EventArgs
        {
            private NBR_POS_DS.PDFRow eventRow;

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
            public NBR_POS_DS.PDFRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public PDFRowChangeEvent(NBR_POS_DS.PDFRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void PDFRowChangeEventHandler(object sender, NBR_POS_DS.PDFRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Price_Declaration_Form_1DataTable : TypedTableBase<NBR_POS_DS.Price_Declaration_Form_1Row>
        {
            private DataColumn column1_Sl_No;

            private DataColumn column2_HS_Code;

            private DataColumn column3_Goods_Name;

            private DataColumn _column3_1_Goods_Description;

            private DataColumn column4_Sale_Unit;

            private DataColumn column5_Raw_Meterials_Name;

            private DataColumn _column5_1_Rameterials_Description;

            private DataColumn column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation;

            private DataColumn column7_Total_Purchase_Price;

            private DataColumn column8_Value_Add;

            private DataColumn column9_Value_Added_Per_Unit;

            private DataColumn column10_Price_With_SD_Present;

            private DataColumn column11_Price_With_SD_Applied;

            private DataColumn column12_SD_On_Applied_Price;

            private DataColumn column13_VAT_Applicable_Price_Present;

            private DataColumn column14_VAT_Applicable_Price_Applied;

            private DataColumn column15_Sale_Price_With_DutyNTax_Wholesale;

            private DataColumn column16_Sale_Price_With_DutyNTax_Retail_Price;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1_Sl_NoColumn
            {
                get
                {
                    return this.column1_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _10_Price_With_SD_PresentColumn
            {
                get
                {
                    return this.column10_Price_With_SD_Present;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _11_Price_With_SD_AppliedColumn
            {
                get
                {
                    return this.column11_Price_With_SD_Applied;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _12_SD_On_Applied_PriceColumn
            {
                get
                {
                    return this.column12_SD_On_Applied_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _13_VAT_Applicable_Price_PresentColumn
            {
                get
                {
                    return this.column13_VAT_Applicable_Price_Present;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _14_VAT_Applicable_Price_AppliedColumn
            {
                get
                {
                    return this.column14_VAT_Applicable_Price_Applied;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _15_Sale_Price_With_DutyNTax_WholesaleColumn
            {
                get
                {
                    return this.column15_Sale_Price_With_DutyNTax_Wholesale;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _16_Sale_Price_With_DutyNTax_Retail_PriceColumn
            {
                get
                {
                    return this.column16_Sale_Price_With_DutyNTax_Retail_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_HS_CodeColumn
            {
                get
                {
                    return this.column2_HS_Code;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_1_Goods_DescriptionColumn
            {
                get
                {
                    return this._column3_1_Goods_Description;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_Goods_NameColumn
            {
                get
                {
                    return this.column3_Goods_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4_Sale_UnitColumn
            {
                get
                {
                    return this.column4_Sale_Unit;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_1_Rameterials_DescriptionColumn
            {
                get
                {
                    return this._column5_1_Rameterials_Description;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_Raw_Meterials_NameColumn
            {
                get
                {
                    return this.column5_Raw_Meterials_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationColumn
            {
                get
                {
                    return this.column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7_Total_Purchase_PriceColumn
            {
                get
                {
                    return this.column7_Total_Purchase_Price;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _8_Value_AddColumn
            {
                get
                {
                    return this.column8_Value_Add;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _9_Value_Added_Per_UnitColumn
            {
                get
                {
                    return this.column9_Value_Added_Per_Unit;
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
            public NBR_POS_DS.Price_Declaration_Form_1Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Price_Declaration_Form_1Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Price_Declaration_Form_1DataTable()
            {
                base.TableName = "Price_Declaration_Form_1";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Price_Declaration_Form_1DataTable(DataTable table)
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
            protected Price_Declaration_Form_1DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddPrice_Declaration_Form_1Row(NBR_POS_DS.Price_Declaration_Form_1Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Price_Declaration_Form_1Row AddPrice_Declaration_Form_1Row(string _2_HS_Code, string _3_Goods_Name, string _3_1_Goods_Description, string _4_Sale_Unit, string _5_Raw_Meterials_Name, string _5_1_Rameterials_Description, string _6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation, string _7_Total_Purchase_Price, string _8_Value_Add, string _9_Value_Added_Per_Unit, string _10_Price_With_SD_Present, string _11_Price_With_SD_Applied, string _12_SD_On_Applied_Price, string _13_VAT_Applicable_Price_Present, string _14_VAT_Applicable_Price_Applied, string _15_Sale_Price_With_DutyNTax_Wholesale, string _16_Sale_Price_With_DutyNTax_Retail_Price)
            {
                NBR_POS_DS.Price_Declaration_Form_1Row priceDeclarationForm1Row = (NBR_POS_DS.Price_Declaration_Form_1Row)base.NewRow();
                object[] _2HSCode = new object[] { null, _2_HS_Code, _3_Goods_Name, _3_1_Goods_Description, _4_Sale_Unit, _5_Raw_Meterials_Name, _5_1_Rameterials_Description, _6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation, _7_Total_Purchase_Price, _8_Value_Add, _9_Value_Added_Per_Unit, _10_Price_With_SD_Present, _11_Price_With_SD_Applied, _12_SD_On_Applied_Price, _13_VAT_Applicable_Price_Present, _14_VAT_Applicable_Price_Applied, _15_Sale_Price_With_DutyNTax_Wholesale, _16_Sale_Price_With_DutyNTax_Retail_Price };
                priceDeclarationForm1Row.ItemArray = _2HSCode;
                base.Rows.Add(priceDeclarationForm1Row);
                return priceDeclarationForm1Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Price_Declaration_Form_1DataTable priceDeclarationForm1DataTable = (NBR_POS_DS.Price_Declaration_Form_1DataTable)base.Clone();
                priceDeclarationForm1DataTable.InitVars();
                return priceDeclarationForm1DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Price_Declaration_Form_1DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Price_Declaration_Form_1Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Price_Declaration_Form_1DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.column1_Sl_No = new DataColumn("1_Sl_No", typeof(int), null, MappingType.Element);
                this.column1_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column1_Sl_No");
                this.column1_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "1_Sl_No");
                base.Columns.Add(this.column1_Sl_No);
                this.column2_HS_Code = new DataColumn("2_HS_Code", typeof(string), null, MappingType.Element);
                this.column2_HS_Code.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column2_HS_Code");
                this.column2_HS_Code.ExtendedProperties.Add("Generator_UserColumnName", "2_HS_Code");
                base.Columns.Add(this.column2_HS_Code);
                this.column3_Goods_Name = new DataColumn("3_Goods_Name", typeof(string), null, MappingType.Element);
                this.column3_Goods_Name.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column3_Goods_Name");
                this.column3_Goods_Name.ExtendedProperties.Add("Generator_UserColumnName", "3_Goods_Name");
                base.Columns.Add(this.column3_Goods_Name);
                this._column3_1_Goods_Description = new DataColumn("3.1_Goods_Description", typeof(string), null, MappingType.Element);
                this._column3_1_Goods_Description.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_column3_1_Goods_Description");
                this._column3_1_Goods_Description.ExtendedProperties.Add("Generator_UserColumnName", "3.1_Goods_Description");
                base.Columns.Add(this._column3_1_Goods_Description);
                this.column4_Sale_Unit = new DataColumn("4_Sale_Unit", typeof(string), null, MappingType.Element);
                this.column4_Sale_Unit.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column4_Sale_Unit");
                this.column4_Sale_Unit.ExtendedProperties.Add("Generator_UserColumnName", "4_Sale_Unit");
                base.Columns.Add(this.column4_Sale_Unit);
                this.column5_Raw_Meterials_Name = new DataColumn("5_Raw_Meterials_Name", typeof(string), null, MappingType.Element);
                this.column5_Raw_Meterials_Name.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column5_Raw_Meterials_Name");
                this.column5_Raw_Meterials_Name.ExtendedProperties.Add("Generator_UserColumnName", "5_Raw_Meterials_Name");
                base.Columns.Add(this.column5_Raw_Meterials_Name);
                this._column5_1_Rameterials_Description = new DataColumn("5.1_Rameterials_Description", typeof(string), null, MappingType.Element);
                this._column5_1_Rameterials_Description.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "_column5_1_Rameterials_Description");
                this._column5_1_Rameterials_Description.ExtendedProperties.Add("Generator_UserColumnName", "5.1_Rameterials_Description");
                base.Columns.Add(this._column5_1_Rameterials_Description);
                this.column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation = new DataColumn("6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation", typeof(string), null, MappingType.Element);
                this.column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation");
                this.column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation.ExtendedProperties.Add("Generator_UserColumnName", "6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation");
                base.Columns.Add(this.column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation);
                this.column7_Total_Purchase_Price = new DataColumn("7_Total_Purchase_Price", typeof(string), null, MappingType.Element);
                this.column7_Total_Purchase_Price.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column7_Total_Purchase_Price");
                this.column7_Total_Purchase_Price.ExtendedProperties.Add("Generator_UserColumnName", "7_Total_Purchase_Price");
                base.Columns.Add(this.column7_Total_Purchase_Price);
                this.column8_Value_Add = new DataColumn("8_Value_Add", typeof(string), null, MappingType.Element);
                this.column8_Value_Add.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column8_Value_Add");
                this.column8_Value_Add.ExtendedProperties.Add("Generator_UserColumnName", "8_Value_Add");
                base.Columns.Add(this.column8_Value_Add);
                this.column9_Value_Added_Per_Unit = new DataColumn("9_Value_Added_Per_Unit", typeof(string), null, MappingType.Element);
                this.column9_Value_Added_Per_Unit.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column9_Value_Added_Per_Unit");
                this.column9_Value_Added_Per_Unit.ExtendedProperties.Add("Generator_UserColumnName", "9_Value_Added_Per_Unit");
                base.Columns.Add(this.column9_Value_Added_Per_Unit);
                this.column10_Price_With_SD_Present = new DataColumn("10_Price_With_SD_Present", typeof(string), null, MappingType.Element);
                this.column10_Price_With_SD_Present.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column10_Price_With_SD_Present");
                this.column10_Price_With_SD_Present.ExtendedProperties.Add("Generator_UserColumnName", "10_Price_With_SD_Present");
                base.Columns.Add(this.column10_Price_With_SD_Present);
                this.column11_Price_With_SD_Applied = new DataColumn("11_Price_With_SD_Applied", typeof(string), null, MappingType.Element);
                this.column11_Price_With_SD_Applied.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column11_Price_With_SD_Applied");
                this.column11_Price_With_SD_Applied.ExtendedProperties.Add("Generator_UserColumnName", "11_Price_With_SD_Applied");
                base.Columns.Add(this.column11_Price_With_SD_Applied);
                this.column12_SD_On_Applied_Price = new DataColumn("12_SD_On_Applied_Price", typeof(string), null, MappingType.Element);
                this.column12_SD_On_Applied_Price.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column12_SD_On_Applied_Price");
                this.column12_SD_On_Applied_Price.ExtendedProperties.Add("Generator_UserColumnName", "12_SD_On_Applied_Price");
                base.Columns.Add(this.column12_SD_On_Applied_Price);
                this.column13_VAT_Applicable_Price_Present = new DataColumn("13_VAT_Applicable_Price_Present", typeof(string), null, MappingType.Element);
                this.column13_VAT_Applicable_Price_Present.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column13_VAT_Applicable_Price_Present");
                this.column13_VAT_Applicable_Price_Present.ExtendedProperties.Add("Generator_UserColumnName", "13_VAT_Applicable_Price_Present");
                base.Columns.Add(this.column13_VAT_Applicable_Price_Present);
                this.column14_VAT_Applicable_Price_Applied = new DataColumn("14_VAT_Applicable_Price_Applied", typeof(string), null, MappingType.Element);
                this.column14_VAT_Applicable_Price_Applied.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column14_VAT_Applicable_Price_Applied");
                this.column14_VAT_Applicable_Price_Applied.ExtendedProperties.Add("Generator_UserColumnName", "14_VAT_Applicable_Price_Applied");
                base.Columns.Add(this.column14_VAT_Applicable_Price_Applied);
                this.column15_Sale_Price_With_DutyNTax_Wholesale = new DataColumn("15_Sale_Price_With_DutyNTax_Wholesale", typeof(string), null, MappingType.Element);
                this.column15_Sale_Price_With_DutyNTax_Wholesale.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column15_Sale_Price_With_DutyNTax_Wholesale");
                this.column15_Sale_Price_With_DutyNTax_Wholesale.ExtendedProperties.Add("Generator_UserColumnName", "15_Sale_Price_With_DutyNTax_Wholesale");
                base.Columns.Add(this.column15_Sale_Price_With_DutyNTax_Wholesale);
                this.column16_Sale_Price_With_DutyNTax_Retail_Price = new DataColumn("16_Sale_Price_With_DutyNTax_Retail_Price", typeof(string), null, MappingType.Element);
                this.column16_Sale_Price_With_DutyNTax_Retail_Price.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column16_Sale_Price_With_DutyNTax_Retail_Price");
                this.column16_Sale_Price_With_DutyNTax_Retail_Price.ExtendedProperties.Add("Generator_UserColumnName", "16_Sale_Price_With_DutyNTax_Retail_Price");
                base.Columns.Add(this.column16_Sale_Price_With_DutyNTax_Retail_Price);
                this.column1_Sl_No.AutoIncrement = true;
                this.column1_Sl_No.AutoIncrementSeed = (long)-1;
                this.column1_Sl_No.AutoIncrementStep = (long)-1;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.column1_Sl_No = base.Columns["1_Sl_No"];
                this.column2_HS_Code = base.Columns["2_HS_Code"];
                this.column3_Goods_Name = base.Columns["3_Goods_Name"];
                this._column3_1_Goods_Description = base.Columns["3.1_Goods_Description"];
                this.column4_Sale_Unit = base.Columns["4_Sale_Unit"];
                this.column5_Raw_Meterials_Name = base.Columns["5_Raw_Meterials_Name"];
                this._column5_1_Rameterials_Description = base.Columns["5.1_Rameterials_Description"];
                this.column6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation = base.Columns["6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation"];
                this.column7_Total_Purchase_Price = base.Columns["7_Total_Purchase_Price"];
                this.column8_Value_Add = base.Columns["8_Value_Add"];
                this.column9_Value_Added_Per_Unit = base.Columns["9_Value_Added_Per_Unit"];
                this.column10_Price_With_SD_Present = base.Columns["10_Price_With_SD_Present"];
                this.column11_Price_With_SD_Applied = base.Columns["11_Price_With_SD_Applied"];
                this.column12_SD_On_Applied_Price = base.Columns["12_SD_On_Applied_Price"];
                this.column13_VAT_Applicable_Price_Present = base.Columns["13_VAT_Applicable_Price_Present"];
                this.column14_VAT_Applicable_Price_Applied = base.Columns["14_VAT_Applicable_Price_Applied"];
                this.column15_Sale_Price_With_DutyNTax_Wholesale = base.Columns["15_Sale_Price_With_DutyNTax_Wholesale"];
                this.column16_Sale_Price_With_DutyNTax_Retail_Price = base.Columns["16_Sale_Price_With_DutyNTax_Retail_Price"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Price_Declaration_Form_1Row NewPrice_Declaration_Form_1Row()
            {
                return (NBR_POS_DS.Price_Declaration_Form_1Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Price_Declaration_Form_1Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Price_Declaration_Form_1RowChanged != null)
                {
                    this.Price_Declaration_Form_1RowChanged(this, new NBR_POS_DS.Price_Declaration_Form_1RowChangeEvent((NBR_POS_DS.Price_Declaration_Form_1Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Price_Declaration_Form_1RowChanging != null)
                {
                    this.Price_Declaration_Form_1RowChanging(this, new NBR_POS_DS.Price_Declaration_Form_1RowChangeEvent((NBR_POS_DS.Price_Declaration_Form_1Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Price_Declaration_Form_1RowDeleted != null)
                {
                    this.Price_Declaration_Form_1RowDeleted(this, new NBR_POS_DS.Price_Declaration_Form_1RowChangeEvent((NBR_POS_DS.Price_Declaration_Form_1Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Price_Declaration_Form_1RowDeleting != null)
                {
                    this.Price_Declaration_Form_1RowDeleting(this, new NBR_POS_DS.Price_Declaration_Form_1RowChangeEvent((NBR_POS_DS.Price_Declaration_Form_1Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovePrice_Declaration_Form_1Row(NBR_POS_DS.Price_Declaration_Form_1Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Price_Declaration_Form_1RowChangeEventHandler Price_Declaration_Form_1RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Price_Declaration_Form_1RowChangeEventHandler Price_Declaration_Form_1RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Price_Declaration_Form_1RowChangeEventHandler Price_Declaration_Form_1RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Price_Declaration_Form_1RowChangeEventHandler Price_Declaration_Form_1RowDeleting;
        }

        public class Price_Declaration_Form_1Row : DataRow
        {
            private NBR_POS_DS.Price_Declaration_Form_1DataTable tablePrice_Declaration_Form_1;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public int _1_Sl_No
            {
                get
                {
                    int item;
                    try
                    {
                        item = (int)base[this.tablePrice_Declaration_Form_1._1_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '1_Sl_No' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._1_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _10_Price_With_SD_Present
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._10_Price_With_SD_PresentColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '10_Price_With_SD_Present' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._10_Price_With_SD_PresentColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _11_Price_With_SD_Applied
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._11_Price_With_SD_AppliedColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '11_Price_With_SD_Applied' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._11_Price_With_SD_AppliedColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _12_SD_On_Applied_Price
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._12_SD_On_Applied_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '12_SD_On_Applied_Price' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._12_SD_On_Applied_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _13_VAT_Applicable_Price_Present
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._13_VAT_Applicable_Price_PresentColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '13_VAT_Applicable_Price_Present' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._13_VAT_Applicable_Price_PresentColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _14_VAT_Applicable_Price_Applied
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._14_VAT_Applicable_Price_AppliedColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '14_VAT_Applicable_Price_Applied' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._14_VAT_Applicable_Price_AppliedColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _15_Sale_Price_With_DutyNTax_Wholesale
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._15_Sale_Price_With_DutyNTax_WholesaleColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '15_Sale_Price_With_DutyNTax_Wholesale' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._15_Sale_Price_With_DutyNTax_WholesaleColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _16_Sale_Price_With_DutyNTax_Retail_Price
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._16_Sale_Price_With_DutyNTax_Retail_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '16_Sale_Price_With_DutyNTax_Retail_Price' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._16_Sale_Price_With_DutyNTax_Retail_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_HS_Code
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._2_HS_CodeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2_HS_Code' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._2_HS_CodeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_1_Goods_Description
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._3_1_Goods_DescriptionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3.1_Goods_Description' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._3_1_Goods_DescriptionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_Goods_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._3_Goods_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3_Goods_Name' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._3_Goods_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4_Sale_Unit
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._4_Sale_UnitColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '4_Sale_Unit' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._4_Sale_UnitColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_1_Rameterials_Description
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._5_1_Rameterials_DescriptionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5.1_Rameterials_Description' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._5_1_Rameterials_DescriptionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_Raw_Meterials_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._5_Raw_Meterials_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5_Raw_Meterials_Name' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._5_Raw_Meterials_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '6_Raw_Meterials_Quantity_AsPer_Unit_With_Depreciation' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7_Total_Purchase_Price
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._7_Total_Purchase_PriceColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '7_Total_Purchase_Price' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._7_Total_Purchase_PriceColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _8_Value_Add
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._8_Value_AddColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '8_Value_Add' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._8_Value_AddColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _9_Value_Added_Per_Unit
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePrice_Declaration_Form_1._9_Value_Added_Per_UnitColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '9_Value_Added_Per_Unit' in table 'Price_Declaration_Form_1' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePrice_Declaration_Form_1._9_Value_Added_Per_UnitColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Price_Declaration_Form_1Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePrice_Declaration_Form_1 = (NBR_POS_DS.Price_Declaration_Form_1DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1_Sl_NoNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._1_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_10_Price_With_SD_PresentNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._10_Price_With_SD_PresentColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_11_Price_With_SD_AppliedNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._11_Price_With_SD_AppliedColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_12_SD_On_Applied_PriceNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._12_SD_On_Applied_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_13_VAT_Applicable_Price_PresentNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._13_VAT_Applicable_Price_PresentColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_14_VAT_Applicable_Price_AppliedNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._14_VAT_Applicable_Price_AppliedColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_15_Sale_Price_With_DutyNTax_WholesaleNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._15_Sale_Price_With_DutyNTax_WholesaleColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_16_Sale_Price_With_DutyNTax_Retail_PriceNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._16_Sale_Price_With_DutyNTax_Retail_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_HS_CodeNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._2_HS_CodeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_1_Goods_DescriptionNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._3_1_Goods_DescriptionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_Goods_NameNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._3_Goods_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4_Sale_UnitNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._4_Sale_UnitColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_1_Rameterials_DescriptionNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._5_1_Rameterials_DescriptionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_Raw_Meterials_NameNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._5_Raw_Meterials_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7_Total_Purchase_PriceNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._7_Total_Purchase_PriceColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_8_Value_AddNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._8_Value_AddColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_9_Value_Added_Per_UnitNull()
            {
                return base.IsNull(this.tablePrice_Declaration_Form_1._9_Value_Added_Per_UnitColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_1_Sl_NoNull()
            {
                base[this.tablePrice_Declaration_Form_1._1_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_10_Price_With_SD_PresentNull()
            {
                base[this.tablePrice_Declaration_Form_1._10_Price_With_SD_PresentColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_11_Price_With_SD_AppliedNull()
            {
                base[this.tablePrice_Declaration_Form_1._11_Price_With_SD_AppliedColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_12_SD_On_Applied_PriceNull()
            {
                base[this.tablePrice_Declaration_Form_1._12_SD_On_Applied_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_13_VAT_Applicable_Price_PresentNull()
            {
                base[this.tablePrice_Declaration_Form_1._13_VAT_Applicable_Price_PresentColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_14_VAT_Applicable_Price_AppliedNull()
            {
                base[this.tablePrice_Declaration_Form_1._14_VAT_Applicable_Price_AppliedColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_15_Sale_Price_With_DutyNTax_WholesaleNull()
            {
                base[this.tablePrice_Declaration_Form_1._15_Sale_Price_With_DutyNTax_WholesaleColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_16_Sale_Price_With_DutyNTax_Retail_PriceNull()
            {
                base[this.tablePrice_Declaration_Form_1._16_Sale_Price_With_DutyNTax_Retail_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_HS_CodeNull()
            {
                base[this.tablePrice_Declaration_Form_1._2_HS_CodeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_1_Goods_DescriptionNull()
            {
                base[this.tablePrice_Declaration_Form_1._3_1_Goods_DescriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_Goods_NameNull()
            {
                base[this.tablePrice_Declaration_Form_1._3_Goods_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4_Sale_UnitNull()
            {
                base[this.tablePrice_Declaration_Form_1._4_Sale_UnitColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_1_Rameterials_DescriptionNull()
            {
                base[this.tablePrice_Declaration_Form_1._5_1_Rameterials_DescriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_Raw_Meterials_NameNull()
            {
                base[this.tablePrice_Declaration_Form_1._5_Raw_Meterials_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationNull()
            {
                base[this.tablePrice_Declaration_Form_1._6_Raw_Meterials_Quantity_AsPer_Unit_With_DepreciationColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7_Total_Purchase_PriceNull()
            {
                base[this.tablePrice_Declaration_Form_1._7_Total_Purchase_PriceColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_8_Value_AddNull()
            {
                base[this.tablePrice_Declaration_Form_1._8_Value_AddColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_9_Value_Added_Per_UnitNull()
            {
                base[this.tablePrice_Declaration_Form_1._9_Value_Added_Per_UnitColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Price_Declaration_Form_1RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Price_Declaration_Form_1Row eventRow;

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
            public NBR_POS_DS.Price_Declaration_Form_1Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Price_Declaration_Form_1RowChangeEvent(NBR_POS_DS.Price_Declaration_Form_1Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Price_Declaration_Form_1RowChangeEventHandler(object sender, NBR_POS_DS.Price_Declaration_Form_1RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Purchase_Account_Form_16DataTable : TypedTableBase<NBR_POS_DS.Purchase_Account_Form_16Row>
        {
            private DataColumn column1_Sl_No;

            private DataColumn column2_Date;

            private DataColumn column3_Opening_Balance_Quantity;

            private DataColumn column4_Opening_Balance_Value;

            private DataColumn column5_ChallanBill_of_Entry_No;

            private DataColumn column6_ChallanBill_of_Entry_Date;

            private DataColumn column7_Name;

            private DataColumn column8_Address;

            private DataColumn column10_Description;

            private DataColumn column11_Quantity;

            private DataColumn column12_Value_Excluding_SD_VAT;

            private DataColumn column13_SD;

            private DataColumn column14_VAT;

            private DataColumn column15_Traders_Quantity;

            private DataColumn column16_Traders_Value;

            private DataColumn column17_Closing_Balance_Quantity;

            private DataColumn column18_Closing_Balance_Value;

            private DataColumn column19_Remarks;

            private DataColumn column9_Registration_No;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1_Sl_NoColumn
            {
                get
                {
                    return this.column1_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _10_DescriptionColumn
            {
                get
                {
                    return this.column10_Description;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _11_QuantityColumn
            {
                get
                {
                    return this.column11_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _12_Value_Excluding_SD_VATColumn
            {
                get
                {
                    return this.column12_Value_Excluding_SD_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _13_SDColumn
            {
                get
                {
                    return this.column13_SD;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _14_VATColumn
            {
                get
                {
                    return this.column14_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _15_Traders_QuantityColumn
            {
                get
                {
                    return this.column15_Traders_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _16_Traders_ValueColumn
            {
                get
                {
                    return this.column16_Traders_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _17_Closing_Balance_QuantityColumn
            {
                get
                {
                    return this.column17_Closing_Balance_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _18_Closing_Balance_ValueColumn
            {
                get
                {
                    return this.column18_Closing_Balance_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _19_RemarksColumn
            {
                get
                {
                    return this.column19_Remarks;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_DateColumn
            {
                get
                {
                    return this.column2_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_Opening_Balance_QuantityColumn
            {
                get
                {
                    return this.column3_Opening_Balance_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4_Opening_Balance_ValueColumn
            {
                get
                {
                    return this.column4_Opening_Balance_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_ChallanBill_of_Entry_NoColumn
            {
                get
                {
                    return this.column5_ChallanBill_of_Entry_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6_ChallanBill_of_Entry_DateColumn
            {
                get
                {
                    return this.column6_ChallanBill_of_Entry_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7_NameColumn
            {
                get
                {
                    return this.column7_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _8_AddressColumn
            {
                get
                {
                    return this.column8_Address;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _9_Registration_NoColumn
            {
                get
                {
                    return this.column9_Registration_No;
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
            public NBR_POS_DS.Purchase_Account_Form_16Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Purchase_Account_Form_16Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Purchase_Account_Form_16DataTable()
            {
                base.TableName = "Purchase_Account_Form_16";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Purchase_Account_Form_16DataTable(DataTable table)
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
            protected Purchase_Account_Form_16DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddPurchase_Account_Form_16Row(NBR_POS_DS.Purchase_Account_Form_16Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Purchase_Account_Form_16Row AddPurchase_Account_Form_16Row(string _1_Sl_No, string _2_Date, string _3_Opening_Balance_Quantity, string _4_Opening_Balance_Value, string _5_ChallanBill_of_Entry_No, string _6_ChallanBill_of_Entry_Date, string _7_Name, string _8_Address, string _10_Description, string _11_Quantity, string _12_Value_Excluding_SD_VAT, string _13_SD, string _14_VAT, string _15_Traders_Quantity, string _16_Traders_Value, string _17_Closing_Balance_Quantity, string _18_Closing_Balance_Value, string _19_Remarks, string _9_Registration_No)
            {
                NBR_POS_DS.Purchase_Account_Form_16Row purchaseAccountForm16Row = (NBR_POS_DS.Purchase_Account_Form_16Row)base.NewRow();
                object[] _1SlNo = new object[] { _1_Sl_No, _2_Date, _3_Opening_Balance_Quantity, _4_Opening_Balance_Value, _5_ChallanBill_of_Entry_No, _6_ChallanBill_of_Entry_Date, _7_Name, _8_Address, _10_Description, _11_Quantity, _12_Value_Excluding_SD_VAT, _13_SD, _14_VAT, _15_Traders_Quantity, _16_Traders_Value, _17_Closing_Balance_Quantity, _18_Closing_Balance_Value, _19_Remarks, _9_Registration_No };
                purchaseAccountForm16Row.ItemArray = _1SlNo;
                base.Rows.Add(purchaseAccountForm16Row);
                return purchaseAccountForm16Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Purchase_Account_Form_16DataTable purchaseAccountForm16DataTable = (NBR_POS_DS.Purchase_Account_Form_16DataTable)base.Clone();
                purchaseAccountForm16DataTable.InitVars();
                return purchaseAccountForm16DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Purchase_Account_Form_16DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Purchase_Account_Form_16Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Purchase_Account_Form_16DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.column1_Sl_No = new DataColumn("1_Sl_No", typeof(string), null, MappingType.Element);
                this.column1_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column1_Sl_No");
                this.column1_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "1_Sl_No");
                base.Columns.Add(this.column1_Sl_No);
                this.column2_Date = new DataColumn("2_Date", typeof(string), null, MappingType.Element);
                this.column2_Date.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column2_Date");
                this.column2_Date.ExtendedProperties.Add("Generator_UserColumnName", "2_Date");
                base.Columns.Add(this.column2_Date);
                this.column3_Opening_Balance_Quantity = new DataColumn("3_Opening_Balance_Quantity", typeof(string), null, MappingType.Element);
                this.column3_Opening_Balance_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column3_Opening_Balance_Quantity");
                this.column3_Opening_Balance_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "3_Opening_Balance_Quantity");
                base.Columns.Add(this.column3_Opening_Balance_Quantity);
                this.column4_Opening_Balance_Value = new DataColumn("4_Opening_Balance_Value", typeof(string), null, MappingType.Element);
                this.column4_Opening_Balance_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column4_Opening_Balance_Value");
                this.column4_Opening_Balance_Value.ExtendedProperties.Add("Generator_UserColumnName", "4_Opening_Balance_Value");
                base.Columns.Add(this.column4_Opening_Balance_Value);
                this.column5_ChallanBill_of_Entry_No = new DataColumn("5_ChallanBill_of_Entry_No", typeof(string), null, MappingType.Element);
                this.column5_ChallanBill_of_Entry_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column5_ChallanBill_of_Entry_No");
                this.column5_ChallanBill_of_Entry_No.ExtendedProperties.Add("Generator_UserColumnName", "5_ChallanBill_of_Entry_No");
                base.Columns.Add(this.column5_ChallanBill_of_Entry_No);
                this.column6_ChallanBill_of_Entry_Date = new DataColumn("6_ChallanBill_of_Entry_Date", typeof(string), null, MappingType.Element);
                this.column6_ChallanBill_of_Entry_Date.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column6_ChallanBill_of_Entry_Date");
                this.column6_ChallanBill_of_Entry_Date.ExtendedProperties.Add("Generator_UserColumnName", "6_ChallanBill_of_Entry_Date");
                base.Columns.Add(this.column6_ChallanBill_of_Entry_Date);
                this.column7_Name = new DataColumn("7_Name", typeof(string), null, MappingType.Element);
                this.column7_Name.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column7_Name");
                this.column7_Name.ExtendedProperties.Add("Generator_UserColumnName", "7_Name");
                base.Columns.Add(this.column7_Name);
                this.column8_Address = new DataColumn("8_Address", typeof(string), null, MappingType.Element);
                this.column8_Address.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column8_Address");
                this.column8_Address.ExtendedProperties.Add("Generator_UserColumnName", "8_Address");
                base.Columns.Add(this.column8_Address);
                this.column10_Description = new DataColumn("10_Description", typeof(string), null, MappingType.Element);
                this.column10_Description.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column10_Description");
                this.column10_Description.ExtendedProperties.Add("Generator_UserColumnName", "10_Description");
                base.Columns.Add(this.column10_Description);
                this.column11_Quantity = new DataColumn("11_Quantity", typeof(string), null, MappingType.Element);
                this.column11_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column11_Quantity");
                this.column11_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "11_Quantity");
                base.Columns.Add(this.column11_Quantity);
                this.column12_Value_Excluding_SD_VAT = new DataColumn("12_Value_Excluding_SD_VAT", typeof(string), null, MappingType.Element);
                this.column12_Value_Excluding_SD_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column12_Value_Excluding_SD_VAT");
                this.column12_Value_Excluding_SD_VAT.ExtendedProperties.Add("Generator_UserColumnName", "12_Value_Excluding_SD_VAT");
                base.Columns.Add(this.column12_Value_Excluding_SD_VAT);
                this.column13_SD = new DataColumn("13_SD", typeof(string), null, MappingType.Element);
                this.column13_SD.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column13_SD");
                this.column13_SD.ExtendedProperties.Add("Generator_UserColumnName", "13_SD");
                base.Columns.Add(this.column13_SD);
                this.column14_VAT = new DataColumn("14_VAT", typeof(string), null, MappingType.Element);
                this.column14_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column14_VAT");
                this.column14_VAT.ExtendedProperties.Add("Generator_UserColumnName", "14_VAT");
                base.Columns.Add(this.column14_VAT);
                this.column15_Traders_Quantity = new DataColumn("15_Traders_Quantity", typeof(string), null, MappingType.Element);
                this.column15_Traders_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column15_Traders_Quantity");
                this.column15_Traders_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "15_Traders_Quantity");
                base.Columns.Add(this.column15_Traders_Quantity);
                this.column16_Traders_Value = new DataColumn("16_Traders_Value", typeof(string), null, MappingType.Element);
                this.column16_Traders_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column16_Traders_Value");
                this.column16_Traders_Value.ExtendedProperties.Add("Generator_UserColumnName", "16_Traders_Value");
                base.Columns.Add(this.column16_Traders_Value);
                this.column17_Closing_Balance_Quantity = new DataColumn("17_Closing_Balance_Quantity", typeof(string), null, MappingType.Element);
                this.column17_Closing_Balance_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column17_Closing_Balance_Quantity");
                this.column17_Closing_Balance_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "17_Closing_Balance_Quantity");
                base.Columns.Add(this.column17_Closing_Balance_Quantity);
                this.column18_Closing_Balance_Value = new DataColumn("18_Closing_Balance_Value", typeof(string), null, MappingType.Element);
                this.column18_Closing_Balance_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column18_Closing_Balance_Value");
                this.column18_Closing_Balance_Value.ExtendedProperties.Add("Generator_UserColumnName", "18_Closing_Balance_Value");
                base.Columns.Add(this.column18_Closing_Balance_Value);
                this.column19_Remarks = new DataColumn("19_Remarks", typeof(string), null, MappingType.Element);
                this.column19_Remarks.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column19_Remarks");
                this.column19_Remarks.ExtendedProperties.Add("Generator_UserColumnName", "19_Remarks");
                base.Columns.Add(this.column19_Remarks);
                this.column9_Registration_No = new DataColumn("9_Registration_No", typeof(string), null, MappingType.Element);
                this.column9_Registration_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column9_Registration_No");
                this.column9_Registration_No.ExtendedProperties.Add("Generator_UserColumnName", "9_Registration_No");
                base.Columns.Add(this.column9_Registration_No);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.column1_Sl_No = base.Columns["1_Sl_No"];
                this.column2_Date = base.Columns["2_Date"];
                this.column3_Opening_Balance_Quantity = base.Columns["3_Opening_Balance_Quantity"];
                this.column4_Opening_Balance_Value = base.Columns["4_Opening_Balance_Value"];
                this.column5_ChallanBill_of_Entry_No = base.Columns["5_ChallanBill_of_Entry_No"];
                this.column6_ChallanBill_of_Entry_Date = base.Columns["6_ChallanBill_of_Entry_Date"];
                this.column7_Name = base.Columns["7_Name"];
                this.column8_Address = base.Columns["8_Address"];
                this.column10_Description = base.Columns["10_Description"];
                this.column11_Quantity = base.Columns["11_Quantity"];
                this.column12_Value_Excluding_SD_VAT = base.Columns["12_Value_Excluding_SD_VAT"];
                this.column13_SD = base.Columns["13_SD"];
                this.column14_VAT = base.Columns["14_VAT"];
                this.column15_Traders_Quantity = base.Columns["15_Traders_Quantity"];
                this.column16_Traders_Value = base.Columns["16_Traders_Value"];
                this.column17_Closing_Balance_Quantity = base.Columns["17_Closing_Balance_Quantity"];
                this.column18_Closing_Balance_Value = base.Columns["18_Closing_Balance_Value"];
                this.column19_Remarks = base.Columns["19_Remarks"];
                this.column9_Registration_No = base.Columns["9_Registration_No"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Purchase_Account_Form_16Row NewPurchase_Account_Form_16Row()
            {
                return (NBR_POS_DS.Purchase_Account_Form_16Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Purchase_Account_Form_16Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Purchase_Account_Form_16RowChanged != null)
                {
                    this.Purchase_Account_Form_16RowChanged(this, new NBR_POS_DS.Purchase_Account_Form_16RowChangeEvent((NBR_POS_DS.Purchase_Account_Form_16Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Purchase_Account_Form_16RowChanging != null)
                {
                    this.Purchase_Account_Form_16RowChanging(this, new NBR_POS_DS.Purchase_Account_Form_16RowChangeEvent((NBR_POS_DS.Purchase_Account_Form_16Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Purchase_Account_Form_16RowDeleted != null)
                {
                    this.Purchase_Account_Form_16RowDeleted(this, new NBR_POS_DS.Purchase_Account_Form_16RowChangeEvent((NBR_POS_DS.Purchase_Account_Form_16Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Purchase_Account_Form_16RowDeleting != null)
                {
                    this.Purchase_Account_Form_16RowDeleting(this, new NBR_POS_DS.Purchase_Account_Form_16RowChangeEvent((NBR_POS_DS.Purchase_Account_Form_16Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovePurchase_Account_Form_16Row(NBR_POS_DS.Purchase_Account_Form_16Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Purchase_Account_Form_16RowChangeEventHandler Purchase_Account_Form_16RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Purchase_Account_Form_16RowChangeEventHandler Purchase_Account_Form_16RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Purchase_Account_Form_16RowChangeEventHandler Purchase_Account_Form_16RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Purchase_Account_Form_16RowChangeEventHandler Purchase_Account_Form_16RowDeleting;
        }

        public class Purchase_Account_Form_16Row : DataRow
        {
            private NBR_POS_DS.Purchase_Account_Form_16DataTable tablePurchase_Account_Form_16;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _1_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._1_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '1_Sl_No' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._1_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _10_Description
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._10_DescriptionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '10_Description' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._10_DescriptionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _11_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._11_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '11_Quantity' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._11_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _12_Value_Excluding_SD_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._12_Value_Excluding_SD_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '12_Value_Excluding_SD_VAT' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._12_Value_Excluding_SD_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _13_SD
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._13_SDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '13_SD' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._13_SDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _14_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._14_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '14_VAT' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._14_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _15_Traders_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._15_Traders_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '15_Traders_Quantity' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._15_Traders_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _16_Traders_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._16_Traders_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '16_Traders_Value' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._16_Traders_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _17_Closing_Balance_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._17_Closing_Balance_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '17_Closing_Balance_Quantity' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._17_Closing_Balance_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _18_Closing_Balance_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._18_Closing_Balance_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '18_Closing_Balance_Value' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._18_Closing_Balance_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _19_Remarks
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._19_RemarksColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '19_Remarks' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._19_RemarksColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._2_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2_Date' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._2_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_Opening_Balance_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._3_Opening_Balance_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3_Opening_Balance_Quantity' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._3_Opening_Balance_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4_Opening_Balance_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._4_Opening_Balance_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '4_Opening_Balance_Value' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._4_Opening_Balance_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_ChallanBill_of_Entry_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._5_ChallanBill_of_Entry_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5_ChallanBill_of_Entry_No' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._5_ChallanBill_of_Entry_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6_ChallanBill_of_Entry_Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._6_ChallanBill_of_Entry_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '6_ChallanBill_of_Entry_Date' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._6_ChallanBill_of_Entry_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._7_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '7_Name' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._7_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _8_Address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._8_AddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '8_Address' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._8_AddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _9_Registration_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tablePurchase_Account_Form_16._9_Registration_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '9_Registration_No' in table 'Purchase_Account_Form_16' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tablePurchase_Account_Form_16._9_Registration_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Purchase_Account_Form_16Row(DataRowBuilder rb) : base(rb)
            {
                this.tablePurchase_Account_Form_16 = (NBR_POS_DS.Purchase_Account_Form_16DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1_Sl_NoNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._1_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_10_DescriptionNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._10_DescriptionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_11_QuantityNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._11_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_12_Value_Excluding_SD_VATNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._12_Value_Excluding_SD_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_13_SDNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._13_SDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_14_VATNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._14_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_15_Traders_QuantityNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._15_Traders_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_16_Traders_ValueNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._16_Traders_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_17_Closing_Balance_QuantityNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._17_Closing_Balance_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_18_Closing_Balance_ValueNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._18_Closing_Balance_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_19_RemarksNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._19_RemarksColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_DateNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._2_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_Opening_Balance_QuantityNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._3_Opening_Balance_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4_Opening_Balance_ValueNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._4_Opening_Balance_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_ChallanBill_of_Entry_NoNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._5_ChallanBill_of_Entry_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6_ChallanBill_of_Entry_DateNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._6_ChallanBill_of_Entry_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7_NameNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._7_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_8_AddressNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._8_AddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_9_Registration_NoNull()
            {
                return base.IsNull(this.tablePurchase_Account_Form_16._9_Registration_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_1_Sl_NoNull()
            {
                base[this.tablePurchase_Account_Form_16._1_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_10_DescriptionNull()
            {
                base[this.tablePurchase_Account_Form_16._10_DescriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_11_QuantityNull()
            {
                base[this.tablePurchase_Account_Form_16._11_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_12_Value_Excluding_SD_VATNull()
            {
                base[this.tablePurchase_Account_Form_16._12_Value_Excluding_SD_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_13_SDNull()
            {
                base[this.tablePurchase_Account_Form_16._13_SDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_14_VATNull()
            {
                base[this.tablePurchase_Account_Form_16._14_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_15_Traders_QuantityNull()
            {
                base[this.tablePurchase_Account_Form_16._15_Traders_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_16_Traders_ValueNull()
            {
                base[this.tablePurchase_Account_Form_16._16_Traders_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_17_Closing_Balance_QuantityNull()
            {
                base[this.tablePurchase_Account_Form_16._17_Closing_Balance_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_18_Closing_Balance_ValueNull()
            {
                base[this.tablePurchase_Account_Form_16._18_Closing_Balance_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_19_RemarksNull()
            {
                base[this.tablePurchase_Account_Form_16._19_RemarksColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_DateNull()
            {
                base[this.tablePurchase_Account_Form_16._2_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_Opening_Balance_QuantityNull()
            {
                base[this.tablePurchase_Account_Form_16._3_Opening_Balance_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4_Opening_Balance_ValueNull()
            {
                base[this.tablePurchase_Account_Form_16._4_Opening_Balance_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_ChallanBill_of_Entry_NoNull()
            {
                base[this.tablePurchase_Account_Form_16._5_ChallanBill_of_Entry_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6_ChallanBill_of_Entry_DateNull()
            {
                base[this.tablePurchase_Account_Form_16._6_ChallanBill_of_Entry_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7_NameNull()
            {
                base[this.tablePurchase_Account_Form_16._7_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_8_AddressNull()
            {
                base[this.tablePurchase_Account_Form_16._8_AddressColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_9_Registration_NoNull()
            {
                base[this.tablePurchase_Account_Form_16._9_Registration_NoColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Purchase_Account_Form_16RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Purchase_Account_Form_16Row eventRow;

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
            public NBR_POS_DS.Purchase_Account_Form_16Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Purchase_Account_Form_16RowChangeEvent(NBR_POS_DS.Purchase_Account_Form_16Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Purchase_Account_Form_16RowChangeEventHandler(object sender, NBR_POS_DS.Purchase_Account_Form_16RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class Sales_Account_Form_17DataTable : TypedTableBase<NBR_POS_DS.Sales_Account_Form_17Row>
        {
            private DataColumn column1_Sl_No;

            private DataColumn column2_Date;

            private DataColumn column3_Opening_Balance_Quantity;

            private DataColumn column4_Opening_Balance_Value;

            private DataColumn column5_Production_Opening_Balance_Quantity;

            private DataColumn column6_Production_Opening_Balance_Value;

            private DataColumn column7_Name;

            private DataColumn column8_Registration_No;

            private DataColumn column9_Address;

            private DataColumn column10_Challan_No;

            private DataColumn column11_Challan_DateTime;

            private DataColumn column12_Supplied_Goods_Description;

            private DataColumn column13_Supplied_Goods_Quantity;

            private DataColumn column14_Supplied_Goods_Taxable_Value;

            private DataColumn column15_Supplied_Goods_SD;

            private DataColumn column16_Supplied_Goods_VAT;

            private DataColumn column17_Closing_Balance_Quantity;

            private DataColumn column18_Closing_Balance_Value;

            private DataColumn column19_Remarks;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _1_Sl_NoColumn
            {
                get
                {
                    return this.column1_Sl_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _10_Challan_NoColumn
            {
                get
                {
                    return this.column10_Challan_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _11_Challan_DateTimeColumn
            {
                get
                {
                    return this.column11_Challan_DateTime;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _12_Supplied_Goods_DescriptionColumn
            {
                get
                {
                    return this.column12_Supplied_Goods_Description;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _13_Supplied_Goods_QuantityColumn
            {
                get
                {
                    return this.column13_Supplied_Goods_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _14_Supplied_Goods_Taxable_ValueColumn
            {
                get
                {
                    return this.column14_Supplied_Goods_Taxable_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _15_Supplied_Goods_SDColumn
            {
                get
                {
                    return this.column15_Supplied_Goods_SD;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _16_Supplied_Goods_VATColumn
            {
                get
                {
                    return this.column16_Supplied_Goods_VAT;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _17_Closing_Balance_QuantityColumn
            {
                get
                {
                    return this.column17_Closing_Balance_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _18_Closing_Balance_ValueColumn
            {
                get
                {
                    return this.column18_Closing_Balance_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _19_RemarksColumn
            {
                get
                {
                    return this.column19_Remarks;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _2_DateColumn
            {
                get
                {
                    return this.column2_Date;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _3_Opening_Balance_QuantityColumn
            {
                get
                {
                    return this.column3_Opening_Balance_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _4_Opening_Balance_ValueColumn
            {
                get
                {
                    return this.column4_Opening_Balance_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _5_Production_Opening_Balance_QuantityColumn
            {
                get
                {
                    return this.column5_Production_Opening_Balance_Quantity;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _6_Production_Opening_Balance_ValueColumn
            {
                get
                {
                    return this.column6_Production_Opening_Balance_Value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _7_NameColumn
            {
                get
                {
                    return this.column7_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _8_Registration_NoColumn
            {
                get
                {
                    return this.column8_Registration_No;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn _9_AddressColumn
            {
                get
                {
                    return this.column9_Address;
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
            public NBR_POS_DS.Sales_Account_Form_17Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.Sales_Account_Form_17Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Sales_Account_Form_17DataTable()
            {
                base.TableName = "Sales_Account_Form_17";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Sales_Account_Form_17DataTable(DataTable table)
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
            protected Sales_Account_Form_17DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddSales_Account_Form_17Row(NBR_POS_DS.Sales_Account_Form_17Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Sales_Account_Form_17Row AddSales_Account_Form_17Row(string _1_Sl_No, string _2_Date, string _3_Opening_Balance_Quantity, string _4_Opening_Balance_Value, string _5_Production_Opening_Balance_Quantity, string _6_Production_Opening_Balance_Value, string _7_Name, string _8_Registration_No, string _9_Address, string _10_Challan_No, string _11_Challan_DateTime, string _12_Supplied_Goods_Description, string _13_Supplied_Goods_Quantity, string _14_Supplied_Goods_Taxable_Value, string _15_Supplied_Goods_SD, string _16_Supplied_Goods_VAT, string _17_Closing_Balance_Quantity, string _18_Closing_Balance_Value, string _19_Remarks)
            {
                NBR_POS_DS.Sales_Account_Form_17Row salesAccountForm17Row = (NBR_POS_DS.Sales_Account_Form_17Row)base.NewRow();
                object[] _1SlNo = new object[] { _1_Sl_No, _2_Date, _3_Opening_Balance_Quantity, _4_Opening_Balance_Value, _5_Production_Opening_Balance_Quantity, _6_Production_Opening_Balance_Value, _7_Name, _8_Registration_No, _9_Address, _10_Challan_No, _11_Challan_DateTime, _12_Supplied_Goods_Description, _13_Supplied_Goods_Quantity, _14_Supplied_Goods_Taxable_Value, _15_Supplied_Goods_SD, _16_Supplied_Goods_VAT, _17_Closing_Balance_Quantity, _18_Closing_Balance_Value, _19_Remarks };
                salesAccountForm17Row.ItemArray = _1SlNo;
                base.Rows.Add(salesAccountForm17Row);
                return salesAccountForm17Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.Sales_Account_Form_17DataTable salesAccountForm17DataTable = (NBR_POS_DS.Sales_Account_Form_17DataTable)base.Clone();
                salesAccountForm17DataTable.InitVars();
                return salesAccountForm17DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.Sales_Account_Form_17DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.Sales_Account_Form_17Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "Sales_Account_Form_17DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.column1_Sl_No = new DataColumn("1_Sl_No", typeof(string), null, MappingType.Element);
                this.column1_Sl_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column1_Sl_No");
                this.column1_Sl_No.ExtendedProperties.Add("Generator_UserColumnName", "1_Sl_No");
                base.Columns.Add(this.column1_Sl_No);
                this.column2_Date = new DataColumn("2_Date", typeof(string), null, MappingType.Element);
                this.column2_Date.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column2_Date");
                this.column2_Date.ExtendedProperties.Add("Generator_UserColumnName", "2_Date");
                base.Columns.Add(this.column2_Date);
                this.column3_Opening_Balance_Quantity = new DataColumn("3_Opening_Balance_Quantity", typeof(string), null, MappingType.Element);
                this.column3_Opening_Balance_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column3_Opening_Balance_Quantity");
                this.column3_Opening_Balance_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "3_Opening_Balance_Quantity");
                base.Columns.Add(this.column3_Opening_Balance_Quantity);
                this.column4_Opening_Balance_Value = new DataColumn("4_Opening_Balance_Value", typeof(string), null, MappingType.Element);
                this.column4_Opening_Balance_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column4_Opening_Balance_Value");
                this.column4_Opening_Balance_Value.ExtendedProperties.Add("Generator_UserColumnName", "4_Opening_Balance_Value");
                base.Columns.Add(this.column4_Opening_Balance_Value);
                this.column5_Production_Opening_Balance_Quantity = new DataColumn("5_Production_Opening_Balance_Quantity", typeof(string), null, MappingType.Element);
                this.column5_Production_Opening_Balance_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column5_Production_Opening_Balance_Quantity");
                this.column5_Production_Opening_Balance_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "5_Production_Opening_Balance_Quantity");
                base.Columns.Add(this.column5_Production_Opening_Balance_Quantity);
                this.column6_Production_Opening_Balance_Value = new DataColumn("6_Production_Opening_Balance_Value", typeof(string), null, MappingType.Element);
                this.column6_Production_Opening_Balance_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column6_Production_Opening_Balance_Value");
                this.column6_Production_Opening_Balance_Value.ExtendedProperties.Add("Generator_UserColumnName", "6_Production_Opening_Balance_Value");
                base.Columns.Add(this.column6_Production_Opening_Balance_Value);
                this.column7_Name = new DataColumn("7_Name", typeof(string), null, MappingType.Element);
                this.column7_Name.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column7_Name");
                this.column7_Name.ExtendedProperties.Add("Generator_UserColumnName", "7_Name");
                base.Columns.Add(this.column7_Name);
                this.column8_Registration_No = new DataColumn("8_Registration_No", typeof(string), null, MappingType.Element);
                this.column8_Registration_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column8_Registration_No");
                this.column8_Registration_No.ExtendedProperties.Add("Generator_UserColumnName", "8_Registration_No");
                base.Columns.Add(this.column8_Registration_No);
                this.column9_Address = new DataColumn("9_Address", typeof(string), null, MappingType.Element);
                this.column9_Address.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column9_Address");
                this.column9_Address.ExtendedProperties.Add("Generator_UserColumnName", "9_Address");
                base.Columns.Add(this.column9_Address);
                this.column10_Challan_No = new DataColumn("10_Challan_No", typeof(string), null, MappingType.Element);
                this.column10_Challan_No.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column10_Challan_No");
                this.column10_Challan_No.ExtendedProperties.Add("Generator_UserColumnName", "10_Challan_No");
                base.Columns.Add(this.column10_Challan_No);
                this.column11_Challan_DateTime = new DataColumn("11_Challan_DateTime", typeof(string), null, MappingType.Element);
                this.column11_Challan_DateTime.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column11_Challan_DateTime");
                this.column11_Challan_DateTime.ExtendedProperties.Add("Generator_UserColumnName", "11_Challan_DateTime");
                base.Columns.Add(this.column11_Challan_DateTime);
                this.column12_Supplied_Goods_Description = new DataColumn("12_Supplied_Goods_Description", typeof(string), null, MappingType.Element);
                this.column12_Supplied_Goods_Description.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column12_Supplied_Goods_Description");
                this.column12_Supplied_Goods_Description.ExtendedProperties.Add("Generator_UserColumnName", "12_Supplied_Goods_Description");
                base.Columns.Add(this.column12_Supplied_Goods_Description);
                this.column13_Supplied_Goods_Quantity = new DataColumn("13_Supplied_Goods_Quantity", typeof(string), null, MappingType.Element);
                this.column13_Supplied_Goods_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column13_Supplied_Goods_Quantity");
                this.column13_Supplied_Goods_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "13_Supplied_Goods_Quantity");
                base.Columns.Add(this.column13_Supplied_Goods_Quantity);
                this.column14_Supplied_Goods_Taxable_Value = new DataColumn("14_Supplied_Goods_Taxable_Value", typeof(string), null, MappingType.Element);
                this.column14_Supplied_Goods_Taxable_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column14_Supplied_Goods_Taxable_Value");
                this.column14_Supplied_Goods_Taxable_Value.ExtendedProperties.Add("Generator_UserColumnName", "14_Supplied_Goods_Taxable_Value");
                base.Columns.Add(this.column14_Supplied_Goods_Taxable_Value);
                this.column15_Supplied_Goods_SD = new DataColumn("15_Supplied_Goods_SD", typeof(string), null, MappingType.Element);
                this.column15_Supplied_Goods_SD.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column15_Supplied_Goods_SD");
                this.column15_Supplied_Goods_SD.ExtendedProperties.Add("Generator_UserColumnName", "15_Supplied_Goods_SD");
                base.Columns.Add(this.column15_Supplied_Goods_SD);
                this.column16_Supplied_Goods_VAT = new DataColumn("16_Supplied_Goods_VAT", typeof(string), null, MappingType.Element);
                this.column16_Supplied_Goods_VAT.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column16_Supplied_Goods_VAT");
                this.column16_Supplied_Goods_VAT.ExtendedProperties.Add("Generator_UserColumnName", "16_Supplied_Goods_VAT");
                base.Columns.Add(this.column16_Supplied_Goods_VAT);
                this.column17_Closing_Balance_Quantity = new DataColumn("17_Closing_Balance_Quantity", typeof(string), null, MappingType.Element);
                this.column17_Closing_Balance_Quantity.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column17_Closing_Balance_Quantity");
                this.column17_Closing_Balance_Quantity.ExtendedProperties.Add("Generator_UserColumnName", "17_Closing_Balance_Quantity");
                base.Columns.Add(this.column17_Closing_Balance_Quantity);
                this.column18_Closing_Balance_Value = new DataColumn("18_Closing_Balance_Value", typeof(string), null, MappingType.Element);
                this.column18_Closing_Balance_Value.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column18_Closing_Balance_Value");
                this.column18_Closing_Balance_Value.ExtendedProperties.Add("Generator_UserColumnName", "18_Closing_Balance_Value");
                base.Columns.Add(this.column18_Closing_Balance_Value);
                this.column19_Remarks = new DataColumn("19_Remarks", typeof(string), null, MappingType.Element);
                this.column19_Remarks.ExtendedProperties.Add("Generator_ColumnVarNameInTable", "column19_Remarks");
                this.column19_Remarks.ExtendedProperties.Add("Generator_UserColumnName", "19_Remarks");
                base.Columns.Add(this.column19_Remarks);
                this.column5_Production_Opening_Balance_Quantity.Caption = "5_ChallanBill_of_Entry_No";
                this.column6_Production_Opening_Balance_Value.Caption = "6_ChallanBill_of_Entry_Date";
                this.column8_Registration_No.Caption = "8_Address";
                this.column9_Address.Caption = "10_Description";
                this.column10_Challan_No.Caption = "11_Quantity";
                this.column11_Challan_DateTime.Caption = "12_Value_Excluding_SD_VAT";
                this.column12_Supplied_Goods_Description.Caption = "13_SD";
                this.column13_Supplied_Goods_Quantity.Caption = "14_VAT";
                this.column14_Supplied_Goods_Taxable_Value.Caption = "15_Traders_Quantity";
                this.column15_Supplied_Goods_SD.Caption = "16_Traders_Value";
                this.column16_Supplied_Goods_VAT.Caption = "17_Closing_Balance_Quantity";
                this.column17_Closing_Balance_Quantity.Caption = "18_Closing_Balance_Value";
                this.column18_Closing_Balance_Value.Caption = "19_Remarks";
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.column1_Sl_No = base.Columns["1_Sl_No"];
                this.column2_Date = base.Columns["2_Date"];
                this.column3_Opening_Balance_Quantity = base.Columns["3_Opening_Balance_Quantity"];
                this.column4_Opening_Balance_Value = base.Columns["4_Opening_Balance_Value"];
                this.column5_Production_Opening_Balance_Quantity = base.Columns["5_Production_Opening_Balance_Quantity"];
                this.column6_Production_Opening_Balance_Value = base.Columns["6_Production_Opening_Balance_Value"];
                this.column7_Name = base.Columns["7_Name"];
                this.column8_Registration_No = base.Columns["8_Registration_No"];
                this.column9_Address = base.Columns["9_Address"];
                this.column10_Challan_No = base.Columns["10_Challan_No"];
                this.column11_Challan_DateTime = base.Columns["11_Challan_DateTime"];
                this.column12_Supplied_Goods_Description = base.Columns["12_Supplied_Goods_Description"];
                this.column13_Supplied_Goods_Quantity = base.Columns["13_Supplied_Goods_Quantity"];
                this.column14_Supplied_Goods_Taxable_Value = base.Columns["14_Supplied_Goods_Taxable_Value"];
                this.column15_Supplied_Goods_SD = base.Columns["15_Supplied_Goods_SD"];
                this.column16_Supplied_Goods_VAT = base.Columns["16_Supplied_Goods_VAT"];
                this.column17_Closing_Balance_Quantity = base.Columns["17_Closing_Balance_Quantity"];
                this.column18_Closing_Balance_Value = base.Columns["18_Closing_Balance_Value"];
                this.column19_Remarks = base.Columns["19_Remarks"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.Sales_Account_Form_17Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.Sales_Account_Form_17Row NewSales_Account_Form_17Row()
            {
                return (NBR_POS_DS.Sales_Account_Form_17Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.Sales_Account_Form_17RowChanged != null)
                {
                    this.Sales_Account_Form_17RowChanged(this, new NBR_POS_DS.Sales_Account_Form_17RowChangeEvent((NBR_POS_DS.Sales_Account_Form_17Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.Sales_Account_Form_17RowChanging != null)
                {
                    this.Sales_Account_Form_17RowChanging(this, new NBR_POS_DS.Sales_Account_Form_17RowChangeEvent((NBR_POS_DS.Sales_Account_Form_17Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.Sales_Account_Form_17RowDeleted != null)
                {
                    this.Sales_Account_Form_17RowDeleted(this, new NBR_POS_DS.Sales_Account_Form_17RowChangeEvent((NBR_POS_DS.Sales_Account_Form_17Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.Sales_Account_Form_17RowDeleting != null)
                {
                    this.Sales_Account_Form_17RowDeleting(this, new NBR_POS_DS.Sales_Account_Form_17RowChangeEvent((NBR_POS_DS.Sales_Account_Form_17Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveSales_Account_Form_17Row(NBR_POS_DS.Sales_Account_Form_17Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Sales_Account_Form_17RowChangeEventHandler Sales_Account_Form_17RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Sales_Account_Form_17RowChangeEventHandler Sales_Account_Form_17RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Sales_Account_Form_17RowChangeEventHandler Sales_Account_Form_17RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.Sales_Account_Form_17RowChangeEventHandler Sales_Account_Form_17RowDeleting;
        }

        public class Sales_Account_Form_17Row : DataRow
        {
            private NBR_POS_DS.Sales_Account_Form_17DataTable tableSales_Account_Form_17;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _1_Sl_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._1_Sl_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '1_Sl_No' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._1_Sl_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _10_Challan_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._10_Challan_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '10_Challan_No' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._10_Challan_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _11_Challan_DateTime
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._11_Challan_DateTimeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '11_Challan_DateTime' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._11_Challan_DateTimeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _12_Supplied_Goods_Description
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._12_Supplied_Goods_DescriptionColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '12_Supplied_Goods_Description' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._12_Supplied_Goods_DescriptionColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _13_Supplied_Goods_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._13_Supplied_Goods_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '13_Supplied_Goods_Quantity' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._13_Supplied_Goods_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _14_Supplied_Goods_Taxable_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._14_Supplied_Goods_Taxable_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '14_Supplied_Goods_Taxable_Value' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._14_Supplied_Goods_Taxable_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _15_Supplied_Goods_SD
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._15_Supplied_Goods_SDColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '15_Supplied_Goods_SD' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._15_Supplied_Goods_SDColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _16_Supplied_Goods_VAT
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._16_Supplied_Goods_VATColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '16_Supplied_Goods_VAT' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._16_Supplied_Goods_VATColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _17_Closing_Balance_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._17_Closing_Balance_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '17_Closing_Balance_Quantity' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._17_Closing_Balance_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _18_Closing_Balance_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._18_Closing_Balance_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '18_Closing_Balance_Value' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._18_Closing_Balance_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _19_Remarks
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._19_RemarksColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '19_Remarks' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._19_RemarksColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _2_Date
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._2_DateColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '2_Date' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._2_DateColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _3_Opening_Balance_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._3_Opening_Balance_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '3_Opening_Balance_Quantity' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._3_Opening_Balance_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _4_Opening_Balance_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._4_Opening_Balance_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '4_Opening_Balance_Value' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._4_Opening_Balance_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _5_Production_Opening_Balance_Quantity
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._5_Production_Opening_Balance_QuantityColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '5_Production_Opening_Balance_Quantity' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._5_Production_Opening_Balance_QuantityColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _6_Production_Opening_Balance_Value
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._6_Production_Opening_Balance_ValueColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '6_Production_Opening_Balance_Value' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._6_Production_Opening_Balance_ValueColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _7_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._7_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '7_Name' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._7_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _8_Registration_No
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._8_Registration_NoColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '8_Registration_No' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._8_Registration_NoColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string _9_Address
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableSales_Account_Form_17._9_AddressColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column '9_Address' in table 'Sales_Account_Form_17' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableSales_Account_Form_17._9_AddressColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal Sales_Account_Form_17Row(DataRowBuilder rb) : base(rb)
            {
                this.tableSales_Account_Form_17 = (NBR_POS_DS.Sales_Account_Form_17DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_1_Sl_NoNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._1_Sl_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_10_Challan_NoNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._10_Challan_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_11_Challan_DateTimeNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._11_Challan_DateTimeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_12_Supplied_Goods_DescriptionNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._12_Supplied_Goods_DescriptionColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_13_Supplied_Goods_QuantityNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._13_Supplied_Goods_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_14_Supplied_Goods_Taxable_ValueNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._14_Supplied_Goods_Taxable_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_15_Supplied_Goods_SDNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._15_Supplied_Goods_SDColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_16_Supplied_Goods_VATNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._16_Supplied_Goods_VATColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_17_Closing_Balance_QuantityNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._17_Closing_Balance_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_18_Closing_Balance_ValueNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._18_Closing_Balance_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_19_RemarksNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._19_RemarksColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_2_DateNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._2_DateColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_3_Opening_Balance_QuantityNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._3_Opening_Balance_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_4_Opening_Balance_ValueNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._4_Opening_Balance_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_5_Production_Opening_Balance_QuantityNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._5_Production_Opening_Balance_QuantityColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_6_Production_Opening_Balance_ValueNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._6_Production_Opening_Balance_ValueColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_7_NameNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._7_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_8_Registration_NoNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._8_Registration_NoColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Is_9_AddressNull()
            {
                return base.IsNull(this.tableSales_Account_Form_17._9_AddressColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_1_Sl_NoNull()
            {
                base[this.tableSales_Account_Form_17._1_Sl_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_10_Challan_NoNull()
            {
                base[this.tableSales_Account_Form_17._10_Challan_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_11_Challan_DateTimeNull()
            {
                base[this.tableSales_Account_Form_17._11_Challan_DateTimeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_12_Supplied_Goods_DescriptionNull()
            {
                base[this.tableSales_Account_Form_17._12_Supplied_Goods_DescriptionColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_13_Supplied_Goods_QuantityNull()
            {
                base[this.tableSales_Account_Form_17._13_Supplied_Goods_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_14_Supplied_Goods_Taxable_ValueNull()
            {
                base[this.tableSales_Account_Form_17._14_Supplied_Goods_Taxable_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_15_Supplied_Goods_SDNull()
            {
                base[this.tableSales_Account_Form_17._15_Supplied_Goods_SDColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_16_Supplied_Goods_VATNull()
            {
                base[this.tableSales_Account_Form_17._16_Supplied_Goods_VATColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_17_Closing_Balance_QuantityNull()
            {
                base[this.tableSales_Account_Form_17._17_Closing_Balance_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_18_Closing_Balance_ValueNull()
            {
                base[this.tableSales_Account_Form_17._18_Closing_Balance_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_19_RemarksNull()
            {
                base[this.tableSales_Account_Form_17._19_RemarksColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_2_DateNull()
            {
                base[this.tableSales_Account_Form_17._2_DateColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_3_Opening_Balance_QuantityNull()
            {
                base[this.tableSales_Account_Form_17._3_Opening_Balance_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_4_Opening_Balance_ValueNull()
            {
                base[this.tableSales_Account_Form_17._4_Opening_Balance_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_5_Production_Opening_Balance_QuantityNull()
            {
                base[this.tableSales_Account_Form_17._5_Production_Opening_Balance_QuantityColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_6_Production_Opening_Balance_ValueNull()
            {
                base[this.tableSales_Account_Form_17._6_Production_Opening_Balance_ValueColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_7_NameNull()
            {
                base[this.tableSales_Account_Form_17._7_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_8_Registration_NoNull()
            {
                base[this.tableSales_Account_Form_17._8_Registration_NoColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Set_9_AddressNull()
            {
                base[this.tableSales_Account_Form_17._9_AddressColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class Sales_Account_Form_17RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.Sales_Account_Form_17Row eventRow;

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
            public NBR_POS_DS.Sales_Account_Form_17Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public Sales_Account_Form_17RowChangeEvent(NBR_POS_DS.Sales_Account_Form_17Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void Sales_Account_Form_17RowChangeEventHandler(object sender, NBR_POS_DS.Sales_Account_Form_17RowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class testDataTable : TypedTableBase<NBR_POS_DS.testRow>
        {
            private DataColumn columnCountry_Name;

            private DataColumn columnCountry_Code;

            private DataColumn columnabbr_name;

            private DataColumn columntest;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn abbr_nameColumn
            {
                get
                {
                    return this.columnabbr_name;
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
            public DataColumn Country_CodeColumn
            {
                get
                {
                    return this.columnCountry_Code;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Country_NameColumn
            {
                get
                {
                    return this.columnCountry_Name;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.testRow this[int index]
            {
                get
                {
                    return (NBR_POS_DS.testRow)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn testColumn
            {
                get
                {
                    return this.columntest;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public testDataTable()
            {
                base.TableName = "test";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal testDataTable(DataTable table)
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
            protected testDataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddtestRow(NBR_POS_DS.testRow row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.testRow AddtestRow(string Country_Name, string Country_Code, string abbr_name, string test)
            {
                NBR_POS_DS.testRow _testRow = (NBR_POS_DS.testRow)base.NewRow();
                object[] countryName = new object[] { Country_Name, Country_Code, abbr_name, test };
                _testRow.ItemArray = countryName;
                base.Rows.Add(_testRow);
                return _testRow;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.testDataTable _testDataTable = (NBR_POS_DS.testDataTable)base.Clone();
                _testDataTable.InitVars();
                return _testDataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.testDataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.testRow);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "testDataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnCountry_Name = new DataColumn("Country_Name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCountry_Name);
                this.columnCountry_Code = new DataColumn("Country_Code", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnCountry_Code);
                this.columnabbr_name = new DataColumn("abbr_name", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnabbr_name);
                this.columntest = new DataColumn("test", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columntest);
                this.columnCountry_Name.DefaultValue = "Pepols Republic Of Bangladesh";
                this.columnCountry_Code.DefaultValue = "National Board Of Ravenue";
                this.columnabbr_name.DefaultValue = "Dhaka";
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnCountry_Name = base.Columns["Country_Name"];
                this.columnCountry_Code = base.Columns["Country_Code"];
                this.columnabbr_name = base.Columns["abbr_name"];
                this.columntest = base.Columns["test"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.testRow(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.testRow NewtestRow()
            {
                return (NBR_POS_DS.testRow)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.testRowChanged != null)
                {
                    this.testRowChanged(this, new NBR_POS_DS.testRowChangeEvent((NBR_POS_DS.testRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.testRowChanging != null)
                {
                    this.testRowChanging(this, new NBR_POS_DS.testRowChangeEvent((NBR_POS_DS.testRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.testRowDeleted != null)
                {
                    this.testRowDeleted(this, new NBR_POS_DS.testRowChangeEvent((NBR_POS_DS.testRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.testRowDeleting != null)
                {
                    this.testRowDeleting(this, new NBR_POS_DS.testRowChangeEvent((NBR_POS_DS.testRow)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemovetestRow(NBR_POS_DS.testRow row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.testRowChangeEventHandler testRowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.testRowChangeEventHandler testRowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.testRowChangeEventHandler testRowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.testRowChangeEventHandler testRowDeleting;
        }

        public class testRow : DataRow
        {
            private NBR_POS_DS.testDataTable tabletest;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string abbr_name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabletest.abbr_nameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'abbr_name' in table 'test' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabletest.abbr_nameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Country_Code
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabletest.Country_CodeColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Country_Code' in table 'test' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabletest.Country_CodeColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Country_Name
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabletest.Country_NameColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Country_Name' in table 'test' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabletest.Country_NameColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string test
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tabletest.testColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'test' in table 'test' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tabletest.testColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal testRow(DataRowBuilder rb) : base(rb)
            {
                this.tabletest = (NBR_POS_DS.testDataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool Isabbr_nameNull()
            {
                return base.IsNull(this.tabletest.abbr_nameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCountry_CodeNull()
            {
                return base.IsNull(this.tabletest.Country_CodeColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsCountry_NameNull()
            {
                return base.IsNull(this.tabletest.Country_NameColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IstestNull()
            {
                return base.IsNull(this.tabletest.testColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void Setabbr_nameNull()
            {
                base[this.tabletest.abbr_nameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCountry_CodeNull()
            {
                base[this.tabletest.Country_CodeColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetCountry_NameNull()
            {
                base[this.tabletest.Country_NameColumn] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SettestNull()
            {
                base[this.tabletest.testColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class testRowChangeEvent : EventArgs
        {
            private NBR_POS_DS.testRow eventRow;

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
            public NBR_POS_DS.testRow Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public testRowChangeEvent(NBR_POS_DS.testRow row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void testRowChangeEventHandler(object sender, NBR_POS_DS.testRowChangeEvent e);

        [Serializable]
        [XmlSchemaProvider("GetTypedTableSchema")]
        public class VAT_Return_Form_19DataTable : TypedTableBase<NBR_POS_DS.VAT_Return_Form_19Row>
        {
            private DataColumn columnZero_Return;

            private DataColumn columnNet_Sales_of_Taxable_Goods_Sales_Value_1;

            private DataColumn columnNet_Sales_of_Taxable_Goods_SD_1_1;

            private DataColumn columnNet_Sales_of_Taxable_Goods_VAT_1_2;

            private DataColumn columnSales_of_Zero_Rated_GoodsServices_2;

            private DataColumn columnSales_of_Exempt_GoodsServices_3;

            private DataColumn columnTotal_Tax_Payable_4;

            private DataColumn columnOther_Adjustments_5;

            private DataColumn columnPurchase_of_Taxable_GoodsServices_Purchase_Value_7;

            private DataColumn columnPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1;

            private DataColumn columnTaxable_GoodsServices_Import_Purchase_Value_8;

            private DataColumn columnTaxable_GoodsServices_Import_Rebatable_Tax_8_1;

            private DataColumn columnOther_Tax_Rebate_on_Export_Purchase_Value_9;

            private DataColumn columnOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1;

            private DataColumn columnPurchase_of_Exempt_GoodsServices_10;

            private DataColumn columnOther_Adjustments_12;

            private DataColumn columnBalance_of_Previous_Month_13;

            private DataColumn columnTreasury_Deposit_16;

            private DataColumn columnOpening_Balance_of_Next_Month_17;

            private DataColumn columnDrawback_From_the_Directorate_18;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Balance_of_Previous_Month_13Column
            {
                get
                {
                    return this.columnBalance_of_Previous_Month_13;
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
            public DataColumn Drawback_From_the_Directorate_18Column
            {
                get
                {
                    return this.columnDrawback_From_the_Directorate_18;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.VAT_Return_Form_19Row this[int index]
            {
                get
                {
                    return (NBR_POS_DS.VAT_Return_Form_19Row)base.Rows[index];
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Net_Sales_of_Taxable_Goods_Sales_Value_1Column
            {
                get
                {
                    return this.columnNet_Sales_of_Taxable_Goods_Sales_Value_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Net_Sales_of_Taxable_Goods_SD_1_1Column
            {
                get
                {
                    return this.columnNet_Sales_of_Taxable_Goods_SD_1_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Net_Sales_of_Taxable_Goods_VAT_1_2Column
            {
                get
                {
                    return this.columnNet_Sales_of_Taxable_Goods_VAT_1_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Opening_Balance_of_Next_Month_17Column
            {
                get
                {
                    return this.columnOpening_Balance_of_Next_Month_17;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Other_Adjustments_12Column
            {
                get
                {
                    return this.columnOther_Adjustments_12;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Other_Adjustments_5Column
            {
                get
                {
                    return this.columnOther_Adjustments_5;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Other_Tax_Rebate_on_Export_Purchase_Value_9Column
            {
                get
                {
                    return this.columnOther_Tax_Rebate_on_Export_Purchase_Value_9;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1Column
            {
                get
                {
                    return this.columnOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Purchase_of_Exempt_GoodsServices_10Column
            {
                get
                {
                    return this.columnPurchase_of_Exempt_GoodsServices_10;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Purchase_of_Taxable_GoodsServices_Purchase_Value_7Column
            {
                get
                {
                    return this.columnPurchase_of_Taxable_GoodsServices_Purchase_Value_7;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Column
            {
                get
                {
                    return this.columnPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sales_of_Exempt_GoodsServices_3Column
            {
                get
                {
                    return this.columnSales_of_Exempt_GoodsServices_3;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Sales_of_Zero_Rated_GoodsServices_2Column
            {
                get
                {
                    return this.columnSales_of_Zero_Rated_GoodsServices_2;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Taxable_GoodsServices_Import_Purchase_Value_8Column
            {
                get
                {
                    return this.columnTaxable_GoodsServices_Import_Purchase_Value_8;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Taxable_GoodsServices_Import_Rebatable_Tax_8_1Column
            {
                get
                {
                    return this.columnTaxable_GoodsServices_Import_Rebatable_Tax_8_1;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Total_Tax_Payable_4Column
            {
                get
                {
                    return this.columnTotal_Tax_Payable_4;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Treasury_Deposit_16Column
            {
                get
                {
                    return this.columnTreasury_Deposit_16;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public DataColumn Zero_ReturnColumn
            {
                get
                {
                    return this.columnZero_Return;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VAT_Return_Form_19DataTable()
            {
                base.TableName = "VAT_Return_Form_19";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal VAT_Return_Form_19DataTable(DataTable table)
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
            protected VAT_Return_Form_19DataTable(SerializationInfo info, StreamingContext context) : base(info, context)
            {
                this.InitVars();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void AddVAT_Return_Form_19Row(NBR_POS_DS.VAT_Return_Form_19Row row)
            {
                base.Rows.Add(row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.VAT_Return_Form_19Row AddVAT_Return_Form_19Row(string Zero_Return, string Net_Sales_of_Taxable_Goods_Sales_Value_1, string Net_Sales_of_Taxable_Goods_SD_1_1, string Net_Sales_of_Taxable_Goods_VAT_1_2, string Sales_of_Zero_Rated_GoodsServices_2, string Sales_of_Exempt_GoodsServices_3, string Total_Tax_Payable_4, string Other_Adjustments_5, string Purchase_of_Taxable_GoodsServices_Purchase_Value_7, string Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1, string Taxable_GoodsServices_Import_Purchase_Value_8, string Taxable_GoodsServices_Import_Rebatable_Tax_8_1, string Other_Tax_Rebate_on_Export_Purchase_Value_9, string Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1, string Purchase_of_Exempt_GoodsServices_10, string Other_Adjustments_12, string Balance_of_Previous_Month_13, string Treasury_Deposit_16, string Opening_Balance_of_Next_Month_17, string Drawback_From_the_Directorate_18)
            {
                NBR_POS_DS.VAT_Return_Form_19Row vATReturnForm19Row = (NBR_POS_DS.VAT_Return_Form_19Row)base.NewRow();
                object[] zeroReturn = new object[] { Zero_Return, Net_Sales_of_Taxable_Goods_Sales_Value_1, Net_Sales_of_Taxable_Goods_SD_1_1, Net_Sales_of_Taxable_Goods_VAT_1_2, Sales_of_Zero_Rated_GoodsServices_2, Sales_of_Exempt_GoodsServices_3, Total_Tax_Payable_4, Other_Adjustments_5, Purchase_of_Taxable_GoodsServices_Purchase_Value_7, Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1, Taxable_GoodsServices_Import_Purchase_Value_8, Taxable_GoodsServices_Import_Rebatable_Tax_8_1, Other_Tax_Rebate_on_Export_Purchase_Value_9, Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1, Purchase_of_Exempt_GoodsServices_10, Other_Adjustments_12, Balance_of_Previous_Month_13, Treasury_Deposit_16, Opening_Balance_of_Next_Month_17, Drawback_From_the_Directorate_18 };
                vATReturnForm19Row.ItemArray = zeroReturn;
                base.Rows.Add(vATReturnForm19Row);
                return vATReturnForm19Row;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public override DataTable Clone()
            {
                NBR_POS_DS.VAT_Return_Form_19DataTable vATReturnForm19DataTable = (NBR_POS_DS.VAT_Return_Form_19DataTable)base.Clone();
                vATReturnForm19DataTable.InitVars();
                return vATReturnForm19DataTable;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataTable CreateInstance()
            {
                return new NBR_POS_DS.VAT_Return_Form_19DataTable();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override Type GetRowType()
            {
                return typeof(NBR_POS_DS.VAT_Return_Form_19Row);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
            {
                XmlSchemaComplexType xmlSchemaComplexType;
                XmlSchema xmlSchema;
                XmlSchemaComplexType xmlSchemaComplexType1 = new XmlSchemaComplexType();
                XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
                NBR_POS_DS nBRPOSD = new NBR_POS_DS();
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
                    FixedValue = nBRPOSD.Namespace
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute);
                XmlSchemaAttribute xmlSchemaAttribute1 = new XmlSchemaAttribute()
                {
                    Name = "tableTypeName",
                    FixedValue = "VAT_Return_Form_19DataTable"
                };
                xmlSchemaComplexType1.Attributes.Add(xmlSchemaAttribute1);
                xmlSchemaComplexType1.Particle = xmlSchemaSequence;
                XmlSchema schemaSerializable = nBRPOSD.GetSchemaSerializable();
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
                this.columnZero_Return = new DataColumn("Zero_Return", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnZero_Return);
                this.columnNet_Sales_of_Taxable_Goods_Sales_Value_1 = new DataColumn("Net_Sales_of_Taxable_Goods_Sales_Value_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNet_Sales_of_Taxable_Goods_Sales_Value_1);
                this.columnNet_Sales_of_Taxable_Goods_SD_1_1 = new DataColumn("Net_Sales_of_Taxable_Goods_SD_1_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNet_Sales_of_Taxable_Goods_SD_1_1);
                this.columnNet_Sales_of_Taxable_Goods_VAT_1_2 = new DataColumn("Net_Sales_of_Taxable_Goods_VAT_1_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnNet_Sales_of_Taxable_Goods_VAT_1_2);
                this.columnSales_of_Zero_Rated_GoodsServices_2 = new DataColumn("Sales_of_Zero_Rated_GoodsServices_2", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSales_of_Zero_Rated_GoodsServices_2);
                this.columnSales_of_Exempt_GoodsServices_3 = new DataColumn("Sales_of_Exempt_GoodsServices_3", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnSales_of_Exempt_GoodsServices_3);
                this.columnTotal_Tax_Payable_4 = new DataColumn("Total_Tax_Payable_4", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTotal_Tax_Payable_4);
                this.columnOther_Adjustments_5 = new DataColumn("Other_Adjustments_5", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOther_Adjustments_5);
                this.columnPurchase_of_Taxable_GoodsServices_Purchase_Value_7 = new DataColumn("Purchase_of_Taxable_GoodsServices_Purchase_Value_7", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPurchase_of_Taxable_GoodsServices_Purchase_Value_7);
                this.columnPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1 = new DataColumn("Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1);
                this.columnTaxable_GoodsServices_Import_Purchase_Value_8 = new DataColumn("Taxable_GoodsServices_Import_Purchase_Value_8", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTaxable_GoodsServices_Import_Purchase_Value_8);
                this.columnTaxable_GoodsServices_Import_Rebatable_Tax_8_1 = new DataColumn("Taxable_GoodsServices_Import_Rebatable_Tax_8_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTaxable_GoodsServices_Import_Rebatable_Tax_8_1);
                this.columnOther_Tax_Rebate_on_Export_Purchase_Value_9 = new DataColumn("Other_Tax_Rebate_on_Export_Purchase_Value_9", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOther_Tax_Rebate_on_Export_Purchase_Value_9);
                this.columnOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1 = new DataColumn("Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1);
                this.columnPurchase_of_Exempt_GoodsServices_10 = new DataColumn("Purchase_of_Exempt_GoodsServices_10", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnPurchase_of_Exempt_GoodsServices_10);
                this.columnOther_Adjustments_12 = new DataColumn("Other_Adjustments_12", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOther_Adjustments_12);
                this.columnBalance_of_Previous_Month_13 = new DataColumn("Balance_of_Previous_Month_13", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnBalance_of_Previous_Month_13);
                this.columnTreasury_Deposit_16 = new DataColumn("Treasury_Deposit_16", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnTreasury_Deposit_16);
                this.columnOpening_Balance_of_Next_Month_17 = new DataColumn("Opening_Balance_of_Next_Month_17", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnOpening_Balance_of_Next_Month_17);
                this.columnDrawback_From_the_Directorate_18 = new DataColumn("Drawback_From_the_Directorate_18", typeof(string), null, MappingType.Element);
                base.Columns.Add(this.columnDrawback_From_the_Directorate_18);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal void InitVars()
            {
                this.columnZero_Return = base.Columns["Zero_Return"];
                this.columnNet_Sales_of_Taxable_Goods_Sales_Value_1 = base.Columns["Net_Sales_of_Taxable_Goods_Sales_Value_1"];
                this.columnNet_Sales_of_Taxable_Goods_SD_1_1 = base.Columns["Net_Sales_of_Taxable_Goods_SD_1_1"];
                this.columnNet_Sales_of_Taxable_Goods_VAT_1_2 = base.Columns["Net_Sales_of_Taxable_Goods_VAT_1_2"];
                this.columnSales_of_Zero_Rated_GoodsServices_2 = base.Columns["Sales_of_Zero_Rated_GoodsServices_2"];
                this.columnSales_of_Exempt_GoodsServices_3 = base.Columns["Sales_of_Exempt_GoodsServices_3"];
                this.columnTotal_Tax_Payable_4 = base.Columns["Total_Tax_Payable_4"];
                this.columnOther_Adjustments_5 = base.Columns["Other_Adjustments_5"];
                this.columnPurchase_of_Taxable_GoodsServices_Purchase_Value_7 = base.Columns["Purchase_of_Taxable_GoodsServices_Purchase_Value_7"];
                this.columnPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1 = base.Columns["Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1"];
                this.columnTaxable_GoodsServices_Import_Purchase_Value_8 = base.Columns["Taxable_GoodsServices_Import_Purchase_Value_8"];
                this.columnTaxable_GoodsServices_Import_Rebatable_Tax_8_1 = base.Columns["Taxable_GoodsServices_Import_Rebatable_Tax_8_1"];
                this.columnOther_Tax_Rebate_on_Export_Purchase_Value_9 = base.Columns["Other_Tax_Rebate_on_Export_Purchase_Value_9"];
                this.columnOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1 = base.Columns["Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1"];
                this.columnPurchase_of_Exempt_GoodsServices_10 = base.Columns["Purchase_of_Exempt_GoodsServices_10"];
                this.columnOther_Adjustments_12 = base.Columns["Other_Adjustments_12"];
                this.columnBalance_of_Previous_Month_13 = base.Columns["Balance_of_Previous_Month_13"];
                this.columnTreasury_Deposit_16 = base.Columns["Treasury_Deposit_16"];
                this.columnOpening_Balance_of_Next_Month_17 = base.Columns["Opening_Balance_of_Next_Month_17"];
                this.columnDrawback_From_the_Directorate_18 = base.Columns["Drawback_From_the_Directorate_18"];
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
            {
                return new NBR_POS_DS.VAT_Return_Form_19Row(builder);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public NBR_POS_DS.VAT_Return_Form_19Row NewVAT_Return_Form_19Row()
            {
                return (NBR_POS_DS.VAT_Return_Form_19Row)base.NewRow();
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanged(DataRowChangeEventArgs e)
            {
                base.OnRowChanged(e);
                if (this.VAT_Return_Form_19RowChanged != null)
                {
                    this.VAT_Return_Form_19RowChanged(this, new NBR_POS_DS.VAT_Return_Form_19RowChangeEvent((NBR_POS_DS.VAT_Return_Form_19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowChanging(DataRowChangeEventArgs e)
            {
                base.OnRowChanging(e);
                if (this.VAT_Return_Form_19RowChanging != null)
                {
                    this.VAT_Return_Form_19RowChanging(this, new NBR_POS_DS.VAT_Return_Form_19RowChangeEvent((NBR_POS_DS.VAT_Return_Form_19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleted(DataRowChangeEventArgs e)
            {
                base.OnRowDeleted(e);
                if (this.VAT_Return_Form_19RowDeleted != null)
                {
                    this.VAT_Return_Form_19RowDeleted(this, new NBR_POS_DS.VAT_Return_Form_19RowChangeEvent((NBR_POS_DS.VAT_Return_Form_19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            protected override void OnRowDeleting(DataRowChangeEventArgs e)
            {
                base.OnRowDeleting(e);
                if (this.VAT_Return_Form_19RowDeleting != null)
                {
                    this.VAT_Return_Form_19RowDeleting(this, new NBR_POS_DS.VAT_Return_Form_19RowChangeEvent((NBR_POS_DS.VAT_Return_Form_19Row)e.Row, e.Action));
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void RemoveVAT_Return_Form_19Row(NBR_POS_DS.VAT_Return_Form_19Row row)
            {
                base.Rows.Remove(row);
            }

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.VAT_Return_Form_19RowChangeEventHandler VAT_Return_Form_19RowChanged;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.VAT_Return_Form_19RowChangeEventHandler VAT_Return_Form_19RowChanging;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.VAT_Return_Form_19RowChangeEventHandler VAT_Return_Form_19RowDeleted;

            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public event NBR_POS_DS.VAT_Return_Form_19RowChangeEventHandler VAT_Return_Form_19RowDeleting;
        }

        public class VAT_Return_Form_19Row : DataRow
        {
            private NBR_POS_DS.VAT_Return_Form_19DataTable tableVAT_Return_Form_19;

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Balance_of_Previous_Month_13
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Balance_of_Previous_Month_13Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Balance_of_Previous_Month_13' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Balance_of_Previous_Month_13Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Drawback_From_the_Directorate_18
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Drawback_From_the_Directorate_18Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Drawback_From_the_Directorate_18' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Drawback_From_the_Directorate_18Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Net_Sales_of_Taxable_Goods_Sales_Value_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_Sales_Value_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Net_Sales_of_Taxable_Goods_Sales_Value_1' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_Sales_Value_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Net_Sales_of_Taxable_Goods_SD_1_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_SD_1_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Net_Sales_of_Taxable_Goods_SD_1_1' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_SD_1_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Net_Sales_of_Taxable_Goods_VAT_1_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_VAT_1_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Net_Sales_of_Taxable_Goods_VAT_1_2' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_VAT_1_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Opening_Balance_of_Next_Month_17
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Opening_Balance_of_Next_Month_17Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Opening_Balance_of_Next_Month_17' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Opening_Balance_of_Next_Month_17Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Other_Adjustments_12
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Other_Adjustments_12Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Other_Adjustments_12' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Other_Adjustments_12Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Other_Adjustments_5
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Other_Adjustments_5Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Other_Adjustments_5' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Other_Adjustments_5Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Other_Tax_Rebate_on_Export_Purchase_Value_9
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Purchase_Value_9Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Other_Tax_Rebate_on_Export_Purchase_Value_9' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Purchase_Value_9Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Purchase_of_Exempt_GoodsServices_10
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Purchase_of_Exempt_GoodsServices_10Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Purchase_of_Exempt_GoodsServices_10' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Purchase_of_Exempt_GoodsServices_10Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Purchase_of_Taxable_GoodsServices_Purchase_Value_7
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Purchase_Value_7Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Purchase_of_Taxable_GoodsServices_Purchase_Value_7' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Purchase_Value_7Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sales_of_Exempt_GoodsServices_3
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Sales_of_Exempt_GoodsServices_3Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sales_of_Exempt_GoodsServices_3' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Sales_of_Exempt_GoodsServices_3Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Sales_of_Zero_Rated_GoodsServices_2
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Sales_of_Zero_Rated_GoodsServices_2Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Sales_of_Zero_Rated_GoodsServices_2' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Sales_of_Zero_Rated_GoodsServices_2Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Taxable_GoodsServices_Import_Purchase_Value_8
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Purchase_Value_8Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Taxable_GoodsServices_Import_Purchase_Value_8' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Purchase_Value_8Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Taxable_GoodsServices_Import_Rebatable_Tax_8_1
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Rebatable_Tax_8_1Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Taxable_GoodsServices_Import_Rebatable_Tax_8_1' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Rebatable_Tax_8_1Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Total_Tax_Payable_4
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Total_Tax_Payable_4Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Total_Tax_Payable_4' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Total_Tax_Payable_4Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Treasury_Deposit_16
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Treasury_Deposit_16Column];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Treasury_Deposit_16' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Treasury_Deposit_16Column] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public string Zero_Return
            {
                get
                {
                    string item;
                    try
                    {
                        item = (string)base[this.tableVAT_Return_Form_19.Zero_ReturnColumn];
                    }
                    catch (InvalidCastException invalidCastException)
                    {
                        throw new StrongTypingException("The value for column 'Zero_Return' in table 'VAT_Return_Form_19' is DBNull.", invalidCastException);
                    }
                    return item;
                }
                set
                {
                    base[this.tableVAT_Return_Form_19.Zero_ReturnColumn] = value;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            internal VAT_Return_Form_19Row(DataRowBuilder rb) : base(rb)
            {
                this.tableVAT_Return_Form_19 = (NBR_POS_DS.VAT_Return_Form_19DataTable)base.Table;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsBalance_of_Previous_Month_13Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Balance_of_Previous_Month_13Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsDrawback_From_the_Directorate_18Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Drawback_From_the_Directorate_18Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNet_Sales_of_Taxable_Goods_Sales_Value_1Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_Sales_Value_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNet_Sales_of_Taxable_Goods_SD_1_1Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_SD_1_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsNet_Sales_of_Taxable_Goods_VAT_1_2Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_VAT_1_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOpening_Balance_of_Next_Month_17Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Opening_Balance_of_Next_Month_17Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOther_Adjustments_12Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Other_Adjustments_12Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOther_Adjustments_5Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Other_Adjustments_5Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOther_Tax_Rebate_on_Export_Purchase_Value_9Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Purchase_Value_9Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPurchase_of_Exempt_GoodsServices_10Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Purchase_of_Exempt_GoodsServices_10Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPurchase_of_Taxable_GoodsServices_Purchase_Value_7Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Purchase_Value_7Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSales_of_Exempt_GoodsServices_3Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Sales_of_Exempt_GoodsServices_3Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsSales_of_Zero_Rated_GoodsServices_2Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Sales_of_Zero_Rated_GoodsServices_2Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTaxable_GoodsServices_Import_Purchase_Value_8Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Purchase_Value_8Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTaxable_GoodsServices_Import_Rebatable_Tax_8_1Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Rebatable_Tax_8_1Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTotal_Tax_Payable_4Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Total_Tax_Payable_4Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsTreasury_Deposit_16Null()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Treasury_Deposit_16Column);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public bool IsZero_ReturnNull()
            {
                return base.IsNull(this.tableVAT_Return_Form_19.Zero_ReturnColumn);
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetBalance_of_Previous_Month_13Null()
            {
                base[this.tableVAT_Return_Form_19.Balance_of_Previous_Month_13Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetDrawback_From_the_Directorate_18Null()
            {
                base[this.tableVAT_Return_Form_19.Drawback_From_the_Directorate_18Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNet_Sales_of_Taxable_Goods_Sales_Value_1Null()
            {
                base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_Sales_Value_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNet_Sales_of_Taxable_Goods_SD_1_1Null()
            {
                base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_SD_1_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetNet_Sales_of_Taxable_Goods_VAT_1_2Null()
            {
                base[this.tableVAT_Return_Form_19.Net_Sales_of_Taxable_Goods_VAT_1_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOpening_Balance_of_Next_Month_17Null()
            {
                base[this.tableVAT_Return_Form_19.Opening_Balance_of_Next_Month_17Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOther_Adjustments_12Null()
            {
                base[this.tableVAT_Return_Form_19.Other_Adjustments_12Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOther_Adjustments_5Null()
            {
                base[this.tableVAT_Return_Form_19.Other_Adjustments_5Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOther_Tax_Rebate_on_Export_Purchase_Value_9Null()
            {
                base[this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Purchase_Value_9Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetOther_Tax_Rebate_on_Export_Rebatable_Tax_9_1Null()
            {
                base[this.tableVAT_Return_Form_19.Other_Tax_Rebate_on_Export_Rebatable_Tax_9_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPurchase_of_Exempt_GoodsServices_10Null()
            {
                base[this.tableVAT_Return_Form_19.Purchase_of_Exempt_GoodsServices_10Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPurchase_of_Taxable_GoodsServices_Purchase_Value_7Null()
            {
                base[this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Purchase_Value_7Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetPurchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Null()
            {
                base[this.tableVAT_Return_Form_19.Purchase_of_Taxable_GoodsServices_Rebatable_Tax_7_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSales_of_Exempt_GoodsServices_3Null()
            {
                base[this.tableVAT_Return_Form_19.Sales_of_Exempt_GoodsServices_3Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetSales_of_Zero_Rated_GoodsServices_2Null()
            {
                base[this.tableVAT_Return_Form_19.Sales_of_Zero_Rated_GoodsServices_2Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTaxable_GoodsServices_Import_Purchase_Value_8Null()
            {
                base[this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Purchase_Value_8Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTaxable_GoodsServices_Import_Rebatable_Tax_8_1Null()
            {
                base[this.tableVAT_Return_Form_19.Taxable_GoodsServices_Import_Rebatable_Tax_8_1Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTotal_Tax_Payable_4Null()
            {
                base[this.tableVAT_Return_Form_19.Total_Tax_Payable_4Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetTreasury_Deposit_16Null()
            {
                base[this.tableVAT_Return_Form_19.Treasury_Deposit_16Column] = Convert.DBNull;
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public void SetZero_ReturnNull()
            {
                base[this.tableVAT_Return_Form_19.Zero_ReturnColumn] = Convert.DBNull;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public class VAT_Return_Form_19RowChangeEvent : EventArgs
        {
            private NBR_POS_DS.VAT_Return_Form_19Row eventRow;

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
            public NBR_POS_DS.VAT_Return_Form_19Row Row
            {
                get
                {
                    return this.eventRow;
                }
            }

            [DebuggerNonUserCode]
            [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
            public VAT_Return_Form_19RowChangeEvent(NBR_POS_DS.VAT_Return_Form_19Row row, DataRowAction action)
            {
                this.eventRow = row;
                this.eventAction = action;
            }
        }

        [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        public delegate void VAT_Return_Form_19RowChangeEventHandler(object sender, NBR_POS_DS.VAT_Return_Form_19RowChangeEvent e);
    }
}

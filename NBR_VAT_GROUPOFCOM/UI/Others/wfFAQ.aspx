<%@ page language="C#" title="KGCVAT FAQ" masterpagefile="~/DashboardVTR.Master" autoeventwireup="true" inherits="wfFAQ, App_Web_0aej32q1" %>

<%@ Register Src="~/UserControls/MsgBox.ascx" TagName="MsgBox" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="../../Styles/bootstrap/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container-fluid">
        <h2>Summery & Details Report of this application Functions</h2>
        <div class="panel panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">কিভাবে সিস্টেমে লগইন করবেন?</a>
                    </h4>
                </div>
                <div id="collapse1" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>•	ব্যবহারকারী প্রথমে KGCVAT প্রোডাক্টি তাদের কম্পিউটারে ইনস্টল করবেন।</p>
                       <p>•	ইনস্টল শেষে ডেক্সটপ থেকে “Welcome To NBR POS” লিখা আইকনে ক্লিক করবেন।</p>
                        <img src="../../Images/UM/ds_vp.jpg" alt="Desktop Shortcut Image Here" width="100%"/>
                        <p>• “Welcome To NBR POS” লিখা আইকনে ক্লিক করার পর নিম্নোক্ত পেজটি ওপেন হবেঃ</p>
                        <img src="../../Images/UM/login.jpg" alt="Login Image Here" width="100%"/>
                        <p>• এখানে “User Name” এবং “Password” দিয়ে সিস্টেমে লগইন করতে হবে।</p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">কিভাবে ব্যাংক সেটআপ করবেন?</a>
                    </h4>
                </div>
                <div id="collapse2" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>“Bank” সেটআপের জন্যে ব্যবহারকারীকে “Control Panel” মেন্যুর সাব মেন্যু “Financial Setup” এর “Bank” এ ক্লিক করতে হবে। </p>
                       <p>•	“Bank” এ ক্লিক করার পর নিম্নোক্ত পেজটি আসবেঃ</p>
                        <img src="../../Images/Purchase_Return.png" />
                        <p>• প্রয়োজনীয় তথ্যাদি দিয়ে “Save” বাটনে ক্লিক করুন।</p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">কিভাবে ব্যাংক ব্রাঞ্চ সেট করবেন?</a>
                    </h4>
                </div>
                <div id="collapse3" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• “Bank Branch” সেটআপের জন্যে ব্যবহারকারীকে “Control Panel” মেন্যুর সাব মেন্যু “Financial Setup” এর “Bank Branch” এ ক্লিক করতে হবে। </p>
                       <p>•	“Bank Branch” এ ক্লিক করার পর নিম্নোক্ত পেজটি আসবেঃ</p>
                        <img src="../../Images/UM/bank_branch.jpg" alt="Bank Branch Image Here" width="100%" />
                        <p>• প্রয়োজনীয় তথ্যাদি দিয়ে “Save” বাটনে ক্লিক করুন।</p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">কিভাবে অর্গানাইজেশন সেট করবেন?</a>
                    </h4>
                </div>
                <div id="collapse4" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>•	“Organization” সেটআপ করার জন্যে “Operation Setup” এর “মুল্য সংযোজন কর নিবন্ধন ও টার্নওভার কর তালিকাভুক্তির আবেদনপত্র” তে ক্লিক করতে হবে।</p>
                       <p>•	“মুল্য সংযোজন কর নিবন্ধন ও টার্নওভার কর তালিকাভুক্তির আবেদনপত্র” তে ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/UM/org_setup.jpg" alt="Organization Setup Image Here" width="100%" />
                        <p><b>Form Fillup এর প্রসেস গুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>  <b>১.</b> E-TIN,BIN,Organization Name এ ডাটা অ্যাড করার পর,<br> 
                             <b>২.</b> Present Address(Red * ঘর গুলো অবশ্যই Fillup করতে হবে),<br> 
                             <b>৩.</b> Permanent Address(Red * ঘর গুলো অবশ্যই Fillup করতে হবে),<br>
                             <b>৪.</b> Registration Type(অবশ্যই Select করতে হবে),<br> 
                             <b>৫.</b> Yearly Turnover (যদি না থাকে তবে Amount এর ঘরে ০ এবং InWord এর ঘরে NA দিতে হবে),<br> 
                             <b>৬.</b> Registration Date(অবশ্যই Date Add হবে),<br>
                             <b>৭.</b> Type of Business(একের অধিক Check করতে পারেন / না থাকলে Check করার দরকার নাই),<br> 
                             <b>৮.</b> Other Tax Collection(একের অধিক Check করতে পারেন / না থাকলে Check করার দরকার নাই),<br> 
                             <b>৯.</b> Vat Deducted at Source(যদি Yes Check করেন তাহলে Check Box অবশ্যই চেক করতে হবে),<br>
                            <b>১০.</b> Nature of Application(একের অধিক Check করতে পারেন / না থাকলে Check করার দরকার নাই),<br> 
                            <b>১১.</b> Business Process Activities(একের অধিক Check করতে পারেন / না থাকলে Check করার দরকার নাই),<br>
                            <b>১২.</b> Economic Process Activities(একের অধিক Check করতে পারেন / না থাকলে Check করার দরকার নাই),<br>
                            <b>১৩.</b> Circle(অবশ্যই Select করতে হবে),<br>
                            <b>১৪.</b> Nature of Application & Branch Unit Address(ব্রাঞ্চ না থাকলে অথবা ব্রাঞ্চ সেট করতে না চাইলে No Branch বাটন এ ক্লিক করুন। এরপর Save Button শো করলে, সেভ বাটন এ ক্লিক করে First Part সেভ করুন।),<br>
                            <b>১৫.</b> Bank Information(যদি না থাকে তাহলে Avoid করুন ),<br>
                            <b>১৬.</b> Owner Type(যদি না থাকে তাহলে Avoid করুন।  কিন্তু যদি থাকে তবে অ্যাড করুন। একের অধিক Owner Type Add করতে পারবেন।),<br>
                            <b>১৭.</b> Declaration(অবশ্যই Select করতে হবে। এবং Save Button এ ক্লিক করে Second Part সেভ করুন এবং Organization Setup Complete করুন )<br>
                        </p>
                        
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">কিভাবে ইউজার সেট করবেন?</a>
                    </h4>
                </div>
                <div id="collapse5" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Control Panel -> User / Basic Setup -> User Setup</p>
                       <p>• User Setup এর জন্যে “User Setup” এ ক্লিক করতে হবে।</p>
                       <p>•	“User Setup” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/UM/user.jpg" alt="User Setup Image Here" width="100%" />
                        <p>• উপরোক্ত ফর্মের সবগুলো ফিল্ড পূরণ করে Save করতে হবে।</p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse6">কিভাবে ইউজার আপডেট  করবেন?</a>
                    </h4>
                </div>
                <div id="collapse6" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Control Panel -> User / Basic Setup -> User Setup</p>
                       <p>• User Setup এর জন্যে “User Setup” এ ক্লিক করতে হবে।</p>
                       <p>•	“User Setup” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/UM/user.jpg" alt="User Setup Image Here" width="100%" />
                        <p>• উপরোক্ত ফর্মের সবগুলো ফিল্ড পূরণ করে Save করতে হবে।</p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse7">কিভাবে স্থানীয় ক্রয় (Local Purchase) এর কাজ করবেন?</a>
                    </h4>
                </div>
                <div id="collapse7" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Purchase -> ক্রয় চালানপত্র </p>
                       <p>• Local Purchase এর জন্যে “ক্রয় চালানপত্র” এ ক্লিক করতে হবে।</p>
                       <p>•	“ক্রয় চালানপত্র” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/UM/localpurchase.jpg" alt="Local Purchase Image Here" width="100%" />
                        <p><b>Form Fillup এর প্রসেস গুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                            <b>১.</b> Organization Branch Name (যদি থাকে তাহলে Drop-down List থেকে তা Select করুন এবং ব্রাঞ্চ নাম সিলেক্টের সাথে সাথেই ব্রাঞ্চের বিন নাম্বার ও ঠিকানা অটো চলে আসবে)।<br />

                            <b>২.</b> Supplier Name (অবশ্যই Select করতে হবে এবং Supplier Name Select এর সাথে সাথেই Supplier Address ও supplier BIN Number অটো চলে আসবে; আর যদি নতুন কোন Supplier অ্যাড করতে হয় সেক্ষেত্রে Supplier Name এর পাশে NEW নামে একটা বাটন আছে, ঐটাতে ক্লিক করে নতুন Supplier Add করা যাবে )।<br />

                            <b>৩.</b> Ref. Challan No (অবশ্যই দিতে হবে)।<br />

                            <b>৪.</b> Agreement No (অবশ্যই দিতে হবে)।<br />

                            <b>৫.</b> Transaction Type (Select Transaction Type)<br />

                            <b>৬.</b> Purchase Type (Select Purchase Type)<br />

                            <b>৭.</b> যদি কোনো পণ্য ক্রয় করা হয় তাহলে Goods Select করতে হবে এবং সার্ভিস ক্রয়ের জন্ত Service Select করতে হবে।<br />

                            <b>৮.</b> Receive Scroll No (অবশ্যই দিতে হবে)।<br />

                            <b>৯.</b> Vehicle Type (যদি থাকে তাহলে তা Select করতে হবে এবং Vehicle No ও দিতে হবে)।<br />

                            <b>১০.</b> Bank Name (ব্যাংকের নাম সিলেক্ট করতে হবে)।<br />

                            <b>১১.</b> Bank Branch (সিলেক্টকৃত ব্যাংকের ব্রাঞ্চ সিলেক্ট করতে হবে)।<br />

                            <b>১২.</b> Ultimate Destination (যদি থাকে তা লিখতে হবে)।<br />

                            <b>১৩.</b> Remarks (কোনো মন্তব্য থাকলে তা লিখতে হবে)।<br />

                            <b>১৪.</b> যেসব পণ্য ক্রয় করতে চান তা manually input দিতে চাইলে Manual Input নামের radio button এ ক্লিক করুন এবং পণ্যটির যদি VDS তাহকে সেক্ষেত্রে VDS নামের radio button select করুন আর রেয়াতপ্রাপ্ত হলে Rebate নামের radio button এ ক্লিক করুন । তারপর একটা একটা করে পণ্য add করুন।<br />

                            <b>১৫.</b> আর তৈরিকৃত কোনো এক্সেল শিট থেকে যদি পণ্যগুলো লোড করতে চান তাহলে Import from Excel নামের radio button এ ক্লিক করুন।<br />

                            <b>১৬.</b> যদি কোনো voucher number থাকে তাহলে Add by Voucher No নামের radio button এ ক্লিক করে ভাউচারের মাধ্যমে পণ্য add করুন।<br />

                            <b>১৭.</b> Add Payment (এইবাটনে ক্লিক করে পেমেন্ট করুন)<br />

                            <b>১৮.</b> Save button এক্লিক করে ডাটা সংরক্ষণ করুন।
                        </p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse8">কিভাবে আমদানি চালানপত্রের (Bill of Entry) এর কাজ করবেন?</a>
                    </h4>
                </div>
                <div id="collapse8" class="panel-collapse collapse">
                    <div class="panel-body">
                    <p><b>• Purchase/Production/Sales -> Purchase -> আমদানি চালানপত্র</b></p>
                       <p>• আমদানি চালানপত্র এর জন্যে “আমদানি চালানপত্র” এ ক্লিক করতে হবে।</p>
                       <p>•	“আমদানি চালানপত্র” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/UM/billofentry.jpg" alt="আমদানি চালানপত্র Image Here" width="100%" />
                        <p><b>Form Fillup এর প্রসেস গুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                            <b>১.</b> Organization Branch Name (যদি থাকে তাহলে Drop-down List থেকে তা Select করুন এবং ব্রাঞ্চ নাম সিলেক্টের সাথে সাথেই ব্রাঞ্চের বিন নাম্বার ও ঠিকানা অটো চলে আসবে)।<br />

                            <b>২.</b> Ref. Challan No (অবশ্যই দিতে হবে)।<br />

                            <b>৩.</b> Bill of Entry No (অবশ্যই দিতে হবে)।<br />

                            <b>৪.</b> Port Code (অবশ্যই সিলেক্ট করতে হবে)।<br />

                            <b>৫.</b> Port From (অবশ্যই লিখতে হবে)।<br />

                            <b>৬.</b>Port To (অবশ্যই লিখতে হবে)।<br />

                            <b>৭.</b> LC No (অবশ্যই দিতে হবে)।<br />

                            <b>৮.</b> LC Date (অবশ্যই দিতে হবে)।<br />

                            <b>৯.</b> LC Amount (অবশ্যই দিতে হবে)।<br />

                            <b>১০.</b> LC Value and Currency (অবশ্যই দিতে হবে)।<br />

                            <b>১১.</b> Bank (ব্যাংকের নাম সিলেক্ট করতে হবে)।<br />

                            <b>১২.</b> Branch (সিলেক্টকৃত ব্যাংকের ব্রাঞ্চ সিলেক্ট করতে হবে)।<br />

                            <b>১৩.</b> Insurance No (অবশ্যই দিতে হবে)।<br />

                            <b>১৪.</b> Insurance Amount (অবশ্যই দিতে হবে)।<br />

                            <b>১৫.</b> Shipment Date and Time (অবশ্যই দিতে হবে)।<br />

                            <b>১৬.</b> Delivery Date and Time (অবশ্যই দিতে হবে)।<br />

                            <b>১৭.</b> Release Order No (অবশ্যই দিতে হবে)।<br />

                            <b>১৮.</b> Registration Order Date (অবশ্যই দিতে হবে)।<br />

                            <b>১৯.</b> Supplier Name (অবশ্যই Select করতে হবে এবং Supplier Name Select এর সাথে সাথেই Supplier Address, Supplier BIN Number ও Supplier Ultimate Destination অটো চলে আসবে; আর যদি নতুন কোন Supplier অ্যাড করতে হয় সেক্ষেত্রে Supplier Name এর পাশে NEW নামে একটা বাটন আছে, ঐটাতে ক্লিক করে নতুন Supplier Add করা যাবে )।<br />

                            <b>২০.</b> Supplier Country (অবশ্যই দিতে হবে)।<br />

                            <b>২১.</b> Tax Pay Date (অবশ্যই দিতে হবে)।<br />

                            <b>২২.</b> Remarks (কোনো মন্তব্য থাকলে তা লিখতে হবে)।<br />

                            <b>২৩.</b> যেসব পণ্য ক্রয় করতে চান তা manually input দিতে চাইলে Manual Input নামের radio button এ ক্লিক করুন এবং  রেয়াতপ্রাপ্ত হলে Rebate নামের check box এ ক্লিক করুন । তারপর একটা একটা করে পণ্য add করুন।<br />

                            <b>২৪.</b> আর তৈরিকৃত কোনো এক্সেল শিট থেকে যদি পণ্যগুলো লোড করতে চান তাহলে Import from Excel নামের radio button এ ক্লিক করুন।<br />

                            <b>২৫.</b> Add Payment (এইবাটনে ক্লিক করে পেমেন্ট করুন)<br />

                            <b>২৬.</b> Save button এক্লিক করে ডাটা সংরক্ষণ করুন।
                        </p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse9">কিভাবে বিক্রয় চালানপত্র (Local Sale/Export) মূসক-৬.৩ এর কাজ করবেন?</a>
                    </h4>
                </div>
                <div id="collapse9" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Sale -> বিক্রয় চালানপত্র (মূসক-৬.৩)</p>
                       <p>• Local Sale/Export এর জন্যে “বিক্রয় চালানপত্র (মূসক-৬.৩)” এ ক্লিক করতে হবে।</p>
                       <p>•	“বিক্রয় চালানপত্র (মূসক-৬.৩)” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <%--<img src="../../Images/UM/salechallan.jpg" alt="Sale Challan Image Here" width="100%" />--%>
                         <p><b>Form Fillup এর প্রসেস গুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                            <b>১.</b> Organization Branch Name (যদি থাকে তাহলে Drop-down List থেকে তা Select করুন এবং ব্রাঞ্চ নাম সিলেক্টের সাথে সাথেই ব্রাঞ্চের বিন নাম্বার ও ঠিকানা অটো চলে আসবে)।<br />
                            
                            <b>২.</b> Customer Name (অবশ্যই Select করতে হবে এবং Customer Name Select এর সাথে সাথেই Customer Address ও Customer BIN Number অটো চলে আসবে; আর যদি নতুন কোন Customer অ্যাড করতে হয় সেক্ষেত্রে Customer Name এর পাশে NEW নামে একটা বাটন আছে, ঐটাতে ক্লিক করে নতুন Customer Add করা যাবে )।<br />
                            
                            <b>৩.</b> DO/Challan No অটো আসবে। যদি না আসে তবে প্রথমে বিক্রয় চালান মূসক-৬.৩ আর জন্য চালান বুক তৈরী করতে হবে। (Control Panel -> Challan Book Setup)<br />
                             
                            <b>৪.</b> Service Charge (যদি থাকে তবে (%) আকারে দিতে হবে। যেমন: যদি ১০% হয় তবে শুধু ১০ লিখতে হবে। না থাকলে Text Box ফাঁকা থাকবে। )।<br />

                            <b>৫.</b> Ultimate Dest (মালামাল কোথায় Delivery হবে সেই জায়গার নাম দিতে হবে। )<br />

                            <b>৬.</b> Sale Type (Select Sale Type)<br />

                            <b>৭.</b> Transaction Type (Local বিক্রয়ের ক্ষেত্রে Local সিলেক্ট করুন। Goods/Service রপ্তানির ক্ষেত্রে Export সিলেক্ট করুন।)<br />

                            <b>৮.</b> যদি পণ্য বিক্রয় করা হয় তবে Goods সিলেক্ট করতে হবে R যদি সেবা বিক্রয় করা হয় Service সিলেক্ট করতে হবে <br />

                            <b>৯.</b> Vehicle Type (যদি থাকে তাহলে তা Select করতে হবে এবং Vehicle No ও দিতে হবে)।<br />

                            <b>১০.</b> Transaction Type যদি Export সিলেক্ট করা হয় তবে (Export Date,Export Bill No,Bank,Branch) এই ৪ টি ফিল্ড অবশ্যই পূরণ করতে হবে।  <br />

                            <b>১১.</b> Instalment (পণ্য বা সেবা যদি Instalment এ বিক্রয় করা হয় তবে কয়টি Instalment এ টাকা দেওয়া হবে তার সংখ্যা এখানে উল্লেখ করতে হবে।)।<br />

                            <b>১২.</b> Discount (যদি থাকে তা লিখতে হবে)।<br />

                            <b>১৩.</b> Agreement No (ক্রেতার সাথে যদি কোনো চুক্তি থাকে তবে সেই চুক্তির নম্বর এখানে দিতে হবে।)।<br />

                            <b>১৪.</b> যেসব পণ্য ক্রয় করতে চান তা manually input দিতে চাইলে Manual Input নামের radio button এ ক্লিক করুন এবং পণ্যটির যদি VDS তাহকে সেক্ষেত্রে VDS নামের radio button select করুন আর রেয়াতপ্রাপ্ত হলে Rebate নামের radio button এ ক্লিক করুন । তারপর একটা একটা করে পণ্য add করুন।<br />

                            <b>১৫.</b> আর তৈরিকৃত কোনো এক্সেল শিট থেকে যদি পণ্যগুলো লোড করতে চান তাহলে Import from Excel নামের radio button এ ক্লিক করুন।<br />

                            <b>১৬.</b> Add Button Click করার মাধ্যমে একাধিক পণ্য List এ Add করা যাবে। <br />

                            <b>১৭.</b> Add Payment (এইবাটনে ক্লিক করে পেমেন্ট করুন)<br />

                            <b>১৮.</b> Save button এ ক্লিক করে ডাটা সংরক্ষণ করুন।<br />

                            <b>১৯.</b> ডাটা সেভ হওয়ার পর পেজ এর নিছে তিনটি বাটন পাবেন। Cash Memo, Custom CashMemo and Challan<br />

                            <b>২০.</b> Challan Button এ ক্লিক করলে বিক্রয় চালান মূসক-৬.৩ প্রিন্ট হবে। এ ক্ষত্রে কোনো প্রিন্ট প্রিভিউ দেখাবে না।<br />
                        </p>
                    </div>
                </div>
            </div>
            <%--<div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">কিভাবে কাঁচামালের চাহিদা পত্র (Raw Material Requisition) তৈরী করবেন?</a>
                    </h4>
                </div>
                <div id="collapse10" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Production -> Raw Material Requisition (কাঁচামালের চাহিদা পত্র)</p>
                       <p>• Raw Material Requisition এর জন্যে “Raw Material Requisition (কাঁচামালের চাহিদা পত্র)” এ ক্লিক করতে হবে।</p>
                       <p>•	“Raw Material Requisition (কাঁচামালের চাহিদা পত্র)” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/UM/raw_material_req.jpg" alt="Sale Challan Image Here" width="100%" />
                         <p><b>Form Fillup এর প্রসেস গুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                           <b>১.</b> যে পণ্যটি উৎপাদনের জন্য চাহিদাপত্র তৈরী করা হচ্ছে প্রথমে সেই পণ্যটি এন্ট্রি করে নিতে হবে। বিঃ দ্রঃ যদি পূর্বেই এন্ট্রি করা থাকে তবে পুনরায় এন্ট্রি করার দরকার নেই। <br />

                           <b>২.</b> উৎপাদিত পণ্যটির উপকরণ/উৎপাদ সম্পর্ক বা সহগ মূল্যভিত্তি ঘোষনাপত্র (মূসক-১) এন্ট্রি করতে হবে। বিঃ দ্রঃ যদি পূর্বেই এন্ট্রি করা থাকে তবে পুনরায় এন্ট্রি করার দরকার নেই। <br />

                           <b>৩.</b> Branch Name (যে ব্রাঞ্চ এর কাছ থেকে কাঁচামাল গ্রহণ করবেন সেই ব্রাঞ্চ সিলেক্ট করুন।) <br />
                            
                           <b>৪.</b> Requisition No (এখানে কাঁচামালের চাহিদাপত্রের নাম্বার দিতে হবে।)।<br />
                            
                            <b>৫.</b> Requisition Date (এখানে কাঁচামালের চাহিদাপত্র তৈরির তারিখ দিতে হবে।)<br />
                             
                            <b>৬.</b> Quantity (কয়টি পণ্য উৎপাদনের জন্য চাহিদাপত্র তৈরী করা হচ্ছে তার পরিমান এইখানে দিতে হবে।)।<br />

                            <b>৭.</b> Finish Product (যে পণ্যটি উৎপাদনের জন্য চাহিদাপত্র তৈরী করা হচ্ছে তার নাম এইখান থেকে সিলেক্ট করতে হবে।)<br>
                                        পণ্যটি সিলেক্ট করার সাথে সাথে যে যে Raw Materials লাগবে তা Data Grid এ Show করবে। <br />

                            <b>৮.</b> কোনো Item যদি Data Grid থেকে Remove করার দরকার হয়, তাহলে Data Grid এর Delete Icon এ ক্লিক করে আইটেম Remove করা যাবে।  <br />

                            <b>৯.</b> কোনো Item যদি Data Grid এ Add করার দরকার হয়, তাহলে (Item Name এ item সিলেক্ট করতে হবে,Quantity তে Item Quantity Add করতে হবে, 
                            Requisitor Name এর ঘরে your name দিতে হবে) fillup করে Add Item Button ক্লিক করে Data Grid এ Item Add করা যাবে।<br />

                            <b>১০.</b> Save Button এ ক্লিক করে Data সেভ করতে হবে  এবং Data Save হলে রিপোর্ট শো হবে। <br />
                        </p>
                    </div>
                </div>
            </div>--%>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse11">উৎপাদনের জন্য পণ্য প্রেরণ করার কাজের প্রক্রিয়া</a>
                    </h4>
                </div>
                <div id="collapse11" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Production -> সত্ত্বাধিকারীর সরবরাহস্থল হইতে উৎপাদনের জন্য প্রেরিত উপকরণ এর চালানপত্র (মূসক-৬.৪(প্রেরণ))</p>
                       <p>• উৎপাদনের জন্য পণ্য প্রেরণ এর জন্যে “সত্ত্বাধিকারীর সরবরাহস্থল হইতে উৎপাদনের জন্য প্রেরিত উপকরণ এর চালানপত্র (মূসক-৬.৪(প্রেরণ))” এ ক্লিক করতে হবে।</p>
                       <p>•	“সত্ত্বাধিকারীর সরবরাহস্থল হইতে উৎপাদনের জন্য প্রেরিত উপকরণ এর চালানপত্র (মূসক-৬.৪(প্রেরণ))” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/Purchase_Return.png" alt="Sale Challan Image Here"/>
                         <p><b>Form Fillup এর প্রসেসগুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                           <b>১.</b> Org. Branch Name (পণ্য উৎপাদনের জন্য কাঁচামাল যে ব্রাঞ্চ থেকে সরবরাহ করা হবে সেই ব্রাঞ্চ এখান থেকে সিলেক্ট করতে হবে।)<br />

                           <b>২.</b> Party Name (যে পার্টি অথবা ফ্যাক্টরি কে পণ্য উৎপাদনের জন্য নিয়োগ দেওয়া হবে, এখন থেকে সেই পার্টি অথবা ফ্যাক্টরি সিলেক্ট করতে হবে। যদি পার্টি অথবা ফ্যাক্টরি Dropdown List এ পাওয়া না যায় তবে "Control Panel->User / Basic Setup->Party/Client Setup" এ গিয়ে পার্টি অথবা ফ্যাক্টরি ADD করতে হবে। অথবা New Button এ ক্লিক করে নতুন পার্টি/ফ্যাক্টরি ADD করতে হবে।) <br />

                           <b>৩.</b> Challan No (অটো আসবে।  যদি না আসে তবে "Control Panel -> User / Basic Setup -> Challan Book Setup" এ গিয়ে Challan Book ADD করতে হবে। ) <br />
                            
                           <b>৪.</b> Challan Date (এখানে Challan Date & Time সেট করতে হবে। )<br />
                            
                           <b>৫.</b> Delivery Date  (এখানে Delivery Date & Time সেট করতে হবে।)<br />
                             
                           <b>৬.</b> Vehicle Type (কাঁচামাল যে যানবাহনের মাধ্যমে পাঠানো হবে তা এখানে সিলেক্ট করতে হবে।)।<br />

                           <b>৭.</b> Vehicle No (যদি Vehicle Type সিলেক্ট করা হয় তবে Vehicle No অবশ্যই দিতে হবে।)<br />

                           <b>৮.</b> Finish Product(Pr) (যে Product টি উৎপাদনের জন্য কাঁচামাল পাঠানো হচ্ছে সেই Product টি এখান থেকে সিলেক্ট করতে হবে। )<br />

                           <b>৯.</b> Product Quantity (কতগুলো বা কতটুকু উৎপাদন করতে হবে তার পরিমান এখানে লিখতে হবে।)<br />

                           <b>১০.</b> Price Decl. No (পণ্যটি উৎপাদন করার জন্য যে Price Dclaration করা হয়েছে তা এখানে সিলেক্ট করতে হবে।)<br />

                           <b>১১.</b> Show Ingredience Button (সবগুলো ফিল্ড পূর্ণ করার পর Show Ingredience Button এ ক্লিক করলে Product Quantity এর ঘরে যে পরিমাণ দেওয়া হয়েছে তার পরিমান হিসাব করে কাঁচামালগুলো Quantity সহ Grid এ শো করবে।)<br />

                           <b>১২.</b> নতুন কোনো কাঁচামাল Grid এ যোগ করতে চাইলে (Category,Sub-Cat,Product,Item Name,HS Code,Quantity) পূর্ণ করার পর Add Item Button এ ক্লিক করে ADD করতে হবে। <br />

                           <b>১৩.</b>Grid এর কাঁচামাল গুলো এবং তাদের পরিমাণ ঠিক আছে কিনা দেখে Save Button এ ক্লিক করে ডাটা সেভ করতে হবে। ডাটা Save হলে নিচে রিপোর্ট Show করবে। <br />
                        </p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse12">উৎপাদিত পণ্য কিভাবে গ্রহণ করবেন?</a>
                    </h4>
                </div>
                <div id="collapse12" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Production -> সত্ত্বাধিকারীর সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ (মূসক-৬.৪(গ্রহণ))</p>
                       <p>• উৎপাদিত পণ্য গ্রহণের জন্য “সত্ত্বাধিকারীর সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ (মূসক-৬.৪(গ্রহণ))” এ ক্লিক করতে হবে।</p>
                       <p>•	“সত্ত্বাধিকারীর সরবরাহ স্থল থেকে উৎপাদিত পণ্য গ্রহণ (মূসক-৬.৪(গ্রহণ))” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/Purchase_Return.png" alt="Sale Challan Image Here"/>
                         <p><b>Form Fillup এর প্রসেসগুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                           <b>১.</b> Org. Branch Name (উৎপাদিত পণ্যগুলো যে ব্রাঞ্চ গ্রহণ করবে, সেই ব্রাঞ্চ এখান থেকে সিলেক্ট করতে হবে।)<br />

                           <b>২.</b> Party Name (যে পার্টি অথবা ফ্যাক্টরি কে পণ্য উৎপাদনের জন্য নিয়োগ দেওয়া হয়েছিল, এখান থেকে সেই পার্টি অথবা ফ্যাক্টরি সিলেক্ট করতে হবে।) <br />

                           <b>৩.</b> Received Challan No (যে চালান নম্বর এ পণ্যগুলো গ্রহণ করা হয়েছে সেই চালান নম্বর এখানে লিখতে হবে।) <br />
                            
                           <b>৪.</b> Challan Date (যে Received Challan No এ উৎপাদিত পণ্য গ্রহণ করা হয়েছে সেই Challan No এর Date & Time এখানে লিখতে হবে। )<br />
                            
                           <b>৫.</b> Provided Challan No (যে চালানের মাধ্যমে কাঁচামাল সরবরাহ করা হয়েছিল সেই চালান নম্বর এখান থেকে সিলেক্ট করতে হবে।)<br />

                           <b>৬.</b> নতুন কোনো কাঁচামাল Grid এ যোগ করতে চাইলে (Category,Sub-Cat,Product,Item Name,HS Code,Quantity) পূর্ণ করার পর Add Item Button এ ক্লিক করে ADD করতে হবে। <br />

                           <b>৭.</b>Grid এর কাঁচামাল গুলো এবং তাদের পরিমাণ ঠিক আছে কিনা দেখে Save Button এ ক্লিক করে ডাটা সেভ করতে হবে। ডাটা Save হলে নিচে রিপোর্ট Show করবে। <br />
                        </p>
                    </div>
                </div>
            </div>
           <%-- <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse13">অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিস্পত্তির কাজ কিভাবে করবেন?</a>
                    </h4>
                </div>
                <div id="collapse13" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Others -> অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি(মূসক-২৬)</p>
                       <p>• অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি “অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি(মূসক-২৬)” এ ক্লিক করতে হবে।</p>
                       <p>•	“অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি(মূসক-২৬)” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/Purchase_Return.png" alt="Sale Challan Image Here"/>
                         <p><b>Form Fillup এর প্রসেসগুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                           <b>১.</b> Phone (অর্গানাইজেশনের ফোন নম্বর লিখতে হবে)<br />

                           <b>২.</b> Business Activity (অর্গানাইজেশনের ব্যবসার ধরণ কি তা লিখতে হবে।) <br />

                           <b>৩.</b> Challan No (অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি Challan No লিখতে হবে।) <br />
                            
                           <b>৪.</b> Challan Date (অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তির Date & Time এখানে লিখতে হবে। )<br />
                            
                           <b>৫.</b> Purchase Challan No (ক্রয়কৃত যে চালানের অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তি করতে হবে সেই চালান নম্বর সিলেক্ট করতে হবে। )<br />

                           <b>৬.</b> Item Name (Purchase Challan No সিলেক্ট করলে ওই চালানে যেসব পণ্য ক্রয় করা হয়েছে সেই পণ্যগুলো এখানে Dropdown List এ শো করবে। ) <br />
                                      অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তির পণ্যটি সিলেক্ট করতে হবে। <br />

                           <b>৭.</b>Dispose Quantity (Dispose এর পরিমান উল্ল্যেখ করতে হবে।) <br />

                           <b>৮.</b>Present Unit Price (পণ্যটির বর্তমান মূল্য দিতে হবে।) <br />

                           <b>৯.</b>Disposal Reason (অব্যবহৃত বা ব্যবহার অনুপযোগী উপকরণ নিষ্পত্তির কারণ সিলেক্ট করতে হবে।) <br />

                           <b>১০.</b>Remarks (যদি কোনো মন্তব্য থাকে তা এ ঘরে উল্ল্যেখ করতে হবে।) <br />

                           <b>১১.</b>Add Item Button এ ক্লিক করে প্রথমে আইটেমগুলো গ্রিড এ Add করতে হবে। আইটেম Add করা শেষ হলে Dispose Button এ Click করে ডাটা Save করতে হবে।<br />

                        </p>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse14">ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির কাজ কিভাবে করবেন?</a>
                    </h4>
                </div>
                <div id="collapse14" class="panel-collapse collapse">
                    <div class="panel-body">
                       <p>• Purchase/Production/Sales -> Others -> ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির আবেদনপত্র (মূসক-২৭)</p>
                       <p>• ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তি “ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির আবেদনপত্র (মূসক-২৭)” এ ক্লিক করতে হবে।</p>
                       <p>•	“ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির আবেদনপত্র (মূসক-২৭)” এ ক্লিক করার পর নিম্নোক্ত পেজটা আসবেঃ</p>
                        <img src="../../Images/Purchase_Return.png" alt="Sale Challan Image Here"/>
                         <p><b>Form Fillup এর প্রসেসগুলো নিম্মে দেওয়া হলোঃ</b></p>
                        <p>
                           <b>১.</b> Phone (অর্গানাইজেশনের ফোন নম্বর লিখতে হবে)<br />

                           <b>২.</b> Business Activity (অর্গানাইজেশনের ব্যবসার ধরণ কি তা লিখতে হবে।) <br />

                           <b>৩.</b> Challan No (ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির Challan No লিখতে হবে।) <br />
                            
                           <b>৪.</b> Challan Date (ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির Date & Time এখানে লিখতে হবে। )<br />
                            
                           <b>৫.</b> Purchase Challan No (ক্রয়কৃত যে চালানের ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তি করতে হবে সেই চালান নম্বর সিলেক্ট করতে হবে। )<br />

                           <b>৬.</b> Item Name (Purchase Challan No সিলেক্ট করলে ওই চালানে যেসব পণ্য ক্রয় করা হয়েছে সেই পণ্যগুলো এখানে Dropdown List এ শো করবে। ) <br />
                                      ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্যটি সিলেক্ট করতে হবে। <br />

                           <b>৭.</b>Dispose Quantity (Damage এর পরিমান উল্ল্যেখ করতে হবে।) <br />

                           <b>৮.</b>Present Unit Price (পণ্যটির বর্তমান মূল্য দিতে হবে।) <br />

                           <b>৯.</b>Disposal Reason (ক্ষতিগ্রস্ত বা ধ্বংসপ্রাপ্ত বা সরবরাহের অযোগ্য পণ্য নিষ্পত্তির কারণ সিলেক্ট করতে হবে।) <br />

                           <b>১০.</b>Remarks (যদি কোনো মন্তব্য থাকে তা এ ঘরে উল্ল্যেখ করতে হবে।) <br />

                           <b>১১.</b>Add Item Button এ ক্লিক করে প্রথমে আইটেমগুলো গ্রিড এ Add করতে হবে। আইটেম Add করা শেষ হলে Dispose Button এ Click করে ডাটা Save করতে হবে।<br />

                        </p>
                    </div>
                </div>
            </div>--%>
        </div>
    </div>
</asp:Content>

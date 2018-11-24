using System;
using System.Globalization;

namespace SchMod.Models.StdFees
{
    public class PayMod
    {
        public PayMod()
        {
            MerchantLogin = "197";
            MerchantPass = "Test@123";
            TransactionType = "NBFundTransfer";
            ProductID = "NSE";
            TransactionID = "123";
            TransactionAmount = "100.00";
            TransactionCurrency = "INR";
            BankID = "";
            ClientCode = "001";
            CustomerAccountNo = "123456789";
            TransactionServiceCharge = "0";
            // MerchantDiscretionaryData = "";
            TransactionDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.CreateSpecificCulture("en-GB"));  //   DD/MM/YYYY HH:MM:SS 
            ru = "http://localhost:55469/api/Receipts/PayReceipt";
            reqHashKey = "KEY123657234";
            signature = "";
            surcharge = "";
            udf1 = "";
            udf2 = "";
            udf3 = "";
            udf5 = "";
            udf6 = "";
            udf7 = "";
            udf8 = "";
            udf9 = "";

            Auth_code = "";
            Bank_name = "";
            Bank_txn = "";
            CardNumber = "";
            Desc = "";
            Discriminator = "";
            f_code = "";
            mer_txn = "";
            mmp_txn = "";
        }

        public string MerchantLogin { get; set; }
        public string MerchantPass { get; set; }
        public string TransactionType { get; set; }
        public string ProductID { get; set; }
        public string TransactionID { get; set; }
        public string TransactionAmount { get; set; }
        public string TransactionCurrency { get; set; }
        public string BankID { get; set; }
        public string ClientCode { get; set; }
        public string CustomerAccountNo { get; set; }
        public string TransactionServiceCharge { get; set; }
        //public string MerchantDiscretionaryData  { get; set; }
        public string TransactionDateTime { get; set; } //   DD/MM/YYYY HH:MM:SS 
        public string ru { get; set; }
        public string reqHashKey { get; set; }
        public string signature { get; set; }
        public string surcharge { get; set; }
        public string udf1 { get; set; }
        public string udf2 { get; set; }
        public string udf3 { get; set; }
        public string udf4 { get; set; }
        public string udf5 { get; set; }
        public string udf6 { get; set; }
        public string udf7 { get; set; }
        public string udf8 { get; set; }
        public string udf9 { get; set; }

        public string Auth_code { get; set; }
        public string Bank_name { get; set; }
        public string Bank_txn { get; set; }
        public string CardNumber { get; set; }
        public string Desc { get; set; }
        public string Discriminator { get; set; }
        public string f_code { get; set; }
        public string mer_txn { get; set; }
        public string mmp_txn { get; set; }
    }
}

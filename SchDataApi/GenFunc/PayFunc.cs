using Microsoft.AspNetCore.Http;
using SchMod.ViewModels.StdFees;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;


namespace SchDataApi.GenFunc
{
    public static class PayFunc
    {
        private static HttpContext httpContext;

        public static void InititiatePayment(Receipt receipt)
        {
            LaunchPayment();
        }

        public static void LaunchPayment()
        {
            string TransURL = TransferFund();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // comparable to modern browsers
            //httpContext.Response.Redirect(TransURL, false);
            using (HttpClient client = new HttpClient())
            {
                //client.BaseAddress = new Uri(GloVar.iBaseURI);
                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                HttpResponseMessage response = client.GetAsync(TransURL).Result;
                var stringData = response.Content.ReadAsStringAsync().Result;
                //return Json(new { result = data, count = count });
            }
            //return RedirectToAction(nameof(Payment));
        }
        public static string TransferFund()
        //string MerchantLogin, string MerchantPass, string MerchantDiscretionaryData, string ProductID, 
        //string ClientCode, string CustomerAccountNo, string TransactionType, string TransactionAmount, 
        //string TransactionCurrency, string TransactionServiceCharge, string TransactionID, 
        //string TransactionDateTime, string BankID)
        {
            string strURL, strClientCode, strClientCodeEncoded;
            byte[] b;
            //string strResponse = "";
            strURL = "https://paynetzuat.atomtech.in/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]" +
            //strURL = "/paynetz/epi/fts?login=[MerchantLogin]pass=[MerchantPass]" +
                "ttype=[TransactionType]prodid=[ProductID]amt=[TransactionAmount]txncurr=[TransactionCurrency]" +
                "txnscamt=[TransactionServiceCharge]clientcode=[ClientCode]txnid=[TransactionID]" +
                "date=[TransactionDateTime]custacc=[CustomerAccountNo]" +
                "udf1=bobsmith&udf2=ABCD&ru=[ru]signature=[signature]";
            string MerchantLogin = "197";
            string MerchantPass = "Test@123";
            string TransactionType = "NBFundTransfer";
            string ProductID = "NSE";
            string TransactionID = "123";
            string TransactionAmount = "100.00";
            string TransactionCurrency = "INR";
            string BankID = "";
            string ClientCode = "001";
            string CustomerAccountNo = "123456789";
            string TransactionServiceCharge = "0";
            //string MerchantDiscretionaryData = "";
            string TransactionDateTime =  DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.CreateSpecificCulture("en-GB"));  //   DD/MM/YYYY HH:MM:SS 
            string ru = "http://http://localhost:55469/api/Receipts";
        //string fru = "http://localhost:258252/Pages/FundTransferFailed.aspx";
            try
            {
                b = Encoding.UTF8.GetBytes(ClientCode);
                strClientCode = Convert.ToBase64String(b);
                strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);
                //strURL = "" + ConfigurationManager.AppSettings["TransferURL"].ToString();///
                strURL = strURL.Replace("[MerchantLogin]", MerchantLogin + "&");
                strURL = strURL.Replace("[MerchantPass]", MerchantPass + "&");
                strURL = strURL.Replace("[TransactionType]", TransactionType + "&");
                strURL = strURL.Replace("[ProductID]", ProductID + "&");
                strURL = strURL.Replace("[TransactionAmount]", TransactionAmount + "&");
                strURL = strURL.Replace("[TransactionCurrency]", TransactionCurrency + "&");
                strURL = strURL.Replace("[TransactionServiceCharge]", TransactionServiceCharge + "&");
                strURL = strURL.Replace("[ClientCode]", strClientCodeEncoded + "&");
                strURL = strURL.Replace("[TransactionID]", TransactionID + "&");
                strURL = strURL.Replace("[TransactionDateTime]", TransactionDateTime + "&");
                strURL = strURL.Replace("[CustomerAccountNo]", CustomerAccountNo + "&");
                //strURL = strURL.Replace("[MerchantDiscretionaryData]", MerchantDiscretionaryData + "&");
                //strURL = strURL.Replace("[BankID]", BankID + "&");
                strURL = strURL.Replace("[ru]", ru + "&");// Remove on Production

                //  string reqHashKey = requestkey;
                string reqHashKey = "KEY123657234";
                string signature = "";
                string strsignature = MerchantLogin + MerchantPass + TransactionType + ProductID + TransactionID + TransactionAmount + TransactionCurrency;
                byte[] bytes = Encoding.UTF8.GetBytes(reqHashKey);
                byte[] bt = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
                // byte[] b = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(prodid));
                signature = byteToHexString(bt).ToLower();
                //ExceptionLogger.LogExceptionDetails(null, "[Log]" + signature); //Handle before Exception
                strURL = strURL.Replace("[signature]", signature);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12; // comparable to modern browsers
                 return strURL;
                //HttpContext..Redirect(strURL, false);
            }
            catch (Exception ex)
            {
                //ExceptionLogger.LogExceptionDetails(ex, null);
                throw ex;
            }
        }

        public static string byteToHexString(byte[] byData)
        {
            StringBuilder sb = new StringBuilder((byData.Length * 2));
            for (int i = 0; (i < byData.Length); i++)
            {
                int v = (byData[i] & 255);
                if ((v < 16))
                {
                    sb.Append('0');
                }
                sb.Append(v.ToString("X"));
            }
            return sb.ToString();
        }

        //public static void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!IsPostBack)
        //        {
        //            NameValueCollection nvc = Request.Form;

        //            if (Request.Params["mmp_txn"] != null)
        //            {
        //                string postingmmp_txn = Request.Params["mmp_txn"].ToString();
        //                int postingmer_txn = Convert.ToInt32(Request.Params["mer_txn"]);
        //                string postinamount = Request.Params["amt"].ToString();
        //                string postingprod = Request.Params["prod"].ToString();
        //                string postingdate = Request.Params["date"].ToString();
        //                string postingbank_txn = Request.Params["bank_txn"].ToString();
        //                string postingf_code = Request.Params["f_code"].ToString();
        //                string postingbank_name = Request.Params["bank_name"].ToString();
        //                string signature = Request.Params["signature"].ToString();
        //                string postingdiscriminator = Request.Params["discriminator"].ToString();

        //                string respHashKey = "KEYRESP123657234";
        //                string ressignature = "";
        //                string strsignature = postingmmp_txn + postingmer_txn + postingf_code + postingprod + postingdiscriminator + postinamount + postingbank_txn;
        //                byte[] bytes = Encoding.UTF8.GetBytes(respHashKey);
        //                byte[] b = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
        //                ressignature = byteToHexString(b).ToLower();

        //                if (signature == ressignature)
        //                {
        //                    lblStatus.Text = "Signature matched...";

        //                }
        //                else
        //                {
        //                    lblStatus.Text = "Signature Mismatched...";
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //}



        //public static void Page_Load(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (!IsPostBack)
        //        {
        //            NameValueCollection nvc = Request.Form;

        //            if (Request.Params["mmp_txn"] != null)
        //            {
        //                string postingmmp_txn = Request.Params["mmp_txn"].ToString();
        //                int postingmer_txn = Convert.ToInt32(Request.Params["mer_txn"]);
        //                string postinamount = Request.Params["amt"].ToString();
        //                string postingprod = Request.Params["prod"].ToString();
        //                string postingdate = Request.Params["date"].ToString();
        //                string postingbank_txn = Request.Params["bank_txn"].ToString();
        //                string postingf_code = Request.Params["f_code"].ToString();
        //                string postingbank_name = Request.Params["bank_name"].ToString();
        //                string signature = Request.Params["signature"].ToString();
        //                string postingdiscriminator = Request.Params["discriminator"].ToString();

        //                string respHashKey = "KEYRESP123657234";
        //                string ressignature = "";
        //                string strsignature = postingmmp_txn + postingmer_txn + postingf_code + postingprod + postingdiscriminator + postinamount + postingbank_txn;
        //                byte[] bytes = Encoding.UTF8.GetBytes(respHashKey);
        //                byte[] b = new System.Security.Cryptography.HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
        //                ressignature = byteToHexString(b).ToLower();

        //                if (signature == ressignature)
        //                {
        //                    lblStatus.Text = "Signature matched...";

        //                }
        //                else
        //                {
        //                    lblStatus.Text = "Signature Mismatched...";
        //                }
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //}


    }
}

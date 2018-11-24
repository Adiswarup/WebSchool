using Microsoft.AspNetCore.Http;
using SchMod.Models.StdFees;
using SchMod.ViewModels.StdFees;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;


namespace WebCat7.GenFunction
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
            PayMod payMod = new PayMod();
            string TransURL = TransferFund(payMod);
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
        public static string TransferFund(PayMod payMod)
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
                "udf1=[udf1]&udf2=[udf2]&udf3=[udf3]&udf4=[udf4]&udf5=[udf5]&udf6=[udf6]&udf7=[udf7]&udf8=[udf8]&udf9=[udf9]&ru=[ru]signature=[signature]";
            string MerchantLogin = payMod.MerchantLogin;
            string MerchantPass = payMod.MerchantPass;
            string TransactionType = payMod.TransactionType;
            string ProductID = payMod.ProductID;
            string TransactionID = payMod.TransactionID;
            string TransactionAmount = payMod.TransactionAmount;
            string TransactionCurrency =payMod.TransactionCurrency;
            string BankID =payMod.BankID;
            string ClientCode = payMod.ClientCode;
            string CustomerAccountNo = payMod.CustomerAccountNo;
            string TransactionServiceCharge = payMod.TransactionServiceCharge;
            //string MerchantDiscretionaryData = "";
            string TransactionDateTime = payMod.TransactionDateTime; // DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss", CultureInfo.CreateSpecificCulture("en-GB"));  //   DD/MM/YYYY HH:MM:SS 
            string ru = payMod.ru;  // "http://localhost:55469/api/Receipts/PayReceipt";
            //string fru = payMod.fru; // "http://localhost:258252/Pages/FundTransferFailed.aspx";
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
                strURL = strURL.Replace("[udf1]", payMod.udf1);
                strURL = strURL.Replace("[udf2]", payMod.udf2);
                strURL = strURL.Replace("[udf3]", payMod.udf3);
                strURL = strURL.Replace("[udf4]", payMod.udf4);
                strURL = strURL.Replace("[udf5]", payMod.udf5);
                strURL = strURL.Replace("[udf6]", payMod.udf6);
                strURL = strURL.Replace("[udf7]", payMod.udf7);
                strURL = strURL.Replace("[udf8]", payMod.udf8);
                strURL = strURL.Replace("[udf9]", payMod.udf9);
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

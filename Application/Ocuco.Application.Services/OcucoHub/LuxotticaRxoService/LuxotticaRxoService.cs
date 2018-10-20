using Microsoft.Extensions.Logging;
using Ocuco.Application.Services.OcucoHub.LuxotticaRxoService.Dtos;
using Ocuco.DataModel.Hydradb.Entities;
using Ocuco.Domain.Persistence.Repositories.Rxo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ocuco.Application.Services.OcucoHub.LuxotticaRxoService
{
    public class LuxotticaRxoService : ILuxotticaRxoService
    {
        //
        // Abstract more... decouple repos
        // 

        private readonly IRxoRepository rxoRepository;
        private readonly ILogger<LuxotticaRxoService> logger;
        private RxoWSConfigData configRxoWs;

        public LuxotticaRxoService(ILogger<LuxotticaRxoService> logger,
                                   IRxoRepository rxoRepository)
        {
            this.logger = logger;
            this.rxoRepository = rxoRepository;            

            // Configure settings for Luxottica Rxo WS, temporary, move this code outside...

            configRxoWs = new RxoWSConfigData();

            configRxoWs.Address = "https://certi-my.luxottica.com:443/Stores-WS/RXOServiceImplService";
            configRxoWs.BasicAuth = true;
            configRxoWs.BasicAuthUsername = "B2BSalmoiraghi";
            configRxoWs.BasicAuthPassword = "Luxottica910";

            configRxoWs.ORIGIN_NAME = "BLUDATA";
        }


        public RxoBaseResponseEntity CallCheckFrame(RxoCheckFrameRequest modelCheckFrame)
        {
            int iReturnFromResponse = 0;
            string soapResult = "";

            RxoBaseResponseEntity responseCheckFrame = new RxoBaseResponseEntity();            

            HttpWebRequest request = CreateWebRequest(configRxoWs);

            XmlDocument soapEnvelopeXml = new XmlDocument();

            string stringRequest = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:rxo=""http://rxo.webservices.luxottica.it/"">
                                        <soapenv:Header/>
                                        <soapenv:Body>
                                          <rxo:rxoCheckFrame>
                                            <arg0>{0}</arg0>
                                            <arg1>{1}</arg1>
                                          </rxo:rxoCheckFrame>
                                        </soapenv:Body>
                                      </soapenv:Envelope>";

            stringRequest = String.Format(stringRequest, modelCheckFrame.Kunnr, modelCheckFrame.Upc);

            soapEnvelopeXml.LoadXml(stringRequest);

            //
            // Logging
            //
            //if (_iLoggingLevel > (int)LoggingLevelEnums.None)
            //{
            //    ExceptionLoggingService.Instance.WriteRXOWSLog("HTTPClient.InvokeRXOCheckFrame", "rxoCheckFrame Request", soapEnvelopeXml.InnerXml.ToString());
            //}

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);

                        //
                        // Logging
                        //
                        //if (_iLoggingLevel > (int)LoggingLevelEnums.None)
                        //{
                        //    ExceptionLoggingService.Instance.WriteRXOWSLog("HTTPClient.InvokeRXOCheckFrame", "rxoCheckFrame Response", soapResult);
                        //}

                        //
                        // Now parse the response
                        //
                        string strResponseCode = null;
                        XDocument doc = XDocument.Parse(soapResult);
                        XNamespace ns = "http://rxo.webservices.luxottica.it/";
                        IEnumerable<XElement> responses = doc.Descendants(ns + "rxoCheckFrameResponse");
                        foreach (XElement _element in responses)
                        {
                            strResponseCode = (string)_element.Element("return");
                        }

                        if (strResponseCode != null)
                        {
                            iReturnFromResponse = 500;
                            Int32.TryParse(strResponseCode, out iReturnFromResponse);                            
                        }
                        else
                            iReturnFromResponse = 501;
                    }
                }
            }
            catch (WebException webex)
            {
                if (webex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = webex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                        iReturnFromResponse = (int)response.StatusCode;
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else
                {
                    // no http status code available
                }
            }
            catch (Exception ex)
            {
                iReturnFromResponse = 501;
            }

            responseCheckFrame.WebService = @"https://certi-my.luxottica.com:443/Stores-WS/RXOServiceImplService";
            responseCheckFrame.ErrorCode = iReturnFromResponse;
            responseCheckFrame.ErrorDescription = DecodeResponseCodes(iReturnFromResponse);

            // Auditing

            RxoWsAuditing recordAudit = new RxoWsAuditing() {
                DoorNumber = modelCheckFrame.Kunnr,
                EventName = "CheckFrame",
                EventDescription = "Request to Luxottica Rxo WebService",
                EventDate = DateTime.Now,
                EventStatus = iReturnFromResponse.ToString(),
                EventRequest = stringRequest,
                EventResponse = soapResult
            };

            rxoRepository.AddEntity(recordAudit);

            if (!rxoRepository.SaveAll())
            {
                // ...some logging...
            }

            return responseCheckFrame;
        }

        public RxoBaseResponseEntity CallCheckOrder(RxoCheckOrderRequest modelCheckOrder)
        {
            int iReturnFromResponse = 0;
            string soapResult = "";


            ////////////////////////////////////
            //
            // ...config stuff
            //
            ////////////////////////////////////

            modelCheckOrder.ORIGIN_NAME = configRxoWs.ORIGIN_NAME;


            ////////////////////////////////////
            //
            // create the service response
            //
            ////////////////////////////////////
            
            RxoBaseResponseEntity responseCheckOrder = new RxoBaseResponseEntity();


            ////////////////////////////////////
            //
            // Prepare the SOAP Request
            //
            ////////////////////////////////////

            HttpWebRequest request = CreateWebRequest(configRxoWs);


            ////////////////////////////////////
            //
            // Prepare the SOAP Request
            //
            ////////////////////////////////////

            string stringRequest = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:rxo=""http://rxo.webservices.luxottica.it/""  xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                        <soapenv:Header/>
                                        <soapenv:Body>
                                           <rxo:rxoCheckOrder>
                                              <arg0 id=""{0}"">
                                                 <HEADER>	
                                                 <ORIGIN>
                                                    <NAME>{1}</NAME>
                                                 </ORIGIN>
                                                 <DATE_REQUESTED>{2}</DATE_REQUESTED>
                                                 <ACCOUNT class=""orderBy"">
                                                 <ACCOUNT_ID>{3}</ACCOUNT_ID>
                                                 </ACCOUNT>
                                                 <ACCOUNT class=""shipTo"">
                                                 <ACCOUNT_ID>{3}</ACCOUNT_ID>
                                                 </ACCOUNT>
                                                 <ACCOUNT class=""billTo"">
                                                 <ACCOUNT_ID>{3}</ACCOUNT_ID>
                                                 </ACCOUNT>
                                                 <PATIENT>
                                                 <FIRST_NAME>{4}</FIRST_NAME>
                                                 <LAST_NAME>{4}</LAST_NAME>
                                                 </PATIENT>
                                                 </HEADER> 
         
                                                 <LENS eye=""R"">
                                                    <SALES_ARTICLE>{5}</SALES_ARTICLE>
                                                    <SPHERE>{6}</SPHERE>
                                                    <CYLINDER>{7}</CYLINDER>
                                                    <AXIS>{8}</AXIS>
                                                    <PD>
                                                       <DISTANCE>{9}</DISTANCE>
                                                    </PD>
                                                    <ADD>{10}</ADD>
                                                    <SEG_HEIGHT xsi:nil=""true"">{11}</SEG_HEIGHT>
                                                    <OC_HEIGHT class=""Height"">{12}</OC_HEIGHT>
                                                    <OPC></OPC>
                                                 </LENS>

                                                 <LENS eye=""L"">
                                                    <SALES_ARTICLE>{5}</SALES_ARTICLE>
                                                    <SPHERE>{13}</SPHERE>
                                                    <CYLINDER>{14}</CYLINDER>
                                                    <AXIS>{15}</AXIS>
                                                    <PD>
                                                       <DISTANCE>{16}</DISTANCE>
                                                    </PD>
                                                    <ADD>{17}</ADD>
                                                    <SEG_HEIGHT xsi:nil=""true"">{18}</SEG_HEIGHT>
                                                    <OC_HEIGHT class=""Height"">{19}</OC_HEIGHT>
                                                    <OPC/>
                                                 </LENS>

                                                 <ITEMS>
                                                    <FRAME>
                                                       <UPC>{20}</UPC>
                                                       <DBL>{21}</DBL>
                                                    </FRAME>
                                                 </ITEMS>
                                              </arg0>
                                           </rxo:rxoCheckOrder>
                                        </soapenv:Body>
                                     </soapenv:Envelope>";


            stringRequest = stringRequest.Replace("{0}", modelCheckOrder.arg0);

            XDocument baseRequest = XDocument.Parse(stringRequest);

            //
            // Update <HEADER><ORIGIN><NAME>
            //
            IEnumerable<XElement> TagORIGIN = baseRequest.Descendants("ORIGIN");
            foreach (XElement _element in TagORIGIN)
            {
                if (_element.Name.LocalName == "ORIGIN")
                {
                    _element.Element("NAME").Value = modelCheckOrder.ORIGIN_NAME;
                }
            }

            //
            // Update <HEADER><DATE_REQUESTED>
            //
            IEnumerable<XElement> TagDATE_REQUESTED = baseRequest.Descendants("HEADER");
            foreach (XElement _element in TagDATE_REQUESTED)
            {
                if (_element.Name.LocalName == "HEADER")
                {
                    _element.Element("DATE_REQUESTED").Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }

            //
            // Update <HEADER><ORIGIN><ACCOUNT>
            //
            IEnumerable<XElement> TagACCOUNT = baseRequest.Descendants("ACCOUNT");
            foreach (XElement _element in TagACCOUNT)
            {
                if (_element.Name.LocalName == "ACCOUNT")
                {
                    _element.Element("ACCOUNT_ID").Value = modelCheckOrder.ACCOUNT;
                }
            }

            //
            // Update <HEADER><ORIGIN><PATIENT>
            //
            IEnumerable<XElement> TagPATIENT = baseRequest.Descendants("PATIENT");
            foreach (XElement _element in TagPATIENT)
            {
                if (_element.Name.LocalName == "PATIENT")
                {
                    _element.Element("FIRST_NAME").Value = modelCheckOrder.PATIENT_FIRST_NAME;
                    _element.Element("LAST_NAME").Value = modelCheckOrder.PATIENT_LAST_NAME;
                }
            }

            //
            // Update <LENS ...>
            //
            IEnumerable<XElement> TagLENSR = baseRequest.Descendants("LENS");
            foreach (XElement _element in TagLENSR)
            {
                if (_element.Name.LocalName == "LENS")
                {
                    _element.Element("SALES_ARTICLE").Value = modelCheckOrder.LENS_SALES_ARTICLE;
                }

                if (_element.Name.LocalName == "LENS" && _element.FirstAttribute.Value == "R")
                {
                    _element.Element("SPHERE").Value = modelCheckOrder.LENS_R_SPHERE;
                    _element.Element("CYLINDER").Value = modelCheckOrder.LENS_R_CYLINDER;
                    _element.Element("AXIS").Value = modelCheckOrder.LENS_R_AXIS;

                    XElement subPD = _element.Element("PD");
                    subPD.Element("DISTANCE").Value = modelCheckOrder.LENS_R_DISTANCE;

                    if (modelCheckOrder.LENS_R_TYPE == "4")
                    {
                        // Progressive
                        _element.Element("ADD").Value = modelCheckOrder.LENS_R_ADD;
                        _element.Element("SEG_HEIGHT").Value = modelCheckOrder.LENS_R_SEG_HEIGHT;
                        _element.Element("OC_HEIGHT").Value = "";
                    }
                    else
                    {
                        // Single Vision
                        _element.Element("ADD").Value = "";
                        _element.Element("SEG_HEIGHT").Value = "";
                        _element.Element("OC_HEIGHT").Value = modelCheckOrder.LENS_R_OC_HEIGHT;
                    }
                }
                else
                {
                    _element.Element("SPHERE").Value = modelCheckOrder.LENS_L_SPHERE;
                    _element.Element("CYLINDER").Value = modelCheckOrder.LENS_L_CYLINDER;
                    _element.Element("AXIS").Value = modelCheckOrder.LENS_L_AXIS;

                    XElement subPD = _element.Element("PD");
                    subPD.Element("DISTANCE").Value = modelCheckOrder.LENS_L_DISTANCE;

                    if (modelCheckOrder.LENS_R_TYPE == "4")
                    {
                        // Progressive
                        _element.Element("ADD").Value = modelCheckOrder.LENS_L_ADD;
                        _element.Element("SEG_HEIGHT").Value = modelCheckOrder.LENS_L_SEG_HEIGHT;
                        _element.Element("OC_HEIGHT").Value = "";

                    }
                    else
                    {
                        // Single Vision
                        _element.Element("ADD").Value = "";
                        _element.Element("SEG_HEIGHT").Value = "";
                        _element.Element("OC_HEIGHT").Value = modelCheckOrder.LENS_L_OC_HEIGHT;
                    }

                }
            }

            //
            // Update <ITEMS><FRAME>
            //

            IEnumerable<XElement> TagFRAME = baseRequest.Descendants("FRAME");
            foreach (XElement _element in TagFRAME)
            {
                if (_element.Name.LocalName == "FRAME")
                {
                    _element.Element("UPC").Value = modelCheckOrder.FRAME_UPC;
                    _element.Element("DBL").Value = modelCheckOrder.FRAME_DBL;
                }
            }


            ////////////////////////////////////
            //
            // ...now the XML document
            //
            ////////////////////////////////////

            XmlDocument soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml(baseRequest.ToString());


            //
            // Logging
            //
            //if (_iLoggingLevel > (int)LoggingLevelEnums.None)
            //{
            //    ExceptionLoggingService.Instance.WriteRXOWSLog("HTTPClient.InvokeRXOCheckOrder", "rxoCheckOrder Request", soapEnvelopeXml.InnerXml.ToString());
            //}


            ////////////////////////////////////
            //
            // 
            //
            ////////////////////////////////////

            using (Stream stream = request.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }


            ////////////////////////////////////
            //
            // 
            //
            ////////////////////////////////////

            try
            {
                WebResponse webResponse = request.GetResponse();

                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            soapResult = responseReader.ReadToEnd();
                            Console.WriteLine(soapResult);

                            //
                            // Logging
                            //
                            //if (_iLoggingLevel > (int)LoggingLevelEnums.None)
                            //{
                            //    ExceptionLoggingService.Instance.WriteRXOWSLog("HTTPClient.InvokeRXOCheckOrder", "rxoCheckOrder Response", soapResult);
                            //}

                            //
                            // Now parse the response
                            //
                            string strResponseCode = null;
                            XDocument doc = XDocument.Parse(soapResult);
                            XNamespace ns = "http://rxo.webservices.luxottica.it/";

                            iReturnFromResponse = 502;

                            IEnumerable<XElement> responses = doc.Descendants("LMS_MAKEABILITY_SUCCESS_RESULT");
                            if (responses.Count() > 0)
                            {
                                foreach (XElement _element in responses)
                                {
                                    strResponseCode = (string)_element.Element("FRAME_IN_STOCK");
                                }

                                if (strResponseCode != null)
                                {
                                    if (strResponseCode == "Y")
                                    {
                                        responseCheckOrder.ErrorCode = 0;
                                        responseCheckOrder.ErrorDescription = "Y";
                                        iReturnFromResponse = 0;
                                    }
                                    else
                                    {
                                        responseCheckOrder.ErrorCode = 0;
                                        responseCheckOrder.ErrorDescription = "N";
                                        iReturnFromResponse = 0;
                                    }
                                }
                            }

                            IEnumerable<XElement> responses2 = doc.Descendants("LMS_MAKEABILITY_FAILURE_RESULT_ENTRY");
                            if (responses2.Count() > 0)
                            {
                                foreach (XElement _element in responses2)
                                {
                                    if (_element.Name.LocalName == "LMS_MAKEABILITY_FAILURE_RESULT_ENTRY")
                                    {
                                        strResponseCode = (string)_element.Element("EYENET_ERROR_CODE");
                                        responseCheckOrder.ErrorCode = Convert.ToInt32(strResponseCode);
                                        responseCheckOrder.ErrorDescription = (string)_element.Element("EYENET_ERROR_MESSAGE");
                                    }
                                }
                                iReturnFromResponse = 502;
                            }                            
                        }
                    }
                }
            }
            catch (WebException webex)
            {
                //var resp = new StreamReader(webex.Response.GetResponseStream()).ReadToEnd();

                if (webex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = webex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                        iReturnFromResponse = (int)response.StatusCode;
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else if (webex.Status == WebExceptionStatus.Timeout)
                {
                    iReturnFromResponse = (int)HttpStatusCode.RequestTimeout;
                }
                else
                {
                    // no http status code available
                }
            }
            catch (Exception ex)
            {
                iReturnFromResponse = 502;
            }

            responseCheckOrder.ErrorCode = iReturnFromResponse;
            responseCheckOrder.ErrorDescription = DecodeResponseCodes(iReturnFromResponse);

            // Override specifics
            if (responseCheckOrder.ErrorCode != -999)
            {
                responseCheckOrder.ErrorCode = responseCheckOrder.ErrorCode;
                responseCheckOrder.ErrorDescription = responseCheckOrder.ErrorDescription;
            }

            // Auditing

            RxoWsAuditing recordAudit = new RxoWsAuditing()
            {
                DoorNumber = modelCheckOrder.ACCOUNT,
                EventName = "CheckOrder",
                EventDescription = "Request to Luxottica Rxo CheckOrder WebService",
                EventDate = DateTime.Now,
                EventStatus = responseCheckOrder.ErrorCode.ToString(),
                EventRequest = stringRequest,
                EventResponse = soapResult
            };

            rxoRepository.AddEntity(recordAudit);

            if (!rxoRepository.SaveAll())
            {
                // ...some logging...
            }



            return responseCheckOrder;
        }

        public RxoBaseResponseEntity CallSendOrder(RxoSendOrderRequest modelSendOrder)
        {
            int iReturnFromResponse = 0;
            string soapResult = "";


            ////////////////////////////////////
            //
            // ...config stuff
            //
            ////////////////////////////////////

            modelSendOrder.ORIGIN_NAME = configRxoWs.ORIGIN_NAME;


            ////////////////////////////////////
            //
            // create the service response
            //
            ////////////////////////////////////

            RxoBaseResponseEntity responseSendOrder = new RxoBaseResponseEntity();


            ////////////////////////////////////
            //
            // Create the HTTP web request
            //
            ////////////////////////////////////

            HttpWebRequest request = CreateWebRequestForSendOrder(configRxoWs);

            ////////////////////////////////////
            //
            // Prepare the SOAP Request
            //
            ////////////////////////////////////

            string stringRequest = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:rxo=""http://rxo.webservices.luxottica.it/""  xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                                        <soapenv:Header/>
                                        <soapenv:Body>
                                           <rxo:rxoOrder>
                                              <arg0 id=""{0}"">
                                                 <HEADER>	
                                                 <ORIGIN>
                                                    <NAME>{1}</NAME>
                                                 </ORIGIN>
                                                 <DATE_REQUESTED>{2}</DATE_REQUESTED>
                                                 <ACCOUNT class=""orderBy"">
                                                 <ACCOUNT_ID>{3}</ACCOUNT_ID>
                                                 </ACCOUNT>
                                                 <ACCOUNT class=""shipTo"">
                                                 <ACCOUNT_ID>{3}</ACCOUNT_ID>
                                                 </ACCOUNT>
                                                 <ACCOUNT class=""billTo"">
                                                 <ACCOUNT_ID>{3}</ACCOUNT_ID>
                                                 </ACCOUNT>
                                                 <PATIENT>
                                                 <FIRST_NAME>{4}</FIRST_NAME>
                                                 <LAST_NAME>{4}</LAST_NAME>
                                                 </PATIENT>
                                                 </HEADER> 
         
                                                 <LENS eye=""R"">
                                                    <SALES_ARTICLE>{5}</SALES_ARTICLE>
                                                    <SPHERE>{6}</SPHERE>
                                                    <CYLINDER>{7}</CYLINDER>
                                                    <AXIS>{8}</AXIS>
                                                    <PD>
                                                       <DISTANCE>{9}</DISTANCE>
                                                    </PD>
                                                    <ADD>{10}</ADD>
                                                    <SEG_HEIGHT xsi:nil=""true"">{11}</SEG_HEIGHT>
                                                    <OC_HEIGHT class=""Height"">{12}</OC_HEIGHT>
                                                    <OPC></OPC>
                                                 </LENS>

                                                 <LENS eye=""L"">
                                                    <SALES_ARTICLE>{5}</SALES_ARTICLE>
                                                    <SPHERE>{13}</SPHERE>
                                                    <CYLINDER>{14}</CYLINDER>
                                                    <AXIS>{15}</AXIS>
                                                    <PD>
                                                       <DISTANCE>{16}</DISTANCE>
                                                    </PD>
                                                    <ADD>{17}</ADD>
                                                    <SEG_HEIGHT xsi:nil=""true"">{18}</SEG_HEIGHT>
                                                    <OC_HEIGHT class=""Height"">{19}</OC_HEIGHT>
                                                    <OPC/>
                                                 </LENS>

                                                 <ITEMS>
                                                    <FRAME>
                                                       <UPC>{20}</UPC>
                                                       <DBL>{21}</DBL>
                                                    </FRAME>
                                                 </ITEMS>
                                              </arg0>
                                           </rxo:rxoOrder>
                                        </soapenv:Body>
                                     </soapenv:Envelope>";


            stringRequest = stringRequest.Replace("{0}", modelSendOrder.arg0);

            XDocument baseRequest = XDocument.Parse(stringRequest);

            //
            // Update <HEADER><ORIGIN><NAME>
            //
            IEnumerable<XElement> TagORIGIN = baseRequest.Descendants("ORIGIN");
            foreach (XElement _element in TagORIGIN)
            {
                if (_element.Name.LocalName == "ORIGIN")
                {
                    _element.Element("NAME").Value = modelSendOrder.ORIGIN_NAME;
                }
            }

            //
            // Update <HEADER><DATE_REQUESTED>
            //
            IEnumerable<XElement> TagDATE_REQUESTED = baseRequest.Descendants("HEADER");
            foreach (XElement _element in TagDATE_REQUESTED)
            {
                if (_element.Name.LocalName == "HEADER")
                {
                    _element.Element("DATE_REQUESTED").Value = DateTime.Now.ToString("yyyy-MM-dd");
                }
            }

            //
            // Update <HEADER><ORIGIN><ACCOUNT>
            //
            IEnumerable<XElement> TagACCOUNT = baseRequest.Descendants("ACCOUNT");
            foreach (XElement _element in TagACCOUNT)
            {
                if (_element.Name.LocalName == "ACCOUNT")
                {
                    _element.Element("ACCOUNT_ID").Value = modelSendOrder.ACCOUNT;
                }
            }

            //
            // Update <HEADER><ORIGIN><PATIENT>
            //
            IEnumerable<XElement> TagPATIENT = baseRequest.Descendants("PATIENT");
            foreach (XElement _element in TagPATIENT)
            {
                if (_element.Name.LocalName == "PATIENT")
                {
                    _element.Element("FIRST_NAME").Value = modelSendOrder.PATIENT_FIRST_NAME;
                    _element.Element("LAST_NAME").Value = modelSendOrder.PATIENT_LAST_NAME;
                }
            }

            //
            // Update <LENS ...>
            //
            IEnumerable<XElement> TagLENSR = baseRequest.Descendants("LENS");
            foreach (XElement _element in TagLENSR)
            {
                if (_element.Name.LocalName == "LENS")
                {
                    _element.Element("SALES_ARTICLE").Value = modelSendOrder.LENS_SALES_ARTICLE;
                }

                if (_element.Name.LocalName == "LENS" && _element.FirstAttribute.Value == "R")
                {
                    _element.Element("SPHERE").Value = modelSendOrder.LENS_R_SPHERE;
                    _element.Element("CYLINDER").Value = modelSendOrder.LENS_R_CYLINDER;
                    _element.Element("AXIS").Value = modelSendOrder.LENS_R_AXIS;

                    XElement subPD = _element.Element("PD");
                    subPD.Element("DISTANCE").Value = modelSendOrder.LENS_R_DISTANCE;

                    if (modelSendOrder.LENS_R_TYPE == "4")
                    {
                        // Progressive
                        _element.Element("ADD").Value = modelSendOrder.LENS_R_ADD;
                        _element.Element("SEG_HEIGHT").Value = modelSendOrder.LENS_R_SEG_HEIGHT;
                        _element.Element("OC_HEIGHT").Value = "";
                    }
                    else
                    {
                        // Single Vision
                        _element.Element("ADD").Value = "";
                        _element.Element("SEG_HEIGHT").Value = "";
                        _element.Element("OC_HEIGHT").Value = modelSendOrder.LENS_R_OC_HEIGHT;
                    }
                }
                else
                {
                    _element.Element("SPHERE").Value = modelSendOrder.LENS_L_SPHERE;
                    _element.Element("CYLINDER").Value = modelSendOrder.LENS_L_CYLINDER;
                    _element.Element("AXIS").Value = modelSendOrder.LENS_L_AXIS;

                    XElement subPD = _element.Element("PD");
                    subPD.Element("DISTANCE").Value = modelSendOrder.LENS_L_DISTANCE;

                    if (modelSendOrder.LENS_R_TYPE == "4")
                    {
                        // Progressive
                        _element.Element("ADD").Value = modelSendOrder.LENS_L_ADD;
                        _element.Element("SEG_HEIGHT").Value = modelSendOrder.LENS_L_SEG_HEIGHT;
                        _element.Element("OC_HEIGHT").Value = "";

                    }
                    else
                    {
                        // Single Vision
                        _element.Element("ADD").Value = "";
                        _element.Element("SEG_HEIGHT").Value = "";
                        _element.Element("OC_HEIGHT").Value = modelSendOrder.LENS_L_OC_HEIGHT;
                    }

                }
            }

            //
            // Update <ITEMS><FRAME>
            //

            IEnumerable<XElement> TagFRAME = baseRequest.Descendants("FRAME");
            foreach (XElement _element in TagFRAME)
            {
                if (_element.Name.LocalName == "FRAME")
                {
                    _element.Element("UPC").Value = modelSendOrder.FRAME_UPC;
                    _element.Element("DBL").Value = modelSendOrder.FRAME_DBL;
                }
            }


            ////////////////////////////////////
            //
            // 
            //
            ////////////////////////////////////

            XmlDocument soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml(baseRequest.ToString());

            //
            // Logging
            //
            //if (_iLoggingLevel > (int)LoggingLevelEnums.None)
            //{
            //    ExceptionLoggingService.Instance.WriteRXOWSLog("HTTPClient.InvokeRXOOrder", "rxoOrder Request", soapEnvelopeXml.InnerXml.ToString());
            //}

            ////////////////////////////////////
            //
            // 
            //
            ////////////////////////////////////

            using (Stream webStream = request.GetRequestStream())

            using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.UTF8))
            {
                requestWriter.Write(soapEnvelopeXml.InnerXml.ToString());
            }

            ////////////////////////////////////
            //
            // 
            //
            ////////////////////////////////////

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        Console.WriteLine(soapResult);

                        //
                        // Logging
                        //
                        //if (_iLoggingLevel > (int)LoggingLevelEnums.None)
                        //{
                        //    ExceptionLoggingService.Instance.WriteRXOWSLog("HTTPClient.InvokeRXOOrder", "rxoOrder Response", soapResult);
                        //}

                        //
                        // Now parse the response
                        //
                        string strResponseCode = null;
                        XDocument doc = XDocument.Parse(soapResult);
                        XNamespace ns = "http://rxo.webservices.luxottica.it/";

                        IEnumerable<XElement> responses = doc.Descendants(ns + "rxoOrderResponse");
                        foreach (XElement _element in responses)
                        {
                            strResponseCode = (string)_element.Element("return");
                        }

                        if (strResponseCode != null)
                        {
                            iReturnFromResponse = 503;
                            Int32.TryParse(strResponseCode, out iReturnFromResponse);

                            if (iReturnFromResponse == -1)
                            {
                                responseSendOrder.ErrorCode = iReturnFromResponse;
                                responseSendOrder.ErrorDescription = @"RXOOrder Generic Error";
                            }
                            else
                            {
                                responseSendOrder.ErrorCode = 0;
                                responseSendOrder.ErrorDescription = strResponseCode;
                            }

                            iReturnFromResponse = responseSendOrder.ErrorCode;
                        }
                        else
                            iReturnFromResponse = 503;
                    }
                }

            }
            catch (WebException webex)
            {
                if (webex.Status == WebExceptionStatus.ProtocolError)
                {
                    var response = webex.Response as HttpWebResponse;
                    if (response != null)
                    {
                        Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
                        iReturnFromResponse = (int)response.StatusCode;
                    }
                    else
                    {
                        // no http status code available
                    }
                }
                else if (webex.Status == WebExceptionStatus.Timeout)
                {
                    iReturnFromResponse = (int)HttpStatusCode.RequestTimeout;
                }
                else
                {
                    // no http status code available
                }
            }
            catch (Exception ex)
            {
                iReturnFromResponse = 503;
            }


            //return 0;           
            

            responseSendOrder.ErrorCode = iReturnFromResponse;
            responseSendOrder.ErrorDescription = DecodeResponseCodes(iReturnFromResponse);

            // Override specifics
            if (responseSendOrder.ErrorCode != -999)
            {
                responseSendOrder.ErrorCode = responseSendOrder.ErrorCode;
                responseSendOrder.ErrorDescription = responseSendOrder.ErrorDescription;
            }


            // Auditing

            RxoWsAuditing recordAudit = new RxoWsAuditing()
            {
                DoorNumber = modelSendOrder.ACCOUNT,
                EventName = "SendOrder",
                EventDescription = "Send a Rxo Order to Luxottica",
                EventDate = DateTime.Now,
                EventStatus = responseSendOrder.ErrorCode.ToString(),
                EventRequest = stringRequest,
                EventResponse = soapResult
            };

            rxoRepository.AddEntity(recordAudit);

            if (!rxoRepository.SaveAll())
            {
                // ...some logging...
            }


            return responseSendOrder;
        }


        #region PRIVATE / INTERNALS

        private HttpWebRequest CreateWebRequest(RxoWSConfigData _ReqDetails)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls
                                                            | System.Net.SecurityProtocolType.Tls11
                                                            | System.Net.SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_ReqDetails.Address);

            //
            // Soap action
            //

            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";

            //
            // Set HttpWebRequest timeout
            //

            if (_ReqDetails.HttpRequest > 0)
            {
                webRequest.Timeout = (_ReqDetails.HttpRequest * 1000);
            }

            //
            // Add Basic Authentication
            //
            if (_ReqDetails.BasicAuth)
            {
                string username = _ReqDetails.BasicAuthUsername;
                string password = _ReqDetails.BasicAuthPassword;

                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

                webRequest.Headers.Add("Authorization", "Basic " + svcCredentials);
            }

            //
            // eventually manage certificates
            //
            //X509Certificate Cert = X509Certificate.CreateFromCertFile("C:\\myluxotticacom.crt");
            //AttachClientCertificate(webRequest, "a", "b");

            return webRequest;
        }


        private HttpWebRequest CreateWebRequestForSendOrder(RxoWSConfigData _ReqDetails)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls
                                                            | System.Net.SecurityProtocolType.Tls11
                                                            | System.Net.SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_ReqDetails.Address);

            //
            // Soap action
            //

            webRequest.Headers.Add("SOAPAction", "http://webservices.luxottica.it/RXOService/rxoOrderRequest");

            //
            //set compression
            //
            webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";

            //
            //set connection properties
            //
            webRequest.KeepAlive = true;  //15 sec on server side
            webRequest.Accept = "text/xml";

            //
            //set verb
            //
            webRequest.Method = "POST";

            //
            // Set HttpWebRequest timeout
            //
            if (_ReqDetails.HttpRequest > 0)
            {
                webRequest.Timeout = (_ReqDetails.HttpRequest * 1000);
            }

            //
            // Add Basic Authentication
            //
            if (_ReqDetails.BasicAuth)
            {
                string username = _ReqDetails.BasicAuthUsername;
                string password = _ReqDetails.BasicAuthPassword;

                string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));

                webRequest.Headers.Add("Authorization", "Basic " + svcCredentials);
            }

            return webRequest;
        }



        private string DecodeResponseCodes(int ValueToDecode)
        {
            string _strDecode = "";

            switch (ValueToDecode)
            {

                case 0:
                {
                    _strDecode = "OK";
                }
                break;
                case 1:
                {
                    _strDecode = "cannot buy";
                }
                break;
                case 2:
                {
                    _strDecode = "cannot provide RX Service";
                }
                break;
                case -1:
                {
                    _strDecode = "internal error";
                }
                break;
                case -2:
                {
                    _strDecode = "UPC Code not found";
                }
                break;
                case -3:
                {
                    _strDecode = "Customer not found";
                }
                break;

                case 408:
                {
                    _strDecode = "RequestTimeout";
                }
                break;

                case 500:
                {
                    _strDecode = "Internal Server Error";
                }
                break;

                case 501:
                {
                    _strDecode = "RXOCheckFrame Generic Error";
                }
                break;

                case 502:
                {
                    _strDecode = "RXOCheckOrder Generic Error";
                }
                break;

                case 503:
                {
                    _strDecode = "RXOOrder Generic Error";
                }
                break;

                default:
                    return _strDecode;
                    break;
            }

            return _strDecode;
        }

        #endregion 
    }

}

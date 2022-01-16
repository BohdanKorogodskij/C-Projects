using AkzonobelScript.Infrastructure.Abstract;
using AkzonobelScript.Infrastructure.Entity;
using AkzonobelScript.Infrastructure.Entity.Enum;
using AkzonobelScript.Models;
using Entity;
using Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AkzonobelScript.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReception _reception;
        private readonly IQuestion _question;
        private readonly IQuestionOperator _questionOperator;
        private readonly IOperator _operator;
        private readonly IEmailHandle _email;
        private readonly ISession _session;
        private readonly ISendMessage _sendMessage;
        public HomeController(IReception reception, IQuestion question, IOperator operatorData, IEmailHandle email, ISession session, IQuestionOperator questionOperator, ISendMessage sendMessage)
        {
            _reception = reception;
            _question = question;
            _operator = operatorData;
            _email = email;
            _session = session;
            _questionOperator = questionOperator;
            _sendMessage = sendMessage;
        }
        public ActionResult Index(string ani, int? routerCallKey, int? routerCallKeyDay, string peripheralNumber, string callSubject, string DNIS, string admin, bool isRedirect = false)
        {
            CheckRedir("|Index", isRedirect);
            IEnumerable<QuestionBase> questionList = _question.GetQuestion.OrderBy(x => x.KODID).Take(6);
            var operatorData = new OperatorModel
            {
                question = questionList
            };
            if (!routerCallKey.HasValue && !routerCallKeyDay.HasValue && string.IsNullOrEmpty(peripheralNumber) && string.IsNullOrEmpty(DNIS))
            {
                goto NotChanged;
            }
            Session.Clear();
            OperatorData operData = _operator.GetOperatorLogin(peripheralNumber);
            if(operData == null)
            {
                operData = new OperatorData();
            }
            if (Session["IsFirstOpen"] != null)
            {
                Session["HistoryClient"] += "|Главная";
            }else
            {
                Session["IsFirstOpen"] = true;
            }
            if(!string.IsNullOrEmpty(admin))
            {
                Session["admin"] = true;
            }
            Session["callId"] = $"{routerCallKeyDay}{routerCallKey}";
            Session["operator"] = operData.LoginName ?? "оператор не найден";
            Session["ani"] = ani;
            Session["DNIS"] = DNIS;
            
            NotChanged:
            return View(operatorData);
        }
        public ActionResult Help(bool isRedirect = false)
        {
            CheckRedir("|Help", isRedirect);
            Session["HistoryClient"] += "|Справка";
            return View();
        }

        public ActionResult Question(bool isRedirect = false)
        {
            CheckRedir("|Question", isRedirect);
            Session["HistoryClient"] += "|Вопрос оператора";
            return View();
        }

        public ActionResult Reception(bool isReturn = false, bool isRedirect = false)
        {
            CheckRedir("|Reception", isRedirect);
            Session["HistoryClient"] += "|Ресепшн";
            if(Session["AlreadyReception"] == null)
            {
                Session["AlreadyReception"] = true;
            }
            ViewBag.Reception = true;
            ViewBag.IsReturn = isReturn;
            return View();
        }
        public string SearchReception(FieldReception? orderBy, AD? ad, string search = "")
        {
            IEnumerable<ReceptionBase> receptionList = _reception.GetReception(orderBy, ad, search);
            return JsonConvert.SerializeObject(receptionList);
        }
        public ActionResult TypeCall(TypeCallDescRedir type, bool isRedirect = false)
        {
            var route = string.Empty;
            switch(type)
            {
                case TypeCallDescRedir.EnglishLang:
                    route = "TypeCall";
                    Session["HistoryClient"] += "|Англоязычный звонок";
                    CheckRedir("|TypeCall", isRedirect);
                    break;
                case TypeCallDescRedir.Fail:
                    route = "TypeCallFail";
                    Session["HistoryClient"] += "|Ошиблись номером";
                    CheckRedir("|TypeCallFail", isRedirect);
                    break;
                case TypeCallDescRedir.Hooligan:
                    route = "TypeCallHooligan";
                    Session["HistoryClient"] += "|Хулиганский звонок";
                    CheckRedir("|TypeCallHooligan", isRedirect);
                    break;
                case TypeCallDescRedir.Silence:
                    route = "TypeCallSilence";
                    Session["HistoryClient"] += "|Тишина в трубке";
                    CheckRedir("|TypeCallSilence", isRedirect);
                    break;
                case TypeCallDescRedir.Break:
                    route = "EndCall";
                    Session["HistoryClient"] += "|Обрыв соединения";
                    CheckRedir("|EndCall", isRedirect);
                    break;
            }
            return View(route);
        }
        private void CheckRedir(string route, bool isRedirect)
        {
            if(!isRedirect)
            {
                Session["HistoryRoute"] += route;
            }
        }

        public ActionResult EndCall(string title = "", bool isRedirect = false)
        {
            CheckRedir("|EndCall", isRedirect);
            if (title != "")
            {
                Session["HistoryClient"] += $"|{title}";
            } else {
                Session["HistoryClient"] += "|Всего доброго, До свидания!";
            }
            return View();
        }
        public ActionResult Result()
        {
            string conid = Session["callId"].ToString();
            string login = Session["operator"].ToString();
            string question = "Текст вопроса";
            _questionOperator.AddQuestionOperator(conid, login, question);
            _email.SendQuestion(login, question);

            var akDetail = new AkzonobelDetail();
            akDetail.user_login = Session["operator"].ToString();
            akDetail.connid = Session["callId"].ToString();
            akDetail.unicid = 0;
            akDetail.ani = Session["ani"].ToString();
            akDetail.dnis = Session["DNIS"].ToString();
            akDetail.callsubject = "";
            akDetail.callresult = "";
            akDetail.an_time_work = 0;
            akDetail.an_temp_under = "";
            akDetail.an_temp_count = 0;
            akDetail.an_temp_arrayQuestion = "";
            akDetail.an_temp_AnswersPath = "";
            akDetail.an_temp_level_txt = $"|Главная{Session["HistoryClient"].ToString()}";
            akDetail.attempt = 0;
            akDetail.an_callhistory = Session["HistoryClient"].ToString();
            _session.UpdateSession(akDetail);
            Session.Clear();
            return View("ResultView", "_Result");
        }
        public ActionResult InfoOperator()
        {
            return View("InfoOperator", "_Info");
        }
        public ActionResult Email(string address)
        {
            ViewBag.Email = address;
            return PartialView();
        }
        public void EmailSend(Email email)
        {
            var connid = Session["callId"].ToString();
            email.Login = Session["operator"].ToString();
            var sBodyTxt = $@"
От: {email.FioTxt ?? email.Fio}
Компания: {email.CompanyTxt ?? email.Company}
Контактный телефон: {email.Phone}
Текст сообщения: {email.Message}
login: {email.Login}
Согласие на предоставление персональных данных: {(email.IsCancel ? "Получено" : "Не получено")}";
            _sendMessage.AddMessage(connid, email.Address, "", email.FioTxt ?? email.Fio, email.CompanyTxt ?? email.Company, "", sBodyTxt, email.Login, "");
            _email.Send(email);
        }
        public string SearchOperator(string oper, string LOGON_USER)
        {
            if (string.IsNullOrEmpty(oper))
            {
                if (string.IsNullOrEmpty(LOGON_USER))
                {
                    oper = "anonymous";
                }
                else
                {
                    if (LOGON_USER.Length >= 6)
                    { oper = LOGON_USER.ToUpper().Substring(6); }
                }
            }
            return oper;
        }
        public string NextSave()
        {
            Session["HistoryClient"] += "|Далее";
            return Session["HistoryClient"].ToString();
        }
        public string BackRoute()
        {
            string backRoute = "";
            string route = Session["HistoryRoute"] != null ? Session["HistoryRoute"].ToString() : "";
            if(route == "")
            {
                goto RouteOff;
            }
            List<string> format = route.Split('|').Where(item => item != "").ToList();
            int length = format.Count;
            if(length > 1)
            {
                format.RemoveAt(length - 1);
                string formatConcat = string.Join("|", format);
                Session["HistoryRoute"] = formatConcat;
            }
            backRoute = format.Last();

            RouteOff:
            return backRoute;
        }
    }
}
using AkzonobelScript.Infrastructure.Abstract;
using AkzonobelScript.Infrastructure.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AkzonobelScript.Infrastructure.Concrete
{
    public class EmailHandle : IEmailHandle
    {
        private string _connection;
        public EmailHandle(string connection)
        {
            _connection = connection;
        }
        public void Send(Email email)
        {
            var fio = email.FioTxt ?? email.Fio;
            var company = email.CompanyTxt ?? email.Company;
            var sBodyTxt = $@"
От: {fio}
Компания: {company}
Контактный телефон: {email.Phone}
Текст сообщения: {email.Message}
login: {email.Login}
Согласие на предоставление персональных данных: {(email.IsCancel ? "Получено" : "Не получено")}";

            var logEmail = LogManager.GetLogger("email");
            try
            {
                logEmail.Info(sBodyTxt);
            } catch(Exception)
            {

            }
        }
        public void SendQuestion(string operatorName, string question)
        {
            var sBodyTxt = $@"
Оператор: {operatorName}

Вопрос оператора: {question}
";
            var logEmail = LogManager.GetLogger("email");
            try
            {
                logEmail.Info(sBodyTxt);
            }
            catch (Exception)
            {

            }
        }
    }
}
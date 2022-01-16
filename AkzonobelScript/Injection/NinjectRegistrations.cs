using Ninject.Modules;
using Interface;
using Concrete;
using AkzonobelScript.Infrastructure.Concrete;
using AkzonobelScript.Infrastructure.Abstract;

namespace AkzonobelScript.Injection
{
    public class NinjectRegistrations : NinjectModule
    {
        private static readonly string ConnectionString = "Data Source=172.16.32.198;Initial Catalog=AkzoNobel;Persist Security Info=True;User ID=AkzoNobel.ProjectConfig;Password=123456Q!";
        public override void Load()
        {
            Bind<IQuestion>().To<Question>().WithConstructorArgument("connection", ConnectionString);
            Bind<IQuestionOperator>().To<QuestionOperator>().WithConstructorArgument("connection", ConnectionString);
            Bind<IReception>().To<Reception>().WithConstructorArgument("connection", ConnectionString);
            Bind<ISendMessage>().To<SendMessage>().WithConstructorArgument("connection", ConnectionString);
            Bind<ISession>().To<Session>().WithConstructorArgument("connection", ConnectionString);
            Bind<IOperator>().To<Operator>().WithConstructorArgument("connection", ConnectionString);
            Bind<IEmailHandle>().To<EmailHandle>().WithConstructorArgument("connection", ConnectionString);
        }
    }
}
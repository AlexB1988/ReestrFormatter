using Autofac;
using ReestrFormatter.Interfaces;
using ReestrFormatter.Services;

namespace ReestrFormatter.DI
{
    public class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SberFormatter>().As<IFormatter>();
            builder.RegisterType<SberFormatter>().Named<IFormatter>("sber");
            builder.RegisterType<PochtaFormatter>().Named<IFormatter>("pochta");
            builder.RegisterType<RnkbFormatter>().Named<IFormatter>("rnkb"); 
            builder.RegisterType<OtkritieFormatter>().Named<IFormatter>("otkr");
            builder.RegisterType<KbFormatter>().Named<IFormatter>("kb");
            builder.RegisterType<MainForm>().AsSelf();
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AssignableTo<Form>()
                .AsSelf();
        }
    }
}

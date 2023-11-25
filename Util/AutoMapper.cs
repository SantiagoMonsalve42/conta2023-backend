using AutoMapper;
using System.Data;
namespace Util
{
    public static class AutoMapper
    {
        public static TNew Clone<TOrigin, TNew>(this TOrigin obj)
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TOrigin, TNew>();
            });
            var mapper = config.CreateMapper();
            var resultado = mapper.Map<TOrigin, TNew>(obj);
            return resultado;
        }
        public static ICollection<TNew> Clone<TOrigin, TNew>(this ICollection<TOrigin> obj)
        {
            var config = new MapperConfiguration(x =>
            {
                x.CreateMap<TOrigin, TNew>();
            });
            var mapper = config.CreateMapper();
            var resultado = mapper.Map<ICollection<TNew>>(obj);
            return resultado;
        }
        
    }
}

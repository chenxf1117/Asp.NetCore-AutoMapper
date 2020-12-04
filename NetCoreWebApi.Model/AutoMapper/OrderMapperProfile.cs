using AutoMapper;
using NetCoreWebApi.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model.AutoMapper
{
    /// <summary>
    /// 映射配置
    /// </summary>
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, OrderDTO>();
            //字段名称不一致 Name映射到OrderName
            CreateMap<Order, OrderDTO>().ForMember(dest => dest.OrderName, src => src.MapFrom(s => s.Name));
            //字段类型不一致 源类型DateTime映射到目标类型String字符串
            CreateMap<OrderItem, OrderItemDTO>().ForMember(dest => dest.CreateTime, src => src.ConvertUsing(new FormatConvert()));
        }
    }

    /// <summary>
    /// DateTime映射到String
    /// </summary>
    public class FormatConvert : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime sourceMember, ResolutionContext context)
        {
            if (sourceMember == null)
                return DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return sourceMember.ToString("yyyyMMddHHmmssfff");
        }
    }
}

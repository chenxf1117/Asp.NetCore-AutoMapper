using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NetCoreWebApi.Model.AutoMapper
{
    public class BatchMapperProfile : Profile
    {
        public BatchMapperProfile()
        {
            InitMapper();
        }

        public void InitMapper()
        {
            //获取所有需要依据特性进行映射的DTO类
            var typeList = Assembly.GetAssembly(typeof(OrderDTO)).GetTypes().Where(t => t.GetCustomAttributes(typeof(TypeMapperAttribute)).Any()).ToList();
            typeList.ForEach(type =>
            {
                //获取类指定的特性
                var attribute = (TypeMapperAttribute)type.GetCustomAttributes(typeof(TypeMapperAttribute)).FirstOrDefault();
                if (attribute == null || attribute.SourceType == null)
                    return;
                //类映射
                var mapper = CreateMap(attribute.SourceType, type);

                //处理类中映射规则不同的属性
                var propertyAttributes = type.GetProperties().Where(p => p.GetCustomAttributes(typeof(PropertyMapperAttribute)).Any()).ToList();
                propertyAttributes.ForEach(property =>
                {
                    //获取属性指定特性
                    var propertyAttribute = (PropertyMapperAttribute)property.GetCustomAttributes(typeof(PropertyMapperAttribute)).FirstOrDefault();
                    if (propertyAttribute == null)
                        return;
                    if (!string.IsNullOrEmpty(propertyAttribute.SourceName))
                    {
                        //属性名称自定义映射
                        mapper.ForMember(property.Name, src => src.MapFrom(propertyAttribute.SourceName));
                    }
                    if (propertyAttribute.SourceDataType != null && propertyAttribute.SourceDataType == typeof(DateTime))
                    {
                        //DateTime数据类型 映射 自定义字符串格式
                        mapper.ForMember(property.Name, src => src.ConvertUsing(new FormatBatchConvert()));
                    }
                });

            });

        }
    }

    //AttributeUsage用与指定声明的特性的使用范围  
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Class, Inherited = true)]
    public class TypeMapperAttribute : Attribute
    {
        /// <summary>
        /// 源类型
        /// </summary>
        public Type SourceType { get; set; }

    }

    //AttributeUsage用与指定声明的特性的使用范围  
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class PropertyMapperAttribute : Attribute
    {
        /// <summary>
        /// 属性名称
        /// </summary>
        public string SourceName { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public Type SourceDataType { get; set; }
    }

    /// <summary>
    /// DateTime映射到String
    /// </summary>
    public class FormatBatchConvert : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime sourceMember, ResolutionContext context)
        {
            if (sourceMember == null)
                return DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return sourceMember.ToString("yyyyMMddHHmmssfff");
        }
    }
}

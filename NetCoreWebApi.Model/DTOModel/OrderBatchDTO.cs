using NetCoreWebApi.Model.AutoMapper;
using NetCoreWebApi.Model.DBModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model
{
    /// <summary>
    /// 源模型Order 映射到 目标模型OrderBatchDTO
    /// </summary>
    [TypeMapper(SourceType = typeof(Order))]
    public class OrderBatchDTO
    {
        public int Id { get; set; }
        /// <summary>
        /// Order.Name 映射到 OrderBatchDTO.OrderName
        /// </summary>
        [PropertyMapper(SourceName = "Name")]
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Order.CreateTime时间格式  映射到  OrderBatchDTO.CreateTime自定义字符串格式
        /// </summary>
        [PropertyMapper(SourceDataType = typeof(DateTime))]
        public string CreateTime { get; set; }
        public int CustomId { get; set; }
    }
}

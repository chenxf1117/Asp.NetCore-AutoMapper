using NetCoreWebApi.Model.AutoMapper;
using NetCoreWebApi.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model
{
    [TypeMapper(SourceType = typeof(OrderItem))]
    public class OrderItemBatchDTO
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        [PropertyMapper(SourceDataType = typeof(DateTime))]
        public string CreateTime { get; set; }
    }
}

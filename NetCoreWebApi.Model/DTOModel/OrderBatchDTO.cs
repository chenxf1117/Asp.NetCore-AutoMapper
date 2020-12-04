using NetCoreWebApi.Model.AutoMapper;
using NetCoreWebApi.Model.DBModel;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model
{
    [TypeMapper(SourceType = typeof(Order))]
    public class OrderBatchDTO
    {
        public int Id { get; set; }

        [PropertyMapper(SourceName = "Name")]
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        [PropertyMapper(SourceDataType = typeof(DateTime))]
        public string CreateTime { get; set; }
        public int CustomId { get; set; }
    }
}

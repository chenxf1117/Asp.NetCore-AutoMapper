using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model
{
    /// <summary>
    /// 订单映射模型
    /// </summary>
    public class OrderDTO
    {
        public int Id { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateTime { get; set; }
        public int CustomId { get; set; }
    }
}

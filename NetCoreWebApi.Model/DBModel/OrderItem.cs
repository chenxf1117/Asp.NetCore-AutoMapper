using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model.DBModel
{
    /// <summary>
    /// 订单子表
    /// </summary>
    [SugarTable("OrderDetail")]
    public class OrderItem
    {
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}

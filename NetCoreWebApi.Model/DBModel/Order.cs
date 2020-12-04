using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreWebApi.Model.DBModel
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class Order
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        public DateTime CreateTime { get; set; }

        public int CustomId { get; set; }
    }
}
